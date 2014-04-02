using System;

namespace OpenGL
{
    /// <summary>
    /// A viewing frustum, brought in from Orchard Sun.
    /// </summary>
    public class Frustum
    {
        #region Variables
        private Plane[] planes;

        /// <summary>
        /// Get the planes that make up the Frustum.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public Plane this[int a]
        {
            get { return (a >= 0 && a < 6) ? planes[a] : null; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Builds a new Frustum and initializes six new planes
        /// </summary>
        public Frustum()
        {
            planes = new Plane[6];
            for (int i = 0; i < 6; i++) planes[i] = new Plane(0, 0, 0, 0);
        }

        /// <summary>
        /// Builds the Planes so that they make up the left, right, up, down, front and back of the Frustum.
        /// </summary>
        /// <param name="clipMatrix">The combined projection and view matrix (usually from the camera).</param>
        public void UpdateFrustum(Matrix4 clipMatrix)
        {
            planes[0].Set(clipMatrix[3].w - clipMatrix[3].x, new Vector3(clipMatrix[0].w - clipMatrix[0].x, clipMatrix[1].w - clipMatrix[1].x, clipMatrix[2].w - clipMatrix[2].x));
            planes[1].Set(clipMatrix[3].w + clipMatrix[3].x, new Vector3(clipMatrix[0].w + clipMatrix[0].x, clipMatrix[1].w + clipMatrix[1].x, clipMatrix[2].w + clipMatrix[2].x));
            planes[2].Set(clipMatrix[3].w + clipMatrix[3].y, new Vector3(clipMatrix[0].w + clipMatrix[0].y, clipMatrix[1].w + clipMatrix[1].y, clipMatrix[2].w + clipMatrix[2].y));
            planes[3].Set(clipMatrix[3].w - clipMatrix[3].y, new Vector3(clipMatrix[0].w - clipMatrix[0].y, clipMatrix[1].w - clipMatrix[1].y, clipMatrix[2].w - clipMatrix[2].y));
            planes[4].Set(clipMatrix[3].w - clipMatrix[3].z, new Vector3(clipMatrix[0].w - clipMatrix[0].z, clipMatrix[1].w - clipMatrix[1].z, clipMatrix[2].w - clipMatrix[2].z));
            planes[5].Set(clipMatrix[3].w + clipMatrix[3].z, new Vector3(clipMatrix[0].w + clipMatrix[0].z, clipMatrix[1].w + clipMatrix[1].z, clipMatrix[2].w + clipMatrix[2].z));

            for (int i = 0; i < 6; i++)
            {
                float t_mag = planes[i].Normal.Length;
                planes[i].Scalar /= t_mag;
                planes[i].Normal /= t_mag;
            }
        }

        /// <summary>
        /// Builds the Planes so that they make up the left, right, up, down, front and back of the Frustum.
        /// </summary>
        public void UpdateFrustum(Matrix4 projectionMatrix, Matrix4 modelviewMatrix)
        {
            UpdateFrustum(modelviewMatrix * projectionMatrix);
        }

        /// <summary>
        /// True if the AxisAlignedBoundingBox is in (or partially in) the Frustum
        /// </summary>
        /// <param name="b">AxixAlignedBoundingBox to check</param>
        /// <returns>True if an intersection exists</returns>
        public bool Intersects(AxisAlignedBoundingBox box)
        {
            for (int i = 0; i < 6; i++)
            {
                Plane p = planes[i];

                float d = box.Center.Dot(p.Normal);
                float r = box.Size.x * Math.Abs(p.Normal.x) + box.Size.y * Math.Abs(p.Normal.y) + box.Size.z * Math.Abs(p.Normal.z);
                float dpr = d + r;
                float dmr = d - r;

                if (dpr < -p.Scalar) return false;
            }
            return true;
        }
        #endregion
    }
}
