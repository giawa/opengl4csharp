#define USE_NUMERICS

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#if USE_NUMERICS
using System.Numerics;
#else
using OpenGL;
#endif

namespace OpenGLUnitTests
{
    [TestClass]
    public class Vector3Tests
    {
        [TestMethod]
        public void Vector3BuiltIns()
        {
            Assert.AreEqual(Vector3.One, new Vector3(1, 1, 1));
            Assert.AreEqual(Vector3.UnitX, new Vector3(1, 0, 0));
            Assert.AreEqual(Vector3.UnitY, new Vector3(0, 1, 0));
            Assert.AreEqual(Vector3.UnitZ, new Vector3(0, 0, 1));
            Assert.AreEqual(Vector3.Zero, new Vector3(0, 0, 0));
        }

        [TestMethod]
        public void Vector3StaticMethods()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Vector3 v1 = new Vector3(GetRandomFloat(), GetRandomFloat(), GetRandomFloat());
                Vector3 v2 = new Vector3(GetRandomFloat(), GetRandomFloat(), GetRandomFloat());
                Vector3 v3 = new Vector3(GetRandomFloat(), GetRandomFloat(), GetRandomFloat());
                float f1 = GetRandomFloat();
                Quaternion q = new Quaternion(GetRandomFloat(), GetRandomFloat(), GetRandomFloat(), GetRandomFloat());
                float[] ma = new float[16];
                for (int j = 0; j < 16; j++) ma[j] = GetRandomFloat();
                OpenGL.Matrix4 m = new OpenGL.Matrix4(ma);

                Assert.AreEqual(Vector3.Abs(v1), new Vector3(Math.Abs(v1.X), Math.Abs(v1.Y), Math.Abs(v1.Z)));
                Assert.AreEqual(Vector3.Add(v1, v2), new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z));
                Assert.AreEqual(Vector3.Clamp(v1, v2, v3), new Vector3(Clamp(v1.X, v2.X, v3.X), Clamp(v1.Y, v2.Y, v3.Y), Clamp(v1.Z, v2.Z, v3.Z)));
                Assert.AreEqual(Vector3.Cross(v1, v2), new Vector3(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X));
#if USE_NUMERICS
                Assert.IsTrue(CloseEnough(Vector3.Distance(v1, v2), (v1 - v2).Length()));
#else
                Assert.IsTrue(CloseEnough(Vector3.Distance(v1, v2), (v1 - v2).Length));
#endif
                Assert.IsTrue(CloseEnough(Vector3.DistanceSquared(v1, v2), (v1 - v2).LengthSquared()));
                Assert.AreEqual(Vector3.Divide(v1, f1), new Vector3(v1.X / f1, v1.Y / f1, v1.Z / f1));
                Assert.AreEqual(Vector3.Divide(v1, v2), new Vector3(v1.X / v2.X, v1.Y / v2.Y, v1.Z / v2.Z));
                Assert.IsTrue(CloseEnough(Vector3.Dot(v1, v2), v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z));
                Assert.IsTrue(CloseEnough(Vector3.Lerp(v1, v2, f1), v1 + (v2 - v1) * f1, 1e-02f));
                Assert.AreEqual(Vector3.Max(v1, v2), new Vector3(Math.Max(v1.X, v2.X), Math.Max(v1.Y, v2.Y), Math.Max(v1.Z, v2.Z)));
                Assert.AreEqual(Vector3.Min(v1, v2), new Vector3(Math.Min(v1.X, v2.X), Math.Min(v1.Y, v2.Y), Math.Min(v1.Z, v2.Z)));
                Assert.AreEqual(Vector3.Multiply(v1, f1), new Vector3(v1.X * f1, v1.Y * f1, v1.Z * f1));
                Assert.AreEqual(Vector3.Multiply(f1, v1), new Vector3(v1.X * f1, v1.Y * f1, v1.Z * f1));
                Assert.AreEqual(Vector3.Multiply(v1, v2), new Vector3(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z));
                Assert.AreEqual(Vector3.Negate(v1), new Vector3(-v1.X, -v1.Y, -v1.Z));
#if USE_NUMERICS
                Assert.AreEqual(Vector3.Normalize(v1), v1 / v1.Length());
#else
                Assert.AreEqual(Vector3.Normalize(v1), v1 / v1.Length);
#endif
                Assert.IsTrue(CloseEnough(Vector3.Reflect(v1, v2), v1 - Vector3.Dot(v1, v2) * v2 * 2f));
                Assert.IsTrue(CloseEnough(Vector3.SquareRoot(v1), new Vector3((float)Math.Sqrt(v1.X), (float)Math.Sqrt(v1.Y), (float)Math.Sqrt(v1.Z))));
                Assert.AreEqual(Vector3.Subtract(v1, v2), new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z));
                Assert.IsTrue(CloseEnough(Vector3.Transform(v1, q), Transform(v1, q), 1e-01f));
            }
        }

        private static Random generator = new Random(Environment.TickCount);

        private float GetRandomFloat()
        {
            return (float)(10000 * (generator.NextDouble() - 0.5));
        }

        private float Clamp(float value, float min, float max)
        {
            float actualMax = Math.Max(min, max);
            return (value < min ? min : value > actualMax ? actualMax : value);
        }

        private bool CloseEnough(float f1, float f2, float rtol = 1e-05f)
        {
            if (float.IsNaN(f1) && float.IsNaN(f2)) return true;

            return Math.Abs(f1 - f2) <= Math.Max(rtol * Math.Max(Math.Abs(f1), Math.Abs(f2)), 1e-08f);
        }

        private bool CloseEnough(Vector3 v1, Vector3 v2, float rtol = 1e-05f)
        {
            bool close = CloseEnough(v1.X, v2.X, rtol) && CloseEnough(v1.Y, v2.Y, rtol) && CloseEnough(v1.Z, v2.Z, rtol);

            if (close) return true;
            else 
                return false;
        }

        private Vector3 Transform(Vector3 value, Quaternion rotation)
        {
            float x2 = rotation.X + rotation.X;
            float y2 = rotation.Y + rotation.Y;
            float z2 = rotation.Z + rotation.Z;

            float wx2 = rotation.W * x2;
            float wy2 = rotation.W * y2;
            float wz2 = rotation.W * z2;
            float xx2 = rotation.X * x2;
            float xy2 = rotation.X * y2;
            float xz2 = rotation.X * z2;
            float yy2 = rotation.Y * y2;
            float yz2 = rotation.Y * z2;
            float zz2 = rotation.Z * z2;

            return new Vector3(
                value.X * (1.0f - yy2 - zz2) + value.Y * (xy2 - wz2) + value.Z * (xz2 + wy2),
                value.X * (xy2 + wz2) + value.Y * (1.0f - xx2 - zz2) + value.Z * (yz2 - wx2),
                value.X * (xz2 - wy2) + value.Y * (yz2 + wx2) + value.Z * (1.0f - xx2 - yy2));
        }

        private Vector3 Transform(Vector3 position, OpenGL.Matrix4 matrix)
        {
            return new Vector3(
                position.X * matrix[0].X + position.Y * matrix[1].X + position.Z * matrix[2].X + matrix[3].X,
                position.X * matrix[0].Y + position.Y * matrix[1].Y + position.Z * matrix[2].Y + matrix[3].Y,
                position.X * matrix[0].Z + position.Y * matrix[1].Z + position.Z * matrix[2].Z + matrix[3].Z);
        }

        private Vector3 TransformNormal(Vector3 normal, OpenGL.Matrix4 matrix)
        {
            return new Vector3(
                normal.X * matrix[0].X + normal.Y * matrix[1].X + normal.Z * matrix[2].X,
                normal.X * matrix[0].Y + normal.Y * matrix[1].Y + normal.Z * matrix[2].Y,
                normal.X * matrix[0].Z + normal.Y * matrix[1].Z + normal.Z * matrix[2].Z);
        }

        private System.Numerics.Matrix4x4 FromMatrix4(OpenGL.Matrix4 matrix)
        {
            return new System.Numerics.Matrix4x4(
                matrix[0].X, matrix[0].Y, matrix[0].Z, matrix[0].W,
                matrix[1].X, matrix[1].Y, matrix[1].Z, matrix[1].W,
                matrix[2].X, matrix[2].Y, matrix[2].Z, matrix[2].W,
                matrix[3].X, matrix[3].Y, matrix[3].Z, matrix[3].W);
        }
    }
}
