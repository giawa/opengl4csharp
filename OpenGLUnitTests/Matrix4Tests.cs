﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

#if USE_NUMERICS
using System.Numerics;
#endif
using OpenGL;

namespace OpenGLUnitTests
{
    [TestClass]
    public class Matrix4Tests
    {
        [TestMethod]
        public void MatrixCreateIdentity()
        {
            Matrix4 identity = Matrix4.Identity;

            Assert.AreEqual(identity[0], Vector4.UnitX);
            Assert.AreEqual(identity[1], Vector4.UnitY);
            Assert.AreEqual(identity[2], Vector4.UnitZ);
            Assert.AreEqual(identity[3], Vector4.UnitW);
        }

        [TestMethod]
        public void MatrixCreateFromArray()
        {
            Matrix4 matrix = new Matrix4(new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });

            Assert.AreEqual(matrix[0], new Vector4(0, 1, 2, 3));
            Assert.AreEqual(matrix[1], new Vector4(4, 5, 6, 7));
            Assert.AreEqual(matrix[2], new Vector4(8, 9, 10, 11));
            Assert.AreEqual(matrix[3], new Vector4(12, 13, 14, 15));
        }

        [TestMethod]
        public void MatrixCreateFromVectors()
        {
            Vector4 v4 = new Vector4(0, 1, 2, 3);
            Vector4 v3 = new Vector4(4, 5, 6, 7);
            Vector4 v2 = new Vector4(8, 9, 10, 11);
            Vector4 v1 = new Vector4(12, 13, 14, 15);

            Matrix4 matrix = new Matrix4(v1, v2, v3, v4);

            Assert.AreEqual(matrix[0], v1);
            Assert.AreEqual(matrix[1], v2);
            Assert.AreEqual(matrix[2], v3);
            Assert.AreEqual(matrix[3], v4);
        }

        [TestMethod]
        public void MatrixAdd()
        {
            Matrix4 m1 = new Matrix4(new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            Matrix4 m2 = new Matrix4(new double[] { 10, 20, 30, 40, 50, 10, 20, 30, 40, 50, 10, 20, 30, 40, 50, 10 });
            Matrix4 sum = m1 + m2;

            Assert.AreEqual(sum[0], m1[0] + m2[0]);
            Assert.AreEqual(sum[1], m1[1] + m2[1]);
            Assert.AreEqual(sum[2], m1[2] + m2[2]);
            Assert.AreEqual(sum[3], m1[3] + m2[3]);
        }

        [TestMethod]
        public void MatrixSubtract()
        {
            Matrix4 m1 = new Matrix4(new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            Matrix4 m2 = new Matrix4(new double[] { 10, 20, 30, 40, 50, 10, 20, 30, 40, 50, 10, 20, 30, 40, 50, 10 });
            Matrix4 difference = m1 - m2;

            Assert.AreEqual(difference[0], m1[0] - m2[0]);
            Assert.AreEqual(difference[1], m1[1] - m2[1]);
            Assert.AreEqual(difference[2], m1[2] - m2[2]);
            Assert.AreEqual(difference[3], m1[3] - m2[3]);
        }

        [TestMethod]
        public void MatrixMultiply()
        {
            Matrix4 m1 = new Matrix4(new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            Matrix4 m2 = new Matrix4(new double[] { 10, 20, 30, 40, 50, 10, 20, 30, 40, 50, 10, 20, 30, 40, 50, 10 });
            Matrix4 mult = m1 * m2;

            Assert.AreEqual(new Vector4(220, 230, 190, 100), mult[0]);
            Assert.AreEqual(new Vector4(740, 710, 630, 500), mult[1]);
            Assert.AreEqual(new Vector4(1260, 1190, 1070, 900), mult[2]);
            Assert.AreEqual(new Vector4(1780, 1670, 1510, 1300), mult[3]);
        }

        [TestMethod]
        public void MatrixMultiplyMultipleMatrix()
        {
            Matrix4 m1 = new Matrix4(new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            Matrix4 m2 = new Matrix4(new double[] { 10, 20, 30, 40, 50, 10, 20, 30, 40, 50, 10, 20, 30, 40, 50, 10 });
            Matrix4 m3 = new Matrix4(new double[] { 100, 200, 300, 400, 500, 100, 200, 300, 400, 500, 100, 200, 300, 400, 500, 100 });
            Matrix4 mult = m1 * m2 * m3;

            Assert.AreEqual(new Vector4(243000, 202000, 181000, 205000), mult[0]);
            Assert.AreEqual(new Vector4(831000, 734000, 677000, 685000), mult[1]);
            Assert.AreEqual(new Vector4(1419000, 1266000, 1173000, 1165000), mult[2]);
            Assert.AreEqual(new Vector4(2007000, 1798000, 1669000, 1645000), mult[3]);
        }

        [TestMethod]
        public void MatrixMultiplyByFloat()
        {
            Vector4 v4 = new Vector4(0, 1, 2, 3);
            Vector4 v3 = new Vector4(4, 5, 6, 7);
            Vector4 v2 = new Vector4(8, 9, 10, 11);
            Vector4 v1 = new Vector4(12, 13, 14, 15);

            Matrix4 matrix = new Matrix4(v1, v2, v3, v4);
            Matrix4 mult = matrix * 2f;

            Assert.AreEqual(mult[0], v1 * 2f);
            Assert.AreEqual(mult[1], v2 * 2f);
            Assert.AreEqual(mult[2], v3 * 2f);
            Assert.AreEqual(mult[3], v4 * 2f);
        }

        [TestMethod]
        public void MatrixMultiplyByVector3()
        {
            Vector4 v4 = new Vector4(0, 1, 2, 3);
            Vector4 v3 = new Vector4(4, 5, 6, 7);
            Vector4 v2 = new Vector4(8, 9, 10, 11);
            Vector4 v1 = new Vector4(12, 13, 14, 15);

            Matrix4 matrix = new Matrix4(v1, v2, v3, v4);
            Vector3 vector = new Vector3(3, 7, -1);
            Vector3 mult = matrix * vector;

            Vector4 vector4 = new Vector4(vector, 0);
            Assert.AreEqual(mult.X, Vector4.Dot(matrix[0], vector4));
            Assert.AreEqual(mult.Y, Vector4.Dot(matrix[1], vector4));
            Assert.AreEqual(mult.Z, Vector4.Dot(matrix[2], vector4));
        }

        [TestMethod]
        public void MatrixMultiplyByVector4()
        {
            Vector4 v4 = new Vector4(0, 1, 2, 3);
            Vector4 v3 = new Vector4(4, 5, 6, 7);
            Vector4 v2 = new Vector4(8, 9, 10, 11);
            Vector4 v1 = new Vector4(12, 13, 14, 15);

            Matrix4 matrix = new Matrix4(v1, v2, v3, v4);
            Vector4 vector = new Vector4(3, 7, -1, 4);
            Vector4 mult = matrix * vector;

            Assert.AreEqual(mult.X, Vector4.Dot(matrix[0], vector));
            Assert.AreEqual(mult.Y, Vector4.Dot(matrix[1], vector));
            Assert.AreEqual(mult.Z, Vector4.Dot(matrix[2], vector));
            Assert.AreEqual(mult.W, Vector4.Dot(matrix[3], vector));
        }

        [TestMethod]
        public void Vector4MultiplyByMatrix()
        {
            Vector4 v1 = new Vector4(0, 1, 2, 3);
            Vector4 v2 = new Vector4(4, 5, 6, 7);
            Vector4 v3 = new Vector4(8, 9, 10, 11);
            Vector4 v4 = new Vector4(12, 13, 14, 15);

            Matrix4 matrix = new Matrix4(v1, v2, v3, v4);
            Vector4 vector = new Vector4(5, 6, 7, 8);

            Vector4 actual = vector * matrix;
            Vector4 expected = new Vector4(176, 202, 228, 254);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vector3MultiplyByMatrix()
        {
            Vector4 v1 = new Vector4(0, 1, 2, 3);
            Vector4 v2 = new Vector4(4, 5, 6, 7);
            Vector4 v3 = new Vector4(8, 9, 10, 11);
            Vector4 v4 = new Vector4(12, 13, 14, 15);

            Matrix4 matrix = new Matrix4(v1, v2, v3, v4);
            Vector3 vector = new Vector3(5, 6, 7);

            Vector3 actual = vector * matrix;
            Vector3 expected = new Vector3(80, 98, 116);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MatrixDivideByFloat()
        {
            Vector4 v4 = new Vector4(0, 1, 2, 3);
            Vector4 v3 = new Vector4(4, 5, 6, 7);
            Vector4 v2 = new Vector4(8, 9, 10, 11);
            Vector4 v1 = new Vector4(12, 13, 14, 15);

            Matrix4 matrix = new Matrix4(v1, v2, v3, v4);
            Matrix4 mult = matrix / 2f;

            Assert.AreEqual(mult[0], v1 / 2f);
            Assert.AreEqual(mult[1], v2 / 2f);
            Assert.AreEqual(mult[2], v3 / 2f);
            Assert.AreEqual(mult[3], v4 / 2f);
        }

        [TestMethod]
        public void MatrixEqualityOpMatrix()
        {
            Vector4 v1 = new Vector4(0, 1, 2, 3);
            Vector4 v2 = new Vector4(4, 5, 6, 7);
            Vector4 v3 = new Vector4(8, 9, 10, 11);
            Vector4 v4 = new Vector4(12, 13, 14, 15);

            Assert.IsTrue(new Matrix4(v1, v2, v3, v4) == new Matrix4(v1, v2, v3, v4));
            Assert.IsFalse(new Matrix4(v1, v2, v4, v3) == new Matrix4(v1, v2, v3, v4));
            Assert.IsFalse(new Matrix4(v1, v3, v2, v4) == new Matrix4(v1, v2, v3, v4));
            Assert.IsFalse(new Matrix4(v1, v3, v4, v2) == new Matrix4(v1, v2, v3, v4));
            Assert.IsFalse(new Matrix4(v1, v4, v2, v3) == new Matrix4(v1, v2, v3, v4));
            Assert.IsFalse(new Matrix4(v1, v4, v3, v2) == new Matrix4(v1, v2, v3, v4));

            Assert.IsFalse(new Matrix4(v2, v1, v3, v4) == new Matrix4(v1, v2, v3, v4));
            Assert.IsFalse(new Matrix4(v2, v1, v4, v3) == new Matrix4(v1, v2, v3, v4));
            Assert.IsFalse(new Matrix4(v2, v3, v1, v4) == new Matrix4(v1, v2, v3, v4));
            Assert.IsFalse(new Matrix4(v2, v3, v4, v1) == new Matrix4(v1, v2, v3, v4));
            Assert.IsFalse(new Matrix4(v2, v4, v1, v3) == new Matrix4(v1, v2, v3, v4));
            Assert.IsFalse(new Matrix4(v2, v4, v3, v1) == new Matrix4(v1, v2, v3, v4));
        }

        [TestMethod]
        public void MatrixInEqualityOpMatrix()
        {
            Vector4 v1 = new Vector4(0, 1, 2, 3);
            Vector4 v2 = new Vector4(4, 5, 6, 7);
            Vector4 v3 = new Vector4(8, 9, 10, 11);
            Vector4 v4 = new Vector4(12, 13, 14, 15);

            Assert.IsFalse(new Matrix4(v1, v2, v3, v4) != new Matrix4(v1, v2, v3, v4));
            Assert.IsTrue(new Matrix4(v1, v2, v4, v3) != new Matrix4(v1, v2, v3, v4));
            Assert.IsTrue(new Matrix4(v1, v3, v2, v4) != new Matrix4(v1, v2, v3, v4));
            Assert.IsTrue(new Matrix4(v1, v3, v4, v2) != new Matrix4(v1, v2, v3, v4));
            Assert.IsTrue(new Matrix4(v1, v4, v2, v3) != new Matrix4(v1, v2, v3, v4));
            Assert.IsTrue(new Matrix4(v1, v4, v3, v2) != new Matrix4(v1, v2, v3, v4));

            Assert.IsTrue(new Matrix4(v2, v1, v3, v4) != new Matrix4(v1, v2, v3, v4));
            Assert.IsTrue(new Matrix4(v2, v1, v4, v3) != new Matrix4(v1, v2, v3, v4));
            Assert.IsTrue(new Matrix4(v2, v3, v1, v4) != new Matrix4(v1, v2, v3, v4));
            Assert.IsTrue(new Matrix4(v2, v3, v4, v1) != new Matrix4(v1, v2, v3, v4));
            Assert.IsTrue(new Matrix4(v2, v4, v1, v3) != new Matrix4(v1, v2, v3, v4));
            Assert.IsTrue(new Matrix4(v2, v4, v3, v1) != new Matrix4(v1, v2, v3, v4));
        }

        [TestMethod]
        public void MatrixEqualsMatrix()
        {
            Vector4 v1 = new Vector4(0, 1, 2, 3);
            Vector4 v2 = new Vector4(4, 5, 6, 7);
            Vector4 v3 = new Vector4(8, 9, 10, 11);
            Vector4 v4 = new Vector4(12, 13, 14, 15);

            Assert.IsTrue(new Matrix4(v1, v2, v3, v4).Equals(new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v1, v2, v4, v3).Equals(new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v1, v3, v2, v4).Equals(new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v1, v3, v4, v2).Equals(new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v1, v4, v2, v3).Equals(new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v1, v4, v3, v2).Equals(new Matrix4(v1, v2, v3, v4)));

            Assert.IsFalse(new Matrix4(v2, v1, v3, v4).Equals(new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v2, v1, v4, v3).Equals(new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v2, v3, v1, v4).Equals(new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v2, v3, v4, v1).Equals(new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v2, v4, v1, v3).Equals(new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v2, v4, v3, v1).Equals(new Matrix4(v1, v2, v3, v4)));
        }

        [TestMethod]
        public void MatrixEqualsObject()
        {
            Vector4 v1 = new Vector4(0, 1, 2, 3);
            Vector4 v2 = new Vector4(4, 5, 6, 7);
            Vector4 v3 = new Vector4(8, 9, 10, 11);
            Vector4 v4 = new Vector4(12, 13, 14, 15);

            Assert.IsTrue(new Matrix4(v1, v2, v3, v4).Equals((object)new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v1, v2, v4, v3).Equals((object)new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v1, v3, v2, v4).Equals((object)new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v1, v3, v4, v2).Equals((object)new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v1, v4, v2, v3).Equals((object)new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v1, v4, v3, v2).Equals((object)new Matrix4(v1, v2, v3, v4)));

            Assert.IsFalse(new Matrix4(v2, v1, v3, v4).Equals((object)new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v2, v1, v4, v3).Equals((object)new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v2, v3, v1, v4).Equals((object)new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v2, v3, v4, v1).Equals((object)new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v2, v4, v1, v3).Equals((object)new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v2, v4, v3, v1).Equals((object)new Matrix4(v1, v2, v3, v4)));
            Assert.IsFalse(new Matrix4(v2, v4, v3, v1).Equals(new object()));
        }

        [TestMethod]
        public void MatrixToFloat()
        {
            float[] array = new float[] { 10, 20, 30, 40, 50, 10, 20, 30, 40, 50, 10, 20, 30, 40, 50, 10 };
            Matrix4 matrix = new Matrix4(array);
            float[] comparison = matrix.ToFloat();

            Assert.AreEqual(comparison.Length, array.Length);
            for (int i = 0; i < array.Length; i++)
                Assert.AreEqual(comparison[i], array[i]);
        }

        [TestMethod]
        public void MatrixInverse()
        {
            Matrix4 matrix = new Matrix4(new double[] { 10, 20, 30, 40, 50, 10, 20, 30, 40, 50, 10, 20, 30, 40, 50, 10 });
            Matrix4 inverse = matrix.Inverse();
            float[] identity = (matrix * inverse).ToFloat();

            // make sure the diff between the identity matrix and the float[] is less than e-8
            for (int i = 0; i < identity.Length; i++)
                Assert.IsTrue(identity[i] - Matrix4.Identity[i / 4].Get(i % 4) < 10e-8);
        }

        [TestMethod]
        public void MatrixTranspose()
        {
            Vector4 v1 = new Vector4(0, 1, 2, 3);
            Vector4 v2 = new Vector4(4, 5, 6, 7);
            Vector4 v3 = new Vector4(8, 9, 10, 11);
            Vector4 v4 = new Vector4(12, 13, 14, 15);

            Vector4 v1t = new Vector4(0, 4, 8, 12);
            Vector4 v2t = new Vector4(1, 5, 9, 13);
            Vector4 v3t = new Vector4(2, 6, 10, 14);
            Vector4 v4t = new Vector4(3, 7, 11, 15);

            Matrix4 matrix = new Matrix4(v1, v2, v3, v4);
            Matrix4 expected = new Matrix4(v1t, v2t, v3t, v4t);
            Matrix4 actual = matrix.Transpose();

            Assert.AreEqual(expected, actual);
        }
    }
}