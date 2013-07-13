using System;
using System.Runtime.InteropServices;

namespace OpenGL
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix4 : IEquatable<Matrix4>
    {
        public Vector4[] Matrix;

        #region Static Constructors
        public static Matrix4 Identity
        {
            get { return new Matrix4(Vector4.UnitX, Vector4.UnitY, Vector4.UnitZ, Vector4.UnitW); }
        }
        #endregion

        #region Operators
        public static Matrix4 operator +(Matrix4 m1, Matrix4 m2)
        {
            return new Matrix4(m1.Matrix[0] + m2.Matrix[0], m1.Matrix[1] + m2.Matrix[1], m1.Matrix[2] + m2.Matrix[2], m1.Matrix[3] + m2.Matrix[3]);
        }

        public static Matrix4 operator -(Matrix4 m1, Matrix4 m2)
        {
            return new Matrix4(m1.Matrix[0] - m2.Matrix[0], m1.Matrix[1] - m2.Matrix[1], m1.Matrix[2] - m2.Matrix[2], m1.Matrix[3] - m2.Matrix[3]);
        }

        public static Matrix4 operator *(Matrix4 m, Matrix4 m2)
        {
            Matrix4 r = new Matrix4(
            new Vector4(m[0][0] * m2[0][0] + m[0][1] * m2[1][0] + m[0][2] * m2[2][0] + m[0][3] * m2[3][0],
                m[0][0] * m2[0][1] + m[0][1] * m2[1][1] + m[0][2] * m2[2][1] + m[0][3] * m2[3][1],
                m[0][0] * m2[0][2] + m[0][1] * m2[1][2] + m[0][2] * m2[2][2] + m[0][3] * m2[3][2],
                m[0][0] * m2[0][3] + m[0][1] * m2[1][3] + m[0][2] * m2[2][3] + m[0][3] * m2[3][3]),
            new Vector4(m[1][0] * m2[0][0] + m[1][1] * m2[1][0] + m[1][2] * m2[2][0] + m[1][3] * m2[3][0],
                m[1][0] * m2[0][1] + m[1][1] * m2[1][1] + m[1][2] * m2[2][1] + m[1][3] * m2[3][1],
                m[1][0] * m2[0][2] + m[1][1] * m2[1][2] + m[1][2] * m2[2][2] + m[1][3] * m2[3][2],
                m[1][0] * m2[0][3] + m[1][1] * m2[1][3] + m[1][2] * m2[2][3] + m[1][3] * m2[3][3]),
            new Vector4(m[2][0] * m2[0][0] + m[2][1] * m2[1][0] + m[2][2] * m2[2][0] + m[2][3] * m2[3][0],
                m[2][0] * m2[0][1] + m[2][1] * m2[1][1] + m[2][2] * m2[2][1] + m[2][3] * m2[3][1],
                m[2][0] * m2[0][2] + m[2][1] * m2[1][2] + m[2][2] * m2[2][2] + m[2][3] * m2[3][2],
                m[2][0] * m2[0][3] + m[2][1] * m2[1][3] + m[2][2] * m2[2][3] + m[2][3] * m2[3][3]),
            new Vector4(m[3][0] * m2[0][0] + m[3][1] * m2[1][0] + m[3][2] * m2[2][0] + m[3][3] * m2[3][0],
                m[3][0] * m2[0][1] + m[3][1] * m2[1][1] + m[3][2] * m2[2][1] + m[3][3] * m2[3][1],
                m[3][0] * m2[0][2] + m[3][1] * m2[1][2] + m[3][2] * m2[2][2] + m[3][3] * m2[3][2],
                m[3][0] * m2[0][3] + m[3][1] * m2[1][3] + m[3][2] * m2[2][3] + m[3][3] * m2[3][3]));
            return r;
        }

        public static Matrix4 operator *(Matrix4 m1, float d)
        {
            return new Matrix4(m1.Matrix[0] * d, m1.Matrix[1] * d, m1.Matrix[2] * d, m1.Matrix[3] * d);
        }

        public static Matrix4 operator /(Matrix4 m1, float d)
        {
            return new Matrix4(m1.Matrix[0] / d, m1.Matrix[1] / d, m1.Matrix[2] / d, m1.Matrix[3] / d);
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
                return Matrix[a];
            }
            set
            {
                if (a > 3 || a < 0) return;
                Matrix[a] = value;
            }
        }

        public static bool operator ==(Matrix4 m1, Matrix4 m2)
        {
            return (m1.Matrix[0] == m2.Matrix[0] && m1.Matrix[1] == m2.Matrix[1] && m1.Matrix[2] == m2.Matrix[2] && m1.Matrix[3] == m2.Matrix[3]);
        }

        public static bool operator !=(Matrix4 m1, Matrix4 m2)
        {
            return (m1.Matrix[0] != m2.Matrix[0] || m1.Matrix[1] != m2.Matrix[1] || m1.Matrix[2] != m2.Matrix[2] || m1.Matrix[3] != m2.Matrix[3]);
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
            return "[ " + Matrix[0].ToString() + " ] [ " + Matrix[1].ToString() + " ] [ " + Matrix[2].ToString() + " ] [ " + Matrix[3].ToString() + " ]";
        }
        #endregion

        #region Constructors
        public Matrix4(Matrix4 ExistingMatrix)
        {
            this.Matrix = new Vector4[] { ExistingMatrix[0], ExistingMatrix[1], ExistingMatrix[2], ExistingMatrix[3] };
        }

        public Matrix4(Vector4 v0, Vector4 v1, Vector4 v2, Vector4 v3)
        {
            Matrix = new Vector4[4];
            SetMatrix(v0, v1, v2, v3);
        }

        public Matrix4(float[] Array)
        {
            Matrix = new Vector4[4];
            SetMatrix(new Vector4(Array[0], Array[1], Array[2], Array[3]), new Vector4(Array[4], Array[5], Array[6], Array[7]),
                new Vector4(Array[8], Array[9], Array[10], Array[11]), new Vector4(Array[12], Array[13], Array[14], Array[15]));
        }

        public Matrix4(double[] Array)
        {
            Matrix = new Vector4[4];
            SetMatrix(new Vector4(Array[0], Array[1], Array[2], Array[3]), new Vector4(Array[4], Array[5], Array[6], Array[7]),
                new Vector4(Array[8], Array[9], Array[10], Array[11]), new Vector4(Array[12], Array[13], Array[14], Array[15]));
        }

        /*public Matrix4(Matrix3 ExistingMatrix, Vector3 Translation)
        {
            Matrix = new Vector4[4];
            SetMatrix(new Vector4(ExistingMatrix[0].x, ExistingMatrix[0].y, ExistingMatrix[0].z, 0.0f),
                new Vector4(ExistingMatrix[1].x, ExistingMatrix[1].y, ExistingMatrix[1].z, 0.0f),
                new Vector4(ExistingMatrix[2].x, ExistingMatrix[2].y, ExistingMatrix[2].z, 0.0f),
                new Vector4(Translation.x, Translation.y, Translation.z, 1.0f));
        }

        public Matrix4(Matrix3 ExistingMatrix)
        {
            Matrix = new Vector4[4];
            SetMatrix(new Vector4(ExistingMatrix[0].x, ExistingMatrix[0].y, ExistingMatrix[0].z, 0.0f),
                new Vector4(ExistingMatrix[1].x, ExistingMatrix[1].y, ExistingMatrix[1].z, 0.0f),
                new Vector4(ExistingMatrix[2].x, ExistingMatrix[2].y, ExistingMatrix[2].z, 0.0f),
                new Vector4(0.0f, 0.0f, 0.0f, 1.0f));
        }*/

        public void SetMatrix(Vector4 v0, Vector4 v1, Vector4 v2, Vector4 v3)
        {
            Matrix[0] = v0;
            Matrix[1] = v1;
            Matrix[2] = v2;
            Matrix[3] = v3;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates a matrix which contains information on how to translate.
        /// </summary>
        /// <param name="Translation">Amount to translate by in the x, y and z direction.</param>
        /// <returns>A Matrix4 object that contains the translation matrix.</returns>
        public static Matrix4 CreateTranslation(Vector3 Translation)
        {
            Matrix4 result = Matrix4.Identity;
            result[3] = new Vector4(Translation, 1.0f);
            return result;
        }

        /// <summary>
        /// Creates a matrix which contains information on how to rotate about the X axis.
        /// </summary>
        /// <param name="Angle">Amount to rotate in radians (counter-clockwise).</param>
        /// <returns>A Matrix4 object that contains the rotation matrix.</returns>
        public static Matrix4 CreateRotationX(float Angle)
        {
            float cos = (float)Math.Cos(Angle);
            float sin = (float)Math.Sin(Angle);

            return new Matrix4(Vector4.UnitX, new Vector4(0.0f, cos, sin, 0.0f), new Vector4(0.0f, -sin, cos, 0.0f), Vector4.UnitW);
        }

        /// <summary>
        /// Creates a matrix which contains information on how to rotate about the Y axis.
        /// </summary>
        /// <param name="Angle">Amount to rotate in radians (counter-clockwise).</param>
        /// <returns>A Matrix4 object that contains the rotation matrix.</returns>
        public static Matrix4 CreateRotationY(float Angle)
        {
            float cos = (float)Math.Cos(Angle);
            float sin = (float)Math.Sin(Angle);

            return new Matrix4(new Vector4(cos, 0.0f, -sin, 0.0f), Vector4.UnitY, new Vector4(sin, 0.0f, cos, 0.0f), Vector4.UnitW);
        }

        /// <summary>
        /// Creates a matrix which contains information on how to rotate about the Z axis.
        /// </summary>
        /// <param name="Angle">Amount to rotate in radians (counter-clockwise).</param>
        /// <returns>A Matrix4 object that contains the rotation matrix.</returns>
        public static Matrix4 CreateRotationZ(float Angle)
        {
            float cos = (float)Math.Cos(Angle);
            float sin = (float)Math.Sin(Angle);

            return new Matrix4(new Vector4(cos, sin, 0.0f, 0.0f), new Vector4(-sin, cos, 0.0f, 0.0f), Vector4.UnitZ, Vector4.UnitW);
        }

        /// <summary>
        /// Create a rotation matrix about an arbitrary axis.
        /// </summary>
        /// <param name="Axis">Arbitrary axis for rotation.</param>
        /// <param name="Angle">Amount to rotate in radians.</param>
        /// <returns>A Matrix4 object that contains the rotation matrix.</returns>
        public static Matrix4 CreateRotation(Vector3 Axis, float Angle)
        {
            float cos = (float)Math.Cos(Angle);
            float sin = (float)Math.Sin(Angle);
            float tan = 1.0f - cos;
            return new Matrix4(new Vector4(tan * Axis.x * Axis.x + cos,
                    tan * Axis.x * Axis.y - sin * Axis.z,
                    tan * Axis.x * Axis.z + sin * Axis.y, 0.0f),
                new Vector4(tan * Axis.y * Axis.x + sin * Axis.z,
                    tan * Axis.y * Axis.y + cos,
                    tan * Axis.y * Axis.z - sin * Axis.x, 0.0f),
                new Vector4(tan * Axis.z * Axis.x - sin * Axis.y,
                    tan * Axis.z * Axis.y + sin * Axis.x,
                    tan * Axis.z * Axis.z + cos, 0.0f),
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
        /// <param name="Scale">Amount to scale by in the x, y and z direction</param>
        /// <returns>A Matrix4 object that contains the scaling matrix</returns>
        public static Matrix4 CreateScaling(Vector3 Scale)
        {
            return new Matrix4(new Vector4(Scale.x, 0.0f, 0.0f, 0.0f), new Vector4(0.0f, Scale.y, 0.0f, 0.0f), new Vector4(0.0f, 0.0f, Scale.z, 0.0f), new Vector4(0.0f, 0.0f, 0.0f, 1.0f));
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

            Matrix4 rot = new Matrix4(new Vector4(x.x, y.x, z.x, 0.0f),
                                        new Vector4(x.y, y.y, z.y, 0.0f),
                                        new Vector4(x.z, y.z, z.z, 0.0f),
                                        Vector4.UnitW);

            Matrix4 trans = Matrix4.CreateTranslation(-eye);

            return trans * rot;
        }

        /// <summary>
        /// Creates the transpose of the current matrix.
        /// </summary>
        /// <returns>A Matrix4 object that contains the transposed matrix</returns>
        public Matrix4 Transpose()
        {
            return new Matrix4(new Vector4(Matrix[0][0], Matrix[1][0], Matrix[2][0], Matrix[3][0]),
                new Vector4(Matrix[0][1], Matrix[1][1], Matrix[2][1], Matrix[3][1]),
                new Vector4(Matrix[0][2], Matrix[1][2], Matrix[2][2], Matrix[3][2]),
                new Vector4(Matrix[0][3], Matrix[1][3], Matrix[2][3], Matrix[3][3]));
        }

        /// <summary>
        /// Creates the inverse matrix using Gauss-Jordan elimination with partial pivoting.
        /// </summary>
        /// <returns>A Matrix4 object that contains the inversed matrix</returns>
        public Matrix4 Inverse()
        {
            Matrix4 original = new Matrix4(this);
            Matrix4 identity = Matrix4.Identity;
            int t_k;

            // loop over columns from left to right climinating above and below diagonal
            for (int j = 0; j < 4; j++)
            {
                t_k = j;    // row with largest pivot cadence
                for (int i = j + 1; i < 4; i++)
                    if (Math.Abs(original.Matrix[i][j]) > Math.Abs(original.Matrix[t_k][j])) t_k = i;

                Vector4.Swap(ref original.Matrix[t_k], ref original.Matrix[j]);
                Vector4.Swap(ref identity.Matrix[t_k], ref identity.Matrix[j]);

                if (original.Matrix[j][j] == 0.0f) throw new Exception("Matrix4 was a singular matrix and cannot be inverted.");
                //Logger.Instance.WriteLine(WarningLevel.Error, "Matrix4 was a singular matrix.  Cannot invert.");

                identity.Matrix[j] /= original.Matrix[j][j];
                original.Matrix[j] /= original.Matrix[j][j];

                for (int i = 0; i < 4; i++)
                {
                    if (i != j)
                    {
                        identity.Matrix[i] -= original.Matrix[i][j] * identity.Matrix[j];
                        original.Matrix[i] -= original.Matrix[i][j] * original.Matrix[j];
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
            Vector4 t_vec = Matrix[i];
            Matrix[i] = Matrix[j];
            Matrix[j] = t_vec;
        }

        /// <summary>
        /// Swaps two columns in the Matrix4 object.
        /// </summary>
        /// <param name="i">First column to switch</param>
        /// <param name="j">Second column to switch</param>
        public void SwapCols(int i, int j)
        {
            float t_float;
            for (int k = 0; k < 4; k++)
            {
                t_float = Matrix[k][i];
                Matrix[k][i] = Matrix[k][j];
                Matrix[k][j] = t_float;
            }
        }

        /// <summary>
        /// Returns a floating array that represents the Matrix4.
        /// </summary>
        /// <returns>Floating array that represents that Matrix4</returns>
        public float[] ToFloat()
        {
            return new float[] { Matrix[0].x, Matrix[0].y, Matrix[0].z, Matrix[0].w, Matrix[1].x, Matrix[1].y, Matrix[1].z, Matrix[1].w,
                Matrix[2].x, Matrix[2].y, Matrix[2].z, Matrix[2].w, Matrix[3].x, Matrix[3].y, Matrix[3].z, Matrix[3].w };
        }

        /// <summary>
        /// Build a rotation matrix from a quaternion
        /// </summary>
        /// <param name="q">the quaternion</param>
        /// <returns>A rotation matrix</returns>
        public static Matrix4 Rotate(Quaternion q)
        {
            Vector4 axisangle = q.ToAxisAngle();
            return CreateFromAxisAngle(axisangle.Xyz, q.w);
        }
        #endregion
    }
}
