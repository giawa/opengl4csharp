using System;

namespace OpenGL
{
    /// <summary>
    /// A viewing frustum, brought in from Orchard Sun.
    /// </summary>
    public class Frustum
    {
        #region Variables
        Plane[] planes;
        #endregion

        #region Methods
        /// <summary>
        /// Builds a new Frustum and initializes six new planes
        /// </summary>
        public Frustum()
        {
            planes = new Plane[6];
        }

        /// <summary>
        /// Builds the Planes so that they make up the left, right, up, down, front and back of the Frustum
        /// </summary>
        public void UpdateFrustum(Matrix4 projectionMatrix, Matrix4 modelviewMatrix)
        {
            Matrix4 t_proj = projectionMatrix;//Matrix4.FromArray(CameraHandler.Instance.ProjectionMatrix);
            Matrix4 t_model = modelviewMatrix;//Matrix4.FromArray(CameraHandler.Instance.ModelviewMatrix);
            Matrix4 t_clip = t_model * t_proj;

            planes[0] = new Plane(t_clip[0].w - t_clip[0].x, t_clip[1].w - t_clip[1].x, t_clip[2].w - t_clip[2].x, t_clip[3].w - t_clip[3].x);
            planes[1] = new Plane(t_clip[0].w + t_clip[0].x, t_clip[1].w + t_clip[1].x, t_clip[2].w + t_clip[2].x, t_clip[3].w + t_clip[3].x);
            planes[2] = new Plane(t_clip[0].w + t_clip[0].y, t_clip[1].w + t_clip[1].y, t_clip[2].w + t_clip[2].y, t_clip[3].w + t_clip[3].y);
            planes[3] = new Plane(t_clip[0].w - t_clip[0].y, t_clip[1].w - t_clip[1].y, t_clip[2].w - t_clip[2].y, t_clip[3].w - t_clip[3].y);
            planes[4] = new Plane(t_clip[0].w - t_clip[0].z, t_clip[1].w - t_clip[1].z, t_clip[2].w - t_clip[2].z, t_clip[3].w - t_clip[3].z);
            planes[5] = new Plane(t_clip[0].w + t_clip[0].z, t_clip[1].w + t_clip[1].z, t_clip[2].w + t_clip[2].z, t_clip[3].w + t_clip[3].z);
            for (int i = 0; i < 6; i++)
            {
                float t_mag = planes[i].Normal.Length;
                planes[i].Scalar /= t_mag;
                planes[i].Normal /= t_mag;
            }
        }

        /// <summary>
        /// True if the AxisAlignedBoundingBox is in (or partially in) the Frustum
        /// </summary>
        /// <param name="b">AxixAlignedBoundingBox to check</param>
        /// <returns>True if an intersection exists</returns>
        public bool Intersects(AxisAlignedBoundingBox b)
        {
            for (int i = 0; i < 6; i++)
            {
                if (Vector3.Dot(b.Center, planes[i].Normal) + planes[i].Scalar <= -b.Radius) return false;
            }
            return true;
        }
        #endregion
    }
}
