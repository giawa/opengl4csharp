#region License
/* SDL2# - C# Wrapper for SDL2
 *
 * Copyright (c) 2013-2015 Ethan Lee.
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software in a
 * product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source distribution.
 *
 * Ethan "flibitijibibo" Lee <flibitijibibo@flibitijibibo.com>
 *
 */

// Copyright (c) 2017 Giawa
//
// This source file has been modified by Giawa to make all methods 'safe'.
// This source file has also been modified to remove ICustomMarshaler, which
//   is not yet part of the .NET Standard < 2.0
// This modified source file is part of the OpenGL.Platform package:
//    https://www.github.com/giawa/opengl4csharp
#endregion

#region Using Statements
using System;
using System.Runtime.InteropServices;
#endregion

namespace SDL2
{
	public static class SDL_image
	{
		#region SDL2# Variables

		/* Used by DllImport to load the native library. */
		private const string nativeLibName = "SDL2_image.dll";

		#endregion

		#region SDL_image.h

		/* Similar to the headers, this is the version we're expecting to be
		 * running with. You will likely want to check this somewhere in your
		 * program!
		 */
		public const int SDL_IMAGE_MAJOR_VERSION =	2;
		public const int SDL_IMAGE_MINOR_VERSION =	0;
		public const int SDL_IMAGE_PATCHLEVEL =		0;

		[Flags]
		public enum IMG_InitFlags
		{
			IMG_INIT_JPG =	0x00000001,
			IMG_INIT_PNG =	0x00000002,
			IMG_INIT_TIF =	0x00000004,
			IMG_INIT_WEBP =	0x00000008
		}

		public static void SDL_IMAGE_VERSION(out SDL.SDL_version X)
		{
			X.major = SDL_IMAGE_MAJOR_VERSION;
			X.minor = SDL_IMAGE_MINOR_VERSION;
			X.patch = SDL_IMAGE_PATCHLEVEL;
		}

		[DllImport(nativeLibName, EntryPoint = "IMG_LinkedVersion", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_IMG_LinkedVersion();
		public static SDL.SDL_version IMG_LinkedVersion()
		{
			SDL.SDL_version result;
			IntPtr result_ptr = INTERNAL_IMG_LinkedVersion();
			result = Marshal.PtrToStructure<SDL.SDL_version>(result_ptr);
			return result;
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int IMG_Init(IMG_InitFlags flags);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void IMG_Quit();

#if NETSTANDARD1_4
        /* IntPtr refers to an SDL_Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IMG_Load(
            [In()] 
                IntPtr file
        );
#else
        /* IntPtr refers to an SDL_Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr IMG_Load(
			[In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
				string file
		);
#endif

        /* src refers to an SDL_RWops*, IntPtr to an SDL_Surface* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr IMG_Load_RW(
			IntPtr src,
			int freesrc
		);

#if NETSTANDARD1_4
        /* src refers to an SDL_RWops*, IntPtr to an SDL_Surface* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IMG_LoadTyped_RW(
            IntPtr src,
            int freesrc,
            [In()] 
                IntPtr type
        );

        /* IntPtr refers to an SDL_Texture*, renderer to an SDL_Renderer* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IMG_LoadTexture(
            IntPtr renderer,
            [In()] 
                IntPtr file
        );
#else
        /* src refers to an SDL_RWops*, IntPtr to an SDL_Surface* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr IMG_LoadTyped_RW(
			IntPtr src,
			int freesrc,
			[In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
				string type
		);

		/* IntPtr refers to an SDL_Texture*, renderer to an SDL_Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr IMG_LoadTexture(
			IntPtr renderer,
			[In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
				string file
		);
#endif

        /* renderer refers to an SDL_Renderer*.
		 * src refers to an SDL_RWops*.
		 * IntPtr to an SDL_Texture*.
		 */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr IMG_LoadTexture_RW(
			IntPtr renderer,
			IntPtr src,
			int freesrc
		);

#if NETSTANDARD1_4
        /* renderer refers to an SDL_Renderer*.
		 * src refers to an SDL_RWops*.
		 * IntPtr to an SDL_Texture*.
		 */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IMG_LoadTextureTyped_RW(
            IntPtr renderer,
            IntPtr src,
            int freesrc,
            [In()]
                IntPtr type
        );
#else
        /* renderer refers to an SDL_Renderer*.
		 * src refers to an SDL_RWops*.
		 * IntPtr to an SDL_Texture*.
		 */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr IMG_LoadTextureTyped_RW(
			IntPtr renderer,
			IntPtr src,
			int freesrc,
			[In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
				string type
		);
#endif

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int IMG_InvertAlpha(int on);

		/* IntPtr refers to an SDL_Surface* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr IMG_ReadXPMFromArray(
			[In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)]
				string[] xpm
		);

#if NETSTANDARD1_4
        /* surface refers to an SDL_Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int IMG_SavePNG(
            IntPtr surface,
            [In()] 
                IntPtr file
        );
#else
        /* surface refers to an SDL_Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int IMG_SavePNG(
			IntPtr surface,
			[In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
				string file
		);
#endif

        /* surface refers to an SDL_Surface*, dst to an SDL_RWops* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int IMG_SavePNG_RW(
			IntPtr surface,
			IntPtr dst,
			int freedst
		);

#endregion
	}
}
