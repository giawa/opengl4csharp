using System;
using System.Runtime.InteropServices;

#if USE_NUMERICS
using System.Numerics;
#endif

#if MEMORY_LOGGER
using System.Collections.Generic;
#endif

namespace OpenGL
{
    #region Simple Memory Logging for Debugging
#if MEMORY_LOGGER
    public static class MemoryLogger
    {
        /// <summary>
        /// Configures the memory logger to log a stack trace with each allocated texture or VBO.
        /// </summary>
        public static bool LogStackTrace { get; set; }

        /// <summary>
        /// Gets the size in bytes of all of the textures that have been allocated.
        /// </summary>
        public static long TotalTextureMemory = 0;

        /// <summary>
        /// Gets the size in bytes of all of the VBOs that have been allocated.
        /// </summary>
        public static long TotalVBOMemory = 0;

        private static readonly Dictionary<uint, string> validTextures = new Dictionary<uint, string>();
        private static Dictionary<uint, int> validVBOs = new Dictionary<uint, int>();
        private static Dictionary<uint, string> validVBOStackTrace = new Dictionary<uint, string>();

        internal static void AllocateTexture(uint textureID, System.Drawing.Size size)
        {
            TotalTextureMemory += size.Height * size.Width * 4;
            if (LogStackTrace) validTextures.Add(textureID, Environment.StackTrace);
            else validTextures.Add(textureID, String.Empty);
        }

        internal static void DestroyTexture(uint textureID, System.Drawing.Size size)
        {
            if (validTextures.ContainsKey(textureID))
            {
                TotalTextureMemory -= size.Height * size.Width * 4;
                validTextures.Remove(textureID);
            }
        }

        internal static void AllocateVBO(uint id, int bytes)
        {
            if (validVBOs.ContainsKey(id))
            {
                TotalVBOMemory += bytes - validVBOs[id];
                validVBOs[id] = bytes;
                if (LogStackTrace) validVBOStackTrace[id] = Environment.StackTrace;
            }
            else
            {
                TotalVBOMemory += bytes;
                validVBOs.Add(id, bytes);
                if (LogStackTrace) validVBOStackTrace.Add(id, Environment.StackTrace);
            }
        }

        internal static void DestroyVBO(uint id)
        {
            if (!validVBOs.ContainsKey(id)) return;

            TotalVBOMemory -= validVBOs[id];

            validVBOs.Remove(id);
            if (validVBOStackTrace.ContainsKey(id)) validVBOStackTrace.Remove(id);
        }

        public static Dictionary<uint, string> TextureStackTraces
        {
            get { return validTextures; }
        }

        public static Dictionary<uint, string> VBOStackTraces
        {
            get { return validVBOStackTrace; }
        }
    }
#endif
    #endregion

    /// <summary>
    /// Bindings to OpenGL 4.5 methods as well as some helper shortcuts.
    /// </summary>
    partial class Gl
    {
        #region Preallocated Memory
        // pre-allocate the float[] for matrix and array data
        private static float[] float1 = new float[1];
        private static float[] matrix4Float = new float[16];
        private static float[] matrix3Float = new float[9];
        private static double[] double1 = new double[1];
        private static uint[] uint1 = new uint[1];
        private static int[] int1 = new int[1];
        private static bool[] bool1 = new bool[1];
        #endregion

        #region Private Fields
        private static int version = 0;
        private static int versionMinor = 0;
        private static uint currentProgram = 0;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the program ID of the currently active shader program.
        /// </summary>
        public static uint CurrentProgram
        {
            get { return currentProgram; }
        }
        #endregion

        #region OpenGL Helpers (Type Safe Equivalents or Shortcuts)
        /// <summary>
        /// Select active texture unit.
        /// <para>
        /// glActiveTexture selects which texture unit subsequent texture state calls will affect. The number of
        /// texture units an implementation supports is implementation dependent, but must be at least 80.
        /// </para>
        /// </summary>
        /// <param name="texture">
        /// Specifies which texture unit to make active. The number of texture units is implementation
        /// dependent, but must be at least 80. texture must be a value between 0 and 
        /// GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS minus one. The initial value is 0.
        /// </param>
        public static void ActiveTexture(int texture)
        {
#pragma warning disable CS0618
            Delegates.glActiveTexture((int)TextureUnit.Texture0 + texture);
#pragma warning restore
        }

        /// <summary>
        /// Returns the boolean value of a selected parameter.
        /// </summary>
        /// <param name="pname">A parameter that returns a single boolean.</param>
        public static bool GetBoolean(GetPName pname)
        {
            GetBooleanv(pname, bool1);
            return bool1[0];
        }

        /// <summary>
        /// Returns the float value of a selected parameter.
        /// </summary>
        /// <param name="pname">A parameter that returns a single float.</param>
        public static float GetFloat(GetPName pname)
        {
            GetFloatv(pname, float1);
            return float1[0];
        }

        /// <summary>
        /// Returns the double value of a selected parameter.
        /// </summary>
        /// <param name="pname">A parameter that returns a single double.</param>
        public static double GetDouble(GetPName pname)
        {
            GetDoublev(pname, double1);
            return double1[0];
        }

        /// <summary>
        /// Returns the integer value of a selected parameter.
        /// </summary>
        /// <param name="name">A parameter that returns a single integer.</param>
        public static int GetInteger(GetPName name)
        {
            GetIntegerv(name, int1);
            return int1[0];
        }

        /// <summary>
        /// Set a scalar texture parameter.
        /// </summary>
        /// <param name="target">Specificies the target for which the texture is bound.</param>
        /// <param name="pname">Specifies the name of a single-values texture parameter.</param>
        /// <param name="param">Specifies the value of pname.</param>
        public static void TexParameteri(TextureTarget target, TextureParameterName pname, TextureParameter param)
        {
            Delegates.glTexParameteri(target, pname, (int)param);
        }

        /// <summary>
        /// Set a vector texture parameter.
        /// </summary>
        /// <param name="target">Specificies the target for which the texture is bound.</param>
        /// <param name="pname">Specifies the name of a single-values texture parameter.</param>
        /// <param name="params"></param>
        public static void TexParameteriv(TextureTarget target, TextureParameterName pname, TextureParameter[] @params)
        {
            int[] iparams = new int[@params.Length];
            for (int i = 0; i < iparams.Length; i++) iparams[i] = (int)@params[i];
            Delegates.glTexParameteriv(target, pname, iparams);
        }

        /// <summary>
        /// Shortcut for quickly generating a single buffer id without creating an array to
        /// pass to the gl function.  Calls Gl.GenBuffers(1, id).
        /// </summary>
        /// <returns>The ID of the generated buffer.  0 on failure.</returns>
        public static uint GenBuffer()
        {
            uint1[0] = 0;
            Gl.GenBuffers(1, uint1);
            return uint1[0];
        }

        /// <summary>
        /// Shortcut for quickly generating a single texture id without creating an array to
        /// pass to the gl function.  Calls Gl.GenTexture(1, id).
        /// </summary>
        /// <returns>The ID of the generated texture.  0 on failure.</returns>
        public static uint GenTexture()
        {
            uint1[0] = 0;
            Gl.GenTextures(1, uint1);
            return uint1[0];
        }

        /// <summary>
        /// Shortcut for deleting a single texture without created an array to pass to the gl function.
        /// Calls Gl.DeleteTextures(1, id).
        /// </summary>
        /// <param name="texture">The ID of the texture to delete.</param>
        public static void DeleteTexture(uint texture)
        {
            uint1[0] = texture;
            Gl.DeleteTextures(1, uint1);
        }

        /// <summary>
        /// Shortcut for quickly generating a single vertex array id without creating an array to
        /// pass to the gl function.  Calls Gl.GenVertexArrays(1, id).
        /// </summary>
        /// <returns>The ID of the generated vertex array.  0 on failure.</returns>
        public static uint GenVertexArray()
        {
            uint1[0] = 0;
            Gl.GenVertexArrays(1, uint1);
            return uint1[0];
        }

        /// <summary>
        /// Shortcut for deleting a single texture without created an array to pass to the gl function.
        /// Calls Gl.DeleteVertexArrays(1, id).
        /// </summary>
        /// <param name="vao">The ID of the vertex array to delete.</param>
        public static void DeleteVertexArray(uint vao)
        {
            uint1[0] = vao;
            Gl.DeleteVertexArrays(1, uint1);
        }

        /// <summary>
        /// Shortcut for quickly generating a single framebuffer object without creating an array
        /// to pass to the gl function.  Calls Gl.GenFramebuffers(1, id).
        /// </summary>
        /// <returns>The ID of the generated framebuffer.  0 on failure.</returns>
        public static uint GenFramebuffer()
        {
            uint1[0] = 0;
            Gl.GenFramebuffers(1, uint1);
            return uint1[0];
        }

        /// <summary>
        /// Shortcut for deleting a framebuffer without created an array to pass to the gl function.
        /// Calls Gl.DeleteFramebuffers(1, id).
        /// </summary>
        /// <param name="framebuffer">The ID of the vertex array to delete.</param>
        public static void DeleteFramebuffer(uint framebuffer)
        {
            uint1[0] = framebuffer;
            Gl.DeleteFramebuffers(1, uint1);
        }

        /// <summary>
        /// Shortcut for quickly generating a single renderbuffer object without creating an array
        /// to pass to the gl function.  Calls Gl.GenRenderbuffers(1, id).
        /// </summary>
        /// <returns>The ID of the generated framebuffer.  0 on failure.</returns>
        public static uint GenRenderbuffer()
        {
            uint1[0] = 0;
            Gl.GenRenderbuffers(1, uint1);
            return uint1[0];
        }

        /// <summary>
        /// Gets whether the shader compiled successfully.
        /// </summary>
        /// <param name="shader">The ID of the shader program.</param>
        /// <returns></returns>
        public static bool GetShaderCompileStatus(UInt32 shader)
        {
            const int SUCCESS = 1;
            Gl.GetShaderiv(shader, ShaderParameter.CompileStatus, int1);
            return int1[0] == SUCCESS;
        }

        /// <summary>
        /// Get whether program linking was performed successfully.
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        public static bool GetProgramLinkStatus(UInt32 program)
        {
            const int SUCCESS = 1;
            Gl.GetProgramiv(program, ProgramParameter.LinkStatus, int1);
            return int1[0] == SUCCESS;
        }

        /// <summary>
        /// Gets the program info from a shader program.
        /// </summary>
        /// <param name="program">The ID of the shader program.</param>
        public static string GetProgramInfoLog(UInt32 program)
        {
            Gl.GetProgramiv(program, ProgramParameter.InfoLogLength, int1);
            if (int1[0] == 0) return String.Empty;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(int1[0]);
            Gl.GetProgramInfoLog(program, sb.Capacity, int1, sb);
            return sb.ToString();
        }

        /// <summary>
        /// Gets the program info from a shader program.
        /// </summary>
        /// <param name="shader">The ID of the shader program.</param>
        public static string GetShaderInfoLog(UInt32 shader)
        {
            Gl.GetShaderiv(shader, ShaderParameter.InfoLogLength, int1);
            if (int1[0] == 0) return String.Empty;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(int1[0]);
            Gl.GetShaderInfoLog(shader, sb.Capacity, int1, sb);
            return sb.ToString();
        }

        /// <summary>
        /// Replaces the source code in a shader object.
        /// </summary>
        /// <param name="shader">Specifies the handle of the shader object whose source code is to be replaced.</param>
        /// <param name="source">Specifies a string containing the source code to be loaded into the shader.</param>
        public static void ShaderSource(UInt32 shader, string source)
        {
            int1[0] = source.Length;
            Gl.ShaderSource(shader, 1, new string[] { source }, int1);
        }

        /// <summary>
        /// Creates and initializes a buffer object's data store.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Specifies the target buffer object.</param>
        /// <param name="size">Specifies the size in bytes of the buffer object's new data store.</param>
        /// <param name="data">Specifies a pointer to data that will be copied into the data store for initialization, or NULL if no data is to be copied.</param>
        /// <param name="usage">Specifies expected usage pattern of the data store.</param>
        public static void BufferData<T>(BufferTarget target, Int32 size, [In, Out] T[] data, BufferUsageHint usage)
            where T : struct
        {
            GCHandle data_ptr = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                Delegates.glBufferData(target, new IntPtr(size), data_ptr.AddrOfPinnedObject(), usage);
            }
            finally
            {
                data_ptr.Free();
            }
        }

        /// <summary>
        /// Creates and initializes an empty buffer object's data store.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Specifies the target buffer object.</param>
        /// <param name="size">Specifies the size in bytes of the buffer object's new data store.</param>
        /// <param name="usage">Specifies expected usage pattern of the data store.</param>
        public static void BufferData<T>(BufferTarget target, Int32 size, BufferUsageHint usage)
            where T : struct
        {
            Delegates.glBufferData(target, new IntPtr(size), IntPtr.Zero, usage);
        }

        /// <summary>
        /// Creates and initializes a buffer object's data store.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Specifies the target buffer object.</param>
        /// <param name="position">Offset into the data from which to start copying to the buffer.</param>
        /// <param name="size">Specifies the size in bytes of the buffer object's new data store.</param>
        /// <param name="data">Specifies a pointer to data that will be copied into the data store for initialization, or NULL if no data is to be copied.</param>
        /// <param name="usage">Specifies expected usage pattern of the data store.</param>
        public static void BufferData<T>(BufferTarget target, Int32 position, Int32 size, [In, Out] T[] data, BufferUsageHint usage)
            where T : struct
        {
            GCHandle data_ptr = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                Delegates.glBufferData(target, new IntPtr(size), (IntPtr)((int)data_ptr.AddrOfPinnedObject() + position), usage);
            }
            finally
            {
                data_ptr.Free();
            }
        }

        /// <summary>
        /// Creates a standard VBO of type T.
        /// </summary>
        /// <typeparam name="T">The type of the data being stored in the VBO (make sure it's byte aligned).</typeparam>
        /// <param name="target">The VBO BufferTarget (usually ArrayBuffer or ElementArrayBuffer).</param>
        /// <param name="data">The data to store in the VBO.</param>
        /// <param name="hint">The buffer usage hint (usually StaticDraw).</param>
        /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
        public static uint CreateVBO<T>(BufferTarget target, [In, Out] T[] data, BufferUsageHint hint)
            where T : struct
        {
            uint vboHandle = Gl.GenBuffer();
            if (vboHandle == 0) return 0;

            int size = data.Length * Marshal.SizeOf<T>();

#if MEMORY_LOGGER
            MemoryLogger.AllocateVBO(vboHandle, size);
#endif

            Gl.BindBuffer(target, vboHandle);
            Gl.BufferData<T>(target, size, data, hint);
            Gl.BindBuffer(target, 0);
            return vboHandle;
        }

        /// <summary>
        /// Creates a standard VBO of type T where the length of the VBO is less than or equal to the length of the data.
        /// </summary>
        /// <typeparam name="T">The type of the data being stored in the VBO (make sure it's byte aligned).</typeparam>
        /// <param name="target">The VBO BufferTarget (usually ArrayBuffer or ElementArrayBuffer).</param>
        /// <param name="data">The data to store in the VBO.</param>
        /// <param name="hint">The buffer usage hint (usually StaticDraw).</param>
        /// <param name="length">The length of the VBO (will take the first 'length' elements from data).</param>
        /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
        public static uint CreateVBO<T>(BufferTarget target, [In, Out] T[] data, BufferUsageHint hint, int length)
            where T : struct
        {
            uint vboHandle = Gl.GenBuffer();
            if (vboHandle == 0) return 0;

            int size = length * Marshal.SizeOf<T>();

#if MEMORY_LOGGER
            MemoryLogger.AllocateVBO(vboHandle, size);
#endif

            Gl.BindBuffer(target, vboHandle);
            Gl.BufferData<T>(target, size, data, hint);
            Gl.BindBuffer(target, 0);
            return vboHandle;
        }

        /// <summary>
        /// Creates a standard VBO of type T where the length of the VBO is less than or equal to the length of the data.
        /// </summary>
        /// <typeparam name="T">The type of the data being stored in the VBO (make sure it's byte aligned).</typeparam>
        /// <param name="target">The VBO BufferTarget (usually ArrayBuffer or ElementArrayBuffer).</param>
        /// <param name="data">The data to store in the VBO.</param>
        /// <param name="hint">The buffer usage hint (usually StaticDraw).</param>
        /// <param name="position">Starting element of the data that will be copied into the VBO.</param>
        /// <param name="length">The length of the VBO (will take the first 'length' elements from data).</param>
        /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
        public static uint CreateVBO<T>(BufferTarget target, [In, Out] T[] data, BufferUsageHint hint, int position, int length)
            where T : struct
        {
            uint vboHandle = Gl.GenBuffer();
            if (vboHandle == 0) return 0;

            int offset = position * Marshal.SizeOf<T>();
            int size = length * Marshal.SizeOf<T>();

#if MEMORY_LOGGER
            MemoryLogger.AllocateVBO(vboHandle, size - offset);
#endif

            Gl.BindBuffer(target, vboHandle);
            Gl.BufferData<T>(target, offset, size, data, hint);
            Gl.BindBuffer(target, 0);
            return vboHandle;
        }

        /// <summary>
        /// Creates a standard VBO of type T with a specified length.
        /// </summary>
        /// <typeparam name="T">The type of the data being stored in the VBO (make sure it's byte aligned).</typeparam>
        /// <param name="target">The VBO BufferTarget (usually ArrayBuffer or ElementArrayBuffer).</param>
        /// <param name="hint">The buffer usage hint (usually StaticDraw).</param>
        /// <param name="length">The length of the VBO.</param>
        /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
        public static uint CreateVBO<T>(BufferTarget target, BufferUsageHint hint, int length)
            where T : struct
        {
            uint vboHandle = Gl.GenBuffer();
            if (vboHandle == 0) return 0;

            int size = length * Marshal.SizeOf<T>();

#if MEMORY_LOGGER
            MemoryLogger.AllocateVBO(vboHandle, size);
#endif

            Gl.BindBuffer(target, vboHandle);
            Gl.BufferData<T>(target, size, hint);
            Gl.BindBuffer(target, 0);
            return vboHandle;
        }

        /// <summary>
        /// Creates an interleaved VBO that contains both Vector3 and Vector3 data (typically position and normal data).
        /// </summary>
        /// <param name="target">The VBO buffer target.</param>
        /// <param name="data1">The first array of Vector3 data (usually position).</param>
        /// <param name="data2">The second array of Vector3 data (usually normal).</param>
        /// <param name="hint">Specifies expected usage pattern of the data store.</param>
        /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
        public static uint CreateInterleavedVBO(BufferTarget target, Vector3[] data1, Vector3[] data2, BufferUsageHint hint)
        {
            if (data2.Length != data1.Length) throw new Exception("Data lengths must be identical to construct an interleaved VBO.");

            float[] interleaved = new float[data1.Length * 6];

            for (int i = 0, j = 0; i < data1.Length; i++)
            {
                interleaved[j++] = data1[i].X;
                interleaved[j++] = data1[i].Y;
                interleaved[j++] = data1[i].Z;

                interleaved[j++] = data2[i].X;
                interleaved[j++] = data2[i].Y;
                interleaved[j++] = data2[i].Z;
            }

            return CreateVBO<float>(target, interleaved, hint);
        }

        /// <summary>
        /// Creates an interleaved VBO that contains Vector3, Vector3 and Vector2 data (typically position, normal and UV data).
        /// </summary>
        /// <param name="target">The VBO buffer target.</param>
        /// <param name="data1">The first array of Vector3 data (usually position).</param>
        /// <param name="data2">The second array of Vector3 data (usually normal).</param>
        /// <param name="data3">The Vector2 data (usually UV).</param>
        /// <param name="hint">Specifies expected usage pattern of the data store.</param>
        /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
        public static uint CreateInterleavedVBO(BufferTarget target, Vector3[] data1, Vector3[] data2, Vector2[] data3, BufferUsageHint hint)
        {
            if (data2.Length != data1.Length || data3.Length != data1.Length) throw new Exception("Data lengths must be identical to construct an interleaved VBO.");

            float[] interleaved = new float[data1.Length * 8];

            for (int i = 0, j = 0; i < data1.Length; i++)
            {
                interleaved[j++] = data1[i].X;
                interleaved[j++] = data1[i].Y;
                interleaved[j++] = data1[i].Z;

                interleaved[j++] = data2[i].X;
                interleaved[j++] = data2[i].Y;
                interleaved[j++] = data2[i].Z;

                interleaved[j++] = data3[i].X;
                interleaved[j++] = data3[i].Y;
            }

            return CreateVBO<float>(target, interleaved, hint);
        }

        /// <summary>
        /// Creates an interleaved VBO that contains Vector3, Vector3 and Vector3 data (typically position, normal and tangent data).
        /// </summary>
        /// <param name="target">The VBO buffer target.</param>
        /// <param name="data1">The first array of Vector3 data (usually position).</param>
        /// <param name="data2">The second array of Vector3 data (usually normal).</param>
        /// <param name="data3">The third array of Vector3 data (usually tangent).</param>
        /// <param name="hint">Specifies expected usage pattern of the data store.</param>
        /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
        public static uint CreateInterleavedVBO(BufferTarget target, Vector3[] data1, Vector3[] data2, Vector3[] data3, BufferUsageHint hint)
        {
            if (data2.Length != data1.Length || data3.Length != data1.Length) throw new Exception("Data lengths must be identical to construct an interleaved VBO.");

            float[] interleaved = new float[data1.Length * 9];

            for (int i = 0, j = 0; i < data1.Length; i++)
            {
                interleaved[j++] = data1[i].X;
                interleaved[j++] = data1[i].Y;
                interleaved[j++] = data1[i].Z;

                interleaved[j++] = data2[i].X;
                interleaved[j++] = data2[i].Y;
                interleaved[j++] = data2[i].Z;

                interleaved[j++] = data3[i].X;
                interleaved[j++] = data3[i].Y;
                interleaved[j++] = data3[i].Z;
            }

            return CreateVBO<float>(target, interleaved, hint);
        }

        /// <summary>
        /// Creates an interleaved VBO that contains Vector3, Vector3, Vector3 and Vector2 data (typically position, normal, tangent and UV data).
        /// </summary>
        /// <param name="target">The VBO buffer target.</param>
        /// <param name="data1">The first array of Vector3 data (usually position).</param>
        /// <param name="data2">The second array of Vector3 data (usually normal).</param>
        /// <param name="data3">The third array of Vector3 data (usually tangent).</param>
        /// <param name="data4">The Vector2 data (usually UV).</param>
        /// <param name="hint">Specifies expected usage pattern of the data store.</param>
        /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
        public static uint CreateInterleavedVBO(BufferTarget target, Vector3[] data1, Vector3[] data2, Vector3[] data3, Vector2[] data4, BufferUsageHint hint)
        {
            if (data2.Length != data1.Length || data3.Length != data1.Length || data4.Length != data1.Length)
            {
                throw new Exception("Data lengths must be identical to construct an interleaved VBO.");
            }

            float[] interleaved = new float[data1.Length * 11];

            for (int i = 0, j = 0; i < data1.Length; i++)
            {
                interleaved[j++] = data1[i].X;
                interleaved[j++] = data1[i].Y;
                interleaved[j++] = data1[i].Z;

                interleaved[j++] = data2[i].X;
                interleaved[j++] = data2[i].Y;
                interleaved[j++] = data2[i].Z;

                interleaved[j++] = data3[i].X;
                interleaved[j++] = data3[i].Y;
                interleaved[j++] = data3[i].Z;

                interleaved[j++] = data4[i].X;
                interleaved[j++] = data4[i].Y;
            }

            return CreateVBO<float>(target, interleaved, hint);
        }

        /// <summary>
        /// Creates a vertex array object based on a series of attribute arrays and and attribute names.
        /// </summary>
        /// <param name="program">The shader program that contains the attributes to be bound to.</param>
        /// <param name="vbo">The VBO containing all of the attribute data.</param>
        /// <param name="sizes">An array of sizes which correspond to the size of each attribute.</param>
        /// <param name="types">An array of the attribute pointer types.</param>
        /// <param name="targets">An array of the buffer targets.</param>
        /// <param name="names">An array of the attribute names.</param>
        /// <param name="stride">The stride of the VBO.</param>
        /// <param name="eboHandle">The element buffer handle.</param>
        /// <returns>The vertex array object (VAO) ID.</returns>
        public static uint CreateVAO(ShaderProgram program, uint vbo, int[] sizes, VertexAttribPointerType[] types, BufferTarget[] targets, string[] names, int stride, uint eboHandle)
        {
            uint vaoHandle = Gl.GenVertexArray();
            Gl.BindVertexArray(vaoHandle);

            int offset = 0;

            for (uint i = 0; i < names.Length; i++)
            {
                Gl.EnableVertexAttribArray(i);
                Gl.BindBuffer(targets[i], vbo);
                Gl.VertexAttribPointer(i, sizes[i], types[i], true, stride, new IntPtr(offset));
                Gl.BindAttribLocation(program.ProgramID, i, names[i]);
            }

            Gl.BindBuffer(BufferTarget.ElementArrayBuffer, eboHandle);
            Gl.BindVertexArray(0);

            return vaoHandle;
        }

        /// <summary>
        /// Gets the current major OpenGL version (returns a cached result on subsequent calls).
        /// </summary>
        /// <returns>The current major OpenGL version, or 0 on an error.</returns>
        public static int Version()
        {
            if (version != 0) return version; // cache the version information

            try
            {
                string versionString = Gl.GetString(StringName.Version);

                version = int.Parse(versionString.Substring(0, versionString.IndexOf('.')));
                return Gl.version;
            }
            catch (Exception)
            {
                //Console.WriteLine("Error while retrieving the OpenGL version.");
                return 0;
            }
        }

        /// <summary>
        /// Gets the current minor OpenGL version (returns a cached result on subsequent calls).
        /// </summary>
        /// <returns>The current minor OpenGL version, or -1 on an error.</returns>
        public static int VersionMinor()
        {
            if (versionMinor != 0) return versionMinor; // cache the version information

            try
            {
                string versionString = Gl.GetString(StringName.Version);

                versionMinor = int.Parse(versionString.Split('.')[1]);
                return Gl.versionMinor;
            }
            catch (Exception)
            {
                //Console.WriteLine("Error while retrieving the OpenGL version.");
                return -1;
            }
        }

        /// <summary>
        /// Installs a program object as part of current rendering state.
        /// </summary>
        /// <param name="Program">Specifies the handle of the program object whose executables are to be used as part of current rendering state.</param>
        public static void UseProgram(ShaderProgram Program)
        {
            Gl.UseProgram(Program.ProgramID);
        }

        /// <summary>
        /// Bind a named texture to a texturing target
        /// </summary>
        /// <param name="Texture">Specifies the texture.</param>
        public static void BindTexture(Texture Texture)
        {
            Gl.BindTexture(Texture.TextureTarget, Texture.TextureID);
        }

        /// <summary>
        /// Get the index of a uniform block in the provided shader program.
        /// Note:  This method will use the provided shader program, so make sure to
        /// store which program is currently active and reload it if required.
        /// </summary>
        /// <param name="program">The shader program that contains the uniform block.</param>
        /// <param name="uniformBlockName">The uniform block name.</param>
        /// <returns>The index of the uniform block.</returns>
        public static uint GetUniformBlockIndex(ShaderProgram program, string uniformBlockName)
        {
            return Gl.GetUniformBlockIndex(program.ProgramID, uniformBlockName);
        }

        /// <summary>
        /// Binds a VBO based on the buffer target.
        /// </summary>
        /// <param name="buffer">The VBO to bind.</param>
        public static void BindBuffer<T>(VBO<T> buffer)
            where T : struct
        {
            Gl.BindBuffer(buffer.BufferTarget, buffer.ID);
        }

        /// <summary>
        /// Binds a VBO to a shader attribute.
        /// </summary>
        /// <param name="buffer">The VBO to bind to the shader attribute.</param>
        /// <param name="program">The shader program whose attribute will be bound to.</param>
        /// <param name="attributeName">The name of the shader attribute to be bound to.</param>
        public static void BindBufferToShaderAttribute<T>(VBO<T> buffer, ShaderProgram program, string attributeName)
            where T : struct
        {
            var cachedAttribute = program[attributeName];
            uint location = (uint)(cachedAttribute?.Location ?? Gl.GetAttribLocation(program.ProgramID, attributeName));

            Gl.EnableVertexAttribArray(location);
            Gl.BindBuffer(buffer);
            Gl.VertexAttribPointer(location, buffer.Size, buffer.PointerType, true, Marshal.SizeOf<T>(), IntPtr.Zero);
        }

        /// <summary>
        /// Delete a single OpenGL buffer.
        /// </summary>
        /// <param name="buffer">The OpenGL buffer to delete.</param>
        public static void DeleteBuffer(uint buffer)
        {
#if MEMORY_LOGGER
            MemoryLogger.DestroyVBO(buffer);
#endif

            uint1[0] = buffer;
            DeleteBuffers(1, uint1);
            uint1[0] = 0;
        }

        /// <summary>
        /// Set a uniform mat4 in the shader.
        /// Uses a cached float[] to reduce memory usage.
        /// </summary>
        /// <param name="location">The location of the uniform in the shader.</param>
        /// <param name="param">The Matrix4 to load into the shader uniform.</param>
        public static void UniformMatrix4fv(int location, Matrix4 param)
        {
            // use the statically allocated float[] for setting the uniform
            matrix4Float[0] = param[0].X; matrix4Float[1] = param[0].Y; matrix4Float[2] = param[0].Z; matrix4Float[3] = param[0].W;
            matrix4Float[4] = param[1].X; matrix4Float[5] = param[1].Y; matrix4Float[6] = param[1].Z; matrix4Float[7] = param[1].W;
            matrix4Float[8] = param[2].X; matrix4Float[9] = param[2].Y; matrix4Float[10] = param[2].Z; matrix4Float[11] = param[2].W;
            matrix4Float[12] = param[3].X; matrix4Float[13] = param[3].Y; matrix4Float[14] = param[3].Z; matrix4Float[15] = param[3].W;

            Gl.UniformMatrix4fv(location, 1, false, matrix4Float);
        }

        /// <summary>
        /// Set a uniform mat3 in the shader.
        /// Uses a cached float[] to reduce memory usage.
        /// </summary>
        /// <param name="location">The location of the uniform in the shader.</param>
        /// <param name="param">The Matrix3 to load into the shader uniform.</param>
        public static void UniformMatrix3fv(int location, Matrix3 param)
        {
            // use the statically allocated float[] for setting the uniform
            matrix3Float[0] = param[0].X; matrix3Float[1] = param[0].Y; matrix3Float[2] = param[0].Z;
            matrix3Float[3] = param[1].X; matrix3Float[4] = param[1].Y; matrix3Float[5] = param[1].Z;
            matrix3Float[6] = param[2].X; matrix3Float[7] = param[2].Y; matrix3Float[8] = param[2].Z;

            Gl.UniformMatrix3fv(location, 1, false, matrix3Float);
        }

        /// <summary>
        /// Updates a subset of the buffer object's data store.
        /// </summary>
        /// <typeparam name="T">The type of data in the data array.</typeparam>
        /// <param name="vboID">The VBO whose buffer will be updated.</param>
        /// <param name="target">Specifies the target buffer object.  Must be ArrayBuffer, ElementArrayBuffer, PixelPackBuffer or PixelUnpackBuffer.</param>
        /// <param name="data">The new data that will be copied to the data store.</param>
        /// <param name="length">The size in bytes of the data store region being replaced.</param>
        public static void BufferSubData<T>(uint vboID, BufferTarget target, T[] data, int length)
            where T : struct
        {
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);

            try
            {
                Gl.BindBuffer(target, vboID);
                Gl.BufferSubData(target, IntPtr.Zero, (IntPtr)(Marshal.SizeOf(data[0]) * length), handle.AddrOfPinnedObject());
            }
            finally
            {
                handle.Free();
            }
        }
        #endregion
    }
}
