using OpenGL.Constructs;
using System;
using System.Collections.Generic;

#if USE_NUMERICS
using System.Numerics;
#endif

namespace OpenGL
{
    public class VAO<T1> : GenericVAO
        where T1 : struct
    {
        [Obsolete("This VAO constructor is deprecated in favour of using VAO(ShaderProgram program, IGenericVBO[] vbos).")]
        public VAO(ShaderProgram program, VBO<T1> vbo1, string attribName, VBO<int> elementArray)
            : base(program)
        {
            IGenericVBO[] vbos = new IGenericVBO[2];
            vbos[0] = new GenericVBO<T1>(vbo1, attribName);
            vbos[1] = new GenericVBO<int>(elementArray);

            Init(vbos);
        }

        [Obsolete("This VAO constructor is deprecated in favour of using VAO(ShaderProgram program, IGenericVBO[] vbos).")]
        public VAO(ShaderProgram program, VBO<T1> vbo1, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 1) throw new Exception(string.Format("Expected an array of 1 name, but instead got {0}.", attribNames.Length));

            IGenericVBO[] vbos = new IGenericVBO[2];
            vbos[0] = new GenericVBO<T1>(vbo1, attribNames[0]);
            vbos[1] = new GenericVBO<int>(elementArray);

            Init(vbos);
        }
    }

    public class VAO<T1, T2> : GenericVAO
        where T1 : struct
        where T2 : struct
    {
        [Obsolete("This VAO constructor is deprecated in favour of using VAO(ShaderProgram program, IGenericVBO[] vbos).")]
        public VAO(ShaderProgram program, VBO<T1> vbo1, string attribName, VBO<T2> elementArray)
    : base(program, false)
        {
            IGenericVBO[] vbos = new IGenericVBO[2];
            vbos[0] = new GenericVBO<T1>(vbo1, attribName);
            vbos[1] = new GenericVBO<T2>(elementArray);

            Init(vbos);
        }

        [Obsolete("This VAO constructor is deprecated in favour of using VAO(ShaderProgram program, IGenericVBO[] vbos).")]
        public VAO(ShaderProgram program, VBO<T1> vbo1, string[] attribNames, VBO<T2> elementArray)
    : base(program, false)
        {
            if (attribNames.Length != 1) throw new Exception(string.Format("Expected an array of 1 names, but instead got {0}.", attribNames.Length));

            IGenericVBO[] vbos = new IGenericVBO[2];
            vbos[0] = new GenericVBO<T1>(vbo1, attribNames[0]);
            vbos[1] = new GenericVBO<T2>(elementArray);

            Init(vbos);
        }

        [Obsolete("This VAO constructor is deprecated in favour of using VAO(ShaderProgram program, IGenericVBO[] vbos).")]
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 2) throw new Exception(string.Format("Expected an array of 2 names, but instead got {0}.", attribNames.Length));

            IGenericVBO[] vbos = new IGenericVBO[3];
            vbos[0] = new GenericVBO<T1>(vbo1, attribNames[0]);
            vbos[1] = new GenericVBO<T2>(vbo2, attribNames[1]);
            vbos[2] = new GenericVBO<int>(elementArray);

            Init(vbos);
        }
    }

    public class VAO<T1, T2, T3> : GenericVAO
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        [Obsolete("This VAO constructor is deprecated in favour of using VAO(ShaderProgram program, IGenericVBO[] vbos).")]
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, string[] attribNames, VBO<T3> elementArray)
    : base(program, false)
        {
            if (attribNames.Length != 2) throw new Exception(string.Format("Expected an array of 2 names, but instead got {0}.", attribNames.Length));

            IGenericVBO[] vbos = new IGenericVBO[3];
            vbos[0] = new GenericVBO<T1>(vbo1, attribNames[0]);
            vbos[1] = new GenericVBO<T2>(vbo2, attribNames[1]);
            vbos[2] = new GenericVBO<T3>(elementArray);

            Init(vbos);
        }

        [Obsolete("This VAO constructor is deprecated in favour of using VAO(ShaderProgram program, IGenericVBO[] vbos).")]
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 3) throw new Exception(string.Format("Expected an array of 3 names, but instead got {0}.", attribNames.Length));

            IGenericVBO[] vbos = new IGenericVBO[4];
            vbos[0] = new GenericVBO<T1>(vbo1, attribNames[0]);
            vbos[1] = new GenericVBO<T2>(vbo2, attribNames[1]);
            vbos[2] = new GenericVBO<T3>(vbo3, attribNames[2]);
            vbos[3] = new GenericVBO<int>(elementArray);

            Init(vbos);
        }
    }

    public class VAO<T1, T2, T3, T4> : GenericVAO
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        [Obsolete("This VAO constructor is deprecated in favour of using VAO(ShaderProgram program, IGenericVBO[] vbos).")]
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, string[] attribNames, VBO<T4> elementArray)
    : base(program, false)
        {
            if (attribNames.Length != 3) throw new Exception(string.Format("Expected an array of 3 names, but instead got {0}.", attribNames.Length));

            IGenericVBO[] vbos = new IGenericVBO[4];
            vbos[0] = new GenericVBO<T1>(vbo1, attribNames[0]);
            vbos[1] = new GenericVBO<T2>(vbo2, attribNames[1]);
            vbos[2] = new GenericVBO<T3>(vbo3, attribNames[2]);
            vbos[3] = new GenericVBO<T4>(elementArray);

            Init(vbos);
        }

        [Obsolete("This VAO constructor is deprecated in favour of using VAO(ShaderProgram program, IGenericVBO[] vbos).")]
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 4) throw new Exception(string.Format("Expected an array of 4 names, but instead got {0}.", attribNames.Length));

            IGenericVBO[] vbos = new IGenericVBO[5];
            vbos[0] = new GenericVBO<T1>(vbo1, attribNames[0]);
            vbos[1] = new GenericVBO<T2>(vbo2, attribNames[1]);
            vbos[2] = new GenericVBO<T3>(vbo3, attribNames[2]);
            vbos[3] = new GenericVBO<T4>(vbo4, attribNames[3]);
            vbos[4] = new GenericVBO<int>(elementArray);

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
        [Obsolete("This VAO constructor is deprecated in favour of using VAO(ShaderProgram program, IGenericVBO[] vbos).")]
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, string[] attribNames, VBO<T5> elementArray)
    : base(program, false)
        {
            if (attribNames.Length != 4) throw new Exception(string.Format("Expected an array of 4 names, but instead got {0}.", attribNames.Length));

            IGenericVBO[] vbos = new IGenericVBO[5];
            vbos[0] = new GenericVBO<T1>(vbo1, attribNames[0]);
            vbos[1] = new GenericVBO<T2>(vbo2, attribNames[1]);
            vbos[2] = new GenericVBO<T3>(vbo3, attribNames[2]);
            vbos[3] = new GenericVBO<T4>(vbo4, attribNames[3]);
            vbos[4] = new GenericVBO<T5>(elementArray);

            Init(vbos);
        }

        [Obsolete("This VAO constructor is deprecated in favour of using VAO(ShaderProgram program, IGenericVBO[] vbos).")]
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, VBO<T5> vbo5, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 5) throw new Exception(string.Format("Expected an array of 5 names, but instead got {0}.", attribNames.Length));

            IGenericVBO[] vbos = new IGenericVBO[6];
            vbos[0] = new GenericVBO<T1>(vbo1, attribNames[0]);
            vbos[1] = new GenericVBO<T2>(vbo2, attribNames[1]);
            vbos[2] = new GenericVBO<T3>(vbo3, attribNames[2]);
            vbos[3] = new GenericVBO<T4>(vbo4, attribNames[3]);
            vbos[4] = new GenericVBO<T5>(vbo5, attribNames[4]);
            vbos[5] = new GenericVBO<int>(elementArray);

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
        [Obsolete("This VAO constructor is deprecated in favour of using VAO(ShaderProgram program, IGenericVBO[] vbos).")]
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, VBO<T5> vbo5, string[] attribNames, VBO<T6> elementArray)
    : base(program, false)
        {
            if (attribNames.Length != 5) throw new Exception(string.Format("Expected an array of 5 names, but instead got {0}.", attribNames.Length));

            IGenericVBO[] vbos = new IGenericVBO[6];
            vbos[0] = new GenericVBO<T1>(vbo1, attribNames[0]);
            vbos[1] = new GenericVBO<T2>(vbo2, attribNames[1]);
            vbos[2] = new GenericVBO<T3>(vbo3, attribNames[2]);
            vbos[3] = new GenericVBO<T4>(vbo4, attribNames[3]);
            vbos[4] = new GenericVBO<T5>(vbo5, attribNames[4]);
            vbos[5] = new GenericVBO<T6>(elementArray);

            Init(vbos);
        }

        [Obsolete("This VAO constructor is deprecated in favour of using VAO(ShaderProgram program, IGenericVBO[] vbos).")]
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, VBO<T5> vbo5, VBO<T6> vbo6, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 6) throw new Exception(string.Format("Expected an array of 6 names, but instead got {0}.", attribNames.Length));

            IGenericVBO[] vbos = new IGenericVBO[7];
            vbos[0] = new GenericVBO<T1>(vbo1, attribNames[0]);
            vbos[1] = new GenericVBO<T2>(vbo2, attribNames[1]);
            vbos[2] = new GenericVBO<T3>(vbo3, attribNames[2]);
            vbos[3] = new GenericVBO<T4>(vbo4, attribNames[3]);
            vbos[4] = new GenericVBO<T5>(vbo5, attribNames[4]);
            vbos[5] = new GenericVBO<T6>(vbo6, attribNames[5]);
            vbos[6] = new GenericVBO<int>(elementArray);

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
        [Obsolete("This VAO constructor is deprecated in favour of using VAO(ShaderProgram program, IGenericVBO[] vbos).")]
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, VBO<T5> vbo5, VBO<T6> vbo6, string[] attribNames, VBO<T7> elementArray)
    : base(program, false)
        {
            if (attribNames.Length != 6) throw new Exception(string.Format("Expected an array of 6 names, but instead got {0}.", attribNames.Length));

            IGenericVBO[] vbos = new IGenericVBO[7];
            vbos[0] = new GenericVBO<T1>(vbo1, attribNames[0]);
            vbos[1] = new GenericVBO<T2>(vbo2, attribNames[1]);
            vbos[2] = new GenericVBO<T3>(vbo3, attribNames[2]);
            vbos[3] = new GenericVBO<T4>(vbo4, attribNames[3]);
            vbos[4] = new GenericVBO<T5>(vbo5, attribNames[4]);
            vbos[5] = new GenericVBO<T6>(vbo6, attribNames[5]);
            vbos[6] = new GenericVBO<T7>(elementArray);

            Init(vbos);
        }

        [Obsolete("This VAO constructor is deprecated in favour of using VAO(ShaderProgram program, IGenericVBO[] vbos).")]
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, VBO<T5> vbo5, VBO<T6> vbo6, VBO<T7> vbo7, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 7) throw new Exception(string.Format("Expected an array of 7 names, but instead got {0}.", attribNames.Length));

            IGenericVBO[] vbos = new IGenericVBO[8];
            vbos[0] = new GenericVBO<T1>(vbo1, attribNames[0]);
            vbos[1] = new GenericVBO<T2>(vbo2, attribNames[1]);
            vbos[2] = new GenericVBO<T3>(vbo3, attribNames[2]);
            vbos[3] = new GenericVBO<T4>(vbo4, attribNames[3]);
            vbos[4] = new GenericVBO<T5>(vbo5, attribNames[4]);
            vbos[5] = new GenericVBO<T6>(vbo6, attribNames[5]);
            vbos[6] = new GenericVBO<T7>(vbo7, attribNames[6]);
            vbos[7] = new GenericVBO<int>(elementArray);

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
        [Obsolete("This VAO constructor is deprecated in favour of using VAO(ShaderProgram program, IGenericVBO[] vbos).")]
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, VBO<T5> vbo5, VBO<T6> vbo6, VBO<T7> vbo7, string[] attribNames, VBO<T8> elementArray)
    : base(program, false)
        {
            if (attribNames.Length != 7) throw new Exception(string.Format("Expected an array of 7 names, but instead got {0}.", attribNames.Length));

            IGenericVBO[] vbos = new IGenericVBO[8];
            vbos[0] = new GenericVBO<T1>(vbo1, attribNames[0]);
            vbos[1] = new GenericVBO<T2>(vbo2, attribNames[1]);
            vbos[2] = new GenericVBO<T3>(vbo3, attribNames[2]);
            vbos[3] = new GenericVBO<T4>(vbo4, attribNames[3]);
            vbos[4] = new GenericVBO<T5>(vbo5, attribNames[4]);
            vbos[5] = new GenericVBO<T6>(vbo6, attribNames[5]);
            vbos[6] = new GenericVBO<T7>(vbo7, attribNames[6]);
            vbos[7] = new GenericVBO<T8>(elementArray);

            Init(vbos);
        }

        [Obsolete("This VAO constructor is deprecated in favour of using VAO(ShaderProgram program, IGenericVBO[] vbos).")]
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, VBO<T5> vbo5, VBO<T6> vbo6, VBO<T7> vbo7, VBO<T8> vbo8, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 8) throw new Exception(string.Format("Expected an array of 8 names, but instead got {0}.", attribNames.Length));

            IGenericVBO[] vbos = new IGenericVBO[9];
            vbos[0] = new GenericVBO<T1>(vbo1, attribNames[0]);
            vbos[1] = new GenericVBO<T2>(vbo2, attribNames[1]);
            vbos[2] = new GenericVBO<T3>(vbo3, attribNames[2]);
            vbos[3] = new GenericVBO<T4>(vbo4, attribNames[3]);
            vbos[4] = new GenericVBO<T5>(vbo5, attribNames[4]);
            vbos[5] = new GenericVBO<T6>(vbo6, attribNames[5]);
            vbos[6] = new GenericVBO<T7>(vbo7, attribNames[6]);
            vbos[7] = new GenericVBO<T8>(vbo8, attribNames[7]);
            vbos[8] = new GenericVBO<int>(elementArray);

            Init(vbos);
        }
    }

    public class GenericVAO : IDisposable
    {
        #region Private Fields
        private static readonly Dictionary<VertexAttribPointerType, DrawElementsType> ValidElementTypes = new Dictionary<VertexAttribPointerType, DrawElementsType>()
        {
            [VertexAttribPointerType.UnsignedByte] = DrawElementsType.UnsignedByte,
            [VertexAttribPointerType.UnsignedShort] = DrawElementsType.UnsignedShort,
            [VertexAttribPointerType.UnsignedInt] = DrawElementsType.UnsignedInt
        };
        #endregion

        #region Generic VBO
        public IGenericVBO[] vbos;

        public struct GenericVBO<T> : IGenericVBO
            where T : struct
        {
            private readonly VBO<T> vbo;
            private readonly string name;

            public uint ID { get { return vbo.ID; } }
            public uint vboID { get { return vbo.ID; } }

            public string Name { get { return name; } }

            public VertexAttribPointerType PointerType { get { return vbo.PointerType; } }

            public int Length { get { return vbo.Count; } }

            public BufferTarget BufferTarget { get { return vbo.BufferTarget; } }

            public int Size { get { return vbo.Size; } }

            public uint Divisor { get { return vbo.Divisor; } }

            public bool Normalize { get { return vbo.Normalize; } }

            public bool CastToFloat { get { return vbo.CastToFloat; } }

            public bool IsIntegralType { get { return vbo.IsIntegralType; } }

            public GenericVBO(VBO<T> vbo) : this(vbo, string.Empty)
            {
            }

            public GenericVBO(VBO<T> vbo, string name)
            {
                this.vbo = vbo;
                this.name = name;
            }

            /// <summary>
            /// Deletes the vertex array from the GPU and will also dispose of any child VBOs if (DisposeChildren == true).
            /// </summary>
            public void Dispose()
            {
                Dispose(true);
            }

            private void Dispose(bool disposing)
            {
                if (disposing)
                {
                    vbo.Dispose();
                }
            }
        }
        #endregion

        #region Constructor and Destructor
        public GenericVAO(ShaderProgram program)
        {
            Program = program;
            DrawMode = BeginMode.Triangles;
        }

        public GenericVAO(ShaderProgram program, bool allowIntAsElementType)
        {
            Program = program;
            DrawMode = BeginMode.Triangles;
            this.allowIntAsElementType = allowIntAsElementType;
        }

        public void Init(IGenericVBO[] vbos)
        {
            this.vbos = vbos;

            if (Gl.Version() >= 3)
            {
                ID = Gl.GenVertexArray();
                if (ID != 0)
                {
                    Gl.BindVertexArray(ID);
                    BindAttributes(Program);
                }
                Gl.BindVertexArray(0);

                Draw = DrawOGL3;
                DrawInstanced = DrawInstancedOGL3;

                if (Gl.Version() >= 4 && Gl.VersionMinor() >= 3)
                {
                    MultiDrawElementsIndirect = MultiDrawElementsIndirectOGL43;
                }
                else
                {
                    MultiDrawElementsIndirect = MultiDrawElementsIndirectOGLTooOld;
                }
            }
            else
            {
                Draw = DrawOGL2;
                DrawInstanced = DrawInstancedOGL2;
                MultiDrawElementsIndirect = MultiDrawElementsIndirectOGLTooOld;
            }
        }

        ~GenericVAO()
        {
            Dispose(false);
        }
        #endregion

        #region Properties
        private bool disposeChildren = false;
        private DrawElementsType elementType;
        public DrawElementsType ElementType { get { return elementType; } }
        private bool allowIntAsElementType = true;
        private int offset = 0;
        private IntPtr offsetInBytes = IntPtr.Zero;
        public IntPtr OffsetInBytes { get { return offsetInBytes; } }

        /// <summary>
        /// The offset into the element array buffer that this VAO begins.
        /// </summary>
        public int Offset
        {
            get { return offset; }
            set
            {
                offset = value;
                offsetInBytes = (IntPtr)(offset * GetElementSizeInBytes());
            }
        }

        /// <summary>
        /// The number of vertices that make up this VAO.
        /// </summary>
        public int VertexCount { get; set; }

        /// <summary>
        /// Specifies if the VAO should dispose of the child VBOs when Dispose() is called.
        /// </summary>
        public bool DisposeChildren
        {
            get { return disposeChildren; }
            set
            {
                disposeChildren = value;
                DisposeElementArray = value;    // TODO:  I think this is bad behaviour
            }
        }

        /// <summary>
        /// Specifies if the VAO should dispose of the element array when Dispose() is called.
        /// </summary>
        public bool DisposeElementArray { get; set; }

        /// <summary>
        /// The ShaderProgram associated with this VAO.
        /// </summary>
        public ShaderProgram Program { get; private set; }

        /// <summary>
        /// The drawing mode to use when drawing the arrays.
        /// </summary>
        public BeginMode DrawMode { get; set; }

#pragma warning disable IDE1006
        /// <summary>
        /// The ID of this Vertex Array Object for use in calls to OpenGL.
        /// </summary>
        [Obsolete("Use ID instead.")]
        public uint vaoID
        {
             get { return ID; }
            private set { ID = value; }
        }
#pragma warning restore

        /// <summary>
        /// The ID of this Vertex Array Object for use in calls to OpenGL.
        /// </summary>
        public uint ID { get; private set; }
        #endregion

        #region Draw Methods (OGL2 and OGL3)
        private int GetElementSizeInBytes()
        {
            switch (elementType)
            {
                case DrawElementsType.UnsignedByte:
                    return 1;
                case DrawElementsType.UnsignedShort:
                    return 2;
                case DrawElementsType.UnsignedInt:
                    return 4;
                default:
                    throw new Exception($"Unknown enum value. Expected an enum of type {nameof(DrawElementsType)}.");
            }
        }

        public void BindAttributes(ShaderProgram program)
        {
            IGenericVBO elementArray = null;

            for (int i = 0; i < vbos.Length; i++)
            {
                if (vbos[i].BufferTarget == BufferTarget.ElementArrayBuffer)
                {
                    elementArray = vbos[i];

                    // To not break compatibility with previous versions of this call,
                    // int is allowed as an element type even though the specs don't allow it.
                    // All cases where int is used as the default element type have been marked obsolete
                    //but until it's completely removed , this will serve to support that use case.
                    if (allowIntAsElementType && vbos[i].PointerType == VertexAttribPointerType.Int)
                    {
                        elementType = DrawElementsType.UnsignedInt;
                    }
                    else
                    {
                        // Check if the element array can be used as an indice buffer.
                        if (!ValidElementTypes.ContainsKey(vbos[i].PointerType))
                        {
                            throw new Exception($"The element buffer must be an unsigned integral type. See {nameof(DrawElementsType)} enum for valid types.");
                        }
                        elementType = ValidElementTypes[vbos[i].PointerType];
                    }
                    continue;
                }
                else if (vbos[i].BufferTarget == BufferTarget.DrawIndirectBuffer)
                {
                    continue;
                }

                // According to OGL spec then, if there is no location for an attribute, -1 is returned.
                // The same error representation is used here.
                int loc = program[vbos[i].Name]?.Location ?? -1;
                if (loc == -1) throw new Exception(string.Format("Shader did not contain '{0}'.", vbos[i].Name));

                Gl.EnableVertexAttribArray((uint)loc);
                Gl.BindBuffer(vbos[i].BufferTarget, vbos[i].ID);

                if (vbos[i].CastToFloat)
                {
                    Gl.VertexAttribPointer((uint)loc, vbos[i].Size, vbos[i].PointerType, vbos[i].Normalize, 0, IntPtr.Zero);
                }
                else if (vbos[i].IsIntegralType)
                {
                    Gl.VertexAttribIPointer((uint)loc, vbos[i].Size, vbos[i].PointerType, 0, IntPtr.Zero);
                }
                else if (vbos[i].PointerType == VertexAttribPointerType.Double)
                {
                    Gl.VertexAttribLPointer((uint)loc, vbos[i].Size, vbos[i].PointerType, 0, IntPtr.Zero);
                }
                else
                {
                    throw new Exception("VBO shouldn't be cast to float, isn't an integral type and is not a float. No vertex attribute support this combination.");
                }

                // 0 is the divisors default value.
                // No need to set the divisor to its default value.
                if (vbos[i].Divisor != 0)
                {
                    Gl.VertexAttribDivisor((uint)loc, vbos[i].Divisor);
                }
            }

            if (elementArray != null)
            {
                Gl.BindBuffer(BufferTarget.ElementArrayBuffer, elementArray.ID);
                VertexCount = elementArray.Length;
            }
        }

        public delegate void DrawFunc();
        public delegate void DrawInstancedFunc(int count);
        public delegate void MultiDrawElementsIndirectFunc(VBO<DrawElementsIndirectCommand> cmdVBO, int cmdCount);

        public DrawFunc Draw;
        public DrawInstancedFunc DrawInstanced;
        public MultiDrawElementsIndirectFunc MultiDrawElementsIndirect;

        /// <summary>
        /// OGL3 method uses a vertex array object for quickly binding the VBOs to their attributes.
        /// </summary>
        private void DrawOGL3()
        {
            if (ID == 0 || VertexCount == 0) return;
            Gl.BindVertexArray(ID);
            Gl.DrawElements(DrawMode, VertexCount, elementType, offsetInBytes);
            Gl.BindVertexArray(0);
        }

        /// <summary>
        /// OGL2 does not support VAOs, and instead must bind the VBOs to their attributes manually.
        /// </summary>
        private void DrawOGL2()
        {
            if (VertexCount == 0) return;
            BindAttributes(Program);
            Gl.DrawElements(DrawMode, VertexCount, elementType, offsetInBytes);
        }

        /// <summary>
        /// OGL3 method uses a vertex array object for quickly binding the VBOs to their attributes.
        /// </summary>
        private void DrawInstancedOGL3(int count)
        {
            if (ID == 0 || VertexCount == 0 || count == 0) return;
            Gl.BindVertexArray(ID);
            Gl.DrawElementsInstanced(DrawMode, VertexCount, elementType, IntPtr.Zero, count);
            Gl.BindVertexArray(0);
        }

        /// <summary>
        /// OGL2 does not support Gl.DrawElementsInstanced.
        /// </summary>
        private void DrawInstancedOGL2(int count)
        {
            throw new Exception("The Function glDrawElementsInstanced was first added in OpenGL 3.1 which is not supported on this system.");
        }

        /// <summary>
        /// OGL4 method uses a vertex array object for quickly binding the VBOs to their attributes.
        /// </summary>
        private void MultiDrawElementsIndirectOGL43(VBO<DrawElementsIndirectCommand> cmdVBO, int cmdCount)
        {
            if (ID == 0) return;
            Gl.BindVertexArray(ID);
            Gl.BindBuffer(cmdVBO);
            Gl.MultiDrawElementsIndirect(DrawMode, elementType, IntPtr.Zero, cmdCount, 0);
            Gl.BindVertexArray(0);
        }

        /// <summary>
        /// OGL version does not support Gl.MultiDrawElementsIndirect.
        /// </summary>
        private void MultiDrawElementsIndirectOGLTooOld(VBO<DrawElementsIndirectCommand> cmdVBO, int cmdCount)
        {
            throw new Exception("The Function glMultiDrawElementsIndirect was first added in OpenGL 4.3 which is not supported on this system.");
        }

        /// <summary>
        /// Performs the draw routine with a custom shader program.
        /// </summary>
        /// <param name="program"></param>
        public void DrawProgram(ShaderProgram program)
        {
            BindAttributes(program);
            Gl.DrawElements(DrawMode, VertexCount, elementType, offsetInBytes);
        }
        #endregion

        #region IDisposable
        /// <summary>
        /// Deletes the vertex array from the GPU and will also dispose of any child VBOs if (DisposeChildren == true).
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // first try to dispose of the vertex array
            if (ID != 0)
            {
                Gl.DeleteVertexArray(ID);

                ID = 0;
            }

            // children must be disposed of separately since OpenGL 2.1 will not have a vertex array
            if (DisposeChildren)
            {
                for (int i = 0; i < vbos.Length; i++)
                {
                    if (vbos[i].BufferTarget == BufferTarget.ElementArrayBuffer && !DisposeElementArray) continue;
                    vbos[i].Dispose();
                }
            }
        }
        #endregion
    }

    public class VAO : GenericVAO, IDisposable
    {
        #region Constructors and Destructor
        [Obsolete("Use VBO<uint> instead of VBO<int> as the element array buffer.")]
        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<int> element)
            : this(program, vertex, null, null, null, element)
        {
        }

        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<uint> element)
            : this(program, vertex, null, null, null, element)
        {
        }

        [Obsolete("Use VBO<uint> instead of VBO<int> as the element array buffer.")]
        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<Vector2> uv, VBO<int> element)
            : this(program, vertex, null, null, uv, element)
        {
        }

        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<Vector2> uv, VBO<uint> element)
            : this(program, vertex, null, null, uv, element)
        {
        }

        [Obsolete("Use VBO<uint> instead of VBO<int> as the element array buffer.")]
        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<Vector3> normal, VBO<int> element)
            : this(program, vertex, normal, null, null, element)
        {
        }

        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<Vector3> normal, VBO<uint> element)
            : this(program, vertex, normal, null, null, element)
        {
        }

        [Obsolete("Use VBO<uint> instead of VBO<int> as the element array buffer.")]
        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<Vector3> normal, VBO<Vector2> uv, VBO<int> element)
            : this(program, vertex, normal, null, uv, element)
        {
        }

        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<Vector3> normal, VBO<Vector2> uv, VBO<uint> element)
            : this(program, vertex, normal, null, uv, element)
        {
        }

        [Obsolete("Use VBO<uint> instead of VBO<int> as the element array buffer.")]
        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<Vector3> normal, VBO<Vector3> tangent, VBO<Vector2> uv, VBO<int> element)
            : base(program, true)
        {
            InitDefaultVAO(vertex, normal, tangent, uv, element);
        }

        public VAO(ShaderProgram program, VBO<Vector3> vertex, VBO<Vector3> normal, VBO<Vector3> tangent, VBO<Vector2> uv, VBO<uint> element)
            : base(program, false)
        {
            InitDefaultVAO(vertex, normal, tangent, uv, element);
        }

        public VAO(ShaderProgram program, IGenericVBO[] vbos)
            : base(program, false)
        {
            Init(vbos);
        }

        private void InitDefaultVAO<T>(VBO<Vector3> vertex, VBO<Vector3> normal, VBO<Vector3> tangent, VBO<Vector2> uv, VBO<T> element)
            where T : struct
        {
            List<IGenericVBO> vbos = new List<IGenericVBO>();

            if (vertex != null)
            {
                vbos.Add(new GenericVBO<Vector3>(vertex, "in_position"));
            }
            if (normal != null)
            {
                vbos.Add(new GenericVBO<Vector3>(normal, "in_normal"));
            }
            if (tangent != null)
            {
                vbos.Add(new GenericVBO<Vector3>(tangent, "in_tangent"));
            }
            if (uv != null)
            {
                vbos.Add(new GenericVBO<Vector2>(uv, "in_uv"));
            }
            vbos.Add(new GenericVBO<T>(element));

            Init(vbos.ToArray());
        }

        ~VAO()
        {
            Dispose(false);
        }
        #endregion
    }
}
