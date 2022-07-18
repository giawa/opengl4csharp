using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#if USE_NUMERICS
using System.Numerics;
#endif
using OpenGL;

namespace OpenGLUnitTests
{
    [TestClass]
    public class Matrix2Tests
    {
        [TestMethod]
        public void MatrixCreateIdentity()
        {
            Matrix2 identity = Matrix2.Identity;

            Assert.AreEqual(identity[0], Vector2.UnitX);
            Assert.AreEqual(identity[1], Vector2.UnitY);
        }

        [TestMethod]
        public void MatrixCreateFromMatrix()
        {
            Matrix2 matrix1 = new Matrix2(new double[] { 0, 1, 2, 3 });
            Matrix2 matrix2 = new Matrix2(matrix1);

            Assert.AreEqual(matrix1, matrix2);
        }

        [TestMethod]
        public void MatrixCreateFromVectors()
        {
            Vector2 v1 = new Vector2(0, 1);
            Vector2 v2 = new Vector2(2, 3);

            Matrix2 matrix = new Matrix2(v1, v2);

            Assert.AreEqual(matrix[0], v1);
            Assert.AreEqual(matrix[1], v2);
        }

        [TestMethod]
        public void MatrixCreateFromFloatArray()
        {
            Matrix2 matrix = new Matrix2(new float[] { 0, 1, 2, 3 });

            Assert.AreEqual(matrix[0], new Vector2(0, 1));
            Assert.AreEqual(matrix[1], new Vector2(2, 3));
        }

        [TestMethod]
        public void MatrixCreateFromDoubleArray()
        {
            Matrix2 matrix = new Matrix2(new double[] { 0, 1, 2, 3 });

            Assert.AreEqual(matrix[0], new Vector2(0, 1));
            Assert.AreEqual(matrix[1], new Vector2(2, 3));
        }

        [TestMethod]
        public void MatrixCreateFromFloats()
        {
            Matrix2 matrix = new Matrix2(0, 1, 2, 3);

            Assert.AreEqual(matrix[0], new Vector2(0, 1));
            Assert.AreEqual(matrix[1], new Vector2(2, 3));
        }

        [TestMethod]
        public void MatrixSetMatrix()
        {
            Vector2 v1 = new Vector2(4, 5);
            Vector2 v2 = new Vector2(6, 7);

            Matrix2 matrix = new Matrix2(new double[] { 0, 1, 2, 3 });
            matrix.SetMatrix(v1, v2);

            Assert.AreEqual(matrix[0], v1);
            Assert.AreEqual(matrix[1], v2);
        }

        [TestMethod]
        public void MatrixAdd()
        {
            Matrix2 m1 = new Matrix2(new double[] { 0, 1, 2, 3 });
            Matrix2 m2 = new Matrix2(new double[] { 10, 20, 30, 40 });
            Matrix2 sum = m1 + m2;

            Assert.AreEqual(sum[0], m1[0] + m2[0]);
            Assert.AreEqual(sum[1], m1[1] + m2[1]);
        }

        [TestMethod]
        public void MatrixSubtract()
        {
            Matrix2 m1 = new Matrix2(new double[] { 0, 1, 2, 3 });
            Matrix2 m2 = new Matrix2(new double[] { 10, 20, 30, 40 });
            Matrix2 difference = m1 - m2;

            Assert.AreEqual(difference[0], m1[0] - m2[0]);
            Assert.AreEqual(difference[1], m1[1] - m2[1]);
        }

        [TestMethod]
        public void MatrixMultiply()
        {
            Matrix2 m1 = new Matrix2(new double[] { 0, 1, 2, 3 });
            Matrix2 m2 = new Matrix2(new double[] { 10, 20, 30, 40 });
            Matrix2 mult = m1 * m2;

            Assert.AreEqual(mult[0], new Vector2(30, 40));
            Assert.AreEqual(mult[1], new Vector2(110, 160));
        }

        [TestMethod]
        public void MatrixMultiplyByFloat()
        {
            Vector2 v1 = new Vector2(0, 1);
            Vector2 v2 = new Vector2(2, 3);

            Matrix2 matrix = new Matrix2(v1, v2);
            Matrix2 mult = matrix * 2f;

            Assert.AreEqual(mult[0], v1 * 2f);
            Assert.AreEqual(mult[1], v2 * 2f);
        }

        [TestMethod]
        public void MatrixDivideByFloat()
        {
            Vector2 v1 = new Vector2(0, 1);
            Vector2 v2 = new Vector2(2, 3);

            Matrix2 matrix = new Matrix2(v1, v2);
            Matrix2 mult = matrix / 2f;

            Assert.AreEqual(mult[0], v1 / 2f);
            Assert.AreEqual(mult[1], v2 / 2f);
        }

        [TestMethod]
        public void MatrixMultiplyByVector()
        {
            Vector2 expected = new Vector2(170, 390);

            Matrix2 matrix = new Matrix2(new float[] { 10, 20, 30, 40 });
            Vector2 v1 = new Vector2(5, 6);
            Vector2 mult = matrix * v1;

            Assert.AreEqual(mult, expected);
        }

        [TestMethod]
        public void VectorMultiplyByMatrix()
        {
            Vector2 expected = new Vector2(230, 340);

            Matrix2 matrix = new Matrix2(new float[] { 10, 20, 30, 40 });
            Vector2 v1 = new Vector2(5, 6);
            Vector2 mult = v1 * matrix;

            Assert.AreEqual(mult, expected);
        }

        [TestMethod]
        public void MatrixEqualsOperator()
        {
            Matrix2 m1 = new Matrix2(new float[] { 0, 1, 2, 3 });
            Matrix2 m2 = new Matrix2(new float[] { 0, 2, 2, 3 });
            Matrix2 m3 = new Matrix2(new float[] { 0, 1, 5, 3 });
            Matrix2 m4 = new Matrix2(new float[] { 7, 1, 8, 3 });

            Assert.IsTrue(m1 == m1);
            Assert.IsTrue(m2 == m2);
            Assert.IsTrue(m3 == m3);
            Assert.IsTrue(m4 == m4);

            Assert.IsFalse(m1 == m2);
            Assert.IsFalse(m1 == m3);
            Assert.IsFalse(m1 == m4);
            Assert.IsFalse(m2 == m1);
            Assert.IsFalse(m2 == m3);
            Assert.IsFalse(m2 == m4);
            Assert.IsFalse(m3 == m1);
            Assert.IsFalse(m3 == m2);
            Assert.IsFalse(m3 == m4);
            Assert.IsFalse(m4 == m1);
            Assert.IsFalse(m4 == m2);
            Assert.IsFalse(m4 == m3);
        }

        [TestMethod]
        public void MatrixNotEqualsOperator()
        {
            Matrix2 m1 = new Matrix2(new float[] { 0, 1, 2, 3 });
            Matrix2 m2 = new Matrix2(new float[] { 0, 2, 2, 3 });
            Matrix2 m3 = new Matrix2(new float[] { 0, 1, 5, 3 });
            Matrix2 m4 = new Matrix2(new float[] { 7, 1, 8, 3 });

            Assert.IsFalse(m1 != m1);
            Assert.IsFalse(m2 != m2);
            Assert.IsFalse(m3 != m3);
            Assert.IsFalse(m4 != m4);

            Assert.IsTrue(m1 != m2);
            Assert.IsTrue(m1 != m3);
            Assert.IsTrue(m1 != m4);
            Assert.IsTrue(m2 != m1);
            Assert.IsTrue(m2 != m3);
            Assert.IsTrue(m2 != m4);
            Assert.IsTrue(m3 != m1);
            Assert.IsTrue(m3 != m2);
            Assert.IsTrue(m3 != m4);
            Assert.IsTrue(m4 != m1);
            Assert.IsTrue(m4 != m2);
            Assert.IsTrue(m4 != m3);
        }

        [TestMethod]
        public void MatrixEqualsAsObject()
        {
            object m1 = new Matrix2(new float[] { 0, 1, 2, 3 });
            object m2 = new Matrix2(new float[] { 0, 2, 2, 3 });
            object m3 = new Matrix2(new float[] { 0, 1, 5, 3 });
            object m4 = new Matrix2(new float[] { 7, 1, 8, 3 });

            Assert.IsTrue(m1.Equals(m1));
            Assert.IsTrue(m2.Equals(m2));
            Assert.IsTrue(m3.Equals(m3));
            Assert.IsTrue(m4.Equals(m4));

            Assert.IsFalse(m1.Equals(m2));
            Assert.IsFalse(m1.Equals(m3));
            Assert.IsFalse(m1.Equals(m4));
            Assert.IsFalse(m2.Equals(m1));
            Assert.IsFalse(m2.Equals(m3));
            Assert.IsFalse(m2.Equals(m4));
            Assert.IsFalse(m3.Equals(m1));
            Assert.IsFalse(m3.Equals(m2));
            Assert.IsFalse(m3.Equals(m4));
            Assert.IsFalse(m4.Equals(m1));
            Assert.IsFalse(m4.Equals(m2));
            Assert.IsFalse(m4.Equals(m3));
        }

        [TestMethod]
        public void MatrixEqualsAsMatrix()
        {
            Matrix2 m1 = new Matrix2(new float[] { 0, 1, 2, 3 });
            Matrix2 m2 = new Matrix2(new float[] { 0, 2, 2, 3 });
            Matrix2 m3 = new Matrix2(new float[] { 0, 1, 5, 3 });
            Matrix2 m4 = new Matrix2(new float[] { 7, 1, 8, 3 });

            Assert.IsTrue(m1.Equals(m1));
            Assert.IsTrue(m2.Equals(m2));
            Assert.IsTrue(m3.Equals(m3));
            Assert.IsTrue(m4.Equals(m4));

            Assert.IsFalse(m1.Equals(m2));
            Assert.IsFalse(m1.Equals(m3));
            Assert.IsFalse(m1.Equals(m4));
            Assert.IsFalse(m2.Equals(m1));
            Assert.IsFalse(m2.Equals(m3));
            Assert.IsFalse(m2.Equals(m4));
            Assert.IsFalse(m3.Equals(m1));
            Assert.IsFalse(m3.Equals(m2));
            Assert.IsFalse(m3.Equals(m4));
            Assert.IsFalse(m4.Equals(m1));
            Assert.IsFalse(m4.Equals(m2));
            Assert.IsFalse(m4.Equals(m3));
        }

        [TestMethod]
        public void MatrixCreateRotation()
        {
            Matrix2 rot0deg = new Matrix2(1, 0, 0, 1);
            Matrix2 rot90deg = new Matrix2(0, -1, 1, 0);
            Matrix2 rot180deg = new Matrix2(-1, 0, 0, -1);
            Matrix2 rot270deg = new Matrix2(0, 1, -1, 0);

            CompareMatrices(Matrix2.CreateRotation((float)Math.PI * 0.0f), rot0deg, 10e-7f);
            CompareMatrices(Matrix2.CreateRotation((float)Math.PI * 0.5f), rot90deg, 10e-7f);
            CompareMatrices(Matrix2.CreateRotation((float)Math.PI * 1.0f), rot180deg, 10e-7f);
            CompareMatrices(Matrix2.CreateRotation((float)Math.PI * 1.5f), rot270deg, 10e-7f);
            CompareMatrices(Matrix2.CreateRotation((float)Math.PI * 2.0f), rot0deg, 10e-7f);
        }

        [TestMethod]
        public void MatrixInverse()
        {
            Matrix2 matrix = new Matrix2(new double[] { 10, 20, 30, 40 });
            Matrix2 inverse = matrix.Inverse();
            Matrix2 identity = matrix * inverse;

            // make sure the diff between the identity matrix and the expected identity is less than e-8
            CompareMatrices(identity, Matrix2.Identity, 10e-8f);
        }

        [TestMethod]
        public void MatrixToFloat()
        {
            float[] array = new float[] { 10, 20, 30, 40 };
            Matrix2 matrix = new Matrix2(array);
            float[] comparison = matrix.ToFloat();

            Assert.AreEqual(comparison.Length, array.Length);
            for (int i = 0; i < array.Length; i++)
                Assert.AreEqual(comparison[i], array[i]);
        }

        private static void CompareMatrices(Matrix2 m1, Matrix2 m2, float allowedError)
        {
            string errorMessage = $"The matrices {m1} and {m2} are not equal with an allowed error of {allowedError}.";
            Assert.IsTrue(Math.Abs((m1[0] - m2[0]).X) < allowedError, errorMessage);
            Assert.IsTrue(Math.Abs((m1[0] - m2[0]).Y) < allowedError, errorMessage);
            Assert.IsTrue(Math.Abs((m1[1] - m2[1]).X) < allowedError, errorMessage);
            Assert.IsTrue(Math.Abs((m1[1] - m2[1]).Y) < allowedError, errorMessage);
        }
    }
}
