using System.Runtime.InteropServices;

namespace OpenGL.Platform
{
    public static class NativeMethods
    {
        #region DllImport
        [DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/A/Frameworks/CoreGraphics.framework/CoreGraphics")]
        private static extern void CGSetLocalEventsSuppressionInterval(double seconds);
        #endregion

        #region Delegates
        public static void CGSetLocalEventsSuppressionIntervalEmpty(double seconds)
        {
        }

        public delegate void CGSetLocalEventsDelegate(double seconds);
        public delegate bool wglSwapIntervalEXT(int interval);

        public static CGSetLocalEventsDelegate CGSetLocalEventsDelegateOSIndependent;
        public static wglSwapIntervalEXT wglSwapInterval;
        #endregion

        #region Public Methods
        static NativeMethods()
        {
            if (Compatibility.IsWindows())
            {
                CGSetLocalEventsDelegateOSIndependent = NativeMethods.CGSetLocalEventsSuppressionIntervalEmpty;
            }
            else if (Compatibility.IsOSX())
            {
                CGSetLocalEventsDelegateOSIndependent = NativeMethods.CGSetLocalEventsSuppressionInterval;
            }
            else
            {
                CGSetLocalEventsDelegateOSIndependent = NativeMethods.CGSetLocalEventsSuppressionIntervalEmpty;
            }
        }
        #endregion
    }
}
