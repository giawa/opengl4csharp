using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenGL
{
    /// <summary>
    /// A 3d plane, brought in from Orchard Sun.
    /// </summary>
    public class Plane
    {
        #region Enumerations
        public enum PlaneSide
        {
            Negative, Positive, Both, None
        };
        #endregion

        #region Variables
        private float scalar;
        private Vector3 normal;
        #endregion

        #region Properties
        /// <summary>
        /// Fourth float representation of a plane
        /// </summary>
        public float Scalar
        {
            get { return scalar; }
            set { scalar = value; }
        }

        /// <summary>
        /// The normalized normal that represents the plane
        /// </summary>
        public Vector3 Normal
        {
            get { return normal; }
            set { normal = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Builds a plane from a scalar and vector3 normal
        /// </summary>
        /// <param name="Scalar">Scalar value</param>
        /// <param name="Normal">Normal to the plane</param>
        public Plane(float Scalar, Vector3 Normal)
        {
            Set(Scalar, Normal);
        }

        /// <summary>
        /// Builds a duplicate plane
        /// </summary>
        /// <param name="_Plane">Plane to duplicate</param>
        public Plane(Plane plane)
        {
            normal = plane.Normal;
            scalar = plane.Scalar;
        }

        /// <summary>
        /// Builds a plane from 3 points that represent the plane
        /// </summary>
        public Plane(Vector3 Point0, Vector3 Point1, Vector3 Point2)
        {
            FromPoints(Point0, Point1, Point2);
        }

        /// <summary>
        /// Builds a plane from four floats
        /// </summary>
        /// <param name="a">Normal.x</param>
        /// <param name="b">Normal.y</param>
        /// <param name="c">Normal.z</param>
        /// <param name="d">Scalar</param>
        public Plane(float a, float b, float c, float d)
        {
            normal = new Vector3(a, b, c);
            scalar = d;
        }

        /// <summary>
        /// Builds a plane from 3 points that represent the plane
        /// </summary>
        public void FromPoints(Vector3 Point0, Vector3 Point1, Vector3 Point2)
        {
            Vector3 t_edge1 = Point1 - Point0;
            Vector3 t_edge2 = Point2 - Point0;
            normal = Vector3.Cross(t_edge1, t_edge2).Normalize();
            scalar = Vector3.Dot(-normal, Point0);
        }

        /// <summary>
        /// Set new values for the scalar and normal
        /// </summary>
        /// <param name="Scalar">Scalar value</param>
        /// <param name="Normal">Normal to the plane</param>
        public void Set(float Scalar, Vector3 Normal)
        {
            scalar = Scalar;
            normal = Normal;
        }

        /// <summary>
        /// Check which side a AxisAlignedBoundingBox falls to on the plane
        /// </summary>
        /// <param name="b">AxisAlignedBoundingBox</param>
        /// <returns>PlaneSide.Negative, PlaneSide.Positive or PlaneSide.Both</returns>
        public PlaneSide Intersects(AxisAlignedBoundingBox b)
        {
            float t_distance = DistanceFromPoint(b.Center);
            float t_mdist = Math.Abs(Vector3.Dot(normal, b.Size * 0.5f));
            if (t_distance < -t_mdist) return PlaneSide.Negative;
            else if (t_distance > t_mdist) return PlaneSide.Positive;
            else return PlaneSide.Both;
        }

        /// <summary>
        /// Get the minimum distance from an arbitrary point and the plane
        /// </summary>
        /// <param name="Point">The Vector3 point to check</param>
        /// <returns>The minimum distance between the plane and point</returns>
        public float DistanceFromPoint(Vector3 Point)
        {
            return Vector3.Dot(Normal, Point) + scalar;
        }
        #endregion
    }
}
