using System;

#if USE_NUMERICS
using System.Numerics;
#endif

namespace OpenGL
{
    /// <summary>
    /// Helper class that performs simple math on some types of Geometry as
    /// well as helps generate some simple objects such as cubes and quads.
    /// </summary>
    public class Geometry
    {
        /// <summary>
        /// Calculate the array of vertex normals based on vertex and face information (assuming triangle polygons).
        /// </summary>
        /// <param name="vertexData">The vertex data to find the normals for.</param>
        /// <param name="elementData">The element array describing the order in which vertices are drawn.</param>
        /// <returns></returns>
        [Obsolete("Use uint[] instead of int[].")]
        public static Vector3[] CalculateNormals(Vector3[] vertexData, int[] elementData)
        {
            Vector3 b1, b2, normal;
            Vector3[] normalData = new Vector3[vertexData.Length];

            for (int i = 0; i < elementData.Length / 3; i++)
            {
                int cornerA = elementData[i * 3];
                int cornerB = elementData[i * 3 + 1];
                int cornerC = elementData[i * 3 + 2];

                b1 = vertexData[cornerB] - vertexData[cornerA];
                b2 = vertexData[cornerC] - vertexData[cornerA];

                normal = Vector3.Cross(b1, b2).Normalize();

                normalData[cornerA] += normal;
                normalData[cornerB] += normal;
                normalData[cornerC] += normal;
            }

            for (int i = 0; i < normalData.Length; i++) normalData[i] = normalData[i].Normalize();

            return normalData;
        }

        /// <summary>
        /// Calculate the array of vertex normals based on vertex and face information (assuming triangle polygons).
        /// </summary>
        /// <param name="vertexData">The vertex data to find the normals for.</param>
        /// <param name="elementData">The element array describing the order in which vertices are drawn.</param>
        /// <returns></returns>
        public static Vector3[] CalculateNormals(Vector3[] vertexData, uint[] elementData)
        {
            Vector3 b1, b2, normal;
            Vector3[] normalData = new Vector3[vertexData.Length];

            for (int i = 0; i < elementData.Length / 3; i++)
            {
                uint cornerA = elementData[i * 3];
                uint cornerB = elementData[i * 3 + 1];
                uint cornerC = elementData[i * 3 + 2];

                b1 = vertexData[cornerB] - vertexData[cornerA];
                b2 = vertexData[cornerC] - vertexData[cornerA];

                normal = Vector3.Cross(b1, b2).Normalize();

                normalData[cornerA] += normal;
                normalData[cornerB] += normal;
                normalData[cornerC] += normal;
            }

            for (int i = 0; i < normalData.Length; i++) normalData[i] = normalData[i].Normalize();

            return normalData;
        }

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
            Vector3[] vertices = new Vector3[] { new Vector3(location.X, location.Y, 0), new Vector3(location.X + size.X, location.Y, 0), 
                new Vector3(location.X + size.X, location.Y + size.Y, 0), new Vector3(location.X, location.Y + size.Y, 0) };
            Vector2[] uvs = new Vector2[] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) };
            uint[] indices = new uint[] { 0, 1, 2, 2, 3, 0 };

            return new VAO(program, new VBO<Vector3>(vertices), new VBO<Vector2>(uvs), new VBO<uint>(indices, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
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
            Vector3[] vertices = new Vector3[] { new Vector3(location.X, location.Y, 0), new Vector3(location.X + size.X, location.Y, 0), 
                new Vector3(location.X + size.X, location.Y + size.Y, 0), new Vector3(location.X, location.Y + size.Y, 0) };
            Vector2[] uvs = new Vector2[] { uvloc, new Vector2(uvloc.X + uvsize.X, uvloc.Y), new Vector2(uvloc.X + uvsize.X, uvloc.Y + uvsize.Y), new Vector2(uvloc.X, uvloc.Y + uvsize.Y) };
            uint[] indices = new uint[] { 0, 1, 2, 2, 3, 0 };

            return new VAO(program, new VBO<Vector3>(vertices), new VBO<Vector2>(uvs), new VBO<uint>(indices, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
        }

        /// <summary>
        /// Create a basic quad by storing two triangles into a VAO.
        /// This quad includes normals, and does not include UV co-ordinates.
        /// </summary>
        /// <param name="program">The ShaderProgram assigned to this quad.</param>
        /// <param name="location">The location of the VAO (assigned to the vertices).</param>
        /// <param name="size">The size of the VAO (assigned to the vertices).</param>
        /// <returns>The VAO object representing this quad.</returns>
        public static VAO CreateQuadWithNormals(ShaderProgram program, Vector2 location, Vector2 size)
        {
            Vector3[] vertex = new Vector3[] { new Vector3(location.X, location.Y, 0), new Vector3(location.X + size.X, location.Y, 0), 
                new Vector3(location.X + size.X, location.Y + size.Y, 0), new Vector3(location.X, location.Y + size.Y, 0) };
            uint[] element = new uint[] { 0, 1, 2, 2, 3, 0 };
            Vector3[] normal = CalculateNormals(vertex, element);

            return new VAO(program, new VBO<Vector3>(vertex), new VBO<Vector3>(normal), new VBO<uint>(element, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
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
                new Vector3(min.X, min.Y, max.Z),
                new Vector3(max.X, min.Y, max.Z),
                new Vector3(min.X, max.Y, max.Z),
                new Vector3(max.X, max.Y, max.Z),
                new Vector3(max.X, min.Y, min.Z),
                new Vector3(max.X, max.Y, min.Z),
                new Vector3(min.X, max.Y, min.Z),
                new Vector3(min.X, min.Y, min.Z)
            };

            uint[] element = new uint[] {
                0, 1, 2, 1, 3, 2,
                1, 4, 3, 4, 5, 3,
                4, 7, 5, 7, 6, 5,
                7, 0, 6, 0, 2, 6,
                7, 4, 0, 4, 1, 0,
                2, 3, 6, 3, 5, 6
            };

            return new VAO(program, new VBO<Vector3>(vertex), new VBO<uint>(element, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
        }

        /// <summary>
        /// Create a basic cube with normals and stores it in a VAO.
        /// This cube consists of 12 triangles and 6 faces.
        /// </summary>
        /// <param name="program">The ShaderProgram assigned to this cube.</param>
        /// <param name="min">The 3 minimum values of the cube (lower left back corner).</param>
        /// <param name="max">The 3 maximum values of the cube (top right front corner).</param>
        /// <returns></returns>
        public static VAO CreateCubeWithNormals(ShaderProgram program, Vector3 min, Vector3 max)
        {
            Vector3[] vertex = new Vector3[] {
                new Vector3(min.X, min.Y, max.Z),
                new Vector3(max.X, min.Y, max.Z),
                new Vector3(min.X, max.Y, max.Z),
                new Vector3(max.X, max.Y, max.Z),
                new Vector3(max.X, min.Y, min.Z),
                new Vector3(max.X, max.Y, min.Z),
                new Vector3(min.X, max.Y, min.Z),
                new Vector3(min.X, min.Y, min.Z)
            };

            uint[] element = new uint[] {
                0, 1, 2, 1, 3, 2,
                1, 4, 3, 4, 5, 3,
                4, 7, 5, 7, 6, 5,
                7, 0, 6, 0, 2, 6,
                7, 4, 0, 4, 1, 0,
                2, 3, 6, 3, 5, 6
            };

            Vector3[] normal = CalculateNormals(vertex, element);

            return new VAO(program, new VBO<Vector3>(vertex), new VBO<Vector3>(normal), new VBO<uint>(element, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
        }
    }
}
