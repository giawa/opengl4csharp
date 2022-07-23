using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.InteropServices;

#if USE_NUMERICS
using System.Numerics;
#endif
using OpenGL;

namespace OpenGLUnitTests
{
    [TestClass]
    public class GeometryTests
    {
        [TestMethod]
        public void CalculateNormalsSingleTriangle()
        {
            Vector3[] vertices = new Vector3[]
            {
                new Vector3(0, 1, 0),
                new Vector3(1, 0, 0),
                new Vector3(0, 0, 0)
            };
            uint[] elements = new uint[] { 0, 1, 2 };

            Vector3[] expectedNormals = new Vector3[]
            {
                new Vector3(0, 0, -1),
                new Vector3(0, 0, -1),
                new Vector3(0, 0, -1)
            };

            VerifyOverloads(vertices, elements, expectedNormals);
        }

        [TestMethod]
        public void CalculateNormalsSingleTriangleReversed()
        {
            Vector3[] vertices = new Vector3[]
            {
                new Vector3(0, 1, 0),
                new Vector3(1, 0, 0),
                new Vector3(0, 0, 0)
            };
            uint[] elements = new uint[] { 2, 1, 0 };

            Vector3[] expectedNormals = new Vector3[]
            {
                new Vector3(0, 0, 1),
                new Vector3(0, 0, 1),
                new Vector3(0, 0, 1)
            };

            VerifyOverloads(vertices, elements, expectedNormals);
        }

        [TestMethod]
        public void CalculateNormalsMultipleTriangles()
        {
            // Pyramid shape
            Vector3[] vertices = new Vector3[]
            {
                new Vector3( 0, 1,  0),
                new Vector3( 0, 0,  1),
                new Vector3( 1, 0,  0),
                new Vector3( 0, 0, -1),
                new Vector3(-1, 0,  0)
            };
            uint[] elements = new uint[] 
            { 
                0, 1, 2,
                0, 2, 3,
                0, 3, 4,
                0, 4, 1
            };

            Vector3[] expectedNormals = new Vector3[]
            {
                new Vector3( 0, 1,  0).Normalize(),
                new Vector3( 0, 1,  1).Normalize(),
                new Vector3( 1, 1,  0).Normalize(),
                new Vector3( 0, 1, -1).Normalize(),
                new Vector3(-1, 1,  0).Normalize()
            };

            VerifyOverloads(vertices, elements, expectedNormals);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateNormalWrongSizeNormalArray()
        {
            Geometry.CalculateNormals(new Vector3[3], new uint[3], new Vector3[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateNormalWrongSizeElementArray()
        {
            Geometry.CalculateNormals(new Vector3[3], new uint[4]);
        }

        private void VerifyOverloads(Vector3[] vertices, uint[] elements, Vector3[] expectedNormals)
        {
            {
                int[] intElements = new int[elements.Length];
                Span<int> casted = MemoryMarshal.Cast<uint, int>(elements);
                casted.CopyTo(intElements);
                Vector3[] actualNormals = Geometry.CalculateNormals(vertices, intElements);
                CompareNormalArrays(expectedNormals, actualNormals);
            }
            {
                Vector3[] actualNormals = Geometry.CalculateNormals(vertices, elements);
                CompareNormalArrays(expectedNormals, actualNormals);
            }
            {
                Vector3[] actualNormals = Geometry.CalculateNormals(vertices.AsSpan(), elements.AsSpan());
                CompareNormalArrays(expectedNormals, actualNormals);
            }
            {
                Vector3[] actualNormals = new Vector3[expectedNormals.Length];
                Geometry.CalculateNormals(vertices, elements, actualNormals);
                CompareNormalArrays(expectedNormals, actualNormals);
            }
        }

        private void CompareNormalArrays(Vector3[] expected, Vector3[] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length, $"{Environment.NewLine}Expected {expected.Length} normals but got {actual.Length} normals.");
            for (int i = 0; i < expected.Length; i++)
            {
                CompareVectors(expected[i], actual[i]);
            }
        }

        private void CompareVectors(Vector3 expected, Vector3 actual)
        {
            Assert.AreEqual(expected, actual, $"{Environment.NewLine}Expected: {expected}{Environment.NewLine}Actual:   {actual}");
        }
    }
}
