using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;

namespace OpenGL
{
    public class Texture : IDisposable
    {
        #region Propreties
        public string Filename { get; private set; }

        public uint TextureID { get; private set; }

        public Size Size { get; private set; }

        public TextureTarget TextureTarget { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Create a texture from the supplied filename.
        /// Any files that Bitmap.FromFile can open are supported.
        /// This method also supports dds textures (as long as the file extension is .dds).
        /// </summary>
        /// <param name="filename">The path to the texture to load.</param>
        public Texture(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException(string.Format("The file {0} does not exist.", filename));
            }

            Filename = filename;
            switch (new FileInfo(filename).Extension.ToLower())
            {
                case ".dds":
                    LoadDDS(filename);
                    break;
                default:
                    LoadBitmap(filename);
                    break;
            }

            Gl.BindTexture(TextureTarget, 0);
        }

        public Texture(IntPtr pixelData, int width, int height)
            : this(pixelData, width, height, PixelFormat.Bgra, PixelInternalFormat.Rgba8) { }

        public Texture(IntPtr pixelData, int width, int height, PixelFormat format, PixelInternalFormat internalFormat)
        {
            Filename = "Raw Data";
            Size = new Size(width, height);

            // set the texture target and then generate the texture ID
            TextureTarget = TextureTarget.Texture2D;
            TextureID = Gl.GenTexture();

            Gl.PixelStorei(PixelStoreParameter.UnpackAlignment, 1); // set pixel alignment
            Gl.BindTexture(TextureTarget, TextureID);     // bind the texture to memory in OpenGL

            //Gl.TexParameteri(TextureTarget, TextureParameterName.GenerateMipmap, 0);
            Gl.TexImage2D(TextureTarget, 0, internalFormat, width, height, 0, format, PixelType.UnsignedByte, pixelData);
            Gl.TexParameteri(TextureTarget, TextureParameterName.TextureMagFilter, TextureParameter.Nearest);
            Gl.TexParameteri(TextureTarget, TextureParameterName.TextureMinFilter, TextureParameter.Nearest);

            Gl.BindTexture(TextureTarget, 0);
        }

        ~Texture()
        {
            Dispose(false);
        }
        #endregion

        #region Methods
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (TextureID != 0)
            {
#if MEMORY_LOGGER
                MemoryLogger.DestroyTexture(TextureID, Size);
#endif

                Gl.DeleteTexture(TextureID);
                TextureID = 0;
            }
        }

        private void LoadBitmap(string filename, bool flipy = true)
        {
            using (Bitmap image = (Bitmap)Image.FromFile(filename))
            {
                Size = new Size(image.Width, image.Height);

                if (flipy)
                {
                    image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                }

                // must be Format32bppArgb file format, so convert it if it isn't in that format
                BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                TextureTarget = TextureTarget.Texture2D;
                TextureID = Gl.GenTexture();

                Gl.PixelStorei(PixelStoreParameter.UnpackAlignment, 1); // set pixel alignment
                Gl.BindTexture(TextureTarget, TextureID);     // bind the texture to memory in OpenGL

                Gl.TexImage2D(TextureTarget, 0, PixelInternalFormat.Rgba8, image.Width, image.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, imageData.Scan0);
                Gl.TexParameteri(TextureTarget, TextureParameterName.TextureMagFilter, TextureParameter.Nearest);
                Gl.TexParameteri(TextureTarget, TextureParameterName.TextureMinFilter, TextureParameter.Nearest);

#if MEMORY_LOGGER
                MemoryLogger.AllocateTexture(TextureID, Size);
#endif

                image.UnlockBits(imageData);
            }
        }

        /// <summary>
        /// Loads a compressed DDS file into an OpenGL texture.
        /// </summary>
        /// <param name="filename">The path to the DDS file.</param>
        private void LoadDDS(string filename)
        {
            using (FileStream file = new FileStream(filename, FileMode.Open))
            using (BinaryReader stream = new BinaryReader(file))
            {
                string filecode = new string(stream.ReadChars(4));
                if (filecode != "DDS ")                                 // first 4 chars should be "DDS "
                    throw new Exception("File was not a DDS file format.");

                DDS.DDSURFACEDESC2 imageData = DDS.DDSURFACEDESC2.FromBinaryReader(stream);//new DDS.DDSURFACEDESC2(stream);  // read the DirectDraw surface descriptor
                this.Size = new Size(imageData.Width, imageData.Height);

                if (imageData.LinearSize == 0)
                    throw new Exception("The linear scan line size was zero.");

                bool compressed = true;
                int factor = 0, buffersize = 0, blocksize = 0;
                PixelInternalFormat format;
                switch (imageData.PixelFormat.FourCC)       // check the compression type
                {
                    case "DXT1":    // DXT1 compression ratio is 8:1
                        format = PixelInternalFormat.CompressedRgbaS3tcDxt1Ext;
                        factor = 2;
                        blocksize = 8;
                        break;
                    case "DXT3":    // DXT3 compression ratio is 4:1
                        format = PixelInternalFormat.CompressedRgbaS3tcDxt3Ext;
                        factor = 4;
                        blocksize = 16;
                        break;
                    case "DXT5":    // DXT5 compression ratio is 4:1
                        format = PixelInternalFormat.CompressedRgbaS3tcDxt5Ext;
                        factor = 4;
                        blocksize = 16;
                        break;
                    default:
                        compressed = false;
                        if (imageData.PixelFormat.ABitMask == 0xf000 && imageData.PixelFormat.RBitMask == 0x0f00 &&
                            imageData.PixelFormat.GBitMask == 0x00f0 && imageData.PixelFormat.BBitMask == 0x000f &&
                            imageData.PixelFormat.RGBBitCount == 16) format = PixelInternalFormat.Rgba;
                        else if (imageData.PixelFormat.ABitMask == unchecked((int)0xff000000) && imageData.PixelFormat.RBitMask == 0x00ff0000 &&
                            imageData.PixelFormat.GBitMask == 0x0000ff00 && imageData.PixelFormat.BBitMask == 0x000000ff &&
                            imageData.PixelFormat.RGBBitCount == 32) format = PixelInternalFormat.Rgba;
                        else throw new Exception(string.Format("File compression \"{0}\" is not supported.", imageData.PixelFormat.FourCC));
                        break;
                }

                if (imageData.LinearSize != 0) buffersize = (int)((imageData.MipmapCount > 1) ? imageData.LinearSize * factor : imageData.LinearSize);
                else buffersize = (int)(stream.BaseStream.Length - stream.BaseStream.Position);

                // read the pixel data and then pin it to memory so that the garbage collector
                // doesn't shuffle the data around while OpenGL is decompressing it
                byte[] pixels = stream.ReadBytes(buffersize);
                GCHandle pinned = GCHandle.Alloc(pixels, GCHandleType.Pinned);

                try
                {
                    TextureTarget = (imageData.Height == 1 || imageData.Width == 1) ? TextureTarget.Texture1D : TextureTarget.Texture2D;
                    TextureID = Gl.GenTexture();

                    Gl.BindTexture(TextureTarget, TextureID);
                    Gl.TexParameteri(TextureTarget, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
                    Gl.TexParameteri(TextureTarget, TextureParameterName.TextureMagFilter, TextureParameter.Linear);

                    int nOffset = 0, nWidth = (int)imageData.Width, nHeight = (int)imageData.Height;

                    for (int i = 0; i < (imageData.MipmapCount == 0 ? 1 : imageData.MipmapCount); ++i)
                    {
                        if (nWidth == 0) nWidth = 1;        // smallest mipmap is 1x1 pixels
                        if (nHeight == 0) nHeight = 1;
                        int nSize = 0;

                        if (compressed)
                        {
                            nSize = ((nWidth + 3) / 4) * ((nHeight + 3) / 4) * blocksize;
                            Gl.CompressedTexImage2D(TextureTarget, i, format, nWidth, nHeight, 0, nSize, (IntPtr)(pinned.AddrOfPinnedObject().ToInt64() + nOffset));
                        }
                        else
                        {
                            PixelType pixelType = imageData.PixelFormat.RGBBitCount == 16 ? PixelType.UnsignedShort4444Reversed : PixelType.UnsignedInt8888Reversed;

                            nSize = nWidth * nHeight * imageData.PixelFormat.RGBBitCount / 8;
                            Gl.TexImage2D(TextureTarget, i, format, nWidth, nHeight, 0, PixelFormat.Bgra, pixelType, (IntPtr)(pinned.AddrOfPinnedObject().ToInt64() + nOffset));
                        }

                        nOffset += nSize;
                        nWidth /= 2;
                        nHeight /= 2;
                    }

#if MEMORY_LOGGER
                    MemoryLogger.AllocateTexture(TextureID, Size);
#endif
                }
                catch (Exception)
                {   // There was some sort of Dll related error, or the target GPU does not support glCompressedTexImage2DARB
                    throw;
                }
                finally
                {
                    pinned.Free();
                }
            }
        }
        #endregion
    }

    internal class DDS
    {
        #region DirectDraw Surface
        /// <summary>The DirectDraw Surface pixel format.</summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DDS_PIXEL_FORMAT
        {
            /// <summary>Size of the DDS_PIXEL_FORMAT structure.</summary>
            public int Size;
            /// <summary>Pixel format flags.</summary>
            public int Flags;
            /// <summary>The FourCC code for compression identification.</summary>
            public string FourCC { get { return string.Format("{0}{1}{2}{3}", fourCC0, fourCC1, fourCC2, fourCC3); } }
            public char fourCC0;
            public char fourCC1;
            public char fourCC2;
            public char fourCC3;
            /// <summary>The number of bits per pixel.</summary>
            public int RGBBitCount;
            /// <summary>Red bit mask.</summary>
            public int RBitMask;
            /// <summary>Green bit mask.</summary>
            public int GBitMask;
            /// <summary>Blue bit mask.</summary>
            public int BBitMask;
            /// <summary>Alpha bit mask.</summary>
            public int ABitMask;
        }

        /// <summary>The DirectDraw Surface descriptor.</summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DDSURFACEDESC2
        {
            /// <summary>The size of the DDSURFACEDESC2 structure.</summary>
            public int Size;
            /// <summary>Flags to determine which fields are valid.</summary>
            public int Flags;
            /// <summary>The height (in pixels) of the surface.</summary>
            public int Height;
            /// <summary>The width (in pixels) of the surface.</summary>
            public int Width;
            /// <summary>The scan line size of the surface.</summary>
            public int LinearSize;
            /// <summary>The depth (if applicable).</summary>
            public int Depth;
            /// <summary>The number of mip map levels in this surface.</summary>
            public int MipmapCount;
            private int Reserved0;
            private int Reserved1;
            private int Reserved2;
            private int Reserved3;
            private int Reserved4;
            private int Reserved5;
            private int Reserved6;
            private int Reserved7;
            private int Reserved8;
            private int Reserved9;
            private int Reserved10;
            /// <summary>A pixel format describing the surface.</summary>
            public DDS_PIXEL_FORMAT PixelFormat;
            /// <summary>DDS surface flags.</summary>
            public int SurfaceFlags;
            /// <summary>DDS cubemap flags.</summary>
            public int CubemapFlags;
            private int Reserved11;
            private int Reserved12;
            private int Reserved13;

            public static DDSURFACEDESC2 FromBinaryReader(BinaryReader stream)
            {
                byte[] data = stream.ReadBytes(124);    // Marshal.SizeOf(typeof(DDSURFACEDESC2)));
                GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
                DDSURFACEDESC2 desc = (DDSURFACEDESC2)Marshal.PtrToStructure<DDSURFACEDESC2>(handle.AddrOfPinnedObject());
                handle.Free();
                return desc;
            }
        }
        #endregion
    }
}
