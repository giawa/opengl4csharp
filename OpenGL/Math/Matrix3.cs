using System;
using System.Runtime.InteropServices;

#if USE_NUMERICS
using System.Numerics;
#endif

namespace OpenGL
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix3 : IEquatable<Matrix3>
    {
        private Vector3 row1, row2, row3;

        #region Static Constructors
        public static Matrix3 Identity
        {
            get { return new Matrix3(Vector3.UnitX, Vector3.UnitY, Vector3.UnitZ); }
        }
	    #endregion

        #region Operators
        public static Matrix3 operator +(Matrix3 m1, Matrix3 m2)
        {
            return new Matrix3(m1.row1 + m2.row1, m1.row2 + m2.row2, m1.row3 + m2.row3);
        }

        public static Matrix3 operator -(Matrix3 m1, Matrix3 m2)
        {
            return new Matrix3(m1.row1 - m2.row1, m1.row2 - m2.row2, m1.row3 - m2.row3);
        }

        public static Matrix3 operator *(Matrix3 m, Matrix3 m2)
        {
            Matrix3 r = new Matrix3(
            new Vector3(m[0].X * m2[0].X + m[0].Y * m2[1].X + m[0].Z * m2[2].X,
                m[0].X * m2[0].Y + m[0].Y * m2[1].Y + m[0].Z * m2[2].Y,
                m[0].X * m2[0].Z + m[0].Y * m2[1].Z + m[0].Z * m2[2].Z),

            new Vector3(m[1].X * m2[0].X + m[1].Y * m2[1].X + m[1].Z * m2[2].X,
                m[1].X * m2[0].Y + m[1].Y * m2[1].Y + m[1].Z * m2[2].Y,
                m[1].X * m2[0].Z + m[1].Y * m2[1].Z + m[1].Z * m2[2].Z),

            new Vector3(m[2].X * m2[0].X + m[2].Y * m2[1].X + m[2].Z * m2[2].X,
                m[2].X * m2[0].Y + m[2].Y * m2[1].Y + m[2].Z * m2[2].Y,
                m[2].X * m2[0].Z + m[2].Y * m2[1].Z + m[2].Z * m2[2].Z));
            return r;
        }

        public static Matrix3 operator *(Matrix3 m1, float d)
        {
            return new Matrix3(m1.row1 * d, m1.row2 * d, m1.row3 * d);
        }

        public static Matrix3 operator /(Matrix3 m1, float d)
        {
            return new Matrix3(m1.row1 / d, m1.row2 / d, m1.row3 / d);
        }

        public static Vector2 operator *(Matrix3 m1, Vector2 v)
        {
            return new Vector2(m1[0].X * v.X + m1[0].Y * v.Y,
                m1[1].X * v.X + m1[1].Y * v.Y);
        }

        public static Vector2 operator *(Vector2 v, Matrix3 m1)
        {
            return new Vector2(v.X * m1[0].X + v.Y * m1[1].X,
                v.X * m1[0].Y + v.Y * m1[1].Y);
        }

        public static Vector3 operator *(Matrix3 m1, Vector3 v)
        {
			return new Vector3(m1[0].X * v.X + m1[0].Y * v.Y + m1[0].Z * v.Z,
				m1[1].X * v.X + m1[1].Y * v.Y + m1[1].Z * v.Z,
				m1[2].X * v.X + m1[2].Y * v.Y + m1[2].Z * v.Z);
		}

        public static Vector3 operator *(Vector3 v, Matrix3 m1)
        {
            return new Vector3(v.X * m1[0].X + v.Y * m1[1].X + v.Z * m1[2].X,
                v.X * m1[0].Y + v.Y * m1[1].Y + v.Z * m1[2].Y,
                v.X * m1[0].Z + v.Y * m1[1].Z + v.Z * m1[2].Z);
        }

        public Vector3 this[int a]
        {
            get
            {
                if (a > 2 || a < 0) throw new ArgumentOutOfRangeException();
                return (a == 0 ? row1 : (a == 1 ? row2 : row3));
            }
            set
            {
                if (a == 0) row1 = value;
                else if (a == 1) row2 = value;
                else if (a == 2) row3 = value;
            }
        }

        public static bool operator ==(Matrix3 m1, Matrix3 m2)
        {
            return (m1[0] == m2[0] && m1[1] == m2[1] && m1[2] == m2[2]);
        }

        public static bool operator !=(Matrix3 m1, Matrix3 m2)
        {
            return (m1[0] != m2[0] || m1[1] != m2[1] || m1[2] != m2[2]);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix3)) return false;

            return this.Equals((Matrix3)obj);
        }

        public bool Equals(Matrix3 other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "[ " + row1.ToString() + " ] [ " + row2.ToString() + " ] [ " + row3.ToString() + " ]";
        }
        #endregion

        #region Constructors
        public Matrix3(Matrix3 existingMatrix)
        {
            row1 = existingMatrix[0];
            row2 = existingMatrix[1];
            row3 = existingMatrix[2];
        }

        public Matrix3(Vector3 v0, Vector3 v1, Vector3 v2)
        {
            row1 = v0;
            row2 = v1;
            row3 = v2;
        }

        public Matrix3(float[] array)
        {
            row1 = new Vector3(array[0], array[1], array[2]);
            row2 = new Vector3(array[3], array[4], array[5]);
            row3 = new Vector3(array[6], array[7], array[8]);
        }

        public Matrix3(double[] array)
        {
            row1 = new Vector3((float)array[0], (float)array[1], (float)array[2]);
            row2 = new Vector3((float)array[3], (float)array[4], (float)array[5]);
            row3 = new Vector3((float)array[6], (float)array[7], (float)array[8]);
        }

        public void SetMatrix(Vector3 v0, Vector3 v1, Vector3 v2)
        {
            row1 = v0;
            row2 = v1;
            row3 = v2;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates a matrix which contains information on how to translate.
        /// </summary>
        /// <param name="translation">Amount to translate by in the x, and y directions.</param>
        /// <returns>A Matrix3 object that contains the translation matrix.</returns>
        public static Matrix3 CreateTranslation(Vector2 translation)
        {
            Matrix3 result = Matrix3.Identity;
	        result.row1.Z = translation.X;
	        result.row2.Z = translation.Y;
            return result;
        }

        /// <summary>
        /// Creates a matrix which contains information on how to rotate.
        /// </summary>
        /// <param name="angle">Amount to rotate in radians (counter-clockwise).</param>
        /// <returns>A Matrix3 object that contains the rotation matrix.</returns>
        public static Matrix3 CreateRotation(float angle)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            return new Matrix3(
				new Vector3(cos, sin, 0f),
				new Vector3(-sin, cos, 0f),
				Vector3.UnitZ);
        }

        /// <summary>
        /// Creates a matrix which contains information on how to scale.
        /// </summary>
        /// <param name="scale">Amount to scale by in the x and y direction</param>
        /// <returns>A Matrix3 object that contains the scaling matrix</returns>
        public static Matrix3 CreateScaling(Vector2 scale)
        {
            return new Matrix3(
				new Vector3(scale.X, 0.0f, 0.0f),
				new Vector3(0.0f, scale.Y, 0.0f),
				new Vector3(0.0f, 0.0f, 1.0f));
        }

        /// <summary>
        /// Creates the transpose of the current matrix.
        /// </summary>
        /// <returns>A Matrix3 object that contains the transposed matrix</returns>
        public Matrix3 Transpose()
        {
            return new Matrix3(new Vector3(this[0].X, this[1].X, this[2].X),
                new Vector3(this[0].Y, this[1].Y, this[2].Y),
                new Vector3(this[0].Z, this[1].Z, this[2].Z));
        }

        /// <summary>
        /// Creates the inverse matrix using Gauss-Jordan elimination with partial pivoting.
        /// </summary>
        /// <returns>A Matrix3 object that contains the inversed matrix</returns>
        public Matrix3 Inverse()
        {
			// TODO - Make sure this actually works
            Matrix3 original = new Matrix3(this);
            Matrix3 identity = Matrix3.Identity;
            int k;

            // loop over columns from left to right eliminating above and below diagonal
            for (int j = 0; j < 3; j++)
            {
                k = j;    // row with largest pivot cadence
                for (int i = j + 1; i < 3; i++)
                    if (Math.Abs(original[i].Get(j)) > Math.Abs(original[k].Get(j))) k = i;

                original.SwapRows(k, j);
                identity.SwapRows(k, j);

                if (original[j].Get(j) == 0.0f) 
                    throw new Exception("Matrix3 was a singular matrix and cannot be inverted.");

                identity[j] /= original[j].Get(j);
                original[j] /= original[j].Get(j);

                for (int i = 0; i < 3; i++)
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
        /// Swaps two rows in the Matrix3 object.
        /// </summary>
        /// <param name="i">First row to switch</param>
        /// <param name="j">Second row to switch</param>
        public void SwapRows(int i, int j)
        {
            Vector3 temp = this[i];
            this[i] = this[j];
            this[j] = temp;
        }

        /// <summary>
        /// Returns a floating array that represents the Matrix3.
        /// </summary>
        /// <returns>Floating array that represents that Matrix3</returns>
        public float[] ToFloat()
        {
            return new float[] { this[0].X, this[0].Y, this[0].Z, this[1].X, this[1].Y, this[1].Z,
                this[2].X, this[2].Y, this[2].Z };
        }
        #endregion
    }
}