using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenGL
{
    public class VAO<T1> : GenericVAO
        where T1 : struct
    {
        public VAO(ShaderProgram program, VBO<T1> vbo1, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 1) throw new Exception(string.Format("Expected an array of 1 name, but instead got {0}.", attribNames.Length));

            GenericVAO.GenericVBO[] vbos = new GenericVBO[2];
            vbos[0] = new GenericVBO(vbo1.vboID, attribNames[0], vbo1.Count, vbo1.Size, vbo1.PointerType, vbo1.BufferTarget);
            vbos[1] = new GenericVBO(elementArray.vboID, "", elementArray.Count, elementArray.Size, elementArray.PointerType, elementArray.BufferTarget);

            Init(vbos);
        }
    }

    public class VAO<T1, T2> : GenericVAO
        where T1 : struct
        where T2 : struct
    {
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 2) throw new Exception(string.Format("Expected an array of 2 names, but instead got {0}.", attribNames.Length));

            GenericVAO.GenericVBO[] vbos = new GenericVBO[3];
            vbos[0] = new GenericVBO(vbo1.vboID, attribNames[0], vbo1.Count, vbo1.Size, vbo1.PointerType, vbo1.BufferTarget);
            vbos[1] = new GenericVBO(vbo2.vboID, attribNames[1], vbo2.Count, vbo2.Size, vbo2.PointerType, vbo2.BufferTarget);
            vbos[2] = new GenericVBO(elementArray.vboID, "", elementArray.Count, elementArray.Size, elementArray.PointerType, elementArray.BufferTarget);

            Init(vbos);
        }
    }

    public class VAO<T1, T2, T3> : GenericVAO
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 3) throw new Exception(string.Format("Expected an array of 3 names, but instead got {0}.", attribNames.Length));

            GenericVAO.GenericVBO[] vbos = new GenericVBO[4];
            vbos[0] = new GenericVBO(vbo1.vboID, attribNames[0], vbo1.Count, vbo1.Size, vbo1.PointerType, vbo1.BufferTarget);
            vbos[1] = new GenericVBO(vbo2.vboID, attribNames[1], vbo2.Count, vbo2.Size, vbo2.PointerType, vbo2.BufferTarget);
            vbos[2] = new GenericVBO(vbo3.vboID, attribNames[2], vbo3.Count, vbo3.Size, vbo3.PointerType, vbo3.BufferTarget);
            vbos[3] = new GenericVBO(elementArray.vboID, "", elementArray.Count, elementArray.Size, elementArray.PointerType, elementArray.BufferTarget);

            Init(vbos);
        }
    }

    public class VAO<T1, T2, T3, T4> : GenericVAO
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 4) throw new Exception(string.Format("Expected an array of 4 names, but instead got {0}.", attribNames.Length));

            GenericVAO.GenericVBO[] vbos = new GenericVBO[5];
            vbos[0] = new GenericVBO(vbo1.vboID, attribNames[0], vbo1.Count, vbo1.Size, vbo1.PointerType, vbo1.BufferTarget);
            vbos[1] = new GenericVBO(vbo2.vboID, attribNames[1], vbo2.Count, vbo2.Size, vbo2.PointerType, vbo2.BufferTarget);
            vbos[2] = new GenericVBO(vbo3.vboID, attribNames[2], vbo3.Count, vbo3.Size, vbo3.PointerType, vbo3.BufferTarget);
            vbos[3] = new GenericVBO(vbo4.vboID, attribNames[3], vbo4.Count, vbo4.Size, vbo4.PointerType, vbo4.BufferTarget);
            vbos[4] = new GenericVBO(elementArray.vboID, "", elementArray.Count, elementArray.Size, elementArray.PointerType, elementArray.BufferTarget);

            Init(vbos);
        }
    }

    public class VAO<T1, T2, T3, T4, T5> : GenericVAO
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, VBO<T5> vbo5, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 5) throw new Exception(string.Format("Expected an array of 5 names, but instead got {0}.", attribNames.Length));

            GenericVAO.GenericVBO[] vbos = new GenericVBO[6];
            vbos[0] = new GenericVBO(vbo1.vboID, attribNames[0], vbo1.Count, vbo1.Size, vbo1.PointerType, vbo1.BufferTarget);
            vbos[1] = new GenericVBO(vbo2.vboID, attribNames[1], vbo2.Count, vbo2.Size, vbo2.PointerType, vbo2.BufferTarget);
            vbos[2] = new GenericVBO(vbo3.vboID, attribNames[2], vbo3.Count, vbo3.Size, vbo3.PointerType, vbo3.BufferTarget);
            vbos[3] = new GenericVBO(vbo4.vboID, attribNames[3], vbo4.Count, vbo4.Size, vbo4.PointerType, vbo4.BufferTarget);
            vbos[4] = new GenericVBO(vbo5.vboID, attribNames[4], vbo5.Count, vbo5.Size, vbo5.PointerType, vbo5.BufferTarget);
            vbos[5] = new GenericVBO(elementArray.vboID, "", elementArray.Count, elementArray.Size, elementArray.PointerType, elementArray.BufferTarget);

            Init(vbos);
        }
    }

    public class VAO<T1, T2, T3, T4, T5, T6> : GenericVAO
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
    {
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, VBO<T5> vbo5, VBO<T6> vbo6, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 6) throw new Exception(string.Format("Expected an array of 6 names, but instead got {0}.", attribNames.Length));

            GenericVAO.GenericVBO[] vbos = new GenericVBO[7];
            vbos[0] = new GenericVBO(vbo1.vboID, attribNames[0], vbo1.Count, vbo1.Size, vbo1.PointerType, vbo1.BufferTarget);
            vbos[1] = new GenericVBO(vbo2.vboID, attribNames[1], vbo2.Count, vbo2.Size, vbo2.PointerType, vbo2.BufferTarget);
            vbos[2] = new GenericVBO(vbo3.vboID, attribNames[2], vbo3.Count, vbo3.Size, vbo3.PointerType, vbo3.BufferTarget);
            vbos[3] = new GenericVBO(vbo4.vboID, attribNames[3], vbo4.Count, vbo4.Size, vbo4.PointerType, vbo4.BufferTarget);
            vbos[4] = new GenericVBO(vbo5.vboID, attribNames[4], vbo5.Count, vbo5.Size, vbo5.PointerType, vbo5.BufferTarget);
            vbos[5] = new GenericVBO(vbo6.vboID, attribNames[5], vbo6.Count, vbo6.Size, vbo6.PointerType, vbo6.BufferTarget);
            vbos[6] = new GenericVBO(elementArray.vboID, "", elementArray.Count, elementArray.Size, elementArray.PointerType, elementArray.BufferTarget);

            Init(vbos);
        }
    }

    public class VAO<T1, T2, T3, T4, T5, T6, T7> : GenericVAO
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
        where T7 : struct
    {
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, VBO<T5> vbo5, VBO<T6> vbo6, VBO<T7> vbo7, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 7) throw new Exception(string.Format("Expected an array of 7 names, but instead got {0}.", attribNames.Length));

            GenericVAO.GenericVBO[] vbos = new GenericVBO[8];
            vbos[0] = new GenericVBO(vbo1.vboID, attribNames[0], vbo1.Count, vbo1.Size, vbo1.PointerType, vbo1.BufferTarget);
            vbos[1] = new GenericVBO(vbo2.vboID, attribNames[1], vbo2.Count, vbo2.Size, vbo2.PointerType, vbo2.BufferTarget);
            vbos[2] = new GenericVBO(vbo3.vboID, attribNames[2], vbo3.Count, vbo3.Size, vbo3.PointerType, vbo3.BufferTarget);
            vbos[3] = new GenericVBO(vbo4.vboID, attribNames[3], vbo4.Count, vbo4.Size, vbo4.PointerType, vbo4.BufferTarget);
            vbos[4] = new GenericVBO(vbo5.vboID, attribNames[4], vbo5.Count, vbo5.Size, vbo5.PointerType, vbo5.BufferTarget);
            vbos[5] = new GenericVBO(vbo6.vboID, attribNames[5], vbo6.Count, vbo6.Size, vbo6.PointerType, vbo6.BufferTarget);
            vbos[6] = new GenericVBO(vbo7.vboID, attribNames[6], vbo7.Count, vbo7.Size, vbo7.PointerType, vbo7.BufferTarget);
            vbos[7] = new GenericVBO(elementArray.vboID, "", elementArray.Count, elementArray.Size, elementArray.PointerType, elementArray.BufferTarget);

            Init(vbos);
        }
    }

    public class VAO<T1, T2, T3, T4, T5, T6, T7, T8> : GenericVAO
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
        where T7 : struct
        where T8 : struct
    {
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, VBO<T5> vbo5, VBO<T6> vbo6, VBO<T7> vbo7, VBO<T8> vbo8, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 8) throw new Exception(string.Format("Expected an array of 8 names, but instead got {0}.", attribNames.Length));

            GenericVAO.GenericVBO[] vbos = new GenericVBO[8];
            vbos[0] = new GenericVBO(vbo1.vboID, attribNames[0], vbo1.Count, vbo1.Size, vbo1.PointerType, vbo1.BufferTarget);
            vbos[1] = new GenericVBO(vbo2.vboID, attribNames[1], vbo2.Count, vbo2.Size, vbo2.PointerType, vbo2.BufferTarget);
            vbos[2] = new GenericVBO(vbo3.vboID, attribNames[2], vbo3.Count, vbo3.Size, vbo3.PointerType, vbo3.BufferTarget);
            vbos[3] = new GenericVBO(vbo4.vboID, attribNames[3], vbo4.Count, vbo4.Size, vbo4.PointerType, vbo4.BufferTarget);
            vbos[4] = new GenericVBO(vbo5.vboID, attribNames[4], vbo5.Count, vbo5.Size, vbo5.PointerType, vbo5.BufferTarget);
            vbos[5] = new GenericVBO(vbo6.vboID, attribNames[5], vbo6.Count, vbo6.Size, vbo6.PointerType, vbo6.BufferTarget);
            vbos[6] = new GenericVBO(vbo7.vboID, attribNames[6], vbo7.Count, vbo7.Size, vbo7.PointerType, vbo7.BufferTarget);
            vbos[7] = new GenericVBO(vbo8.vboID, attribNames[7], vbo8.Count, vbo8.Size, vbo8.PointerType, vbo8.BufferTarget);
            vbos[8] = new GenericVBO(elementArray.vboID, "", elementArray.Count, elementArray.Size, elementArray.PointerType, elementArray.BufferTarget);

            Init(vbos);
        }
    }

    public class GenericVAO : IDisposable
    {
        #region Generic VBO
        public GenericVBO[] vbos;

        public struct GenericVBO
        {
            public string name;
            public VertexAttribPointerType pointerType;
            public int length;
            public BufferTarget bufferTarget;
            public uint vboID;
            public int size;

            public GenericVBO(uint VboID, string Name, int Length, int Size, VertexAttribPointerType PointerType, BufferTarget BufferTarget)
            {
                vboID = VboID;
                name = Name;
                length = Length;
                size = Size;
                pointerType = PointerType;
                bufferTarget = BufferTarget;
            }
        }
        #endregion

        #region Constructor and Destructor
        public GenericVAO(ShaderProgram program)
        {
            this.Program = program;
            this.DrawMode = BeginMode.Triangles;
        }

        public void Init(GenericVBO[] vbos)
        {
            this.vbos = vbos;

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
        }

        ~GenericVAO()
        {
            if (vaoID != 0) System.Diagnostics.Debug.Fail("VAO was not disposed of properly.");
        }
        #endregion

        #region Properties
        /// <summary>
        /// The number of vertices that make up this VAO.
        /// </summary>
        public int VertexCount { get; set; }

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

        #region Draw Methods (OGL2 and OGL3)
        private int SizeOfType(VertexAttribPointerType type)
        {
            switch (type)
            {
                case VertexAttribPointerType.Byte: 
                case VertexAttribPointerType.UnsignedByte: return 1;
                case VertexAttribPointerType.Short:
                case VertexAttribPointerType.UnsignedShort: 
                case VertexAttribPointerType.HalfFloat: return 2;
                case VertexAttribPointerType.Int:
                case VertexAttribPointerType.Float: return 4;
                case VertexAttribPointerType.Double: return 8;
            }
            return 1;
        }

        public void BindAttributes(ShaderProgram program)
        {
            GenericVBO elementArray = new GenericVBO(0, "", 0, 0, VertexAttribPointerType.Byte, BufferTarget.ArrayBuffer);

            for (int i = 0; i < vbos.Length; i++)
            {
                if (vbos[i].bufferTarget == BufferTarget.ElementArrayBuffer)
                {
                    elementArray = vbos[i];
                    continue;
                }

                int loc = Gl.GetAttribLocation(program.ProgramID, vbos[i].name);
                if (loc == -1) throw new Exception(string.Format("Shader did not contain '{0}'.", vbos[i].name));

                Gl.EnableVertexAttribArray((uint)loc);
                Gl.BindBuffer(vbos[i].bufferTarget, vbos[i].vboID);
                Gl.VertexAttribPointer((uint)loc, vbos[i].size, vbos[i].pointerType, true, vbos[i].size * SizeOfType(vbos[i].pointerType), IntPtr.Zero);
            }

            if (elementArray.vboID != 0)
            {
                Gl.BindBuffer(BufferTarget.ElementArrayBuffer, elementArray.vboID);
                VertexCount = elementArray.length;
            }
        }

        public delegate void DrawFunc();

        public DrawFunc Draw;

        /// <summary>
        /// OGL3 method uses a vertex array object for quickly binding the VBOs to their attributes.
        /// </summary>
        private void DrawOGL3()
        {
            if (vaoID == 0 || VertexCount == 0) return;
            Gl.BindVertexArray(vaoID);
            Gl.DrawElements(DrawMode, VertexCount, DrawElementsType.UnsignedInt, IntPtr.Zero);
            Gl.BindVertexArray(0);
        }

        /// <summary>
        /// OGL2 does not support VAOs, and instead must bind the VBOs to their attributes manually.
        /// </summary>
        private void DrawOGL2()
        {
            if (VertexCount == 0) return;
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
            if (DisposeChildren)
            {
                for (int i = 0; i < vbos.Length; i++)
                    Gl.DeleteBuffer(vbos[i].vboID);
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
        }

        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<Vector2> uv, VBO<int> element)
            : this(program, vertex, null, null, uv, element)
        {
        }

        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<Vector3> normal, VBO<int> element)
            : this(program, vertex, normal, null, null, element)
        {
        }

        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<Vector3> normal, VBO<Vector2> uv, VBO<int> element)
            : this(program, vertex, normal, null, uv, element)
        {
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
        }

        ~VAO()
        {
            if (vaoID != 0) System.Diagnostics.Debug.Fail("VAO was not disposed of properly.");
        }
        #endregion

        #region Draw Methods (OGL2 and OGL3)
        public void BindCachedAttributes(ShaderProgram program, int vertexAttributeLocation, int normalAttributeLocation = -1, int uvAttributeLocation = -1, int tangentAttributeLocation = -1)
        {
            if (normalAttributeLocation != -1 && normal.vboID != 0)
            {
                Gl.EnableVertexAttribArray((uint)normalAttributeLocation);
                Gl.BindBuffer(normal.BufferTarget, normal.vboID);
                Gl.VertexAttribPointer((uint)normalAttributeLocation, normal.Size, normal.PointerType, true, 12, IntPtr.Zero);
            }

            if (uvAttributeLocation != -1 && uv.vboID != 0)
            {
                Gl.EnableVertexAttribArray((uint)uvAttributeLocation);
                Gl.BindBuffer(uv.BufferTarget, uv.vboID);
                Gl.VertexAttribPointer((uint)uvAttributeLocation, uv.Size, uv.PointerType, true, 8, IntPtr.Zero);
            }

            if (tangentAttributeLocation != -1 && tangent.vboID != 0)
            {
                Gl.EnableVertexAttribArray((uint)tangentAttributeLocation);
                Gl.BindBuffer(tangent.BufferTarget, tangent.vboID);
                Gl.VertexAttribPointer((uint)tangentAttributeLocation, tangent.Size, tangent.PointerType, true, 12, IntPtr.Zero);
            }

            BindCachedAttributes(vertexAttributeLocation, program);
        }

        public void BindCachedAttributes(int vertexAttributeLocation, ShaderProgram program)
        {
            if (vertex == null || vertex.vboID == 0) throw new Exception("Error binding attributes.  No vertices were supplied.");
            if (element == null || element.vboID == 0) throw new Exception("Error binding attributes.  No element array was supplied.");

            Gl.EnableVertexAttribArray((uint)vertexAttributeLocation);
            Gl.BindBuffer(vertex.BufferTarget, vertex.vboID);
            Gl.VertexAttribPointer((uint)vertexAttributeLocation, vertex.Size, vertex.PointerType, true, 12, IntPtr.Zero);

            Gl.BindBuffer(BufferTarget.ElementArrayBuffer, element.vboID);
        }

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
            int loc = Gl.GetAttribLocation(program.ProgramID, "in_position");
            if (loc == -1) throw new Exception("Shader did not contain 'in_position'.");

            Gl.EnableVertexAttribArray((uint)loc);
            Gl.BindBuffer(vertex.BufferTarget, vertex.vboID);
            Gl.VertexAttribPointer((uint)loc, vertex.Size, vertex.PointerType, true, 12, IntPtr.Zero);

            if (normal != null && normal.vboID != 0)
            {
                loc = Gl.GetAttribLocation(program.ProgramID, "in_normal");
                if (loc != -1)
                {
                    Gl.EnableVertexAttribArray((uint)loc);
                    Gl.BindBuffer(normal.BufferTarget, normal.vboID);
                    Gl.VertexAttribPointer((uint)loc, normal.Size, normal.PointerType, true, 12, IntPtr.Zero);
                }
            }

            if (uv != null && uv.vboID != 0)
            {
                loc = Gl.GetAttribLocation(program.ProgramID, "in_uv");
                if (loc != -1)
                {
                    Gl.EnableVertexAttribArray((uint)loc);
                    Gl.BindBuffer(uv.BufferTarget, uv.vboID);
                    Gl.VertexAttribPointer((uint)loc, uv.Size, uv.PointerType, true, 8, IntPtr.Zero);
                }
            }

            if (tangent != null && tangent.vboID != 0)
            {
                loc = Gl.GetAttribLocation(program.ProgramID, "in_tangent");
                if (loc != -1)
                {
                    Gl.EnableVertexAttribArray((uint)loc);
                    Gl.BindBuffer(tangent.BufferTarget, tangent.vboID);
                    Gl.VertexAttribPointer((uint)loc, tangent.Size, tangent.PointerType, true, 12, IntPtr.Zero);
                }
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
            if (DisposeChildren)
            {
                if (vertex != null) vertex.Dispose();
                if (normal != null) normal.Dispose();
                if (tangent != null) tangent.Dispose();
                if (uv != null) uv.Dispose();
                if (element != null) element.Dispose();

                vertex = null;
                normal = null;
                tangent = null;
                uv = null;
                element = null;
            }
        }
        #endregion
    }
}
