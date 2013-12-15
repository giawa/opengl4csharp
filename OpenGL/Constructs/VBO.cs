using System;
using System.Runtime.InteropServices;

namespace OpenGL
{
    public class VBO<T> : IDisposable
        where T : struct
    {
        #region Properties
        /// <summary>
        /// The ID of the vertex buffer object.
        /// </summary>
        public uint vboID { get; private set; }

        /// <summary>
        /// The type of the buffer.
        /// </summary>
        public BufferTarget BufferTarget { get; private set; }

        /// <summary>
        /// The size (in floats) of the type of data in the buffer.  Size * 4 to get bytes.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// The type of data that is stored in the buffer (either int or float).
        /// </summary>
        public VertexAttribPointerType PointerType { get; private set; }
        
        /// <summary>
        /// The length of data that is stored in the buffer.
        /// </summary>
        public int Count { get; private set; }
        #endregion

        #region Constructor and Destructor
        /// <summary>
        /// Creates a buffer object of type T with a specified length.
        /// This allows the array T[] to be larger than the actual size necessary to buffer.
        /// Useful for reusing resources and avoiding unnecessary GC action.
        /// </summary>
        /// <param name="Data">An array of data of type T (which must be a struct) that will be buffered to the GPU.</param>
        /// <param name="Length">The length of the valid data in the data array.</param>
        /// <param name="Target">Specifies the target buffer object.</param>
        /// <param name="Hint">Specifies the expected usage of the data store.</param>
        public VBO(T[] Data, int Length, BufferTarget Target = OpenGL.BufferTarget.ArrayBuffer, BufferUsageHint Hint = BufferUsageHint.StaticRead)
        {
            Length = Math.Max(0, Math.Min(Length, Data.Length));

            vboID = Gl.CreateVBO<T>(BufferTarget = Target, Data, Hint, Length);

            this.Size = (Data is int[] ? 1 : (Data is Vector2[] ? 2 : (Data is Vector3[] ? 3 : (Data is Vector4[] ? 4 : 0))));
            this.PointerType = (Data is int[] ? VertexAttribPointerType.Int : VertexAttribPointerType.Float);
            this.Count = Length;
        }

        /// <summary>
        /// Creates a buffer object of type T.
        /// </summary>
        /// <param name="Data">Specifies a pointer to data that will be copied into the data store for initialization.</param>
        /// <param name="Target">Specifies the target buffer object.</param>
        /// <param name="Hint">Specifies the expected usage of the data store.</param>
        public VBO(T[] Data, BufferTarget Target = OpenGL.BufferTarget.ArrayBuffer, BufferUsageHint Hint = BufferUsageHint.StaticRead)
        {
            vboID = Gl.CreateVBO<T>(BufferTarget = Target, Data, Hint);

            Size = (Data is int[] ? 1 : (Data is Vector2[] ? 2 : (Data is Vector3[] ? 3 : (Data is Vector4[] ? 4 : 0))));
            PointerType = (Data is int[] ? VertexAttribPointerType.Int : VertexAttribPointerType.Float);
            Count = Data.Length;
        }

        /// <summary>
        /// Creates a static-read array buffer of type T.
        /// </summary>
        /// <param name="Data">Specifies a pointer to data that will be copied into the data store for initialization.</param>
        public VBO(T[] Data)
            : this(Data, BufferTarget.ArrayBuffer, BufferUsageHint.StaticRead)
        {
        }

        /// <summary>
        /// Check to ensure that the VBO was disposed of properly.
        /// </summary>
        ~VBO()
        {
            if (vboID != 0) System.Diagnostics.Debug.Fail("VBO was not disposed of properly.");
        }
        #endregion

        #region IDisposable
        /// <summary>
        /// Deletes this buffer from GPU memory.
        /// </summary>
        public void Dispose()
        {
            if (vboID != 0)
            {
                Gl.DeleteBuffers(1, new uint[] { vboID });
                vboID = 0;
            }
        }
        #endregion
    }

    public class VAO : IDisposable
    {
        #region Variables
        private VBO<Vector3> vertex, normal, tangent;
        
        private VBO<Vector2> uv;
        
        private VBO<int> element;
        
        private IDisposable[] vbos;
        #endregion

        #region Properties
        /// <summary>
        /// The number of vertices that make up this VAO.
        /// </summary>
        public int VertexCount { get; private set; }
        
        /// <summary>
        /// Specifies if the VAO should dispose of the child VBOs when Dispose() is called.
        /// </summary>
        public bool DisposeChildren { get; set; }
        
        /// <summary>
        /// The ShaderProgram associated with this VAO.
        /// </summary>
        public ShaderProgram Program { get; private set; }

        /// <summary>
        /// The drawing mode to use when drawing the arrays.
        /// </summary>
        public BeginMode DrawMode { get; set; }

        /// <summary>
        /// The ID of this Vertex Array Object for use in calls to OpenGL.
        /// </summary>
        public uint vaoID { get; private set; }
        #endregion

        #region Constructors and Destructor
        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<int> element)
            : this(program, vertex, null, null, null, element)
        {
            vbos = new IDisposable[] { vertex, element };
        }

        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<Vector2> uv, VBO<int> element)
            : this(program, vertex, null, null, uv, element)
        {
            vbos = new IDisposable[] { vertex, uv, element };
        }

        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<Vector3> normal, VBO<int> element)
            : this(program, vertex, normal, null, null, element)
        {
            vbos = new IDisposable[] { vertex, normal, element };
        }

        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<Vector3> normal, VBO<Vector2> uv, VBO<int> element)
            : this(program, vertex, normal, null, uv, element)
        {
            vbos = new IDisposable[] { vertex, normal, uv, element };
        }
        
        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<Vector3> normal, VBO<Vector3> tangent, VBO<Vector2> uv, VBO<int> element)
        {
            this.Program = program;
            this.VertexCount = element.Count;
            this.DrawMode = BeginMode.Triangles;
            this.vertex = vertex;
            this.normal = normal;
            this.tangent = tangent;
            this.uv = uv;
            this.element = element;
            
            if (Gl.Version() >= 3)
            {
                vaoID = Gl.GenVertexArray();
                if (vaoID != 0)
                {
                    Gl.BindVertexArray(vaoID);
                    BindAttributes(this.Program);
                }
                Gl.BindVertexArray(0);
                
                Draw = DrawOGL3;
            }
            else
            {
                Draw = DrawOGL2;
            }
            
            vbos = new IDisposable[] { vertex, normal, tangent, uv, element };
        }

        ~VAO()
        {
            if (vaoID != 0) System.Diagnostics.Debug.Fail("VAO was not disposed of properly.");
        }
        #endregion

        #region Draw Methods (OGL2 and OGL3)
        /// <summary>
        /// Generic method for binding the VBOs to their respective attribute locations.
        /// OpenGL.dll assumes the common naming conventions below:
        ///     vertices: vec3 in_position
        ///     normals: vec3 in_normal
        ///     uv: vec2 in_uv
        ///     tangent: vec3 in_tangent
        /// </summary>
        public void BindAttributes(ShaderProgram program)
        {
            if (vertex == null || vertex.vboID == 0) throw new Exception("Error binding attributes.  No vertices were supplied.");
            if (element == null || element.vboID == 0) throw new Exception("Error binding attributes.  No element array was supplied.");

            // Note:  Since the shader is already compiled, we cannot set the attribute locations.
            //  Instead we must query the shader for the locations that the linker chose and use them.
            uint loc = (uint)Gl.GetAttribLocation(program.ProgramID, "in_position");
            Gl.EnableVertexAttribArray(loc);
            Gl.BindBuffer(vertex.BufferTarget, vertex.vboID);
            Gl.VertexAttribPointer(loc, vertex.Size, vertex.PointerType, true, 12, new IntPtr(0));

            if (normal != null && normal.vboID != 0)
            {
                loc = (uint)Gl.GetAttribLocation(program.ProgramID, "in_normal");
                Gl.EnableVertexAttribArray(loc);
                Gl.BindBuffer(normal.BufferTarget, normal.vboID);
                Gl.VertexAttribPointer(loc, normal.Size, normal.PointerType, true, 12, new IntPtr(0));
            }

            if (uv != null && uv.vboID != 0)
            {
                loc = (uint)Gl.GetAttribLocation(program.ProgramID, "in_uv");
                Gl.EnableVertexAttribArray(loc);
                Gl.BindBuffer(uv.BufferTarget, uv.vboID);
                Gl.VertexAttribPointer(loc, uv.Size, uv.PointerType, true, 8, new IntPtr(0));
            }

            if (tangent != null && tangent.vboID != 0)
            {
                loc = (uint)Gl.GetAttribLocation(program.ProgramID, "in_tangent");
                Gl.EnableVertexAttribArray(loc);
                Gl.BindBuffer(tangent.BufferTarget, tangent.vboID);
                Gl.VertexAttribPointer(loc, tangent.Size, tangent.PointerType, true, 12, new IntPtr(0));
            }

            Gl.BindBuffer(BufferTarget.ElementArrayBuffer, element.vboID);
        }
        
        public delegate void DrawFunc();
        
        public DrawFunc Draw; 
        
        /// <summary>
        /// OGL3 method uses a vertex array object for quickly binding the VBOs to their attributes.
        /// </summary>
        private void DrawOGL3()
        {
            if (vaoID == 0) return;
            Gl.BindVertexArray(vaoID);
            Gl.DrawElements(DrawMode, VertexCount, DrawElementsType.UnsignedInt, IntPtr.Zero);
            Gl.BindVertexArray(0);
        }
        
        /// <summary>
        /// OGL2 does not support VAOs, and instead must bind the VBOs to their attributes manually.
        /// </summary>
        private void DrawOGL2()
        {
            BindAttributes(this.Program);
            Gl.DrawElements(DrawMode, VertexCount, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        /// <summary>
        /// Performs the draw routine with a custom shader program.
        /// </summary>
        /// <param name="program"></param>
        public void DrawProgram(ShaderProgram program)
        {
            BindAttributes(program);
            Gl.DrawElements(DrawMode, VertexCount, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }
        #endregion

        #region IDisposable
        /// <summary>
        /// Deletes the vertex array from the GPU and will also dispose of any child VBOs if (DisposeChildren == true).
        /// </summary>
        public void Dispose()
        {
            // first try to dispose of the vertex array
            if (vaoID != 0)
            {
                Gl.DeleteVertexArrays(1, new uint[] { vaoID });
                
                vaoID = 0;
            }
            
            // children must be disposed of separately since OpenGL 2.1 will not have a vertex array
            if (DisposeChildren && vbos != null)
            {
                foreach (IDisposable pChild in vbos) pChild.Dispose();
            }
        }
        #endregion
    }
}
