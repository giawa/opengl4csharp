using System;
using System.Runtime.InteropServices;

namespace OpenGL
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2 : IEquatable<Vector2>
    {
        public float x, y;

        #region Static Constructors
        public static Vector2 Identity
        {
            get { return new Vector2(1.0f, 1.0f); }
        }

        public static Vector2 Zero
        {
            get { return new Vector2(0.0f, 0.0f); }
        }
        #endregion

        #region Operators
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2 operator +(Vector2 v, float s)
        {
            return new Vector2(v.x + s, v.y + s);
        }

        public static Vector2 operator +(float s, Vector2 v)
        {
            return new Vector2(v.x + s, v.y + s);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector2 operator -(Vector2 v, float s)
        {
            return new Vector2(v.x - s, v.y - s);
        }

        public static Vector2 operator -(float s, Vector2 v)
        {
            return new Vector2(s - v.x, s - v.y);
        }

        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.x, -v.y);
        }

        public static Vector2 operator *(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x * v2.x, v1.y * v2.y);
        }

        public static Vector2 operator *(float s, Vector2 v)
        {
            return new Vector2(v.x * s, v.y * s);
        }

        public static Vector2 operator *(Vector2 v, float s)
        {
            return new Vector2(v.x * s, v.y * s);
        }

        public static Vector2 operator /(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x / v2.x, v1.y / v2.y);
        }

        public static Vector2 operator /(float s, Vector2 v)
        {
            return new Vector2(s / v.x, s / v.y);
        }

        public static Vector2 operator /(Vector2 v, float s)
        {
            return new Vector2(v.x / s, v.y / s);
        }

        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return (v1.x == v2.x && v1.y == v2.y);
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return (v1.x != v2.x || v1.y != v2.y);
        }
        #endregion

        #region Constructors
        /// <summary>Create a Vector2 structure, normally used to store Vertex positions.</summary>
        /// <param name="x">x value</param>
        /// <param name="y">y value</param>
        public Vector2(float x, float y)
        {
            this.x = x; this.y = y;
        }

        /// <summary>Create a Vector2 structure, normally used to store Vertex positions.</summary>
        /// <param name="x">x value</param>
        /// <param name="y">y value</param>
        public Vector2(double x, double y)
        {
            this.x = (float)x; this.y = (float)y;
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "{" + x + ", " + y + "}";
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
            get { return (a == 0) ? x : y; }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get the length of the Vector2 structure.
        /// </summary>
        public float Length
        {
            get { return (float)Math.Sqrt(x * x + y * y); }
        }

        /// <summary>
        /// Get the squared length of the Vector2 structure.
        /// </summary>
        public float SquaredLength
        {
            get { return x * x + y * y; }
        }

        /// <summary>
        /// Gets the perpendicular vector on the right side of this vector.
        /// </summary>
        public Vector2 PerpendicularRight
        {
            get { return new Vector2(y, -x); }
        }

        /// <summary>
        /// Gets the perpendicular vector on the left side of this vector.
        /// </summary>
        public Vector2 PerpendicularLeft
        {
            get { return new Vector2(-y, x); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Converts a Vector2 to a float array.  Useful for vector commands in GL.
        /// </summary>
        /// <returns>Float array representation of a Vector2</returns>
        public float[] ToFloat()
        {
            return new float[] { x, y };
        }

        /// <summary>
        /// Performs the Vector2 scalar dot product.
        /// </summary>
        /// <param name="v1">The left Vector2.</param>
        /// <param name="v2">The right Vector2.</param>
        /// <returns>v1.x * v2.x + v1.y * v2.y</returns>
        public static float Dot(Vector2 v1, Vector2 v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
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
            else return new Vector2(x, y) / Length;
        }

        /// <summary>
        /// Checks to see if any value (x, y, z) are within 0.0001 of 0.
        /// If so this method truncates that value to zero.
        /// </summary>
        /// <returns>A truncated Vector2</returns>
        public Vector2 Truncate()
        {
            float _x = (Math.Abs(x) - 0.0001 < 0) ? 0 : x;
            float _y = (Math.Abs(y) - 0.0001 < 0) ? 0 : y;
            return new Vector2(_x, _y);
        }

        /// <summary>
        /// Store the minimum values of x, and y between the two vectors.
        /// </summary>
        /// <param name="v">Vector to check against</param>
        public void TakeMin(Vector2 v)
        {
            if (v.x < x) x = v.x;
            if (v.y < y) y = v.y;
        }

        /// <summary>
        /// Store the maximum values of x, and y between the two vectors.
        /// </summary>
        /// <param name="v">Vector to check against</param>
        public void TakeMax(Vector2 v)
        {
            if (v.x > x) x = v.x;
            if (v.y > y) y = v.y;
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
}
