using System;
using System.Runtime.InteropServices;

namespace OpenGL
{
#if !USE_NUMERICS
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2 : IEquatable<Vector2>
    {
        public float X, Y;

#pragma warning disable IDE1006
        /// <summary>
        /// Maintains backwards compatible with legacy OpenGL library code (prior to USE_NUMERICS).
        /// </summary>
        [Obsolete("Use X instead, which is compatible with System.Numerics.")]
        public float x
        {
            get { return X; }
            set { X = value; }
        }

        /// <summary>
        /// Maintains backwards compatible with legacy OpenGL library code (prior to USE_NUMERICS).
        /// </summary>
        [Obsolete("Use Y instead, which is compatible with System.Numerics.")]
        public float y
        {
            get { return Y; }
            set { Y = value; }
        }
#pragma warning restore

        #region Static Constructors
        [Obsolete("Vector2.Identity is not compatible with System.Numerics.  Use Vector2.One instead.")]
        public static Vector2 Identity
        {
            get { return new Vector2(1.0f, 1.0f); }
        }

        public static Vector2 Zero
        {
            get { return new Vector2(0.0f, 0.0f); }
        }

        public static Vector2 One
        {
            get { return new Vector2(1.0f, 1.0f); }
        }

        public static Vector2 UnitX
        {
            get { return new Vector2(1.0f, 0.0f); }
        }

        public static Vector2 UnitY
        {
            get { return new Vector2(0.0f, 1.0f); }
        }
        #endregion

        #region Operators
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2 operator +(Vector2 v, float s)
        {
            return new Vector2(v.X + s, v.Y + s);
        }

        public static Vector2 operator +(float s, Vector2 v)
        {
            return new Vector2(v.X + s, v.Y + s);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2 operator -(Vector2 v, float s)
        {
            return new Vector2(v.X - s, v.Y - s);
        }

        public static Vector2 operator -(float s, Vector2 v)
        {
            return new Vector2(s - v.X, s - v.Y);
        }

        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.X, -v.Y);
        }

        public static Vector2 operator *(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X * v2.X, v1.Y * v2.Y);
        }

        public static Vector2 operator *(float s, Vector2 v)
        {
            return new Vector2(v.X * s, v.Y * s);
        }

        public static Vector2 operator *(Vector2 v, float s)
        {
            return new Vector2(v.X * s, v.Y * s);
        }

        public static Vector2 operator /(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X / v2.X, v1.Y / v2.Y);
        }

        public static Vector2 operator /(float s, Vector2 v)
        {
            return new Vector2(s / v.X, s / v.Y);
        }

        public static Vector2 operator /(Vector2 v, float s)
        {
            return new Vector2(v.X / s, v.Y / s);
        }

        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return (v1.X == v2.X && v1.Y == v2.Y);
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return (v1.X != v2.X || v1.Y != v2.Y);
        }
        #endregion

        #region Constructors
        /// <summary>Creates a Vector2 structure whose elements have the specified values.</summary>
        /// <param name="x">The value to assign to the X field.</param>
        /// <param name="y">The value to assign to the Y field.</param>
        public Vector2(float x, float y)
        {
            this.X = x; this.Y = y;
        }

        /// <summary>Creates a Vector2 structure whose elements have the specified values.</summary>
        /// <param name="x">The value to assign to the X field.</param>
        /// <param name="y">The value to assign to the Y field.</param>
        [Obsolete("Use floats instead, which is compatible with System.Numerics.")]
        public Vector2(double x, double y)
        {
            this.X = (float)x; this.Y = (float)y;
        }

        /// <summary>Creates a Vector2 structure whose two elements have the same value.</summary>
        /// <param name="value">The value to assign to all two elements.</param>
        public Vector2(float value)
        {
            X = Y = value;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (!(obj is Vector2)) return false;

            return this.Equals((Vector2)obj);
        }

        public bool Equals(Vector2 other)
        {
            return this == other;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a string representing this Vector2.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return string.Format("<{0}, {1}>", X, Y);
        }

        /// <summary>
        /// Parses a JSON stream and produces a Vector2 struct.
        /// </summary>
        public static Vector2 Parse(string text)
        {
            string[] split = text.Trim(new char[] { '{', '}' }).Split(',');
            if (split.Length != 2) return Vector2.Zero;

            return new Vector2(float.Parse(split[0]), float.Parse(split[1]));
        }

        public float this[int a]
        {
            get 
            {
                if (a > 1 || a < 0) throw new ArgumentOutOfRangeException();
                return (a == 0) ? X : Y; 
            }
            set
            {
                if (a == 0) X = value;
                else if (a == 1) Y = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get the length of the Vector2 structure.
        /// </summary>
        public float Length
        {
            get { return (float)Math.Sqrt(X * X + Y * Y); }
        }

        /// <summary>
        /// Get the squared length of the Vector2 structure.
        /// </summary>
        [Obsolete("Use LengthSquared() instead, which is compatible with System.Numerics.")]
        public float SquaredLength
        {
            get { return X * X + Y * Y; }
        }

        /// <summary>
        /// A System.Numerics compatible version of SquaredLength.
        /// </summary>
        /// <returns>Returns the squared length of the Vector2 structure.</returns>
        public float LengthSquared()
        {
            return X * X + Y * Y;
        }

        /// <summary>
        /// Gets the perpendicular vector on the right side of this vector.
        /// </summary>
        public Vector2 PerpendicularRight
        {
            get { return new Vector2(Y, -X); }
        }

        /// <summary>
        /// Gets the perpendicular vector on the left side of this vector.
        /// </summary>
        public Vector2 PerpendicularLeft
        {
            get { return new Vector2(-Y, X); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Converts a Vector2 to a float array.  Useful for vector commands in GL.
        /// </summary>
        /// <returns>Float array representation of a Vector2</returns>
        public float[] ToFloat()
        {
            return new float[] { X, Y };
        }

        /// <summary>
        /// Performs the Vector2 scalar dot product.
        /// </summary>
        /// <param name="v1">The left Vector2.</param>
        /// <param name="v2">The right Vector2.</param>
        /// <returns>v1.x * v2.x + v1.y * v2.y</returns>
        public static float Dot(Vector2 v1, Vector2 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }

        /// <summary>
        /// Performs the Vector2 scalar dot product.
        /// </summary>
        /// <param name="v">Second dot product term</param>
        /// <returns>Vector2.Dot(this, v)</returns>
        public float Dot(Vector2 v)
        {
            return this.Dot(v);
        }

        /// <summary>
        /// Normalizes the Vector2 structure to have a peak value of one.
        /// </summary>
        /// <returns>if (Length = 0) return Zero; else return Vector2(x,y)/Length</returns>
        public Vector2 Normalize()
        {
            if (Length == 0) return Zero;
            else return new Vector2(X, Y) / Length;
        }

        /// <summary>
        /// Checks to see if any value (x, y, z) are within 0.0001 of 0.
        /// If so this method truncates that value to zero.
        /// </summary>
        /// <returns>A truncated Vector2</returns>
        public Vector2 Truncate()
        {
            float _x = (Math.Abs(X) - 0.0001 < 0) ? 0 : X;
            float _y = (Math.Abs(Y) - 0.0001 < 0) ? 0 : Y;
            return new Vector2(_x, _y);
        }

        /// <summary>
        /// Store the minimum values of x, and y between the two vectors.
        /// </summary>
        /// <param name="v">Vector to check against</param>
        public void TakeMin(Vector2 v)
        {
            if (v.X < X) X = v.X;
            if (v.Y < Y) Y = v.Y;
        }

        /// <summary>
        /// Store the maximum values of x, and y between the two vectors.
        /// </summary>
        /// <param name="v">Vector to check against</param>
        public void TakeMax(Vector2 v)
        {
            if (v.X > X) X = v.X;
            if (v.Y > Y) Y = v.Y;
        }

        /// <summary>
        /// Linear interpolates between two vectors to get a new vector.
        /// </summary>
        /// <param name="v1">Initial vector (amount = 0).</param>
        /// <param name="v2">Final vector (amount = 1).</param>
        /// <param name="amount">Amount of each vector to consider (0->1).</param>
        /// <returns>A linear interpolated Vector3.</returns>
        public static Vector2 Lerp(Vector2 v1, Vector2 v2, float amount)
        {
            return v1 + (v2 - v1) * amount;
        }

        /// <summary>
        /// Swaps two Vector2 structures by passing via reference.
        /// </summary>
        /// <param name="v1">The first Vector2 structure.</param>
        /// <param name="v2">The second Vector2 structure.</param>
        public static void Swap(ref Vector2 v1, ref Vector2 v2)
        {
            Vector2 t = v1;
            v1 = v2;
            v2 = t;
        }
        #endregion
    }
#else
#endif
}
