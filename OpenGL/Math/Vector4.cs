using System;
#if USE_NUMERICS
using System.Numerics;
#else
using System.Runtime.InteropServices;
#endif

namespace OpenGL
{
#if !USE_NUMERICS
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4 : IEquatable<Vector4>
    {
        public float X, Y, Z, W;

        #region Static Constructors
        public static Vector4 Zero
        {
            get { return new Vector4(0.0f, 0.0f, 0.0f, 0.0f); }
        }

        public static Vector4 UnitX
        {
            get { return new Vector4(1.0f, 0.0f, 0.0f, 0.0f); }
        }

        public static Vector4 UnitY
        {
            get { return new Vector4(0.0f, 1.0f, 0.0f, 0.0f); }
        }

        public static Vector4 UnitZ
        {
            get { return new Vector4(0.0f, 0.0f, 1.0f, 0.0f); }
        }

        public static Vector4 UnitW
        {
            get { return new Vector4(0.0f, 0.0f, 0.0f, 1.0f); }
        }

        public static Vector4 One
        {
            get { return new Vector4(1.0f, 1.0f, 1.0f, 1.0f); }
        }
        #endregion

        #region Operators
        public static Vector4 operator +(Vector4 v1, Vector4 v2)
        {
            return new Vector4(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z, v1.W + v2.W);
        }

        public static Vector4 operator +(Vector4 v, float s)
        {
            return new Vector4(v.X + s, v.Y + s, v.Z + s, v.W + s);
        }

        public static Vector4 operator +(float s, Vector4 v)
        {
            return new Vector4(v.X + s, v.Y + s, v.Z + s, v.W + s);
        }

        public static Vector4 operator -(Vector4 v1, Vector4 v2)
        {
            return new Vector4(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z, v1.W - v2.W);
        }

        public static Vector4 operator -(Vector4 v, float s)
        {
            return new Vector4(v.X - s, v.Y - s, v.Z - s, v.W - s);
        }

        public static Vector4 operator -(float s, Vector4 v)
        {
            return new Vector4(s - v.X, s - v.Y, s - v.Z, s - v.W);
        }

        public static Vector4 operator -(Vector4 v)
        {
            return new Vector4(-v.X, -v.Y, -v.Z, -v.W);
        }

        public static Vector4 operator *(Vector4 v1, Vector4 v2)
        {
            return new Vector4(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z, v1.W * v2.W);
        }

        public static Vector4 operator *(float s, Vector4 v)
        {
            return new Vector4(v.X * s, v.Y * s, v.Z * s, v.W * s);
        }

        public static Vector4 operator *(Vector4 v, float s)
        {
            return new Vector4(v.X * s, v.Y * s, v.Z * s, v.W * s);
        }

        public static Vector4 operator /(Vector4 v1, Vector4 v2)
        {
            return new Vector4(v1.X / v2.X, v1.Y / v2.Y, v1.Z / v2.Z, v1.W / v2.W);
        }

        public static Vector4 operator /(float s, Vector4 v)
        {
            return new Vector4(s / v.X, s / v.Y, s / v.Z, s / v.W);
        }

        public static Vector4 operator /(Vector4 v, float s)
        {
            return new Vector4(v.X / s, v.Y / s, v.Z / s, v.W / s);
        }

        public static bool operator ==(Vector4 v1, Vector4 v2)
        {
            return (v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z && v1.W == v2.W);
        }

        public static bool operator !=(Vector4 v1, Vector4 v2)
        {
            return (v1.X != v2.X || v1.Y != v2.Y || v1.Z != v2.Z || v1.W != v2.W);
        }
        #endregion

        #region Constructors
        /// <summary>Creates a Vector4 structure whose elements have the specified values.</summary>
        /// <param name="x">The value to assign to the X field.</param>
        /// <param name="y">The value to assign to the Y field.</param>
        /// <param name="z">The value to assign to the Z field.</param>
        /// <param name="w">The value to assign to the W field.</param>
        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>Creates a Vector4 structure based on a Vector3 and w.</summary>
        /// <param name="v">The Vector3 to use for the X, Y and Z components.</param>
        /// <param name="w">The value to assign to the W field.</param>
        public Vector4(Vector3 v, float w)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = w;
        }

        /// <summary>Creates a Vector4 structure whose four elements have the same value.</summary>
        /// <param name="value">The value to assign to all four elements.</param>
        public Vector4(float value)
        {
            X = Y = Z = W = value;
        }

        /// <summary>Creates a Vector4 structure based on a Vector2, z and w.</summary>
        /// <param name="v">The Vector2 to use for the X and Y components.</param>
        /// <param name="z">The value to assign to the Z field.</param>
        /// <param name="w">The value to assign to the W field.</param>
        public Vector4(Vector2 v, float z, float w)
        {
            X = v.X;
            Y = v.Y;
            Z = z;
            W = w;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (!(obj is Vector4)) return false;

            return this.Equals((Vector4)obj);
        }

        public bool Equals(Vector4 other)
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
        /// Returns a string representing this Vector4.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return string.Format("<{0}, {1}, {2}, {3}>", X, Y, Z, W);
        }

        /// <summary>
        /// Parses a JSON stream and produces a Vector4 struct.
        /// </summary>
        public static Vector4 Parse(string text)
        {
            string[] split = text.Trim(new char[] { '{', '}' }).Split(',');
            if (split.Length != 4) return Vector4.Zero;

            return new Vector4(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]), float.Parse(split[3]));
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get the length of the Vector4 structure.
        /// </summary>
        public float Length()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
        }

        /// <summary>
        /// Get the squared length of the Vector4 structure.
        /// </summary>
        public float SquaredLength
        {
            get { return X * X + Y * Y + Z * Z + W * W; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Vector4 scalar dot product.
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>Scalar dot product value</returns>
        public static float Dot(Vector4 v1, Vector4 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z + v1.W * v2.W;
        }

        /// <summary>
        /// Vector4 scalar dot product.
        /// </summary>
        /// <param name="v">Second vector</param>
        /// <returns>Vector4.Dot(this, v)</returns>
        public float Dot(Vector4 v)
        {
            return Vector4.Dot(this, v);
        }

        /// <summary>
        /// Converts a Vector4 to a float array.  Useful for vector commands in GL.
        /// </summary>
        /// <returns>Float array representation of a Vector4</returns>
        public float[] ToFloat()
        {
            return new float[] { X, Y, Z, W };
        }

        /// <summary>
        /// Normalizes the Vector4 structure to have a peak value of one.
        /// </summary>
        /// <returns>if (Length = 0) return Zero; else return Vector4(x,y,z,w)/Length</returns>
        public Vector4 Normalize()
        {
            if (Length() == 0) return Zero;
            else return new Vector4(X, Y, Z, W) / Length();
        }

        /// <summary>
        /// Checks to see if any value (x, y, z, w) are within 0.0001 of 0.
        /// If so this method truncates that value to zero.
        /// </summary>
        /// <returns>A truncated Vector4</returns>
        public Vector4 Truncate()
        {
            float _x = (Math.Abs(X) - 0.0001f < 0) ? 0 : X;
            float _y = (Math.Abs(Y) - 0.0001f < 0) ? 0 : Y;
            float _z = (Math.Abs(Z) - 0.0001f < 0) ? 0 : Z;
            float _w = (Math.Abs(W) - 0.0001f < 0) ? 0 : W;
            return new Vector4(_x, _y, _z, _w);
        }

        /// <summary>
        /// Store the minimum values of x, y, z, and w between the two vectors.
        /// </summary>
        /// <param name="v">Vector to check against</param>
        public void TakeMin(Vector4 v)
        {
            if (v.X < X) X = v.X;
            if (v.Y < Y) Y = v.Y;
            if (v.Z < Z) Z = v.Z;
            if (v.W < W) W = v.W;
        }

        /// <summary>
        /// Store the maximum values of x, y, z, and w  between the two vectors.
        /// </summary>
        /// <param name="v">Vector to check against</param>
        public void TakeMax(Vector4 v)
        {
            if (v.X > X) X = v.X;
            if (v.Y > Y) Y = v.Y;
            if (v.Z > Z) Z = v.Z;
            if (v.W > W) W = v.W;
        }

        /// <summary>
        /// Linear interpolates between two vectors to get a new vector.
        /// </summary>
        /// <param name="v1">Initial vector (amount = 0).</param>
        /// <param name="v2">Final vector (amount = 1).</param>
        /// <param name="amount">Amount of each vector to consider (0->1).</param>
        /// <returns>A linear interpolated Vector3.</returns>
        public static Vector4 Lerp(Vector4 v1, Vector4 v2, float amount)
        {
            return v1 + (v2 - v1) * amount;
        }

        /// <summary>
        /// Swaps two Vector4 structures by passing via reference.
        /// </summary>
        /// <param name="v1">The first Vector4 structure.</param>
        /// <param name="v2">The second Vector4 structure.</param>
        public static void Swap(ref Vector4 v1, ref Vector4 v2)
        {
            Vector4 t = v1;
            v1 = v2;
            v2 = t;
        }

        /// <summary>
        /// Copies the elements of the vector to a specified array.
        /// </summary>
        /// <param name="array">The destination array.</param>
        /// <param name="offset">The index at which to copy the first element of the vector.</param>
        public void CopyTo(float[] array, int offset)
        {
            array[offset + 0] = X;
            array[offset + 1] = Y;
            array[offset + 2] = Z;
            array[offset + 3] = W;
        }
        #endregion
    }
#endif

    /// <summary>
    /// Extension methods for the Vector4 structure.
    /// </summary>
    public static class Vector4Extensions
    {
        /// <summary>
        /// Provide an accessor for each of the elements of the Vector structure.
        /// </summary>
        /// <param name="v">The Vector4 to access.</param>
        /// <param name="index">The element to access (0 = X, 1 = Y, 2 = Z, 3 = W).</param>
        /// <returns>The element of the Vector3 as indexed by i.</returns>
        public static float Get(this Vector4 v, int index)
        {
            switch (index)
            {
                case 0: return v.X;
                case 1: return v.Y;
                case 2: return v.Z;
                case 3: return v.W;
                default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
    }
}
