using System.Runtime.InteropServices;

namespace OpenGL.Constructs
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct DrawElementsIndirectCommand
    {
        /// <summary>
        /// Element count
        /// </summary>
        private readonly uint Count;

        /// <summary>
        /// Instance count
        /// </summary>
        private readonly uint InstanceCount;

        /// <summary>
        /// Index of first element in base array
        /// </summary>
        private readonly uint FirstIndex;

        /// <summary>
        /// Index of first vertex in base array
        /// </summary>
        private readonly uint BaseVertex;

        /// <summary>
        /// Index of the first instance in base array
        /// </summary>
        private readonly uint BaseInstance;

        public DrawElementsIndirectCommand(int elementCount, int instanceCount, int firstElementIndex, int firstVertexIndex, int firstInstanceIndex)
        {
            this.Count = (uint)elementCount;
            this.InstanceCount = (uint)instanceCount;
            this.FirstIndex = (uint)firstElementIndex;
            this.BaseVertex = (uint)firstVertexIndex;
            this.BaseInstance = (uint)firstInstanceIndex;
        }
    }
}
