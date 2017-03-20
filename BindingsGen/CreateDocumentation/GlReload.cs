using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace OpenGL
{
    public partial class Gl
    {
        #region Fields

        //internal const string Library = "libGL.so.1";	// linux
        internal const string Library = "opengl32.dll";	// mac os x and windows

        private static Type glClass;
        private static Type delegatesClass;
        private static Type coreClass;
        private static FieldInfo[] delegates;

        #endregion

        #region Constructor

        static Gl()
        {
            glClass = typeof(Gl);
            delegatesClass = glClass.GetNestedType("Delegates", BindingFlags.Static | BindingFlags.NonPublic);
            coreClass = glClass.GetNestedType("NativeMethods", BindingFlags.Static | BindingFlags.NonPublic);
            // 'Touch' Imports class to force initialization. We don't want anything yet, just to have
            // this class ready.
            if (Core.FunctionMap != null) { }
            ReloadFunctions();
        }

        #endregion

        #region internal static partial class Core

        /// <summary>
        /// Contains DllImports for the core OpenGL functions.
        /// </summary>
        internal static partial class Core
        {
            /// <summary>
            ///  Build a string->MethodInfo map to speed up extension loading.
            /// </summary>
            internal static SortedList<string, MethodInfo> FunctionMap;  // This is faster than either Dictionary or SortedDictionary
            static Core()
            {
                MethodInfo[] methods = coreClass.GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
                FunctionMap = new SortedList<string, MethodInfo>(methods.Length);
                foreach (MethodInfo m in methods)
                    FunctionMap.Add(m.Name, m);
            }
        }

        #endregion

        #region public static void ReloadFunctions()

        /// <summary>
        /// Loads all OpenGL functions (core and extensions).
        /// </summary>
        /// <remarks>
        /// <para>
        /// This function will be automatically called the first time you use any opengl function.
        /// </para>
        /// <para>
        /// Call this function manually whenever you need to update OpenGL entry points.
        /// This need may arise if you change the pixelformat/visual, or in case you cannot
        /// (or do not want) to use the automatic initialization of the GL class.
        /// </para>
        /// </remarks>
        public static void ReloadFunctions()
        {
            // Using reflection is more than 3 times faster than directly loading delegates on the first
            // run, probably due to code generation overhead. Subsequent runs are faster with direct loading
            // than with reflection, but the first time is more significant.

            if (delegates == null)
                delegates = delegatesClass.GetFields(BindingFlags.Static | BindingFlags.NonPublic);

            foreach (FieldInfo f in delegates)
            {
                f.SetValue(null, GetDelegate(f.Name, f.FieldType));
                if (f.GetValue(null) == null) Console.WriteLine("Failed to load extension {0}.", f.Name);
            }
        }

        static void Set(object d, Delegate value)
        {
            d = value;
        }

        #endregion

        #region public static bool ReloadFunction(string function)

        /// <summary>
        /// Tries to reload the given OpenGL function (core or extension).
        /// </summary>
        /// <param name="function">The name of the OpenGL function (i.e. glShaderSource)</param>
        /// <returns>True if the function was found and reloaded, false otherwise.</returns>
        /// <remarks>
        /// <para>
        /// Use this function if you require greater granularity when loading OpenGL entry points.
        /// </para>
        /// <para>
        /// While the automatic initialisation will load all OpenGL entry points, in some cases
        /// the initialisation can take place before an OpenGL Context has been established.
        /// In this case, use this function to load the entry points for the OpenGL functions
        /// you will need, or use ReloadFunctions() to load all available entry points.
        /// </para>
        /// <para>
        /// This function returns true if the given OpenGL function is supported, false otherwise.
        /// </para>
        /// <para>
        /// To query for supported extensions use the IsExtensionSupported() function instead.
        /// </para>
        /// </remarks>
        public static bool Load(string function)
        {
            FieldInfo f = delegatesClass.GetField(function, BindingFlags.Static | BindingFlags.NonPublic);
            if (f == null)
                return false;

            Delegate old = f.GetValue(null) as Delegate;
            Delegate @new = GetDelegate(f.Name, f.FieldType);
            if (old.Target != @new.Target)
            {
                f.SetValue(null, @new);
            }
            return @new != null;
        }

        #endregion

        #region public static Delegate GetDelegate(string name, Type signature)

        /// <summary>
        /// Creates a System.Delegate that can be used to call an OpenGL function, core or extension.
        /// </summary>
        /// <param name="name">The name of the OpenGL function (eg. "glNewList")</param>
        /// <param name="signature">The signature of the OpenGL function.</param>
        /// <returns>
        /// A System.Delegate that can be used to call this OpenGL function, or null if the specified
        /// function name did not correspond to an OpenGL function.
        /// </returns>
        public static Delegate GetDelegate(string name, Type signature)
        {
            MethodInfo m;
            return GetExtensionDelegate(name, signature) ??
                  (Core.FunctionMap.TryGetValue((name.Substring(2)), out m) ?
                   Delegate.CreateDelegate(signature, m) : null);
        }

        #endregion

        #region internal static Delegate GetExtensionDelegate(string name, Type signature)

        /// <summary>
        /// Creates a System.Delegate that can be used to call a dynamically exported OpenGL function.
        /// </summary>
        /// <param name="name">The name of the OpenGL function (eg. "glNewList")</param>
        /// <param name="signature">The signature of the OpenGL function.</param>
        /// <returns>
        /// A System.Delegate that can be used to call this OpenGL function or null
        /// if the function is not available in the current OpenGL context.
        /// </returns>
        internal static Delegate GetExtensionDelegate(string name, Type signature)
        {
            IntPtr address = GetAddress(name);

            if (address == IntPtr.Zero ||
                address == new IntPtr(1) ||     // Workaround for buggy nvidia drivers which return
                address == new IntPtr(2))       // 1 or 2 instead of IntPtr.Zero for some extensions.
            {
                return null;
            }
            else
            {
                return Marshal.GetDelegateForFunctionPointer(address, signature);
            }
        }

        #endregion

        #region private static IntPtr GetAddress(string function)

        internal partial class NativeMethods
        {
            [DllImport(Library, EntryPoint = "wglGetProcAddress", ExactSpelling = true)]
            internal static extern IntPtr wglGetProcAddress(string lpszProc);

            [DllImport(Library, EntryPoint = "glXGetProcAddress")]
            internal static extern IntPtr glxGetProcAddress([MarshalAs(UnmanagedType.LPTStr)] string procName);

            [DllImport("libdl.dylib", EntryPoint = "NSIsSymbolNameDefined")]
            internal static extern bool NSIsSymbolNameDefined(string s);
            [DllImport("libdl.dylib", EntryPoint = "NSLookupAndBindSymbol")]
            internal static extern IntPtr NSLookupAndBindSymbol(string s);
            [DllImport("libdl.dylib", EntryPoint = "NSAddressOfSymbol")]
            internal static extern IntPtr NSAddressOfSymbol(IntPtr symbol);
        }

        private static IGetProcAddress getProcAddress;

        internal interface IGetProcAddress
        {
            IntPtr GetProcAddress(string function);
        }

        internal class GetProcAddressWindows : IGetProcAddress
        {
            public IntPtr GetProcAddress(string function)
            {
                return NativeMethods.wglGetProcAddress(function);
            }
        }

        internal class GetProcAddressX11 : IGetProcAddress
        {
            public IntPtr GetProcAddress(string function)
            {
                return NativeMethods.glxGetProcAddress(function);
            }
        }

        internal class GetProcAddressOSX : IGetProcAddress
        {
            public IntPtr GetProcAddress(string function)
            {
                string fname = "_" + function;
                if (!NativeMethods.NSIsSymbolNameDefined(fname))
                    return IntPtr.Zero;

                IntPtr symbol = NativeMethods.NSLookupAndBindSymbol(fname);
                if (symbol != IntPtr.Zero)
                    symbol = NativeMethods.NSAddressOfSymbol(symbol);

                return symbol;
            }
        }

        /// <summary>
        /// Retrieves the entry point for a dynamically exported OpenGL function.
        /// </summary>
        /// <param name="function">The function string for the OpenGL function (eg. "glNewList")</param>
        /// <returns>
        /// An IntPtr contaning the address for the entry point, or IntPtr.Zero if the specified
        /// OpenGL function is not dynamically exported.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The Marshal.GetDelegateForFunctionPointer method can be used to turn the return value
        /// into a call-able delegate.
        /// </para>
        /// <para>
        /// This function is cross-platform. It determines the underlying platform and uses the
        /// correct wgl, glx or agl GetAddress function to retrieve the function pointer.
        /// </para>
        /// <see cref="Marshal.GetDelegateForFunctionPointer"/>
        /// </remarks>
        public static IntPtr GetAddress(string function)
        {
            if (getProcAddress == null)
            {
                if (Environment.OSVersion.Platform == PlatformID.Win32NT ||
                    Environment.OSVersion.Platform == PlatformID.Win32S ||
                    Environment.OSVersion.Platform == PlatformID.Win32Windows ||
                    Environment.OSVersion.Platform == PlatformID.WinCE)
                {
                    getProcAddress = new GetProcAddressWindows();
                }
                else if (Environment.OSVersion.Platform == PlatformID.Unix ||
                         Environment.OSVersion.Platform == (PlatformID)4)
                {
                    // Distinguish between Unix and Mac OS X kernels.
                    switch (DetectUnixKernel())
                    {
                        case "Unix":
                        case "Linux":
                            getProcAddress = new GetProcAddressX11();
                            break;

                        case "Darwin":
                            getProcAddress = new GetProcAddressOSX();
                            break;

                        default:
                            throw new PlatformNotSupportedException(
                                DetectUnixKernel() + ": Unknown Unix platform - cannot load extensions. Please report a bug at http://taoframework.com");
                    }
                }
                else
                {
                    throw new PlatformNotSupportedException(
                        "Extension loading is only supported under Mac OS X, Unix/X11 and Windows. We are sorry for the inconvience.");
                }
            }

            return getProcAddress.GetProcAddress(function);
        }

        #endregion

        #region private static string DetectUnixKernel()

        /// <summary>
        /// Executes "uname" which returns a string representing the name of the
        /// underlying Unix kernel.
        /// </summary>
        /// <returns>"Unix", "Linux", "Darwin" or null.</returns>
        /// <remarks>Source code from "Mono: A Developer's Notebook"</remarks>
        private static string DetectUnixKernel()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                Arguments = "-s",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            };

            foreach (string unameprog in new string[] { "/usr/bin/uname", "/bin/uname", "uname" })
            {
                try
                {
                    startInfo.FileName = unameprog;
                    Process uname = Process.Start(startInfo);
                    StreamReader stdout = uname.StandardOutput;
                    return stdout.ReadLine().Trim();
                }
                catch (FileNotFoundException)
                {
                    // The requested executable doesn't exist, try next one.
                    continue;
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    continue;
                }
            }
            return null;
        }

        #endregion
    }
}
