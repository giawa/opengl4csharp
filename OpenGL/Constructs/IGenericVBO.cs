using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGL
{
    public interface IGenericVBO : IDisposable
    {
        string Name { get; }
        VertexAttribPointerType PointerType { get; }
        int Length { get; }
        BufferTarget BufferTarget { get; }
        uint ID { get; }
        int Size { get; }
        uint Divisor { get; }
        bool Normalize { get; }
        bool CastToFloat { get; }
        bool IsIntegralType { get; }
        uint vboID { get; }
    }
}
