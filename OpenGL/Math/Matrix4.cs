using System;
using System.Runtime.InteropServices;

namespace OpenGL
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix4 : IEquatable<Matrix4>
    {
        private Vector4 row1, row2, row3, row4;

        [System.Obsolete("This property no longer has the same functionality, and should be modified to this[].  This property will be removed in a future build.", false)]
        public Vector4[] Matrix
        {
            get { return new Vector4[] { row1, row2, row3, row4 }; }
        }

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
            Matrix4 r = new Matrix4(
            new Vector4(m[0].x * m2[0].x + m[0].y * m2[1].x + m[0].z * m2[2].x + m[0].w * m2[3].x,
                m[0].x * m2[0].y + m[0].y * m2[1].y + m[0].z * m2[2].y + m[0].w * m2[3].y,
                m[0].x * m2[0].z + m[0].y * m2[1].z + m[0].z * m2[2].z + m[0].w * m2[3].z,
                m[0].x * m2[0].w + m[0].y * m2[1].w + m[0].z * m2[2].w + m[0].w * m2[3].w),
            new Vector4(m[1].x * m2[0].x + m[1].y * m2[1].x + m[1].z * m2[2].x + m[1].w * m2[3].x,
                m[1].x * m2[0].y + m[1].y * m2[1].y + m[1].z * m2[2].y + m[1].w * m2[3].y,
                m[1].x * m2[0].z + m[1].y * m2[1].z + m[1].z * m2[2].z + m[1].w * m2[3].z,
                m[1].x * m2[0].w + m[1].y * m2[1].w + m[1].z * m2[2].w + m[1].w * m2[3].w),
            new Vector4(m[2].x * m2[0].x + m[2].y * m2[1].x + m[2].z * m2[2].x + m[2].w * m2[3].x,
                m[2].x * m2[0].y + m[2].y * m2[1].y + m[2].z * m2[2].y + m[2].w * m2[3].y,
                m[2].x * m2[0].z + m[2].y * m2[1].z + m[2].z * m2[2].z + m[2].w * m2[3].z,
                m[2].x * m2[0].w + m[2].y * m2[1].w + m[2].z * m2[2].w + m[2].w * m2[3].w),
            new Vector4(m[3].x * m2[0].x + m[3].y * m2[1].x + m[3].z * m2[2].x + m[3].w * m2[3].x,
                m[3].x * m2[0].y + m[3].y * m2[1].y + m[3].z * m2[2].y + m[3].w * m2[3].y,
                m[3].x * m2[0].z + m[3].y * m2[1].z + m[3].z * m2[2].z + m[3].w * m2[3].z,
                m[3].x * m2[0].w + m[3].y * m2[1].w + m[3].z * m2[2].w + m[3].w * m2[3].w));
            return r;
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
            return new Vector3(m1[0].x * v.x + m1[0].y * v.y + m1[0].z * v.z,
                m1[1].x * v.x + m1[1].y * v.y + m1[1].z * v.z,
                m1[2].x * v.x + m1[2].y * v.y + m1[2].z * v.z);
        }

        public static Vector3 operator *(Vector3 v, Matrix4 m1)
        {
            return new Vector3(v.x * m1[0].x + v.y * m1[1].x + v.z * m1[2].x,
                v.x * m1[0].y + v.y * m1[1].y + v.z * m1[2].y,
                v.x * m1[0].z + v.y * m1[1].z + v.z * m1[2].z);
        }

        public static Vector4 operator *(Matrix4 m1, Vector4 v)
        {
            return new Vector4(m1[0].x * v.x + m1[0].y * v.y + m1[0].z * v.z + m1[0].w * v.w,
                m1[1].x * v.x + m1[1].y * v.y + m1[1].z * v.z + m1[1].w * v.w,
                m1[2].x * v.x + m1[2].y * v.y + m1[2].z * v.z + m1[2].w * v.w,
                m1[3].x * v.x + m1[3].y * v.y + m1[3].z * v.z + m1[3].w * v.w);
        }

        public static Vector4 operator *(Vector4 v, Matrix4 m1)
        {
            return new Vector4(v.x * m1[0].x + v.y * m1[1].x + v.z * m1[2].x + v.w * m1[3].x,
                v.x * m1[0].y + v.y * m1[1].y + v.z * m1[2].y + v.w * m1[3].y,
                v.x * m1[0].z + v.y * m1[1].z + v.z * m1[2].z + v.w * m1[3].z,
                v.x * m1[0].w + v.y * m1[1].w + v.z * m1[2].w + v.w * m1[3].w);
        }

        public Vector4 this[int a]
        {
            get
            {
                if (a > 3 || a < 0) return Vector4.Zero;
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

        public static bool operator ==(Matrix4 m1, Matrix4 m2)
        {
            return (m1[0] == m2[0] && m1[1] == m2[1] && m1[2] == m2[2] && m1[3] == m2[3]);
        }

        public static bool operator !=(Matrix4 m1, Matrix4 m2)
        {
            return (m1[0] != m2[0] || m1[1] != m2[1] || m1[2] != m2[2] || m1[3] != m2[3]);
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
            row1 = new Vector4(array[0], array[1], array[2], array[3]);
            row2 = new Vector4(array[4], array[5], array[6], array[7]);
            row3 = new Vector4(array[8], array[9], array[10], array[11]);
            row4 = new Vector4(array[12], array[13], array[14], array[15]);
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
            return new Matrix4(new Vector4(tan * axis.x * axis.x + cos,
                    tan * axis.x * axis.y - sin * axis.z,
                    tan * axis.x * axis.z + sin * axis.y, 0.0f),
                new Vector4(tan * axis.y * axis.x + sin * axis.z,
                    tan * axis.y * axis.y + cos,
                    tan * axis.y * axis.z - sin * axis.x, 0.0f),
                new Vector4(tan * axis.z * axis.x - sin * axis.y,
                    tan * axis.z * axis.y + sin * axis.x,
                    tan * axis.z * axis.z + cos, 0.0f),
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

            return new Matrix4(new Vector4(t * axis.x * axis.x + cos, t * axis.x * axis.y - sin * axis.z, t * axis.x * axis.z + sin * axis.y, 0.0f),
                                 new Vector4(t * axis.x * axis.y + sin * axis.z, t * axis.y * axis.y + cos, t * axis.y * axis.z - sin * axis.x, 0.0f),
                                 new Vector4(t * axis.x * axis.z - sin * axis.y, t * axis.y * axis.z + sin * axis.x, t * axis.z * axis.z + cos, 0.0f),
                                 Vector4.UnitW);
        }

        /// <summary>Creates a matrix which contains information on how to scale</summary>
        /// <param name="scale">Amount to scale by in the x, y and z direction</param>
        /// <returns>A Matrix4 object that contains the scaling matrix</returns>
        public static Matrix4 CreateScaling(Vector3 scale)
        {
            return new Matrix4(new Vector4(scale.x, 0.0f, 0.0f, 0.0f), new Vector4(0.0f, scale.y, 0.0f, 0.0f), new Vector4(0.0f, 0.0f, scale.z, 0.0f), new Vector4(0.0f, 0.0f, 0.0f, 1.0f));
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
        /// <param name="fovy">Angle of the field of view in the y direction (in radians)</param>
        /// <param name="aspect">Aspect ratio of the view (width / height)</param>
        /// <param name="zNear">Distance to the near clip plane</param>
        /// <param name="zFar">Distance to the far clip plane</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown under the following conditions:
        /// <list type="bullet">
        /// <item>fovy is zero, less than zero or larger than Math.PI</item>
        /// <item>aspect is negative or zero</item>
        /// <item>zNear is negative or zero</item>
        /// <item>zFar is negative or zero</item>
        /// <item>zNear is larger than zFar</item>
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
        /// <param name="left">Left edge of the view frustum</param>
        /// <param name="right">Right edge of the view frustum</param>
        /// <param name="bottom">Bottom edge of the view frustum</param>
        /// <param name="top">Top edge of the view frustum</param>
        /// <param name="zNear">Distance to the near clip plane</param>
        /// <param name="zFar">Distance to the far clip plane</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown under the following conditions:
        /// <list type="bullet">
        /// <item>zNear is negative or zero</item>
        /// <item>zFar is negative or zero</item>
        /// <item>zNear is larger than zFar</item>
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
        /// <param name="eye">Eye (camera) position in world space</param>
        /// <param name="target">Target position in world space</param>
        /// <param name="up">Up vector in world space (should not be parallel to the camera direction, that is target - eye)</param>
        /// <returns>A Matrix4 that transforms world space to camera space</returns>
        public static Matrix4 LookAt(Vector3 eye, Vector3 target, Vector3 up)
        {
            Vector3 z = (eye - target).Normalize();
            Vector3 x = Vector3.Cross(up, z).Normalize();
            Vector3 y = Vector3.Cross(z, x).Normalize();

            Matrix4 matrix = new Matrix4(new Vector4(x.x, y.x, z.x, 0.0f),
                                        new Vector4(x.y, y.y, z.y, 0.0f),
                                        new Vector4(x.z, y.z, z.z, 0.0f),
                                        Vector4.UnitW);

            return Matrix4.CreateTranslation(-eye) * matrix;
        }

        /// <summary>
        /// Creates the transpose of the current matrix.
        /// </summary>
        /// <returns>A Matrix4 object that contains the transposed matrix</returns>
        public Matrix4 Transpose()
        {
            return new Matrix4(new Vector4(this[0].x, this[1].x, this[2].x, this[3].x),
                new Vector4(this[0].y, this[1].y, this[2].y, this[3].y),
                new Vector4(this[0].z, this[1].z, this[2].z, this[3].z),
                new Vector4(this[0].w, this[1].w, this[2].w, this[3].w));
        }

        /// <summary>
        /// Creates the inverse matrix using Gauss-Jordan elimination with partial pivoting.
        /// </summary>
        /// <returns>A Matrix4 object that contains the inversed matrix</returns>
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
                    if (Math.Abs(original[i][j]) > Math.Abs(original[k][j])) k = i;

                original.SwapRows(k, j);
                identity.SwapRows(k, j);
                //Vector4.Swap(ref original[k], ref original[j]);
                //Vector4.Swap(ref identity[k], ref identity[j]);

                if (original[j][j] == 0.0f) 
                    throw new Exception("Matrix4 was a singular matrix and cannot be inverted.");

                identity[j] /= original[j][j];
                original[j] /= original[j][j];

                for (int i = 0; i < 4; i++)
                {
                    if (i != j)
                    {
                        identity[i] -= original[i][j] * identity[j];
                        original[i] -= original[i][j] * original[j];
                    }
                }
            }
            return identity;
        }

        /// <summary>
        /// Swaps two rows in the Matrix4 object.
        /// </summary>
        /// <param name="i">First row to switch</param>
        /// <param name="j">Second row to switch</param>
        public void SwapRows(int i, int j)
        {
            Vector4 temp = this[i];
            this[i] = this[j];
            this[j] = temp;
        }

        /// <summary>
        /// Swaps two columns in the Matrix4 object.
        /// </summary>
        /// <param name="i">First column to switch</param>
        /// <param name="j">Second column to switch</param>
        /*public void SwapCols(int i, int j)
        {
            // TODO: This does not work with the new Matrix4 format
            float temp;
            for (int k = 0; k < 4; k++)
            {
                temp = Matrix[k][i];
                Matrix[k][i] = Matrix[k][j];
                Matrix[k][j] = temp;
            }
        }*/

        /// <summary>
        /// Returns a floating array that represents the Matrix4.
        /// </summary>
        /// <returns>Floating array that represents that Matrix4</returns>
        public float[] ToFloat()
        {
            return new float[] { this[0].x, this[0].y, this[0].z, this[0].w, this[1].x, this[1].y, this[1].z, this[1].w,
                this[2].x, this[2].y, this[2].z, this[2].w, this[3].x, this[3].y, this[3].z, this[3].w };
        }

        /// <summary>
        /// Build a rotation matrix from a quaternion
        /// </summary>
        /// <param name="rotation">A quaternion representation of the rotation.</param>
        /// <returns>A rotation matrix</returns>
        public static Matrix4 Rotate(Quaternion rotation)
        {
            Vector4 axisangle = rotation.ToAxisAngle();
            return CreateFromAxisAngle(axisangle.Xyz, rotation.w);
        }
        #endregion
    }
}
