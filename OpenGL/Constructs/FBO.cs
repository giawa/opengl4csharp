using System;
using System.Drawing;

namespace OpenGL
{
    /// <summary>
    /// Encapsulates a frame buffer and its associated depth buffer (if applicable).
    /// </summary>
    public class FBO : IDisposable
    {
        #region Properties
        /// <summary>
        /// The ID for the entire framebuffer object.
        /// </summary>
        public uint BufferID { get; private set; }

        /// <summary>
        /// The IDs for each of the renderbuffer attachments.
        /// </summary>
        public uint[] TextureID { get; private set; }

        /// <summary>
        /// The ID for the single depth buffer attachment.
        /// </summary>
        public uint DepthID { get; private set; }

        /// <summary>
        /// The size (in pixels) of all renderbuffers associated with this framebuffer.
        /// </summary>
        public Size Size { get; private set; }

        /// <summary>
        /// The attachments used by this framebuffer.
        /// </summary>
        public FramebufferAttachment[] Attachments { get; private set; }

        /// <summary>
        /// The internal pixel format for each of the renderbuffers (depth buffer not included).
        /// </summary>
        public PixelInternalFormat Format { get; private set; }

        /// <summary>
        /// Specifies whether to build mipmaps after the frame buffer is unbound.
        /// </summary>
        public bool MipMaps { get; private set; }
        #endregion

        #region Constructor and Destructor
        /// <summary>
        /// Creates a framebuffer object and its associated resources (depth and frame buffers).
        /// </summary>
        /// <param name="width">Specifies the width (in pixels) of the framebuffer and its associated buffers.</param>
        /// <param name="height">Specifies the height (in pixels) of the framebuffer and its associated buffers.</param>
        /// <param name="attachment">Specifies the attachment to use for the frame buffer.</param>
        /// <param name="format">Specifies the internal pixel format for the frame buffer.</param>
        /// <param name="mipmaps">Specifies whether to build mipmaps after the frame buffer is unbound.</param>
        public FBO(int width, int height, FramebufferAttachment attachment = FramebufferAttachment.ColorAttachment0, PixelInternalFormat format = PixelInternalFormat.Rgba8, bool mipmaps = true)
            : this(new Size(width, height), new FramebufferAttachment[] { attachment }, format, mipmaps)
        {
        }

        /// <summary>
        /// Creates a framebuffer object and its associated resources (depth and frame buffers).
        /// </summary>
        /// <param name="size">Specifies the size (in pixels) of the framebuffer and its associated buffers.</param>
        /// <param name="attachment">Specifies the attachment to use for the frame buffer.</param>
        /// <param name="format">Specifies the internal pixel format for the frame buffer.</param>
        /// <param name="mipmaps">Specifies whether to build mipmaps after the frame buffer is unbound.</param>
        public FBO(Size size, FramebufferAttachment attachment = FramebufferAttachment.ColorAttachment0, PixelInternalFormat format = PixelInternalFormat.Rgba8, bool mipmaps = true)
            : this(size, new FramebufferAttachment[] { attachment }, format, mipmaps)
        {
        }

        /// <summary>
        /// Creates a framebuffer object and its associated resources (depth and frame buffers).
        /// </summary>
        /// <param name="size">Specifies the size (in pixels) of the framebuffer and its associated buffers.</param>
        /// <param name="attachments">Specifies the attachments to use for the frame buffer.</param>
        /// <param name="format">Specifies the internal pixel format for the frame buffer.</param>
        /// <param name="mipmaps">Specifies whether to build mipmaps after the frame buffer is unbound.</param>
        /// <param name="filterType">Specifies the type of filtering to apply to the frame buffer when bound as a texture.</param>
        /// <param name="pixelType">Specifies the pixel type to use for the underlying format of the frame buffer.</param>
        public FBO(Size size, FramebufferAttachment[] attachments, PixelInternalFormat format, bool mipmaps = false, TextureParameter filterType = TextureParameter.Linear, PixelType pixelType = PixelType.UnsignedByte)
        {
            this.Size = size;
            this.Attachments = attachments;
            this.Format = format;
            this.MipMaps = mipmaps;

            // First create the framebuffer
            BufferID = Gl.GenFramebuffer();
            Gl.BindFramebuffer(FramebufferTarget.Framebuffer, BufferID);

            if (Attachments.Length == 1 && Attachments[0] == FramebufferAttachment.DepthAttachment)
            {
                // if this is a depth attachment only
                TextureID = new uint[] { Gl.GenTexture() };
                Gl.BindTexture(TextureTarget.Texture2D, TextureID[0]);

                Gl.TexImage2D(TextureTarget.Texture2D, 0, Format, Size.Width, Size.Height, 0, PixelFormat.DepthComponent, PixelType.Float, IntPtr.Zero);
                Gl.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Nearest);
                Gl.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Nearest);
                Gl.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
                Gl.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);

                Gl.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, TextureID[0], 0);
                Gl.DrawBuffer(DrawBufferMode.None);
                Gl.ReadBuffer(ReadBufferMode.None);
            }
            else
            {
                // Create n texture buffers (known by the number of attachments)
                TextureID = new uint[Attachments.Length];
                Gl.GenTextures(Attachments.Length, TextureID);

                // Bind the n texture buffers to the framebuffer
                for (int i = 0; i < Attachments.Length; i++)
                {
                    Gl.BindTexture(TextureTarget.Texture2D, TextureID[i]);
                    Gl.TexImage2D(TextureTarget.Texture2D, 0, Format, Size.Width, Size.Height, 0, PixelFormat.Rgba, pixelType, IntPtr.Zero);
                    if (MipMaps)
                    {
                        Gl.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
                        Gl.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.LinearMipMapLinear);
                        Gl.GenerateMipmap(GenerateMipmapTarget.Texture2D);
                    }
                    else
                    {
                        Gl.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, filterType);
                        Gl.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, filterType);
                    }
                    Gl.FramebufferTexture(FramebufferTarget.Framebuffer, Attachments[i], TextureID[i], 0);
                }

                // Create and attach a 24-bit depth buffer to the framebuffer
                DepthID = Gl.GenTexture();
                Gl.BindTexture(TextureTarget.Texture2D, DepthID);

                Gl.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Depth24Stencil8, Size.Width, Size.Height, 0, PixelFormat.DepthStencil, PixelType.UnsignedInt248, IntPtr.Zero);
                Gl.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Nearest);
                Gl.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Nearest);
                Gl.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
                Gl.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);

                Gl.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, DepthID, 0);
                Gl.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.StencilAttachment, DepthID, 0);
            }

            // Build the framebuffer and check for errors
            FramebufferErrorCode status = Gl.CheckFramebufferStatus(FramebufferTarget.Framebuffer);
            if (status != FramebufferErrorCode.FramebufferComplete)
            {
                Console.WriteLine("Frame buffer did not compile correctly.  Returned {0}, glError: {1}", status.ToString(), Gl.GetError().ToString());
            }

            Gl.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        }

        /// <summary>
        /// Check to ensure that the FBO was disposed of properly.
        /// </summary>
        ~FBO()
        {
            Dispose(false);
        }
        #endregion

        #region Enable and Disable
        /// <summary>
        /// Binds the framebuffer and all of the renderbuffers.
        /// Clears the buffer bits and sets viewport size.
        /// Perform all rendering after this call.
        /// </summary>
        /// <param name="clear">True to clear both the color and depth buffer bits of the FBO before enabling.</param>
        public void Enable(bool clear = true)
        {
            Gl.BindFramebuffer(FramebufferTarget.Framebuffer, BufferID);
            if (Attachments.Length == 1)
            {
                Gl.BindTexture(TextureTarget.Texture2D, TextureID[0]);
                Gl.FramebufferTexture(FramebufferTarget.Framebuffer, Attachments[0], TextureID[0], 0);
            }
            else
            {
                DrawBuffersEnum[] buffers = new DrawBuffersEnum[Attachments.Length];

                for (int i = 0; i < Attachments.Length; i++)
                {
                    Gl.BindTexture(TextureTarget.Texture2D, TextureID[i]);
                    Gl.FramebufferTexture(FramebufferTarget.Framebuffer, Attachments[i], TextureID[i], 0);
                    buffers[i] = (DrawBuffersEnum)Attachments[i];
                }

                Gl.BindTexture(TextureTarget.Texture2D, DepthID);
                Gl.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, DepthID, 0);

                if (Attachments.Length > 1) Gl.DrawBuffers(Attachments.Length, buffers);
            }

            Gl.Viewport(0, 0, Size.Width, Size.Height);

            // configurably clear the buffer and color bits
            if (clear)
            {
                if (Attachments.Length == 1 && Attachments[0] == FramebufferAttachment.DepthAttachment)
                    Gl.Clear(ClearBufferMask.DepthBufferBit);
                else
                    Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            }
        }

        /// <summary>
        /// Unbinds the framebuffer and then generates the mipmaps of each renderbuffer.
        /// </summary>
        public void Disable()
        {
            // unbind this framebuffer (does not guarantee the correct framebuffer is bound)
            Gl.BindFramebuffer(FramebufferTarget.Framebuffer, 0);

            // have to generate mipmaps here
            for (int i = 0; i < Attachments.Length && MipMaps; i++)
            {
                Gl.BindTexture(TextureTarget.Texture2D, TextureID[i]);
                Gl.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            }
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (DepthID != 0 || BufferID != 0 || TextureID != null)
            {
                Gl.DeleteTextures(TextureID.Length, TextureID);
                Gl.DeleteFramebuffer(BufferID);
                Gl.DeleteFramebuffer(DepthID);

                BufferID = 0;
                DepthID = 0;
                TextureID = null;
            }
        }
        #endregion

        #region Sample Shader
        public static string vertexShaderSource = @"
#version 330

uniform mat4 projection_matrix;
uniform mat4 modelview_matrix;
uniform float animation_factor;

in vec3 in_position;
in vec3 in_normal;
in vec2 in_uv;

out vec2 uv;

void main(void)
{
  vec4 pos2 = projection_matrix * modelview_matrix * vec4(in_normal, 1);
  vec4 pos1 = projection_matrix * modelview_matrix * vec4(in_position, 1);

  uv = in_uv;
  
  gl_Position = mix(pos2, pos1, animation_factor);
}";

        public static string fragmentShaderSource = @"
#version 330

uniform sampler2D active_texture;

in vec2 uv;

out vec4 out_frag_color;

void main(void)
{
  out_frag_color = mix(texture2D(active_texture, uv), vec4(1, 1, 1, 1), 0.05);
}";
        #endregion
    }
}
