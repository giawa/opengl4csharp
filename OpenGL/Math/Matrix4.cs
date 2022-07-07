using System;
using System.Runtime.InteropServices;

#if USE_NUMERICS
using System.Numerics;
#endif

namespace OpenGL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix4 : IEquatable<Matrix4>
    {
        private Vector4 row1, row2, row3, row4;

        #region Static Constructors
        public static Matrix4 Identity
        {
            get { return new Matrix4(Vector4.UnitX, Vector4.UnitY, Vector4.UnitZ, Vector4.UnitW); }
        }
        #endregion

        #region Operators
        public static Matrix4 operator +(Matrix4 m1, Matrix4 m2)
        {
            return new Matrix4(m1.row1 + m2.row1, m1.row2 + m2.row2, m1.row3 + m2.row3, m1.row4 + m2.row4);
        }

        public static Matrix4 operator -(Matrix4 m1, Matrix4 m2)
        {
            return new Matrix4(m1.row1 - m2.row1, m1.row2 - m2.row2, m1.row3 - m2.row3, m1.row4 - m2.row4);
        }

        public static Matrix4 operator *(Matrix4 m, Matrix4 m2)
        {
            Matrix4 mt = m.Transpose();
            return new Matrix4(
                mt * m2.row1,
                mt * m2.row2,
                mt * m2.row3,
                mt * m2.row4);
        }

        public static Matrix4 operator *(Matrix4 m1, float d)
        {
            return new Matrix4(m1.row1 * d, m1.row2 * d, m1.row3 * d, m1.row4 * d);
        }

        public static Matrix4 operator /(Matrix4 m1, float d)
        {
            return new Matrix4(m1.row1 / d, m1.row2 / d, m1.row3 / d, m1.row4 / d);
        }

        public static Vector3 operator *(Matrix4 m1, Vector3 v)
        {
            Vector4 v4 = new Vector4(v, 0.0f);
            return new Vector3(Vector4.Dot(m1.row1, v4), Vector4.Dot(m1.row2, v4), Vector4.Dot(m1.row3, v4));
        }

        public static Vector3 operator *(Vector3 v, Matrix4 m1)
        {
            return new Vector3(
                v.X * m1[0].X + v.Y * m1[1].X + v.Z * m1[2].X,
                v.X * m1[0].Y + v.Y * m1[1].Y + v.Z * m1[2].Y,
                v.X * m1[0].Z + v.Y * m1[1].Z + v.Z * m1[2].Z);
        }

        public static Vector4 operator *(Matrix4 m1, Vector4 v)
        {
            return new Vector4(
                Vector4.Dot(m1.row1, v),
                Vector4.Dot(m1.row2, v),
                Vector4.Dot(m1.row3, v),
                Vector4.Dot(m1.row4, v));
        }

        public static Vector4 operator *(Vector4 v, Matrix4 m1)
        {
            return m1.Transpose() * v;
        }

        public Vector4 this[int a]
        {
            get
            {
                if (a > 3 || a < 0) throw new ArgumentOutOfRangeException();
                return (a == 0 ? row1 : (a == 1 ? row2 : (a == 2 ? row3 : row4)));
            }
            set
            {
                if (a == 0) row1 = value;
                else if (a == 1) row2 = value;
                else if (a == 2) row3 = value;
                else if (a == 3) row4 = value;
            }
        }

        public float this[int column, int row]
        {
            get
            {
                if (row == 0)
                {
                    return row1.Get(column);
                }
                else if (row == 1)
                {
                    return row2.Get(column);
                }
                else if (row == 2)
                {
                    return row3.Get(column);
                }
                else if (row == 3)
                {
                    return row4.Get(column);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(row));
                }
            }
            set
            {
                //Checking each column is needed, so as not to use Vector4[int], as it is not supported by System.Numerics
                if (row == 0)
                {
                    if (column == 0) row1.X = value;
                    else if (column == 1) row1.Y = value;
                    else if (column == 2) row1.Z = value;
                    else if (column == 3) row1.W = value;
                    else throw new ArgumentOutOfRangeException(nameof(column));
                }
                else if (row == 1)
                {
                    if (column == 0) row2.X = value;
                    else if (column == 1) row2.Y = value;
                    else if (column == 2) row2.Z = value;
                    else if (column == 3) row2.W = value;
                    else throw new ArgumentOutOfRangeException(nameof(column));
                }
                else if (row == 2)
                {
                    if (column == 0) row3.X = value;
                    else if (column == 1) row3.Y = value;
                    else if (column == 2) row3.Z = value;
                    else if (column == 3) row3.W = value;
                    else throw new ArgumentOutOfRangeException(nameof(column));
                }
                else if (row == 3)
                {
                    if (column == 0) row4.X = value;
                    else if (column == 1) row4.Y = value;
                    else if (column == 2) row4.Z = value;
                    else if (column == 3) row4.W = value;
                    else throw new ArgumentOutOfRangeException(nameof(column));
                }
                else throw new ArgumentOutOfRangeException(nameof(row));
            }
        }

        public static bool operator ==(in Matrix4 m1, in Matrix4 m2)
        {
            return (m1.row1 == m2.row1 && m1.row2 == m2.row2 && m1.row3 == m2.row3 && m1.row4 == m2.row4);
        }

        public static bool operator !=(in Matrix4 m1, in Matrix4 m2)
        {
            return !(m1 == m2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix4)) return false;

            return this.Equals((Matrix4)obj);
        }

        public bool Equals(Matrix4 other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "[ " + row1.ToString() + " ] [ " + row2.ToString() + " ] [ " + row3.ToString() + " ] [ " + row4.ToString() + " ]";
        }
        #endregion

        #region Constructors
        public Matrix4(Matrix4 existingMatrix)
        {
            row1 = existingMatrix[0];
            row2 = existingMatrix[1];
            row3 = existingMatrix[2];
            row4 = existingMatrix[3];
        }

        public Matrix4(Vector4 v0, Vector4 v1, Vector4 v2, Vector4 v3)
        {
            row1 = v0;
            row2 = v1;
            row3 = v2;
            row4 = v3;
        }

        public Matrix4(float[] array)
        {
            row1 = new Vector4(array[0], array[1], array[2], array[3]);
            row2 = new Vector4(array[4], array[5], array[6], array[7]);
            row3 = new Vector4(array[8], array[9], array[10], array[11]);
            row4 = new Vector4(array[12], array[13], array[14], array[15]);
        }

        public Matrix4(double[] array)
        {
            row1 = new Vector4((float)array[0], (float)array[1], (float)array[2], (float)array[3]);
            row2 = new Vector4((float)array[4], (float)array[5], (float)array[6], (float)array[7]);
            row3 = new Vector4((float)array[8], (float)array[9], (float)array[10], (float)array[11]);
            row4 = new Vector4((float)array[12], (float)array[13], (float)array[14], (float)array[15]);
        }

        public void SetMatrix(Vector4 v0, Vector4 v1, Vector4 v2, Vector4 v3)
        {
            row1 = v0;
            row2 = v1;
            row3 = v2;
            row4 = v3;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates a matrix which contains information on how to translate.
        /// </summary>
        /// <param name="translation">Amount to translate by in the x, y and z direction.</param>
        /// <returns>A Matrix4 object that contains the translation matrix.</returns>
        public static Matrix4 CreateTranslation(Vector3 translation)
        {
            Matrix4 result = Matrix4.Identity;
            result[3] = new Vector4(translation, 1.0f);
            return result;
        }

        /// <summary>
        /// Creates a matrix which contains information on how to rotate about the X axis.
        /// </summary>
        /// <param name="angle">Amount to rotate in radians (counter-clockwise).</param>
        /// <returns>A Matrix4 object that contains the rotation matrix.</returns>
        public static Matrix4 CreateRotationX(float angle)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            return new Matrix4(Vector4.UnitX, new Vector4(0.0f, cos, sin, 0.0f), new Vector4(0.0f, -sin, cos, 0.0f), Vector4.UnitW);
        }

        /// <summary>
        /// Creates a matrix which contains information on how to rotate about the Y axis.
        /// </summary>
        /// <param name="angle">Amount to rotate in radians (counter-clockwise).</param>
        /// <returns>A Matrix4 object that contains the rotation matrix.</returns>
        public static Matrix4 CreateRotationY(float angle)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            return new Matrix4(new Vector4(cos, 0.0f, -sin, 0.0f), Vector4.UnitY, new Vector4(sin, 0.0f, cos, 0.0f), Vector4.UnitW);
        }

        /// <summary>
        /// Creates a matrix which contains information on how to rotate about the Z axis.
        /// </summary>
        /// <param name="angle">Amount to rotate in radians (counter-clockwise).</param>
        /// <returns>A Matrix4 object that contains the rotation matrix.</returns>
        public static Matrix4 CreateRotationZ(float angle)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            return new Matrix4(new Vector4(cos, sin, 0.0f, 0.0f), new Vector4(-sin, cos, 0.0f, 0.0f), Vector4.UnitZ, Vector4.UnitW);
        }

        /// <summary>
        /// Create a rotation matrix about an arbitrary axis.
        /// </summary>
        /// <param name="axis">Arbitrary axis for rotation.</param>
        /// <param name="angle">Amount to rotate in radians.</param>
        /// <returns>A Matrix4 object that contains the rotation matrix.</returns>
        public static Matrix4 CreateRotation(Vector3 axis, float angle)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);
            float tan = 1.0f - cos;
            return new Matrix4(new Vector4(tan * axis.X * axis.X + cos,
                    tan * axis.X * axis.Y - sin * axis.Z,
                    tan * axis.X * axis.Z + sin * axis.Y, 0.0f),
                new Vector4(tan * axis.Y * axis.X + sin * axis.Z,
                    tan * axis.Y * axis.Y + cos,
                    tan * axis.Y * axis.Z - sin * axis.X, 0.0f),
                new Vector4(tan * axis.Z * axis.X - sin * axis.Y,
                    tan * axis.Z * axis.Y + sin * axis.X,
                    tan * axis.Z * axis.Z + cos, 0.0f),
                new Vector4(0.0f, 0.0f, 0.0f, 1.0f));
        }

        /// <summary>
        /// Build a rotation matrix from the specified axis/angle rotation.
        /// </summary>
        /// <param name="axis">The axis to rotate about.</param>
        /// <param name="angle">Angle in radians to rotate counter-clockwise (looking in the direction of the given axis).</param>
        public static Matrix4 CreateFromAxisAngle(Vector3 axis, float angle)
        {
            float cos = (float)Math.Cos(-angle);
            float sin = (float)Math.Sin(-angle);
            float t = 1.0f - cos;

            axis.Normalize();

            return new Matrix4(new Vector4(t * axis.X * axis.X + cos, t * axis.X * axis.Y - sin * axis.Z, t * axis.X * axis.Z + sin * axis.Y, 0.0f),
                                 new Vector4(t * axis.X * axis.Y + sin * axis.Z, t * axis.Y * axis.Y + cos, t * axis.Y * axis.Z - sin * axis.X, 0.0f),
                                 new Vector4(t * axis.X * axis.Z - sin * axis.Y, t * axis.Y * axis.Z + sin * axis.X, t * axis.Z * axis.Z + cos, 0.0f),
                                 Vector4.UnitW);
        }

        /// <summary>
        /// Creates a matrix which contains information on how to scale.
        /// </summary>
        /// <param name="scale">Amount to scale by in the x, y and z direction.</param>
        /// <returns>A Matrix4 object that contains the scaling matrix.</returns>
        public static Matrix4 CreateScaling(Vector3 scale)
        {
            return new Matrix4(new Vector4(scale.X, 0.0f, 0.0f, 0.0f), new Vector4(0.0f, scale.Y, 0.0f, 0.0f), new Vector4(0.0f, 0.0f, scale.Z, 0.0f), new Vector4(0.0f, 0.0f, 0.0f, 1.0f));
        }

        /// <summary>
        /// Creates an orthographic projection matrix.
        /// </summary>
        /// <param name="width">The width of the projection volume.</param>
        /// <param name="height">The height of the projection volume.</param>
        /// <param name="zNear">The near edge of the projection volume.</param>
        /// <param name="zFar">The far edge of the projection volume.</param>
        /// <rereturns>The resulting Matrix4 instance.</rereturns>
        public static Matrix4 CreateOrthographic(float width, float height, float zNear, float zFar)
        {
            return CreateOrthographicOffCenter(-width / 2, width / 2, -height / 2, height / 2, zNear, zFar);
        }

        /// <summary>
        /// Creates an orthographic projection matrix.
        /// </summary>
        /// <param name="left">The left edge of the projection volume.</param>
        /// <param name="right">The right edge of the projection volume.</param>
        /// <param name="bottom">The bottom edge of the projection volume.</param>
        /// <param name="top">The top edge of the projection volume.</param>
        /// <param name="zNear">The near edge of the projection volume.</param>
        /// <param name="zFar">The far edge of the projection volume.</param>
        public static Matrix4 CreateOrthographicOffCenter(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            float invRL = 1 / (right - left);
            float invTB = 1 / (top - bottom);
            float invFN = 1 / (zFar - zNear);

            return new Matrix4(new Vector4(2 * invRL, 0, 0, 0), new Vector4(0, 2 * invTB, 0, 0), new Vector4(0, 0, -2 * invFN, 0),
                new Vector4(-(right + left) * invRL, -(top + bottom) * invTB, -(zFar + zNear) * invFN, 1));
        }

        /// <summary>
        /// Creates a perspective projection matrix.
        /// </summary>
        /// <param name="fovy">Angle of the field of view in the y direction (in radians).</param>
        /// <param name="aspect">Aspect ratio of the view (width / height).</param>
        /// <param name="zNear">Distance to the near clip plane.</param>
        /// <param name="zFar">Distance to the far clip plane.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown under the following conditions:
        /// <list type="bullet">
        /// <item>fovy is zero, less than zero or larger than Math.PI.</item>
        /// <item>aspect is negative or zero.</item>
        /// <item>zNear is negative or zero.</item>
        /// <item>zFar is negative or zero.</item>
        /// <item>zNear is larger than zFar.</item>
        /// </list>
        /// </exception>
        public static Matrix4 CreatePerspectiveFieldOfView(float fovy, float aspect, float zNear, float zFar)
        {
            if (fovy <= 0 || fovy > Math.PI)
                throw new ArgumentOutOfRangeException("fovy");
            if (aspect <= 0)
                throw new ArgumentOutOfRangeException("aspect");

            float yMax = zNear * (float)System.Math.Tan(0.5f * fovy);
            float yMin = -yMax;
            float xMin = yMin * aspect;
            float xMax = yMax * aspect;

            return CreatePerspectiveOffCenter(xMin, xMax, yMin, yMax, zNear, zFar);
        }

        /// <summary>
        /// Creates a perspective projection matrix.
        /// </summary>
        /// <param name="left">Left edge of the view frustum.</param>
        /// <param name="right">Right edge of the view frustum.</param>
        /// <param name="bottom">Bottom edge of the view frustum.</param>
        /// <param name="top">Top edge of the view frustum.</param>
        /// <param name="zNear">Distance to the near clip plane.</param>
        /// <param name="zFar">Distance to the far clip plane.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown under the following conditions:
        /// <list type="bullet">
        /// <item>zNear is negative or zero.</item>
        /// <item>zFar is negative or zero.</item>
        /// <item>zNear is larger than zFar.</item>
        /// </list>
        /// </exception>
        public static Matrix4 CreatePerspectiveOffCenter(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            if (zNear <= 0)
                throw new ArgumentOutOfRangeException("zNear");
            if (zFar <= 0)
                throw new ArgumentOutOfRangeException("zFar");
            if (zNear >= zFar)
                throw new ArgumentOutOfRangeException("zNear");

            float x = (2.0f * zNear) / (right - left);
            float y = (2.0f * zNear) / (top - bottom);
            float a = (right + left) / (right - left);
            float b = (top + bottom) / (top - bottom);
            float c = -(zFar + zNear) / (zFar - zNear);
            float d = -(2.0f * zFar * zNear) / (zFar - zNear);

            return new Matrix4(new Vector4(x, 0, 0, 0), new Vector4(0, y, 0, 0), new Vector4(a, b, c, -1), new Vector4(0, 0, d, 0));
        }

        /// <summary>
        /// Build a world space to camera space matrix.
        /// </summary>
        /// <param name="eye">Eye (camera) position in world space.</param>
        /// <param name="target">Target position in world space.</param>
        /// <param name="up">Up vector in world space (should not be parallel to the camera direction, that is target - eye).</param>
        /// <returns>A Matrix4 that transforms world space to camera space.</returns>
        public static Matrix4 LookAt(Vector3 eye, Vector3 target, Vector3 up)
        {
            Vector3 z = (eye - target).Normalize();
            Vector3 x = Vector3.Cross(up, z).Normalize();
            Vector3 y = Vector3.Cross(z, x).Normalize();

            Matrix4 matrix = new Matrix4(new Vector4(x.X, y.X, z.X, 0.0f),
                                        new Vector4(x.Y, y.Y, z.Y, 0.0f),
                                        new Vector4(x.Z, y.Z, z.Z, 0.0f),
                                        Vector4.UnitW);

            return Matrix4.CreateTranslation(-eye) * matrix;
        }

        /// <summary>
        /// Creates the transpose of the current matrix.
        /// </summary>
        /// <returns>A Matrix4 object that contains the transposed matrix.</returns>
        public Matrix4 Transpose()
        {
            return new Matrix4(
                new Vector4(row1.X, row2.X, row3.X, row4.X),
                new Vector4(row1.Y, row2.Y, row3.Y, row4.Y),
                new Vector4(row1.Z, row2.Z, row3.Z, row4.Z),
                new Vector4(row1.W, row2.W, row3.W, row4.W));
        }

        /// <summary>
        /// Creates the inverse matrix using Gauss-Jordan elimination with partial pivoting.
        /// </summary>
        /// <returns>A Matrix4 object that contains the inversed matrix.</returns>
        public Matrix4 Inverse()
        {
            Matrix4 original = new Matrix4(this);
            Matrix4 identity = Matrix4.Identity;
            int k;

            // loop over columns from left to right eliminating above and below diagonal
            for (int j = 0; j < 4; j++)
            {
                k = j;    // row with largest pivot cadence
                for (int i = j + 1; i < 4; i++)
                    if (Math.Abs(original[i].Get(j)) > Math.Abs(original[k].Get(j))) k = i;

                original.SwapRows(k, j);
                identity.SwapRows(k, j);

                if (original[j].Get(j) == 0.0f) 
                    throw new Exception("Matrix4 was a singular matrix and cannot be inverted.");

                identity[j] /= original[j].Get(j);
                original[j] /= original[j].Get(j);

                for (int i = 0; i < 4; i++)
                {
                    if (i != j)
                    {
                        identity[i] -= original[i].Get(j) * identity[j];
                        original[i] -= original[i].Get(j) * original[j];
                    }
                }
            }
            return identity;
        }

        /// <summary>
        /// Swaps two rows in the Matrix4 object.
        /// </summary>
        /// <param name="i">First row to switch.</param>
        /// <param name="j">Second row to switch.</param>
        public void SwapRows(int i, int j)
        {
            Vector4 temp = this[i];
            this[i] = this[j];
            this[j] = temp;
        }

        /// <summary>
        /// Returns a floating array that represents the Matrix4.
        /// </summary>
        /// <returns>Floating array that represents that Matrix4.</returns>
        public float[] ToFloat()
        {
            float[] elements = new float[16];
            row1.CopyTo(elements, 0);
            row2.CopyTo(elements, 4);
            row3.CopyTo(elements, 8);
            row4.CopyTo(elements, 12);
            return elements;
        }

        /// <summary>
        /// Build a rotation matrix from a quaternion.
        /// </summary>
        /// <param name="rotation">A quaternion representation of the rotation.</param>
        /// <returns>A rotation matrix.</returns>
        public static Matrix4 Rotate(Quaternion rotation)
        {
            Vector4 axisangle = rotation.ToAxisAngle();
            return CreateFromAxisAngle(new Vector3(axisangle.X, axisangle.Y, axisangle.Z), rotation.W);
        }
        #endregion
    }
}
