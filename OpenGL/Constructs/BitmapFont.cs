using System;

#if USE_NUMERICS
using System.Numerics;
#endif

namespace OpenGL
{
    public class BitmapFont : IDisposable
    {
        #region Properties
        public Texture FontTexture { get; private set; }
        
        public struct UVPair
        {
            public Vector2 Topleft;
            public Vector2 BottomRight;

            public UVPair(Vector2 topleft, Vector2 bottomright)
            {
                Topleft = topleft;
                BottomRight = bottomright;
            }
        }

        public UVPair[] Character { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a bitmap font object, which is created from a h by v array of bitmap characters.
        /// </summary>
        /// <param name="FontTexture">A grid of h*v characters ordered by ASCII number.</param>
        /// <param name="h">The number of columns in the bitmap font texture.</param>
        /// <param name="v">The number of rows in the bitmap font texture.</param>
        public BitmapFont(Texture FontTexture, int h, int v)
        {
            if (FontTexture.Size.Width % h != 0) throw new Exception("FontTexture is not a width that is divisible by h.");
            if (FontTexture.Size.Height % v != 0) throw new Exception("FontTexture is not a height that is divisible by v.");

            this.FontTexture = FontTexture;

            float delx = (float)FontTexture.Size.Width / h;
            float dely = (float)FontTexture.Size.Height / v;
            
            Character = new UVPair[h * v];
            for (int x = 0; x < h; x++)
            {
                for (int y = 0; y < v; y++)
                {
                    Character[x + y * h] = new UVPair(
                        new Vector2(x * delx / FontTexture.Size.Width, 1 - (y + 1) * dely / FontTexture.Size.Height),
                        new Vector2((x + 1) * delx / FontTexture.Size.Width, 1 - (y * dely + 1) / FontTexture.Size.Height));
                }
            }
        }

        ~BitmapFont()
        {
            Dispose(false);
        }
        #endregion

        #region Methods
        public VAO CreateString(ShaderProgram Program, string Text)
        {
            Vector3[] vertices = new Vector3[Text.Length * 4];
            Vector2[] uvs = new Vector2[Text.Length * 4];
            uint[] indices = new uint[Text.Length * 6];

            for (uint i = 0; i < Text.Length; i++)
            {
                // Note: These are fixed width fonts so just use 2x2 quads (-1..1)
                vertices[i * 4 + 0] = new Vector3(-1 + i * 2, 1, 0);
                vertices[i * 4 + 1] = new Vector3(-1 + i * 2, -1, 0);
                vertices[i * 4 + 2] = new Vector3(1 + i * 2, 1, 0);
                vertices[i * 4 + 3] = new Vector3(1 + i * 2, -1, 0);

                UVPair ch = Character[Text[(int)i] > 256 ? ' ' : Text[(int)i]];
                uvs[i * 4 + 0] = new Vector2(ch.Topleft.X, ch.BottomRight.Y);
                uvs[i * 4 + 1] = ch.Topleft;
                uvs[i * 4 + 2] = ch.BottomRight;
                uvs[i * 4 + 3] = new Vector2(ch.BottomRight.X, ch.Topleft.Y);

                indices[i * 6 + 0] = i * 4 + 1;
                indices[i * 6 + 1] = i * 4 + 0;
                indices[i * 6 + 2] = i * 4 + 2;
                indices[i * 6 + 3] = i * 4 + 1;
                indices[i * 6 + 4] = i * 4 + 2;
                indices[i * 6 + 5] = i * 4 + 3;
            }

            // Create the vertex buffer objects and then create the array object
            VBO<Vector3> vertexArray = new VBO<Vector3>(vertices, BufferTarget.ArrayBuffer, BufferUsageHint.StaticRead);
            VBO<Vector2> uvArray = new VBO<Vector2>(uvs, BufferTarget.ArrayBuffer, BufferUsageHint.StaticRead);
            VBO<uint> elementArray = new VBO<uint>(indices, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead);

            return new VAO(Program, vertexArray, uvArray, elementArray);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            FontTexture.Dispose();
        }
        #endregion

        #region Sample Shader
        public static string vertexShader2Source = @"
#version 400

uniform mat4 projection_matrix;
uniform mat4 modelview_matrix;

in vec3 in_position;
in vec2 in_uv;

out vec2 uv;

void main(void)
{
  uv = in_uv;
  
  gl_Position = projection_matrix * modelview_matrix * vec4(in_position, 1);
}";

        public static string fragmentShader2Source = @"
#version 400

uniform sampler2D active_texture;
uniform vec3 color;

in vec2 uv;

out vec4 fragColor;

void main(void)
{
  vec4 t = texture2D(active_texture, uv);
  fragColor = t * vec4(color, t.r);
}";
        #endregion
    }
}
