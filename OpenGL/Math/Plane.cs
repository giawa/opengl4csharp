using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if USE_NUMERICS
using System.Numerics;
#endif

namespace OpenGL
{
    /// <summary>
    /// A 3d plane, brought in from Orchard Sun.
    /// </summary>
    public class Plane : IEquatable<Plane>
    {
        #region Enumerations
        public enum PlaneSide
        {
            Negative, Positive, Both, None
        };
        #endregion

        #region Properties
        /// <summary>
        /// The distance of the plane along its normal from the origin.
        /// </summary>
        public float D { get; set; }

        /// <summary>
        /// The normal that represents the plane.
        /// </summary>
        public Vector3 Normal { get; set; }

        [Obsolete("Use D instead, which is compatible with System.Numerics.")]
        public float Scalar
        {
            get { return D; }
            set { D = value; }
        }
        #endregion

        #region Operators
        public static bool operator ==(Plane v1, Plane v2)
        {
            return (v1.Normal == v2.Normal && v1.D == v2.D);
        }

        public static bool operator !=(Plane v1, Plane v2)
        {
            return (v1.Normal != v2.Normal || v1.D != v2.D);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Builds a plane from a scalar and vector3 normal.
        /// </summary>
        /// <param name="Scalar">Scalar value.</param>
        /// <param name="Normal">Normal to the plane.</param>
        public Plane(float Scalar, Vector3 Normal)
        {
            Set(Scalar, Normal);
        }

        /// <summary>
        /// Builds a duplicate plane.
        /// </summary>
        /// <param name="plane">Plane to duplicate.</param>
        public Plane(Plane plane)
        {
            Normal = plane.Normal;
            D = plane.D;
        }

        /// <summary>
        /// Builds a plane from 3 points that represent the plane.
        /// </summary>
        public Plane(Vector3 Point0, Vector3 Point1, Vector3 Point2)
        {
            FromPoints(Point0, Point1, Point2);
        }

        /// <summary>
        /// Builds a plane from four floats.
        /// </summary>
        /// <param name="a">Normal.x</param>
        /// <param name="b">Normal.y</param>
        /// <param name="c">Normal.z</param>
        /// <param name="d">Scalar</param>
        public Plane(float a, float b, float c, float d)
        {
            Normal = new Vector3(a, b, c);
            D = d;
        }

        /// <summary>
        /// Builds a plane from 3 points that represent the plane.
        /// </summary>
        public void FromPoints(Vector3 Point0, Vector3 Point1, Vector3 Point2)
        {
            Vector3 edge1 = Point1 - Point0;
            Vector3 edge2 = Point2 - Point0;
            Normal = Vector3.Cross(edge1, edge2).Normalize();
            D = Vector3.Dot(-Normal, Point0);
        }

        /// <summary>
        /// Set new values for the scalar and normal.
        /// </summary>
        /// <param name="scalar">Scalar value.</param>
        /// <param name="normal">Normal to the plane.</param>
        public void Set(float scalar, Vector3 normal)
        {
            D = scalar;
            Normal = normal;
        }

        /// <summary>
        /// Check which side a AxisAlignedBoundingBox falls to on the plane.
        /// </summary>
        /// <param name="box">AxisAlignedBoundingBox.</param>
        /// <returns>PlaneSide.Negative, PlaneSide.Positive or PlaneSide.Both.</returns>
        public PlaneSide Intersects(AxisAlignedBoundingBox box)
        {
            float distance = DistanceFromPoint(box.Center);
            float mdist = Math.Abs(Vector3.Dot(Normal, box.Size * 0.5f));
            if (distance < -mdist) return PlaneSide.Negative;
            else if (distance > mdist) return PlaneSide.Positive;
            else return PlaneSide.Both;
        }

        /// <summary>
        /// Get the minimum distance from an arbitrary point and the plane.
        /// </summary>
        /// <param name="Point">The Vector3 point to check.</param>
        /// <returns>The minimum distance between the plane and point.</returns>
        public float DistanceFromPoint(Vector3 Point)
        {
            return Vector3.Dot(Normal, Point) + D;
        }

        public bool Equals(Plane plane)
        {
            return this == plane;
        }

        public override bool Equals(object obj)
        {
            if (obj is Plane)
            {
                return this == ((Plane)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a string representing this Plane.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return string.Format("Normal: {0} D: {1}", Normal, D);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return Normal.GetHashCode() + D.GetHashCode();
        }
        #endregion
    }
}
