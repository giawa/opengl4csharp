using System;

#if USE_NUMERICS
using System.Numerics;
#endif

namespace OpenGL
{
    public class Billboard : IDisposable
    {
        #region Properties
        public ShaderProgram Program { get; private set; }

        public Texture Texture { get; private set; }

        private VAO billboard;

        private Vector4 Color { get; set; }
        #endregion

        #region Constructors
        public Billboard(ShaderProgram program, Texture texture, Vector3 location, float size)
            : this(program, texture, new Vector3[] { location }, new Vector3[] { new Vector3(1, 1, 1) })
        {
        }

        public Billboard(ShaderProgram program, Texture texture, Vector3[] locations, Vector3[] colors)
        {
            Program = program;
            Texture = texture;

            uint[] elements = new uint[locations.Length];
            for (uint i = 0; i < elements.Length; i++) elements[i] = i;

            billboard = new VAO(program, new VBO<Vector3>(locations), new VBO<Vector3>(colors), new VBO<uint>(elements))
            {
                DrawMode = BeginMode.Points,
                DisposeChildren = true
            };
            Color = new Vector4(1, 1, 1, 1);
        }

        ~Billboard()
        {
            Dispose(false);
        }
        #endregion

        #region Methods
        public void Draw()
        {
            // set up the shader program
            Program.Use();

            // bind the active texture
            Gl.ActiveTexture(0);
            Gl.BindTexture(Texture);

            // draw the billboard
            billboard.Draw();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // dispose of all of the objects
            Program.Dispose();
            Texture.Dispose();
            billboard.Dispose();
        }
        #endregion

        #region Sample Shader Code
        public static string vertexShaderSource = @"
#version 400

uniform mat4 projection_matrix;
uniform mat4 modelview_matrix;

in vec3 in_position;
in vec3 in_normal;

out vec4 color;

void main(void)
{
  vec4 pos = projection_matrix * modelview_matrix * vec4(in_position, 1);
  color = vec4(in_normal, 1);
  gl_PointSize = in_normal.y * 10;
  gl_Position = pos;
}";

        public static string fragmentShaderSource = @"
#version 400

uniform sampler2D tex0;

in vec4 color;

out vec4 fragColor;

void main(void)
{
  fragColor = color * texture2D(tex0, gl_PointCoord.st);
}";
        #endregion
    }
}
