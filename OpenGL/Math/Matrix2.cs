using System;
using System.Runtime.InteropServices;

#if USE_NUMERICS
using System.Numerics;
#endif

namespace OpenGL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix2 : IEquatable<Matrix2>
    {
        private Vector2 row1, row2;

        #region Properties
        /// <summary>
        /// Returns the determinant of this matrix.
        /// </summary>
        public float Determinant
        {
            get { return this[0].X * this[1].Y - this[0].Y * this[1].X; }
        }
        #endregion

        #region Static Constructors
        public static Matrix2 Identity
        {
            get { return new Matrix2(Vector2.UnitX, Vector2.UnitY); }
        }
        #endregion

        #region Operators
        public static Matrix2 operator +(Matrix2 m1, Matrix2 m2)
        {
            return new Matrix2(m1.row1 + m2.row1, m1.row2 + m2.row2);
        }

        public static Matrix2 operator -(Matrix2 m1, Matrix2 m2)
        {
            return new Matrix2(m1.row1 - m2.row1, m1.row2 - m2.row2);
        }

        public static Matrix2 operator *(Matrix2 m, Matrix2 m2)
        {
            Matrix2 r = new Matrix2(
            new Vector2(m[0].X * m2[0].X + m[0].Y * m2[1].X,
                        m[0].X * m2[0].Y + m[0].Y * m2[1].Y),

            new Vector2(m[1].X * m2[0].X + m[1].Y * m2[1].X,
                        m[1].X * m2[0].Y + m[1].Y * m2[1].Y));
            return r;
        }

        public static Matrix2 operator *(Matrix2 m1, float d)
        {
            return new Matrix2(m1.row1 * d, m1.row2 * d);
        }

        public static Matrix2 operator /(Matrix2 m1, float d)
        {
            return new Matrix2(m1.row1 / d, m1.row2 / d);
        }

        public static Vector2 operator *(Matrix2 m1, Vector2 v)
        {
            return new Vector2(m1[0].X * v.X + m1[0].Y * v.Y,
                               m1[1].X * v.X + m1[1].Y * v.Y);
        }

        public static Vector2 operator *(Vector2 v, Matrix2 m1)
        {
            return new Vector2(m1[0].X * v.X + m1[1].X * v.Y, m1[0].Y * v.X + m1[1].Y * v.Y);
        }

        public Vector2 this[int a]
        {
            get
            {
                if (a > 1 || a < 0) throw new ArgumentOutOfRangeException();
                return (a == 0 ? row1 : row2);
            }
            set
            {
                if (a == 0) row1 = value;
                else if (a == 1) row2 = value;
            }
        }

        public static bool operator ==(Matrix2 m1, Matrix2 m2)
        {
            return (m1[0] == m2[0] && m1[1] == m2[1]);
        }

        public static bool operator !=(Matrix2 m1, Matrix2 m2)
        {
            return (m1[0] != m2[0] || m1[1] != m2[1]);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix2)) return false;

            return this.Equals((Matrix2)obj);
        }

        public bool Equals(Matrix2 other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "[ " + row1.ToString() + " ] [ " + row2.ToString() + " ]";
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates an identical copy of a Matrix2.
        /// </summary>
        /// <param name="existingMatrix">Specifies the Matrix2 to copy.</param>
        public Matrix2(Matrix2 existingMatrix)
        {
            row1 = existingMatrix[0];
            row2 = existingMatrix[1];
        }

        /// <summary>
        /// Creates a Matrix2 from rows of vectors.
        /// </summary>
        /// <param name="v0">Specifies the first row of the matrix.</param>
        /// <param name="v1">Specifies the second row of the matrix.</param>
        public Matrix2(Vector2 v0, Vector2 v1)
        {
            row1 = v0;
            row2 = v1;
        }

        /// <summary>
        /// Takes the first four values of a float[] and creates a Matrix2 out of it.
        /// The first two values specify the first row of the matrix. The next two
        /// specifies the second row of the matrix.
        /// </summary>
        /// <param name="array">Specifies the float[] to make into a Matrix2.</param>
        public Matrix2(float[] array)
        {
            row1 = new Vector2(array[0], array[1]);
            row2 = new Vector2(array[2], array[3]);
        }

        /// <summary>
        /// Takes the first four values of a double[] and creates a Matrix2 out of it.
        /// The first two values specify the first row of the matrix. The next two
        /// specifies the second row of the matrix. The values are cast to floats.
        /// </summary>
        /// <param name="array">Specifies the double[] to make into a Matrix2.</param>
        public Matrix2(double[] array)
        {
            row1 = new Vector2((float)array[0], (float)array[1]);
            row2 = new Vector2((float)array[2], (float)array[3]);
        }

        /// <summary>
        /// <para/>Takes four floats to make a matrix.
        /// <para/>The values will be setup as follows in the matrix.
        /// <para/>f11, f12
        /// <para/>f21, f22
        /// </summary>
        /// <param name="f11">Top left value in the matrix.</param>
        /// <param name="f12">Top right value in the matrix.</param>
        /// <param name="f21">Bottom left value in the matrix.</param>
        /// <param name="f22">Bottom right value in the matrix.</param>
        public Matrix2(float f11, float f12, float f21, float f22)
        {
            row1 = new Vector2(f11, f12);
            row2 = new Vector2(f21, f22);
        }

        /// <summary>
        /// Set matrix rows with new rows.
        /// </summary>
        /// <param name="v0">Set first row to this vector.</param>
        /// <param name="v1">Set second row to this vector.</param>
        public void SetMatrix(Vector2 v0, Vector2 v1)
        {
            row1 = v0;
            row2 = v1;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates a matrix which contains information on how to rotate.
        /// </summary>
        /// <param name="angle">Amount to rotate in radians (counter-clockwise).</param>
        /// <returns>A Matrix2 object that contains the rotation matrix.</returns>
        public static Matrix2 CreateRotation(float angle)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            return new Matrix2(
                new Vector2(cos, -sin),
                new Vector2(sin, cos));
        }


        /// <summary>
        /// Creates the inverse matrix if it has any. If no inverse matrix exists then it throws an error.
        /// </summary>
        /// <returns>A Matrix2 object that contains the inversed matrix</returns>
        /// <exception cref="System.Exception">Throws error if the matrix doesn't have an inverse matrix.</exception>
        public Matrix2 Inverse()
        {
            float det = Determinant;

            //Some matrices cannot be inverted
            if (det == 0)
                throw new Exception("Matrix2 was a singular matrix and cannot be inverted.");

            Matrix2 m1 = new Matrix2(this[1].Y, -this[0].Y, -this[1].X, this[0].X);
            return m1 * (1 / det);
        }

        /// <summary>
        /// Returns a floating array that represents the Matrix2.
        /// </summary>
        /// <returns>Floating array that represents that Matrix2</returns>
        public float[] ToFloat()
        {
            return new float[] { this[0].X, this[0].Y, this[1].X, this[1].Y };
        }
        #endregion
    }
}