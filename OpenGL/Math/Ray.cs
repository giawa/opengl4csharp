using System;

#if USE_NUMERICS
using System.Numerics;
#endif

namespace OpenGL
{
    /// <summary>
    /// A ray, brought in from Orchard Sun.
    /// </summary>
    public class Ray
    {
        #region Enumerations
        /// <summary>
        /// Ray can be of 3 types per dimension, resulting in 27 types
        /// Ray can be plus (P), zero (O) or minus (M)
        /// </summary>
        public enum RayType
        {
#pragma warning disable CS1591
            MMM, MMP, MPM, MPP, PMM, PMP, PPM, PPP, POO, MOO, OPO, OMO, OOP, OOM,
            OMM, OMP, OPM, OPP, MOM, MOP, POM, POP, MMO, MPO, PMO, PPO
#pragma warning restore
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
        /// Standard ray constructor.  Ray must have an origin and distance.
        /// </summary>
        /// <param name="Origin">Origin of the ray.</param>
        /// <param name="Direction">Direction of the ray.</param>
        public Ray(Vector3 Origin, Vector3 Direction)
        {
            origin = Origin;
            direction = Direction;
            PreCalculate();
        }

        /// <summary>
        /// Multiplies the ray by a value t to get the position at that point.
        /// </summary>
        /// <param name="t">Value of t to multiple direction by.</param>
        /// <returns>r_origin + r_direction * t.</returns>
        public Vector3 GetPoint(float t)
        {
            return origin + (direction * t);
        }

        /// <summary>
        /// Multiplies the ray by a value t to get the position at that point.
        /// </summary>
        /// <param name="r">Ray to find the point along.</param>
        /// <param name="t">Value of t to multiple direction by.</param>
        /// <returns>r_origin + r_direction * t.</returns>
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
            inverse = new Vector3(1.0f / direction.X, 1.0f / direction.Y, 1.0f / direction.Z);
            ibyj = direction.X * inverse.Y;
            jbyi = direction.Y * inverse.X;
            jbyk = direction.Y * inverse.Z;
            kbyj = direction.Z * inverse.Y;
            ibyk = direction.X * inverse.Z;
            kbyi = direction.Z * inverse.X;
            c_xy = origin.Y - jbyi * origin.X;
            c_xz = origin.Z - kbyi * origin.X;
            c_yx = origin.X - ibyj * origin.Y;
            c_yz = origin.Z - kbyj * origin.Y;
            c_zx = origin.X - ibyk * origin.Z;
            c_zy = origin.Y - jbyk * origin.Z;

            if (direction.X < 0)
            {
                if (direction.Y < 0)
                {
                    if (direction.Z < 0) classification = RayType.MMM;
                    else if (direction.Z > 0) classification = RayType.MMP;
                    else classification = RayType.MMO;
                }
                else
                {
                    if (direction.Z < 0)
                    {
                        classification = RayType.MPM;
                        if (direction.Y == 0)
                            classification = RayType.MOM;
                    }
                    else
                    {
                        if ((direction.Y == 0) && (direction.Z == 0)) classification = RayType.MOO;
                        else if (direction.Z == 0) classification = RayType.MPO;
                        else if (direction.Y == 0) classification = RayType.MOP;
                        else classification = RayType.MPP;
                    }
                }
            }
            else
            {
                if (direction.Y < 0)
                {
                    if (direction.Z < 0)
                    {
                        classification = RayType.PMM;
                        if (direction.X == 0) classification = RayType.OMM;
                    }
                    else
                    {
                        if ((direction.X == 0) && (direction.Z == 0)) classification = RayType.OMO;
                        else if (direction.Z == 0) classification = RayType.PMO;
                        else if (direction.X == 0) classification = RayType.OMP;
                        else classification = RayType.PMP;
                    }
                }
                else
                {
                    if (direction.Z < 0)
                    {
                        if ((direction.X == 0) && (direction.Y == 0)) classification = RayType.OOM;
                        else if (direction.X == 0) classification = RayType.OPM;
                        else if (direction.Y == 0) classification = RayType.POM;
                        else classification = RayType.PPM;
                    }
                    else
                    {
                        if (direction.X == 0)
                        {
                            if (direction.Y == 0) classification = RayType.OOP;
                            else if (direction.Z == 0) classification = RayType.OPO;
                            else classification = RayType.OPP;
                        }
                        else
                        {
                            if ((direction.Y == 0) && (direction.Z == 0)) classification = RayType.POO;
                            else if (direction.Y == 0) classification = RayType.POP;
                            else if (direction.Z == 0) classification = RayType.PPO;
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
        /// <param name="b">BoundingBox to check.</param>
        /// <returns>True if an intersection exists.</returns>
        public bool Intersects(AxisAlignedBoundingBox b)
        {
            if (dirty) PreCalculate();

            switch (classification)
            {
                case RayType.MMM:
                    if ((origin.X < b.Min.X) || (origin.Y < b.Min.Y) || (origin.Z < b.Min.Z)
                        || (jbyi * b.Min.X - b.Max.Y + c_xy > 0)
                        || (ibyj * b.Min.Y - b.Max.X + c_yx > 0)
                        || (jbyk * b.Min.Z - b.Max.Y + c_zy > 0)
                        || (kbyj * b.Min.Y - b.Max.Z + c_yz > 0)
                        || (kbyi * b.Min.X - b.Max.Z + c_xz > 0)
                        || (ibyk * b.Min.Z - b.Max.X + c_zx > 0))
                        return false;
                    return true;
                case RayType.MMP:
                    if ((origin.X < b.Min.X) || (origin.Y < b.Min.Y) || (origin.Z > b.Max.Z)
                        || (jbyi * b.Min.X - b.Max.Y + c_xy > 0)
                        || (ibyj * b.Min.Y - b.Max.X + c_yx > 0)
                        || (jbyk * b.Max.Z - b.Max.Y + c_zy > 0)
                        || (kbyj * b.Min.Y - b.Min.Z + c_yz < 0)
                        || (kbyi * b.Min.X - b.Min.Z + c_xz < 0)
                        || (ibyk * b.Max.Z - b.Max.X + c_zx > 0))
                        return false;
                    return true;
                case RayType.MPM:
                    if ((origin.X < b.Min.X) || (origin.Y > b.Max.Y) || (origin.Z < b.Min.Z)
                        || (jbyi * b.Min.X - b.Min.Y + c_xy < 0)
                        || (ibyj * b.Max.Y - b.Max.X + c_yx > 0)
                        || (jbyk * b.Min.Z - b.Min.Y + c_zy < 0)
                        || (kbyj * b.Max.Y - b.Max.Z + c_yz > 0)
                        || (kbyi * b.Min.X - b.Max.Z + c_xz > 0)
                        || (ibyk * b.Min.Z - b.Max.X + c_zx > 0))
                        return false;
                    return true;
                case RayType.MPP:
                    if ((origin.X < b.Min.X) || (origin.Y > b.Max.Y) || (origin.Z > b.Max.Z)
                        || (jbyi * b.Min.X - b.Min.Y + c_xy < 0)
                        || (ibyj * b.Max.Y - b.Max.X + c_yx > 0)
                        || (jbyk * b.Max.Z - b.Min.Y + c_zy < 0)
                        || (kbyj * b.Max.Y - b.Min.Z + c_yz < 0)
                        || (kbyi * b.Min.X - b.Min.Z + c_xz < 0)
                        || (ibyk * b.Max.Z - b.Max.X + c_zx > 0))
                        return false;
                    return true;
                case RayType.PMM:
                    if ((origin.X > b.Max.X) || (origin.Y < b.Min.Y) || (origin.Z < b.Min.Z)
                        || (jbyi * b.Max.X - b.Max.Y + c_xy > 0)
                        || (ibyj * b.Min.Y - b.Min.X + c_yx < 0)
                        || (jbyk * b.Min.Z - b.Max.Y + c_zy > 0)
                        || (kbyj * b.Min.Y - b.Max.Z + c_yz > 0)
                        || (kbyi * b.Max.X - b.Max.Z + c_xz > 0)
                        || (ibyk * b.Min.Z - b.Min.X + c_zx < 0))
                        return false;
                    return true;
                case RayType.PMP:
                    if ((origin.X > b.Max.X) || (origin.Y < b.Min.Y) || (origin.Z > b.Max.Z)
                        || (jbyi * b.Max.X - b.Max.Y + c_xy > 0)
                        || (ibyj * b.Min.Y - b.Min.X + c_yx < 0)
                        || (jbyk * b.Max.Z - b.Max.Y + c_zy > 0)
                        || (kbyj * b.Min.Y - b.Min.Z + c_yz < 0)
                        || (kbyi * b.Max.X - b.Min.Z + c_xz < 0)
                        || (ibyk * b.Max.Z - b.Min.X + c_zx < 0))
                        return false;
                    return true;
                case RayType.PPM:
                    if ((origin.X > b.Max.X) || (origin.Y > b.Max.Y) || (origin.Z < b.Min.Z)
                        || (jbyi * b.Max.X - b.Min.Y + c_xy < 0)
                        || (ibyj * b.Max.Y - b.Min.X + c_yx < 0)
                        || (jbyk * b.Min.Z - b.Min.Y + c_zy < 0)
                        || (kbyj * b.Max.Y - b.Max.Z + c_yz > 0)
                        || (kbyi * b.Max.X - b.Max.Z + c_xz > 0)
                        || (ibyk * b.Min.Z - b.Min.X + c_zx < 0))
                        return false;
                    return true;
                case RayType.PPP:
                    if ((origin.X > b.Max.X) || (origin.Y > b.Max.Y) || (origin.Z > b.Max.Z)
                        || (jbyi * b.Max.X - b.Min.Y + c_xy < 0)
                        || (ibyj * b.Max.Y - b.Min.X + c_yx < 0)
                        || (jbyk * b.Max.Z - b.Min.Y + c_zy < 0)
                        || (kbyj * b.Max.Y - b.Min.Z + c_yz < 0)
                        || (kbyi * b.Max.X - b.Min.Z + c_xz < 0)
                        || (ibyk * b.Max.Z - b.Min.X + c_zx < 0))
                        return false;
                    return true;
                case RayType.OMM:
                    if ((origin.X < b.Min.X) || (origin.X > b.Max.X)
                        || (origin.Y < b.Min.Y) || (origin.Z < b.Min.Z)
                        || (jbyk * b.Min.Z - b.Max.Y + c_zy > 0)
                        || (kbyj * b.Min.Y - b.Max.Z + c_yz > 0))
                        return false;
                    return true;
                case RayType.OMP:
                    if ((origin.X < b.Min.X) || (origin.X > b.Max.X)
                        || (origin.Y < b.Min.Y) || (origin.Z > b.Max.Z)
                        || (jbyk * b.Max.Z - b.Max.Y + c_zy > 0)
                        || (kbyj * b.Min.Y - b.Min.Z + c_yz < 0))
                        return false;
                    return true;
                case RayType.OPM:
                    if ((origin.X < b.Min.X) || (origin.X > b.Max.X)
                        || (origin.Y > b.Max.Y) || (origin.Z < b.Min.Z)
                        || (jbyk * b.Min.Z - b.Min.Y + c_zy < 0)
                        || (kbyj * b.Max.Y - b.Max.Z + c_yz > 0))
                        return false;
                    return true;
                case RayType.OPP:
                    if ((origin.X < b.Min.X) || (origin.X > b.Max.X)
                        || (origin.Y > b.Max.Y) || (origin.Z > b.Max.Z)
                        || (jbyk * b.Max.Z - b.Min.Y + c_zy < 0)
                        || (kbyj * b.Max.Y - b.Min.Z + c_yz < 0))
                        return false;
                    return true;
                case RayType.MOM:
                    if ((origin.Y < b.Min.Y) || (origin.Y > b.Max.Y)
                        || (origin.X < b.Min.X) || (origin.Z < b.Min.Z)
                        || (kbyi * b.Min.X - b.Max.Z + c_xz > 0)
                        || (ibyk * b.Min.Z - b.Max.X + c_zx > 0))
                        return false;
                    return true;
                case RayType.MOP:
                    if ((origin.Y < b.Min.Y) || (origin.Y > b.Max.Y)
                        || (origin.X < b.Min.X) || (origin.Z > b.Max.Z)
                        || (kbyi * b.Min.X - b.Min.Z + c_xz < 0)
                        || (ibyk * b.Max.Z - b.Max.X + c_zx > 0))
                        return false;
                    return true;
                case RayType.POM:
                    if ((origin.Y < b.Min.Y) || (origin.Y > b.Max.Y)
                        || (origin.X > b.Max.X) || (origin.Z < b.Min.Z)
                        || (kbyi * b.Max.X - b.Max.Z + c_xz > 0)
                        || (ibyk * b.Min.Z - b.Min.X + c_zx < 0))
                        return false;
                    return true;
                case RayType.POP:
                    if ((origin.Y < b.Min.Y) || (origin.Y > b.Max.Y)
                        || (origin.X > b.Max.X) || (origin.Z > b.Max.Z)
                        || (kbyi * b.Max.X - b.Min.Z + c_xz < 0)
                        || (ibyk * b.Max.Z - b.Min.X + c_zx < 0))
                        return false;
                    return true;
                case RayType.MMO:
                    if ((origin.Z < b.Min.Z) || (origin.Z > b.Max.Z)
                        || (origin.X < b.Min.X) || (origin.Y < b.Min.Y)
                        || (jbyi * b.Min.X - b.Max.Y + c_xy > 0)
                        || (ibyj * b.Min.Y - b.Max.X + c_yx > 0))
                        return false;
                    return true;
                case RayType.MPO:
                    if ((origin.Z < b.Min.Z) || (origin.Z > b.Max.Z)
                        || (origin.X < b.Min.X) || (origin.Y > b.Max.Y)
                        || (jbyi * b.Min.X - b.Min.Y + c_xy < 0)
                        || (ibyj * b.Max.Y - b.Max.X + c_yx > 0))
                        return false;
                    return true;
                case RayType.PMO:
                    if ((origin.Z < b.Min.Z) || (origin.Z > b.Max.Z)
                        || (origin.X > b.Max.X) || (origin.Y < b.Min.Y)
                        || (jbyi * b.Max.X - b.Max.Y + c_xy > 0)
                        || (ibyj * b.Min.Y - b.Min.X + c_yx < 0))
                        return false;
                    return true;
                case RayType.PPO:
                    if ((origin.Z < b.Min.Z) || (origin.Z > b.Max.Z)
                        || (origin.X > b.Max.X) || (origin.Y > b.Max.Y)
                        || (jbyi * b.Max.X - b.Min.Y + c_xy < 0)
                        || (ibyj * b.Max.Y - b.Min.X + c_yx < 0))
                        return false;
                    return true;
                case RayType.MOO:
                    if ((origin.X < b.Min.X)
                        || (origin.Y < b.Min.Y) || (origin.Y > b.Max.Y)
                        || (origin.Z < b.Min.Z) || (origin.Z > b.Max.Z))
                        return false;
                    return true;
                case RayType.POO:
                    if ((origin.X > b.Max.X)
                        || (origin.Y < b.Min.Y) || (origin.Y > b.Max.Y)
                        || (origin.Z < b.Min.Z) || (origin.Z > b.Max.Z))
                        return false;
                    return true;
                case RayType.OMO:
                    if ((origin.Y < b.Min.Y)
                        || (origin.X < b.Min.X) || (origin.X > b.Max.X)
                        || (origin.Z < b.Min.Z) || (origin.Z > b.Max.Z))
                        return false;
                    if ((origin.Y > b.Max.Y)
                        || (origin.X < b.Min.X) || (origin.X > b.Max.X)
                        || (origin.Z < b.Min.Z) || (origin.Z > b.Max.Z))
                        return false;
                    if ((origin.Z < b.Min.Z)
                        || (origin.X < b.Min.X) || (origin.X > b.Max.X)
                        || (origin.Y < b.Min.Y) || (origin.Y > b.Max.Y))
                        return false;
                    if ((origin.Z > b.Max.Z)
                        || (origin.X < b.Min.X) || (origin.X > b.Max.X)
                        || (origin.Y < b.Min.Y) || (origin.Y > b.Max.Y))
                        return false;
                    return true;
                case RayType.OPO:
                    if ((origin.Y > b.Max.Y)
                        || (origin.X < b.Min.X) || (origin.X > b.Max.X)
                        || (origin.Z < b.Min.Z) || (origin.Z > b.Max.Z))
                        return false;
                    if ((origin.Z < b.Min.Z)
                        || (origin.X < b.Min.X) || (origin.X > b.Max.X)
                        || (origin.Y < b.Min.Y) || (origin.Y > b.Max.Y))
                        return false;
                    if ((origin.Z > b.Max.Z)
                        || (origin.X < b.Min.X) || (origin.X > b.Max.X)
                        || (origin.Y < b.Min.Y) || (origin.Y > b.Max.Y))
                        return false;
                    return true;
                case RayType.OOM:
                    if ((origin.Z < b.Min.Z)
                        || (origin.X < b.Min.X) || (origin.X > b.Max.X)
                        || (origin.Y < b.Min.Y) || (origin.Y > b.Max.Y))
                        return false;
                    if ((origin.Z > b.Max.Z)
                        || (origin.X < b.Min.X) || (origin.X > b.Max.X)
                        || (origin.Y < b.Min.Y) || (origin.Y > b.Max.Y))
                        return false;
                    return true;
                case RayType.OOP:
                    if ((origin.Z > b.Max.Z)
                        || (origin.X < b.Min.X) || (origin.X > b.Max.X)
                        || (origin.Y < b.Min.Y) || (origin.Y > b.Max.Y))
                        return false;
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks for an intersection between a ray and an OrientatedBoundingBox.
        /// </summary>
        /// <param name="b">BoundingBox to check.</param>
        /// <returns>True if an intersection exists.</returns>
        public bool Intersects(OrientatedBoundingBox b)
        {
            Matrix4 inverse = b.Matrix.Inverse();
            Ray ray = new Ray(this.Origin * inverse, this.Direction * inverse);
            return ray.Intersects(new AxisAlignedBoundingBox(b.Min, b.Max));
        }
        #endregion
    }
}
