using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//using OpenGL;

namespace BuildLibrary
{
    class Program
    {
        static string input = @"GlCore.cs";

        static string output1 = @"GlDelegates.cs";
        static string prepend1 = @"using System;
using System.Runtime.InteropServices;

#pragma warning disable 0649

namespace OpenGL
{
    // Automatically generated from GlCore.cs using BuildGl
    partial class Gl
    {
        internal static partial class Delegates
        {";
        static string append1 = @"        }
    }
}";

        static string output2 = @"Gl.cs";
        static string prepend2 = @"using System;
using System.Runtime.InteropServices;

namespace OpenGL
{
    // Automatically generated from GlCore.cs using BuildGl
    partial class Gl
    {";
        static string append2 = @"    }
}";

        static void Main(string[] args)
        {
            var extensions = from line in ReadFrom(input)
                             where line.Contains("internal extern static") && !line.Contains("*/")
                             select new { Call = line.Substring(line.IndexOf("static") + 7), Name = line.Split(' ')[4] };

            using (StreamWriter output = new StreamWriter(output1))
            {
                output.WriteLine(prepend1);

                foreach (var extension in extensions)
                {
                    string name = extension.Name.Substring(0, extension.Name.IndexOf('('));
                    //writer.WriteLine(@"            [System.Security.SuppressUnmanagedCodeSecurity()]");
                    output.WriteLine(@"            internal delegate {0}", extension.Call);
                    output.WriteLine(@"            internal static {0} gl{0};", name);
                }

                output.WriteLine(append1);
            }

            using (StreamWriter output = new StreamWriter(output2))
            {
                output.WriteLine(prepend2);

                foreach (var extension in extensions)
                {
                    if (extension.Name.StartsWith("GetString"))
                    {
                        if (extension.Name.StartsWith("GetStringi"))
                        {
                            output.WriteLine(@"        public static String GetStringi(OpenGL.StringName name, UInt32 index)");
                            output.WriteLine(@"        {");
                            output.WriteLine(@"            return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(Delegates.glGetStringi(name, index));");
                            output.WriteLine(@"        }");
                            output.WriteLine();
                        }
                        else
                        {
                            output.WriteLine(@"        public static String GetString(OpenGL.StringName name)");
                            output.WriteLine(@"        {");
                            output.WriteLine(@"            return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(Delegates.glGetString(name));");
                            output.WriteLine(@"        }");
                            output.WriteLine();
                        }
                    }
                    else if (extension.Name.StartsWith("ActiveTexture"))
                    {
                        if (extension.Call.StartsWith("void ActiveTexture"))
                        {
                            output.WriteLine("        [Obsolete(\"ActiveTexture(TextureUnit) is deprecated, please use ActiveTexture(int) instead.\")]");
                            output.WriteLine("        public static void ActiveTexture(OpenGL.TextureUnit texture)");
                            output.WriteLine("        {");
                            output.WriteLine("            Delegates.glActiveTexture((int)texture);");
                            output.WriteLine("        }");
                        }
                    }
                    else
                    {
                        string name = extension.Name.Substring(0, extension.Name.IndexOf('('));

                        output.WriteLine(@"        public static {0}", extension.Call.Trim(';'));
                        output.WriteLine(@"        {");

                        if (extension.Name.StartsWith("UseProgram")) output.WriteLine("            Gl.currentProgram = program;");
                        else if (extension.Name.StartsWith("GetUniformBlockIndex")) output.WriteLine("            UseProgram(program);    // take care of a crash that can occur on NVIDIA drivers by using the program first");

                        if (extension.Call.ToLower().Substring(0, 4) != "void") output.Write(@"            return Delegates.gl{0}(", name);
                        else output.Write(@"            Delegates.gl{0}(", name);

                        var arguments = from arg in extension.Call.Trim(new char[] { ';', ')' }).Split(',')
                                        from sarg in arg.Split(' ')
                                        where sarg == arg.Split(' ')[arg.Split(' ').Length - 1] && !sarg.Contains('(')
                                        select sarg;

                        int i = 0;
                        foreach (var arg in arguments)
                        {
                            if (i > 0) output.Write(@", ");
                            output.Write(@"{0}", arg);
                            i++;
                        }

                        output.WriteLine(@");");
                        output.WriteLine(@"        }");
                        output.WriteLine();

                        if ((extension.Name.Contains("Attrib") || extension.Name.Contains("Uniform")) && extension.Call.Contains("UInt32 index"))
                        {
                            output.WriteLine(@"        public static {0}", extension.Call.Trim(';').Replace("UInt32 index", "Int32 index"));
                            output.WriteLine(@"        {");
                            output.WriteLine("            if (index < 0) throw new ArgumentOutOfRangeException(\"index\");");

                            output.Write(@"            Delegates.gl{0}(", name);

                            i = 0;
                            foreach (var arg in arguments)
                            {
                                if (i > 0) output.Write(@", ");
                                output.Write(@"{0}", arg.Replace("index", "(UInt32)index"));
                                i++;
                            }

                            output.WriteLine(@");");
                            output.WriteLine(@"        }");
                            output.WriteLine();
                        }
                        else if (extension.Call.Contains("UInt32 index")) Console.WriteLine(extension.Name);
                    }
                }

                output.WriteLine(append2);
            }

            if (Directory.Exists("../OpenGLManPages"))
            {
                File.Copy(output1, "../OpenGLManPages/" + output1, true);
                File.Copy(output2, "../OpenGLManPages/" + output2, true);
                File.Copy(input, "../OpenGLManPages/" + input, true);
            }
        }

        static IEnumerable<string> ReadFrom(string file)
        {
            bool gl4 = false;
            using (StreamReader stream = new StreamReader(file))
            {
                string line = "";
                while (!stream.EndOfStream && (!(line.Contains("OPENGL4") && !gl4)))
                {
                    line = stream.ReadLine().Trim();
                    if (line.Contains("#define OPENGL4")) gl4 = true;
                    yield return line;
                }
            }
        }
    }
}
