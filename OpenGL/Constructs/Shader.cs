using System;
using System.Collections.Generic;

#if USE_NUMERICS
using System.Numerics;
#endif

namespace OpenGL
{
    public enum ParamType
    {
        Uniform,
        Attribute
    }

    public class ProgramParam
    {
        #region Variables
        private Type type;
        private int location;
        private uint programid;
        private ParamType ptype;
        private string name;
        #endregion

        #region Properties
        /// <summary>
        /// Specifies the C# equivalent of the GLSL data type.
        /// </summary>
        public Type Type { get { return type; } }

        /// <summary>
        /// Specifies the location of the parameter in the OpenGL program.
        /// </summary>
        public int Location { get { return location; } }

        /// <summary>
        /// Specifies the OpenGL program ID.
        /// </summary>
        public uint Program { get { return programid; } }

        /// <summary>
        /// Specifies the parameter type (either attribute or uniform).
        /// </summary>
        public ParamType ParamType { get { return ptype; } }

        /// <summary>
        /// Specifies the case-sensitive name of the parameter.
        /// </summary>
        public string Name { get { return name; } }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a program parameter with a given type and name.
        /// The location must be found after the program is compiled
        /// by using the GetLocation(ShaderProgram Program) method.
        /// </summary>
        /// <param name="Type">Specifies the C# equivalent of the GLSL data type.</param>
        /// <param name="ParamType">Specifies the parameter type (either attribute or uniform).</param>
        /// <param name="Name">Specifies the case-sensitive name of the parameter.</param>
        public ProgramParam(Type Type, ParamType ParamType, string Name)
        {
            type = Type;
            ptype = ParamType;
            name = Name;
        }

        /// <summary>
        /// Creates a program parameter with a type, name, program and location.
        /// </summary>
        /// <param name="Type">Specifies the C# equivalent of the GLSL data type.</param>
        /// <param name="ParamType">Specifies the parameter type (either attribute or uniform).</param>
        /// <param name="Name">Specifies the case-sensitive name of the parameter.</param>
        /// <param name="Program">Specifies the OpenGL program ID.</param>
        /// <param name="Location">Specifies the location of the parameter.</param>
        public ProgramParam(Type Type, ParamType ParamType, string Name, uint Program, int Location)
            : this(Type, ParamType, Name)
        {
            programid = Program;
            location = Location;
        }
        #endregion

        #region GetLocation
        /// <summary>
        /// Gets the location of the parameter in a compiled OpenGL program.
        /// </summary>
        /// <param name="Program">Specifies the shader program that contains this parameter.</param>
        public void GetLocation(ShaderProgram Program)
        {
            Program.Use();
            if (programid == 0)
            {
                programid = Program.ProgramID;
                location = (ptype == OpenGL.ParamType.Uniform ? Program.GetUniformLocation(name) : Program.GetAttributeLocation(name));
            }
        }
        #endregion

        #region SetValue Overrides
        public void SetValue(bool param)
        {
            if (Type != typeof(bool)) throw new Exception(string.Format("SetValue({0}) was given a bool.", Type));
            Gl.Uniform1i(location, (param) ? 1 : 0);
        }

        public void SetValue(int param)
        {
            if (Type != typeof(int) && Type != typeof(Texture)) throw new Exception(string.Format("SetValue({0}) was given a int.", Type));
            Gl.Uniform1i(location, param);
        }

        public void SetValue(float param)
        {
            if (Type != typeof(float)) throw new Exception(string.Format("SetValue({0}) was given a float.", Type));
            Gl.Uniform1f(location, param);
        }

        public void SetValue(Vector2 param)
        {
            if (Type != typeof(Vector2)) throw new Exception(string.Format("SetValue({0}) was given a Vector2.", Type));
            Gl.Uniform2f(location, param.X, param.Y);
        }

        public void SetValue(Vector3 param)
        {
            if (Type != typeof(Vector3)) throw new Exception(string.Format("SetValue({0}) was given a Vector3.", Type));
            Gl.Uniform3f(location, param.X, param.Y, param.Z);
        }

        public void SetValue(Vector4 param)
        {
            if (Type != typeof(Vector4)) throw new Exception(string.Format("SetValue({0}) was given a Vector4.", Type));
            Gl.Uniform4f(location, param.X, param.Y, param.Z, param.W);
        }

        public void SetValue(Matrix3 param)
        {
            if (Type != typeof(Matrix3)) throw new Exception(string.Format("SetValue({0}) was given a Matrix3.", Type));

            Gl.UniformMatrix3fv(location, param);
        }

        public void SetValue(Matrix4 param)
        {
            if (Type != typeof(Matrix4)) throw new Exception(string.Format("SetValue({0}) was given a Matrix4.", Type));

            Gl.UniformMatrix4fv(location, param);
        }

        public void SetValue(float[] param)
        {
            if (param.Length == 16)
            {
                if (Type != typeof(Matrix4)) throw new Exception(string.Format("SetValue({0}) was given a Matrix4.", Type));
                Gl.UniformMatrix4fv(location, 1, false, param);
            }
            else if (param.Length == 9)
            {
                if (Type != typeof(Matrix3)) throw new Exception(string.Format("SetValue({0}) was given a Matrix3.", Type));
                Gl.UniformMatrix3fv(location, 1, false, param);
            }
            else if (param.Length == 4)
            {
                if (Type != typeof(Vector4)) throw new Exception(string.Format("SetValue({0}) was given a Vector4.", Type));
                Gl.Uniform4f(location, param[0], param[1], param[2], param[3]);
            }
            else if (param.Length == 3)
            {
                if (Type != typeof(Vector3)) throw new Exception(string.Format("SetValue({0}) was given a Vector3.", Type));
                Gl.Uniform3f(location, param[0], param[1], param[2]);
            }
            else if (param.Length == 2)
            {
                if (Type != typeof(Vector2)) throw new Exception(string.Format("SetValue({0}) was given a Vector2.", Type));
                Gl.Uniform2f(location, param[0], param[1]);
            }
            else if (param.Length == 1)
            {
                if (Type != typeof(float)) throw new Exception(string.Format("SetValue({0}) was given a float.", Type));
                Gl.Uniform1f(location, param[0]);
            }
            else
            {
                throw new ArgumentException("param was an unexpected length.", "param");
            }
        }

        /*public void SetValue(Texture param)
        {
            if (Type != typeof(Texture)) throw new Exception(string.Format("SetValue({0}) was given a Texture.", Type));
            Gl.Uniform1i(location, param.Binding);
        }*/
        #endregion
    }

    public class Shader : IDisposable
    {
        #region Properties
        /// <summary>
        /// Specifies the OpenGL ShaderID.
        /// </summary>
        public uint ShaderID { get; private set; }

        /// <summary>
        /// Specifies the type of shader.
        /// </summary>
        public ShaderType ShaderType { get; private set; }

        /// <summary>
        /// Returns Gl.GetShaderInfoLog(ShaderID), which contains any compilation errors.
        /// </summary>
        public string ShaderLog
        {
            get { return Gl.GetShaderInfoLog(ShaderID); }
        }
        #endregion

        #region Constructor and Destructor
        /// <summary>
        /// Compiles a shader, which can be either vertex, fragment or geometry.
        /// </summary>
        /// <param name="source">Specifies the source code of the shader object.</param>
        /// <param name="type">Specifies the type of shader to create (either vertex, fragment or geometry).</param>
        public Shader(string source, ShaderType type)
        {
            this.ShaderType = type;
            this.ShaderID = Gl.CreateShader(type);

            Gl.ShaderSource(ShaderID, source);
            Gl.CompileShader(ShaderID);

            //Check whether the shader compiled successfully.
            //If not then throw an error with the compile error.
            if (!Gl.GetShaderCompileStatus(ShaderID))
            {
                throw new Exception(ShaderLog);
            }
        }

        ~Shader()
        {
            Dispose(false);
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (ShaderID != 0)
            {
                Gl.DeleteShader(ShaderID);
                ShaderID = 0;
            }
        }
        #endregion
    }

    public class ShaderProgram : IDisposable
    {
        #region Properties
        /// <summary>
        /// Specifies the OpenGL shader program ID.
        /// </summary>
        public uint ProgramID { get; private set; }

        /// <summary>
        /// Specifies the vertex shader used in this program.
        /// </summary>
        public Shader VertexShader { get; private set; }

        /// <summary>
        /// Specifies the fragment shader used in this program.
        /// </summary>
        public Shader FragmentShader { get; private set; }

        /// <summary>
        /// Specifies whether this program will dispose of the child 
        /// vertex/fragment programs when the IDisposable method is called.
        /// </summary>
        public bool DisposeChildren { get; set; }

        private Dictionary<string, ProgramParam> shaderParams;

        /// <summary>
        /// Queries the shader parameter hashtable to find a matching attribute/uniform.
        /// </summary>
        /// <param name="name">Specifies the case-sensitive name of the shader attribute/uniform.</param>
        /// <returns>The requested attribute/uniform, or null on a failure.</returns>
        public ProgramParam this[string name]
        {
            get { return shaderParams.ContainsKey(name) ? shaderParams[name] : null; }
        }

        /// <summary>
        /// Returns Gl.GetProgramInfoLog(ProgramID), which contains any linking errors.
        /// </summary>
        public string ProgramLog
        {
            get { return Gl.GetProgramInfoLog(ProgramID); }
        }
        #endregion

        #region Constructors and Destructor
        /// <summary>
        /// Links a vertex and fragment shader together to create a shader program.
        /// </summary>
        /// <param name="vertexShader">Specifies the vertex shader.</param>
        /// <param name="fragmentShader">Specifies the fragment shader.</param>
        public ShaderProgram(Shader vertexShader, Shader fragmentShader)
        {
            this.VertexShader = vertexShader;
            this.FragmentShader = fragmentShader;
            this.ProgramID = Gl.CreateProgram();
            this.DisposeChildren = false;

            Gl.AttachShader(ProgramID, vertexShader.ShaderID);
            Gl.AttachShader(ProgramID, fragmentShader.ShaderID);
            Gl.LinkProgram(ProgramID);

            //Check whether the program linked successfully.
            //If not then throw an error with the linking error.
            if (!Gl.GetProgramLinkStatus(ProgramID))
            {
                throw new Exception(ProgramLog);
            }

            GetParams();
        }

        /// <summary>
        /// Creates two shaders and then links them together to create a shader program.
        /// </summary>
        /// <param name="vertexShaderSource">Specifies the source code of the vertex shader.</param>
        /// <param name="fragmentShaderSource">Specifies the source code of the fragment shader.</param>
        public ShaderProgram(string vertexShaderSource, string fragmentShaderSource)
            : this(new Shader(vertexShaderSource, ShaderType.VertexShader), new Shader(fragmentShaderSource, ShaderType.FragmentShader))
        {
            DisposeChildren = true;
        }

        ~ShaderProgram()
        {
            Dispose(false);
        }
        #endregion

        #region GetParams
        /// <summary>
        /// Parses all of the parameters (attributes/uniforms) from the two attached shaders
        /// and then loads their location by passing this shader program into the parameter object.
        /// </summary>
        private void GetParams()
        {
            shaderParams = new Dictionary<string, ProgramParam>();

#if GET_PROGRAM_INTERFACE
            if (Gl.GetAddress("glGetProgramInterfaceiv") == IntPtr.Zero)
            {
#endif
                int[] resources = new int[1];
                int[] actualLength = new int[1];
                int[] arraySize = new int[1];

                Gl.GetProgramiv(ProgramID, ProgramParameter.ActiveAttributes, resources);

                for (int i = 0; i < resources[0]; i++)
                {
                    ActiveAttribType[] type = new ActiveAttribType[1];
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(256);
                    Gl.GetActiveAttrib(ProgramID, i, 256, actualLength, arraySize, type, sb);

                    if (!shaderParams.ContainsKey(sb.ToString()))
                    {
                        ProgramParam param = new ProgramParam(TypeFromAttributeType(type[0]), ParamType.Attribute, sb.ToString());
                        shaderParams.Add(param.Name, param);
                        param.GetLocation(this);
                    }
                }

                Gl.GetProgramiv(ProgramID, ProgramParameter.ActiveUniforms, resources);

                for (int i = 0; i < resources[0]; i++)
                {
                    ActiveUniformType[] type = new ActiveUniformType[1];
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(256);
                    Gl.GetActiveUniform(ProgramID, (uint)i, 256, actualLength, arraySize, type, sb);

                    if (!shaderParams.ContainsKey(sb.ToString()))
                    {
                        ProgramParam param = new ProgramParam(TypeFromUniformType(type[0]), ParamType.Uniform, sb.ToString());
                        shaderParams.Add(param.Name, param);
                        param.GetLocation(this);
                    }
                }
#if GET_PROGRAM_INTERFACE
            }
            else
            {
                int[] resources = new int[1];
                Gl.GetProgramInterfaceiv(ProgramID, ProgramInterface.ProgramInput, ProgramInterfaceParameterName.ActiveResources, resources);

                for (int i = 0; i < resources[0]; i++)
                {
                    int[] values = new int[2];
                    Gl.GetProgramResourceiv(ProgramID, ProgramInterface.ProgramInput, (uint)i, 2, new ProgramResourceParameterName[] { ProgramResourceParameterName.NameLength, ProgramResourceParameterName.Type }, 256, null, values);
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(values[0]);
                    Gl.GetProgramResourceName(ProgramID, ProgramInterface.ProgramInput, (uint)i, values[0], null, sb);

                    if (!shaderParams.ContainsKey(sb.ToString()))
                    {
                        ProgramParam param = new ProgramParam(TypeFromAttributeType((ActiveAttribType)values[1]), ParamType.Attribute, sb.ToString());
                        shaderParams.Add(param.Name, param);
                        param.GetLocation(this);
                    }
                }

                Gl.GetProgramInterfaceiv(ProgramID, ProgramInterface.Uniform, ProgramInterfaceParameterName.ActiveResources, resources);

                for (int i = 0; i < resources[0]; i++)
                {
                    int[] values = new int[2];
                    Gl.GetProgramResourceiv(ProgramID, ProgramInterface.Uniform, (uint)i, 2, new ProgramResourceParameterName[] { ProgramResourceParameterName.NameLength, ProgramResourceParameterName.Type }, 256, null, values);
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(values[0]);
                    Gl.GetProgramResourceName(ProgramID, ProgramInterface.Uniform, (uint)i, values[0], null, sb);

                    if (!shaderParams.ContainsKey(sb.ToString()))
                    {
                        ProgramParam param = new ProgramParam(TypeFromUniformType((ActiveUniformType)values[1]), ParamType.Uniform, sb.ToString());
                        shaderParams.Add(param.Name, param);
                        param.GetLocation(this);
                    }
                }
            }
#endif
        }

        private Type TypeFromAttributeType(ActiveAttribType type)
        {
            switch (type)
            {
                case ActiveAttribType.Float: return typeof(float);
                case ActiveAttribType.FloatMat2: return typeof(float[]);
                case ActiveAttribType.FloatMat3: return typeof(Matrix3);
                case ActiveAttribType.FloatMat4: return typeof(Matrix4);
                case ActiveAttribType.FloatVec2: return typeof(Vector2);
                case ActiveAttribType.FloatVec3: return typeof(Vector3);
                case ActiveAttribType.FloatVec4: return typeof(Vector4);
                default: return typeof(object);
            }
        }

        private Type TypeFromUniformType(ActiveUniformType type)
        {
            switch (type)
            {
                case ActiveUniformType.Int: return typeof(int);
                case ActiveUniformType.Float: return typeof(float);
                case ActiveUniformType.FloatVec2: return typeof(Vector2);
                case ActiveUniformType.FloatVec3: return typeof(Vector3);
                case ActiveUniformType.FloatVec4: return typeof(Vector4);
                case ActiveUniformType.IntVec2: return typeof(int[]);
                case ActiveUniformType.IntVec3: return typeof(int[]);
                case ActiveUniformType.IntVec4: return typeof(int[]);
                case ActiveUniformType.Bool: return typeof(bool);
                case ActiveUniformType.BoolVec2: return typeof(bool[]);
                case ActiveUniformType.BoolVec3: return typeof(bool[]);
                case ActiveUniformType.BoolVec4: return typeof(bool[]);
                case ActiveUniformType.FloatMat2: return typeof(float[]);
                case ActiveUniformType.FloatMat3: return typeof(Matrix3);
                case ActiveUniformType.FloatMat4: return typeof(Matrix4);
                case ActiveUniformType.Sampler1D:
                case ActiveUniformType.Sampler2D:
                case ActiveUniformType.Sampler3D:
                case ActiveUniformType.SamplerCube:
                case ActiveUniformType.Sampler1DShadow:
                case ActiveUniformType.Sampler2DShadow:
                case ActiveUniformType.Sampler2DRect:
                case ActiveUniformType.Sampler2DRectShadow: return typeof(int);
                case ActiveUniformType.FloatMat2x3:
                case ActiveUniformType.FloatMat2x4:
                case ActiveUniformType.FloatMat3x2:
                case ActiveUniformType.FloatMat3x4:
                case ActiveUniformType.FloatMat4x2:
                case ActiveUniformType.FloatMat4x3: return typeof(float[]);
                case ActiveUniformType.Sampler1DArray:
                case ActiveUniformType.Sampler2DArray:
                case ActiveUniformType.SamplerBuffer:
                case ActiveUniformType.Sampler1DArrayShadow:
                case ActiveUniformType.Sampler2DArrayShadow:
                case ActiveUniformType.SamplerCubeShadow: return typeof(int);
                case ActiveUniformType.UnsignedIntVec2: return typeof(uint[]);
                case ActiveUniformType.UnsignedIntVec3: return typeof(uint[]);
                case ActiveUniformType.UnsignedIntVec4: return typeof(uint[]);
                case ActiveUniformType.IntSampler1D:
                case ActiveUniformType.IntSampler2D:
                case ActiveUniformType.IntSampler3D:
                case ActiveUniformType.IntSamplerCube:
                case ActiveUniformType.IntSampler2DRect:
                case ActiveUniformType.IntSampler1DArray:
                case ActiveUniformType.IntSampler2DArray:
                case ActiveUniformType.IntSamplerBuffer: return typeof(int);
                case ActiveUniformType.UnsignedIntSampler1D:
                case ActiveUniformType.UnsignedIntSampler2D:
                case ActiveUniformType.UnsignedIntSampler3D:
                case ActiveUniformType.UnsignedIntSamplerCube:
                case ActiveUniformType.UnsignedIntSampler2DRect:
                case ActiveUniformType.UnsignedIntSampler1DArray:
                case ActiveUniformType.UnsignedIntSampler2DArray:
                case ActiveUniformType.UnsignedIntSamplerBuffer: return typeof(uint);
                case ActiveUniformType.Sampler2DMultisample: return typeof(int);
                case ActiveUniformType.IntSampler2DMultisample: return typeof(int);
                case ActiveUniformType.UnsignedIntSampler2DMultisample: return typeof(uint);
                case ActiveUniformType.Sampler2DMultisampleArray: return typeof(int);
                case ActiveUniformType.IntSampler2DMultisampleArray: return typeof(int);
                case ActiveUniformType.UnsignedIntSampler2DMultisampleArray: return typeof(uint);
                default: return typeof(object);
            }
        }
        #endregion

        #region Methods
        public void Use()
        {
            if (Gl.CurrentProgram != ProgramID) Gl.UseProgram(this.ProgramID);
        }

        public int GetUniformLocation(string Name)
        {
            Use();
            return Gl.GetUniformLocation(ProgramID, Name);
        }

        public int GetAttributeLocation(string Name)
        {
            Use();
            return Gl.GetAttribLocation(ProgramID, Name);
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (ProgramID != 0)
            {
                // Make sure this program isn't being used
                if (Gl.CurrentProgram == ProgramID) Gl.UseProgram(0);

                Gl.DetachShader(ProgramID, VertexShader.ShaderID);
                Gl.DetachShader(ProgramID, FragmentShader.ShaderID);
                Gl.DeleteProgram(ProgramID);

                if (DisposeChildren)
                {
                    VertexShader.Dispose();
                    FragmentShader.Dispose();
                }

                ProgramID = 0;
            }
        }
        #endregion
    }
}
