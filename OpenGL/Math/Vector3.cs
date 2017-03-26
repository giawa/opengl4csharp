using System;
using System.Runtime.InteropServices;

#if USE_NUMERICS
using System.Numerics;
#endif

namespace OpenGL
{
#if !USE_NUMERICS
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3 : IEquatable<Vector3>
    {
        public float X, Y, Z;

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

        /// <summary>
        /// Maintains backwards compatible with legacy OpenGL library code (prior to USE_NUMERICS).
        /// </summary>
        [Obsolete("Use Z instead, which is compatible with System.Numerics.")]
        public float z
        {
            get { return Z; }
            set { Z = value; }
        }
#pragma warning restore

        #region Static Constructors
        [Obsolete("Vector3.Identity is not compatible with System.Numerics.  Use Vector3.One instead.")]
        public static Vector3 Identity
        {
            get { return new Vector3(1.0f, 1.0f, 1.0f); }
        }

        public static Vector3 Zero
        {
            get { return new Vector3(0.0f, 0.0f, 0.0f); }
        }

        [Obsolete("Vector3.Up is not compatible with System.Numerics.  Use Vector3.UnitY instead.")]
        public static Vector3 Up
        {
            get { return new Vector3(0.0f, 1.0f, 0.0f); }
        }

        [Obsolete("Vector3.Down is not compatible with System.Numerics.  Use new Vector3(0, -1, 0) instead.")]
        public static Vector3 Down
        {
            get { return new Vector3(0.0f, -1.0f, 0.0f); }
        }

        [Obsolete("Vector3.Forward is not compatible with System.Numerics.  Use new Vector3(0, 0, -1) instead.")]
        public static Vector3 Forward
        {
            get { return new Vector3(0.0f, 0.0f, -1.0f); }
        }

        [Obsolete("Vector3.Backward is not compatible with System.Numerics.  Use Vector3.UnitZ instead.")]
        public static Vector3 Backward
        {
            get { return new Vector3(0.0f, 0.0f, 1.0f); }
        }

        [Obsolete("Vector3.Left is not compatible with System.Numerics.  Use new Vector3(-1, 0, 0) instead.")]
        public static Vector3 Left
        {
            get { return new Vector3(-1.0f, 0.0f, 0.0f); }
        }

        [Obsolete("Vector3.Right is not compatible with System.Numerics.  Use Vector3.UnitX instead.")]
        public static Vector3 Right
        {
            get { return new Vector3(1.0f, 0.0f, 0.0f); }
        }

        public static Vector3 UnitX
        {
            get { return new Vector3(1.0f, 0.0f, 0.0f); }
        }

        public static Vector3 UnitY
        {
            get { return new Vector3(0.0f, 1.0f, 0.0f); }
        }

        public static Vector3 UnitZ
        {
            get { return new Vector3(0.0f, 0.0f, 1.0f); }
        }

        [Obsolete("Vector3.UnitScale is not compatible with System.Numerics.  Use Vector3.One instead.")]
        public static Vector3 UnitScale
        {
            get { return new Vector3(1.0f, 1.0f, 1.0f); }
        }

        public static Vector3 One
        {
            get { return new Vector3(1.0f, 1.0f, 1.0f); }
        }
        #endregion

        #region Operators
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector3 operator +(Vector3 v, float s)
        {
            return new Vector3(v.X + s, v.Y + s, v.Z + s);
        }

        public static Vector3 operator +(float s, Vector3 v)
        {
            return new Vector3(v.X + s, v.Y + s, v.Z + s);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vector3 operator -(Vector3 v, float s)
        {
            return new Vector3(v.X - s, v.Y - s, v.Z - s);
        }

        public static Vector3 operator -(float s, Vector3 v)
        {
            return new Vector3(s - v.X, s - v.Y, s - v.Z);
        }

        public static Vector3 operator -(Vector3 v)
        {
            return new Vector3(-v.X, -v.Y, -v.Z);
        }

        public static Vector3 operator *(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);
        }

        public static Vector3 operator *(float s, Vector3 v)
        {
            return new Vector3(v.X * s, v.Y * s, v.Z * s);
        }

        public static Vector3 operator *(Vector3 v, float s)
        {
            return new Vector3(v.X * s, v.Y * s, v.Z * s);
        }

        public static Vector3 operator /(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X / v2.X, v1.Y / v2.Y, v1.Z / v2.Z);
        }

        public static Vector3 operator /(float s, Vector3 v)
        {
            return new Vector3(s / v.X, s / v.Y, s / v.Z);
        }

        public static Vector3 operator /(Vector3 v, float s)
        {
            return new Vector3(v.X / s, v.Y / s, v.Z / s);
        }

        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            return (v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z);
        }

        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            return (v1.X != v2.X || v1.Y != v2.Y || v1.Z != v2.Z);
        }
        #endregion

        #region Constructors
        /// <summary>Creates a Vector3 structure whose elements have the specified values.</summary>
        /// <param name="x">The value to assign to the X field.</param>
        /// <param name="y">The value to assign to the Y field.</param>
        /// <param name="z">The value to assign to the Z field.</param>
        public Vector3(float x, float y, float z)
        {
            X = x; 
            Y = y; 
            Z = z;
        }

        /// <summary>Creates a Vector3 structure whose elements have the specified values.</summary>
        /// <param name="x">The value to assign to the X field.</param>
        /// <param name="y">The value to assign to the Y field.</param>
        /// <param name="z">The value to assign to the Z field.</param>
        [Obsolete("Use floats instead, which is compatible with System.Numerics.")]
        public Vector3(double x, double y, double z)
        {
            X = (float)x; 
            Y = (float)y; 
            Z = (float)z;
        }

        /// <summary>Creates a Vector3 tructure from a float array (assuming the float array is of length 3).</summary>
        /// <param name="vector">The float array to convert to a Vector3.</param>
        [Obsolete("Use Vector3(float, float, float) instead, which is compatible with System.Numerics.")]
        public Vector3(float[] vector)
        {
            if (vector.Length != 3) throw new Exception(string.Format("float[] vector was of length {0}.  Was expecting a length of 3.", vector.Length));
            X = vector[0]; 
            Y = vector[1]; 
            Z = vector[2];
        }

        /// <summary>Creates a Vector3 structure whose three elements have the same value.</summary>
        /// <param name="value">The value to assign to all three elements.</param>
        public Vector3(float value)
        {
            X = Y = Z = value;
        }

        /// <summary>Creates a Vector3 structure based on a Vector2 and z.</summary>
        /// <param name="v">The Vector2 to use for the X and Y components.</param>
        /// <param name="z">The value to assign to the Z field.</param>
        public Vector3(Vector2 v, float z)
        {
            X = v.X;
            Y = v.Y;
            Z = z;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (!(obj is Vector3)) return false;

            return this.Equals((Vector3)obj);
        }

        public bool Equals(Vector3 other)
        {
            return this == other;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a string representing this Vector3.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return string.Format("<{0}, {1}, {2}>", X, Y, Z);
        }

        /// <summary>
        /// Parses a JSON stream and produces a Vector3 struct.
        /// </summary>
        public static Vector3 Parse(string text)
        {
            string[] split = text.Trim(new char[] { '{', '}' }).Split(',');
            if (split.Length != 3) return Vector3.Zero;

            return new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]));
        }

        public float this[int a]
        {
            get 
            {
                if (a > 2 || a < 0) throw new ArgumentOutOfRangeException();
                return (a == 0) ? X : (a == 1) ? Y : Z; 
            }
            set
            {
                if (a == 0) X = value;
                else if (a == 1) Y = value;
                else if (a == 2) Z = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Converts a Vector3 to a float array.  Useful for vector commands in GL.
        /// </summary>
        /// <returns>Float array representation of a Vector3</returns>
        public float[] ToFloat()
        {
            return new float[] { X, Y, Z };
        }

        /// <summary>
        /// Get the length of the Vector3 structure.
        /// </summary>
        public float Length
        {
            get { return (float)Math.Sqrt(X * X + Y * Y + Z * Z); }
        }

        /// <summary>
        /// Performs the Vector3 scalar dot product.
        /// </summary>
        /// <param name="v1">The left Vector3.</param>
        /// <param name="v2">The right Vector3.</param>
        /// <returns>Scalar dot product value</returns>
        public static float Dot(Vector3 v1, Vector3 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        /// <summary>
        /// Performs the Vector3 scalar dot product.
        /// </summary>
        /// <param name="v">Second dot product term</param>
        /// <returns>Vector3.Dot(this, v)</returns>
        public float Dot(Vector3 v)
        {
            return Vector3.Dot(this, v);
        }

        /// <summary>
        /// Returns the squared length of the Vector3 structure.
        /// </summary>
        [Obsolete("Use LengthSquared() instead, which is compatible with System.Numerics.")]
        public float SquaredLength
        {
            get { return X * X + Y * Y + Z * Z; }
        }

        /// <summary>
        /// A System.Numerics compatible version of SquaredLength.
        /// </summary>
        /// <returns>Returns the squared length of the Vector3 structure.</returns>
        public float LengthSquared()
        {
            return X * X + Y * Y + Z * Z;
        }

        /// <summary>
        /// Vector3 cross product
        /// </summary>
        /// <param name="v1">Vector1</param>
        /// <param name="v2">Vector2</param>
        /// <returns>Vector3 cross product value</returns>
        public static Vector3 Cross(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
        }

        /// <summary>
        /// Vector3 cross product
        /// </summary>
        /// <param name="v">Second cross product term</param>
        /// <returns>this x v</returns>
        public Vector3 Cross(Vector3 v)
        {
            return Vector3.Cross(this, v);
        }

        /// <summary>
        /// Normalizes the Vector3 structure to have a peak value of one.
        /// </summary>
        /// <returns>if (Length = 0) return Zero; else return Vector3(x,y,z)/Length</returns>
        public Vector3 Normalize()
        {
            if (Length == 0) return Zero;
            else return new Vector3(X, Y, Z) / Length;
        }

        /// <summary>
        /// Checks to see if any value (x, y, z) are within 0.0001 of 0.
        /// If so this method truncates that value to zero.
        /// </summary>
        /// <returns>A truncated Vector3</returns>
        public Vector3 Truncate()
        {
            float _x = (Math.Abs(X) - 0.0001 < 0) ? 0 : X;
            float _y = (Math.Abs(Y) - 0.0001 < 0) ? 0 : Y;
            float _z = (Math.Abs(Z) - 0.0001 < 0) ? 0 : Z;
            return new Vector3(_x, _y, _z);
        }

        /// <summary>
        /// Store the minimum values of x, y, and z between the two vectors.
        /// </summary>
        /// <param name="v">Vector to check against</param>
        public void TakeMin(Vector3 v)
        {
            if (v.X < X) X = v.X;
            if (v.Y < Y) Y = v.Y;
            if (v.Z < Z) Z = v.Z;
        }

        /// <summary>
        /// Store the maximum values of x, y, and z between the two vectors.
        /// </summary>
        /// <param name="v">Vector to check against</param>
        public void TakeMax(Vector3 v)
        {
            if (v.X > X) X = v.X;
            if (v.Y > Y) Y = v.Y;
            if (v.Z > Z) Z = v.Z;
        }

        /// <summary>
        /// Returns the maximum component of the Vector3.
        /// </summary>
        /// <returns>The maximum component of the Vector3</returns>
        public float Max()
        {
            return (X >= Y && X >= Z) ? X : (Y >= Z) ? Y : Z;
        }

        /// <summary>
        /// Returns the minimum component of the Vector3.
        /// </summary>
        /// <returns>The minimum component of the Vector3</returns>
        public float Min()
        {
            return (X <= Y && X <= Z) ? X : (Y <= Z) ? Y : Z;
        }

        /// <summary>
        /// Linear interpolates between two vectors to get a new vector.
        /// </summary>
        /// <param name="v1">Initial vector (amount = 0).</param>
        /// <param name="v2">Final vector (amount = 1).</param>
        /// <param name="amount">Amount of each vector to consider (0->1).</param>
        /// <returns>A linear interpolated Vector3.</returns>
        public static Vector3 Lerp(Vector3 v1, Vector3 v2, float amount)
        {
            return v1 + (v2 - v1) * amount;
        }

        /// <summary>
        /// Calculates the angle (in radians) between two vectors.
        /// </summary>
        /// <param name="first">The first vector.</param>
        /// <param name="second">The second vector.</param>
        /// <returns>Angle (in radians) between the vectors.</returns>
        /// <remarks>Note that the returned angle is never bigger than the constant Pi.</remarks>
        public static float CalculateAngle(Vector3 first, Vector3 second)
        {
            return (float)Math.Acos((Vector3.Dot(first, second)) / (first.Length * second.Length));
        }

        /// <summary>
        /// Calculates the angle (in radians) between two vectors.
        /// </summary>
        /// <param name="v">The second vector.</param>
        /// <returns>Angle (in radians) between the vectors.</returns>
        /// <remarks>Note that the returned angle is never bigger than the constant Pi.</remarks>
        public float CalculateAngle(Vector3 v)
        {
            return Vector3.CalculateAngle(this, v);
        }

        /// <summary>
        /// Swaps two Vector3 structures by passing via reference.
        /// </summary>
        /// <param name="v1">The first Vector3 structure.</param>
        /// <param name="v2">The second Vector3 structure.</param>
        public static void Swap(ref Vector3 v1, ref Vector3 v2)
        {
            Vector3 t = v1;
            v1 = v2;
            v2 = t;
        }

        /// <summary>
        /// Create a quaternion that represents the rotation vector between this
        /// Vector3 and a destination Vector3.
        /// </summary>
        /// <param name="destination">The vector we would like to rotate to.</param>
        /// <returns>A quaternion representing the axis of rotation between this vector 
        /// and the destination vector.</returns>
        public Quaternion GetRotationTo(Vector3 destination)
        {
            // Based on Stan Melax's algorithm in "Game Programming Gems"
            Vector3 t_source = this.Normalize();
            Vector3 t_dest = destination.Normalize();

            float d = t_source.Dot(t_dest);

            // if dot == 1 then the vectors are the same
            if (d >= 1.0f) return Quaternion.Identity;
            else if (d < (1e-6f - 1.0f))
            {
                Vector3 t_axis = Vector3.UnitX.Cross(this);
                if (t_axis.LengthSquared() < (1e-12)) // pick another if colinear
                    t_axis = Vector3.UnitY.Cross(this);
                t_axis.Normalize();
                return Quaternion.FromAngleAxis((float)Math.PI, t_axis);
            }
            else
            {
                float t_sqrt = (float)Math.Sqrt((1 + d) * 2.0f);
                float t_invs = 1.0f / t_sqrt;

                Vector3 t_cross = t_source.Cross(t_dest);
                return new Quaternion(t_cross.X * t_invs, t_cross.Y * t_invs, t_cross.Z * t_invs, t_sqrt * 0.5f).Normalize();
            }
        }

        /// <summary>
        /// Take the absolute value of a vector.
        /// </summary>
        /// <param name="value">The source vector.</param>
        /// <returns>A vector whose values are the absolute value of the source vector.</returns>
        public static Vector3 Abs(Vector3 value)
        {
            return new Vector3(Math.Abs(value.X), Math.Abs(value.Y), Math.Abs(value.Z));
        }

        /// <summary>
        /// Clamps a vector between a minimum and maximum vector.
        /// Note:  This follows HLSL order of operations.
        /// </summary>
        /// <param name="value">The source vector.</param>
        /// <param name="min">The minimum vector.</param>
        /// <param name="max">The maximum vector.</param>
        /// <returns>A vector that has been clamped between the minimum and maximum vectors.</returns>
        public static Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max)
        {
            float x = Math.Max(min.X, max.X);
            x = (value.X < min.X ? min.X : value.X > x ? x : value.X);

            float y = Math.Max(min.Y, max.Y);
            y = (value.Y < min.Y ? min.Y : value.Y > y ? y : value.Y);

            float z = Math.Max(min.Z, max.Z);
            z = (value.Z < min.Z ? min.Z : value.Z > z ? z : value.Z);

            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Add two vectors together.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>The sum of the two vectors.</returns>
        public static Vector3 Add(Vector3 v1, Vector3 v2)
        {
            return v1 + v2;
        }

        /// <summary>
        /// Find the length of the difference between two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>The length of the difference of the two vectors.</returns>
        public static float Distance(Vector3 v1, Vector3 v2)
        {
            return (v1 - v2).Length;
        }

        /// <summary>
        /// Find the squared length of the difference between two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>The squared length of the difference of the two vectors.</returns>
        public static float DistanceSquared(Vector3 v1, Vector3 v2)
        {
            return (v1 - v2).LengthSquared();
        }

        /// <summary>
        /// Divide a vector by a float.
        /// </summary>
        /// <param name="v">The source vector.</param>
        /// <param name="f">A float to use as the denominator.</param>
        /// <returns>A vector that has been divided by the float.</returns>
        public static Vector3 Divide(Vector3 v, float f)
        {
            return v / f;
        }

        /// <summary>
        /// Divide one vector by another.
        /// </summary>
        /// <param name="v1">The first vector (numerator).</param>
        /// <param name="v2">The second vector (denominator).</param>
        /// <returns>A vector that has been divided.</returns>
        public static Vector3 Divide(Vector3 v1, Vector3 v2)
        {
            return v1 / v2;
        }

        /// <summary>
        /// Take the maximum of two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>A vector that contains the maximum of the elements of the source vectors.</returns>
        public static Vector3 Max(Vector3 v1, Vector3 v2)
        {
            return new Vector3(Math.Max(v1.X, v2.X), Math.Max(v1.Y, v2.Y), Math.Max(v1.Z, v2.Z));
        }

        /// <summary>
        /// Take the minimum of two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>A vector that contains the minimum of the elements of the source vectors.</returns>
        public static Vector3 Min(Vector3 v1, Vector3 v2)
        {
            return new Vector3(Math.Min(v1.X, v2.X), Math.Min(v1.Y, v2.Y), Math.Min(v1.Z, v2.Z));
        }

        /// <summary>
        /// Multiply a vector by a float.
        /// </summary>
        /// <param name="v">The source vector.</param>
        /// <param name="f">The source float.</param>
        /// <returns>A vector that has been multiplied.</returns>
        public static Vector3 Multiply(Vector3 v, float f)
        {
            return v * f;
        }

        /// <summary>
        /// Multiply a vector by a float.
        /// </summary>
        /// <param name="v">The source vector.</param>
        /// <param name="f">The source float.</param>
        /// <returns>A vector that has been multiplied.</returns>
        public static Vector3 Multiply(float f, Vector3 v)
        {
            return f * v;
        }

        /// <summary>
        /// Multiply a vector by another vector.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>A vector that has been multiplied.</returns>
        public static Vector3 Multiply(Vector3 v1, Vector3 v2)
        {
            return v1 * v2;
        }

        /// <summary>
        /// Negative a source vector.
        /// </summary>
        /// <param name="v">The source vector.</param>
        /// <returns>A vector that is the negation of the source vector.</returns>
        public static Vector3 Negate(Vector3 v)
        {
            return new Vector3(-v.X, -v.Y, -v.Z);
        }

        /// <summary>
        /// Normalize a source vector.
        /// </summary>
        /// <param name="v">The source vector.</param>
        /// <returns>A vector normalized by taking the source vector divided by the source length.</returns>
        public static Vector3 Normalize(Vector3 v)
        {
            if (v.Length == 0) return Zero;
            else return new Vector3(v.X, v.Y, v.Z) / v.Length;
        }

        /// <summary>
        /// Reflect a source vector off a surface with the specified normal.
        /// </summary>
        /// <param name="v">The source vector.</param>
        /// <param name="normal">The normal of the reflecting surface.</param>
        /// <returns>A vector reflected off a surface with the specified normal.</returns>
        public static Vector3 Reflect(Vector3 v, Vector3 normal)
        {
            return v - Vector3.Dot(v, normal) * normal * 2f;
        }

        /// <summary>
        /// Perform a square root calculation on a vector.
        /// </summary>
        /// <param name="v">The source vector.</param>
        /// <returns>A vector that is the square root of the source vector.</returns>
        public static Vector3 SquareRoot(Vector3 v)
        {
            return new Vector3((float)Math.Sqrt(v.X), (float)Math.Sqrt(v.Y), (float)Math.Sqrt(v.Z));
        }

        /// <summary>
        /// Subtract one vector from another.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>The difference between two vectors.</returns>
        public static Vector3 Subtract(Vector3 v1, Vector3 v2)
        {
            return v1 - v2;
        }

        /// <summary>
        /// Transforms a source vector by a provided quaternion rotation.
        /// </summary>
        /// <param name="v">The source vector.</param>
        /// <param name="q">The quaternion rotation to apply.</param>
        /// <returns>A transformed vector.</returns>
        public static Vector3 Transform(Vector3 v, Quaternion q)
        {
            return q * v;
        }

        /// <summary>
        /// Provide an accessor for each of the elements of the Vector structure.
        /// </summary>
        /// <param name="v">The Vector3 to access.</param>
        /// <param name="index">The element to access (0 = X, 1 = Y, 2 = Z).</param>
        /// <returns>The element of the Vector3 as indexed by i.</returns>
        public float Get(int index)
        {
            return (index == 0 ? X : (index == 1 ? Y : Z));
        }
        #endregion
    }
#else
    /// <summary>
    /// Extension methods for the Vector3 structure.
    /// </summary>
    public static class Vector3Extensions
    {
        /// <summary>
        /// Store the minimum values of x, y, and z between the two vectors.
        /// </summary>
        /// <param name="tv">The Vector3 to perform the TakeMin on.</param>
        /// <param name="v">Vector to check against.</param>
        public static void TakeMin(this Vector3 tv, Vector3 v)
        {
            if (v.X < tv.X) tv.X = v.X;
            if (v.Y < tv.Y) tv.Y = v.Y;
            if (v.Z < tv.Z) tv.Z = v.Z;
        }

        /// <summary>
        /// Store the maximum values of x, y, and z between the two vectors.
        /// </summary>
        /// <param name="tv">The Vector3 to perform the TakeMax on.</param>
        /// <param name="v">Vector to check against.</param>
        public static void TakeMax(this Vector3 tv, Vector3 v)
        {
            if (v.X > tv.X) tv.X = v.X;
            if (v.Y > tv.Y) tv.Y = v.Y;
            if (v.Z > tv.Z) tv.Z = v.Z;
        }

        /// <summary>
        /// Normalizes the Vector3 structure to have a peak value of one.
        /// </summary>
        /// <param name="v">The Vector3 to perform the Normalize on.</param>
        /// <returns>if (Length = 0) return Zero; else return Vector3(x,y,z)/Length.</returns>
        public static Vector3 Normalize(this Vector3 v)
        {
            if (v.Length() == 0) return Vector3.Zero;
            else return new Vector3(v.X, v.Y, v.Z) / v.Length();
        }

        /// <summary>
        /// Performs the Vector3 scalar dot product.
        /// </summary>
        /// <param name="tv">The Vector3 to perform the dot product on.</param>
        /// <param name="v">Second dot product term.</param>
        /// <returns>Vector3.Dot(this, v).</returns>
        public static float Dot(this Vector3 tv, Vector3 v)
        {
            return Vector3.Dot(tv, v);
        }
        
        /// <summary>
        /// Provide an accessor for each of the elements of the Vector structure.
        /// </summary>
        /// <param name="v">The Vector3 to access.</param>
        /// <param name="index">The element to access (0 = X, 1 = Y, 2 = Z).</param>
        /// <returns>The element of the Vector3 as indexed by i.</returns>
        public static float Get(this Vector3 v, int index)
        {
            return (index == 0 ? v.X : (index == 1 ? v.Y : v.Z));
        }
    }
#endif
}