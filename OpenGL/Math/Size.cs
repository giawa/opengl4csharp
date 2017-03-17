namespace OpenGL
{
    /// <summary>
    /// A barebones implementation of the System.Drawing.Size structure
    /// to support the use of Size in the Texture and FBO classes.
    /// </summary>
    public struct Size
    {
        /// <summary>
        /// This width of the object that this Size is representing.
        /// </summary>
        public int Width;

        /// <summary>
        /// This height of the object that this Size is representing.
        /// </summary>
        public int Height;

        /// <summary>
        /// Create a Size object with a specified width and height.
        /// </summary>
        /// <param name="width">The width to be represented by the Size object.</param>
        /// <param name="height">The height to be represented by the Size object.</param>
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
