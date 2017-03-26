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
    public struct Quaternion : IEquatable<Quaternion>
    {
        public float X, Y, Z, W;

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

        /// <summary>
        /// Maintains backwards compatible with legacy OpenGL library code (prior to USE_NUMERICS).
        /// </summary>
        [Obsolete("Use W instead, which is compatible with System.Numerics.")]
        public float w
        {
            get { return W; }
            set { W = value; }
        }
#pragma warning restore

        #region Static Constructors
        public static Quaternion Zero
        {
            get { return new Quaternion(0, 0, 0, 0); }
        }

        public static Quaternion Identity
        {
            get { return new Quaternion(0, 0, 0, 1); }
        }
        #endregion

        #region Constructor
        public Quaternion(float x, float y, float z, float w)
        {
            this.X = x; this.Y = y; this.Z = z; this.W = w;
        }

        public Quaternion(Vector4 vec)
        {
            this.X = vec.X; this.Y = vec.Y; this.Z = vec.Z; this.W = vec.W;
        }
        #endregion

        #region Operators
        public static Quaternion operator +(Quaternion q1, Quaternion q2)
        {
            return new Quaternion(q1.X + q2.X, q1.Y + q2.Y, q1.Z + q2.Z, q1.W + q2.W);
        }

        public static Quaternion operator -(Quaternion q1, Quaternion q2)
        {
            return new Quaternion(q1.X - q2.X, q1.Y - q2.Y, q1.Z - q2.Z, q1.W - q2.W);
        }

        public static Quaternion operator -(Quaternion q)
        {
            return new Quaternion(-q.X, -q.Y, -q.Z, -q.W);
        }

        public static Quaternion operator *(Quaternion q, float s)
        {
            return new Quaternion(s * q.X, s * q.Y, s * q.Z, s * q.W);
        }

        public static Quaternion operator *(float s, Quaternion q)
        {
            return new Quaternion(s * q.X, s * q.Y, s * q.Z, s * q.W);
        }

        public static Vector3 operator *(Quaternion q, Vector3 v)
        {   // From nVidia SDK
            Vector3 t_uv, t_uuv;
            Vector3 t_qvec = new Vector3(q.X, q.Y, q.Z);
            t_uv = Vector3.Cross(t_qvec, v);
            t_uuv = Vector3.Cross(t_qvec, t_uv);
            t_uv *= 2.0f * q.W;
            t_uuv *= 2.0f;
            return v + t_uv + t_uuv;
        }

        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            return new Quaternion(
               q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y + q1.W * q2.X,
              -q1.X * q2.Z + q1.Y * q2.W + q1.Z * q2.X + q1.W * q2.Y,
               q1.X * q2.Y - q1.Y * q2.X + q1.Z * q2.W + q1.W * q2.Z,
              -q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z + q1.W * q2.W);
        }

        public static Quaternion operator /(Quaternion q, float scalar)
        {
            float invScalar = 1.0f / scalar;
            return new Quaternion(q.X * invScalar, q.Y * invScalar, q.Z * invScalar, q.W * invScalar);
        }

        public static Quaternion operator /(Quaternion q1, Quaternion q2)
        {
            return q1 * q2.Inverse();
        }

        public static bool operator ==(Quaternion q1, Quaternion q2)
        {
            return (q1.W == q2.W && q1.X == q2.X && q1.Y == q2.Y && q1.Z == q2.Z);
        }

        public static bool operator !=(Quaternion q1, Quaternion q2)
        {
            return !(q1.W == q2.W && q1.X == q2.X && q1.Y == q2.Y && q1.Z == q2.Z);
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Returns a string representing this Quaternion.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return string.Format("<{0}, {1}, {2}, {3}>", X, Y, Z, W);
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

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code.</returns>
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
                    new Vector4(1.0f - 2.0f * (Y * Y + Z * Z), 2.0f * (X * Y - W * Z), 2.0f * (X * Z + W * Y), 0.0f),
                    new Vector4(2.0f * (X * Y + W * Z), 1.0f - 2.0f * (X * X + Z * Z), 2.0f * (Y * Z - W * X), 0.0f),
                    new Vector4(2.0f * (X * Z - W * Y), 2.0f * (Y * Z + W * X), 1.0f - 2.0f * (X * X + Y * Y), 0.0f),
                    new Vector4(0.0f, 0.0f, 0.0f, 1.0f));
            }
        }

        public float this[int a]
        {
            get { return (a == 0) ? X : (a == 1) ? Y : (a == 3) ? Z : W; }
            set { if (a == 0) X = value; else if (a == 1) Y = value; else if (a == 2) Z = value; else W = value; }
        }

        /// <summary>
        /// Gets the length of the current Quaternion.  sqrt(x^2 + y^2 + z^2 + w^2)
        /// </summary>
        public float Length
        {
            get { return (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W); }
        }

        /// <summary>
        /// Gets the squared length of the current Quaternion.  x^2 + y^2 + z^2 + w^2
        /// </summary>
        public float SquaredLength
        {
            get { return X * X + Y * Y + Z * Z + W * W; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the dot product of the current Quaternion with another.  Dot = x*q.x + y * q.y + z * q.z + w * q.w
        /// </summary>
        public float Dot(Quaternion q)
        {
            return (X * q.X) + (Y * q.Y) + (Z * q.Z) + (W * q.W);
        }

        /// <summary>
        /// Calculates the complex conjugate of this Quaternion.
        /// </summary>
        public Quaternion Conjugate()
        {
            return new Quaternion(-X, -Y, -Z, W);
        }

        /// <summary>
        /// Calculates the norm of this Quaternion.  Norm = x^2 + y^2 + z^2 + w^2
        /// </summary>
        public float Norm()
        {
            return X * X + Y * Y + Z * Z + W * W;
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
            float a = (float)Math.Acos(q.W);
            float sina = (float)Math.Sin(a);

            if (sina > 0)
                return new Quaternion(a * q.X / sina, a * q.Y / sina, a * q.Z / sina, 0.0f);
            return new Quaternion(q.X, q.Y, q.Z, 0.0f);
        }

        /// <summary>
        /// Takes the exp of the Quaternion.
        /// </summary>
        public static Quaternion Exp(Quaternion q)
        {
            float a = (float)Math.Sqrt(q.X * q.X + q.Y * q.Y + q.Z * q.Z);
            float sina = (float)Math.Sin(a);
            float cosa = (float)Math.Cos(a);

            if (a > 0)
                return new Quaternion(sina * q.X / a, sina * q.Y / a, sina * q.Z / a, cosa);
            return new Quaternion(q.X, q.Y, q.Z, cosa);
        }

        /// <summary>
        /// Calculates the linear interpolation between q1 and q2 at time t.
        /// </summary>
        /// <param name="q1">Source Quaternion.</param>
        /// <param name="q2">Destination Quaternion.</param>
        /// <param name="t">Time between 0 and 1.</param>
        public static Quaternion Lerp(Quaternion q1, Quaternion q2, float t)
        {
            return Normalize(q1 + t * (q1 - q2));
        }

        /// <summary>
        /// Calculates the spherical linear interpolation between q1 and q2 at time t.
        /// </summary>
        /// <param name="q1">Source Quaternion.</param>
        /// <param name="q2">Destination Quaternion.</param>
        /// <param name="t">Time between 0 and 1.</param>
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

            return c0 * q1 + (sign * c1) * q2;
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
            if (Axis.LengthSquared() == 0.0f)
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
            return new Vector3[] { new Vector3(rotationMatrix[0].X, rotationMatrix[1].X, rotationMatrix[2].X),
                new Vector3(rotationMatrix[0].Y, rotationMatrix[1].Y, rotationMatrix[2].Y),
                new Vector3(rotationMatrix[0].Z, rotationMatrix[1].Z, rotationMatrix[2].Z) };
        }

        /// <summary>
        /// Convert this instance to an axis-angle representation.
        /// </summary>
        /// <returns>A Vector4 that is the axis-angle representation of this quaternion.</returns>
        public Vector4 ToAxisAngle()
        {
            Quaternion q = this;
            if (q.W > 1.0f)
                q.Normalize();

            float w = 2.0f * (float)System.Math.Acos(q.W); // angle
            float den = (float)System.Math.Sqrt(1.0 - q.W * q.W);
            if (den > 0.0001f)
            {
                return new Vector4(new Vector3(q.X, q.Y, q.Z) / den, w);
            }
            else
            {
                // This occurs when the angle is zero. 
                // Not a problem: just set an arbitrary normalized axis.
                return new Vector4(Vector3.UnitX, w);
            }
        }

        /// <summary>
        /// Creates an orientation Quaternion given the 3 axis.
        /// </summary>
        /// <param name="Axis">An array of 3 axis.</param>
        public static Quaternion FromAxis(Vector3 xvec, Vector3 yvec, Vector3 zvec)
        {
            Matrix4 Rotation = new Matrix4(
                new Vector4(xvec.X, yvec.X, zvec.X, 0),
                new Vector4(xvec.Y, yvec.Y, zvec.Y, 0),
                new Vector4(xvec.Z, yvec.Z, zvec.Z, 0),
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

            float t_trace = Rotation[0].X + Rotation[1].Y + Rotation[2].Z;
            float t_root = 0.0f;

            if (t_trace > 0.0)
            {   // |w| > 1/2
                Quaternion t_return = Quaternion.Zero;
                t_root = (float)Math.Sqrt(t_trace + 1.0);
                t_return.W = 0.5f * t_root;
                t_root = 0.5f / t_root;
                t_return.X = (Rotation[2].Y - Rotation[1].Z) * t_root;
                t_return.Y = (Rotation[0].Z - Rotation[2].X) * t_root;
                t_return.Z = (Rotation[1].X - Rotation[0].Y) * t_root;
                return t_return;
            }
            else
            {   // |w| <= 1/2
                Quaternion t_return = Quaternion.Zero;

                int i = 0;
                if (Rotation[1].Y > Rotation[0].X) i = 1;
                if (Rotation[2].Z > Rotation[i].Get(i)) i = 2;
                int j = rotationLookup[i];
                int k = rotationLookup[j];

                t_root = (float)Math.Sqrt(Rotation[i].Get(i) - Rotation[j].Get(j) - Rotation[k].Get(k) + 1.0f);
                t_return[i] = 0.5f * t_root;
                t_root = 0.5f / t_root;
                t_return.W = (Rotation[k].Get(j) - Rotation[j].Get(k)) * t_root;
                t_return[j] = (Rotation[j].Get(i) + Rotation[i].Get(j)) * t_root;
                t_return[k] = (Rotation[k].Get(i) + Rotation[i].Get(k)) * t_root;
                return t_return;
            }
        }
        #endregion
    }
#else
    /// <summary>
    /// Extension methods for the Quaternion structure.
    /// </summary>
    public static class QuaternionExtensions
    {
        /// <summary>
        /// Convert this instance to an axis-angle representation.
        /// </summary>
        /// <returns>A Vector4 that is the axis-angle representation of this quaternion.</returns>
        public static Vector4 ToAxisAngle(this Quaternion q)
        {
            if (q.W > 1.0f)
                q = Quaternion.Normalize(q);

            float w = 2.0f * (float)System.Math.Acos(q.W); // angle
            float den = (float)System.Math.Sqrt(1.0 - q.W * q.W);
            if (den > 0.0001f)
            {
                return new Vector4(new Vector3(q.X, q.Y, q.Z) / den, w);
            }
            else
            {
                // This occurs when the angle is zero. 
                // Not a problem: just set an arbitrary normalized axis.
                return new Vector4(Vector3.UnitX, w);
            }
        }
    }
#endif
}
