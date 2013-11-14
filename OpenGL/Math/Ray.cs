using System;

namespace OpenGL
{
    /// <summary>
    /// A ray, brought in from Orchard Sun.
    /// </summary>
    public class Ray
    {
        #region Enumerations
        // Ray can be of 3 types per dimension, resulting in 27 types
        // Ray can be plus (P), zero (O) or minus (M)
        public enum RayType
        {
            MMM, MMP, MPM, MPP, PMM, PMP, PPM, PPP, POO, MOO, OPO, OMO, OOP, OOM,
            OMM, OMP, OPM, OPP, MOM, MOP, POM, POP, MMO, MPO, PMO, PPO
        };
        #endregion

        #region Variables
        private Vector3 origin;
        private Vector3 direction;
        private Vector3 inverse;
        private RayType classification;
        private float ibyj, jbyi, kbyj, jbyk, ibyk, kbyi;
        private float c_xy, c_xz, c_yx, c_yz, c_zx, c_zy;
        bool dirty = true;
        #endregion

        #region Properties
        /// <summary>
        /// Origin of the ray.  Ray = Origin + Direction * t
        /// </summary>
        public Vector3 Origin
        {
            get { return origin; }
            set { origin = value; dirty = true; }
        }

        /// <summary>
        /// Direction of the ray.  Ray = Origin + Direction * t
        /// </summary>
        public Vector3 Direction
        {
            get { return direction; }
            set { direction = value; dirty = true; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Standard ray constructor.  Ray must have an origin and distance
        /// </summary>
        /// <param name="Origin">Origin of the ray</param>
        /// <param name="Direction">Direction of the ray</param>
        public Ray(Vector3 Origin, Vector3 Direction)
        {
            origin = Origin;
            direction = Direction;
            PreCalculate();
        }

        /// <summary>
        /// Multiplies the ray by a value t to get the position at that point
        /// </summary>
        /// <param name="t">Value of t to multiple direction by</param>
        /// <returns>r_origin + r_direction * t</returns>
        public Vector3 GetPoint(float t)
        {
            return origin + (direction * t);
        }

        /// <summary>
        /// Multiplies the ray by a value t to get the position at that point
        /// </summary>
        /// <param name="r">Ray to find the point along</param>
        /// <param name="t">Value of t to multiple direction by</param>
        /// <returns>r_origin + r_direction * t</returns>
        public static Vector3 operator *(Ray r, float t)
        {
            return r.GetPoint(t);
        }
        #endregion

        #region Intersects
        /* AABB and Ray Intersection Algorithm
         * 
         * "Fast Ray / Axis-Aligned Bounding Box Overlap Tests using Ray Slopes"
         * by Martin Eisemann, Thorsten Grosch, Stefan Muller and Marcus Magnor
         * Computer Graphics Lab, TU Braunschweig, Germany and
         * University of Koblenz-Landau, Germany
         * 
         * Breaks the 3 dimensions into 3 planes (xy, yz, xz) to perform
         * trivial calculations to determine if an intersect has occured.
         * 
         * Conversion and Tweaking for Orchard Sun by Giawa */
        /// <summary>
        /// Precalculates the slopes and 2D projections for intersection tests.
        /// </summary>
        private void PreCalculate()
        {
            inverse = 1.0f / direction;
            ibyj = direction.x * inverse.y;
            jbyi = direction.y * inverse.x;
            jbyk = direction.y * inverse.z;
            kbyj = direction.z * inverse.y;
            ibyk = direction.x * inverse.z;
            kbyi = direction.z * inverse.x;
            c_xy = origin.y - jbyi * origin.x;
            c_xz = origin.z - kbyi * origin.x;
            c_yx = origin.x - ibyj * origin.y;
            c_yz = origin.z - kbyj * origin.y;
            c_zx = origin.x - ibyk * origin.z;
            c_zy = origin.y - jbyk * origin.z;
            if (direction.x < 0)
            {
                if (direction.y < 0)
                {
                    if (direction.z < 0) classification = RayType.MMM;
                    else if (direction.z > 0) classification = RayType.MMP;
                    else classification = RayType.MMO;
                }
                else
                {
                    if (direction.z < 0)
                    {
                        classification = RayType.MPM;
                        if (direction.y == 0)
                            classification = RayType.MOM;
                    }
                    else
                    {
                        if ((direction.y == 0) && (direction.z == 0)) classification = RayType.MOO;
                        else if (direction.z == 0) classification = RayType.MPO;
                        else if (direction.y == 0) classification = RayType.MOP;
                        else classification = RayType.MPP;
                    }
                }
            }
            else
            {
                if (direction.y < 0)
                {
                    if (direction.z < 0)
                    {
                        classification = RayType.PMM;
                        if (direction.x == 0) classification = RayType.OMM;
                    }
                    else
                    {
                        if ((direction.x == 0) && (direction.z == 0)) classification = RayType.OMO;
                        else if (direction.z == 0) classification = RayType.PMO;
                        else if (direction.x == 0) classification = RayType.OMP;
                        else classification = RayType.PMP;
                    }
                }
                else
                {
                    if (direction.z < 0)
                    {
                        if ((direction.x == 0) && (direction.y == 0)) classification = RayType.OOM;
                        else if (direction.x == 0) classification = RayType.OPM;
                        else if (direction.y == 0) classification = RayType.POM;
                        else classification = RayType.PPM;
                    }
                    else
                    {
                        if (direction.x == 0)
                        {
                            if (direction.y == 0) classification = RayType.OOP;
                            else if (direction.z == 0) classification = RayType.OPO;
                            else classification = RayType.OPP;
                        }
                        else
                        {
                            if ((direction.y == 0) && (direction.z == 0)) classification = RayType.POO;
                            else if (direction.y == 0) classification = RayType.POP;
                            else if (direction.z == 0) classification = RayType.PPO;
                            else classification = RayType.PPP;
                        }
                    }
                }
            }
            dirty = false;
        }

        /// <summary>
        /// Checks for an intersection between a ray and an AxisAlignedBoundingBox.
        /// Uses the algorithm "Fast Ray/Axis-Aligned Bounding Box Overlap Tests using Ray Slopes".
        /// </summary>
        /// <param name="b">BoundingBox to check</param>
        /// <returns>True if an intersection exists</returns>
        public bool Intersects(AxisAlignedBoundingBox b)
        {
            if (dirty) PreCalculate();

            switch (classification)
            {
                case RayType.MMM:
                    if ((origin.x < b.Min.x) || (origin.y < b.Min.y) || (origin.z < b.Min.z)
                        || (jbyi * b.Min.x - b.Max.y + c_xy > 0)
                        || (ibyj * b.Min.y - b.Max.x + c_yx > 0)
                        || (jbyk * b.Min.z - b.Max.y + c_zy > 0)
                        || (kbyj * b.Min.y - b.Max.z + c_yz > 0)
                        || (kbyi * b.Min.x - b.Max.z + c_xz > 0)
                        || (ibyk * b.Min.z - b.Max.x + c_zx > 0))
                        return false;
                    return true;
                case RayType.MMP:
                    if ((origin.x < b.Min.x) || (origin.y < b.Min.y) || (origin.z > b.Max.z)
                        || (jbyi * b.Min.x - b.Max.y + c_xy > 0)
                        || (ibyj * b.Min.y - b.Max.x + c_yx > 0)
                        || (jbyk * b.Max.z - b.Max.y + c_zy > 0)
                        || (kbyj * b.Min.y - b.Min.z + c_yz < 0)
                        || (kbyi * b.Min.x - b.Min.z + c_xz < 0)
                        || (ibyk * b.Max.z - b.Max.x + c_zx > 0))
                        return false;
                    return true;
                case RayType.MPM:
                    if ((origin.x < b.Min.x) || (origin.y > b.Max.y) || (origin.z < b.Min.z)
                        || (jbyi * b.Min.x - b.Min.y + c_xy < 0)
                        || (ibyj * b.Max.y - b.Max.x + c_yx > 0)
                        || (jbyk * b.Min.z - b.Min.y + c_zy < 0)
                        || (kbyj * b.Max.y - b.Max.z + c_yz > 0)
                        || (kbyi * b.Min.x - b.Max.z + c_xz > 0)
                        || (ibyk * b.Min.z - b.Max.x + c_zx > 0))
                        return false;
                    return true;
                case RayType.MPP:
                    if ((origin.x < b.Min.x) || (origin.y > b.Max.y) || (origin.z > b.Max.z)
                        || (jbyi * b.Min.x - b.Min.y + c_xy < 0)
                        || (ibyj * b.Max.y - b.Max.x + c_yx > 0)
                        || (jbyk * b.Max.z - b.Min.y + c_zy < 0)
                        || (kbyj * b.Max.y - b.Min.z + c_yz < 0)
                        || (kbyi * b.Min.x - b.Min.z + c_xz < 0)
                        || (ibyk * b.Max.z - b.Max.x + c_zx > 0))
                        return false;
                    return true;
                case RayType.PMM:
                    if ((origin.x > b.Max.x) || (origin.y < b.Min.y) || (origin.z < b.Min.z)
                        || (jbyi * b.Max.x - b.Max.y + c_xy > 0)
                        || (ibyj * b.Min.y - b.Min.x + c_yx < 0)
                        || (jbyk * b.Min.z - b.Max.y + c_zy > 0)
                        || (kbyj * b.Min.y - b.Max.z + c_yz > 0)
                        || (kbyi * b.Max.x - b.Max.z + c_xz > 0)
                        || (ibyk * b.Min.z - b.Min.x + c_zx < 0))
                        return false;
                    return true;
                case RayType.PMP:
                    if ((origin.x > b.Max.x) || (origin.y < b.Min.y) || (origin.z > b.Max.z)
                        || (jbyi * b.Max.x - b.Max.y + c_xy > 0)
                        || (ibyj * b.Min.y - b.Min.x + c_yx < 0)
                        || (jbyk * b.Max.z - b.Max.y + c_zy > 0)
                        || (kbyj * b.Min.y - b.Min.z + c_yz < 0)
                        || (kbyi * b.Max.x - b.Min.z + c_xz < 0)
                        || (ibyk * b.Max.z - b.Min.x + c_zx < 0))
                        return false;
                    return true;
                case RayType.PPM:
                    if ((origin.x > b.Max.x) || (origin.y > b.Max.y) || (origin.z < b.Min.z)
                        || (jbyi * b.Max.x - b.Min.y + c_xy < 0)
                        || (ibyj * b.Max.y - b.Min.x + c_yx < 0)
                        || (jbyk * b.Min.z - b.Min.y + c_zy < 0)
                        || (kbyj * b.Max.y - b.Max.z + c_yz > 0)
                        || (kbyi * b.Max.x - b.Max.z + c_xz > 0)
                        || (ibyk * b.Min.z - b.Min.x + c_zx < 0))
                        return false;
                    return true;
                case RayType.PPP:
                    if ((origin.x > b.Max.x) || (origin.y > b.Max.y) || (origin.z > b.Max.z)
                        || (jbyi * b.Max.x - b.Min.y + c_xy < 0)
                        || (ibyj * b.Max.y - b.Min.x + c_yx < 0)
                        || (jbyk * b.Max.z - b.Min.y + c_zy < 0)
                        || (kbyj * b.Max.y - b.Min.z + c_yz < 0)
                        || (kbyi * b.Max.x - b.Min.z + c_xz < 0)
                        || (ibyk * b.Max.z - b.Min.x + c_zx < 0))
                        return false;
                    return true;
                case RayType.OMM:
                    if ((origin.x < b.Min.x) || (origin.x > b.Max.x)
                        || (origin.y < b.Min.y) || (origin.z < b.Min.z)
                        || (jbyk * b.Min.z - b.Max.y + c_zy > 0)
                        || (kbyj * b.Min.y - b.Max.z + c_yz > 0))
                        return false;
                    return true;
                case RayType.OMP:
                    if ((origin.x < b.Min.x) || (origin.x > b.Max.x)
                        || (origin.y < b.Min.y) || (origin.z > b.Max.z)
                        || (jbyk * b.Max.z - b.Max.y + c_zy > 0)
                        || (kbyj * b.Min.y - b.Min.z + c_yz < 0))
                        return false;
                    return true;
                case RayType.OPM:
                    if ((origin.x < b.Min.x) || (origin.x > b.Max.x)
                        || (origin.y > b.Max.y) || (origin.z < b.Min.z)
                        || (jbyk * b.Min.z - b.Min.y + c_zy < 0)
                        || (kbyj * b.Max.y - b.Max.z + c_yz > 0))
                        return false;
                    return true;
                case RayType.OPP:
                    if ((origin.x < b.Min.x) || (origin.x > b.Max.x)
                        || (origin.y > b.Max.y) || (origin.z > b.Max.z)
                        || (jbyk * b.Max.z - b.Min.y + c_zy < 0)
                        || (kbyj * b.Max.y - b.Min.z + c_yz < 0))
                        return false;
                    return true;
                case RayType.MOM:
                    if ((origin.y < b.Min.y) || (origin.y > b.Max.y)
                        || (origin.x < b.Min.x) || (origin.z < b.Min.z)
                        || (kbyi * b.Min.x - b.Max.z + c_xz > 0)
                        || (ibyk * b.Min.z - b.Max.x + c_zx > 0))
                        return false;
                    return true;
                case RayType.MOP:
                    if ((origin.y < b.Min.y) || (origin.y > b.Max.y)
                        || (origin.x < b.Min.x) || (origin.z > b.Max.z)
                        || (kbyi * b.Min.x - b.Min.z + c_xz < 0)
                        || (ibyk * b.Max.z - b.Max.x + c_zx > 0))
                        return false;
                    return true;
                case RayType.POM:
                    if ((origin.y < b.Min.y) || (origin.y > b.Max.y)
                        || (origin.x > b.Max.x) || (origin.z < b.Min.z)
                        || (kbyi * b.Max.x - b.Max.z + c_xz > 0)
                        || (ibyk * b.Min.z - b.Min.x + c_zx < 0))
                        return false;
                    return true;
                case RayType.POP:
                    if ((origin.y < b.Min.y) || (origin.y > b.Max.y)
                        || (origin.x > b.Max.x) || (origin.z > b.Max.z)
                        || (kbyi * b.Max.x - b.Min.z + c_xz < 0)
                        || (ibyk * b.Max.z - b.Min.x + c_zx < 0))
                        return false;
                    return true;
                case RayType.MMO:
                    if ((origin.z < b.Min.z) || (origin.z > b.Max.z)
                        || (origin.x < b.Min.x) || (origin.y < b.Min.y)
                        || (jbyi * b.Min.x - b.Max.y + c_xy > 0)
                        || (ibyj * b.Min.y - b.Max.x + c_yx > 0))
                        return false;
                    return true;
                case RayType.MPO:
                    if ((origin.z < b.Min.z) || (origin.z > b.Max.z)
                        || (origin.x < b.Min.x) || (origin.y > b.Max.y)
                        || (jbyi * b.Min.x - b.Min.y + c_xy < 0)
                        || (ibyj * b.Max.y - b.Max.x + c_yx > 0))
                        return false;
                    return true;
                case RayType.PMO:
                    if ((origin.z < b.Min.z) || (origin.z > b.Max.z)
                        || (origin.x > b.Max.x) || (origin.y < b.Min.y)
                        || (jbyi * b.Max.x - b.Max.y + c_xy > 0)
                        || (ibyj * b.Min.y - b.Min.x + c_yx < 0))
                        return false;
                    return true;
                case RayType.PPO:
                    if ((origin.z < b.Min.z) || (origin.z > b.Max.z)
                        || (origin.x > b.Max.x) || (origin.y > b.Max.y)
                        || (jbyi * b.Max.x - b.Min.y + c_xy < 0)
                        || (ibyj * b.Max.y - b.Min.x + c_yx < 0))
                        return false;
                    return true;
                case RayType.MOO:
                    if ((origin.x < b.Min.x)
                        || (origin.y < b.Min.y) || (origin.y > b.Max.y)
                        || (origin.z < b.Min.z) || (origin.z > b.Max.z))
                        return false;
                    return true;
                case RayType.POO:
                    if ((origin.x > b.Max.x)
                        || (origin.y < b.Min.y) || (origin.y > b.Max.y)
                        || (origin.z < b.Min.z) || (origin.z > b.Max.z))
                        return false;
                    return true;
                case RayType.OMO:
                    if ((origin.y < b.Min.y)
                        || (origin.x < b.Min.x) || (origin.x > b.Max.x)
                        || (origin.z < b.Min.z) || (origin.z > b.Max.z))
                        return false;
                    if ((origin.y > b.Max.y)
                        || (origin.x < b.Min.x) || (origin.x > b.Max.x)
                        || (origin.z < b.Min.z) || (origin.z > b.Max.z))
                        return false;
                    if ((origin.z < b.Min.z)
                        || (origin.x < b.Min.x) || (origin.x > b.Max.x)
                        || (origin.y < b.Min.y) || (origin.y > b.Max.y))
                        return false;
                    if ((origin.z > b.Max.z)
                        || (origin.x < b.Min.x) || (origin.x > b.Max.x)
                        || (origin.y < b.Min.y) || (origin.y > b.Max.y))
                        return false;
                    return true;
                case RayType.OPO:
                    if ((origin.y > b.Max.y)
                        || (origin.x < b.Min.x) || (origin.x > b.Max.x)
                        || (origin.z < b.Min.z) || (origin.z > b.Max.z))
                        return false;
                    if ((origin.z < b.Min.z)
                        || (origin.x < b.Min.x) || (origin.x > b.Max.x)
                        || (origin.y < b.Min.y) || (origin.y > b.Max.y))
                        return false;
                    if ((origin.z > b.Max.z)
                        || (origin.x < b.Min.x) || (origin.x > b.Max.x)
                        || (origin.y < b.Min.y) || (origin.y > b.Max.y))
                        return false;
                    return true;
                case RayType.OOM:
                    if ((origin.z < b.Min.z)
                        || (origin.x < b.Min.x) || (origin.x > b.Max.x)
                        || (origin.y < b.Min.y) || (origin.y > b.Max.y))
                        return false;
                    if ((origin.z > b.Max.z)
                        || (origin.x < b.Min.x) || (origin.x > b.Max.x)
                        || (origin.y < b.Min.y) || (origin.y > b.Max.y))
                        return false;
                    return true;
                case RayType.OOP:
                    if ((origin.z > b.Max.z)
                        || (origin.x < b.Min.x) || (origin.x > b.Max.x)
                        || (origin.y < b.Min.y) || (origin.y > b.Max.y))
                        return false;
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks for an intersection between a ray and an OrientatedBoundingBox
        /// </summary>
        /// <param name="b">BoundingBox to check</param>
        /// <returns>True if an intersection exists</returns>
        public bool Intersects(OrientatedBoundingBox b)
        {
            Matrix4 inverse = b.Matrix.Inverse();
            Ray ray = new Ray(this.Origin * inverse, this.Direction * inverse);
            return ray.Intersects(new AxisAlignedBoundingBox(b.Min, b.Max));
        }
        #endregion
    }
}
