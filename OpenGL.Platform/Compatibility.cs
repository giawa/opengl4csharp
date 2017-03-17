using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenGL.Platform
{
    public static class Compatibility
    {
        #region Structs
        public struct ScreenResolution : IComparable
        {
            public int width;
            public int height;
            public int bitsPerPixel;
            public int displayFrequency;

            public ScreenResolution(int Width, int Height, int BitsPerPixel, int DisplayFrequency)
            {
                width = Width;
                height = Height;
                bitsPerPixel = BitsPerPixel;
                displayFrequency = DisplayFrequency;
            }

            public override string ToString()
            {
                return string.Format("{0}x{1}:{2}@{3}", width, height, bitsPerPixel, displayFrequency);
            }

            public int CompareTo(object obj)
            {
                if (obj is ScreenResolution)
                {
                    ScreenResolution sr = (ScreenResolution)obj;
                    int theirs = sr.height * sr.width;
                    int mine = height * width;

                    if (mine == theirs)
                    {
                        if (sr.displayFrequency == displayFrequency) return 0;
                        else return (displayFrequency > sr.displayFrequency) ? -1 : 1;
                    }
                    else return (mine > theirs) ? -1 : 1;
                }
                return 0;
            }
        }
        #endregion

        #region OS Detection
        public enum OSVersion : int
        {
            Unknown = 0,
            MacOSX = 1,
            Unix = 2,
            Win32 = 3
        }

        private static OSVersion osVersion;

        public static bool IsLinux()
        {
            if (osVersion == OSVersion.Unknown) DetectOperatingSystem();

            return osVersion == OSVersion.Unix;
        }

        public static bool IsOSX()
        {
            if (osVersion == OSVersion.Unknown) DetectOperatingSystem();

            return osVersion == OSVersion.MacOSX;
        }

        public static bool IsWindows()
        {
            if (osVersion == OSVersion.Unknown) DetectOperatingSystem();

            return osVersion == OSVersion.Win32;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Detect the current running operating system and set up GetProcAddress
        /// and CGSetLocalEventsDelegateSuppressionInterval depending on the OS.
        /// Also sets up some of the preferences by calling these method.
        /// Note:  A valid OpenGL context must exist before running this code.
        /// </summary>
        public static void DetectOperatingSystem()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) osVersion = OSVersion.Win32;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) osVersion = OSVersion.MacOSX;
            else osVersion = OSVersion.Unix;
        }

        /// <summary>
        /// A list of resolutions that the Compatibility layer determined were valid.
        /// </summary>
        public static List<ScreenResolution> ValidResolutions = new List<ScreenResolution>();

        /// <summary>
        /// Populates the screen resolutions that are valid on this system.
        /// </summary>
        public static void DetectValidResolutions()
        {
            // we're in SDL land, so we can just request resolutions
            int displayModeCount = SDL2.SDL.SDL_GetNumDisplayModes(0);
            if (displayModeCount < 1) return;

            for (int i = 0; i < displayModeCount; i++)
            {
                SDL2.SDL.SDL_DisplayMode mode;

                if (SDL2.SDL.SDL_GetDisplayMode(0, i, out mode) == 0)
                {
                    int bpp = SDL2.SDL.SDL_BITSPERPIXEL(mode.format);
                    string name = SDL2.SDL.SDL_GetPixelFormatName(mode.format);

                    // deal with a bug in early versions of SDL2-CS.dll that would return 0 for all SDL_BITSPERPIXEL
                    if (bpp == 0 && name.Contains("RGB888")) ValidResolutions.Add(new ScreenResolution(mode.w, mode.h, 24, mode.refresh_rate));
                    else ValidResolutions.Add(new ScreenResolution(mode.w, mode.h, bpp, mode.refresh_rate));
                }
            }
        }
        #endregion
    }
}