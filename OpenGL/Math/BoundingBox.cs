using System;

#if USE_NUMERICS
using System.Numerics;
#endif

namespace OpenGL
{
    /// <summary>
    /// An axis aligned bounding box, brought in from Orchard Sun.
    /// </summary>
    public class AxisAlignedBoundingBox
    {
        #region Variables
        private Vector3 min;
        private Vector3 max;
        #endregion

        #region Properties
        /// <summary>
        /// The minimum x, y, and z values for the AxisAlignedBoundingBox.
        /// </summary>
        public Vector3 Min
        {
            get { return min; }
            set { min = value; }
        }

        /// <summary>
        /// The maximum x, y, and z values for the AxisAlignedBoundingBox.
        /// </summary>
        public Vector3 Max
        {
            get { return max; }
            set { max = value; }
        }

        /// <summary>
        /// The size of the AxisAlignedBoundingBox (Max - Min).
        /// </summary>
        public Vector3 Size
        {
            get { return max - min; }
        }

        /// <summary>
        /// The center of the AxisAlignedBoundingBox.
        /// </summary>
        public Vector3 Center
        {
            get { return (max + min) * 0.5f; }
        }

        /// <summary>
        /// Gets the radius of a sphere that would encapsulate the AxisAlignedBoundingBox.
        /// </summary>
        public float Radius
        {
            get
            {
                float t_length = Size.X;
                return (float)Math.Sqrt(t_length * t_length * 3) / 2.0f;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates an axis-aligned bounding box of size min, max.
        /// </summary>
        /// <param name="Min">Minimum x,y,z</param>
        /// <param name="Max">Maximum x,y,z</param>
        public AxisAlignedBoundingBox(Vector3 Min, Vector3 Max)
        {
            min = Min;
            max = Max;
        }

        /// <summary>
        /// Constructor used by QuadTrees and Octrees.
        /// </summary>
        public AxisAlignedBoundingBox()
        {
            min = Vector3.Zero;
            max = Vector3.Zero;
        }

        /// <summary>
        /// Set new extents for the axis-aligned bounding box.
        /// </summary>
        /// <param name="Min">Minimum x, y, z.</param>
        /// <param name="Max">Maximum x, y, z.</param>
        public void SetExtents(Vector3 Min, Vector3 Max)
        {
            min = Min;
            max = Max;
        }

        /// <summary>
        /// Increase the size of the bounding box (if needed) to fit the point within the box.
        /// </summary>
        /// <param name="Point">The point to fit into the AxisAlignedBoundingBox.</param>
        public void AddPoint(Vector3 Point)
        {
            min.TakeMin(Point);
            max.TakeMax(Point);
        }

        /// <summary>
        /// Clamp the point to within the boundary of the bounding box.
        /// </summary>
        /// <param name="Point">The point to clamp to the AxisAlignedBoundingBox.</param>
        /// <returns>The clamped point.</returns>
        public Vector3 ClampPoint(Vector3 Point)
        {
            return new Vector3((Point.X > Max.X) ? Max.X : (Point.X < Min.X) ? Min.X : Point.X,
                (Point.Y > Max.Y) ? Max.Y : (Point.Y < Min.Y) ? Min.Y : Point.Y,
                (Point.Z > Max.Z) ? Max.Z : (Point.Z < Min.Z) ? Min.Z : Point.Z);
        }

        /// <summary>
        /// Increase the size of the bounding box (if needed) to fit the AxisAlignedBoundingBox.
        /// </summary>
        /// <param name="Box">The AxisAlignedBoundingBox to fit into this AxisAlignedBoundingBox.</param>
        public void AddBoundingBox(AxisAlignedBoundingBox Box)
        {
            min.TakeMin(Box.Min);
            max.TakeMax(Box.Max);
        }

        /// <summary>
        /// Transforms the box by a Matrix4.  Will maintain the axis-alignment even during rotations.
        /// </summary>
        /// <param name="TranformMatrix">The Matrix4 to transform by.</param>
        public void Transform(Matrix4 TranformMatrix)
        {
            Vector3 t_min = min, t_max = max, t_corner;
            min = max = Vector3.Zero;

            // Compute corners in the order of 0, 6, 5, 1, 2, 4, 7, 3
            // Allows the code to change only one member at a time to get to all corners

            t_corner = t_min;       // min min min
            AddPoint(TranformMatrix * t_corner);
            t_corner.Z = t_max.Z;   // min min max
            AddPoint(TranformMatrix * t_corner);
            t_corner.Y = t_max.Y;   // min max max
            AddPoint(TranformMatrix * t_corner);
            t_corner.Z = t_min.Z;   // min max min
            AddPoint(TranformMatrix * t_corner);
            t_corner.X = t_max.X;   // max max min
            AddPoint(TranformMatrix * t_corner);
            t_corner.Z = t_max.Z;   // max max max
            AddPoint(TranformMatrix * t_corner);
            t_corner.Y = t_min.Y;   // max min max
            AddPoint(TranformMatrix * t_corner);
            t_corner.Z = t_min.Z;   // max min min
            AddPoint(TranformMatrix * t_corner);
        }

        /// <summary>
        /// Translates a box by a given translation vector.  Do this after rotating and scaling!
        /// </summary>
        /// <param name="Translation">Vector to translate by.</param>
        public void Translate(Vector3 Translation)
        {
            min += Translation;
            max += Translation;
        }
        #endregion

        #region Intersects
        /// <summary>
        /// Returns true if the vector intersects the AxisAlignedBoundingBox.
        /// </summary>
        /// <param name="v">Vector3 to test in the AxisAlignedBoundingBox.</param>
        /// <returns>True if the vector intersects the AxisAlignedBoundingBox.</returns>
        public bool Intersects(Vector3 v)
        {
            return (v.X >= min.X && v.X <= max.X && v.Y >= min.Y && v.Y <= max.Y && v.Z >= min.Z && v.Z <= max.Z);
        }

        /// <summary>
        /// Returns true if the ray intersects the AxisAlignedBoundingBox.
        /// </summary>
        /// <param name="r">Ray to test in the AxisAlignedBoundingBox.</param>
        /// <returns>True if the ray intersects the AxisAlignedBoundingBox.</returns>
        public bool Intersects(Ray r)
        {
            return r.Intersects(this);
        }

        /// <summary>
        /// Returns the position of the AxisAlignedBoudingBox relative to a plane.
        /// </summary>
        /// <param name="p">Plane to test.</param>
        /// <returns>Negative, Positive or Both sides of plane.</returns>
        public Plane.PlaneSide Intersects(Plane p)
        {
            return p.Intersects(this);
        }

        /// <summary>
        /// Returns true if the AxisAlignedBoundingBox is within the frustum.
        /// Cheats by using spherical representation of the bounding box.
        /// </summary>
        /// <param name="f">The Frustum to check for intersections with.</param>
        /// <returns>True if the spherical representation of the AxisAlignedBoundingBox is withing the frustum.</returns>
        public bool Intersects(Frustum f)
        {
            return f.Intersects(this);
        }

        /// <summary>
        /// Returns true if the AxisAlignedBoundingBox intersects this AxisAlignedBoundingBox.
        /// </summary>
        /// <param name="b">AxisAlignedBoundingBox to test in this AxisAlignedBoundingBox.</param>
        /// <returns>True if the AxisAlignedBoundingBox intersects this AxisAlignedBoundingBox.</returns>
        public bool Intersects(AxisAlignedBoundingBox b)
        {
            // Test the six planes of the box
            if (max.X < b.Min.X) return false;
            if (max.Y < b.Min.Y) return false;
            if (max.Z < b.Min.Z) return false;
            if (min.X > b.Max.X) return false;
            if (min.Y > b.Max.Y) return false;
            if (min.Z > b.Max.Z) return false;

            // Must be intersecting if all planes check out
            return true;
        }

        /// <summary>
        /// Returns the intersection of the two AxisAlignedBoundingBox objects if an intersection exists.
        /// </summary>
        /// <param name="b">AxisAlignedBoundingBox to intersect with this AxisAlignedBoundingBox.</param>
        /// <returns>The intersection of the two AxisAlignedBoundingBox objects.</returns>
        public AxisAlignedBoundingBox Intersection(AxisAlignedBoundingBox b)
        {
            Vector3 t_min = min;
            Vector3 t_max = max;
            t_min.TakeMax(b.Min);
            t_max.TakeMin(b.Max);
            if (t_min.X < t_max.X && t_min.Y < t_max.Y && t_min.Z < t_max.Z)
                return new AxisAlignedBoundingBox(t_min, t_max);
            return null;    // Must be no intersection
        }

        /// <summary>
        /// Returns true if the point lies within the AxisAlignedBoundingBox.
        /// </summary>
        /// <param name="Position">The point in 3D space.</param>
        /// <returns>True if the AABB contains the point.</returns>
        public bool Contains(Vector3 Position)
        {
            return (Position.X >= min.X && Position.X <= max.X &&
                Position.Y >= min.Y && Position.Y <= max.Y &&
                Position.Z >= min.Z && Position.Z <= max.Z);
        }
        #endregion
    }

    /// <summary>
    /// An oriented bounding box, brought in from Orchard Sun.
    /// </summary>
    public class OrientatedBoundingBox
    {
        #region Variables
        private AxisAlignedBoundingBox box;
        private Matrix4 modelMatrix;
        #endregion

        #region Properties
        /// <summary>
        /// The minimum x, y, and z values for the OrientatedBoundingBox.
        /// </summary>
        public Vector3 Min
        {
            get { return box.Min; }
            set { box.Min = value; }
        }

        /// <summary>
        /// The maximum x, y, and z values for the OrientatedBoundingBox.
        /// </summary>
        public Vector3 Max
        {
            get { return box.Max; }
            set { box.Max = value; }
        }

        /// <summary>
        /// The size of the OrientatedBoundingBox (Max - Min).
        /// </summary>
        public Vector3 Size
        {
            get { return box.Size; }
        }

        /// <summary>
        /// The Matrix4 representing the transformation of the underlying AABB.
        /// </summary>
        public Matrix4 Matrix
        {
            get { return modelMatrix; }
            set { modelMatrix = value; }
        }

        /// <summary>
        /// The underlying AABB structure that is mainpulated by the model matrix.
        /// </summary>
        public AxisAlignedBoundingBox BoundingBox
        {
            get { return box; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates an orientated bounding box of size min, max.
        /// </summary>
        /// <param name="Min">Minimum x, y, z.</param>
        /// <param name="Max">Maximum x, y, z.</param>
        public OrientatedBoundingBox(Vector3 Min, Vector3 Max)
        {
            box = new AxisAlignedBoundingBox(Min, Max);
            modelMatrix = Matrix4.Identity;
        }

        /// <summary>
        /// Set new extents for the orientated bounding box.
        /// </summary>
        /// <param name="Min">Minimum x, y, z.</param>
        /// <param name="Max">Maximum x, y, z.</param>
        public void SetExtents(Vector3 Min, Vector3 Max)
        {
            box.SetExtents(Min, Max);
        }
        #endregion

        #region Intersects
        /// <summary>
        /// Returns true if the ray intersects the OrientatedBoundingBox.
        /// </summary>
        /// <param name="r">Ray to test in the OrientatedBoundingBox.</param>
        /// <returns>True if the ray intersects the OrientatedBoundingBox.</returns>
        public bool Intersects(Ray r)
        {
            return r.Intersects(this);
        }
        #endregion
    }
}
