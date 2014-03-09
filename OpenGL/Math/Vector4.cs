using System;
using System.Runtime.InteropServices;

namespace OpenGL
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4 : IEquatable<Vector4>
    {
        public float x, y, z, w;

        #region Static Constructors
        public static Vector4 Identity
        {
            get { return new Vector4(1.0f, 1.0f, 1.0f, 1.0f); }
        }

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
            get { return new Vector4(0.0, 1.0f, 0.0f, 0.0f); }
        }

        public static Vector4 UnitZ
        {
            get { return new Vector4(0.0, 0.0f, 1.0f, 0.0f); }
        }

        public static Vector4 UnitW
        {
            get { return new Vector4(0.0, 0.0f, 0.0f, 1.0f); }
        }
        #endregion

        #region Operators
        public static Vector4 operator +(Vector4 v1, Vector4 v2)
        {
            return new Vector4(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z, v1.w + v2.w);
        }

        public static Vector4 operator +(Vector4 v, float s)
        {
            return new Vector4(v.x + s, v.y + s, v.z + s, v.w + s);
        }

        public static Vector4 operator +(float s, Vector4 v)
        {
            return new Vector4(v.x + s, v.y + s, v.z + s, v.w + s);
        }

        public static Vector4 operator -(Vector4 v1, Vector4 v2)
        {
            return new Vector4(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z, v1.w - v2.w);
        }

        public static Vector4 operator -(Vector4 v, float s)
        {
            return new Vector4(v.x - s, v.y - s, v.z - s, v.w - s);
        }

        public static Vector4 operator -(float s, Vector4 v)
        {
            return new Vector4(s - v.x, s - v.y, s - v.z, s - v.w);
        }

        public static Vector4 operator -(Vector4 v)
        {
            return new Vector4(-v.x, -v.y, -v.z, -v.w);
        }

        public static Vector4 operator *(Vector4 v1, Vector4 v2)
        {
            return new Vector4(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z, v1.w * v2.w);
        }

        public static Vector4 operator *(float s, Vector4 v)
        {
            return new Vector4(v.x * s, v.y * s, v.z * s, v.w * s);
        }

        public static Vector4 operator *(Vector4 v, float s)
        {
            return new Vector4(v.x * s, v.y * s, v.z * s, v.w * s);
        }

        public static Vector4 operator /(Vector4 v1, Vector4 v2)
        {
            return new Vector4(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z, v1.w / v2.w);
        }

        public static Vector4 operator /(float s, Vector4 v)
        {
            return new Vector4(s / v.x, s / v.y, s / v.z, s / v.w);
        }

        public static Vector4 operator /(Vector4 v, float s)
        {
            return new Vector4(v.x / s, v.y / s, v.z / s, v.w / s);
        }

        public static bool operator ==(Vector4 v1, Vector4 v2)
        {
            return (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z && v1.w == v2.w);
        }

        public static bool operator !=(Vector4 v1, Vector4 v2)
        {
            return (v1.x != v2.x || v1.y != v2.y || v1.z != v2.z || v1.w != v2.w);
        }
        #endregion

        #region Constructors
        /// <summary>Create a Vector4 structure.</summary>
        /// <param name="x">x value</param>
        /// <param name="y">y value</param>
        /// <param name="z">z value</param>
        /// <param name="w">w value</param>
        public Vector4(float x, float y, float z, float w)
        {
            this.x = x; this.y = y; this.z = z; this.w = w;
        }

        /// <summary>Creates a Vector4 structure.  Casted to floats for OpenGL.</summary>
        /// <param name="x">x value</param>
        /// <param name="y">y value</param>
        /// <param name="z">z value</param>
        /// <param name="w">w value</param>
        public Vector4(double x, double y, double z, double w)
        {
            this.x = (float)x; this.y = (float)y; this.z = (float)z; this.w = (float)w;
        }

        /// <summary>Creates a Vector4 structure based on a Vector3 and w.</summary>
        /// <param name="v">Vector3 to make up x,y,z</param>
        /// <param name="w">Double to make up the w component</param>
        public Vector4(Vector3 v, float w)
        {
            x = v.x; y = v.y; z = v.z; this.w = w;
        }

        /// <summary>
        /// Accepts a 24 bit color value and assumes an alpha of 1.0f.
        /// </summary>
        /// <param name="RGBByte">24bit color value</param>
        public Vector4(byte[] RGBByte)
        {
            if (RGBByte.Length < 3) throw new Exception("Color data was not 24bit as expected.");
            x = (float)(RGBByte[0] / 256.0); y = (float)(RGBByte[1] / 256.0); z = (float)(RGBByte[2] / 256.0); w = 1.0f;
        }

        /// <summary>Creates a Vector4 tructure from a float array (assuming the float array is of length 4).</summary>
        /// <param name="vector">The float array to convert to a Vector4.</param>
        public Vector4(float[] vector)
        {
            if (vector.Length != 4) throw new Exception(string.Format("float[] vector was of length {0}.  Was expecting a length of 4.", vector.Length));
            this.x = vector[0]; this.y = vector[1]; this.z = vector[2]; this.w = vector[3];
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "{" + x + ", " + y + ", " + z + ", " + w + "}";
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

        public float this[int a]
        {
            get { return (a == 0) ? x : (a == 1) ? y : (a == 2) ? z : w; }
            set
            {
                if (a == 0) x = value;
                else if (a == 1) y = value;
                else if (a == 2) z = value;
                else if (a == 3) w = value;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get the length of the Vector4 structure.
        /// </summary>
        public float Length
        {
            get { return (float)Math.Sqrt(x * x + y * y + z * z + w * w); }
        }

        /// <summary>
        /// Get the squared length of the Vector4 structure.
        /// </summary>
        public float SquaredLength
        {
            get { return x * x + y * y + z * z + w * w; }
        }

        /// <summary>
        /// Gets or sets an OpenGl.Types.Vector2 with the x and y components of this instance.
        /// </summary>
        public Vector2 Xy { get { return new Vector2(x, y); } set { x = value.x; y = value.y; } }

        /// <summary>
        /// Gets or sets an OpenGl.Types.Vector3 with the x, y and z components of this instance.
        /// </summary>
        public Vector3 Xyz { get { return new Vector3(x, y, z); } set { x = value.x; y = value.y; z = value.z; } }
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
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z + v1.w * v2.w;
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
            return new float[] { x, y, z, w };
        }

        /// <summary>
        /// Normalizes the Vector4 structure to have a peak value of one.
        /// </summary>
        /// <returns>if (Length = 0) return Zero; else return Vector4(x,y,z,w)/Length</returns>
        public Vector4 Normalize()
        {
            if (Length == 0) return Zero;
            else return new Vector4(x, y, z, w) / Length;
        }

        /// <summary>
        /// Checks to see if any value (x, y, z, w) are within 0.0001 of 0.
        /// If so this method truncates that value to zero.
        /// </summary>
        /// <returns>A truncated Vector4</returns>
        public Vector4 Truncate()
        {
            float _x = (Math.Abs(x) - 0.0001 < 0) ? 0 : x;
            float _y = (Math.Abs(y) - 0.0001 < 0) ? 0 : y;
            float _z = (Math.Abs(z) - 0.0001 < 0) ? 0 : z;
            float _w = (Math.Abs(w) - 0.0001 < 0) ? 0 : w;
            return new Vector4(_x, _y, _z, _w);
        }

        /// <summary>
        /// Store the minimum values of x, y, z, and w between the two vectors.
        /// </summary>
        /// <param name="v">Vector to check against</param>
        public void TakeMin(Vector4 v)
        {
            if (v.x < x) x = v.x;
            if (v.y < y) y = v.y;
            if (v.z < z) z = v.z;
            if (v.w < w) w = v.w;
        }

        /// <summary>
        /// Store the maximum values of x, y, z, and w  between the two vectors.
        /// </summary>
        /// <param name="v">Vector to check against</param>
        public void TakeMax(Vector4 v)
        {
            if (v.x > x) x = v.x;
            if (v.y > y) y = v.y;
            if (v.z > z) z = v.z;
            if (v.w > w) w = v.w;
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
        #endregion
    }
}
