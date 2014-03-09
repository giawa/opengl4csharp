using System;
using System.Runtime.InteropServices;

namespace OpenGL
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3 : IEquatable<Vector3>
    {
        public float x, y, z;

        #region Static Constructors
        public static Vector3 Identity
        {
            get { return new Vector3(1.0f, 1.0f, 1.0f); }
        }

        public static Vector3 Zero
        {
            get { return new Vector3(0.0f, 0.0f, 0.0f); }
        }

        public static Vector3 Up
        {
            get { return new Vector3(0.0f, 1.0f, 0.0f); }
        }

        public static Vector3 Down
        {
            get { return new Vector3(0.0f, -1.0f, 0.0f); }
        }

        public static Vector3 Forward
        {
            get { return new Vector3(0.0f, 0.0f, -1.0f); }
        }

        public static Vector3 Backward
        {
            get { return new Vector3(0.0f, 0.0f, 1.0f); }
        }

        public static Vector3 Left
        {
            get { return new Vector3(-1.0f, 0.0f, 0.0f); }
        }

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

        public static Vector3 UnitScale
        {
            get { return new Vector3(1.0f, 1.0f, 1.0f); }
        }
        #endregion

        #region Operators
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3 operator +(Vector3 v, float s)
        {
            return new Vector3(v.x + s, v.y + s, v.z + s);
        }

        public static Vector3 operator +(float s, Vector3 v)
        {
            return new Vector3(v.x + s, v.y + s, v.z + s);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3 operator -(Vector3 v, float s)
        {
            return new Vector3(v.x - s, v.y - s, v.z - s);
        }

        public static Vector3 operator -(float s, Vector3 v)
        {
            return new Vector3(s - v.x, s - v.y, s - v.z);
        }

        public static Vector3 operator -(Vector3 v)
        {
            return new Vector3(-v.x, -v.y, -v.z);
        }

        public static Vector3 operator *(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

        public static Vector3 operator *(float s, Vector3 v)
        {
            return new Vector3(v.x * s, v.y * s, v.z * s);
        }

        public static Vector3 operator *(Vector3 v, float s)
        {
            return new Vector3(v.x * s, v.y * s, v.z * s);
        }

        public static Vector3 operator /(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        }

        public static Vector3 operator /(float s, Vector3 v)
        {
            return new Vector3(s / v.x, s / v.y, s / v.z);
        }

        public static Vector3 operator /(Vector3 v, float s)
        {
            return new Vector3(v.x / s, v.y / s, v.z / s);
        }

        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            return (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z);
        }

        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            return (v1.x != v2.x || v1.y != v2.y || v1.z != v2.z);
        }
        #endregion

        #region Constructors
        /// <summary>Create a Vector3 structure, normally used to store Vertex positions.</summary>
        /// <param name="x">x value</param>
        /// <param name="y">y value</param>
        /// <param name="z">z value</param>
        public Vector3(float x, float y, float z)
        {
            this.x = x; this.y = y; this.z = z;
        }

        /// <summary>Creates a Vector3 structure, normally used to store Vertex positions.  Casted to floats for OpenGL.</summary>
        /// <param name="x">x value</param>
        /// <param name="y">y value</param>
        /// <param name="z">z value</param>
        public Vector3(double x, double y, double z)
        {
            this.x = (float)x; this.y = (float)y; this.z = (float)z;
        }

        /// <summary>Creates a Vector3 tructure from a float array (assuming the float array is of length 3).</summary>
        /// <param name="vector">The float array to convert to a Vector3.</param>
        public Vector3(float[] vector)
        {
            if (vector.Length != 3) throw new Exception(string.Format("float[] vector was of length {0}.  Was expecting a length of 3.", vector.Length));
            this.x = vector[0]; this.y = vector[1]; this.z = vector[2];
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "{" + x + ", " + y + ", " + z + "}";
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
            get { return (a == 0) ? x : (a == 1) ? y : z; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Converts a Vector3 to a float array.  Useful for vector commands in GL.
        /// </summary>
        /// <returns>Float array representation of a Vector3</returns>
        public float[] ToFloat()
        {
            return new float[] { x, y, z };
        }

        /// <summary>
        /// Get the length of the Vector3 structure.
        /// </summary>
        public float Length
        {
            get { return (float)Math.Sqrt(x * x + y * y + z * z); }
        }

        /// <summary>
        /// Performs the Vector3 scalar dot product.
        /// </summary>
        /// <param name="v1">The left Vector3.</param>
        /// <param name="v2">The right Vector3.</param>
        /// <returns>Scalar dot product value</returns>
        public static float Dot(Vector3 v1, Vector3 v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
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
        public float SquaredLength
        {
            get { return x * x + y * y + z * z; }
        }

        /// <summary>
        /// Vector3 cross product
        /// </summary>
        /// <param name="v1">Vector1</param>
        /// <param name="v2">Vector2</param>
        /// <returns>Vector3 cross product value</returns>
        public static Vector3 Cross(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.y * v2.z - v1.z * v2.y, v1.z * v2.x - v1.x * v2.z, v1.x * v2.y - v1.y * v2.x);
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
            else return new Vector3(x, y, z) / Length;
        }

        /// <summary>
        /// Checks to see if any value (x, y, z) are within 0.0001 of 0.
        /// If so this method truncates that value to zero.
        /// </summary>
        /// <returns>A truncated Vector3</returns>
        public Vector3 Truncate()
        {
            float _x = (Math.Abs(x) - 0.0001 < 0) ? 0 : x;
            float _y = (Math.Abs(y) - 0.0001 < 0) ? 0 : y;
            float _z = (Math.Abs(z) - 0.0001 < 0) ? 0 : z;
            return new Vector3(_x, _y, _z);
        }

        /// <summary>
        /// Store the minimum values of x, y, and z between the two vectors.
        /// </summary>
        /// <param name="v">Vector to check against</param>
        public void TakeMin(Vector3 v)
        {
            if (v.x < x) x = v.x;
            if (v.y < y) y = v.y;
            if (v.z < z) z = v.z;
        }

        /// <summary>
        /// Store the maximum values of x, y, and z between the two vectors.
        /// </summary>
        /// <param name="v">Vector to check against</param>
        public void TakeMax(Vector3 v)
        {
            if (v.x > x) x = v.x;
            if (v.y > y) y = v.y;
            if (v.z > z) z = v.z;
        }

        /// <summary>
        /// Returns the maximum component of the Vector3.
        /// </summary>
        /// <returns>The maximum component of the Vector3</returns>
        public float Max()
        {
            return (x >= y && x >= z) ? x : (y >= z) ? y : z;
        }

        /// <summary>
        /// Returns the minimum component of the Vector3.
        /// </summary>
        /// <returns>The minimum component of the Vector3</returns>
        public float Min()
        {
            return (x <= y && x <= z) ? x : (y <= z) ? y : z;
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
                if (t_axis.SquaredLength < (1e-12)) // pick another if colinear
                    t_axis = Vector3.UnitY.Cross(this);
                t_axis.Normalize();
                return Quaternion.FromAngleAxis((float)Math.PI, t_axis);
            }
            else
            {
                float t_sqrt = (float)Math.Sqrt((1 + d) * 2.0f);
                float t_invs = 1.0f / t_sqrt;

                Vector3 t_cross = t_source.Cross(t_dest);
                return new Quaternion(t_cross.x * t_invs, t_cross.y * t_invs, t_cross.z * t_invs, t_sqrt * 0.5f).Normalize();
            }
        }
        #endregion
    }
}
