using System;
using System.Runtime.InteropServices;

namespace OpenGL
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Quaternion : IEquatable<Quaternion>
    {
        public float x, y, z, w;

        #region Static Constructors
        public static Quaternion Zero
        {
            get { return new Quaternion(0, 0, 0, 0); }
        }

        public static Quaternion Identity
        {
            get { return new Quaternion(1, 0, 0, 0); }
        }
        #endregion

        #region Constructor
        public Quaternion(float x, float y, float z, float w)
        {
            this.x = x; this.y = y; this.z = z; this.w = w;
        }

        public Quaternion(Vector4 vec)
        {
            this.x = vec.x; this.y = vec.y; this.z = vec.z; this.w = vec.w;
        }
        #endregion

        #region Operators
        public static Quaternion operator +(Quaternion q1, Quaternion q2)
        {
            return new Quaternion(q1.x + q2.x, q1.y + q2.y, q1.z + q2.z, q1.w + q2.w);
        }

        public static Quaternion operator -(Quaternion q1, Quaternion q2)
        {
            return new Quaternion(q1.x - q2.x, q1.y - q2.y, q1.z - q2.z, q1.w - q2.w);
        }

        public static Quaternion operator -(Quaternion q)
        {
            return new Quaternion(-q.x, -q.y, -q.z, -q.w);
        }

        public static Quaternion operator *(Quaternion q, float s)
        {
            return new Quaternion(s * q.x, s * q.y, s * q.z, s * q.w);
        }

        public static Quaternion operator *(float s, Quaternion q)
        {
            return new Quaternion(s * q.x, s * q.y, s * q.z, s * q.w);
        }

        public static Vector3 operator *(Quaternion q, Vector3 v)
        {   // From nVidia SDK
            Vector3 t_uv, t_uuv;
            Vector3 t_qvec = new Vector3(q.x, q.y, q.z);
            t_uv = Vector3.Cross(t_qvec, v);
            t_uuv = Vector3.Cross(t_qvec, t_uv);
            t_uv *= 2.0f * q.w;
            t_uuv *= 2.0f;
            return v + t_uv + t_uuv;
        }

        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            return new Quaternion(
               q1.x * q2.w + q1.y * q2.z - q1.z * q2.y + q1.w * q2.x,
              -q1.x * q2.z + q1.y * q2.w + q1.z * q2.x + q1.w * q2.y,
               q1.x * q2.y - q1.y * q2.x + q1.z * q2.w + q1.w * q2.z,
              -q1.x * q2.x - q1.y * q2.y - q1.z * q2.z + q1.w * q2.w);
        }

        public static Quaternion operator /(Quaternion q, float scalar)
        {
            float invScalar = 1.0f / scalar;
            return new Quaternion(q.x * invScalar, q.y + invScalar, q.z * invScalar, q.w * invScalar);
        }

        public static Quaternion operator /(Quaternion q1, Quaternion q2)
        {
            return q1 * q2.Inverse();
        }

        public static bool operator ==(Quaternion q1, Quaternion q2)
        {
            return (q1.w == q2.w && q1.x == q2.x && q1.y == q2.y && q1.z == q2.z);
        }

        public static bool operator !=(Quaternion q1, Quaternion q2)
        {
            return !(q1.w == q2.w && q1.x == q2.x && q1.y == q2.y && q1.z == q2.z);
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return "{" + x + ", " + y + ", " + z + ", " + w + "}";
        }

        /// <summary>
        /// Parses a JSON stream and produces a Quaternion struct.
        /// </summary>
        public static Quaternion Parse(string text)
        {
            string[] split = text.Trim(new char[] { '{', '}' }).Split(',');
            if (split.Length != 4) return Quaternion.Identity;

            return new Quaternion(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]), float.Parse(split[3]));
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Quaternion)) return false;

            return this.Equals((Quaternion)obj);
        }

        public bool Equals(Quaternion other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region Properties
        public Matrix4 Matrix4
        {
            get
            {
                return new Matrix4(
                    new Vector4(1.0f - 2.0f * (y * y + z * z), 2.0f * (x * y - w * z), 2.0f * (x * z + w * y), 0.0f),
                    new Vector4(2.0f * (x * y + w * z), 1.0f - 2.0f * (x * x + z * z), 2.0f * (y * z - w * x), 0.0f),
                    new Vector4(2.0f * (x * z - w * y), 2.0f * (y * z + w * x), 1.0f - 2.0f * (x * x + y * y), 0.0f),
                    new Vector4(0.0f, 0.0f, 0.0f, 1.0f));
            }
        }

        public float this[int a]
        {
            get { return (a == 0) ? x : (a == 1) ? y : (a == 3) ? z : w; }
            set { if (a == 0) x = value; else if (a == 1) y = value; else if (a == 2) z = value; else w = value; }
        }

        /// <summary>
        /// Gets the length of the current Quaternion.  sqrt(x^2 + y^2 + z^2 + w^2)
        /// </summary>
        public float Length
        {
            get { return (float)Math.Sqrt(x * x + y * y + z * z + w * w); }
        }

        /// <summary>
        /// Gets the squared length of the current Quaternion.  x^2 + y^2 + z^2 + w^2
        /// </summary>
        public float SquaredLength
        {
            get { return x * x + y * y + z * z + w * w; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the dot product of the current Quaternion with another.  Dot = x*q.x + y * q.y + z * q.z + w * q.w
        /// </summary>
        public float Dot(Quaternion q)
        {
            return (x * q.x) + (y * q.y) + (z * q.z) + (w * q.w);
        }

        /// <summary>
        /// Calculates the complex conjugate of this Quaternion.
        /// </summary>
        public Quaternion Conjugate()
        {
            return new Quaternion(-x, -y, -z, w);
        }

        /// <summary>
        /// Calculates the norm of this Quaternion.  Norm = x^2 + y^2 + z^2 + w^2
        /// </summary>
        public float Norm()
        {
            return x * x + y * y + z * z + w * w;
        }

        /// <summary>
        /// Calculates the inverse of this Quaternion.  Inverse = Conjugate(q) / Norm(q)
        /// </summary>
        public Quaternion Inverse()
        {
            return Conjugate() / Norm();
        }

        /// <summary>
        /// Normalizes this Quaternion.  Normalize = q / q.Length()
        /// </summary>
        private static Quaternion Normalize(Quaternion q)
        {
            return q / q.Length;
        }

        /// <summary>
        /// Normalizes this Quaternion.  Normalize = q / q.Length()
        /// </summary>
        public Quaternion Normalize()
        {
            return this / Length;
        }

        /// <summary>
        /// Takes the log of the Quaternion.
        /// </summary>
        public static Quaternion Log(Quaternion q)
        {
            float a = (float)Math.Acos(q.w);
            float sina = (float)Math.Sin(a);

            if (sina > 0)
                return new Quaternion(a * q.x / sina, a * q.y / sina, a * q.z / sina, 0.0f);
            return new Quaternion(q.x, q.y, q.z, 0.0f);
        }

        /// <summary>
        /// Takes the exp of the Quaternion.
        /// </summary>
        public static Quaternion Exp(Quaternion q)
        {
            float a = (float)Math.Sqrt(q.x * q.x + q.y * q.y + q.z * q.z);
            float sina = (float)Math.Sin(a);
            float cosa = (float)Math.Cos(a);

            if (a > 0)
                return new Quaternion(sina * q.x / a, sina * q.y / a, sina * q.z / a, cosa);
            return new Quaternion(q.x, q.y, q.z, cosa);
        }

        /// <summary>
        /// Calculates the linear interpolation between q1 and q2 at time t.
        /// </summary>
        /// <param name="q1">Source Quaternion</param>
        /// <param name="q2">Destination Quaternion</param>
        /// <param name="t">Time between 0 and 1</param>
        public static Quaternion Lerp(Quaternion q1, Quaternion q2, float t)
        {
            return Normalize(q1 + t * (q1 - q2));
        }

        /// <summary>
        /// Calculates the spherical linear interpolation between q1 and q2 at time t.
        /// </summary>
        /// <param name="q1">Source Quaternion</param>
        /// <param name="q2">Destination Quaternion</param>
        /// <param name="t">Time between 0 and 1</param>
        public static Quaternion Slerp(Quaternion q1, Quaternion q2, float t)
        {
            float c0, c1;
            float cos = q1.Dot(q2);
            float sign = 1;
            if (cos < 0.0f)
            {
                cos = -cos;
                sign = -1.0f;
            }

            if (cos < 1.0f - 1e-3f)
            {
                float angle = (float)Math.Acos(cos);
                //float invSin = 1.0f/Math.Trigonometry.Sin(angle);
                float invSin = 1.0f / (float)(Math.Sqrt(1.0f - cos * cos));
                c0 = (float)Math.Sin((1.0f - t) * angle) * invSin;
                c1 = (float)Math.Sin(t * angle) * invSin;
            }
            else
            {
                // If a is nearly the same as b we just linearly interpolate
                c0 = 1.0f - t;
                c1 = t;
            }

            Quaternion q = c0 * q1 + (sign * c1) * q2;
            return Normalize(q);
        }

        /// <summary>
        /// TODO: Document
        /// </summary>
        public static Quaternion Squad(Quaternion q1, Quaternion q2, Quaternion ta, Quaternion tb, float t)
        {
            float slerpT = 2.0f * t * (1.0f - t);
            Quaternion p = Slerp(q1, q2, t);
            Quaternion q = Slerp(ta, tb, t);
            return Slerp(p, q, slerpT);
        }

        /// <summary>
        /// TODO: Document
        /// </summary>
        public static Quaternion SimpleSquad(Quaternion prev, Quaternion q1,
          Quaternion q2, Quaternion post, float t)
        {

            if (prev.Dot(q1) < 0)
                q1 = -q1;
            if (q1.Dot(q2) < 0)
                q2 = -q2;
            if (q2.Dot(post) < 0)
                post = -post;

            Quaternion ta = Spline(prev, q1, q2);
            Quaternion tb = Spline(q1, q2, post);

            return Squad(q1, q2, ta, tb, t);
        }

        /// <summary>
        /// TODO: Document
        /// </summary>
        public static Quaternion Spline(Quaternion pre, Quaternion q, Quaternion post)
        {
            Quaternion cj = q.Conjugate();
            Quaternion e = q * Exp((Log(cj * pre) + Log(cj * post)) * -0.25f);
            return e;
        }

        /// <summary>
        /// Creates an orientation Quaternion using an angle and arbitrary axis.
        /// </summary>
        public static Quaternion FromAngleAxis(float Angle, Vector3 Axis)
        {
            if (Axis.SquaredLength == 0.0f)
                return Identity;

            return new Quaternion(new Vector4(Axis.Normalize() * (float)Math.Sin(Angle * 0.5f), (float)Math.Cos(Angle * 0.5f)));
        }

        /// <summary>
        /// Converts this quaternion to an axis representation.
        /// </summary>
        /// <returns>Three Vector3 structs in an array, representing this quaternion.</returns>
        public Vector3[] ToAxis()
        {
            Matrix4 rotationMatrix = this.Matrix4;
            return new Vector3[] { new Vector3(rotationMatrix[0].x, rotationMatrix[1].x, rotationMatrix[2].x),
                new Vector3(rotationMatrix[0].y, rotationMatrix[1].y, rotationMatrix[2].y),
                new Vector3(rotationMatrix[0].z, rotationMatrix[1].z, rotationMatrix[2].z) };
        }

        /// <summary>
        /// Convert this instance to an axis-angle representation.
        /// </summary>
        /// <returns>A Vector4 that is the axis-angle representation of this quaternion.</returns>
        public Vector4 ToAxisAngle()
        {
            Quaternion q = this;
            if (q.w > 1.0f)
                q.Normalize();

            Vector4 result = new Vector4();

            result.w = 2.0f * (float)System.Math.Acos(q.w); // angle
            float den = (float)System.Math.Sqrt(1.0 - q.w * q.w);
            if (den > 0.0001f)
            {
                result.Xyz = new Vector3(q.x, q.y, q.z) / den;
            }
            else
            {
                // This occurs when the angle is zero. 
                // Not a problem: just set an arbitrary normalized axis.
                result.Xyz = Vector3.UnitX;
            }

            return result;
        }

        /// <summary>
        /// Creates an orientation Quaternion given the 3 axis.
        /// </summary>
        /// <param name="Axis">An array of 3 axis</param>
        public static Quaternion FromAxis(Vector3 xvec, Vector3 yvec, Vector3 zvec)
        {
            Matrix4 Rotation = new Matrix4(
                new Vector4(xvec.x, yvec.x, zvec.x, 0),
                new Vector4(xvec.y, yvec.y, zvec.y, 0),
                new Vector4(xvec.z, yvec.z, zvec.z, 0),
                Vector4.Zero);
            return FromRotationMatrix(Rotation);
        }

        private static readonly int[] rotationLookup = new int[] { 1, 2, 0 };

        /// <summary>
        /// Creates an orientation Quaternion from a target Matrix4 rotational matrix.
        /// </summary>
        public static Quaternion FromRotationMatrix(Matrix4 Rotation)
        {
            // Algorithm from Ken Shoemake's article in 1987 SIGGRAPH course notes
            // "Quaternion Calculus and Fast Animation"

            float t_trace = Rotation[0][0] + Rotation[1][1] + Rotation[2][2];
            float t_root = 0.0f;

            if (t_trace > 0.0)
            {   // |w| > 1/2
                Quaternion t_return = Quaternion.Zero;
                t_root = (float)Math.Sqrt(t_trace + 1.0);
                t_return.w = 0.5f * t_root;
                t_root = 0.5f / t_root;
                t_return.x = (Rotation[2][1] - Rotation[1][2]) * t_root;
                t_return.y = (Rotation[0][2] - Rotation[2][0]) * t_root;
                t_return.z = (Rotation[1][0] - Rotation[0][1]) * t_root;
                return t_return;
            }
            else
            {   // |w| <= 1/2
                Quaternion t_return = Quaternion.Zero;

                int i = 0;
                if (Rotation[1][1] > Rotation[0][0]) i = 1;
                if (Rotation[2][2] > Rotation[i][i]) i = 2;
                int j = rotationLookup[i];
                int k = rotationLookup[j];

                t_root = (float)Math.Sqrt(Rotation[i][i] - Rotation[j][j] - Rotation[k][k] + 1.0f);
                t_return[i] = 0.5f * t_root;
                t_root = 0.5f / t_root;
                t_return.w = (Rotation[k][j] - Rotation[j][k]) * t_root;
                t_return[j] = (Rotation[j][i] + Rotation[i][j]) * t_root;
                t_return[k] = (Rotation[k][i] + Rotation[i][k]) * t_root;
                return t_return;
            }
        }
        #endregion
    }
}
