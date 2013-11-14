using System;

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
        /// The minimum x, y, and z values for the AxisAlignedBoundingBox
        /// </summary>
        public Vector3 Min
        {
            get { return min; }
            set { min = value; }
        }

        /// <summary>
        /// The maximum x, y, and z values for the AxisAlignedBoundingBox
        /// </summary>
        public Vector3 Max
        {
            get { return max; }
            set { max = value; }
        }

        /// <summary>
        /// The size of the AxisAlignedBoundingBox.  (Max - Min)
        /// </summary>
        public Vector3 Size
        {
            get { return max - min; }
        }

        /// <summary>
        /// The center of the AxisAlignedBoundingBox
        /// </summary>
        public Vector3 Center
        {
            get { return new Vector3((max.x + min.x) * 0.5, (max.y + min.y) * 0.5, (max.z + min.z) * 0.5); }
        }

        /// <summary>
        /// Gets the radius of a sphere that would encapsulate the AxisAlignedBoundingBox
        /// </summary>
        public float Radius
        {
            get
            {
                float t_length = Size.x;
                return (float)Math.Sqrt(t_length * t_length * 3) / 2.0f;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates an axis-aligned bounding box of size min, max
        /// </summary>
        /// <param name="Min">Minimum x,y,z</param>
        /// <param name="Max">Maximum x,y,z</param>
        public AxisAlignedBoundingBox(Vector3 Min, Vector3 Max)
        {
            min = Min;
            max = Max;
        }

        /// <summary>
        /// Constructor used by QuadTrees and Octrees
        /// </summary>
        public AxisAlignedBoundingBox()
        {
            min = Vector3.Zero;
            max = Vector3.Zero;
        }

        /// <summary>
        /// Set new extents for the axis-aligned bounding box
        /// </summary>
        /// <param name="Min">Minimum x,y,z</param>
        /// <param name="Max">Maximum x,y,z</param>
        public void SetExtents(Vector3 Min, Vector3 Max)
        {
            min = Min;
            max = Max;
        }

        /// <summary>
        /// Increase the size of the bounding box (if needed) to fit the point within the box
        /// </summary>
        /// <param name="Point">The point to fit into the AxisAlignedBoundingBox</param>
        public void AddPoint(Vector3 Point)
        {
            min.TakeMin(Point);
            max.TakeMax(Point);
        }

        /// <summary>
        /// Clamp the point to within the boundary of the bounding box
        /// </summary>
        /// <param name="Point">The point to clamp to the AxisAlignedBoundingBox</param>
        /// <returns>The clamped point</returns>
        public Vector3 ClampPoint(Vector3 Point)
        {
            return new Vector3((Point.x > Max.x) ? Max.x : (Point.x < Min.x) ? Min.x : Point.x,
                (Point.y > Max.y) ? Max.y : (Point.y < Min.y) ? Min.y : Point.y,
                (Point.z > Max.z) ? Max.z : (Point.z < Min.z) ? Min.z : Point.z);
        }

        /// <summary>
        /// Increase the size of the bounding box (if needed) to fit the AxisAlignedBoundingBox
        /// </summary>
        /// <param name="Box">The AxisAlignedBoundingBox to fit into this AxisAlignedBoundingBox</param>
        public void AddBoundingBox(AxisAlignedBoundingBox Box)
        {
            min.TakeMin(Box.Min);
            max.TakeMax(Box.Max);
        }

        /// <summary>
        /// Transforms the box by a Matrix4.  Will maintain the axis-alignment even during rotations.
        /// </summary>
        /// <param name="TranformMatrix">The Matrix4 to transform by</param>
        public void Transform(Matrix4 TranformMatrix)
        {
            Vector3 t_min = min, t_max = max, t_corner;
            min = max = Vector3.Zero;
            // Compute corners in the order of 0, 6, 5, 1, 2, 4, 7, 3
            // Allows the code to change only one member at a time to get to all corners

            t_corner = t_min;       // min min min
            AddPoint(TranformMatrix * t_corner);
            t_corner.z = t_max.z;   // min min max
            AddPoint(TranformMatrix * t_corner);
            t_corner.y = t_max.y;   // min max max
            AddPoint(TranformMatrix * t_corner);
            t_corner.z = t_min.z;   // min max min
            AddPoint(TranformMatrix * t_corner);
            t_corner.x = t_max.x;   // max max min
            AddPoint(TranformMatrix * t_corner);
            t_corner.z = t_max.z;   // max max max
            AddPoint(TranformMatrix * t_corner);
            t_corner.y = t_min.y;   // max min max
            AddPoint(TranformMatrix * t_corner);
            t_corner.z = t_min.z;   // max min min
            AddPoint(TranformMatrix * t_corner);
        }

        /// <summary>
        /// Translates a box by a given translation vector.  Do this after rotating and scaling!
        /// </summary>
        /// <param name="Translation">Vector to translate by</param>
        public void Translate(Vector3 Translation)
        {
            min += Translation;
            max += Translation;
        }
        #endregion

        #region Intersects
        /// <summary>
        /// Returns true if the vector intersects the AxisAlignedBoundingBox
        /// </summary>
        /// <param name="v">Vector3 to test in the AxisAlignedBoundingBox</param>
        /// <returns>True if the vector intersects the AxisAlignedBoundingBox</returns>
        public bool Intersects(Vector3 v)
        {
            return (v.x >= min.x && v.x <= max.x && v.y >= min.y && v.y <= max.y && v.z >= min.z && v.z <= max.z);
        }

        /// <summary>
        /// Returns true if the ray intersects the AxisAlignedBoundingBox
        /// </summary>
        /// <param name="r">Ray to test in the AxisAlignedBoundingBox</param>
        /// <returns>True if the ray intersects the AxisAlignedBoundingBox</returns>
        public bool Intersects(Ray r)
        {
            return r.Intersects(this);
        }

        /// <summary>
        /// Returns the position of the AxisAlignedBoudingBox relative to a plane
        /// </summary>
        /// <param name="p">Plane to test</param>
        /// <returns>Negative, Positive or Both sides of plane</returns>
        public Plane.PlaneSide Intersects(Plane p)
        {
            return p.Intersects(this);
        }

        /// <summary>
        /// Returns true if the AxisAlignedBoundingBox is within the frustum.  Cheats by using spherical representation of the bounding box.
        /// </summary>
        /// <param name="f">The Frustum to check for intersections with</param>
        /// <returns>True if the spherical representation of the AxisAlignedBoundingBox is withing the frustum</returns>
        public bool Intersects(Frustum f)
        {
            return f.Intersects(this);
        }

        /// <summary>
        /// Returns true if the AxisAlignedBoundingBox intersects this AxisAlignedBoundingBox
        /// </summary>
        /// <param name="b">AxisAlignedBoundingBox to test in this AxisAlignedBoundingBox</param>
        /// <returns>True if the AxisAlignedBoundingBox intersects this AxisAlignedBoundingBox</returns>
        public bool Intersects(AxisAlignedBoundingBox b)
        {
            // Test the six planes of the box
            if (max.x < b.Min.x) return false;
            if (max.y < b.Min.y) return false;
            if (max.z < b.Min.z) return false;
            if (min.x > b.Max.x) return false;
            if (min.y > b.Max.y) return false;
            if (min.z > b.Max.z) return false;

            // Must be intersecting if all planes check out
            return true;
        }

        /// <summary>
        /// Returns the intersection of the two AxisAlignedBoundingBox objects if an intersection exists
        /// </summary>
        /// <param name="b">AxisAlignedBoundingBox to intersect with this AxisAlignedBoundingBox</param>
        /// <returns>The intersection of the two AxisAlignedBoundingBox objects</returns>
        public AxisAlignedBoundingBox Intersection(AxisAlignedBoundingBox b)
        {
            Vector3 t_min = min;
            Vector3 t_max = max;
            t_min.TakeMax(b.Min);
            t_max.TakeMin(b.Max);
            if (t_min.x < t_max.x && t_min.y < t_max.y && t_min.z < t_max.z)
                return new AxisAlignedBoundingBox(t_min, t_max);
            return null;    // Must be no intersection
        }

        /// <summary>
        /// Returns true if the point lies within the AxisAlignedBoundingBox
        /// </summary>
        /// <param name="Position">The point in 3D space</param>
        /// <returns>True if the AABB contains the point</returns>
        public bool Contains(Vector3 Position)
        {
            return (Position.x >= min.x && Position.x <= max.x &&
                Position.y >= min.y && Position.y <= max.y &&
                Position.z >= min.z && Position.z <= max.z);
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
        /// The minimum x, y, and z values for the OrientatedBoundingBox
        /// </summary>
        public Vector3 Min
        {
            get { return box.Min; }
            set { box.Min = value; }
        }

        /// <summary>
        /// The maximum x, y, and z values for the OrientatedBoundingBox
        /// </summary>
        public Vector3 Max
        {
            get { return box.Max; }
            set { box.Max = value; }
        }

        /// <summary>
        /// The size of the OrientatedBoundingBox.  (Max - Min)
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
        /// Creates an orientated bounding box of size min, max
        /// </summary>
        /// <param name="Min">Minimum x,y,z</param>
        /// <param name="Max">Maximum x,y,z</param>
        public OrientatedBoundingBox(Vector3 Min, Vector3 Max)
        {
            box = new AxisAlignedBoundingBox(Min, Max);
            modelMatrix = Matrix4.Identity;
        }

        /// <summary>
        /// Set new extents for the orientated bounding box
        /// </summary>
        /// <param name="Min">Minimum x,y,z</param>
        /// <param name="Max">Maximum x,y,z</param>
        public void SetExtents(Vector3 Min, Vector3 Max)
        {
            box.SetExtents(Min, Max);
        }
        #endregion

        #region Intersects
        /// <summary>
        /// Returns true if the ray intersects the OrientatedBoundingBox
        /// </summary>
        /// <param name="r">Ray to test in the OrientatedBoundingBox</param>
        /// <returns>True if the ray intersects the OrientatedBoundingBox</returns>
        public bool Intersects(Ray r)
        {
            return r.Intersects(this);
        }
        #endregion
    }
}
