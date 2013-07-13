using System;

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
            this.Program = program;
            this.Texture = texture;

            int[] elements = new int[locations.Length];
            for (int i = 0; i < elements.Length; i++) elements[i] = i;

            this.billboard = new VAO(program, new VBO<Vector3>(locations), new VBO<Vector3>(colors), new VBO<int>(elements));
            this.billboard.DrawMode = BeginMode.Points;
            this.billboard.DisposeChildren = true;
            this.Color = new Vector4(1, 1, 1, 1);
        }
        #endregion

        #region Methods
        public void Draw()
        {
            billboard.Draw();
        }

        public void Dispose()
        {
            this.Program.Dispose();
            this.Texture.Dispose();
            this.billboard.Dispose();
        }
        #endregion

        #region Sample Shader Code
        public static string vertexShaderSource = @"
#version 330

uniform mat4 projection_matrix;
uniform mat4 modelview_matrix;

in vec3 in_position;
in vec3 in_normal;

void main(void)
{
  vec4 pos = projection_matrix * modelview_matrix * vec4(in_position, 1);
  gl_FrontColor = vec4(in_normal, 1);
  gl_PointSize = in_normal.y * 10;
  gl_Position = pos;
}";

        public static string fragmentShaderSource = @"
#version 330

uniform sampler2D tex0;

void main(void)
{
  gl_FragColor = gl_Color * texture2D(tex0, gl_PointCoord.st);
}";
        #endregion
    }
}
