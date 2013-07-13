using System;

namespace OpenGL.Constructs
{
    public class Geometry
    {
        /// <summary>
        /// Create a basic quad by storing two triangles into a VAO.
        /// This quad includes UV co-ordinates from 0,0 to 1,1.
        /// </summary>
        /// <param name="program">The ShaderProgram assigned to this quad.</param>
        /// <param name="location">The location of the VAO (assigned to the vertices).</param>
        /// <param name="size">The size of the VAO (assigned to the vertices).</param>
        /// <returns>The VAO object representing this quad.</returns>
        public static VAO CreateQuad(ShaderProgram program, Vector2 location, Vector2 size)
        {
            Vector3[] vertices = new Vector3[] { new Vector3(location.x, location.y, 0), new Vector3(location.x + size.x, location.y, 0), 
                new Vector3(location.x + size.x, location.y + size.y, 0), new Vector3(location.x, location.y + size.y, 0) };
            Vector2[] uvs = new Vector2[] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) };
            int[] indices = new int[] { 0, 1, 2, 2, 3, 0 };

            return new VAO(program, new VBO<Vector3>(vertices), new VBO<Vector2>(uvs), new VBO<int>(indices, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
        }

        /// <summary>
        /// Create a basic quad by storing two triangles into a VAO.
        /// This quad includes UV co-ordinates from uvloc to uvloc+uvsize.
        /// </summary>
        /// <param name="program">The ShaderProgram assigned to this quad.</param>
        /// <param name="location">The location of the VAO (assigned to the vertices).</param>
        /// <param name="size">The size of the VAO (assigned to the vertices).</param>
        /// <param name="uvloc">The origin of the UV co-ordinates.</param>
        /// <param name="uvsize">The size of the UV co-ordinates.</param>
        /// <returns>The VAO object representing this quad.</returns>
        public static VAO CreateQuad(ShaderProgram program, Vector2 location, Vector2 size, Vector2 uvloc, Vector2 uvsize)
        {
            Vector3[] vertices = new Vector3[] { new Vector3(location.x, location.y, 0), new Vector3(location.x + size.x, location.y, 0), 
                new Vector3(location.x + size.x, location.y + size.y, 0), new Vector3(location.x, location.y + size.y, 0) };
            Vector2[] uvs = new Vector2[] { uvloc, new Vector2(uvloc.x + uvsize.x, uvloc.y), new Vector2(uvloc.x + uvsize.x, uvloc.y + uvsize.y), new Vector2(uvloc.x, uvloc.y + uvsize.y) };
            int[] indices = new int[] { 0, 1, 2, 2, 3, 0 };

            return new VAO(program, new VBO<Vector3>(vertices), new VBO<Vector2>(uvs), new VBO<int>(indices, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
        }

        /// <summary>
        /// Create a basic cube and store into a VAO.
        /// This cube consists of 12 triangles and 6 faces.
        /// </summary>
        /// <param name="program">The ShaderProgram assigned to this cube.</param>
        /// <param name="min">The 3 minimum values of the cube (lower left back corner).</param>
        /// <param name="max">The 3 maximum values of the cube (top right front corner).</param>
        /// <returns></returns>
        public static VAO CreateCube(ShaderProgram program, Vector3 min, Vector3 max)
        {
            Vector3[] vertex = new Vector3[] {
                new Vector3(min.x, min.y, max.z),
                new Vector3(max.x, min.y, max.z),
                new Vector3(min.x, max.y, max.z),
                new Vector3(max.x, max.y, max.z),
                new Vector3(max.x, min.y, min.z),
                new Vector3(max.x, max.y, min.z),
                new Vector3(min.x, max.y, min.z),
                new Vector3(min.x, min.y, min.z)
            };

            int[] element = new int[] {
                0, 1, 2, 1, 3, 2,
                1, 4, 3, 4, 5, 3,
                4, 7, 5, 7, 6, 5,
                7, 0, 6, 0, 2, 6,
                7, 4, 0, 4, 1, 0,
                2, 3, 6, 3, 5, 6
            };

            return new VAO(program, new VBO<Vector3>(vertex), new VBO<int>(element));
        }
    }
}
