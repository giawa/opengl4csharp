using System;
using System.Runtime.InteropServices;

namespace OpenGL
{
    // Automatically generated from GlCore.cs using BuildGl
    partial class Gl
    {
        /// <summary>
        /// Set the active program object for a program pipeline object.
        /// <para>
        /// glActiveShaderProgram sets the linked program named by program to be the active
        /// program for the program pipeline object pipeline. The active program in the
        /// active program pipeline object is the target of calls to glUniform when no
        /// program has been made current through a call to glUseProgram.
        /// </para>
        /// </summary>
        public static void ActiveShaderProgram(UInt32 pipeline, UInt32 program)
        {
            Delegates.glActiveShaderProgram(pipeline, program);
        }

        /// <summary>
        /// Select active texture unit.
        /// <para>
        /// glActiveTexture selects which texture unit subsequent texture state calls will
        /// affect. The number of texture units an implementation supports is implementation
        /// dependent, but must be at least 80.
        /// </para>
        /// </summary>
        public static void ActiveTexture(OpenGL.TextureUnit texture)
        {
            Delegates.glActiveTexture(texture);
        }

        /// <summary>
        /// Attaches a shader object to a program object.
        /// <para>
        /// In order to create a complete shader program, there must be a way to specify the
        /// list of things that will be linked together. Program objects provide this
        /// mechanism. Shaders that are to be linked together in a program object must first
        /// be attached to that program object. glAttachShader attaches the shader object
        /// specified by shader to the program object specified by program. This indicates
        /// that shader will be included in link operations that will be performed on
        /// program.
        /// </para>
        /// </summary>
        public static void AttachShader(UInt32 program, UInt32 shader)
        {
            Delegates.glAttachShader(program, shader);
        }

        /// <summary>
        /// Start conditional rendering.
        /// <para>
        /// Conditional rendering is started using glBeginConditionalRender and ended using
        /// glEndConditionalRender. During conditional rendering, all vertex array commands,
        /// as well as glClear and glClearBuffer have no effect if the (GL_SAMPLES_PASSED)
        /// result of the query object id is zero, or if the (GL_ANY_SAMPLES_PASSED) result
        /// is GL_FALSE. The results of commands setting the current vertex state, such as
        /// glVertexAttrib are undefined. If the (GL_SAMPLES_PASSED) result is non-zero or
        /// if the (GL_ANY_SAMPLES_PASSED) result is GL_TRUE, such commands are not
        /// discarded. The id parameter to glBeginConditionalRender must be the name of a
        /// query object previously returned from a call to glGenQueries. mode specifies how
        /// the results of the query object are to be interpreted. If mode is GL_QUERY_WAIT,
        /// the GL waits for the results of the query to be available and then uses the
        /// results to determine if subsequent rendering commands are discarded. If mode is
        /// GL_QUERY_NO_WAIT, the GL may choose to unconditionally execute the subsequent
        /// rendering commands without waiting for the query to complete.
        /// </para>
        /// </summary>
        public static void BeginConditionalRender(UInt32 id, OpenGL.ConditionalRenderType mode)
        {
            Delegates.glBeginConditionalRender(id, mode);
        }

        /// <summary>
        /// Start conditional rendering.
        /// <para>
        /// Conditional rendering is started using glBeginConditionalRender and ended using
        /// glEndConditionalRender. During conditional rendering, all vertex array commands,
        /// as well as glClear and glClearBuffer have no effect if the (GL_SAMPLES_PASSED)
        /// result of the query object id is zero, or if the (GL_ANY_SAMPLES_PASSED) result
        /// is GL_FALSE. The results of commands setting the current vertex state, such as
        /// glVertexAttrib are undefined. If the (GL_SAMPLES_PASSED) result is non-zero or
        /// if the (GL_ANY_SAMPLES_PASSED) result is GL_TRUE, such commands are not
        /// discarded. The id parameter to glBeginConditionalRender must be the name of a
        /// query object previously returned from a call to glGenQueries. mode specifies how
        /// the results of the query object are to be interpreted. If mode is GL_QUERY_WAIT,
        /// the GL waits for the results of the query to be available and then uses the
        /// results to determine if subsequent rendering commands are discarded. If mode is
        /// GL_QUERY_NO_WAIT, the GL may choose to unconditionally execute the subsequent
        /// rendering commands without waiting for the query to complete.
        /// </para>
        /// </summary>
        public static void EndConditionalRender()
        {
            Delegates.glEndConditionalRender();
        }

        /// <summary>
        /// Delimit the boundaries of a query object.
        /// <para>
        /// glBeginQuery and glEndQuery delimit the boundaries of a query object. query must
        /// be a name previously returned from a call to glGenQueries. If a query object
        /// with name id does not yet exist it is created with the type determined by
        /// target. target must be one of GL_SAMPLES_PASSED, GL_ANY_SAMPLES_PASSED,
        /// GL_PRIMITIVES_GENERATED, GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN, or
        /// GL_TIME_ELAPSED. The behavior of the query object depends on its type and is as
        /// follows.
        /// </para>
        /// </summary>
        public static void BeginQuery(OpenGL.QueryTarget target, UInt32 id)
        {
            Delegates.glBeginQuery(target, id);
        }

        /// <summary>
        /// Delimit the boundaries of a query object.
        /// <para>
        /// glBeginQuery and glEndQuery delimit the boundaries of a query object. query must
        /// be a name previously returned from a call to glGenQueries. If a query object
        /// with name id does not yet exist it is created with the type determined by
        /// target. target must be one of GL_SAMPLES_PASSED, GL_ANY_SAMPLES_PASSED,
        /// GL_PRIMITIVES_GENERATED, GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN, or
        /// GL_TIME_ELAPSED. The behavior of the query object depends on its type and is as
        /// follows.
        /// </para>
        /// </summary>
        public static void EndQuery(OpenGL.QueryTarget target)
        {
            Delegates.glEndQuery(target);
        }

        /// <summary>
        /// Delimit the boundaries of a query object on an indexed target.
        /// <para>
        /// glBeginQueryIndexed and glEndQueryIndexed delimit the boundaries of a query
        /// object. query must be a name previously returned from a call to glGenQueries. If
        /// a query object with name id does not yet exist it is created with the type
        /// determined by target. target must be one of GL_SAMPLES_PASSED,
        /// GL_ANY_SAMPLES_PASSED, GL_PRIMITIVES_GENERATED,
        /// GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN, or GL_TIME_ELAPSED. The behavior of
        /// the query object depends on its type and is as follows.
        /// </para>
        /// </summary>
        public static void BeginQueryIndexed(UInt32 target, UInt32 index, UInt32 id)
        {
            Delegates.glBeginQueryIndexed(target, index, id);
        }

        /// <summary>
        /// Delimit the boundaries of a query object on an indexed target.
        /// <para>
        /// glBeginQueryIndexed and glEndQueryIndexed delimit the boundaries of a query
        /// object. query must be a name previously returned from a call to glGenQueries. If
        /// a query object with name id does not yet exist it is created with the type
        /// determined by target. target must be one of GL_SAMPLES_PASSED,
        /// GL_ANY_SAMPLES_PASSED, GL_PRIMITIVES_GENERATED,
        /// GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN, or GL_TIME_ELAPSED. The behavior of
        /// the query object depends on its type and is as follows.
        /// </para>
        /// </summary>
        public static void EndQueryIndexed(OpenGL.QueryTarget target, UInt32 index)
        {
            Delegates.glEndQueryIndexed(target, index);
        }

        /// <summary>
        /// Start transform feedback operation.
        /// <para>
        /// Transform feedback mode captures the values of varying variables written by the
        /// vertex shader (or, if active, the geometry shader). Transform feedback is said
        /// to be active after a call to glBeginTransformFeedback until a subsequent call to
        /// glEndTransformFeedback. Transform feedback commands must be paired.
        /// </para>
        /// </summary>
        public static void BeginTransformFeedback(OpenGL.BeginFeedbackMode primitiveMode)
        {
            Delegates.glBeginTransformFeedback(primitiveMode);
        }

        /// <summary>
        /// Start transform feedback operation.
        /// <para>
        /// Transform feedback mode captures the values of varying variables written by the
        /// vertex shader (or, if active, the geometry shader). Transform feedback is said
        /// to be active after a call to glBeginTransformFeedback until a subsequent call to
        /// glEndTransformFeedback. Transform feedback commands must be paired.
        /// </para>
        /// </summary>
        public static void EndTransformFeedback()
        {
            Delegates.glEndTransformFeedback();
        }

        /// <summary>
        /// Associates a generic vertex attribute index with a named attribute variable.
        /// <para>
        /// glBindAttribLocation is used to associate a user-defined attribute variable in
        /// the program object specified by program with a generic vertex attribute index.
        /// The name of the user-defined attribute variable is passed as a null terminated
        /// string in name. The generic vertex attribute index to be bound to this variable
        /// is specified by index. When program is made part of current state, values
        /// provided via the generic vertex attribute index will modify the value of the
        /// user-defined attribute variable specified by name.
        /// </para>
        /// </summary>
        public static void BindAttribLocation(UInt32 program, UInt32 index, String name)
        {
            Delegates.glBindAttribLocation(program, index, name);
        }

        /// <summary>
        /// Associates a generic vertex attribute index with a named attribute variable.
        /// <para>
        /// glBindAttribLocation is used to associate a user-defined attribute variable in
        /// the program object specified by program with a generic vertex attribute index.
        /// The name of the user-defined attribute variable is passed as a null terminated
        /// string in name. The generic vertex attribute index to be bound to this variable
        /// is specified by index. When program is made part of current state, values
        /// provided via the generic vertex attribute index will modify the value of the
        /// user-defined attribute variable specified by name.
        /// </para>
        /// </summary>
        public static void BindAttribLocation(UInt32 program, Int32 index, String name)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glBindAttribLocation(program, (UInt32)index, name);
        }

        /// <summary>
        /// Bind a named buffer object.
        /// <para>
        /// glBindBuffer binds a buffer object to the specified buffer binding point.
        /// Calling glBindBuffer with target set to one of the accepted symbolic constants
        /// and buffer set to the name of a buffer object binds that buffer object name to
        /// the target. If no buffer object with name buffer exists, one is created with
        /// that name. When a buffer object is bound to a target, the previous binding for
        /// that target is automatically broken.
        /// </para>
        /// </summary>
        public static void BindBuffer(OpenGL.BufferTarget target, UInt32 buffer)
        {
            Delegates.glBindBuffer(target, buffer);
        }

        /// <summary>
        /// Bind a buffer object to an indexed buffer target.
        /// <para>
        /// glBindBufferBase binds the buffer object buffer to the binding point at index
        /// index of the array of targets specified by target. Each target represents an
        /// indexed array of buffer binding points, as well as a single general binding
        /// point that can be used by other buffer manipulation functions such as
        /// glBindBuffer or glMapBuffer. In addition to binding buffer to the indexed buffer
        /// binding target, glBindBufferBase also binds buffer to the generic buffer binding
        /// point specified by target.
        /// </para>
        /// </summary>
        public static void BindBufferBase(OpenGL.BufferTarget target, UInt32 index, UInt32 buffer)
        {
            Delegates.glBindBufferBase(target, index, buffer);
        }

        /// <summary>
        /// Bind a range within a buffer object to an indexed buffer target.
        /// <para>
        /// glBindBufferRange binds a range the buffer object buffer represented by offset
        /// and size to the binding point at index index of the array of targets specified
        /// by target. Each target represents an indexed array of buffer binding points, as
        /// well as a single general binding point that can be used by other buffer
        /// manipulation functions such as glBindBuffer or glMapBuffer. In addition to
        /// binding a range of buffer to the indexed buffer binding target,
        /// glBindBufferRange also binds the range to the generic buffer binding point
        /// specified by target.
        /// </para>
        /// </summary>
        public static void BindBufferRange(BufferTarget target, UInt32 index, UInt32 buffer, IntPtr offset, IntPtr size)
        {
            Delegates.glBindBufferRange(target, index, buffer, offset, size);
        }

        /// <summary>
        /// Bind one or more buffer objects to a sequence of indexed buffer targets.
        /// <para>
        /// glBindBuffersBase binds a set of count buffer objects whose names are given in
        /// the array buffers to the count consecutive binding points starting from index
        /// index of the array of targets specified by target. If buffers is NULL then
        /// glBindBuffersBase unbinds any buffers that are currently bound to the referenced
        /// binding points. Assuming no errors are generated, it is equivalent to the
        /// following pseudo-code, which calls glBindBufferBase, with the exception that the
        /// non-indexed target is not changed by glBindBuffersBase:.
        /// </para>
        /// </summary>
        public static void BindBuffersBase(OpenGL.BufferTarget target, UInt32 first, Int32 count, UInt32[] buffers)
        {
            Delegates.glBindBuffersBase(target, first, count, buffers);
        }

        /// <summary>
        /// Bind ranges of one or more buffer objects to a sequence of indexed buffer targets.
        /// <para>
        /// glBindBuffersRange binds a set of count ranges from buffer objects whose names
        /// are given in the array buffers to the count consecutive binding points starting
        /// from index index of the array of targets specified by target. offsets specifies
        /// the address of an array containing count starting offsets within the buffers,
        /// and sizes specifies the address of an array of count sizes of the ranges. If
        /// buffers is NULL then offsets and sizes are ignored and glBindBuffersRange
        /// unbinds any buffers that are currently bound to the referenced binding points.
        /// Assuming no errors are generated, it is equivalent to the following pseudo-code,
        /// which calls glBindBufferRange, with the exception that the non-indexed target is
        /// not changed by glBindBuffersRange:.
        /// </para>
        /// </summary>
        public static void BindBuffersRange(OpenGL.BufferTarget target, UInt32 first, Int32 count, UInt32[] buffers, IntPtr[] offsets, IntPtr[] sizes)
        {
            Delegates.glBindBuffersRange(target, first, count, buffers, offsets, sizes);
        }

        /// <summary>
        /// Bind a user-defined varying out variable to a fragment shader color number.
        /// <para>
        /// glBindFragDataLocation explicitly specifies the binding of the user-defined
        /// varying out variable name to fragment shader color number colorNumber for
        /// program program. If name was bound previously, its assigned binding is replaced
        /// with colorNumber. name must be a null-terminated string. colorNumber must be
        /// less than GL_MAX_DRAW_BUFFERS.
        /// </para>
        /// </summary>
        public static void BindFragDataLocation(UInt32 program, UInt32 colorNumber, String name)
        {
            Delegates.glBindFragDataLocation(program, colorNumber, name);
        }

        /// <summary>
        /// Bind a user-defined varying out variable to a fragment shader color number and index.
        /// <para>
        /// glBindFragDataLocationIndexed specifies that the varying out variable name in
        /// program should be bound to fragment color colorNumber when the program is next
        /// linked. index may be zero or one to specify that the color be used as either the
        /// first or second color input to the blend equation, respectively.
        /// </para>
        /// </summary>
        public static void BindFragDataLocationIndexed(UInt32 program, UInt32 colorNumber, UInt32 index, String name)
        {
            Delegates.glBindFragDataLocationIndexed(program, colorNumber, index, name);
        }

        /// <summary>
        /// Bind a framebuffer to a framebuffer target.
        /// <para>
        /// glBindFramebuffer binds the framebuffer object with name framebuffer to the
        /// framebuffer target specified by target. target must be either
        /// GL_DRAW_FRAMEBUFFER, GL_READ_FRAMEBUFFER or GL_FRAMEBUFFER. If a framebuffer
        /// object is bound to GL_DRAW_FRAMEBUFFER or GL_READ_FRAMEBUFFER, it becomes the
        /// target for rendering or readback operations, respectively, until it is deleted
        /// or another framebuffer is bound to the corresponding bind point. Calling
        /// glBindFramebuffer with target set to GL_FRAMEBUFFER binds framebuffer to both
        /// the read and draw framebuffer targets. framebuffer is the name of a framebuffer
        /// object previously returned from a call to glGenFramebuffers, or zero to break
        /// the existing binding of a framebuffer object to target.
        /// </para>
        /// </summary>
        public static void BindFramebuffer(OpenGL.FramebufferTarget target, UInt32 framebuffer)
        {
            Delegates.glBindFramebuffer(target, framebuffer);
        }

        /// <summary>
        /// Bind a level of a texture to an image unit.
        /// <para>
        /// glBindImageTexture binds a single level of a texture to an image unit for the
        /// purpose of reading and writing it from shaders. unit specifies the zero-based
        /// index of the image unit to which to bind the texture level. texture specifies
        /// the name of an existing texture object to bind to the image unit. If texture is
        /// zero, then any existing binding to the image unit is broken. level specifies the
        /// level of the texture to bind to the image unit.
        /// </para>
        /// </summary>
        public static void BindImageTexture(UInt32 unit, UInt32 texture, Int32 level, Boolean layered, Int32 layer, OpenGL.BufferAccess access, OpenGL.PixelInternalFormat format)
        {
            Delegates.glBindImageTexture(unit, texture, level, layered, layer, access, format);
        }

        /// <summary>
        /// Bind one or more named texture images to a sequence of consecutive image units.
        /// <para>
        /// glBindImageTextures binds images from an array of existing texture objects to a
        /// specified number of consecutive image units. count specifies the number of
        /// texture objects whose names are stored in the array textures. That number of
        /// texture names are read from the array and bound to the count consecutive texture
        /// units starting from first. If the name zero appears in the textures array, any
        /// existing binding to the image unit is reset. Any non-zero entry in textures must
        /// be the name of an existing texture object. When a non-zero entry in textures is
        /// present, the image at level zero is bound, the binding is considered layered,
        /// with the first layer set to zero, and the image is bound for read-write access.
        /// The image unit format parameter is taken from the internal format of the image
        /// at level zero of the texture object. For cube map textures, the internal format
        /// of the positive X image of level zero is used. If textures is NULL then it is as
        /// if an appropriately sized array containing only zeros had been specified.
        /// </para>
        /// </summary>
        public static void BindImageTextures(UInt32 first, Int32 count, UInt32[] textures)
        {
            Delegates.glBindImageTextures(first, count, textures);
        }

        /// <summary>
        /// Bind a program pipeline to the current context.
        /// <para>
        /// glBindProgramPipeline binds a program pipeline object to the current context.
        /// pipeline must be a name previously returned from a call to
        /// glGenProgramPipelines. If no program pipeline exists with name pipeline then a
        /// new pipeline object is created with that name and initialized to the default
        /// state vector.
        /// </para>
        /// </summary>
        public static void BindProgramPipeline(UInt32 pipeline)
        {
            Delegates.glBindProgramPipeline(pipeline);
        }

        /// <summary>
        /// Bind a renderbuffer to a renderbuffer target.
        /// <para>
        /// glBindRenderbuffer binds the renderbuffer object with name renderbuffer to the
        /// renderbuffer target specified by target. target must be GL_RENDERBUFFER.
        /// renderbuffer is the name of a renderbuffer object previously returned from a
        /// call to glGenRenderbuffers, or zero to break the existing binding of a
        /// renderbuffer object to target.
        /// </para>
        /// </summary>
        public static void BindRenderbuffer(OpenGL.RenderbufferTarget target, UInt32 renderbuffer)
        {
            Delegates.glBindRenderbuffer(target, renderbuffer);
        }

        /// <summary>
        /// Bind a named sampler to a texturing target.
        /// <para>
        /// glBindSampler binds sampler to the texture unit at index unit. sampler must be
        /// zero or the name of a sampler object previously returned from a call to
        /// glGenSamplers. unit must be less than the value of
        /// GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS.
        /// </para>
        /// </summary>
        public static void BindSampler(UInt32 unit, UInt32 sampler)
        {
            Delegates.glBindSampler(unit, sampler);
        }

        /// <summary>
        /// Bind one or more named sampler objects to a sequence of consecutive sampler units.
        /// <para>
        /// glBindSamplers binds samplers from an array of existing sampler objects to a
        /// specified number of consecutive sampler units. count specifies the number of
        /// sampler objects whose names are stored in the array samplers. That number of
        /// sampler names is read from the array and bound to the count consecutive sampler
        /// units starting from first.
        /// </para>
        /// </summary>
        public static void BindSamplers(UInt32 first, Int32 count, UInt32[] samplers)
        {
            Delegates.glBindSamplers(first, count, samplers);
        }

        /// <summary>
        /// Bind a named texture to a texturing target.
        /// <para>
        /// glBindTexture lets you create or use a named texture. Calling glBindTexture with
        /// target set to GL_TEXTURE_1D, GL_TEXTURE_2D, GL_TEXTURE_3D, GL_TEXTURE_1D_ARRAY,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_RECTANGLE, GL_TEXTURE_CUBE_MAP,
        /// GL_TEXTURE_CUBE_MAP_ARRAY, GL_TEXTURE_BUFFER, GL_TEXTURE_2D_MULTISAMPLE or
        /// GL_TEXTURE_2D_MULTISAMPLE_ARRAY and texture set to the name of the new texture
        /// binds the texture name to the target. When a texture is bound to a target, the
        /// previous binding for that target is automatically broken.
        /// </para>
        /// </summary>
        public static void BindTexture(OpenGL.TextureTarget target, UInt32 texture)
        {
            Delegates.glBindTexture(target, texture);
        }

        /// <summary>
        /// Bind one or more named textures to a sequence of consecutive texture units.
        /// <para>
        /// glBindTextures binds an array of existing texture objects to a specified number
        /// of consecutive texture units. count specifies the number of texture objects
        /// whose names are stored in the array textures. That number of texture names are
        /// read from the array and bound to the count consecutive texture units starting
        /// from first. The target, or type of texture is deduced from the texture object
        /// and each texture is bound to the corresponding target of the texture unit. If
        /// the name zero appears in the textures array, any existing binding to any target
        /// of the texture unit is reset and the default texture for that target is bound in
        /// its place. Any non-zero entry in textures must be the name of an existing
        /// texture object. If textures is NULL then it is as if an appropriately sized
        /// array containing only zeros had been specified.
        /// </para>
        /// </summary>
        public static void BindTextures(UInt32 first, Int32 count, UInt32[] textures)
        {
            Delegates.glBindTextures(first, count, textures);
        }

        /// <summary>
        /// Bind an existing texture object to the specified texture unit.
        /// <para>
        /// glBindTextureUnit binds an existing texture object to the texture unit numbered
        /// unit.
        /// </para>
        /// </summary>
        public static void BindTextureUnit(UInt32 unit, UInt32 texture)
        {
            Delegates.glBindTextureUnit(unit, texture);
        }

        /// <summary>
        /// Bind a transform feedback object.
        /// <para>
        /// glBindTransformFeedback binds the transform feedback object with name id to the
        /// current GL state. id must be a name previously returned from a call to
        /// glGenTransformFeedbacks. If id has not previously been bound, a new transform
        /// feedback object with name id and initialized with with the default transform
        /// state vector is created.
        /// </para>
        /// </summary>
        public static void BindTransformFeedback(OpenGL.NvTransformFeedback2 target, UInt32 id)
        {
            Delegates.glBindTransformFeedback(target, id);
        }

        /// <summary>
        /// Bind a vertex array object.
        /// <para>
        /// glBindVertexArray binds the vertex array object with name array. array is the
        /// name of a vertex array object previously returned from a call to
        /// glGenVertexArrays, or zero to break the existing vertex array object binding.
        /// </para>
        /// </summary>
        public static void BindVertexArray(UInt32 array)
        {
            Delegates.glBindVertexArray(array);
        }

        /// <summary>
        /// Bind a buffer to a vertex buffer bind point.
        /// <para>
        /// glBindVertexBuffer and glVertexArrayVertexBuffer bind the buffer named buffer to
        /// the vertex buffer binding point whose index is given by bindingindex.
        /// glBindVertexBuffer modifies the binding of the currently bound vertex array
        /// object, whereas glVertexArrayVertexBuffer allows the caller to specify ID of the
        /// vertex array object with an argument named vaobj, for which the binding should
        /// be modified. offset and stride specify the offset of the first element within
        /// the buffer and the distance between elements within the buffer, respectively,
        /// and are both measured in basic machine units. bindingindex must be less than the
        /// value of GL_MAX_VERTEX_ATTRIB_BINDINGS. offset and stride must be greater than
        /// or equal to zero. If buffer is zero, then any buffer currently bound to the
        /// specified binding point is unbound.
        /// </para>
        /// </summary>
        public static void BindVertexBuffer(UInt32 bindingindex, UInt32 buffer, IntPtr offset, IntPtr stride)
        {
            Delegates.glBindVertexBuffer(bindingindex, buffer, offset, stride);
        }

        /// <summary>
        /// Bind a buffer to a vertex buffer bind point.
        /// <para>
        /// glBindVertexBuffer and glVertexArrayVertexBuffer bind the buffer named buffer to
        /// the vertex buffer binding point whose index is given by bindingindex.
        /// glBindVertexBuffer modifies the binding of the currently bound vertex array
        /// object, whereas glVertexArrayVertexBuffer allows the caller to specify ID of the
        /// vertex array object with an argument named vaobj, for which the binding should
        /// be modified. offset and stride specify the offset of the first element within
        /// the buffer and the distance between elements within the buffer, respectively,
        /// and are both measured in basic machine units. bindingindex must be less than the
        /// value of GL_MAX_VERTEX_ATTRIB_BINDINGS. offset and stride must be greater than
        /// or equal to zero. If buffer is zero, then any buffer currently bound to the
        /// specified binding point is unbound.
        /// </para>
        /// </summary>
        public static void VertexArrayVertexBuffer(UInt32 vaobj, UInt32 bindingindex, UInt32 buffer, IntPtr offset, Int32 stride)
        {
            Delegates.glVertexArrayVertexBuffer(vaobj, bindingindex, buffer, offset, stride);
        }

        /// <summary>
        /// Attach multiple buffer objects to a vertex array object.
        /// <para>
        /// glBindVertexBuffers and glVertexArrayVertexBuffers bind storage from an array of
        /// existing buffer objects to a specified number of consecutive vertex buffer
        /// binding points units in a vertex array object. For glBindVertexBuffers, the
        /// vertex array object is the currently bound vertex array object. For
        /// glVertexArrayVertexBuffers, vaobj is the name of the vertex array object.
        /// </para>
        /// </summary>
        public static void BindVertexBuffers(UInt32 first, Int32 count, UInt32[] buffers, IntPtr[] offsets, Int32[] strides)
        {
            Delegates.glBindVertexBuffers(first, count, buffers, offsets, strides);
        }

        /// <summary>
        /// Attach multiple buffer objects to a vertex array object.
        /// <para>
        /// glBindVertexBuffers and glVertexArrayVertexBuffers bind storage from an array of
        /// existing buffer objects to a specified number of consecutive vertex buffer
        /// binding points units in a vertex array object. For glBindVertexBuffers, the
        /// vertex array object is the currently bound vertex array object. For
        /// glVertexArrayVertexBuffers, vaobj is the name of the vertex array object.
        /// </para>
        /// </summary>
        public static void VertexArrayVertexBuffers(UInt32 vaobj, UInt32 first, Int32 count, UInt32[] buffers, IntPtr[] offsets, Int32[] strides)
        {
            Delegates.glVertexArrayVertexBuffers(vaobj, first, count, buffers, offsets, strides);
        }

        /// <summary>
        /// Set the blend color.
        /// <para>
        /// The GL_BLEND_COLOR may be used to calculate the source and destination blending
        /// factors. The color components are clamped to the range 0 1 before being stored.
        /// See glBlendFunc for a complete description of the blending operations. Initially
        /// the GL_BLEND_COLOR is set to (0, 0, 0, 0).
        /// </para>
        /// </summary>
        public static void BlendColor(Single red, Single green, Single blue, Single alpha)
        {
            Delegates.glBlendColor(red, green, blue, alpha);
        }

        /// <summary>
        /// Specify the equation used for both the RGB blend equation and the Alpha blend equation.
        /// <para>
        /// The blend equations determine how a new pixel (the ''source'' color) is combined
        /// with a pixel already in the framebuffer (the ''destination'' color). This
        /// function sets both the RGB blend equation and the alpha blend equation to a
        /// single equation. glBlendEquationi specifies the blend equation for a single draw
        /// buffer whereas glBlendEquation sets the blend equation for all draw buffers.
        /// </para>
        /// </summary>
        public static void BlendEquation(OpenGL.BlendEquationMode mode)
        {
            Delegates.glBlendEquation(mode);
        }

        /// <summary>
        /// Specify the equation used for both the RGB blend equation and the Alpha blend equation.
        /// <para>
        /// The blend equations determine how a new pixel (the ''source'' color) is combined
        /// with a pixel already in the framebuffer (the ''destination'' color). This
        /// function sets both the RGB blend equation and the alpha blend equation to a
        /// single equation. glBlendEquationi specifies the blend equation for a single draw
        /// buffer whereas glBlendEquation sets the blend equation for all draw buffers.
        /// </para>
        /// </summary>
        public static void BlendEquationi(UInt32 buf, OpenGL.BlendEquationMode mode)
        {
            Delegates.glBlendEquationi(buf, mode);
        }

        /// <summary>
        /// Set the RGB blend equation and the alpha blend equation separately.
        /// <para>
        /// The blend equations determines how a new pixel (the ''source'' color) is
        /// combined with a pixel already in the framebuffer (the ''destination'' color).
        /// These functions specify one blend equation for the RGB-color components and one
        /// blend equation for the alpha component. glBlendEquationSeparatei specifies the
        /// blend equations for a single draw buffer whereas glBlendEquationSeparate sets
        /// the blend equations for all draw buffers.
        /// </para>
        /// </summary>
        public static void BlendEquationSeparate(OpenGL.BlendEquationMode modeRGB, OpenGL.BlendEquationMode modeAlpha)
        {
            Delegates.glBlendEquationSeparate(modeRGB, modeAlpha);
        }

        /// <summary>
        /// Set the RGB blend equation and the alpha blend equation separately.
        /// <para>
        /// The blend equations determines how a new pixel (the ''source'' color) is
        /// combined with a pixel already in the framebuffer (the ''destination'' color).
        /// These functions specify one blend equation for the RGB-color components and one
        /// blend equation for the alpha component. glBlendEquationSeparatei specifies the
        /// blend equations for a single draw buffer whereas glBlendEquationSeparate sets
        /// the blend equations for all draw buffers.
        /// </para>
        /// </summary>
        public static void BlendEquationSeparatei(UInt32 buf, OpenGL.BlendEquationMode modeRGB, OpenGL.BlendEquationMode modeAlpha)
        {
            Delegates.glBlendEquationSeparatei(buf, modeRGB, modeAlpha);
        }

        /// <summary>
        /// Specify pixel arithmetic.
        /// <para>
        /// Pixels can be drawn using a function that blends the incoming (source) RGBA
        /// values with the RGBA values that are already in the frame buffer (the
        /// destination values). Blending is initially disabled. Use glEnable and glDisable
        /// with argument GL_BLEND to enable and disable blending.
        /// </para>
        /// </summary>
        public static void BlendFunc(OpenGL.BlendingFactorSrc sfactor, OpenGL.BlendingFactorDest dfactor)
        {
            Delegates.glBlendFunc(sfactor, dfactor);
        }

        /// <summary>
        /// Specify pixel arithmetic.
        /// <para>
        /// Pixels can be drawn using a function that blends the incoming (source) RGBA
        /// values with the RGBA values that are already in the frame buffer (the
        /// destination values). Blending is initially disabled. Use glEnable and glDisable
        /// with argument GL_BLEND to enable and disable blending.
        /// </para>
        /// </summary>
        public static void BlendFunci(UInt32 buf, OpenGL.BlendingFactorSrc sfactor, OpenGL.BlendingFactorDest dfactor)
        {
            Delegates.glBlendFunci(buf, sfactor, dfactor);
        }

        /// <summary>
        /// Specify pixel arithmetic for RGB and alpha components separately.
        /// <para>
        /// Pixels can be drawn using a function that blends the incoming (source) RGBA
        /// values with the RGBA values that are already in the frame buffer (the
        /// destination values). Blending is initially disabled. Use glEnable and glDisable
        /// with argument GL_BLEND to enable and disable blending.
        /// </para>
        /// </summary>
        public static void BlendFuncSeparate(OpenGL.BlendingFactorSrc srcRGB, OpenGL.BlendingFactorDest dstRGB, OpenGL.BlendingFactorSrc srcAlpha, OpenGL.BlendingFactorDest dstAlpha)
        {
            Delegates.glBlendFuncSeparate(srcRGB, dstRGB, srcAlpha, dstAlpha);
        }

        /// <summary>
        /// Specify pixel arithmetic for RGB and alpha components separately.
        /// <para>
        /// Pixels can be drawn using a function that blends the incoming (source) RGBA
        /// values with the RGBA values that are already in the frame buffer (the
        /// destination values). Blending is initially disabled. Use glEnable and glDisable
        /// with argument GL_BLEND to enable and disable blending.
        /// </para>
        /// </summary>
        public static void BlendFuncSeparatei(UInt32 buf, OpenGL.BlendingFactorSrc srcRGB, OpenGL.BlendingFactorDest dstRGB, OpenGL.BlendingFactorSrc srcAlpha, OpenGL.BlendingFactorDest dstAlpha)
        {
            Delegates.glBlendFuncSeparatei(buf, srcRGB, dstRGB, srcAlpha, dstAlpha);
        }

        /// <summary>
        /// Copy a block of pixels from one framebuffer object to another.
        /// <para>
        /// glBlitFramebuffer and glBlitNamedFramebuffer transfer a rectangle of pixel
        /// values from one region of a read framebuffer to another region of a draw
        /// framebuffer.
        /// </para>
        /// </summary>
        public static void BlitFramebuffer(Int32 srcX0, Int32 srcY0, Int32 srcX1, Int32 srcY1, Int32 dstX0, Int32 dstY0, Int32 dstX1, Int32 dstY1, OpenGL.ClearBufferMask mask, OpenGL.BlitFramebufferFilter filter)
        {
            Delegates.glBlitFramebuffer(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
        }

        /// <summary>
        /// Copy a block of pixels from one framebuffer object to another.
        /// <para>
        /// glBlitFramebuffer and glBlitNamedFramebuffer transfer a rectangle of pixel
        /// values from one region of a read framebuffer to another region of a draw
        /// framebuffer.
        /// </para>
        /// </summary>
        public static void BlitNamedFramebuffer(UInt32 readFramebuffer, UInt32 drawFramebuffer, Int32 srcX0, Int32 srcY0, Int32 srcX1, Int32 srcY1, Int32 dstX0, Int32 dstY0, Int32 dstX1, Int32 dstY1, OpenGL.ClearBufferMask mask, OpenGL.BlitFramebufferFilter filter)
        {
            Delegates.glBlitNamedFramebuffer(readFramebuffer, drawFramebuffer, srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
        }

        /// <summary>
        /// Creates and initializes a buffer object's data store.
        /// <para>
        /// glBufferData and glNamedBufferData create a new data store for a buffer object.
        /// In case of glBufferData, the buffer object currently bound to target is used.
        /// For glNamedBufferData, a buffer object associated with ID specified by the
        /// caller in buffer will be used instead.
        /// </para>
        /// </summary>
        public static void BufferData(OpenGL.BufferTarget target, IntPtr size, IntPtr data, OpenGL.BufferUsageHint usage)
        {
            Delegates.glBufferData(target, size, data, usage);
        }

        /// <summary>
        /// Creates and initializes a buffer object's data store.
        /// <para>
        /// glBufferData and glNamedBufferData create a new data store for a buffer object.
        /// In case of glBufferData, the buffer object currently bound to target is used.
        /// For glNamedBufferData, a buffer object associated with ID specified by the
        /// caller in buffer will be used instead.
        /// </para>
        /// </summary>
        public static void NamedBufferData(UInt32 buffer, Int32 size, IntPtr data, OpenGL.BufferUsageHint usage)
        {
            Delegates.glNamedBufferData(buffer, size, data, usage);
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// <para>
        /// glBufferStorage and glNamedBufferStorage create a new immutable data store. For
        /// glBufferStorage, the buffer object currently bound to target will be
        /// initialized. For glNamedBufferStorage, buffer is the name of the buffer object
        /// that will be configured. The size of the data store is specified by size. If an
        /// initial data is available, its address may be supplied in data. Otherwise, to
        /// create an uninitialized data store, data should be NULL.
        /// </para>
        /// </summary>
        public static void BufferStorage(OpenGL.BufferTarget target, IntPtr size, IntPtr data, UInt32 flags)
        {
            Delegates.glBufferStorage(target, size, data, flags);
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// <para>
        /// glBufferStorage and glNamedBufferStorage create a new immutable data store. For
        /// glBufferStorage, the buffer object currently bound to target will be
        /// initialized. For glNamedBufferStorage, buffer is the name of the buffer object
        /// that will be configured. The size of the data store is specified by size. If an
        /// initial data is available, its address may be supplied in data. Otherwise, to
        /// create an uninitialized data store, data should be NULL.
        /// </para>
        /// </summary>
        public static void NamedBufferStorage(UInt32 buffer, Int32 size, IntPtr data, UInt32 flags)
        {
            Delegates.glNamedBufferStorage(buffer, size, data, flags);
        }

        /// <summary>
        /// Updates a subset of a buffer object's data store.
        /// <para>
        /// glBufferSubData and glNamedBufferSubData redefine some or all of the data store
        /// for the specified buffer object. Data starting at byte offset offset and
        /// extending for size bytes is copied to the data store from the memory pointed to
        /// by data. offset and size must define a range lying entirely within the buffer
        /// object's data store.
        /// </para>
        /// </summary>
        public static void BufferSubData(OpenGL.BufferTarget target, IntPtr offset, IntPtr size, IntPtr data)
        {
            Delegates.glBufferSubData(target, offset, size, data);
        }

        /// <summary>
        /// Updates a subset of a buffer object's data store.
        /// <para>
        /// glBufferSubData and glNamedBufferSubData redefine some or all of the data store
        /// for the specified buffer object. Data starting at byte offset offset and
        /// extending for size bytes is copied to the data store from the memory pointed to
        /// by data. offset and size must define a range lying entirely within the buffer
        /// object's data store.
        /// </para>
        /// </summary>
        public static void NamedBufferSubData(UInt32 buffer, IntPtr offset, Int32 size, IntPtr data)
        {
            Delegates.glNamedBufferSubData(buffer, offset, size, data);
        }

        /// <summary>
        /// Check the completeness status of a framebuffer.
        /// <para>
        /// glCheckFramebufferStatus and glCheckNamedFramebufferStatus return the
        /// completeness status of a framebuffer object when treated as a read or draw
        /// framebuffer, depending on the value of target.
        /// </para>
        /// </summary>
        public static OpenGL.FramebufferErrorCode CheckFramebufferStatus(OpenGL.FramebufferTarget target)
        {
            return Delegates.glCheckFramebufferStatus(target);
        }

        /// <summary>
        /// Check the completeness status of a framebuffer.
        /// <para>
        /// glCheckFramebufferStatus and glCheckNamedFramebufferStatus return the
        /// completeness status of a framebuffer object when treated as a read or draw
        /// framebuffer, depending on the value of target.
        /// </para>
        /// </summary>
        public static OpenGL.FramebufferErrorCode CheckNamedFramebufferStatus(UInt32 framebuffer, OpenGL.FramebufferTarget target)
        {
            return Delegates.glCheckNamedFramebufferStatus(framebuffer, target);
        }

        /// <summary>
        /// Specify whether data read via glReadPixels should be clamped.
        /// <para>
        /// glClampColor controls color clamping that is performed during glReadPixels.
        /// target must be GL_CLAMP_READ_COLOR. If clamp is GL_TRUE, read color clamping is
        /// enabled; if clamp is GL_FALSE, read color clamping is disabled. If clamp is
        /// GL_FIXED_ONLY, read color clamping is enabled only if the selected read buffer
        /// has fixed point components and disabled otherwise.
        /// </para>
        /// </summary>
        public static void ClampColor(OpenGL.ClampColorTarget target, OpenGL.ClampColorMode clamp)
        {
            Delegates.glClampColor(target, clamp);
        }

        /// <summary>
        /// Clear buffers to preset values.
        /// <para>
        /// glClear sets the bitplane area of the window to values previously selected by
        /// glClearColor, glClearDepth, and glClearStencil. Multiple color buffers can be
        /// cleared simultaneously by selecting more than one buffer at a time using
        /// glDrawBuffer.
        /// </para>
        /// </summary>
        public static void Clear(OpenGL.ClearBufferMask mask)
        {
            Delegates.glClear(mask);
        }

        /// <summary>
        /// Clear individual buffers of a framebuffer.
        /// <para>
        /// These commands clear a specified buffer of a framebuffer to specified value(s).
        /// For glClearBuffer*, the framebuffer is the currently bound draw framebuffer
        /// object. For glClearNamedFramebuffer*, framebuffer is zero, indicating the
        /// default draw framebuffer, or the name of a framebuffer object.
        /// </para>
        /// </summary>
        public static void ClearBufferiv(OpenGL.ClearBuffer buffer, Int32 drawbuffer, Int32[] value)
        {
            Delegates.glClearBufferiv(buffer, drawbuffer, value);
        }

        /// <summary>
        /// Clear individual buffers of a framebuffer.
        /// <para>
        /// These commands clear a specified buffer of a framebuffer to specified value(s).
        /// For glClearBuffer*, the framebuffer is the currently bound draw framebuffer
        /// object. For glClearNamedFramebuffer*, framebuffer is zero, indicating the
        /// default draw framebuffer, or the name of a framebuffer object.
        /// </para>
        /// </summary>
        public static void ClearBufferuiv(OpenGL.ClearBuffer buffer, Int32 drawbuffer, UInt32[] value)
        {
            Delegates.glClearBufferuiv(buffer, drawbuffer, value);
        }

        /// <summary>
        /// Clear individual buffers of a framebuffer.
        /// <para>
        /// These commands clear a specified buffer of a framebuffer to specified value(s).
        /// For glClearBuffer*, the framebuffer is the currently bound draw framebuffer
        /// object. For glClearNamedFramebuffer*, framebuffer is zero, indicating the
        /// default draw framebuffer, or the name of a framebuffer object.
        /// </para>
        /// </summary>
        public static void ClearBufferfv(OpenGL.ClearBuffer buffer, Int32 drawbuffer, Single[] value)
        {
            Delegates.glClearBufferfv(buffer, drawbuffer, value);
        }

        /// <summary>
        /// Clear individual buffers of a framebuffer.
        /// <para>
        /// These commands clear a specified buffer of a framebuffer to specified value(s).
        /// For glClearBuffer*, the framebuffer is the currently bound draw framebuffer
        /// object. For glClearNamedFramebuffer*, framebuffer is zero, indicating the
        /// default draw framebuffer, or the name of a framebuffer object.
        /// </para>
        /// </summary>
        public static void ClearBufferfi(OpenGL.ClearBuffer buffer, Int32 drawbuffer, Single depth, Int32 stencil)
        {
            Delegates.glClearBufferfi(buffer, drawbuffer, depth, stencil);
        }

        /// <summary>
        /// Clear individual buffers of a framebuffer.
        /// <para>
        /// These commands clear a specified buffer of a framebuffer to specified value(s).
        /// For glClearBuffer*, the framebuffer is the currently bound draw framebuffer
        /// object. For glClearNamedFramebuffer*, framebuffer is zero, indicating the
        /// default draw framebuffer, or the name of a framebuffer object.
        /// </para>
        /// </summary>
        public static void ClearNamedFramebufferiv(UInt32 framebuffer, OpenGL.ClearBuffer buffer, Int32 drawbuffer, Int32[] value)
        {
            Delegates.glClearNamedFramebufferiv(framebuffer, buffer, drawbuffer, value);
        }

        /// <summary>
        /// Clear individual buffers of a framebuffer.
        /// <para>
        /// These commands clear a specified buffer of a framebuffer to specified value(s).
        /// For glClearBuffer*, the framebuffer is the currently bound draw framebuffer
        /// object. For glClearNamedFramebuffer*, framebuffer is zero, indicating the
        /// default draw framebuffer, or the name of a framebuffer object.
        /// </para>
        /// </summary>
        public static void ClearNamedFramebufferuiv(UInt32 framebuffer, OpenGL.ClearBuffer buffer, Int32 drawbuffer, UInt32[] value)
        {
            Delegates.glClearNamedFramebufferuiv(framebuffer, buffer, drawbuffer, value);
        }

        /// <summary>
        /// Clear individual buffers of a framebuffer.
        /// <para>
        /// These commands clear a specified buffer of a framebuffer to specified value(s).
        /// For glClearBuffer*, the framebuffer is the currently bound draw framebuffer
        /// object. For glClearNamedFramebuffer*, framebuffer is zero, indicating the
        /// default draw framebuffer, or the name of a framebuffer object.
        /// </para>
        /// </summary>
        public static void ClearNamedFramebufferfv(UInt32 framebuffer, OpenGL.ClearBuffer buffer, Int32 drawbuffer, Single[] value)
        {
            Delegates.glClearNamedFramebufferfv(framebuffer, buffer, drawbuffer, value);
        }

        /// <summary>
        /// Clear individual buffers of a framebuffer.
        /// <para>
        /// These commands clear a specified buffer of a framebuffer to specified value(s).
        /// For glClearBuffer*, the framebuffer is the currently bound draw framebuffer
        /// object. For glClearNamedFramebuffer*, framebuffer is zero, indicating the
        /// default draw framebuffer, or the name of a framebuffer object.
        /// </para>
        /// </summary>
        public static void ClearNamedFramebufferfi(UInt32 framebuffer, OpenGL.ClearBuffer buffer, Single depth, Int32 stencil)
        {
            Delegates.glClearNamedFramebufferfi(framebuffer, buffer, depth, stencil);
        }

        /// <summary>
        /// Fill a buffer object's data store with a fixed value.
        /// <para>
        /// glClearBufferData and glClearNamedBufferData fill the entirety of a buffer
        /// object's data store with data from client memory.
        /// </para>
        /// </summary>
        public static void ClearBufferData(OpenGL.BufferTarget target, OpenGL.SizedInternalFormat internalFormat, OpenGL.PixelInternalFormat format, OpenGL.PixelType type, IntPtr data)
        {
            Delegates.glClearBufferData(target, internalFormat, format, type, data);
        }

        /// <summary>
        /// Fill a buffer object's data store with a fixed value.
        /// <para>
        /// glClearBufferData and glClearNamedBufferData fill the entirety of a buffer
        /// object's data store with data from client memory.
        /// </para>
        /// </summary>
        public static void ClearNamedBufferData(UInt32 buffer, OpenGL.SizedInternalFormat internalFormat, OpenGL.PixelInternalFormat format, OpenGL.PixelType type, IntPtr data)
        {
            Delegates.glClearNamedBufferData(buffer, internalFormat, format, type, data);
        }

        /// <summary>
        /// Fill all or part of buffer object's data store with a fixed value.
        /// <para>
        /// glClearBufferSubData and glClearNamedBufferSubData fill a specified region of a
        /// buffer object's data store with data from client memory.
        /// </para>
        /// </summary>
        public static void ClearBufferSubData(OpenGL.BufferTarget target, OpenGL.SizedInternalFormat internalFormat, IntPtr offset, IntPtr size, OpenGL.PixelInternalFormat format, OpenGL.PixelType type, IntPtr data)
        {
            Delegates.glClearBufferSubData(target, internalFormat, offset, size, format, type, data);
        }

        /// <summary>
        /// Fill all or part of buffer object's data store with a fixed value.
        /// <para>
        /// glClearBufferSubData and glClearNamedBufferSubData fill a specified region of a
        /// buffer object's data store with data from client memory.
        /// </para>
        /// </summary>
        public static void ClearNamedBufferSubData(UInt32 buffer, OpenGL.SizedInternalFormat internalFormat, IntPtr offset, Int32 size, OpenGL.PixelInternalFormat format, OpenGL.PixelType type, IntPtr data)
        {
            Delegates.glClearNamedBufferSubData(buffer, internalFormat, offset, size, format, type, data);
        }

        /// <summary>
        /// Specify clear values for the color buffers.
        /// <para>
        /// glClearColor specifies the red, green, blue, and alpha values used by glClear to
        /// clear the color buffers. Values specified by glClearColor are clamped to the
        /// range 0 1.
        /// </para>
        /// </summary>
        public static void ClearColor(Single red, Single green, Single blue, Single alpha)
        {
            Delegates.glClearColor(red, green, blue, alpha);
        }

        /// <summary>
        /// Specify the clear value for the depth buffer.
        /// <para>
        /// glClearDepth specifies the depth value used by glClear to clear the depth
        /// buffer. Values specified by glClearDepth are clamped to the range 0 1.
        /// </para>
        /// </summary>
        public static void ClearDepth(Double depth)
        {
            Delegates.glClearDepth(depth);
        }

        /// <summary>
        /// Specify the clear value for the depth buffer.
        /// <para>
        /// glClearDepth specifies the depth value used by glClear to clear the depth
        /// buffer. Values specified by glClearDepth are clamped to the range 0 1.
        /// </para>
        /// </summary>
        public static void ClearDepthf(Single depth)
        {
            Delegates.glClearDepthf(depth);
        }

        /// <summary>
        /// Specify the clear value for the stencil buffer.
        /// <para>
        /// glClearStencil specifies the index used by glClear to clear the stencil buffer.
        /// s is masked with 2 m - 1 , where m is the number of bits in the stencil buffer.
        /// </para>
        /// </summary>
        public static void ClearStencil(Int32 s)
        {
            Delegates.glClearStencil(s);
        }

        /// <summary>
        /// Fills all a texture image with a constant value.
        /// <para>
        /// glClearTexImage fills all an image contained in a texture with an application
        /// supplied value. texture must be the name of an existing texture. Further,
        /// texture may not be the name of a buffer texture, nor may its internal format be
        /// compressed.
        /// </para>
        /// </summary>
        public static void ClearTexImage(UInt32 texture, Int32 level, OpenGL.PixelInternalFormat format, OpenGL.PixelType type, IntPtr data)
        {
            Delegates.glClearTexImage(texture, level, format, type, data);
        }

        /// <summary>
        /// Fills all or part of a texture image with a constant value.
        /// <para>
        /// glClearTexSubImage fills all or part of an image contained in a texture with an
        /// application supplied value. texture must be the name of an existing texture.
        /// Further, texture may not be the name of a buffer texture, nor may its internal
        /// format be compressed.
        /// </para>
        /// </summary>
        public static void ClearTexSubImage(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenGL.PixelInternalFormat format, OpenGL.PixelType type, IntPtr data)
        {
            Delegates.glClearTexSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, data);
        }

        /// <summary>
        /// Block and wait for a sync object to become signaled.
        /// <para>
        /// glClientWaitSync causes the client to block and wait for the sync object
        /// specified by sync to become signaled. If sync is signaled when glClientWaitSync
        /// is called, glClientWaitSync returns immediately, otherwise it will block and
        /// wait for up to timeout nanoseconds for sync to become signaled.
        /// </para>
        /// </summary>
        public static OpenGL.ArbSync ClientWaitSync(IntPtr sync, UInt32 flags, UInt64 timeout)
        {
            return Delegates.glClientWaitSync(sync, flags, timeout);
        }

        /// <summary>
        /// Control clip coordinate to window coordinate behavior.
        /// <para>
        /// glClipControl controls the clipping volume behavior and the clip coordinate to
        /// window coordinate transformation behavior.
        /// </para>
        /// </summary>
        public static void ClipControl(OpenGL.ClipControlOrigin origin, OpenGL.ClipControlDepth depth)
        {
            Delegates.glClipControl(origin, depth);
        }

        /// <summary>
        /// Enable and disable writing of frame buffer color components.
        /// <para>
        /// glColorMask and glColorMaski specify whether the individual color components in
        /// the frame buffer can or cannot be written. glColorMaski sets the mask for a
        /// specific draw buffer, whereas glColorMask sets the mask for all draw buffers. If
        /// red is GL_FALSE, for example, no change is made to the red component of any
        /// pixel in any of the color buffers, regardless of the drawing operation
        /// attempted.
        /// </para>
        /// </summary>
        public static void ColorMask(Boolean red, Boolean green, Boolean blue, Boolean alpha)
        {
            Delegates.glColorMask(red, green, blue, alpha);
        }

        /// <summary>
        /// Enable and disable writing of frame buffer color components.
        /// <para>
        /// glColorMask and glColorMaski specify whether the individual color components in
        /// the frame buffer can or cannot be written. glColorMaski sets the mask for a
        /// specific draw buffer, whereas glColorMask sets the mask for all draw buffers. If
        /// red is GL_FALSE, for example, no change is made to the red component of any
        /// pixel in any of the color buffers, regardless of the drawing operation
        /// attempted.
        /// </para>
        /// </summary>
        public static void ColorMaski(UInt32 buf, Boolean red, Boolean green, Boolean blue, Boolean alpha)
        {
            Delegates.glColorMaski(buf, red, green, blue, alpha);
        }

        /// <summary>
        /// Compiles a shader object.
        /// <para>
        /// glCompileShader compiles the source code strings that have been stored in the
        /// shader object specified by shader.
        /// </para>
        /// </summary>
        public static void CompileShader(UInt32 shader)
        {
            Delegates.glCompileShader(shader);
        }

        /// <summary>
        /// Specify a one-dimensional texture image in a compressed format.
        /// <para>
        /// Texturing allows elements of an image array to be read by shaders.
        /// </para>
        /// </summary>
        public static void CompressedTexImage1D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalFormat, Int32 width, Int32 border, Int32 imageSize, IntPtr data)
        {
            Delegates.glCompressedTexImage1D(target, level, internalFormat, width, border, imageSize, data);
        }

        /// <summary>
        /// Specify a two-dimensional texture image in a compressed format.
        /// <para>
        /// Texturing allows elements of an image array to be read by shaders.
        /// </para>
        /// </summary>
        public static void CompressedTexImage2D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalFormat, Int32 width, Int32 height, Int32 border, Int32 imageSize, IntPtr data)
        {
            Delegates.glCompressedTexImage2D(target, level, internalFormat, width, height, border, imageSize, data);
        }

        /// <summary>
        /// Specify a three-dimensional texture image in a compressed format.
        /// <para>
        /// Texturing allows elements of an image array to be read by shaders.
        /// </para>
        /// </summary>
        public static void CompressedTexImage3D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalFormat, Int32 width, Int32 height, Int32 depth, Int32 border, Int32 imageSize, IntPtr data)
        {
            Delegates.glCompressedTexImage3D(target, level, internalFormat, width, height, depth, border, imageSize, data);
        }

        /// <summary>
        /// Specify a one-dimensional texture subimage in a compressed format.
        /// <para>
        /// Texturing allows elements of an image array to be read by shaders.
        /// </para>
        /// </summary>
        public static void CompressedTexSubImage1D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 width, OpenGL.PixelFormat format, Int32 imageSize, IntPtr data)
        {
            Delegates.glCompressedTexSubImage1D(target, level, xoffset, width, format, imageSize, data);
        }

        /// <summary>
        /// Specify a one-dimensional texture subimage in a compressed format.
        /// <para>
        /// Texturing allows elements of an image array to be read by shaders.
        /// </para>
        /// </summary>
        public static void CompressedTextureSubImage1D(UInt32 texture, Int32 level, Int32 xoffset, Int32 width, OpenGL.PixelInternalFormat format, Int32 imageSize, IntPtr data)
        {
            Delegates.glCompressedTextureSubImage1D(texture, level, xoffset, width, format, imageSize, data);
        }

        /// <summary>
        /// Specify a two-dimensional texture subimage in a compressed format.
        /// <para>
        /// Texturing allows elements of an image array to be read by shaders.
        /// </para>
        /// </summary>
        public static void CompressedTexSubImage2D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenGL.PixelFormat format, Int32 imageSize, IntPtr data)
        {
            Delegates.glCompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, data);
        }

        /// <summary>
        /// Specify a two-dimensional texture subimage in a compressed format.
        /// <para>
        /// Texturing allows elements of an image array to be read by shaders.
        /// </para>
        /// </summary>
        public static void CompressedTextureSubImage2D(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenGL.PixelInternalFormat format, Int32 imageSize, IntPtr data)
        {
            Delegates.glCompressedTextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, imageSize, data);
        }

        /// <summary>
        /// Specify a three-dimensional texture subimage in a compressed format.
        /// <para>
        /// Texturing allows elements of an image array to be read by shaders.
        /// </para>
        /// </summary>
        public static void CompressedTexSubImage3D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenGL.PixelFormat format, Int32 imageSize, IntPtr data)
        {
            Delegates.glCompressedTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data);
        }

        /// <summary>
        /// Specify a three-dimensional texture subimage in a compressed format.
        /// <para>
        /// Texturing allows elements of an image array to be read by shaders.
        /// </para>
        /// </summary>
        public static void CompressedTextureSubImage3D(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenGL.PixelInternalFormat format, Int32 imageSize, IntPtr data)
        {
            Delegates.glCompressedTextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data);
        }

        /// <summary>
        /// Copy all or part of the data store of a buffer object to the data store of another buffer object.
        /// <para>
        /// glCopyBufferSubData and glCopyNamedBufferSubData copy part of the data store
        /// attached to a source buffer object to the data store attached to a destination
        /// buffer object. The number of basic machine units indicated by size is copied
        /// from the source at offset readOffset to the destination at writeOffset.
        /// readOffset, writeOffset and size are in terms of basic machine units.
        /// </para>
        /// </summary>
        public static void CopyBufferSubData(OpenGL.BufferTarget readTarget, OpenGL.BufferTarget writeTarget, IntPtr readOffset, IntPtr writeOffset, IntPtr size)
        {
            Delegates.glCopyBufferSubData(readTarget, writeTarget, readOffset, writeOffset, size);
        }

        /// <summary>
        /// Copy all or part of the data store of a buffer object to the data store of another buffer object.
        /// <para>
        /// glCopyBufferSubData and glCopyNamedBufferSubData copy part of the data store
        /// attached to a source buffer object to the data store attached to a destination
        /// buffer object. The number of basic machine units indicated by size is copied
        /// from the source at offset readOffset to the destination at writeOffset.
        /// readOffset, writeOffset and size are in terms of basic machine units.
        /// </para>
        /// </summary>
        public static void CopyNamedBufferSubData(UInt32 readBuffer, UInt32 writeBuffer, IntPtr readOffset, IntPtr writeOffset, Int32 size)
        {
            Delegates.glCopyNamedBufferSubData(readBuffer, writeBuffer, readOffset, writeOffset, size);
        }

        /// <summary>
        /// Perform a raw data copy between two images.
        /// <para>
        /// glCopyImageSubData may be used to copy data from one image (i.e. texture or
        /// renderbuffer) to another. glCopyImageSubData does not perform general-purpose
        /// conversions such as scaling, resizing, blending, color-space, or format
        /// conversions. It should be considered to operate in a manner similar to a CPU
        /// memcpy. CopyImageSubData can copy between images with different internal
        /// formats, provided the formats are compatible.
        /// </para>
        /// </summary>
        public static void CopyImageSubData(UInt32 srcName, OpenGL.BufferTarget srcTarget, Int32 srcLevel, Int32 srcX, Int32 srcY, Int32 srcZ, UInt32 dstName, OpenGL.BufferTarget dstTarget, Int32 dstLevel, Int32 dstX, Int32 dstY, Int32 dstZ, Int32 srcWidth, Int32 srcHeight, Int32 srcDepth)
        {
            Delegates.glCopyImageSubData(srcName, srcTarget, srcLevel, srcX, srcY, srcZ, dstName, dstTarget, dstLevel, dstX, dstY, dstZ, srcWidth, srcHeight, srcDepth);
        }

        /// <summary>
        /// Copy pixels into a 1D texture image.
        /// <para>
        /// glCopyTexImage1D defines a one-dimensional texture image with pixels from the
        /// current GL_READ_BUFFER.
        /// </para>
        /// </summary>
        public static void CopyTexImage1D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalFormat, Int32 x, Int32 y, Int32 width, Int32 border)
        {
            Delegates.glCopyTexImage1D(target, level, internalFormat, x, y, width, border);
        }

        /// <summary>
        /// Copy pixels into a 2D texture image.
        /// <para>
        /// glCopyTexImage2D defines a two-dimensional texture image, or cube-map texture
        /// image with pixels from the current GL_READ_BUFFER.
        /// </para>
        /// </summary>
        public static void CopyTexImage2D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalFormat, Int32 x, Int32 y, Int32 width, Int32 height, Int32 border)
        {
            Delegates.glCopyTexImage2D(target, level, internalFormat, x, y, width, height, border);
        }

        /// <summary>
        /// Copy a one-dimensional texture subimage.
        /// <para>
        /// glCopyTexSubImage1D and glCopyTextureSubImage1D replace a portion of a
        /// one-dimensional texture image with pixels from the current GL_READ_BUFFER
        /// (rather than from main memory, as is the case for glTexSubImage1D). For
        /// glCopyTexSubImage1D, the texture object that is bound to target will be used for
        /// the process. For glCopyTextureSubImage1D, texture tells which texture object
        /// should be used for the purpose of the call.
        /// </para>
        /// </summary>
        public static void CopyTexSubImage1D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 x, Int32 y, Int32 width)
        {
            Delegates.glCopyTexSubImage1D(target, level, xoffset, x, y, width);
        }

        /// <summary>
        /// Copy a one-dimensional texture subimage.
        /// <para>
        /// glCopyTexSubImage1D and glCopyTextureSubImage1D replace a portion of a
        /// one-dimensional texture image with pixels from the current GL_READ_BUFFER
        /// (rather than from main memory, as is the case for glTexSubImage1D). For
        /// glCopyTexSubImage1D, the texture object that is bound to target will be used for
        /// the process. For glCopyTextureSubImage1D, texture tells which texture object
        /// should be used for the purpose of the call.
        /// </para>
        /// </summary>
        public static void CopyTextureSubImage1D(UInt32 texture, Int32 level, Int32 xoffset, Int32 x, Int32 y, Int32 width)
        {
            Delegates.glCopyTextureSubImage1D(texture, level, xoffset, x, y, width);
        }

        /// <summary>
        /// Copy a two-dimensional texture subimage.
        /// <para>
        /// glCopyTexSubImage2D and glCopyTextureSubImage2D replace a rectangular portion of
        /// a two-dimensional texture image, cube-map texture image, rectangular image, or a
        /// linear portion of a number of slices of a one-dimensional array texture with
        /// pixels from the current GL_READ_BUFFER (rather than from main memory, as is the
        /// case for glTexSubImage2D).
        /// </para>
        /// </summary>
        public static void CopyTexSubImage2D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 x, Int32 y, Int32 width, Int32 height)
        {
            Delegates.glCopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height);
        }

        /// <summary>
        /// Copy a two-dimensional texture subimage.
        /// <para>
        /// glCopyTexSubImage2D and glCopyTextureSubImage2D replace a rectangular portion of
        /// a two-dimensional texture image, cube-map texture image, rectangular image, or a
        /// linear portion of a number of slices of a one-dimensional array texture with
        /// pixels from the current GL_READ_BUFFER (rather than from main memory, as is the
        /// case for glTexSubImage2D).
        /// </para>
        /// </summary>
        public static void CopyTextureSubImage2D(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset, Int32 x, Int32 y, Int32 width, Int32 height)
        {
            Delegates.glCopyTextureSubImage2D(texture, level, xoffset, yoffset, x, y, width, height);
        }

        /// <summary>
        /// Copy a three-dimensional texture subimage.
        /// <para>
        /// glCopyTexSubImage3D and glCopyTextureSubImage3D functions replace a rectangular
        /// portion of a three-dimensional or two-dimensional array texture image with
        /// pixels from the current GL_READ_BUFFER (rather than from main memory, as is the
        /// case for glTexSubImage3D).
        /// </para>
        /// </summary>
        public static void CopyTexSubImage3D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 x, Int32 y, Int32 width, Int32 height)
        {
            Delegates.glCopyTexSubImage3D(target, level, xoffset, yoffset, zoffset, x, y, width, height);
        }

        /// <summary>
        /// Copy a three-dimensional texture subimage.
        /// <para>
        /// glCopyTexSubImage3D and glCopyTextureSubImage3D functions replace a rectangular
        /// portion of a three-dimensional or two-dimensional array texture image with
        /// pixels from the current GL_READ_BUFFER (rather than from main memory, as is the
        /// case for glTexSubImage3D).
        /// </para>
        /// </summary>
        public static void CopyTextureSubImage3D(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 x, Int32 y, Int32 width, Int32 height)
        {
            Delegates.glCopyTextureSubImage3D(texture, level, xoffset, yoffset, zoffset, x, y, width, height);
        }

        /// <summary>
        /// Create buffer objects.
        /// <para>
        /// glCreateBuffers returns n previously unused buffer names in buffers, each
        /// representing a new buffer object initialized as if it had been bound to an
        /// unspecified target.
        /// </para>
        /// </summary>
        public static void CreateBuffers(Int32 n, UInt32[] buffers)
        {
            Delegates.glCreateBuffers(n, buffers);
        }

        /// <summary>
        /// Create framebuffer objects.
        /// <para>
        /// glCreateFramebuffers returns n previously unused framebuffer names in
        /// framebuffers, each representing a new framebuffer object initialized to the
        /// default state.
        /// </para>
        /// </summary>
        public static void CreateFramebuffers(Int32 n, UInt32[] ids)
        {
            Delegates.glCreateFramebuffers(n, ids);
        }

        /// <summary>
        /// Creates a program object.
        /// <para>
        /// glCreateProgram creates an empty program object and returns a non-zero value by
        /// which it can be referenced. A program object is an object to which shader
        /// objects can be attached. This provides a mechanism to specify the shader objects
        /// that will be linked to create a program. It also provides a means for checking
        /// the compatibility of the shaders that will be used to create a program (for
        /// instance, checking the compatibility between a vertex shader and a fragment
        /// shader). When no longer needed as part of a program object, shader objects can
        /// be detached.
        /// </para>
        /// </summary>
        public static UInt32 CreateProgram()
        {
            return Delegates.glCreateProgram();
        }

        /// <summary>
        /// Create program pipeline objects.
        /// <para>
        /// glCreateProgramPipelines returns n previously unused program pipeline names in
        /// pipelines, each representing a new program pipeline object initialized to the
        /// default state.
        /// </para>
        /// </summary>
        public static void CreateProgramPipelines(Int32 n, UInt32[] pipelines)
        {
            Delegates.glCreateProgramPipelines(n, pipelines);
        }

        /// <summary>
        /// Create query objects.
        /// <para>
        /// glCreateQueries returns n previously unused query object names in ids, each
        /// representing a new query object with the specified target.
        /// </para>
        /// </summary>
        public static void CreateQueries(OpenGL.QueryTarget target, Int32 n, UInt32[] ids)
        {
            Delegates.glCreateQueries(target, n, ids);
        }

        /// <summary>
        /// Create renderbuffer objects.
        /// <para>
        /// glCreateRenderbuffers returns n previously unused renderbuffer object names in
        /// renderbuffers, each representing a new renderbuffer object initialized to the
        /// default state.
        /// </para>
        /// </summary>
        public static void CreateRenderbuffers(Int32 n, UInt32[] renderbuffers)
        {
            Delegates.glCreateRenderbuffers(n, renderbuffers);
        }

        /// <summary>
        /// Create sampler objects.
        /// <para>
        /// glCreateSamplers returns n previously unused sampler names in samplers, each
        /// representing a new sampler object initialized to the default state.
        /// </para>
        /// </summary>
        public static void CreateSamplers(Int32 n, UInt32[] samplers)
        {
            Delegates.glCreateSamplers(n, samplers);
        }

        /// <summary>
        /// Creates a shader object.
        /// <para>
        /// glCreateShader creates an empty shader object and returns a non-zero value by
        /// which it can be referenced. A shader object is used to maintain the source code
        /// strings that define a shader. shaderType indicates the type of shader to be
        /// created. Five types of shader are supported. A shader of type GL_COMPUTE_SHADER
        /// is a shader that is intended to run on the programmable compute processor. A
        /// shader of type GL_VERTEX_SHADER is a shader that is intended to run on the
        /// programmable vertex processor. A shader of type GL_TESS_CONTROL_SHADER is a
        /// shader that is intended to run on the programmable tessellation processor in the
        /// control stage. A shader of type GL_TESS_EVALUATION_SHADER is a shader that is
        /// intended to run on the programmable tessellation processor in the evaluation
        /// stage. A shader of type GL_GEOMETRY_SHADER is a shader that is intended to run
        /// on the programmable geometry processor. A shader of type GL_FRAGMENT_SHADER is a
        /// shader that is intended to run on the programmable fragment processor.
        /// </para>
        /// </summary>
        public static UInt32 CreateShader(OpenGL.ShaderType shaderType)
        {
            return Delegates.glCreateShader(shaderType);
        }

        /// <summary>
        /// Create a stand-alone program from an array of null-terminated source code strings.
        /// <para>
        /// glCreateShaderProgram creates a program object containing compiled and linked
        /// shaders for a single stage specified by type. strings refers to an array of
        /// count strings from which to create the shader executables.
        /// </para>
        /// </summary>
        public static UInt32 CreateShaderProgramv(OpenGL.ShaderType type, Int32 count, String strings)
        {
            return Delegates.glCreateShaderProgramv(type, count, strings);
        }

        /// <summary>
        /// Create texture objects.
        /// <para>
        /// glCreateTextures returns n previously unused texture names in textures, each
        /// representing a new texture object of the dimensionality and type specified by
        /// target and initialized to the default values for that texture type.
        /// </para>
        /// </summary>
        public static void CreateTextures(OpenGL.TextureTarget target, Int32 n, UInt32[] textures)
        {
            Delegates.glCreateTextures(target, n, textures);
        }

        /// <summary>
        /// Create transform feedback objects.
        /// <para>
        /// glCreateTransformFeedbacks returns n previously unused transform feedback object
        /// names in ids, each representing a new transform feedback object initialized to
        /// the default state.
        /// </para>
        /// </summary>
        public static void CreateTransformFeedbacks(Int32 n, UInt32[] ids)
        {
            Delegates.glCreateTransformFeedbacks(n, ids);
        }

        /// <summary>
        /// Create vertex array objects.
        /// <para>
        /// glCreateVertexArrays returns n previously unused vertex array object names in
        /// arrays, each representing a new vertex array object initialized to the default
        /// state.
        /// </para>
        /// </summary>
        public static void CreateVertexArrays(Int32 n, UInt32[] arrays)
        {
            Delegates.glCreateVertexArrays(n, arrays);
        }

        /// <summary>
        /// Specify whether front- or back-facing facets can be culled.
        /// <para>
        /// glCullFace specifies whether front- or back-facing facets are culled (as
        /// specified by mode) when facet culling is enabled. Facet culling is initially
        /// disabled. To enable and disable facet culling, call the glEnable and glDisable
        /// commands with the argument GL_CULL_FACE. Facets include triangles,
        /// quadrilaterals, polygons, and rectangles.
        /// </para>
        /// </summary>
        public static void CullFace(OpenGL.CullFaceMode mode)
        {
            Delegates.glCullFace(mode);
        }

        /// <summary>
        /// Delete named buffer objects.
        /// <para>
        /// glDeleteBuffers deletes n buffer objects named by the elements of the array
        /// buffers. After a buffer object is deleted, it has no contents, and its name is
        /// free for reuse (for example by glGenBuffers). If a buffer object that is
        /// currently bound is deleted, the binding reverts to 0 (the absence of any buffer
        /// object).
        /// </para>
        /// </summary>
        public static void DeleteBuffers(Int32 n, UInt32[] buffers)
        {
            Delegates.glDeleteBuffers(n, buffers);
        }

        /// <summary>
        /// Delete framebuffer objects.
        /// <para>
        /// glDeleteFramebuffers deletes the n framebuffer objects whose names are stored in
        /// the array addressed by framebuffers. The name zero is reserved by the GL and is
        /// silently ignored, should it occur in framebuffers, as are other unused names.
        /// Once a framebuffer object is deleted, its name is again unused and it has no
        /// attachments. If a framebuffer that is currently bound to one or more of the
        /// targets GL_DRAW_FRAMEBUFFER or GL_READ_FRAMEBUFFER is deleted, it is as though
        /// glBindFramebuffer had been executed with the corresponding target and
        /// framebuffer zero.
        /// </para>
        /// </summary>
        public static void DeleteFramebuffers(Int32 n, UInt32[] framebuffers)
        {
            Delegates.glDeleteFramebuffers(n, framebuffers);
        }

        /// <summary>
        /// Deletes a program object.
        /// <para>
        /// glDeleteProgram frees the memory and invalidates the name associated with the
        /// program object specified by program. This command effectively undoes the effects
        /// of a call to glCreateProgram.
        /// </para>
        /// </summary>
        public static void DeleteProgram(UInt32 program)
        {
            Delegates.glDeleteProgram(program);
        }

        /// <summary>
        /// Delete program pipeline objects.
        /// <para>
        /// glDeleteProgramPipelines deletes the n program pipeline objects whose names are
        /// stored in the array pipelines. Unused names in pipelines are ignored, as is the
        /// name zero. After a program pipeline object is deleted, its name is again unused
        /// and it has no contents. If program pipeline object that is currently bound is
        /// deleted, the binding for that object reverts to zero and no program pipeline
        /// object becomes current.
        /// </para>
        /// </summary>
        public static void DeleteProgramPipelines(Int32 n, UInt32[] pipelines)
        {
            Delegates.glDeleteProgramPipelines(n, pipelines);
        }

        /// <summary>
        /// Delete named query objects.
        /// <para>
        /// glDeleteQueries deletes n query objects named by the elements of the array ids.
        /// After a query object is deleted, it has no contents, and its name is free for
        /// reuse (for example by glGenQueries).
        /// </para>
        /// </summary>
        public static void DeleteQueries(Int32 n, UInt32[] ids)
        {
            Delegates.glDeleteQueries(n, ids);
        }

        /// <summary>
        /// Delete renderbuffer objects.
        /// <para>
        /// glDeleteRenderbuffers deletes the n renderbuffer objects whose names are stored
        /// in the array addressed by renderbuffers. The name zero is reserved by the GL and
        /// is silently ignored, should it occur in renderbuffers, as are other unused
        /// names. Once a renderbuffer object is deleted, its name is again unused and it
        /// has no contents. If a renderbuffer that is currently bound to the target
        /// GL_RENDERBUFFER is deleted, it is as though glBindRenderbuffer had been executed
        /// with a target of GL_RENDERBUFFER and a name of zero.
        /// </para>
        /// </summary>
        public static void DeleteRenderbuffers(Int32 n, UInt32[] renderbuffers)
        {
            Delegates.glDeleteRenderbuffers(n, renderbuffers);
        }

        /// <summary>
        /// Delete named sampler objects.
        /// <para>
        /// glDeleteSamplers deletes n sampler objects named by the elements of the array
        /// samplers. After a sampler object is deleted, its name is again unused. If a
        /// sampler object that is currently bound to a sampler unit is deleted, it is as
        /// though glBindSampler is called with unit set to the unit the sampler is bound to
        /// and sampler zero. Unused names in samplers are silently ignored, as is the
        /// reserved name zero.
        /// </para>
        /// </summary>
        public static void DeleteSamplers(Int32 n, UInt32[] samplers)
        {
            Delegates.glDeleteSamplers(n, samplers);
        }

        /// <summary>
        /// Deletes a shader object.
        /// <para>
        /// glDeleteShader frees the memory and invalidates the name associated with the
        /// shader object specified by shader. This command effectively undoes the effects
        /// of a call to glCreateShader.
        /// </para>
        /// </summary>
        public static void DeleteShader(UInt32 shader)
        {
            Delegates.glDeleteShader(shader);
        }

        /// <summary>
        /// Delete a sync object.
        /// <para>
        /// glDeleteSync deletes the sync object specified by sync. If the fence command
        /// corresponding to the specified sync object has completed, or if no glWaitSync or
        /// glClientWaitSync commands are blocking on sync, the object is deleted
        /// immediately. Otherwise, sync is flagged for deletion and will be deleted when it
        /// is no longer associated with any fence command and is no longer blocking any
        /// glWaitSync or glClientWaitSync command. In either case, after glDeleteSync
        /// returns, the name sync is invalid and can no longer be used to refer to the sync
        /// object.
        /// </para>
        /// </summary>
        public static void DeleteSync(IntPtr sync)
        {
            Delegates.glDeleteSync(sync);
        }

        /// <summary>
        /// Delete named textures.
        /// <para>
        /// glDeleteTextures deletes n textures named by the elements of the array textures.
        /// After a texture is deleted, it has no contents or dimensionality, and its name
        /// is free for reuse (for example by glGenTextures). If a texture that is currently
        /// bound is deleted, the binding reverts to 0 (the default texture).
        /// </para>
        /// </summary>
        public static void DeleteTextures(Int32 n, UInt32[] textures)
        {
            Delegates.glDeleteTextures(n, textures);
        }

        /// <summary>
        /// Delete transform feedback objects.
        /// <para>
        /// glDeleteTransformFeedbacks deletes the n transform feedback objects whose names
        /// are stored in the array ids. Unused names in ids are ignored, as is the name
        /// zero. After a transform feedback object is deleted, its name is again unused and
        /// it has no contents. If an active transform feedback object is deleted, its name
        /// immediately becomes unused, but the underlying object is not deleted until it is
        /// no longer active.
        /// </para>
        /// </summary>
        public static void DeleteTransformFeedbacks(Int32 n, UInt32[] ids)
        {
            Delegates.glDeleteTransformFeedbacks(n, ids);
        }

        /// <summary>
        /// Delete vertex array objects.
        /// <para>
        /// glDeleteVertexArrays deletes n vertex array objects whose names are stored in
        /// the array addressed by arrays. Once a vertex array object is deleted it has no
        /// contents and its name is again unused. If a vertex array object that is
        /// currently bound is deleted, the binding for that object reverts to zero and the
        /// default vertex array becomes current. Unused names in arrays are silently
        /// ignored, as is the value zero.
        /// </para>
        /// </summary>
        public static void DeleteVertexArrays(Int32 n, UInt32[] arrays)
        {
            Delegates.glDeleteVertexArrays(n, arrays);
        }

        /// <summary>
        /// Specify the value used for depth buffer comparisons.
        /// <para>
        /// glDepthFunc specifies the function used to compare each incoming pixel depth
        /// value with the depth value present in the depth buffer. The comparison is
        /// performed only if depth testing is enabled. (See glEnable and glDisable of
        /// GL_DEPTH_TEST.).
        /// </para>
        /// </summary>
        public static void DepthFunc(OpenGL.DepthFunction func)
        {
            Delegates.glDepthFunc(func);
        }

        /// <summary>
        /// Enable or disable writing into the depth buffer.
        /// <para>
        /// glDepthMask specifies whether the depth buffer is enabled for writing. If flag
        /// is GL_FALSE, depth buffer writing is disabled. Otherwise, it is enabled.
        /// Initially, depth buffer writing is enabled.
        /// </para>
        /// </summary>
        public static void DepthMask(Boolean flag)
        {
            Delegates.glDepthMask(flag);
        }

        /// <summary>
        /// Specify mapping of depth values from normalized device coordinates to window coordinates.
        /// <para>
        /// After clipping and division by w, depth coordinates range from -1 to 1,
        /// corresponding to the near and far clipping planes. glDepthRange specifies a
        /// linear mapping of the normalized depth coordinates in this range to window depth
        /// coordinates. Regardless of the actual depth buffer implementation, window
        /// coordinate depth values are treated as though they range from 0 through 1 (like
        /// color components). Thus, the values accepted by glDepthRange are both clamped to
        /// this range before they are accepted.
        /// </para>
        /// </summary>
        public static void DepthRange(Double nearVal, Double farVal)
        {
            Delegates.glDepthRange(nearVal, farVal);
        }

        /// <summary>
        /// Specify mapping of depth values from normalized device coordinates to window coordinates.
        /// <para>
        /// After clipping and division by w, depth coordinates range from -1 to 1,
        /// corresponding to the near and far clipping planes. glDepthRange specifies a
        /// linear mapping of the normalized depth coordinates in this range to window depth
        /// coordinates. Regardless of the actual depth buffer implementation, window
        /// coordinate depth values are treated as though they range from 0 through 1 (like
        /// color components). Thus, the values accepted by glDepthRange are both clamped to
        /// this range before they are accepted.
        /// </para>
        /// </summary>
        public static void DepthRangef(Single nearVal, Single farVal)
        {
            Delegates.glDepthRangef(nearVal, farVal);
        }

        /// <summary>
        /// Specify mapping of depth values from normalized device coordinates to window coordinates for a specified set of viewports.
        /// <para>
        /// After clipping and division by w, depth coordinates range from -1 to 1,
        /// corresponding to the near and far clipping planes. Each viewport has an
        /// independent depth range specified as a linear mapping of the normalized depth
        /// coordinates in this range to window depth coordinates. Regardless of the actual
        /// depth buffer implementation, window coordinate depth values are treated as
        /// though they range from 0 through 1 (like color components). glDepthRangeArray
        /// specifies a linear mapping of the normalized depth coordinates in this range to
        /// window depth coordinates for each viewport in the range [first, first + count).
        /// Thus, the values accepted by glDepthRangeArray are both clamped to this range
        /// before they are accepted.
        /// </para>
        /// </summary>
        public static void DepthRangeArrayv(UInt32 first, Int32 count, Double[] v)
        {
            Delegates.glDepthRangeArrayv(first, count, v);
        }

        /// <summary>
        /// Specify mapping of depth values from normalized device coordinates to window coordinates for a specified viewport.
        /// <para>
        /// After clipping and division by w, depth coordinates range from -1 to 1,
        /// corresponding to the near and far clipping planes. Each viewport has an
        /// independent depth range specified as a linear mapping of the normalized depth
        /// coordinates in this range to window depth coordinates. Regardless of the actual
        /// depth buffer implementation, window coordinate depth values are treated as
        /// though they range from 0 through 1 (like color components). glDepthRangeIndexed
        /// specifies a linear mapping of the normalized depth coordinates in this range to
        /// window depth coordinates for a specified viewport. Thus, the values accepted by
        /// glDepthRangeIndexed are both clamped to this range before they are accepted.
        /// </para>
        /// </summary>
        public static void DepthRangeIndexed(UInt32 index, Double nearVal, Double farVal)
        {
            Delegates.glDepthRangeIndexed(index, nearVal, farVal);
        }

        /// <summary>
        /// Detaches a shader object from a program object to which it is attached.
        /// <para>
        /// glDetachShader detaches the shader object specified by shader from the program
        /// object specified by program. This command can be used to undo the effect of the
        /// command glAttachShader.
        /// </para>
        /// </summary>
        public static void DetachShader(UInt32 program, UInt32 shader)
        {
            Delegates.glDetachShader(program, shader);
        }

        /// <summary>
        /// Launch one or more compute work groups.
        /// <para>
        /// glDispatchCompute launches one or more compute work groups. Each work group is
        /// processed by the active program object for the compute shader stage. While the
        /// individual shader invocations within a work group are executed as a unit, work
        /// groups are executed completely independently and in unspecified order.
        /// num_groups_x, num_groups_y and num_groups_z specify the number of local work
        /// groups that will be dispatched in the X, Y and Z dimensions, respectively.
        /// </para>
        /// </summary>
        public static void DispatchCompute(UInt32 num_groups_x, UInt32 num_groups_y, UInt32 num_groups_z)
        {
            Delegates.glDispatchCompute(num_groups_x, num_groups_y, num_groups_z);
        }

        /// <summary>
        /// Launch one or more compute work groups using parameters stored in a buffer.
        /// <para>
        /// glDispatchComputeIndirect launches one or more compute work groups using
        /// parameters stored in the buffer object currently bound to the
        /// GL_DISPATCH_INDIRECT_BUFFER target. Each work group is processed by the active
        /// program object for the compute shader stage. While the individual shader
        /// invocations within a work group are executed as a unit, work groups are executed
        /// completely independently and in unspecified order. indirect contains the offset
        /// into the data store of the buffer object bound to the
        /// GL_DISPATCH_INDIRECT_BUFFER target at which the parameters are stored.
        /// </para>
        /// </summary>
        public static void DispatchComputeIndirect(IntPtr indirect)
        {
            Delegates.glDispatchComputeIndirect(indirect);
        }

        /// <summary>
        /// Render primitives from array data.
        /// <para>
        /// glDrawArrays specifies multiple geometric primitives with very few subroutine
        /// calls. Instead of calling a GL procedure to pass each individual vertex, normal,
        /// texture coordinate, edge flag, or color, you can prespecify separate arrays of
        /// vertices, normals, and colors and use them to construct a sequence of primitives
        /// with a single call to glDrawArrays.
        /// </para>
        /// </summary>
        public static void DrawArrays(OpenGL.BeginMode mode, Int32 first, Int32 count)
        {
            Delegates.glDrawArrays(mode, first, count);
        }

        /// <summary>
        /// Render primitives from array data, taking parameters from memory.
        /// <para>
        /// glDrawArraysIndirect specifies multiple geometric primitives with very few
        /// subroutine calls. glDrawArraysIndirect behaves similarly to
        /// glDrawArraysInstancedBaseInstance, execept that the parameters to
        /// glDrawArraysInstancedBaseInstance are stored in memory at the address given by
        /// indirect.
        /// </para>
        /// </summary>
        public static void DrawArraysIndirect(OpenGL.BeginMode mode, IntPtr indirect)
        {
            Delegates.glDrawArraysIndirect(mode, indirect);
        }

        /// <summary>
        /// Draw multiple instances of a range of elements.
        /// <para>
        /// glDrawArraysInstanced behaves identically to glDrawArrays except that primcount
        /// instances of the range of elements are executed and the value of the internal
        /// counter instanceID advances for each iteration. instanceID is an internal 32-bit
        /// integer counter that may be read by a vertex shader as gl_InstanceID.
        /// </para>
        /// </summary>
        public static void DrawArraysInstanced(OpenGL.BeginMode mode, Int32 first, Int32 count, Int32 primcount)
        {
            Delegates.glDrawArraysInstanced(mode, first, count, primcount);
        }

        /// <summary>
        /// Draw multiple instances of a range of elements with offset applied to instanced attributes.
        /// <para>
        /// glDrawArraysInstancedBaseInstance behaves identically to glDrawArrays except
        /// that primcount instances of the range of elements are executed and the value of
        /// the internal counter instanceID advances for each iteration. instanceID is an
        /// internal 32-bit integer counter that may be read by a vertex shader as
        /// gl_InstanceID.
        /// </para>
        /// </summary>
        public static void DrawArraysInstancedBaseInstance(OpenGL.BeginMode mode, Int32 first, Int32 count, Int32 primcount, UInt32 baseinstance)
        {
            Delegates.glDrawArraysInstancedBaseInstance(mode, first, count, primcount, baseinstance);
        }

        /// <summary>
        /// Specify which color buffers are to be drawn into.
        /// <para>
        /// When colors are written to the frame buffer, they are written into the color
        /// buffers specified by glDrawBuffer. One of the following values can be used for
        /// default framebuffer:.
        /// </para>
        /// </summary>
        public static void DrawBuffer(OpenGL.DrawBufferMode buf)
        {
            Delegates.glDrawBuffer(buf);
        }

        /// <summary>
        /// Specify which color buffers are to be drawn into.
        /// <para>
        /// When colors are written to the frame buffer, they are written into the color
        /// buffers specified by glDrawBuffer. One of the following values can be used for
        /// default framebuffer:.
        /// </para>
        /// </summary>
        public static void NamedFramebufferDrawBuffer(UInt32 framebuffer, OpenGL.DrawBufferMode buf)
        {
            Delegates.glNamedFramebufferDrawBuffer(framebuffer, buf);
        }

        /// <summary>
        /// Specifies a list of color buffers to be drawn into.
        /// <para>
        /// glDrawBuffers and glNamedFramebufferDrawBuffers define an array of buffers into
        /// which outputs from the fragment shader data will be written. If a fragment
        /// shader writes a value to one or more user defined output variables, then the
        /// value of each variable will be written into the buffer specified at a location
        /// within bufs corresponding to the location assigned to that user defined output.
        /// The draw buffer used for user defined outputs assigned to locations greater than
        /// or equal to n is implicitly set to GL_NONE and any data written to such an
        /// output is discarded.
        /// </para>
        /// </summary>
        public static void DrawBuffers(Int32 n, OpenGL.DrawBuffersEnum[] bufs)
        {
            Delegates.glDrawBuffers(n, bufs);
        }

        /// <summary>
        /// Specifies a list of color buffers to be drawn into.
        /// <para>
        /// glDrawBuffers and glNamedFramebufferDrawBuffers define an array of buffers into
        /// which outputs from the fragment shader data will be written. If a fragment
        /// shader writes a value to one or more user defined output variables, then the
        /// value of each variable will be written into the buffer specified at a location
        /// within bufs corresponding to the location assigned to that user defined output.
        /// The draw buffer used for user defined outputs assigned to locations greater than
        /// or equal to n is implicitly set to GL_NONE and any data written to such an
        /// output is discarded.
        /// </para>
        /// </summary>
        public static void NamedFramebufferDrawBuffers(UInt32 framebuffer, Int32 n, OpenGL.DrawBufferMode[] bufs)
        {
            Delegates.glNamedFramebufferDrawBuffers(framebuffer, n, bufs);
        }

        /// <summary>
        /// Render primitives from array data.
        /// <para>
        /// glDrawElements specifies multiple geometric primitives with very few subroutine
        /// calls. Instead of calling a GL function to pass each individual vertex, normal,
        /// texture coordinate, edge flag, or color, you can prespecify separate arrays of
        /// vertices, normals, and so on, and use them to construct a sequence of primitives
        /// with a single call to glDrawElements.
        /// </para>
        /// </summary>
        public static void DrawElements(OpenGL.BeginMode mode, Int32 count, OpenGL.DrawElementsType type, IntPtr indices)
        {
            Delegates.glDrawElements(mode, count, type, indices);
        }

        /// <summary>
        /// Render primitives from array data with a per-element offset.
        /// <para>
        /// glDrawElementsBaseVertex behaves identically to glDrawElements except that the
        /// ith element transferred by the corresponding draw call will be taken from
        /// element indices[i] + basevertex of each enabled array. If the resulting value is
        /// larger than the maximum value representable by type, it is as if the calculation
        /// were upconverted to 32-bit unsigned integers (with wrapping on overflow
        /// conditions). The operation is undefined if the sum would be negative.
        /// </para>
        /// </summary>
        public static void DrawElementsBaseVertex(OpenGL.BeginMode mode, Int32 count, OpenGL.DrawElementsType type, IntPtr indices, Int32 basevertex)
        {
            Delegates.glDrawElementsBaseVertex(mode, count, type, indices, basevertex);
        }

        /// <summary>
        /// Render indexed primitives from array data, taking parameters from memory.
        /// <para>
        /// glDrawElementsIndirect specifies multiple indexed geometric primitives with very
        /// few subroutine calls. glDrawElementsIndirect behaves similarly to
        /// glDrawElementsInstancedBaseVertexBaseInstance, execpt that the parameters to
        /// glDrawElementsInstancedBaseVertexBaseInstance are stored in memory at the
        /// address given by indirect.
        /// </para>
        /// </summary>
        public static void DrawElementsIndirect(OpenGL.BeginMode mode, OpenGL.DrawElementsType type, IntPtr indirect)
        {
            Delegates.glDrawElementsIndirect(mode, type, indirect);
        }

        /// <summary>
        /// Draw multiple instances of a set of elements.
        /// <para>
        /// glDrawElementsInstanced behaves identically to glDrawElements except that
        /// primcount instances of the set of elements are executed and the value of the
        /// internal counter instanceID advances for each iteration. instanceID is an
        /// internal 32-bit integer counter that may be read by a vertex shader as
        /// gl_InstanceID.
        /// </para>
        /// </summary>
        public static void DrawElementsInstanced(OpenGL.BeginMode mode, Int32 count, OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount)
        {
            Delegates.glDrawElementsInstanced(mode, count, type, indices, primcount);
        }

        /// <summary>
        /// Draw multiple instances of a set of elements with offset applied to instanced attributes.
        /// <para>
        /// glDrawElementsInstancedBaseInstance behaves identically to glDrawElements except
        /// that primcount instances of the set of elements are executed and the value of
        /// the internal counter instanceID advances for each iteration. instanceID is an
        /// internal 32-bit integer counter that may be read by a vertex shader as
        /// gl_InstanceID.
        /// </para>
        /// </summary>
        public static void DrawElementsInstancedBaseInstance(OpenGL.BeginMode mode, Int32 count, OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount, UInt32 baseinstance)
        {
            Delegates.glDrawElementsInstancedBaseInstance(mode, count, type, indices, primcount, baseinstance);
        }

        /// <summary>
        /// Render multiple instances of a set of primitives from array data with a per-element offset.
        /// <para>
        /// glDrawElementsInstancedBaseVertex behaves identically to glDrawElementsInstanced
        /// except that the ith element transferred by the corresponding draw call will be
        /// taken from element indices[i] + basevertex of each enabled array. If the
        /// resulting value is larger than the maximum value representable by type, it is as
        /// if the calculation were upconverted to 32-bit unsigned integers (with wrapping
        /// on overflow conditions). The operation is undefined if the sum would be
        /// negative.
        /// </para>
        /// </summary>
        public static void DrawElementsInstancedBaseVertex(OpenGL.BeginMode mode, Int32 count, OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount, Int32 basevertex)
        {
            Delegates.glDrawElementsInstancedBaseVertex(mode, count, type, indices, primcount, basevertex);
        }

        /// <summary>
        /// Render multiple instances of a set of primitives from array data with a per-element offset.
        /// <para>
        /// glDrawElementsInstancedBaseVertexBaseInstance behaves identically to
        /// glDrawElementsInstanced except that the ith element transferred by the
        /// corresponding draw call will be taken from element indices[i] + basevertex of
        /// each enabled array. If the resulting value is larger than the maximum value
        /// representable by type, it is as if the calculation were upconverted to 32-bit
        /// unsigned integers (with wrapping on overflow conditions). The operation is
        /// undefined if the sum would be negative.
        /// </para>
        /// </summary>
        public static void DrawElementsInstancedBaseVertexBaseInstance(OpenGL.BeginMode mode, Int32 count, OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount, Int32 basevertex, UInt32 baseinstance)
        {
            Delegates.glDrawElementsInstancedBaseVertexBaseInstance(mode, count, type, indices, primcount, basevertex, baseinstance);
        }

        /// <summary>
        /// Render primitives from array data.
        /// <para>
        /// glDrawRangeElements is a restricted form of glDrawElements. mode, and count
        /// match the corresponding arguments to glDrawElements, with the additional
        /// constraint that all values in the arrays count must lie between start and end,
        /// inclusive.
        /// </para>
        /// </summary>
        public static void DrawRangeElements(OpenGL.BeginMode mode, UInt32 start, UInt32 end, Int32 count, OpenGL.DrawElementsType type, IntPtr indices)
        {
            Delegates.glDrawRangeElements(mode, start, end, count, type, indices);
        }

        /// <summary>
        /// Render primitives from array data with a per-element offset.
        /// <para>
        /// glDrawRangeElementsBaseVertex is a restricted form of glDrawElementsBaseVertex.
        /// mode, count and basevertex match the corresponding arguments to
        /// glDrawElementsBaseVertex, with the additional constraint that all values in the
        /// array indices must lie between start and end, inclusive, prior to adding
        /// basevertex. Index values lying outside the range [start, end] are treated in the
        /// same way as glDrawElementsBaseVertex. The ith element transferred by the
        /// corresponding draw call will be taken from element indices[i] + basevertex of
        /// each enabled array. If the resulting value is larger than the maximum value
        /// representable by type, it is as if the calculation were upconverted to 32-bit
        /// unsigned integers (with wrapping on overflow conditions). The operation is
        /// undefined if the sum would be negative.
        /// </para>
        /// </summary>
        public static void DrawRangeElementsBaseVertex(OpenGL.BeginMode mode, UInt32 start, UInt32 end, Int32 count, OpenGL.DrawElementsType type, IntPtr indices, Int32 basevertex)
        {
            Delegates.glDrawRangeElementsBaseVertex(mode, start, end, count, type, indices, basevertex);
        }

        /// <summary>
        /// Render primitives using a count derived from a transform feedback object.
        /// <para>
        /// glDrawTransformFeedback draws primitives of a type specified by mode using a
        /// count retrieved from the transform feedback specified by id. Calling
        /// glDrawTransformFeedback is equivalent to calling glDrawArrays with mode as
        /// specified, first set to zero, and count set to the number of vertices captured
        /// on vertex stream zero the last time transform feedback was active on the
        /// transform feedback object named by id.
        /// </para>
        /// </summary>
        public static void DrawTransformFeedback(OpenGL.NvTransformFeedback2 mode, UInt32 id)
        {
            Delegates.glDrawTransformFeedback(mode, id);
        }

        /// <summary>
        /// Render multiple instances of primitives using a count derived from a transform feedback object.
        /// <para>
        /// glDrawTransformFeedbackInstanced draws multiple copies of a range of primitives
        /// of a type specified by mode using a count retrieved from the transform feedback
        /// stream specified by stream of the transform feedback object specified by id.
        /// Calling glDrawTransformFeedbackInstanced is equivalent to calling
        /// glDrawArraysInstanced with mode and primcount as specified, first set to zero,
        /// and count set to the number of vertices captured on vertex stream zero the last
        /// time transform feedback was active on the transform feedback object named by id.
        /// </para>
        /// </summary>
        public static void DrawTransformFeedbackInstanced(OpenGL.BeginMode mode, UInt32 id, Int32 primcount)
        {
            Delegates.glDrawTransformFeedbackInstanced(mode, id, primcount);
        }

        /// <summary>
        /// Render primitives using a count derived from a specifed stream of a transform feedback object.
        /// <para>
        /// glDrawTransformFeedbackStream draws primitives of a type specified by mode using
        /// a count retrieved from the transform feedback stream specified by stream of the
        /// transform feedback object specified by id. Calling glDrawTransformFeedbackStream
        /// is equivalent to calling glDrawArrays with mode as specified, first set to zero,
        /// and count set to the number of vertices captured on vertex stream stream the
        /// last time transform feedback was active on the transform feedback object named
        /// by id.
        /// </para>
        /// </summary>
        public static void DrawTransformFeedbackStream(OpenGL.NvTransformFeedback2 mode, UInt32 id, UInt32 stream)
        {
            Delegates.glDrawTransformFeedbackStream(mode, id, stream);
        }

        /// <summary>
        /// Render multiple instances of primitives using a count derived from a specifed stream of a transform feedback object.
        /// <para>
        /// glDrawTransformFeedbackStreamInstanced draws multiple copies of a range of
        /// primitives of a type specified by mode using a count retrieved from the
        /// transform feedback stream specified by stream of the transform feedback object
        /// specified by id. Calling glDrawTransformFeedbackStreamInstanced is equivalent to
        /// calling glDrawArraysInstanced with mode and primcount as specified, first set to
        /// zero, and count set to the number of vertices captured on vertex stream stream
        /// the last time transform feedback was active on the transform feedback object
        /// named by id.
        /// </para>
        /// </summary>
        public static void DrawTransformFeedbackStreamInstanced(OpenGL.BeginMode mode, UInt32 id, UInt32 stream, Int32 primcount)
        {
            Delegates.glDrawTransformFeedbackStreamInstanced(mode, id, stream, primcount);
        }

        /// <summary>
        /// Enable or disable server-side GL capabilities.
        /// <para>
        /// glEnable and glDisable enable and disable various capabilities. Use glIsEnabled
        /// or glGet to determine the current setting of any capability. The initial value
        /// for each capability with the exception of GL_DITHER and GL_MULTISAMPLE is
        /// GL_FALSE. The initial value for GL_DITHER and GL_MULTISAMPLE is GL_TRUE.
        /// </para>
        /// </summary>
        public static void Enable(OpenGL.EnableCap cap)
        {
            Delegates.glEnable(cap);
        }

        /// <summary>
        /// Enable or disable server-side GL capabilities.
        /// <para>
        /// glEnable and glDisable enable and disable various capabilities. Use glIsEnabled
        /// or glGet to determine the current setting of any capability. The initial value
        /// for each capability with the exception of GL_DITHER and GL_MULTISAMPLE is
        /// GL_FALSE. The initial value for GL_DITHER and GL_MULTISAMPLE is GL_TRUE.
        /// </para>
        /// </summary>
        public static void Disable(OpenGL.EnableCap cap)
        {
            Delegates.glDisable(cap);
        }

        /// <summary>
        /// Enable or disable server-side GL capabilities.
        /// <para>
        /// glEnable and glDisable enable and disable various capabilities. Use glIsEnabled
        /// or glGet to determine the current setting of any capability. The initial value
        /// for each capability with the exception of GL_DITHER and GL_MULTISAMPLE is
        /// GL_FALSE. The initial value for GL_DITHER and GL_MULTISAMPLE is GL_TRUE.
        /// </para>
        /// </summary>
        public static void Enablei(OpenGL.EnableCap cap, UInt32 index)
        {
            Delegates.glEnablei(cap, index);
        }

        /// <summary>
        /// Enable or disable server-side GL capabilities.
        /// <para>
        /// glEnable and glDisable enable and disable various capabilities. Use glIsEnabled
        /// or glGet to determine the current setting of any capability. The initial value
        /// for each capability with the exception of GL_DITHER and GL_MULTISAMPLE is
        /// GL_FALSE. The initial value for GL_DITHER and GL_MULTISAMPLE is GL_TRUE.
        /// </para>
        /// </summary>
        public static void Disablei(OpenGL.EnableCap cap, UInt32 index)
        {
            Delegates.glDisablei(cap, index);
        }

        /// <summary>
        /// Enable or disable a generic vertex attribute array.
        /// <para>
        /// glEnableVertexAttribArray and glEnableVertexArrayAttrib enable the generic
        /// vertex attribute array specified by index. glEnableVertexAttribArray uses
        /// currently bound vertex array object for the operation, whereas
        /// glEnableVertexArrayAttrib updates state of the vertex array object with ID
        /// vaobj.
        /// </para>
        /// </summary>
        public static void EnableVertexAttribArray(UInt32 index)
        {
            Delegates.glEnableVertexAttribArray(index);
        }

        /// <summary>
        /// Enable or disable a generic vertex attribute array.
        /// <para>
        /// glEnableVertexAttribArray and glEnableVertexArrayAttrib enable the generic
        /// vertex attribute array specified by index. glEnableVertexAttribArray uses
        /// currently bound vertex array object for the operation, whereas
        /// glEnableVertexArrayAttrib updates state of the vertex array object with ID
        /// vaobj.
        /// </para>
        /// </summary>
        public static void EnableVertexAttribArray(Int32 index)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glEnableVertexAttribArray((UInt32)index);
        }

        /// <summary>
        /// Enable or disable a generic vertex attribute array.
        /// <para>
        /// glEnableVertexAttribArray and glEnableVertexArrayAttrib enable the generic
        /// vertex attribute array specified by index. glEnableVertexAttribArray uses
        /// currently bound vertex array object for the operation, whereas
        /// glEnableVertexArrayAttrib updates state of the vertex array object with ID
        /// vaobj.
        /// </para>
        /// </summary>
        public static void DisableVertexAttribArray(UInt32 index)
        {
            Delegates.glDisableVertexAttribArray(index);
        }

        /// <summary>
        /// Enable or disable a generic vertex attribute array.
        /// <para>
        /// glEnableVertexAttribArray and glEnableVertexArrayAttrib enable the generic
        /// vertex attribute array specified by index. glEnableVertexAttribArray uses
        /// currently bound vertex array object for the operation, whereas
        /// glEnableVertexArrayAttrib updates state of the vertex array object with ID
        /// vaobj.
        /// </para>
        /// </summary>
        public static void DisableVertexAttribArray(Int32 index)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glDisableVertexAttribArray((UInt32)index);
        }

        /// <summary>
        /// Enable or disable a generic vertex attribute array.
        /// <para>
        /// glEnableVertexAttribArray and glEnableVertexArrayAttrib enable the generic
        /// vertex attribute array specified by index. glEnableVertexAttribArray uses
        /// currently bound vertex array object for the operation, whereas
        /// glEnableVertexArrayAttrib updates state of the vertex array object with ID
        /// vaobj.
        /// </para>
        /// </summary>
        public static void EnableVertexArrayAttrib(UInt32 vaobj, UInt32 index)
        {
            Delegates.glEnableVertexArrayAttrib(vaobj, index);
        }

        /// <summary>
        /// Enable or disable a generic vertex attribute array.
        /// <para>
        /// glEnableVertexAttribArray and glEnableVertexArrayAttrib enable the generic
        /// vertex attribute array specified by index. glEnableVertexAttribArray uses
        /// currently bound vertex array object for the operation, whereas
        /// glEnableVertexArrayAttrib updates state of the vertex array object with ID
        /// vaobj.
        /// </para>
        /// </summary>
        public static void EnableVertexArrayAttrib(UInt32 vaobj, Int32 index)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glEnableVertexArrayAttrib(vaobj, (UInt32)index);
        }

        /// <summary>
        /// Enable or disable a generic vertex attribute array.
        /// <para>
        /// glEnableVertexAttribArray and glEnableVertexArrayAttrib enable the generic
        /// vertex attribute array specified by index. glEnableVertexAttribArray uses
        /// currently bound vertex array object for the operation, whereas
        /// glEnableVertexArrayAttrib updates state of the vertex array object with ID
        /// vaobj.
        /// </para>
        /// </summary>
        public static void DisableVertexArrayAttrib(UInt32 vaobj, UInt32 index)
        {
            Delegates.glDisableVertexArrayAttrib(vaobj, index);
        }

        /// <summary>
        /// Enable or disable a generic vertex attribute array.
        /// <para>
        /// glEnableVertexAttribArray and glEnableVertexArrayAttrib enable the generic
        /// vertex attribute array specified by index. glEnableVertexAttribArray uses
        /// currently bound vertex array object for the operation, whereas
        /// glEnableVertexArrayAttrib updates state of the vertex array object with ID
        /// vaobj.
        /// </para>
        /// </summary>
        public static void DisableVertexArrayAttrib(UInt32 vaobj, Int32 index)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glDisableVertexArrayAttrib(vaobj, (UInt32)index);
        }

        /// <summary>
        /// Create a new sync object and insert it into the GL command stream.
        /// <para>
        /// glFenceSync creates a new fence sync object, inserts a fence command into the GL
        /// command stream and associates it with that sync object, and returns a non-zero
        /// name corresponding to the sync object.
        /// </para>
        /// </summary>
        public static IntPtr FenceSync(OpenGL.ArbSync condition, UInt32 flags)
        {
            return Delegates.glFenceSync(condition, flags);
        }

        /// <summary>
        /// Block until all GL execution is complete.
        /// <para>
        /// glFinish does not return until the effects of all previously called GL commands
        /// are complete. Such effects include all changes to GL state, all changes to
        /// connection state, and all changes to the frame buffer contents.
        /// </para>
        /// </summary>
        public static void Finish()
        {
            Delegates.glFinish();
        }

        /// <summary>
        /// Force execution of GL commands in finite time.
        /// <para>
        /// Different GL implementations buffer commands in several different locations,
        /// including network buffers and the graphics accelerator itself. glFlush empties
        /// all of these buffers, causing all issued commands to be executed as quickly as
        /// they are accepted by the actual rendering engine. Though this execution may not
        /// be completed in any particular time period, it does complete in finite time.
        /// </para>
        /// </summary>
        public static void Flush()
        {
            Delegates.glFlush();
        }

        /// <summary>
        /// Indicate modifications to a range of a mapped buffer.
        /// <para>
        /// glFlushMappedBufferRange indicates that modifications have been made to a range
        /// of a mapped buffer object. The buffer object must previously have been mapped
        /// with the GL_MAP_FLUSH_EXPLICIT_BIT flag.
        /// </para>
        /// </summary>
        public static void FlushMappedBufferRange(OpenGL.BufferTarget target, IntPtr offset, IntPtr length)
        {
            Delegates.glFlushMappedBufferRange(target, offset, length);
        }

        /// <summary>
        /// Indicate modifications to a range of a mapped buffer.
        /// <para>
        /// glFlushMappedBufferRange indicates that modifications have been made to a range
        /// of a mapped buffer object. The buffer object must previously have been mapped
        /// with the GL_MAP_FLUSH_EXPLICIT_BIT flag.
        /// </para>
        /// </summary>
        public static void FlushMappedNamedBufferRange(UInt32 buffer, IntPtr offset, Int32 length)
        {
            Delegates.glFlushMappedNamedBufferRange(buffer, offset, length);
        }

        /// <summary>
        /// Set a named parameter of a framebuffer object.
        /// <para>
        /// glFramebufferParameteri and glNamedFramebufferParameteri modify the value of the
        /// parameter named pname in the specified framebuffer object. There are no
        /// modifiable parameters of the default draw and read framebuffer, so they are not
        /// valid targets of these commands.
        /// </para>
        /// </summary>
        public static void FramebufferParameteri(OpenGL.FramebufferTarget target, OpenGL.FramebufferPName pname, Int32 param)
        {
            Delegates.glFramebufferParameteri(target, pname, param);
        }

        /// <summary>
        /// Set a named parameter of a framebuffer object.
        /// <para>
        /// glFramebufferParameteri and glNamedFramebufferParameteri modify the value of the
        /// parameter named pname in the specified framebuffer object. There are no
        /// modifiable parameters of the default draw and read framebuffer, so they are not
        /// valid targets of these commands.
        /// </para>
        /// </summary>
        public static void NamedFramebufferParameteri(UInt32 framebuffer, OpenGL.FramebufferPName pname, Int32 param)
        {
            Delegates.glNamedFramebufferParameteri(framebuffer, pname, param);
        }

        /// <summary>
        /// Attach a renderbuffer as a logical buffer of a framebuffer object.
        /// <para>
        /// glFramebufferRenderbuffer and glNamedFramebufferRenderbuffer attaches a
        /// renderbuffer as one of the logical buffers of the specified framebuffer object.
        /// Renderbuffers cannot be attached to the default draw and read framebuffer, so
        /// they are not valid targets of these commands.
        /// </para>
        /// </summary>
        public static void FramebufferRenderbuffer(OpenGL.FramebufferTarget target, OpenGL.FramebufferAttachment attachment, OpenGL.RenderbufferTarget renderbuffertarget, UInt32 renderbuffer)
        {
            Delegates.glFramebufferRenderbuffer(target, attachment, renderbuffertarget, renderbuffer);
        }

        /// <summary>
        /// Attach a renderbuffer as a logical buffer of a framebuffer object.
        /// <para>
        /// glFramebufferRenderbuffer and glNamedFramebufferRenderbuffer attaches a
        /// renderbuffer as one of the logical buffers of the specified framebuffer object.
        /// Renderbuffers cannot be attached to the default draw and read framebuffer, so
        /// they are not valid targets of these commands.
        /// </para>
        /// </summary>
        public static void NamedFramebufferRenderbuffer(UInt32 framebuffer, OpenGL.FramebufferAttachment attachment, OpenGL.RenderbufferTarget renderbuffertarget, UInt32 renderbuffer)
        {
            Delegates.glNamedFramebufferRenderbuffer(framebuffer, attachment, renderbuffertarget, renderbuffer);
        }

        /// <summary>
        /// Attach a level of a texture object as a logical buffer of a framebuffer object.
        /// <para>
        /// These commands attach a selected mipmap level or image of a texture object as
        /// one of the logical buffers of the specified framebuffer object. Textures cannot
        /// be attached to the default draw and read framebuffer, so they are not valid
        /// targets of these commands.
        /// </para>
        /// </summary>
        public static void FramebufferTexture(OpenGL.FramebufferTarget target, OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level)
        {
            Delegates.glFramebufferTexture(target, attachment, texture, level);
        }

        /// <summary>
        /// Attach a level of a texture object as a logical buffer of a framebuffer object.
        /// <para>
        /// These commands attach a selected mipmap level or image of a texture object as
        /// one of the logical buffers of the specified framebuffer object. Textures cannot
        /// be attached to the default draw and read framebuffer, so they are not valid
        /// targets of these commands.
        /// </para>
        /// </summary>
        public static void FramebufferTexture1D(OpenGL.FramebufferTarget target, OpenGL.FramebufferAttachment attachment, OpenGL.TextureTarget textarget, UInt32 texture, Int32 level)
        {
            Delegates.glFramebufferTexture1D(target, attachment, textarget, texture, level);
        }

        /// <summary>
        /// Attach a level of a texture object as a logical buffer of a framebuffer object.
        /// <para>
        /// These commands attach a selected mipmap level or image of a texture object as
        /// one of the logical buffers of the specified framebuffer object. Textures cannot
        /// be attached to the default draw and read framebuffer, so they are not valid
        /// targets of these commands.
        /// </para>
        /// </summary>
        public static void FramebufferTexture2D(OpenGL.FramebufferTarget target, OpenGL.FramebufferAttachment attachment, OpenGL.TextureTarget textarget, UInt32 texture, Int32 level)
        {
            Delegates.glFramebufferTexture2D(target, attachment, textarget, texture, level);
        }

        /// <summary>
        /// Attach a level of a texture object as a logical buffer of a framebuffer object.
        /// <para>
        /// These commands attach a selected mipmap level or image of a texture object as
        /// one of the logical buffers of the specified framebuffer object. Textures cannot
        /// be attached to the default draw and read framebuffer, so they are not valid
        /// targets of these commands.
        /// </para>
        /// </summary>
        public static void FramebufferTexture3D(OpenGL.FramebufferTarget target, OpenGL.FramebufferAttachment attachment, OpenGL.TextureTarget textarget, UInt32 texture, Int32 level, Int32 layer)
        {
            Delegates.glFramebufferTexture3D(target, attachment, textarget, texture, level, layer);
        }

        /// <summary>
        /// Attach a level of a texture object as a logical buffer of a framebuffer object.
        /// <para>
        /// These commands attach a selected mipmap level or image of a texture object as
        /// one of the logical buffers of the specified framebuffer object. Textures cannot
        /// be attached to the default draw and read framebuffer, so they are not valid
        /// targets of these commands.
        /// </para>
        /// </summary>
        public static void NamedFramebufferTexture(UInt32 framebuffer, OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level)
        {
            Delegates.glNamedFramebufferTexture(framebuffer, attachment, texture, level);
        }

        /// <summary>
        /// Attach a single layer of a texture object as a logical buffer of a framebuffer object.
        /// <para>
        /// glFramebufferTextureLayer and glNamedFramebufferTextureLayer attach a single
        /// layer of a three-dimensional or array texture object as one of the logical
        /// buffers of the specified framebuffer object. Textures cannot be attached to the
        /// default draw and read framebuffer, so they are not valid targets of these
        /// commands.
        /// </para>
        /// </summary>
        public static void FramebufferTextureLayer(OpenGL.FramebufferTarget target, OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level, Int32 layer)
        {
            Delegates.glFramebufferTextureLayer(target, attachment, texture, level, layer);
        }

        /// <summary>
        /// Attach a single layer of a texture object as a logical buffer of a framebuffer object.
        /// <para>
        /// glFramebufferTextureLayer and glNamedFramebufferTextureLayer attach a single
        /// layer of a three-dimensional or array texture object as one of the logical
        /// buffers of the specified framebuffer object. Textures cannot be attached to the
        /// default draw and read framebuffer, so they are not valid targets of these
        /// commands.
        /// </para>
        /// </summary>
        public static void NamedFramebufferTextureLayer(UInt32 framebuffer, OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level, Int32 layer)
        {
            Delegates.glNamedFramebufferTextureLayer(framebuffer, attachment, texture, level, layer);
        }

        /// <summary>
        /// Define front- and back-facing polygons.
        /// <para>
        /// In a scene composed entirely of opaque closed surfaces, back-facing polygons are
        /// never visible. Eliminating these invisible polygons has the obvious benefit of
        /// speeding up the rendering of the image. To enable and disable elimination of
        /// back-facing polygons, call glEnable and glDisable with argument GL_CULL_FACE.
        /// </para>
        /// </summary>
        public static void FrontFace(OpenGL.FrontFaceDirection mode)
        {
            Delegates.glFrontFace(mode);
        }

        /// <summary>
        /// Generate buffer object names.
        /// <para>
        /// glGenBuffers returns n buffer object names in buffers. There is no guarantee
        /// that the names form a contiguous set of integers; however, it is guaranteed that
        /// none of the returned names was in use immediately before the call to
        /// glGenBuffers.
        /// </para>
        /// </summary>
        public static void GenBuffers(Int32 n, [OutAttribute] UInt32[] buffers)
        {
            Delegates.glGenBuffers(n, buffers);
        }

        /// <summary>
        /// Generate mipmaps for a specified texture object.
        /// <para>
        /// glGenerateMipmap and glGenerateTextureMipmap generates mipmaps for the specified
        /// texture object. For glGenerateMipmap, the texture object is that bound to to
        /// target. For glGenerateTextureMipmap, texture is the name of the texture object.
        /// </para>
        /// </summary>
        public static void GenerateMipmap(OpenGL.GenerateMipmapTarget target)
        {
            Delegates.glGenerateMipmap(target);
        }

        /// <summary>
        /// Generate mipmaps for a specified texture object.
        /// <para>
        /// glGenerateMipmap and glGenerateTextureMipmap generates mipmaps for the specified
        /// texture object. For glGenerateMipmap, the texture object is that bound to to
        /// target. For glGenerateTextureMipmap, texture is the name of the texture object.
        /// </para>
        /// </summary>
        public static void GenerateTextureMipmap(UInt32 texture)
        {
            Delegates.glGenerateTextureMipmap(texture);
        }

        /// <summary>
        /// Generate framebuffer object names.
        /// <para>
        /// glGenFramebuffers returns n framebuffer object names in ids. There is no
        /// guarantee that the names form a contiguous set of integers; however, it is
        /// guaranteed that none of the returned names was in use immediately before the
        /// call to glGenFramebuffers.
        /// </para>
        /// </summary>
        public static void GenFramebuffers(Int32 n, [OutAttribute] UInt32[] ids)
        {
            Delegates.glGenFramebuffers(n, ids);
        }

        /// <summary>
        /// Reserve program pipeline object names.
        /// <para>
        /// glGenProgramPipelines returns n previously unused program pipeline object names
        /// in pipelines. These names are marked as used, for the purposes of
        /// glGenProgramPipelines only, but they acquire program pipeline state only when
        /// they are first bound.
        /// </para>
        /// </summary>
        public static void GenProgramPipelines(Int32 n, [OutAttribute] UInt32[] pipelines)
        {
            Delegates.glGenProgramPipelines(n, pipelines);
        }

        /// <summary>
        /// Generate query object names.
        /// <para>
        /// glGenQueries returns n query object names in ids. There is no guarantee that the
        /// names form a contiguous set of integers; however, it is guaranteed that none of
        /// the returned names was in use immediately before the call to glGenQueries.
        /// </para>
        /// </summary>
        public static void GenQueries(Int32 n, [OutAttribute] UInt32[] ids)
        {
            Delegates.glGenQueries(n, ids);
        }

        /// <summary>
        /// Generate renderbuffer object names.
        /// <para>
        /// glGenRenderbuffers returns n renderbuffer object names in renderbuffers. There
        /// is no guarantee that the names form a contiguous set of integers; however, it is
        /// guaranteed that none of the returned names was in use immediately before the
        /// call to glGenRenderbuffers.
        /// </para>
        /// </summary>
        public static void GenRenderbuffers(Int32 n, [OutAttribute] UInt32[] renderbuffers)
        {
            Delegates.glGenRenderbuffers(n, renderbuffers);
        }

        /// <summary>
        /// Generate sampler object names.
        /// <para>
        /// glGenSamplers returns n sampler object names in samplers. There is no guarantee
        /// that the names form a contiguous set of integers; however, it is guaranteed that
        /// none of the returned names was in use immediately before the call to
        /// glGenSamplers.
        /// </para>
        /// </summary>
        public static void GenSamplers(Int32 n, [OutAttribute] UInt32[] samplers)
        {
            Delegates.glGenSamplers(n, samplers);
        }

        /// <summary>
        /// Generate texture names.
        /// <para>
        /// glGenTextures returns n texture names in textures. There is no guarantee that
        /// the names form a contiguous set of integers; however, it is guaranteed that none
        /// of the returned names was in use immediately before the call to glGenTextures.
        /// </para>
        /// </summary>
        public static void GenTextures(Int32 n, [OutAttribute] UInt32[] textures)
        {
            Delegates.glGenTextures(n, textures);
        }

        /// <summary>
        /// Reserve transform feedback object names.
        /// <para>
        /// glGenTransformFeedbacks returns n previously unused transform feedback object
        /// names in ids. These names are marked as used, for the purposes of
        /// glGenTransformFeedbacks only, but they acquire transform feedback state only
        /// when they are first bound.
        /// </para>
        /// </summary>
        public static void GenTransformFeedbacks(Int32 n, [OutAttribute] UInt32[] ids)
        {
            Delegates.glGenTransformFeedbacks(n, ids);
        }

        /// <summary>
        /// Generate vertex array object names.
        /// <para>
        /// glGenVertexArrays returns n vertex array object names in arrays. There is no
        /// guarantee that the names form a contiguous set of integers; however, it is
        /// guaranteed that none of the returned names was in use immediately before the
        /// call to glGenVertexArrays.
        /// </para>
        /// </summary>
        public static void GenVertexArrays(Int32 n, [OutAttribute] UInt32[] arrays)
        {
            Delegates.glGenVertexArrays(n, arrays);
        }

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// <para>
        /// These commands return values for simple state variables in GL. pname is a
        /// symbolic constant indicating the state variable to be returned, and data is a
        /// pointer to an array of the indicated type in which to place the returned data.
        /// </para>
        /// </summary>
        public static void GetBooleanv(OpenGL.GetPName pname, [OutAttribute] Boolean[] data)
        {
            Delegates.glGetBooleanv(pname, data);
        }

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// <para>
        /// These commands return values for simple state variables in GL. pname is a
        /// symbolic constant indicating the state variable to be returned, and data is a
        /// pointer to an array of the indicated type in which to place the returned data.
        /// </para>
        /// </summary>
        public static void GetDoublev(OpenGL.GetPName pname, [OutAttribute] Double[] data)
        {
            Delegates.glGetDoublev(pname, data);
        }

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// <para>
        /// These commands return values for simple state variables in GL. pname is a
        /// symbolic constant indicating the state variable to be returned, and data is a
        /// pointer to an array of the indicated type in which to place the returned data.
        /// </para>
        /// </summary>
        public static void GetFloatv(OpenGL.GetPName pname, [OutAttribute] Single[] data)
        {
            Delegates.glGetFloatv(pname, data);
        }

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// <para>
        /// These commands return values for simple state variables in GL. pname is a
        /// symbolic constant indicating the state variable to be returned, and data is a
        /// pointer to an array of the indicated type in which to place the returned data.
        /// </para>
        /// </summary>
        public static void GetIntegerv(OpenGL.GetPName pname, [OutAttribute] Int32[] data)
        {
            Delegates.glGetIntegerv(pname, data);
        }

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// <para>
        /// These commands return values for simple state variables in GL. pname is a
        /// symbolic constant indicating the state variable to be returned, and data is a
        /// pointer to an array of the indicated type in which to place the returned data.
        /// </para>
        /// </summary>
        public static void GetInteger64v(OpenGL.ArbSync pname, [OutAttribute] Int64[] data)
        {
            Delegates.glGetInteger64v(pname, data);
        }

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// <para>
        /// These commands return values for simple state variables in GL. pname is a
        /// symbolic constant indicating the state variable to be returned, and data is a
        /// pointer to an array of the indicated type in which to place the returned data.
        /// </para>
        /// </summary>
        public static void GetBooleani_v(OpenGL.GetPName target, UInt32 index, [OutAttribute] Boolean[] data)
        {
            Delegates.glGetBooleani_v(target, index, data);
        }

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// <para>
        /// These commands return values for simple state variables in GL. pname is a
        /// symbolic constant indicating the state variable to be returned, and data is a
        /// pointer to an array of the indicated type in which to place the returned data.
        /// </para>
        /// </summary>
        public static void GetIntegeri_v(OpenGL.GetPName target, UInt32 index, [OutAttribute] Int32[] data)
        {
            Delegates.glGetIntegeri_v(target, index, data);
        }

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// <para>
        /// These commands return values for simple state variables in GL. pname is a
        /// symbolic constant indicating the state variable to be returned, and data is a
        /// pointer to an array of the indicated type in which to place the returned data.
        /// </para>
        /// </summary>
        public static void GetFloati_v(OpenGL.GetPName target, UInt32 index, [OutAttribute] Single[] data)
        {
            Delegates.glGetFloati_v(target, index, data);
        }

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// <para>
        /// These commands return values for simple state variables in GL. pname is a
        /// symbolic constant indicating the state variable to be returned, and data is a
        /// pointer to an array of the indicated type in which to place the returned data.
        /// </para>
        /// </summary>
        public static void GetDoublei_v(OpenGL.GetPName target, UInt32 index, [OutAttribute] Double[] data)
        {
            Delegates.glGetDoublei_v(target, index, data);
        }

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// <para>
        /// These commands return values for simple state variables in GL. pname is a
        /// symbolic constant indicating the state variable to be returned, and data is a
        /// pointer to an array of the indicated type in which to place the returned data.
        /// </para>
        /// </summary>
        public static void GetInteger64i_v(OpenGL.GetPName target, UInt32 index, [OutAttribute] Int64[] data)
        {
            Delegates.glGetInteger64i_v(target, index, data);
        }

        /// <summary>
        /// Retrieve information about the set of active atomic counter buffers for a program.
        /// <para>
        /// glGetActiveAtomicCounterBufferiv retrieves information about the set of active
        /// atomic counter buffers for a program object. program is the name of a program
        /// object for which the command glLinkProgram has been issued in the past. It is
        /// not necessary for program to have been linked successfully. The link may have
        /// failed because the number of active atomic counters exceeded the limits.
        /// </para>
        /// </summary>
        public static void GetActiveAtomicCounterBufferiv(UInt32 program, UInt32 bufferIndex, OpenGL.AtomicCounterParameterName pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetActiveAtomicCounterBufferiv(program, bufferIndex, pname, @params);
        }

        /// <summary>
        /// Returns information about an active attribute variable for the specified program object.
        /// <para>
        /// glGetActiveAttrib returns information about an active attribute variable in the
        /// program object specified by program. The number of active attributes can be
        /// obtained by calling glGetProgram with the value GL_ACTIVE_ATTRIBUTES. A value of
        /// 0 for index selects the first active attribute variable. Permissible values for
        /// index range from zero to the number of active attribute variables minus one.
        /// </para>
        /// </summary>
        public static void GetActiveAttrib(UInt32 program, UInt32 index, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] Int32[] size, [OutAttribute] OpenGL.ActiveAttribType[] type, [OutAttribute] System.Text.StringBuilder name)
        {
            Delegates.glGetActiveAttrib(program, index, bufSize, length, size, type, name);
        }

        /// <summary>
        /// Returns information about an active attribute variable for the specified program object.
        /// <para>
        /// glGetActiveAttrib returns information about an active attribute variable in the
        /// program object specified by program. The number of active attributes can be
        /// obtained by calling glGetProgram with the value GL_ACTIVE_ATTRIBUTES. A value of
        /// 0 for index selects the first active attribute variable. Permissible values for
        /// index range from zero to the number of active attribute variables minus one.
        /// </para>
        /// </summary>
        public static void GetActiveAttrib(UInt32 program, Int32 index, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] Int32[] size, [OutAttribute] OpenGL.ActiveAttribType[] type, [OutAttribute] System.Text.StringBuilder name)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glGetActiveAttrib(program, (UInt32)index, bufSize, length, size, type, name);
        }

        /// <summary>
        /// Query the name of an active shader subroutine.
        /// <para>
        /// glGetActiveSubroutineName queries the name of an active shader subroutine
        /// uniform from the program object given in program. index specifies the index of
        /// the shader subroutine uniform within the shader stage given by stage, and must
        /// between zero and the value of GL_ACTIVE_SUBROUTINES minus one for the shader
        /// stage.
        /// </para>
        /// </summary>
        public static void GetActiveSubroutineName(UInt32 program, OpenGL.ShaderType shadertype, UInt32 index, Int32 bufsize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder name)
        {
            Delegates.glGetActiveSubroutineName(program, shadertype, index, bufsize, length, name);
        }

        /// <summary>
        /// Query a property of an active shader subroutine uniform.
        /// <para>
        /// glGetActiveSubroutineUniform queries a parameter of an active shader subroutine
        /// uniform. program contains the name of the program containing the uniform.
        /// shadertype specifies the stage which which the uniform location, given by index,
        /// is valid. index must be between zero and the value of
        /// GL_ACTIVE_SUBROUTINE_UNIFORMS minus one for the shader stage.
        /// </para>
        /// </summary>
        public static void GetActiveSubroutineUniformiv(UInt32 program, OpenGL.ShaderType shadertype, UInt32 index, OpenGL.SubroutineParameterName pname, [OutAttribute] Int32[] values)
        {
            Delegates.glGetActiveSubroutineUniformiv(program, shadertype, index, pname, values);
        }

        /// <summary>
        /// Query a property of an active shader subroutine uniform.
        /// <para>
        /// glGetActiveSubroutineUniform queries a parameter of an active shader subroutine
        /// uniform. program contains the name of the program containing the uniform.
        /// shadertype specifies the stage which which the uniform location, given by index,
        /// is valid. index must be between zero and the value of
        /// GL_ACTIVE_SUBROUTINE_UNIFORMS minus one for the shader stage.
        /// </para>
        /// </summary>
        public static void GetActiveSubroutineUniformiv(UInt32 program, OpenGL.ShaderType shadertype, Int32 index, OpenGL.SubroutineParameterName pname, [OutAttribute] Int32[] values)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glGetActiveSubroutineUniformiv(program, shadertype, (UInt32)index, pname, values);
        }

        /// <summary>
        /// Query the name of an active shader subroutine uniform.
        /// <para>
        /// glGetActiveSubroutineUniformName retrieves the name of an active shader
        /// subroutine uniform. program contains the name of the program containing the
        /// uniform. shadertype specifies the stage for which which the uniform location,
        /// given by index, is valid. index must be between zero and the value of
        /// GL_ACTIVE_SUBROUTINE_UNIFORMS minus one for the shader stage.
        /// </para>
        /// </summary>
        public static void GetActiveSubroutineUniformName(UInt32 program, OpenGL.ShaderType shadertype, UInt32 index, Int32 bufsize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder name)
        {
            Delegates.glGetActiveSubroutineUniformName(program, shadertype, index, bufsize, length, name);
        }

        /// <summary>
        /// Query the name of an active shader subroutine uniform.
        /// <para>
        /// glGetActiveSubroutineUniformName retrieves the name of an active shader
        /// subroutine uniform. program contains the name of the program containing the
        /// uniform. shadertype specifies the stage for which which the uniform location,
        /// given by index, is valid. index must be between zero and the value of
        /// GL_ACTIVE_SUBROUTINE_UNIFORMS minus one for the shader stage.
        /// </para>
        /// </summary>
        public static void GetActiveSubroutineUniformName(UInt32 program, OpenGL.ShaderType shadertype, Int32 index, Int32 bufsize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder name)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glGetActiveSubroutineUniformName(program, shadertype, (UInt32)index, bufsize, length, name);
        }

        /// <summary>
        /// Returns information about an active uniform variable for the specified program object.
        /// <para>
        /// glGetActiveUniform returns information about an active uniform variable in the
        /// program object specified by program. The number of active uniform variables can
        /// be obtained by calling glGetProgram with the value GL_ACTIVE_UNIFORMS. A value
        /// of 0 for index selects the first active uniform variable. Permissible values for
        /// index range from zero to the number of active uniform variables minus one.
        /// </para>
        /// </summary>
        public static void GetActiveUniform(UInt32 program, UInt32 index, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] Int32[] size, [OutAttribute] OpenGL.ActiveUniformType[] type, [OutAttribute] System.Text.StringBuilder name)
        {
            Delegates.glGetActiveUniform(program, index, bufSize, length, size, type, name);
        }

        /// <summary>
        /// Returns information about an active uniform variable for the specified program object.
        /// <para>
        /// glGetActiveUniform returns information about an active uniform variable in the
        /// program object specified by program. The number of active uniform variables can
        /// be obtained by calling glGetProgram with the value GL_ACTIVE_UNIFORMS. A value
        /// of 0 for index selects the first active uniform variable. Permissible values for
        /// index range from zero to the number of active uniform variables minus one.
        /// </para>
        /// </summary>
        public static void GetActiveUniform(UInt32 program, Int32 index, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] Int32[] size, [OutAttribute] OpenGL.ActiveUniformType[] type, [OutAttribute] System.Text.StringBuilder name)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glGetActiveUniform(program, (UInt32)index, bufSize, length, size, type, name);
        }

        /// <summary>
        /// Query information about an active uniform block.
        /// <para>
        /// glGetActiveUniformBlockiv retrieves information about an active uniform block
        /// within program.
        /// </para>
        /// </summary>
        public static void GetActiveUniformBlockiv(UInt32 program, UInt32 uniformBlockIndex, OpenGL.ActiveUniformBlockParameter pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetActiveUniformBlockiv(program, uniformBlockIndex, pname, @params);
        }

        /// <summary>
        /// Retrieve the name of an active uniform block.
        /// <para>
        /// glGetActiveUniformBlockName retrieves the name of the active uniform block at
        /// uniformBlockIndex within program.
        /// </para>
        /// </summary>
        public static void GetActiveUniformBlockName(UInt32 program, UInt32 uniformBlockIndex, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder uniformBlockName)
        {
            Delegates.glGetActiveUniformBlockName(program, uniformBlockIndex, bufSize, length, uniformBlockName);
        }

        /// <summary>
        /// Query the name of an active uniform.
        /// <para>
        /// glGetActiveUniformName returns the name of the active uniform at uniformIndex
        /// within program. If uniformName is not NULL, up to bufSize characters (including
        /// a nul-terminator) will be written into the array whose address is specified by
        /// uniformName. If length is not NULL, the number of characters that were (or would
        /// have been) written into uniformName (not including the nul-terminator) will be
        /// placed in the variable whose address is specified in length. If length is NULL,
        /// no length is returned. The length of the longest uniform name in program is
        /// given by the value of GL_ACTIVE_UNIFORM_MAX_LENGTH, which can be queried with
        /// glGetProgram.
        /// </para>
        /// </summary>
        public static void GetActiveUniformName(UInt32 program, UInt32 uniformIndex, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder uniformName)
        {
            Delegates.glGetActiveUniformName(program, uniformIndex, bufSize, length, uniformName);
        }

        /// <summary>
        /// Returns information about several active uniform variables for the specified program object.
        /// <para>
        /// glGetActiveUniformsiv queries the value of the parameter named pname for each of
        /// the uniforms within program whose indices are specified in the array of
        /// uniformCount unsigned integers uniformIndices. Upon success, the value of the
        /// parameter for each uniform is written into the corresponding entry in the array
        /// whose address is given in params. If an error is generated, nothing is written
        /// into params.
        /// </para>
        /// </summary>
        public static void GetActiveUniformsiv(UInt32 program, Int32 uniformCount, [OutAttribute] UInt32[] uniformIndices, OpenGL.ActiveUniformType pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetActiveUniformsiv(program, uniformCount, uniformIndices, pname, @params);
        }

        /// <summary>
        /// Returns the handles of the shader objects attached to a program object.
        /// <para>
        /// glGetAttachedShaders returns the names of the shader objects attached to
        /// program. The names of shader objects that are attached to program will be
        /// returned in shaders. The actual number of shader names written into shaders is
        /// returned in count. If no shader objects are attached to program, count is set to
        /// 0. The maximum number of shader names that may be returned in shaders is
        /// specified by maxCount.
        /// </para>
        /// </summary>
        public static void GetAttachedShaders(UInt32 program, Int32 maxCount, [OutAttribute] Int32[] count, [OutAttribute] UInt32[] shaders)
        {
            Delegates.glGetAttachedShaders(program, maxCount, count, shaders);
        }

        /// <summary>
        /// Returns the location of an attribute variable.
        /// <para>
        /// glGetAttribLocation queries the previously linked program object specified by
        /// program for the attribute variable specified by name and returns the index of
        /// the generic vertex attribute that is bound to that attribute variable. If name
        /// is a matrix attribute variable, the index of the first column of the matrix is
        /// returned. If the named attribute variable is not an active attribute in the
        /// specified program object or if name starts with the reserved prefix "gl_", a
        /// value of -1 is returned.
        /// </para>
        /// </summary>
        public static Int32 GetAttribLocation(UInt32 program, String name)
        {
            return Delegates.glGetAttribLocation(program, name);
        }

        /// <summary>
        /// Return parameters of a buffer object.
        /// <para>
        /// These functions return in data a selected parameter of the specified buffer
        /// object.
        /// </para>
        /// </summary>
        public static void GetBufferParameteriv(OpenGL.BufferTarget target, OpenGL.BufferParameterName value, [OutAttribute] Int32[] data)
        {
            Delegates.glGetBufferParameteriv(target, value, data);
        }

        /// <summary>
        /// Return parameters of a buffer object.
        /// <para>
        /// These functions return in data a selected parameter of the specified buffer
        /// object.
        /// </para>
        /// </summary>
        public static void GetBufferParameteri64v(OpenGL.BufferTarget target, OpenGL.BufferParameterName value, [OutAttribute] Int64[] data)
        {
            Delegates.glGetBufferParameteri64v(target, value, data);
        }

        /// <summary>
        /// Return parameters of a buffer object.
        /// <para>
        /// These functions return in data a selected parameter of the specified buffer
        /// object.
        /// </para>
        /// </summary>
        public static void GetNamedBufferParameteriv(UInt32 buffer, OpenGL.BufferParameterName pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetNamedBufferParameteriv(buffer, pname, @params);
        }

        /// <summary>
        /// Return parameters of a buffer object.
        /// <para>
        /// These functions return in data a selected parameter of the specified buffer
        /// object.
        /// </para>
        /// </summary>
        public static void GetNamedBufferParameteri64v(UInt32 buffer, OpenGL.BufferParameterName pname, [OutAttribute] Int64[] @params)
        {
            Delegates.glGetNamedBufferParameteri64v(buffer, pname, @params);
        }

        /// <summary>
        /// Return the pointer to a mapped buffer object's data store.
        /// <para>
        /// glGetBufferPointerv and glGetNamedBufferPointerv return the buffer pointer
        /// pname, which must be GL_BUFFER_MAP_POINTER. The single buffer map pointer is
        /// returned in params. A NULL pointer is returned if the buffer object's data store
        /// is not currently mapped; or if the requesting context did not map the buffer
        /// object's data store, and the implementation is unable to support mappings on
        /// multiple clients.
        /// </para>
        /// </summary>
        public static void GetBufferPointerv(OpenGL.BufferTarget target, OpenGL.BufferPointer pname, [OutAttribute] IntPtr @params)
        {
            Delegates.glGetBufferPointerv(target, pname, @params);
        }

        /// <summary>
        /// Return the pointer to a mapped buffer object's data store.
        /// <para>
        /// glGetBufferPointerv and glGetNamedBufferPointerv return the buffer pointer
        /// pname, which must be GL_BUFFER_MAP_POINTER. The single buffer map pointer is
        /// returned in params. A NULL pointer is returned if the buffer object's data store
        /// is not currently mapped; or if the requesting context did not map the buffer
        /// object's data store, and the implementation is unable to support mappings on
        /// multiple clients.
        /// </para>
        /// </summary>
        public static void GetNamedBufferPointerv(UInt32 buffer, OpenGL.BufferPointer pname, [OutAttribute] IntPtr @params)
        {
            Delegates.glGetNamedBufferPointerv(buffer, pname, @params);
        }

        /// <summary>
        /// Returns a subset of a buffer object's data store.
        /// <para>
        /// glGetBufferSubData and glGetNamedBufferSubData return some or all of the data
        /// contents of the data store of the specified buffer object. Data starting at byte
        /// offset offset and extending for size bytes is copied from the buffer object's
        /// data store to the memory pointed to by data. An error is thrown if the buffer
        /// object is currently mapped, or if offset and size together define a range beyond
        /// the bounds of the buffer object's data store.
        /// </para>
        /// </summary>
        public static void GetBufferSubData(OpenGL.BufferTarget target, IntPtr offset, IntPtr size, [OutAttribute] IntPtr data)
        {
            Delegates.glGetBufferSubData(target, offset, size, data);
        }

        /// <summary>
        /// Returns a subset of a buffer object's data store.
        /// <para>
        /// glGetBufferSubData and glGetNamedBufferSubData return some or all of the data
        /// contents of the data store of the specified buffer object. Data starting at byte
        /// offset offset and extending for size bytes is copied from the buffer object's
        /// data store to the memory pointed to by data. An error is thrown if the buffer
        /// object is currently mapped, or if offset and size together define a range beyond
        /// the bounds of the buffer object's data store.
        /// </para>
        /// </summary>
        public static void GetNamedBufferSubData(UInt32 buffer, IntPtr offset, Int32 size, [OutAttribute] IntPtr data)
        {
            Delegates.glGetNamedBufferSubData(buffer, offset, size, data);
        }

        /// <summary>
        /// Return a compressed texture image.
        /// <para>
        /// glGetCompressedTexImage and glGetnCompressedTexImage return the compressed
        /// texture image associated with target and lod into pixels.
        /// glGetCompressedTextureImage serves the same purpose, but instead of taking a
        /// texture target, it takes the ID of the texture object. pixels should be an array
        /// of bufSize bytes for glGetnCompresedTexImage and glGetCompressedTextureImage
        /// functions, and of GL_TEXTURE_COMPRESSED_IMAGE_SIZE bytes in case of
        /// glGetCompressedTexImage. If the actual data takes less space than bufSize, the
        /// remaining bytes will not be touched. target specifies the texture target, to
        /// which the texture the data the function should extract the data from is bound
        /// to. lod specifies the level-of-detail number of the desired image.
        /// </para>
        /// </summary>
        public static void GetCompressedTexImage(OpenGL.TextureTarget target, Int32 level, [OutAttribute] IntPtr pixels)
        {
            Delegates.glGetCompressedTexImage(target, level, pixels);
        }

        /// <summary>
        /// Return a compressed texture image.
        /// <para>
        /// glGetCompressedTexImage and glGetnCompressedTexImage return the compressed
        /// texture image associated with target and lod into pixels.
        /// glGetCompressedTextureImage serves the same purpose, but instead of taking a
        /// texture target, it takes the ID of the texture object. pixels should be an array
        /// of bufSize bytes for glGetnCompresedTexImage and glGetCompressedTextureImage
        /// functions, and of GL_TEXTURE_COMPRESSED_IMAGE_SIZE bytes in case of
        /// glGetCompressedTexImage. If the actual data takes less space than bufSize, the
        /// remaining bytes will not be touched. target specifies the texture target, to
        /// which the texture the data the function should extract the data from is bound
        /// to. lod specifies the level-of-detail number of the desired image.
        /// </para>
        /// </summary>
        public static void GetnCompressedTexImage(OpenGL.TextureTarget target, Int32 level, Int32 bufSize, [OutAttribute] IntPtr pixels)
        {
            Delegates.glGetnCompressedTexImage(target, level, bufSize, pixels);
        }

        /// <summary>
        /// Return a compressed texture image.
        /// <para>
        /// glGetCompressedTexImage and glGetnCompressedTexImage return the compressed
        /// texture image associated with target and lod into pixels.
        /// glGetCompressedTextureImage serves the same purpose, but instead of taking a
        /// texture target, it takes the ID of the texture object. pixels should be an array
        /// of bufSize bytes for glGetnCompresedTexImage and glGetCompressedTextureImage
        /// functions, and of GL_TEXTURE_COMPRESSED_IMAGE_SIZE bytes in case of
        /// glGetCompressedTexImage. If the actual data takes less space than bufSize, the
        /// remaining bytes will not be touched. target specifies the texture target, to
        /// which the texture the data the function should extract the data from is bound
        /// to. lod specifies the level-of-detail number of the desired image.
        /// </para>
        /// </summary>
        public static void GetCompressedTextureImage(UInt32 texture, Int32 level, Int32 bufSize, [OutAttribute] IntPtr pixels)
        {
            Delegates.glGetCompressedTextureImage(texture, level, bufSize, pixels);
        }

        /// <summary>
        /// Retrieve a sub-region of a compressed texture image from a compressed texture object.
        /// <para>
        /// glGetCompressedTextureSubImage can be used to obtain a sub-region of a
        /// compressed texture image instead of the whole image, as long as the compressed
        /// data are arranged into fixed-size blocks of texels. texture is the name of the
        /// texture object, and must not be a buffer or multisample texture. The effective
        /// target is the value of GL_TEXTURE_TARGET for texture. level and pixels have the
        /// same meaning as the corresponding arguments of glCompressedTexSubImage3D.
        /// bufSize indicates the size of the buffer to receive the retrieved pixel data.
        /// </para>
        /// </summary>
        public static void GetCompressedTextureSubImage(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, Int32 bufSize, [OutAttribute] IntPtr pixels)
        {
            Delegates.glGetCompressedTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, bufSize, pixels);
        }

        /// <summary>
        /// Return error information.
        /// <para>
        /// glGetError returns the value of the error flag. Each detectable error is
        /// assigned a numeric code and symbolic name. When an error occurs, the error flag
        /// is set to the appropriate error code value. No other errors are recorded until
        /// glGetError is called, the error code is returned, and the flag is reset to
        /// GL_NO_ERROR. If a call to glGetError returns GL_NO_ERROR, there has been no
        /// detectable error since the last call to glGetError, or since the GL was
        /// initialized.
        /// </para>
        /// </summary>
        public static OpenGL.ErrorCode GetError()
        {
            return Delegates.glGetError();
        }

        /// <summary>
        /// Query the bindings of color indices to user-defined varying out variables.
        /// <para>
        /// glGetFragDataIndex returns the index of the fragment color to which the variable
        /// name was bound when the program object program was last linked. If name is not a
        /// varying out variable of program, or if an error occurs, -1 will be returned.
        /// </para>
        /// </summary>
        public static Int32 GetFragDataIndex(UInt32 program, String name)
        {
            return Delegates.glGetFragDataIndex(program, name);
        }

        /// <summary>
        /// Query the bindings of color numbers to user-defined varying out variables.
        /// <para>
        /// glGetFragDataLocation retrieves the assigned color number binding for the
        /// user-defined varying out variable name for program program. program must have
        /// previously been linked. name must be a null-terminated string. If name is not
        /// the name of an active user-defined varying out fragment shader variable within
        /// program, -1 will be returned.
        /// </para>
        /// </summary>
        public static Int32 GetFragDataLocation(UInt32 program, String name)
        {
            return Delegates.glGetFragDataLocation(program, name);
        }

        /// <summary>
        /// Retrieve information about attachments of a framebuffer object.
        /// <para>
        /// glGetFramebufferAttachmentParameteriv and
        /// glGetNamedFramebufferAttachmentParameteriv return parameters of attachments of a
        /// specified framebuffer object.
        /// </para>
        /// </summary>
        public static void GetFramebufferAttachmentParameteriv(OpenGL.FramebufferTarget target, OpenGL.FramebufferAttachment attachment, OpenGL.FramebufferParameterName pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetFramebufferAttachmentParameteriv(target, attachment, pname, @params);
        }

        /// <summary>
        /// Retrieve information about attachments of a framebuffer object.
        /// <para>
        /// glGetFramebufferAttachmentParameteriv and
        /// glGetNamedFramebufferAttachmentParameteriv return parameters of attachments of a
        /// specified framebuffer object.
        /// </para>
        /// </summary>
        public static void GetNamedFramebufferAttachmentParameteriv(UInt32 framebuffer, OpenGL.FramebufferAttachment attachment, OpenGL.FramebufferParameterName pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetNamedFramebufferAttachmentParameteriv(framebuffer, attachment, pname, @params);
        }

        /// <summary>
        /// Query a named parameter of a framebuffer object.
        /// <para>
        /// glGetFramebufferParameteriv and glGetNamedFramebufferParameteriv query
        /// parameters of a specified framebuffer object.
        /// </para>
        /// </summary>
        public static void GetFramebufferParameteriv(OpenGL.FramebufferTarget target, OpenGL.FramebufferPName pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetFramebufferParameteriv(target, pname, @params);
        }

        /// <summary>
        /// Query a named parameter of a framebuffer object.
        /// <para>
        /// glGetFramebufferParameteriv and glGetNamedFramebufferParameteriv query
        /// parameters of a specified framebuffer object.
        /// </para>
        /// </summary>
        public static void GetNamedFramebufferParameteriv(UInt32 framebuffer, OpenGL.FramebufferPName pname, [OutAttribute] Int32[] param)
        {
            Delegates.glGetNamedFramebufferParameteriv(framebuffer, pname, param);
        }

        /// <summary>
        /// Check if the rendering context has not been lost due to software or hardware issues.
        /// <para>
        /// Certain events can result in a reset of the GL context. Such a reset causes all
        /// context state to be lost and requires the application to recreate all objects in
        /// the affected context.
        /// </para>
        /// </summary>
        public static OpenGL.GraphicResetStatus GetGraphicsResetStatus()
        {
            return Delegates.glGetGraphicsResetStatus();
        }

        /// <summary>
        /// Retrieve information about implementation-dependent support for internal formats.
        /// <para>
        /// glGetInternalformativ and glGetInternalformati64v retrieve information about
        /// implementation-dependent support for internal formats. target indicates the
        /// target with which the internal format will be used and must be one of
        /// GL_RENDERBUFFER, GL_TEXTURE_2D_MULTISAMPLE, or GL_TEXTURE_2D_MULTISAMPLE_ARRAY,
        /// corresponding to usage as a renderbuffer, two-dimensional multisample texture or
        /// two-dimensional multisample array texture, respectively.
        /// </para>
        /// </summary>
        public static void GetInternalformativ(OpenGL.TextureTarget target, OpenGL.PixelInternalFormat internalFormat, OpenGL.GetPName pname, Int32 bufSize, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetInternalformativ(target, internalFormat, pname, bufSize, @params);
        }

        /// <summary>
        /// Retrieve information about implementation-dependent support for internal formats.
        /// <para>
        /// glGetInternalformativ and glGetInternalformati64v retrieve information about
        /// implementation-dependent support for internal formats. target indicates the
        /// target with which the internal format will be used and must be one of
        /// GL_RENDERBUFFER, GL_TEXTURE_2D_MULTISAMPLE, or GL_TEXTURE_2D_MULTISAMPLE_ARRAY,
        /// corresponding to usage as a renderbuffer, two-dimensional multisample texture or
        /// two-dimensional multisample array texture, respectively.
        /// </para>
        /// </summary>
        public static void GetInternalformati64v(OpenGL.TextureTarget target, OpenGL.PixelInternalFormat internalFormat, OpenGL.GetPName pname, Int32 bufSize, [OutAttribute] Int64[] @params)
        {
            Delegates.glGetInternalformati64v(target, internalFormat, pname, bufSize, @params);
        }

        /// <summary>
        /// Retrieve the location of a sample.
        /// <para>
        /// glGetMultisamplefv queries the location of a given sample. pname specifies the
        /// sample parameter to retrieve and must be GL_SAMPLE_POSITION. index corresponds
        /// to the sample for which the location should be returned. The sample location is
        /// returned as two floating-point values in val[0] and val[1], each between 0 and
        /// 1, corresponding to the x and y locations respectively in the GL pixel space of
        /// that sample. (0.5, 0.5) this corresponds to the pixel center. index must be
        /// between zero and the value of GL_SAMPLES minus one.
        /// </para>
        /// </summary>
        public static void GetMultisamplefv(OpenGL.GetMultisamplePName pname, UInt32 index, [OutAttribute] Single[] val)
        {
            Delegates.glGetMultisamplefv(pname, index, val);
        }

        /// <summary>
        /// Retrieve the label of a named object identified within a namespace.
        /// <para>
        /// glGetObjectLabel retrieves the label of the object identified by name within the
        /// namespace given by identifier. identifier must be one of GL_BUFFER, GL_SHADER,
        /// GL_PROGRAM, GL_VERTEX_ARRAY, GL_QUERY, GL_PROGRAM_PIPELINE,
        /// GL_TRANSFORM_FEEDBACK, GL_SAMPLER, GL_TEXTURE, GL_RENDERBUFFER, GL_FRAMEBUFFER,
        /// to indicate the namespace containing the names of buffers, shaders, programs,
        /// vertex array objects, query objects, program pipelines, transform feedback
        /// objects, samplers, textures, renderbuffers and frame buffers, respectively.
        /// </para>
        /// </summary>
        public static void GetObjectLabel(OpenGL.ObjectLabel identifier, UInt32 name, Int32 bifSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder label)
        {
            Delegates.glGetObjectLabel(identifier, name, bifSize, length, label);
        }

        /// <summary>
        /// Retrieve the label of a sync object identified by a pointer.
        /// <para>
        /// glGetObjectPtrLabel retrieves the label of the sync object identified by ptr.
        /// </para>
        /// </summary>
        public static void GetObjectPtrLabel([OutAttribute] IntPtr ptr, Int32 bifSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder label)
        {
            Delegates.glGetObjectPtrLabel(ptr, bifSize, length, label);
        }

        /// <summary>
        /// Return the address of the specified pointer.
        /// <para>
        /// glGetPointerv returns pointer information. pname indicates the pointer to be
        /// returned, and params is a pointer to a location in which to place the returned
        /// data. The parameters that may be queried include:.
        /// </para>
        /// </summary>
        public static void GetPointerv(OpenGL.GetPointerParameter pname, [OutAttribute] IntPtr @params)
        {
            Delegates.glGetPointerv(pname, @params);
        }

        /// <summary>
        /// Returns a parameter from a program object.
        /// <para>
        /// glGetProgram returns in params the value of a parameter for a specific program
        /// object. The following parameters are defined:.
        /// </para>
        /// </summary>
        public static void GetProgramiv(UInt32 program, OpenGL.ProgramParameter pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetProgramiv(program, pname, @params);
        }

        /// <summary>
        /// Return a binary representation of a program object's compiled and linked executable source.
        /// <para>
        /// glGetProgramBinary returns a binary representation of the compiled and linked
        /// executable for program into the array of bytes whose address is specified in
        /// binary. The maximum number of bytes that may be written into binary is specified
        /// by bufSize. If the program binary is greater in size than bufSize bytes, then an
        /// error is generated, otherwise the actual number of bytes written into binary is
        /// returned in the variable whose address is given by length. If length is NULL,
        /// then no length is returned.
        /// </para>
        /// </summary>
        public static void GetProgramBinary(UInt32 program, Int32 bufsize, [OutAttribute] Int32[] length, [OutAttribute] Int32[] binaryFormat, [OutAttribute] IntPtr binary)
        {
            Delegates.glGetProgramBinary(program, bufsize, length, binaryFormat, binary);
        }

        /// <summary>
        /// Returns the information log for a program object.
        /// <para>
        /// glGetProgramInfoLog returns the information log for the specified program
        /// object. The information log for a program object is modified when the program
        /// object is linked or validated. The string that is returned will be null
        /// terminated.
        /// </para>
        /// </summary>
        public static void GetProgramInfoLog(UInt32 program, Int32 maxLength, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder infoLog)
        {
            Delegates.glGetProgramInfoLog(program, maxLength, length, infoLog);
        }

        /// <summary>
        /// Query a property of an interface in a program.
        /// <para>
        /// glGetProgramInterfaceiv queries the property of the interface identifed by
        /// programInterface in program, the property name of which is given by pname.
        /// </para>
        /// </summary>
        public static void GetProgramInterfaceiv(UInt32 program, OpenGL.ProgramInterface programInterface, OpenGL.ProgramInterfaceParameterName pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetProgramInterfaceiv(program, programInterface, pname, @params);
        }

        /// <summary>
        /// Retrieve properties of a program pipeline object.
        /// <para>
        /// glGetProgramPipelineiv retrieves the value of a property of the program pipeline
        /// object pipeline. pname specifies the name of the parameter whose value to
        /// retrieve. The value of the parameter is written to the variable whose address is
        /// given by params.
        /// </para>
        /// </summary>
        public static void GetProgramPipelineiv(UInt32 pipeline, Int32 pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetProgramPipelineiv(pipeline, pname, @params);
        }

        /// <summary>
        /// Retrieve the info log string from a program pipeline object.
        /// <para>
        /// glGetProgramPipelineInfoLog retrieves the info log for the program pipeline
        /// object pipeline. The info log, including its null terminator, is written into
        /// the array of characters whose address is given by infoLog. The maximum number of
        /// characters that may be written into infoLog is given by bufSize, and the actual
        /// number of characters written into infoLog is returned in the integer whose
        /// address is given by length. If length is NULL, no length is returned.
        /// </para>
        /// </summary>
        public static void GetProgramPipelineInfoLog(UInt32 pipeline, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder infoLog)
        {
            Delegates.glGetProgramPipelineInfoLog(pipeline, bufSize, length, infoLog);
        }

        /// <summary>
        /// Retrieve values for multiple properties of a single active resource within a program object.
        /// <para>
        /// glGetProgramResourceiv returns values for multiple properties of a single active
        /// resource with an index of index in the interface programInterface of program
        /// object program. For each resource, values for propCount properties specified by
        /// the array props are returned. propCount may not be zero. An error is generated
        /// if any value in props is not one of the properties described immediately belowor
        /// if any value in props is not allowed for programInterface. The set of allowed
        /// programInterface values for each property can be found in the following table:.
        /// </para>
        /// </summary>
        public static void GetProgramResourceiv(UInt32 program, OpenGL.ProgramInterface programInterface, UInt32 index, Int32 propCount, [OutAttribute] OpenGL.ProgramResourceParameterName[] props, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetProgramResourceiv(program, programInterface, index, propCount, props, bufSize, length, @params);
        }

        /// <summary>
        /// Query the index of a named resource within a program.
        /// <para>
        /// glGetProgramResourceIndex returns the unsigned integer index assigned to a
        /// resource named name in the interface type programInterface of program object
        /// program.
        /// </para>
        /// </summary>
        public static UInt32 GetProgramResourceIndex(UInt32 program, OpenGL.ProgramInterface programInterface, String name)
        {
            return Delegates.glGetProgramResourceIndex(program, programInterface, name);
        }

        /// <summary>
        /// Query the location of a named resource within a program.
        /// <para>
        /// glGetProgramResourceLocation returns the location assigned to the variable named
        /// name in interface programInterface of program object program. program must be
        /// the name of a program that has been linked successfully. programInterface must
        /// be one of GL_UNIFORM, GL_PROGRAM_INPUT, GL_PROGRAM_OUTPUT,
        /// GL_VERTEX_SUBROUTINE_UNIFORM, GL_TESS_CONTROL_SUBROUTINE_UNIFORM,
        /// GL_TESS_EVALUATION_SUBROUTINE_UNIFORM, GL_GEOMETRY_SUBROUTINE_UNIFORM,
        /// GL_FRAGMENT_SUBROUTINE_UNIFORM, GL_COMPUTE_SUBROUTINE_UNIFORM, or
        /// GL_TRANSFORM_FEEDBACK_BUFFER.
        /// </para>
        /// </summary>
        public static Int32 GetProgramResourceLocation(UInt32 program, OpenGL.ProgramInterface programInterface, String name)
        {
            return Delegates.glGetProgramResourceLocation(program, programInterface, name);
        }

        /// <summary>
        /// Query the fragment color index of a named variable within a program.
        /// <para>
        /// glGetProgramResourceLocationIndex returns the fragment color index assigned to
        /// the variable named name in interface programInterface of program object program.
        /// program must be the name of a program that has been linked successfully.
        /// programInterface must be GL_PROGRAM_OUTPUT.
        /// </para>
        /// </summary>
        public static Int32 GetProgramResourceLocationIndex(UInt32 program, OpenGL.ProgramInterface programInterface, String name)
        {
            return Delegates.glGetProgramResourceLocationIndex(program, programInterface, name);
        }

        /// <summary>
        /// Query the name of an indexed resource within a program.
        /// <para>
        /// glGetProgramResourceName retrieves the name string assigned to the single active
        /// resource with an index of index in the interface programInterface of program
        /// object program. index must be less than the number of entries in the active
        /// resource list for programInterface.
        /// </para>
        /// </summary>
        public static void GetProgramResourceName(UInt32 program, OpenGL.ProgramInterface programInterface, UInt32 index, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder name)
        {
            Delegates.glGetProgramResourceName(program, programInterface, index, bufSize, length, name);
        }

        /// <summary>
        /// Retrieve properties of a program object corresponding to a specified shader stage.
        /// <para>
        /// glGetProgramStage queries a parameter of a shader stage attached to a program
        /// object. program contains the name of the program to which the shader is
        /// attached. shadertype specifies the stage from which to query the parameter.
        /// pname specifies which parameter should be queried. The value or values of the
        /// parameter to be queried is returned in the variable whose address is given in
        /// values.
        /// </para>
        /// </summary>
        public static void GetProgramStageiv(UInt32 program, OpenGL.ShaderType shadertype, OpenGL.ProgramStageParameterName pname, [OutAttribute] Int32[] values)
        {
            Delegates.glGetProgramStageiv(program, shadertype, pname, values);
        }

        /// <summary>
        /// Return parameters of an indexed query object target.
        /// <para>
        /// glGetQueryIndexediv returns in params a selected parameter of the indexed query
        /// object target specified by target and index. index specifies the index of the
        /// query object target and must be between zero and a target-specific maxiumum.
        /// </para>
        /// </summary>
        public static void GetQueryIndexediv(OpenGL.QueryTarget target, UInt32 index, OpenGL.GetQueryParam pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetQueryIndexediv(target, index, pname, @params);
        }

        /// <summary>
        /// Return parameters of a query object target.
        /// <para>
        /// glGetQueryiv returns in params a selected parameter of the query object target
        /// specified by target.
        /// </para>
        /// </summary>
        public static void GetQueryiv(OpenGL.QueryTarget target, OpenGL.GetQueryParam pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetQueryiv(target, pname, @params);
        }

        /// <summary>
        /// Return parameters of a query object.
        /// <para>
        /// glGetQueryObject returns in params a selected parameter of the query object
        /// specified by id.
        /// </para>
        /// </summary>
        public static void GetQueryObjectiv(UInt32 id, OpenGL.GetQueryObjectParam pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetQueryObjectiv(id, pname, @params);
        }

        /// <summary>
        /// Return parameters of a query object.
        /// <para>
        /// glGetQueryObject returns in params a selected parameter of the query object
        /// specified by id.
        /// </para>
        /// </summary>
        public static void GetQueryObjectuiv(UInt32 id, OpenGL.GetQueryObjectParam pname, [OutAttribute] UInt32[] @params)
        {
            Delegates.glGetQueryObjectuiv(id, pname, @params);
        }

        /// <summary>
        /// Return parameters of a query object.
        /// <para>
        /// glGetQueryObject returns in params a selected parameter of the query object
        /// specified by id.
        /// </para>
        /// </summary>
        public static void GetQueryObjecti64v(UInt32 id, OpenGL.GetQueryObjectParam pname, [OutAttribute] Int64[] @params)
        {
            Delegates.glGetQueryObjecti64v(id, pname, @params);
        }

        /// <summary>
        /// Return parameters of a query object.
        /// <para>
        /// glGetQueryObject returns in params a selected parameter of the query object
        /// specified by id.
        /// </para>
        /// </summary>
        public static void GetQueryObjectui64v(UInt32 id, OpenGL.GetQueryObjectParam pname, [OutAttribute] UInt64[] @params)
        {
            Delegates.glGetQueryObjectui64v(id, pname, @params);
        }

        /// <summary>
        /// Query a named parameter of a renderbuffer object.
        /// <para>
        /// glGetRenderbufferParameteriv and glGetNamedRenderbufferParameteriv query
        /// parameters of a specified renderbuffer object.
        /// </para>
        /// </summary>
        public static void GetRenderbufferParameteriv(OpenGL.RenderbufferTarget target, OpenGL.RenderbufferParameterName pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetRenderbufferParameteriv(target, pname, @params);
        }

        /// <summary>
        /// Query a named parameter of a renderbuffer object.
        /// <para>
        /// glGetRenderbufferParameteriv and glGetNamedRenderbufferParameteriv query
        /// parameters of a specified renderbuffer object.
        /// </para>
        /// </summary>
        public static void GetNamedRenderbufferParameteriv(UInt32 renderbuffer, OpenGL.RenderbufferParameterName pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetNamedRenderbufferParameteriv(renderbuffer, pname, @params);
        }

        /// <summary>
        /// Return sampler parameter values.
        /// <para>
        /// glGetSamplerParameter returns in params the value or values of the sampler
        /// parameter specified as pname. sampler defines the target sampler, and must be
        /// the name of an existing sampler object, returned from a previous call to
        /// glGenSamplers. pname accepts the same symbols as glSamplerParameter, with the
        /// same interpretations:.
        /// </para>
        /// </summary>
        public static void GetSamplerParameterfv(UInt32 sampler, Int32 pname, [OutAttribute] Single[] @params)
        {
            Delegates.glGetSamplerParameterfv(sampler, pname, @params);
        }

        /// <summary>
        /// Return sampler parameter values.
        /// <para>
        /// glGetSamplerParameter returns in params the value or values of the sampler
        /// parameter specified as pname. sampler defines the target sampler, and must be
        /// the name of an existing sampler object, returned from a previous call to
        /// glGenSamplers. pname accepts the same symbols as glSamplerParameter, with the
        /// same interpretations:.
        /// </para>
        /// </summary>
        public static void GetSamplerParameteriv(UInt32 sampler, Int32 pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetSamplerParameteriv(sampler, pname, @params);
        }

        /// <summary>
        /// Return sampler parameter values.
        /// <para>
        /// glGetSamplerParameter returns in params the value or values of the sampler
        /// parameter specified as pname. sampler defines the target sampler, and must be
        /// the name of an existing sampler object, returned from a previous call to
        /// glGenSamplers. pname accepts the same symbols as glSamplerParameter, with the
        /// same interpretations:.
        /// </para>
        /// </summary>
        public static void GetSamplerParameterIiv(UInt32 sampler, OpenGL.TextureParameterName pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetSamplerParameterIiv(sampler, pname, @params);
        }

        /// <summary>
        /// Return sampler parameter values.
        /// <para>
        /// glGetSamplerParameter returns in params the value or values of the sampler
        /// parameter specified as pname. sampler defines the target sampler, and must be
        /// the name of an existing sampler object, returned from a previous call to
        /// glGenSamplers. pname accepts the same symbols as glSamplerParameter, with the
        /// same interpretations:.
        /// </para>
        /// </summary>
        public static void GetSamplerParameterIuiv(UInt32 sampler, OpenGL.TextureParameterName pname, [OutAttribute] UInt32[] @params)
        {
            Delegates.glGetSamplerParameterIuiv(sampler, pname, @params);
        }

        /// <summary>
        /// Returns a parameter from a shader object.
        /// <para>
        /// glGetShader returns in params the value of a parameter for a specific shader
        /// object. The following parameters are defined:.
        /// </para>
        /// </summary>
        public static void GetShaderiv(UInt32 shader, OpenGL.ShaderParameter pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetShaderiv(shader, pname, @params);
        }

        /// <summary>
        /// Returns the information log for a shader object.
        /// <para>
        /// glGetShaderInfoLog returns the information log for the specified shader object.
        /// The information log for a shader object is modified when the shader is compiled.
        /// The string that is returned will be null terminated.
        /// </para>
        /// </summary>
        public static void GetShaderInfoLog(UInt32 shader, Int32 maxLength, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder infoLog)
        {
            Delegates.glGetShaderInfoLog(shader, maxLength, length, infoLog);
        }

        /// <summary>
        /// Retrieve the range and precision for numeric formats supported by the shader compiler.
        /// <para>
        /// glGetShaderPrecisionFormat retrieves the numeric range and precision for the
        /// implementation's representation of quantities in different numeric formats in
        /// specified shader type. shaderType specifies the type of shader for which the
        /// numeric precision and range is to be retrieved and must be one of
        /// GL_VERTEX_SHADER or GL_FRAGMENT_SHADER. precisionType specifies the numeric
        /// format to query and must be one of GL_LOW_FLOAT, GL_MEDIUM_FLOAT GL_HIGH_FLOAT,
        /// GL_LOW_INT, GL_MEDIUM_INT, or GL_HIGH_INT.
        /// </para>
        /// </summary>
        public static void GetShaderPrecisionFormat(OpenGL.ShaderType shaderType, Int32 precisionType, [OutAttribute] Int32[] range, [OutAttribute] Int32[] precision)
        {
            Delegates.glGetShaderPrecisionFormat(shaderType, precisionType, range, precision);
        }

        /// <summary>
        /// Returns the source code string from a shader object.
        /// <para>
        /// glGetShaderSource returns the concatenation of the source code strings from the
        /// shader object specified by shader. The source code strings for a shader object
        /// are the result of a previous call to glShaderSource. The string returned by the
        /// function will be null terminated.
        /// </para>
        /// </summary>
        public static void GetShaderSource(UInt32 shader, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder source)
        {
            Delegates.glGetShaderSource(shader, bufSize, length, source);
        }

        /// <summary>
        /// Return a string describing the current GL connection.
        /// <para>
        /// glGetString returns a pointer to a static string describing some aspect of the
        /// current GL connection. name can be one of the following:.
        /// </para>
        /// </summary>
        public static String GetString(OpenGL.StringName name)
        {
            return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(Delegates.glGetString(name));
        }

        /// <summary>
        /// Return a string describing the current GL connection.
        /// <para>
        /// glGetString returns a pointer to a static string describing some aspect of the
        /// current GL connection. name can be one of the following:.
        /// </para>
        /// </summary>
        public static String GetStringi(OpenGL.StringName name, UInt32 index)
        {
            return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(Delegates.glGetStringi(name, index));
        }

        /// <summary>
        /// Retrieve the index of a subroutine uniform of a given shader stage within a program.
        /// <para>
        /// glGetSubroutineIndex returns the index of a subroutine uniform within a shader
        /// stage attached to a program object. program contains the name of the program to
        /// which the shader is attached. shadertype specifies the stage from which to query
        /// shader subroutine index. name contains the null-terminated name of the
        /// subroutine uniform whose name to query.
        /// </para>
        /// </summary>
        public static UInt32 GetSubroutineIndex(UInt32 program, OpenGL.ShaderType shadertype, String name)
        {
            return Delegates.glGetSubroutineIndex(program, shadertype, name);
        }

        /// <summary>
        /// Retrieve the location of a subroutine uniform of a given shader stage within a program.
        /// <para>
        /// glGetSubroutineUniformLocation returns the location of the subroutine uniform
        /// variable name in the shader stage of type shadertype attached to program, with
        /// behavior otherwise identical to glGetUniformLocation.
        /// </para>
        /// </summary>
        public static Int32 GetSubroutineUniformLocation(UInt32 program, OpenGL.ShaderType shadertype, String name)
        {
            return Delegates.glGetSubroutineUniformLocation(program, shadertype, name);
        }

        /// <summary>
        /// Query the properties of a sync object.
        /// <para>
        /// glGetSynciv retrieves properties of a sync object. sync specifies the name of
        /// the sync object whose properties to retrieve.
        /// </para>
        /// </summary>
        public static void GetSynciv(IntPtr sync, OpenGL.ArbSync pname, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] Int32[] values)
        {
            Delegates.glGetSynciv(sync, pname, bufSize, length, values);
        }

        /// <summary>
        /// Return a texture image.
        /// <para>
        /// glGetTexImage, glGetnTexImage and glGetTextureImage functions return a texture
        /// image into pixels. For glGetTexImage and glGetnTexImage, target specifies
        /// whether the desired texture image is one specified by glTexImage1D
        /// (GL_TEXTURE_1D), glTexImage2D (GL_TEXTURE_1D_ARRAY, GL_TEXTURE_RECTANGLE,
        /// GL_TEXTURE_2D or any of GL_TEXTURE_CUBE_MAP_*), or glTexImage3D
        /// (GL_TEXTURE_2D_ARRAY, GL_TEXTURE_3D, GL_TEXTURE_CUBE_MAP_ARRAY). For
        /// glGetTextureImage, texture specifies the texture object name. In addition to
        /// types of textures accepted by glGetTexImage and glGetnTexImage, the function
        /// also accepts cube map texture objects (with effective target
        /// GL_TEXTURE_CUBE_MAP). level specifies the level-of-detail number of the desired
        /// image. format and type specify the format and type of the desired image array.
        /// See the reference page for glTexImage1D for a description of the acceptable
        /// values for the format and type parameters, respectively. For glGetnTexImage and
        /// glGetTextureImage functions, bufSize tells the size of the buffer to receive the
        /// retrieved pixel data. glGetnTexImage and glGetTextureImage do not write more
        /// than bufSize bytes into pixels.
        /// </para>
        /// </summary>
        public static void GetTexImage(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelFormat format, OpenGL.PixelType type, [OutAttribute] IntPtr pixels)
        {
            Delegates.glGetTexImage(target, level, format, type, pixels);
        }

        /// <summary>
        /// Return a texture image.
        /// <para>
        /// glGetTexImage, glGetnTexImage and glGetTextureImage functions return a texture
        /// image into pixels. For glGetTexImage and glGetnTexImage, target specifies
        /// whether the desired texture image is one specified by glTexImage1D
        /// (GL_TEXTURE_1D), glTexImage2D (GL_TEXTURE_1D_ARRAY, GL_TEXTURE_RECTANGLE,
        /// GL_TEXTURE_2D or any of GL_TEXTURE_CUBE_MAP_*), or glTexImage3D
        /// (GL_TEXTURE_2D_ARRAY, GL_TEXTURE_3D, GL_TEXTURE_CUBE_MAP_ARRAY). For
        /// glGetTextureImage, texture specifies the texture object name. In addition to
        /// types of textures accepted by glGetTexImage and glGetnTexImage, the function
        /// also accepts cube map texture objects (with effective target
        /// GL_TEXTURE_CUBE_MAP). level specifies the level-of-detail number of the desired
        /// image. format and type specify the format and type of the desired image array.
        /// See the reference page for glTexImage1D for a description of the acceptable
        /// values for the format and type parameters, respectively. For glGetnTexImage and
        /// glGetTextureImage functions, bufSize tells the size of the buffer to receive the
        /// retrieved pixel data. glGetnTexImage and glGetTextureImage do not write more
        /// than bufSize bytes into pixels.
        /// </para>
        /// </summary>
        public static void GetnTexImage(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelFormat format, OpenGL.PixelType type, Int32 bufSize, [OutAttribute] IntPtr pixels)
        {
            Delegates.glGetnTexImage(target, level, format, type, bufSize, pixels);
        }

        /// <summary>
        /// Return a texture image.
        /// <para>
        /// glGetTexImage, glGetnTexImage and glGetTextureImage functions return a texture
        /// image into pixels. For glGetTexImage and glGetnTexImage, target specifies
        /// whether the desired texture image is one specified by glTexImage1D
        /// (GL_TEXTURE_1D), glTexImage2D (GL_TEXTURE_1D_ARRAY, GL_TEXTURE_RECTANGLE,
        /// GL_TEXTURE_2D or any of GL_TEXTURE_CUBE_MAP_*), or glTexImage3D
        /// (GL_TEXTURE_2D_ARRAY, GL_TEXTURE_3D, GL_TEXTURE_CUBE_MAP_ARRAY). For
        /// glGetTextureImage, texture specifies the texture object name. In addition to
        /// types of textures accepted by glGetTexImage and glGetnTexImage, the function
        /// also accepts cube map texture objects (with effective target
        /// GL_TEXTURE_CUBE_MAP). level specifies the level-of-detail number of the desired
        /// image. format and type specify the format and type of the desired image array.
        /// See the reference page for glTexImage1D for a description of the acceptable
        /// values for the format and type parameters, respectively. For glGetnTexImage and
        /// glGetTextureImage functions, bufSize tells the size of the buffer to receive the
        /// retrieved pixel data. glGetnTexImage and glGetTextureImage do not write more
        /// than bufSize bytes into pixels.
        /// </para>
        /// </summary>
        public static void GetTextureImage(UInt32 texture, Int32 level, OpenGL.PixelFormat format, OpenGL.PixelType type, Int32 bufSize, [OutAttribute] IntPtr pixels)
        {
            Delegates.glGetTextureImage(texture, level, format, type, bufSize, pixels);
        }

        /// <summary>
        /// Return texture parameter values for a specific level of detail.
        /// <para>
        /// glGetTexLevelParameterfv, glGetTexLevelParameteriv, glGetTextureLevelParameterfv
        /// and glGetTextureLevelParameteriv return in params texture parameter values for a
        /// specific level-of-detail value, specified as level. For the first two functions,
        /// target defines the target texture, either GL_TEXTURE_1D, GL_TEXTURE_2D,
        /// GL_TEXTURE_3D, GL_PROXY_TEXTURE_1D, GL_PROXY_TEXTURE_2D, GL_PROXY_TEXTURE_3D,
        /// GL_TEXTURE_CUBE_MAP_POSITIVE_X, GL_TEXTURE_CUBE_MAP_NEGATIVE_X,
        /// GL_TEXTURE_CUBE_MAP_POSITIVE_Y, GL_TEXTURE_CUBE_MAP_NEGATIVE_Y,
        /// GL_TEXTURE_CUBE_MAP_POSITIVE_Z, GL_TEXTURE_CUBE_MAP_NEGATIVE_Z, or
        /// GL_PROXY_TEXTURE_CUBE_MAP. The remaining two take a texture argument which
        /// specifies the name of the texture object.
        /// </para>
        /// </summary>
        public static void GetTexLevelParameterfv(OpenGL.GetPName target, Int32 level, OpenGL.GetTextureLevelParameter pname, [OutAttribute] Single[] @params)
        {
            Delegates.glGetTexLevelParameterfv(target, level, pname, @params);
        }

        /// <summary>
        /// Return texture parameter values for a specific level of detail.
        /// <para>
        /// glGetTexLevelParameterfv, glGetTexLevelParameteriv, glGetTextureLevelParameterfv
        /// and glGetTextureLevelParameteriv return in params texture parameter values for a
        /// specific level-of-detail value, specified as level. For the first two functions,
        /// target defines the target texture, either GL_TEXTURE_1D, GL_TEXTURE_2D,
        /// GL_TEXTURE_3D, GL_PROXY_TEXTURE_1D, GL_PROXY_TEXTURE_2D, GL_PROXY_TEXTURE_3D,
        /// GL_TEXTURE_CUBE_MAP_POSITIVE_X, GL_TEXTURE_CUBE_MAP_NEGATIVE_X,
        /// GL_TEXTURE_CUBE_MAP_POSITIVE_Y, GL_TEXTURE_CUBE_MAP_NEGATIVE_Y,
        /// GL_TEXTURE_CUBE_MAP_POSITIVE_Z, GL_TEXTURE_CUBE_MAP_NEGATIVE_Z, or
        /// GL_PROXY_TEXTURE_CUBE_MAP. The remaining two take a texture argument which
        /// specifies the name of the texture object.
        /// </para>
        /// </summary>
        public static void GetTexLevelParameteriv(OpenGL.GetPName target, Int32 level, OpenGL.GetTextureLevelParameter pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetTexLevelParameteriv(target, level, pname, @params);
        }

        /// <summary>
        /// Return texture parameter values for a specific level of detail.
        /// <para>
        /// glGetTexLevelParameterfv, glGetTexLevelParameteriv, glGetTextureLevelParameterfv
        /// and glGetTextureLevelParameteriv return in params texture parameter values for a
        /// specific level-of-detail value, specified as level. For the first two functions,
        /// target defines the target texture, either GL_TEXTURE_1D, GL_TEXTURE_2D,
        /// GL_TEXTURE_3D, GL_PROXY_TEXTURE_1D, GL_PROXY_TEXTURE_2D, GL_PROXY_TEXTURE_3D,
        /// GL_TEXTURE_CUBE_MAP_POSITIVE_X, GL_TEXTURE_CUBE_MAP_NEGATIVE_X,
        /// GL_TEXTURE_CUBE_MAP_POSITIVE_Y, GL_TEXTURE_CUBE_MAP_NEGATIVE_Y,
        /// GL_TEXTURE_CUBE_MAP_POSITIVE_Z, GL_TEXTURE_CUBE_MAP_NEGATIVE_Z, or
        /// GL_PROXY_TEXTURE_CUBE_MAP. The remaining two take a texture argument which
        /// specifies the name of the texture object.
        /// </para>
        /// </summary>
        public static void GetTextureLevelParameterfv(UInt32 texture, Int32 level, OpenGL.GetTextureLevelParameter pname, [OutAttribute] Single[] @params)
        {
            Delegates.glGetTextureLevelParameterfv(texture, level, pname, @params);
        }

        /// <summary>
        /// Return texture parameter values for a specific level of detail.
        /// <para>
        /// glGetTexLevelParameterfv, glGetTexLevelParameteriv, glGetTextureLevelParameterfv
        /// and glGetTextureLevelParameteriv return in params texture parameter values for a
        /// specific level-of-detail value, specified as level. For the first two functions,
        /// target defines the target texture, either GL_TEXTURE_1D, GL_TEXTURE_2D,
        /// GL_TEXTURE_3D, GL_PROXY_TEXTURE_1D, GL_PROXY_TEXTURE_2D, GL_PROXY_TEXTURE_3D,
        /// GL_TEXTURE_CUBE_MAP_POSITIVE_X, GL_TEXTURE_CUBE_MAP_NEGATIVE_X,
        /// GL_TEXTURE_CUBE_MAP_POSITIVE_Y, GL_TEXTURE_CUBE_MAP_NEGATIVE_Y,
        /// GL_TEXTURE_CUBE_MAP_POSITIVE_Z, GL_TEXTURE_CUBE_MAP_NEGATIVE_Z, or
        /// GL_PROXY_TEXTURE_CUBE_MAP. The remaining two take a texture argument which
        /// specifies the name of the texture object.
        /// </para>
        /// </summary>
        public static void GetTextureLevelParameteriv(UInt32 texture, Int32 level, OpenGL.GetTextureLevelParameter pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetTextureLevelParameteriv(texture, level, pname, @params);
        }

        /// <summary>
        /// Return texture parameter values.
        /// <para>
        /// glGetTexParameter and glGetTextureParameter return in params the value or values
        /// of the texture parameter specified as pname. target defines the target texture.
        /// GL_TEXTURE_1D, GL_TEXTURE_2D, GL_TEXTURE_3D, GL_TEXTURE_1D_ARRAY,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_RECTANGLE, GL_TEXTURE_CUBE_MAP,
        /// GL_TEXTURE_CUBE_MAP_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, or
        /// GL_TEXTURE_2D_MULTISAMPLE_ARRAY specify one-, two-, or three-dimensional,
        /// one-dimensional array, two-dimensional array, rectangle, cube-mapped or
        /// cube-mapped array, two-dimensional multisample, or two-dimensional multisample
        /// array texturing, respectively. pname accepts the same symbols as glTexParameter,
        /// with the same interpretations:.
        /// </para>
        /// </summary>
        public static void GetTexParameterfv(OpenGL.TextureTarget target, OpenGL.GetTextureParameter pname, [OutAttribute] Single[] @params)
        {
            Delegates.glGetTexParameterfv(target, pname, @params);
        }

        /// <summary>
        /// Return texture parameter values.
        /// <para>
        /// glGetTexParameter and glGetTextureParameter return in params the value or values
        /// of the texture parameter specified as pname. target defines the target texture.
        /// GL_TEXTURE_1D, GL_TEXTURE_2D, GL_TEXTURE_3D, GL_TEXTURE_1D_ARRAY,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_RECTANGLE, GL_TEXTURE_CUBE_MAP,
        /// GL_TEXTURE_CUBE_MAP_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, or
        /// GL_TEXTURE_2D_MULTISAMPLE_ARRAY specify one-, two-, or three-dimensional,
        /// one-dimensional array, two-dimensional array, rectangle, cube-mapped or
        /// cube-mapped array, two-dimensional multisample, or two-dimensional multisample
        /// array texturing, respectively. pname accepts the same symbols as glTexParameter,
        /// with the same interpretations:.
        /// </para>
        /// </summary>
        public static void GetTexParameteriv(OpenGL.TextureTarget target, OpenGL.GetTextureParameter pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetTexParameteriv(target, pname, @params);
        }

        /// <summary>
        /// Return texture parameter values.
        /// <para>
        /// glGetTexParameter and glGetTextureParameter return in params the value or values
        /// of the texture parameter specified as pname. target defines the target texture.
        /// GL_TEXTURE_1D, GL_TEXTURE_2D, GL_TEXTURE_3D, GL_TEXTURE_1D_ARRAY,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_RECTANGLE, GL_TEXTURE_CUBE_MAP,
        /// GL_TEXTURE_CUBE_MAP_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, or
        /// GL_TEXTURE_2D_MULTISAMPLE_ARRAY specify one-, two-, or three-dimensional,
        /// one-dimensional array, two-dimensional array, rectangle, cube-mapped or
        /// cube-mapped array, two-dimensional multisample, or two-dimensional multisample
        /// array texturing, respectively. pname accepts the same symbols as glTexParameter,
        /// with the same interpretations:.
        /// </para>
        /// </summary>
        public static void GetTexParameterIiv(OpenGL.TextureTarget target, OpenGL.GetTextureParameter pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetTexParameterIiv(target, pname, @params);
        }

        /// <summary>
        /// Return texture parameter values.
        /// <para>
        /// glGetTexParameter and glGetTextureParameter return in params the value or values
        /// of the texture parameter specified as pname. target defines the target texture.
        /// GL_TEXTURE_1D, GL_TEXTURE_2D, GL_TEXTURE_3D, GL_TEXTURE_1D_ARRAY,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_RECTANGLE, GL_TEXTURE_CUBE_MAP,
        /// GL_TEXTURE_CUBE_MAP_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, or
        /// GL_TEXTURE_2D_MULTISAMPLE_ARRAY specify one-, two-, or three-dimensional,
        /// one-dimensional array, two-dimensional array, rectangle, cube-mapped or
        /// cube-mapped array, two-dimensional multisample, or two-dimensional multisample
        /// array texturing, respectively. pname accepts the same symbols as glTexParameter,
        /// with the same interpretations:.
        /// </para>
        /// </summary>
        public static void GetTexParameterIuiv(OpenGL.TextureTarget target, OpenGL.GetTextureParameter pname, [OutAttribute] UInt32[] @params)
        {
            Delegates.glGetTexParameterIuiv(target, pname, @params);
        }

        /// <summary>
        /// Return texture parameter values.
        /// <para>
        /// glGetTexParameter and glGetTextureParameter return in params the value or values
        /// of the texture parameter specified as pname. target defines the target texture.
        /// GL_TEXTURE_1D, GL_TEXTURE_2D, GL_TEXTURE_3D, GL_TEXTURE_1D_ARRAY,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_RECTANGLE, GL_TEXTURE_CUBE_MAP,
        /// GL_TEXTURE_CUBE_MAP_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, or
        /// GL_TEXTURE_2D_MULTISAMPLE_ARRAY specify one-, two-, or three-dimensional,
        /// one-dimensional array, two-dimensional array, rectangle, cube-mapped or
        /// cube-mapped array, two-dimensional multisample, or two-dimensional multisample
        /// array texturing, respectively. pname accepts the same symbols as glTexParameter,
        /// with the same interpretations:.
        /// </para>
        /// </summary>
        public static void GetTextureParameterfv(UInt32 texture, OpenGL.GetTextureParameter pname, [OutAttribute] Single[] @params)
        {
            Delegates.glGetTextureParameterfv(texture, pname, @params);
        }

        /// <summary>
        /// Return texture parameter values.
        /// <para>
        /// glGetTexParameter and glGetTextureParameter return in params the value or values
        /// of the texture parameter specified as pname. target defines the target texture.
        /// GL_TEXTURE_1D, GL_TEXTURE_2D, GL_TEXTURE_3D, GL_TEXTURE_1D_ARRAY,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_RECTANGLE, GL_TEXTURE_CUBE_MAP,
        /// GL_TEXTURE_CUBE_MAP_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, or
        /// GL_TEXTURE_2D_MULTISAMPLE_ARRAY specify one-, two-, or three-dimensional,
        /// one-dimensional array, two-dimensional array, rectangle, cube-mapped or
        /// cube-mapped array, two-dimensional multisample, or two-dimensional multisample
        /// array texturing, respectively. pname accepts the same symbols as glTexParameter,
        /// with the same interpretations:.
        /// </para>
        /// </summary>
        public static void GetTextureParameteriv(UInt32 texture, OpenGL.GetTextureParameter pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetTextureParameteriv(texture, pname, @params);
        }

        /// <summary>
        /// Return texture parameter values.
        /// <para>
        /// glGetTexParameter and glGetTextureParameter return in params the value or values
        /// of the texture parameter specified as pname. target defines the target texture.
        /// GL_TEXTURE_1D, GL_TEXTURE_2D, GL_TEXTURE_3D, GL_TEXTURE_1D_ARRAY,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_RECTANGLE, GL_TEXTURE_CUBE_MAP,
        /// GL_TEXTURE_CUBE_MAP_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, or
        /// GL_TEXTURE_2D_MULTISAMPLE_ARRAY specify one-, two-, or three-dimensional,
        /// one-dimensional array, two-dimensional array, rectangle, cube-mapped or
        /// cube-mapped array, two-dimensional multisample, or two-dimensional multisample
        /// array texturing, respectively. pname accepts the same symbols as glTexParameter,
        /// with the same interpretations:.
        /// </para>
        /// </summary>
        public static void GetTextureParameterIiv(UInt32 texture, OpenGL.GetTextureParameter pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetTextureParameterIiv(texture, pname, @params);
        }

        /// <summary>
        /// Return texture parameter values.
        /// <para>
        /// glGetTexParameter and glGetTextureParameter return in params the value or values
        /// of the texture parameter specified as pname. target defines the target texture.
        /// GL_TEXTURE_1D, GL_TEXTURE_2D, GL_TEXTURE_3D, GL_TEXTURE_1D_ARRAY,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_RECTANGLE, GL_TEXTURE_CUBE_MAP,
        /// GL_TEXTURE_CUBE_MAP_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, or
        /// GL_TEXTURE_2D_MULTISAMPLE_ARRAY specify one-, two-, or three-dimensional,
        /// one-dimensional array, two-dimensional array, rectangle, cube-mapped or
        /// cube-mapped array, two-dimensional multisample, or two-dimensional multisample
        /// array texturing, respectively. pname accepts the same symbols as glTexParameter,
        /// with the same interpretations:.
        /// </para>
        /// </summary>
        public static void GetTextureParameterIuiv(UInt32 texture, OpenGL.GetTextureParameter pname, [OutAttribute] UInt32[] @params)
        {
            Delegates.glGetTextureParameterIuiv(texture, pname, @params);
        }

        /// <summary>
        /// Retrieve a sub-region of a texture image from a texture object.
        /// <para>
        /// glGetTextureSubImage returns a texture subimage into pixels.
        /// </para>
        /// </summary>
        public static void GetTextureSubImage(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenGL.PixelFormat format, OpenGL.PixelType type, Int32 bufSize, [OutAttribute] IntPtr pixels)
        {
            Delegates.glGetTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, pixels);
        }

        /// <summary>
        /// Query the state of a transform feedback object.
        /// <para>
        /// In order to use the Transform Feedback functionality, you need to configure the
        /// Transform Feedback Buffer indexed bindings. This can be achieved by either using
        /// glBindBufferBase or glBindBuffersBase to associate whole buffer object storage
        /// to one of the Transform Feedback Binding Points, or by calling glBindBufferRange
        /// or glBindBuffersRange to use a region of a buffer object storage for the
        /// binding. You may want to (but are not required to) bind a Transform Feedback
        /// Object first, in order to cache the binding configuration. This usually allows
        /// you to restore the Transform Feedback configuration faster, than if you were to
        /// execute a list of API calls necessary to set up the Transform Feedback state of
        /// your liking.
        /// </para>
        /// </summary>
        public static void GetTransformFeedbackiv(UInt32 xfb, OpenGL.TransformFeedbackParameterName pname, [OutAttribute] Int32[] param)
        {
            Delegates.glGetTransformFeedbackiv(xfb, pname, param);
        }

        /// <summary>
        /// Query the state of a transform feedback object.
        /// <para>
        /// In order to use the Transform Feedback functionality, you need to configure the
        /// Transform Feedback Buffer indexed bindings. This can be achieved by either using
        /// glBindBufferBase or glBindBuffersBase to associate whole buffer object storage
        /// to one of the Transform Feedback Binding Points, or by calling glBindBufferRange
        /// or glBindBuffersRange to use a region of a buffer object storage for the
        /// binding. You may want to (but are not required to) bind a Transform Feedback
        /// Object first, in order to cache the binding configuration. This usually allows
        /// you to restore the Transform Feedback configuration faster, than if you were to
        /// execute a list of API calls necessary to set up the Transform Feedback state of
        /// your liking.
        /// </para>
        /// </summary>
        public static void GetTransformFeedbacki_v(UInt32 xfb, OpenGL.TransformFeedbackParameterName pname, UInt32 index, [OutAttribute] Int32[] param)
        {
            Delegates.glGetTransformFeedbacki_v(xfb, pname, index, param);
        }

        /// <summary>
        /// Query the state of a transform feedback object.
        /// <para>
        /// In order to use the Transform Feedback functionality, you need to configure the
        /// Transform Feedback Buffer indexed bindings. This can be achieved by either using
        /// glBindBufferBase or glBindBuffersBase to associate whole buffer object storage
        /// to one of the Transform Feedback Binding Points, or by calling glBindBufferRange
        /// or glBindBuffersRange to use a region of a buffer object storage for the
        /// binding. You may want to (but are not required to) bind a Transform Feedback
        /// Object first, in order to cache the binding configuration. This usually allows
        /// you to restore the Transform Feedback configuration faster, than if you were to
        /// execute a list of API calls necessary to set up the Transform Feedback state of
        /// your liking.
        /// </para>
        /// </summary>
        public static void GetTransformFeedbacki64_v(UInt32 xfb, OpenGL.TransformFeedbackParameterName pname, UInt32 index, [OutAttribute] Int64[] param)
        {
            Delegates.glGetTransformFeedbacki64_v(xfb, pname, index, param);
        }

        /// <summary>
        /// Retrieve information about varying variables selected for transform feedback.
        /// <para>
        /// Information about the set of varying variables in a linked program that will be
        /// captured during transform feedback may be retrieved by calling
        /// glGetTransformFeedbackVarying. glGetTransformFeedbackVarying provides
        /// information about the varying variable selected by index. An index of 0 selects
        /// the first varying variable specified in the varyings array passed to
        /// glTransformFeedbackVaryings, and an index of the value of
        /// GL_TRANSFORM_FEEDBACK_VARYINGS minus one selects the last such variable.
        /// </para>
        /// </summary>
        public static void GetTransformFeedbackVarying(UInt32 program, UInt32 index, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] Int32[] size, [OutAttribute] OpenGL.ActiveAttribType[] type, [OutAttribute] System.Text.StringBuilder name)
        {
            Delegates.glGetTransformFeedbackVarying(program, index, bufSize, length, size, type, name);
        }

        /// <summary>
        /// Returns the value of a uniform variable.
        /// <para>
        /// glGetUniform and glGetnUniform return in params the value(s) of the specified
        /// uniform variable. The type of the uniform variable specified by location
        /// determines the number of values returned. If the uniform variable is defined in
        /// the shader as a boolean, int, or float, a single value will be returned. If it
        /// is defined as a vec2, ivec2, or bvec2, two values will be returned. If it is
        /// defined as a vec3, ivec3, or bvec3, three values will be returned, and so on. To
        /// query values stored in uniform variables declared as arrays, call glGetUniform
        /// for each element of the array. To query values stored in uniform variables
        /// declared as structures, call glGetUniform for each field in the structure. The
        /// values for uniform variables declared as a matrix will be returned in column
        /// major order.
        /// </para>
        /// </summary>
        public static void GetUniformfv(UInt32 program, Int32 location, [OutAttribute] Single[] @params)
        {
            Delegates.glGetUniformfv(program, location, @params);
        }

        /// <summary>
        /// Returns the value of a uniform variable.
        /// <para>
        /// glGetUniform and glGetnUniform return in params the value(s) of the specified
        /// uniform variable. The type of the uniform variable specified by location
        /// determines the number of values returned. If the uniform variable is defined in
        /// the shader as a boolean, int, or float, a single value will be returned. If it
        /// is defined as a vec2, ivec2, or bvec2, two values will be returned. If it is
        /// defined as a vec3, ivec3, or bvec3, three values will be returned, and so on. To
        /// query values stored in uniform variables declared as arrays, call glGetUniform
        /// for each element of the array. To query values stored in uniform variables
        /// declared as structures, call glGetUniform for each field in the structure. The
        /// values for uniform variables declared as a matrix will be returned in column
        /// major order.
        /// </para>
        /// </summary>
        public static void GetUniformiv(UInt32 program, Int32 location, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetUniformiv(program, location, @params);
        }

        /// <summary>
        /// Returns the value of a uniform variable.
        /// <para>
        /// glGetUniform and glGetnUniform return in params the value(s) of the specified
        /// uniform variable. The type of the uniform variable specified by location
        /// determines the number of values returned. If the uniform variable is defined in
        /// the shader as a boolean, int, or float, a single value will be returned. If it
        /// is defined as a vec2, ivec2, or bvec2, two values will be returned. If it is
        /// defined as a vec3, ivec3, or bvec3, three values will be returned, and so on. To
        /// query values stored in uniform variables declared as arrays, call glGetUniform
        /// for each element of the array. To query values stored in uniform variables
        /// declared as structures, call glGetUniform for each field in the structure. The
        /// values for uniform variables declared as a matrix will be returned in column
        /// major order.
        /// </para>
        /// </summary>
        public static void GetUniformuiv(UInt32 program, Int32 location, [OutAttribute] UInt32[] @params)
        {
            Delegates.glGetUniformuiv(program, location, @params);
        }

        /// <summary>
        /// Returns the value of a uniform variable.
        /// <para>
        /// glGetUniform and glGetnUniform return in params the value(s) of the specified
        /// uniform variable. The type of the uniform variable specified by location
        /// determines the number of values returned. If the uniform variable is defined in
        /// the shader as a boolean, int, or float, a single value will be returned. If it
        /// is defined as a vec2, ivec2, or bvec2, two values will be returned. If it is
        /// defined as a vec3, ivec3, or bvec3, three values will be returned, and so on. To
        /// query values stored in uniform variables declared as arrays, call glGetUniform
        /// for each element of the array. To query values stored in uniform variables
        /// declared as structures, call glGetUniform for each field in the structure. The
        /// values for uniform variables declared as a matrix will be returned in column
        /// major order.
        /// </para>
        /// </summary>
        public static void GetUniformdv(UInt32 program, Int32 location, [OutAttribute] Double[] @params)
        {
            Delegates.glGetUniformdv(program, location, @params);
        }

        /// <summary>
        /// Returns the value of a uniform variable.
        /// <para>
        /// glGetUniform and glGetnUniform return in params the value(s) of the specified
        /// uniform variable. The type of the uniform variable specified by location
        /// determines the number of values returned. If the uniform variable is defined in
        /// the shader as a boolean, int, or float, a single value will be returned. If it
        /// is defined as a vec2, ivec2, or bvec2, two values will be returned. If it is
        /// defined as a vec3, ivec3, or bvec3, three values will be returned, and so on. To
        /// query values stored in uniform variables declared as arrays, call glGetUniform
        /// for each element of the array. To query values stored in uniform variables
        /// declared as structures, call glGetUniform for each field in the structure. The
        /// values for uniform variables declared as a matrix will be returned in column
        /// major order.
        /// </para>
        /// </summary>
        public static void GetnUniformfv(UInt32 program, Int32 location, Int32 bufSize, [OutAttribute] Single[] @params)
        {
            Delegates.glGetnUniformfv(program, location, bufSize, @params);
        }

        /// <summary>
        /// Returns the value of a uniform variable.
        /// <para>
        /// glGetUniform and glGetnUniform return in params the value(s) of the specified
        /// uniform variable. The type of the uniform variable specified by location
        /// determines the number of values returned. If the uniform variable is defined in
        /// the shader as a boolean, int, or float, a single value will be returned. If it
        /// is defined as a vec2, ivec2, or bvec2, two values will be returned. If it is
        /// defined as a vec3, ivec3, or bvec3, three values will be returned, and so on. To
        /// query values stored in uniform variables declared as arrays, call glGetUniform
        /// for each element of the array. To query values stored in uniform variables
        /// declared as structures, call glGetUniform for each field in the structure. The
        /// values for uniform variables declared as a matrix will be returned in column
        /// major order.
        /// </para>
        /// </summary>
        public static void GetnUniformiv(UInt32 program, Int32 location, Int32 bufSize, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetnUniformiv(program, location, bufSize, @params);
        }

        /// <summary>
        /// Returns the value of a uniform variable.
        /// <para>
        /// glGetUniform and glGetnUniform return in params the value(s) of the specified
        /// uniform variable. The type of the uniform variable specified by location
        /// determines the number of values returned. If the uniform variable is defined in
        /// the shader as a boolean, int, or float, a single value will be returned. If it
        /// is defined as a vec2, ivec2, or bvec2, two values will be returned. If it is
        /// defined as a vec3, ivec3, or bvec3, three values will be returned, and so on. To
        /// query values stored in uniform variables declared as arrays, call glGetUniform
        /// for each element of the array. To query values stored in uniform variables
        /// declared as structures, call glGetUniform for each field in the structure. The
        /// values for uniform variables declared as a matrix will be returned in column
        /// major order.
        /// </para>
        /// </summary>
        public static void GetnUniformuiv(UInt32 program, Int32 location, Int32 bufSize, [OutAttribute] UInt32[] @params)
        {
            Delegates.glGetnUniformuiv(program, location, bufSize, @params);
        }

        /// <summary>
        /// Returns the value of a uniform variable.
        /// <para>
        /// glGetUniform and glGetnUniform return in params the value(s) of the specified
        /// uniform variable. The type of the uniform variable specified by location
        /// determines the number of values returned. If the uniform variable is defined in
        /// the shader as a boolean, int, or float, a single value will be returned. If it
        /// is defined as a vec2, ivec2, or bvec2, two values will be returned. If it is
        /// defined as a vec3, ivec3, or bvec3, three values will be returned, and so on. To
        /// query values stored in uniform variables declared as arrays, call glGetUniform
        /// for each element of the array. To query values stored in uniform variables
        /// declared as structures, call glGetUniform for each field in the structure. The
        /// values for uniform variables declared as a matrix will be returned in column
        /// major order.
        /// </para>
        /// </summary>
        public static void GetnUniformdv(UInt32 program, Int32 location, Int32 bufSize, [OutAttribute] Double[] @params)
        {
            Delegates.glGetnUniformdv(program, location, bufSize, @params);
        }

        /// <summary>
        /// Retrieve the index of a named uniform block.
        /// <para>
        /// glGetUniformBlockIndex retrieves the index of a uniform block within program.
        /// </para>
        /// </summary>
        public static UInt32 GetUniformBlockIndex(UInt32 program, String uniformBlockName)
        {
            UseProgram(program);    // take care of a crash that can occur on NVIDIA drivers by using the program first
            return Delegates.glGetUniformBlockIndex(program, uniformBlockName);
        }

        /// <summary>
        /// Retrieve the index of a named uniform block.
        /// <para>
        /// glGetUniformIndices retrieves the indices of a number of uniforms within
        /// program.
        /// </para>
        /// </summary>
        public static void GetUniformIndices(UInt32 program, Int32 uniformCount, String uniformNames, [OutAttribute] UInt32[] uniformIndices)
        {
            Delegates.glGetUniformIndices(program, uniformCount, uniformNames, uniformIndices);
        }

        /// <summary>
        /// Returns the location of a uniform variable.
        /// <para>
        /// glGetUniformLocation returns an integer that represents the location of a
        /// specific uniform variable within a program object. name must be a null
        /// terminated string that contains no white space. name must be an active uniform
        /// variable name in program that is not a structure, an array of structures, or a
        /// subcomponent of a vector or a matrix. This function returns -1 if name does not
        /// correspond to an active uniform variable in program, if name starts with the
        /// reserved prefix "gl_", or if name is associated with an atomic counter or a
        /// named uniform block.
        /// </para>
        /// </summary>
        public static Int32 GetUniformLocation(UInt32 program, String name)
        {
            return Delegates.glGetUniformLocation(program, name);
        }

        /// <summary>
        /// Retrieve the value of a subroutine uniform of a given shader stage of the current program.
        /// <para>
        /// glGetUniformSubroutine retrieves the value of the subroutine uniform at location
        /// location for shader stage shadertype of the current program. location must be
        /// less than the value of GL_ACTIVE_SUBROUTINE_UNIFORM_LOCATIONS for the shader
        /// currently in use at shader stage shadertype. The value of the subroutine uniform
        /// is returned in values.
        /// </para>
        /// </summary>
        public static void GetUniformSubroutineuiv(OpenGL.ShaderType shadertype, Int32 location, [OutAttribute] UInt32[] values)
        {
            Delegates.glGetUniformSubroutineuiv(shadertype, location, values);
        }

        /// <summary>
        /// Retrieve parameters of an attribute of a vertex array object.
        /// <para>
        /// glGetVertexArrayIndexediv and glGetVertexArrayIndexed64iv provide a way of
        /// querying parameters of an attribute at an user-specified index of a vertex array
        /// object. The vertex array object does not have to be bound to the rendering
        /// context at the time of the call, but must have been bound at least once prior to
        /// this call.
        /// </para>
        /// </summary>
        public static void GetVertexArrayIndexed64iv(UInt32 vaobj, UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Int64[] param)
        {
            Delegates.glGetVertexArrayIndexed64iv(vaobj, index, pname, param);
        }

        /// <summary>
        /// Retrieve parameters of an attribute of a vertex array object.
        /// <para>
        /// glGetVertexArrayIndexediv and glGetVertexArrayIndexed64iv provide a way of
        /// querying parameters of an attribute at an user-specified index of a vertex array
        /// object. The vertex array object does not have to be bound to the rendering
        /// context at the time of the call, but must have been bound at least once prior to
        /// this call.
        /// </para>
        /// </summary>
        public static void GetVertexArrayIndexediv(UInt32 vaobj, UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Int32[] param)
        {
            Delegates.glGetVertexArrayIndexediv(vaobj, index, pname, param);
        }

        /// <summary>
        /// Retrieve parameters of a vertex array object.
        /// <para>
        /// This function provides a mean of querying properties of an existing vertex array
        /// object. The vertex array object does not have to be bound to the rendering
        /// context at the time of the call, but must have been bound at least once prior to
        /// this call.
        /// </para>
        /// </summary>
        public static void GetVertexArrayiv(UInt32 vaobj, OpenGL.VertexAttribParameter pname, [OutAttribute] Int32[] param)
        {
            Delegates.glGetVertexArrayiv(vaobj, pname, param);
        }

        /// <summary>
        /// Return a generic vertex attribute parameter.
        /// <para>
        /// glGetVertexAttrib returns in params the value of a generic vertex attribute
        /// parameter. The generic vertex attribute to be queried is specified by index, and
        /// the parameter to be queried is specified by pname.
        /// </para>
        /// </summary>
        public static void GetVertexAttribdv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Double[] @params)
        {
            Delegates.glGetVertexAttribdv(index, pname, @params);
        }

        /// <summary>
        /// Return a generic vertex attribute parameter.
        /// <para>
        /// glGetVertexAttrib returns in params the value of a generic vertex attribute
        /// parameter. The generic vertex attribute to be queried is specified by index, and
        /// the parameter to be queried is specified by pname.
        /// </para>
        /// </summary>
        public static void GetVertexAttribdv(Int32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Double[] @params)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glGetVertexAttribdv((UInt32)index, pname, @params);
        }

        /// <summary>
        /// Return a generic vertex attribute parameter.
        /// <para>
        /// glGetVertexAttrib returns in params the value of a generic vertex attribute
        /// parameter. The generic vertex attribute to be queried is specified by index, and
        /// the parameter to be queried is specified by pname.
        /// </para>
        /// </summary>
        public static void GetVertexAttribfv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Single[] @params)
        {
            Delegates.glGetVertexAttribfv(index, pname, @params);
        }

        /// <summary>
        /// Return a generic vertex attribute parameter.
        /// <para>
        /// glGetVertexAttrib returns in params the value of a generic vertex attribute
        /// parameter. The generic vertex attribute to be queried is specified by index, and
        /// the parameter to be queried is specified by pname.
        /// </para>
        /// </summary>
        public static void GetVertexAttribfv(Int32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Single[] @params)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glGetVertexAttribfv((UInt32)index, pname, @params);
        }

        /// <summary>
        /// Return a generic vertex attribute parameter.
        /// <para>
        /// glGetVertexAttrib returns in params the value of a generic vertex attribute
        /// parameter. The generic vertex attribute to be queried is specified by index, and
        /// the parameter to be queried is specified by pname.
        /// </para>
        /// </summary>
        public static void GetVertexAttribiv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetVertexAttribiv(index, pname, @params);
        }

        /// <summary>
        /// Return a generic vertex attribute parameter.
        /// <para>
        /// glGetVertexAttrib returns in params the value of a generic vertex attribute
        /// parameter. The generic vertex attribute to be queried is specified by index, and
        /// the parameter to be queried is specified by pname.
        /// </para>
        /// </summary>
        public static void GetVertexAttribiv(Int32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Int32[] @params)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glGetVertexAttribiv((UInt32)index, pname, @params);
        }

        /// <summary>
        /// Return a generic vertex attribute parameter.
        /// <para>
        /// glGetVertexAttrib returns in params the value of a generic vertex attribute
        /// parameter. The generic vertex attribute to be queried is specified by index, and
        /// the parameter to be queried is specified by pname.
        /// </para>
        /// </summary>
        public static void GetVertexAttribIiv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetVertexAttribIiv(index, pname, @params);
        }

        /// <summary>
        /// Return a generic vertex attribute parameter.
        /// <para>
        /// glGetVertexAttrib returns in params the value of a generic vertex attribute
        /// parameter. The generic vertex attribute to be queried is specified by index, and
        /// the parameter to be queried is specified by pname.
        /// </para>
        /// </summary>
        public static void GetVertexAttribIiv(Int32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Int32[] @params)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glGetVertexAttribIiv((UInt32)index, pname, @params);
        }

        /// <summary>
        /// Return a generic vertex attribute parameter.
        /// <para>
        /// glGetVertexAttrib returns in params the value of a generic vertex attribute
        /// parameter. The generic vertex attribute to be queried is specified by index, and
        /// the parameter to be queried is specified by pname.
        /// </para>
        /// </summary>
        public static void GetVertexAttribIuiv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] UInt32[] @params)
        {
            Delegates.glGetVertexAttribIuiv(index, pname, @params);
        }

        /// <summary>
        /// Return a generic vertex attribute parameter.
        /// <para>
        /// glGetVertexAttrib returns in params the value of a generic vertex attribute
        /// parameter. The generic vertex attribute to be queried is specified by index, and
        /// the parameter to be queried is specified by pname.
        /// </para>
        /// </summary>
        public static void GetVertexAttribIuiv(Int32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] UInt32[] @params)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glGetVertexAttribIuiv((UInt32)index, pname, @params);
        }

        /// <summary>
        /// Return a generic vertex attribute parameter.
        /// <para>
        /// glGetVertexAttrib returns in params the value of a generic vertex attribute
        /// parameter. The generic vertex attribute to be queried is specified by index, and
        /// the parameter to be queried is specified by pname.
        /// </para>
        /// </summary>
        public static void GetVertexAttribLdv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Double[] @params)
        {
            Delegates.glGetVertexAttribLdv(index, pname, @params);
        }

        /// <summary>
        /// Return a generic vertex attribute parameter.
        /// <para>
        /// glGetVertexAttrib returns in params the value of a generic vertex attribute
        /// parameter. The generic vertex attribute to be queried is specified by index, and
        /// the parameter to be queried is specified by pname.
        /// </para>
        /// </summary>
        public static void GetVertexAttribLdv(Int32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Double[] @params)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glGetVertexAttribLdv((UInt32)index, pname, @params);
        }

        /// <summary>
        /// Return the address of the specified generic vertex attribute pointer.
        /// <para>
        /// glGetVertexAttribPointerv returns pointer information. index is the generic
        /// vertex attribute to be queried, pname is a symbolic constant indicating the
        /// pointer to be returned, and params is a pointer to a location in which to place
        /// the returned data.
        /// </para>
        /// </summary>
        public static void GetVertexAttribPointerv(UInt32 index, OpenGL.VertexAttribPointerParameter pname, [OutAttribute] IntPtr pointer)
        {
            Delegates.glGetVertexAttribPointerv(index, pname, pointer);
        }

        /// <summary>
        /// Return the address of the specified generic vertex attribute pointer.
        /// <para>
        /// glGetVertexAttribPointerv returns pointer information. index is the generic
        /// vertex attribute to be queried, pname is a symbolic constant indicating the
        /// pointer to be returned, and params is a pointer to a location in which to place
        /// the returned data.
        /// </para>
        /// </summary>
        public static void GetVertexAttribPointerv(Int32 index, OpenGL.VertexAttribPointerParameter pname, [OutAttribute] IntPtr pointer)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glGetVertexAttribPointerv((UInt32)index, pname, pointer);
        }

        /// <summary>
        /// Specify implementation-specific hints.
        /// <para>
        /// Certain aspects of GL behavior, when there is room for interpretation, can be
        /// controlled with hints. A hint is specified with two arguments. target is a
        /// symbolic constant indicating the behavior to be controlled, and mode is another
        /// symbolic constant indicating the desired behavior. The initial value for each
        /// target is GL_DONT_CARE. mode can be one of the following:.
        /// </para>
        /// </summary>
        public static void Hint(OpenGL.HintTarget target, OpenGL.HintMode mode)
        {
            Delegates.glHint(target, mode);
        }

        /// <summary>
        /// Invalidate the content of a buffer object's data store.
        /// <para>
        /// glInvalidateBufferData invalidates all of the content of the data store of a
        /// buffer object. After invalidation, the content of the buffer's data store
        /// becomes undefined.
        /// </para>
        /// </summary>
        public static void InvalidateBufferData(UInt32 buffer)
        {
            Delegates.glInvalidateBufferData(buffer);
        }

        /// <summary>
        /// Invalidate a region of a buffer object's data store.
        /// <para>
        /// glInvalidateBufferSubData invalidates all or part of the content of the data
        /// store of a buffer object. After invalidation, the content of the specified range
        /// of the buffer's data store becomes undefined. The start of the range is given by
        /// offset and its size is given by length, both measured in basic machine units.
        /// </para>
        /// </summary>
        public static void InvalidateBufferSubData(UInt32 buffer, IntPtr offset, IntPtr length)
        {
            Delegates.glInvalidateBufferSubData(buffer, offset, length);
        }

        /// <summary>
        /// Invalidate the content of some or all of a framebuffer's attachments.
        /// <para>
        /// glInvalidateFramebuffer and glInvalidateNamedFramebufferData invalidate the
        /// entire contents of a specified set of attachments of a framebuffer.
        /// </para>
        /// </summary>
        public static void InvalidateFramebuffer(OpenGL.FramebufferTarget target, Int32 numAttachments, OpenGL.FramebufferAttachment[] attachments)
        {
            Delegates.glInvalidateFramebuffer(target, numAttachments, attachments);
        }

        /// <summary>
        /// Invalidate the content of some or all of a framebuffer's attachments.
        /// <para>
        /// glInvalidateFramebuffer and glInvalidateNamedFramebufferData invalidate the
        /// entire contents of a specified set of attachments of a framebuffer.
        /// </para>
        /// </summary>
        public static void InvalidateNamedFramebufferData(UInt32 framebuffer, Int32 numAttachments, OpenGL.FramebufferAttachment[] attachments)
        {
            Delegates.glInvalidateNamedFramebufferData(framebuffer, numAttachments, attachments);
        }

        /// <summary>
        /// Invalidate the content of a region of some or all of a framebuffer's attachments.
        /// <para>
        /// glInvalidateSubFramebuffer and glInvalidateNamedFramebufferSubData invalidate
        /// the contents of a specified region of a specified set of attachments of a
        /// framebuffer.
        /// </para>
        /// </summary>
        public static void InvalidateSubFramebuffer(OpenGL.FramebufferTarget target, Int32 numAttachments, OpenGL.FramebufferAttachment[] attachments, Int32 x, Int32 y, Int32 width, Int32 height)
        {
            Delegates.glInvalidateSubFramebuffer(target, numAttachments, attachments, x, y, width, height);
        }

        /// <summary>
        /// Invalidate the content of a region of some or all of a framebuffer's attachments.
        /// <para>
        /// glInvalidateSubFramebuffer and glInvalidateNamedFramebufferSubData invalidate
        /// the contents of a specified region of a specified set of attachments of a
        /// framebuffer.
        /// </para>
        /// </summary>
        public static void InvalidateNamedFramebufferSubData(UInt32 framebuffer, Int32 numAttachments, OpenGL.FramebufferAttachment[] attachments, Int32 x, Int32 y, Int32 width, Int32 height)
        {
            Delegates.glInvalidateNamedFramebufferSubData(framebuffer, numAttachments, attachments, x, y, width, height);
        }

        /// <summary>
        /// Invalidate the entirety a texture image.
        /// <para>
        /// glInvalidateTexSubImage invalidates all of a texture image. texture and level
        /// indicated which texture image is being invalidated. After this command, data in
        /// the texture image has undefined values.
        /// </para>
        /// </summary>
        public static void InvalidateTexImage(UInt32 texture, Int32 level)
        {
            Delegates.glInvalidateTexImage(texture, level);
        }

        /// <summary>
        /// Invalidate a region of a texture image.
        /// <para>
        /// glInvalidateTexSubImage invalidates all or part of a texture image. texture and
        /// level indicated which texture image is being invalidated. After this command,
        /// data in that subregion have undefined values. xoffset, yoffset, zoffset, width,
        /// height, and depth are interpreted as they are in glTexSubImage3D. For texture
        /// targets that don't have certain dimensions, this command treats those dimensions
        /// as having a size of 1. For example, to invalidate a portion of a two-
        /// dimensional texture, the application would use zoffset equal to zero and depth
        /// equal to one. Cube map textures are treated as an array of six slices in the
        /// z-dimension, where a value of zoffset is interpreted as specifying face
        /// GL_TEXTURE_CUBE_MAP_POSITIVE_X + zoffset.
        /// </para>
        /// </summary>
        public static void InvalidateTexSubImage(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth)
        {
            Delegates.glInvalidateTexSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth);
        }

        /// <summary>
        /// Determine if a name corresponds to a buffer object.
        /// <para>
        /// glIsBuffer returns GL_TRUE if buffer is currently the name of a buffer object.
        /// If buffer is zero, or is a non-zero value that is not currently the name of a
        /// buffer object, or if an error occurs, glIsBuffer returns GL_FALSE.
        /// </para>
        /// </summary>
        public static Boolean IsBuffer(UInt32 buffer)
        {
            return Delegates.glIsBuffer(buffer);
        }

        /// <summary>
        /// Test whether a capability is enabled.
        /// <para>
        /// glIsEnabled returns GL_TRUE if cap is an enabled capability and returns GL_FALSE
        /// otherwise. Boolean states that are indexed may be tested with glIsEnabledi. For
        /// glIsEnabledi, index specifies the index of the capability to test. index must be
        /// between zero and the count of indexed capabilities for cap. Initially all
        /// capabilities except GL_DITHER are disabled; GL_DITHER is initially enabled.
        /// </para>
        /// </summary>
        public static Boolean IsEnabled(OpenGL.EnableCap cap)
        {
            return Delegates.glIsEnabled(cap);
        }

        /// <summary>
        /// Test whether a capability is enabled.
        /// <para>
        /// glIsEnabled returns GL_TRUE if cap is an enabled capability and returns GL_FALSE
        /// otherwise. Boolean states that are indexed may be tested with glIsEnabledi. For
        /// glIsEnabledi, index specifies the index of the capability to test. index must be
        /// between zero and the count of indexed capabilities for cap. Initially all
        /// capabilities except GL_DITHER are disabled; GL_DITHER is initially enabled.
        /// </para>
        /// </summary>
        public static Boolean IsEnabledi(OpenGL.EnableCap cap, UInt32 index)
        {
            return Delegates.glIsEnabledi(cap, index);
        }

        /// <summary>
        /// Determine if a name corresponds to a framebuffer object.
        /// <para>
        /// glIsFramebuffer returns GL_TRUE if framebuffer is currently the name of a
        /// framebuffer object. If framebuffer is zero, or if framebuffer is not the name of
        /// a framebuffer object, or if an error occurs, glIsFramebuffer returns GL_FALSE.
        /// If framebuffer is a name returned by glGenFramebuffers, by that has not yet been
        /// bound through a call to glBindFramebuffer, then the name is not a framebuffer
        /// object and glIsFramebuffer returns GL_FALSE.
        /// </para>
        /// </summary>
        public static Boolean IsFramebuffer(UInt32 framebuffer)
        {
            return Delegates.glIsFramebuffer(framebuffer);
        }

        /// <summary>
        /// Determines if a name corresponds to a program object.
        /// <para>
        /// glIsProgram returns GL_TRUE if program is the name of a program object
        /// previously created with glCreateProgram and not yet deleted with
        /// glDeleteProgram. If program is zero or a non-zero value that is not the name of
        /// a program object, or if an error occurs, glIsProgram returns GL_FALSE.
        /// </para>
        /// </summary>
        public static Boolean IsProgram(UInt32 program)
        {
            return Delegates.glIsProgram(program);
        }

        /// <summary>
        /// Determine if a name corresponds to a program pipeline object.
        /// <para>
        /// glIsProgramPipeline returns GL_TRUE if pipeline is currently the name of a
        /// program pipeline object. If pipeline is zero, or if pipeline is not the name of
        /// a program pipeline object, or if an error occurs, glIsProgramPipeline returns
        /// GL_FALSE. If pipeline is a name returned by glGenProgramPipelines, but that has
        /// not yet been bound through a call to glBindProgramPipeline, then the name is not
        /// a program pipeline object and glIsProgramPipeline returns GL_FALSE.
        /// </para>
        /// </summary>
        public static Boolean IsProgramPipeline(UInt32 pipeline)
        {
            return Delegates.glIsProgramPipeline(pipeline);
        }

        /// <summary>
        /// Determine if a name corresponds to a query object.
        /// <para>
        /// glIsQuery returns GL_TRUE if id is currently the name of a query object. If id
        /// is zero, or is a non-zero value that is not currently the name of a query
        /// object, or if an error occurs, glIsQuery returns GL_FALSE.
        /// </para>
        /// </summary>
        public static Boolean IsQuery(UInt32 id)
        {
            return Delegates.glIsQuery(id);
        }

        /// <summary>
        /// Determine if a name corresponds to a renderbuffer object.
        /// <para>
        /// glIsRenderbuffer returns GL_TRUE if renderbuffer is currently the name of a
        /// renderbuffer object. If renderbuffer is zero, or if renderbuffer is not the name
        /// of a renderbuffer object, or if an error occurs, glIsRenderbuffer returns
        /// GL_FALSE. If renderbuffer is a name returned by glGenRenderbuffers, by that has
        /// not yet been bound through a call to glBindRenderbuffer or
        /// glFramebufferRenderbuffer, then the name is not a renderbuffer object and
        /// glIsRenderbuffer returns GL_FALSE.
        /// </para>
        /// </summary>
        public static Boolean IsRenderbuffer(UInt32 renderbuffer)
        {
            return Delegates.glIsRenderbuffer(renderbuffer);
        }

        /// <summary>
        /// Determine if a name corresponds to a sampler object.
        /// <para>
        /// glIsSampler returns GL_TRUE if id is currently the name of a sampler object. If
        /// id is zero, or is a non-zero value that is not currently the name of a sampler
        /// object, or if an error occurs, glIsSampler returns GL_FALSE.
        /// </para>
        /// </summary>
        public static Boolean IsSampler(UInt32 id)
        {
            return Delegates.glIsSampler(id);
        }

        /// <summary>
        /// Determines if a name corresponds to a shader object.
        /// <para>
        /// glIsShader returns GL_TRUE if shader is the name of a shader object previously
        /// created with glCreateShader and not yet deleted with glDeleteShader. If shader
        /// is zero or a non-zero value that is not the name of a shader object, or if an
        /// error occurs, glIsShader returns GL_FALSE.
        /// </para>
        /// </summary>
        public static Boolean IsShader(UInt32 shader)
        {
            return Delegates.glIsShader(shader);
        }

        /// <summary>
        /// Determine if a name corresponds to a sync object.
        /// <para>
        /// glIsSync returns GL_TRUE if sync is currently the name of a sync object. If sync
        /// is not the name of a sync object, or if an error occurs, glIsSync returns
        /// GL_FALSE. Note that zero is not the name of a sync object.
        /// </para>
        /// </summary>
        public static Boolean IsSync(IntPtr sync)
        {
            return Delegates.glIsSync(sync);
        }

        /// <summary>
        /// Determine if a name corresponds to a texture.
        /// <para>
        /// glIsTexture returns GL_TRUE if texture is currently the name of a texture. If
        /// texture is zero, or is a non-zero value that is not currently the name of a
        /// texture, or if an error occurs, glIsTexture returns GL_FALSE.
        /// </para>
        /// </summary>
        public static Boolean IsTexture(UInt32 texture)
        {
            return Delegates.glIsTexture(texture);
        }

        /// <summary>
        /// Determine if a name corresponds to a transform feedback object.
        /// <para>
        /// glIsTransformFeedback returns GL_TRUE if id is currently the name of a transform
        /// feedback object. If id is zero, or if id is not the name of a transform feedback
        /// object, or if an error occurs, glIsTransformFeedback returns GL_FALSE. If id is
        /// a name returned by glGenTransformFeedbacks, but that has not yet been bound
        /// through a call to glBindTransformFeedback, then the name is not a transform
        /// feedback object and glIsTransformFeedback returns GL_FALSE.
        /// </para>
        /// </summary>
        public static Boolean IsTransformFeedback(UInt32 id)
        {
            return Delegates.glIsTransformFeedback(id);
        }

        /// <summary>
        /// Determine if a name corresponds to a vertex array object.
        /// <para>
        /// glIsVertexArray returns GL_TRUE if array is currently the name of a vertex array
        /// object. If array is zero, or if array is not the name of a vertex array object,
        /// or if an error occurs, glIsVertexArray returns GL_FALSE. If array is a name
        /// returned by glGenVertexArrays, by that has not yet been bound through a call to
        /// glBindVertexArray, then the name is not a vertex array object and
        /// glIsVertexArray returns GL_FALSE.
        /// </para>
        /// </summary>
        public static Boolean IsVertexArray(UInt32 array)
        {
            return Delegates.glIsVertexArray(array);
        }

        /// <summary>
        /// Specify the width of rasterized lines.
        /// <para>
        /// glLineWidth specifies the rasterized width of both aliased and antialiased
        /// lines. Using a line width other than 1 has different effects, depending on
        /// whether line antialiasing is enabled. To enable and disable line antialiasing,
        /// call glEnable and glDisable with argument GL_LINE_SMOOTH. Line antialiasing is
        /// initially disabled.
        /// </para>
        /// </summary>
        public static void LineWidth(Single width)
        {
            Delegates.glLineWidth(width);
        }

        /// <summary>
        /// Links a program object.
        /// <para>
        /// glLinkProgram links the program object specified by program. If any shader
        /// objects of type GL_VERTEX_SHADER are attached to program, they will be used to
        /// create an executable that will run on the programmable vertex processor. If any
        /// shader objects of type GL_GEOMETRY_SHADER are attached to program, they will be
        /// used to create an executable that will run on the programmable geometry
        /// processor. If any shader objects of type GL_FRAGMENT_SHADER are attached to
        /// program, they will be used to create an executable that will run on the
        /// programmable fragment processor.
        /// </para>
        /// </summary>
        public static void LinkProgram(UInt32 program)
        {
            Delegates.glLinkProgram(program);
        }

        /// <summary>
        /// Specify a logical pixel operation for rendering.
        /// <para>
        /// glLogicOp specifies a logical operation that, when enabled, is applied between
        /// the incoming RGBA color and the RGBA color at the corresponding location in the
        /// frame buffer. To enable or disable the logical operation, call glEnable and
        /// glDisable using the symbolic constant GL_COLOR_LOGIC_OP. The initial value is
        /// disabled.
        /// </para>
        /// </summary>
        public static void LogicOp(OpenGL.LogicOp opcode)
        {
            Delegates.glLogicOp(opcode);
        }

        /// <summary>
        /// Map all of a buffer object's data store into the client's address space.
        /// <para>
        /// glMapBuffer and glMapNamedBuffer map the entire data store of a specified buffer
        /// object into the client's address space. The data can then be directly read
        /// and/or written relative to the returned pointer, depending on the specified
        /// access policy.
        /// </para>
        /// </summary>
        public static IntPtr MapBuffer(OpenGL.BufferTarget target, OpenGL.BufferAccess access)
        {
            return Delegates.glMapBuffer(target, access);
        }

        /// <summary>
        /// Map all of a buffer object's data store into the client's address space.
        /// <para>
        /// glMapBuffer and glMapNamedBuffer map the entire data store of a specified buffer
        /// object into the client's address space. The data can then be directly read
        /// and/or written relative to the returned pointer, depending on the specified
        /// access policy.
        /// </para>
        /// </summary>
        public static IntPtr MapNamedBuffer(UInt32 buffer, OpenGL.BufferAccess access)
        {
            return Delegates.glMapNamedBuffer(buffer, access);
        }

        /// <summary>
        /// Map all or part of a buffer object's data store into the client's address space.
        /// <para>
        /// glMapBufferRange and glMapNamedBufferRange map all or part of the data store of
        /// a specified buffer object into the client's address space. offset and length
        /// indicate the range of data in the buffer object that is to be mapped, in terms
        /// of basic machine units. access is a bitfield containing flags which describe the
        /// requested mapping. These flags are described below.
        /// </para>
        /// </summary>
        public static IntPtr MapBufferRange(OpenGL.BufferTarget target, IntPtr offset, IntPtr length, OpenGL.BufferAccessMask access)
        {
            return Delegates.glMapBufferRange(target, offset, length, access);
        }

        /// <summary>
        /// Map all or part of a buffer object's data store into the client's address space.
        /// <para>
        /// glMapBufferRange and glMapNamedBufferRange map all or part of the data store of
        /// a specified buffer object into the client's address space. offset and length
        /// indicate the range of data in the buffer object that is to be mapped, in terms
        /// of basic machine units. access is a bitfield containing flags which describe the
        /// requested mapping. These flags are described below.
        /// </para>
        /// </summary>
        public static IntPtr MapNamedBufferRange(UInt32 buffer, IntPtr offset, Int32 length, UInt32 access)
        {
            return Delegates.glMapNamedBufferRange(buffer, offset, length, access);
        }

        /// <summary>
        /// Defines a barrier ordering memory transactions.
        /// <para>
        /// Encoding="UTF-8" standalone="no"?> glMemoryBarrier - OpenGL 4 Reference Pages
        /// MathJax.Hub.Config({ MathML: { extensions: ["content-mathml.js"] }, tex2jax: {
        /// inlineMath: [['$','$'], ['\\(','\\)']] } }); Name glMemoryBarrier — defines a
        /// barrier ordering memory transactions.
        /// </para>
        /// </summary>
        public static void MemoryBarrier(UInt32 barriers)
        {
            Delegates.glMemoryBarrier(barriers);
        }

        /// <summary>
        /// Defines a barrier ordering memory transactions.
        /// <para>
        /// Encoding="UTF-8" standalone="no"?> glMemoryBarrier - OpenGL 4 Reference Pages
        /// MathJax.Hub.Config({ MathML: { extensions: ["content-mathml.js"] }, tex2jax: {
        /// inlineMath: [['$','$'], ['\\(','\\)']] } }); Name glMemoryBarrier — defines a
        /// barrier ordering memory transactions.
        /// </para>
        /// </summary>
        public static void MemoryBarrierByRegion(UInt32 barriers)
        {
            Delegates.glMemoryBarrierByRegion(barriers);
        }

        /// <summary>
        /// Specifies minimum rate at which sample shaing takes place.
        /// <para>
        /// glMinSampleShading specifies the rate at which samples are shaded within a
        /// covered pixel. Sample-rate shading is enabled by calling glEnable with the
        /// parameter GL_SAMPLE_SHADING. If GL_MULTISAMPLE or GL_SAMPLE_SHADING is disabled,
        /// sample shading has no effect. Otherwise, an implementation must provide at least
        /// as many unique color values for each covered fragment as specified by value
        /// times samples where samples is the value of GL_SAMPLES for the current
        /// framebuffer. At least 1 sample for each covered fragment is generated.
        /// </para>
        /// </summary>
        public static void MinSampleShading(Single value)
        {
            Delegates.glMinSampleShading(value);
        }

        /// <summary>
        /// Render multiple sets of primitives from array data.
        /// <para>
        /// glMultiDrawArrays specifies multiple sets of geometric primitives with very few
        /// subroutine calls. Instead of calling a GL procedure to pass each individual
        /// vertex, normal, texture coordinate, edge flag, or color, you can prespecify
        /// separate arrays of vertices, normals, and colors and use them to construct a
        /// sequence of primitives with a single call to glMultiDrawArrays.
        /// </para>
        /// </summary>
        public static void MultiDrawArrays(OpenGL.BeginMode mode, Int32[] first, Int32[] count, Int32 drawcount)
        {
            Delegates.glMultiDrawArrays(mode, first, count, drawcount);
        }

        /// <summary>
        /// Render multiple sets of primitives from array data, taking parameters from memory.
        /// <para>
        /// glMultiDrawArraysIndirect specifies multiple geometric primitives with very few
        /// subroutine calls. glMultiDrawArraysIndirect behaves similarly to a multitude of
        /// calls to glDrawArraysInstancedBaseInstance, execept that the parameters to each
        /// call to glDrawArraysInstancedBaseInstance are stored in an array in memory at
        /// the address given by indirect, separated by the stride, in basic machine units,
        /// specified by stride. If stride is zero, then the array is assumed to be tightly
        /// packed in memory.
        /// </para>
        /// </summary>
        public static void MultiDrawArraysIndirect(OpenGL.BeginMode mode, IntPtr indirect, Int32 drawcount, Int32 stride)
        {
            Delegates.glMultiDrawArraysIndirect(mode, indirect, drawcount, stride);
        }

        /// <summary>
        /// Render multiple sets of primitives by specifying indices of array data elements.
        /// <para>
        /// glMultiDrawElements specifies multiple sets of geometric primitives with very
        /// few subroutine calls. Instead of calling a GL function to pass each individual
        /// vertex, normal, texture coordinate, edge flag, or color, you can prespecify
        /// separate arrays of vertices, normals, and so on, and use them to construct a
        /// sequence of primitives with a single call to glMultiDrawElements.
        /// </para>
        /// </summary>
        public static void MultiDrawElements(OpenGL.BeginMode mode, Int32[] count, OpenGL.DrawElementsType type, IntPtr indices, Int32 drawcount)
        {
            Delegates.glMultiDrawElements(mode, count, type, indices, drawcount);
        }

        /// <summary>
        /// Render multiple sets of primitives by specifying indices of array data elements and an index to apply to each index.
        /// <para>
        /// glMultiDrawElementsBaseVertex behaves identically to glDrawElementsBaseVertex,
        /// except that drawcount separate lists of elements are specifried instead.
        /// </para>
        /// </summary>
        public static void MultiDrawElementsBaseVertex(OpenGL.BeginMode mode, Int32[] count, OpenGL.DrawElementsType type, IntPtr indices, Int32 drawcount, Int32[] basevertex)
        {
            Delegates.glMultiDrawElementsBaseVertex(mode, count, type, indices, drawcount, basevertex);
        }

        /// <summary>
        /// Render indexed primitives from array data, taking parameters from memory.
        /// <para>
        /// glMultiDrawElementsIndirect specifies multiple indexed geometric primitives with
        /// very few subroutine calls. glMultiDrawElementsIndirect behaves similarly to a
        /// multitude of calls to glDrawElementsInstancedBaseVertexBaseInstance, execpt that
        /// the parameters to glDrawElementsInstancedBaseVertexBaseInstance are stored in an
        /// array in memory at the address given by indirect, separated by the stride, in
        /// basic machine units, specified by stride. If stride is zero, then the array is
        /// assumed to be tightly packed in memory.
        /// </para>
        /// </summary>
        public static void MultiDrawElementsIndirect(OpenGL.BeginMode mode, OpenGL.DrawElementsType type, IntPtr indirect, Int32 drawcount, Int32 stride)
        {
            Delegates.glMultiDrawElementsIndirect(mode, type, indirect, drawcount, stride);
        }

        /// <summary>
        /// Label a named object identified within a namespace.
        /// <para>
        /// glObjectLabel labels the object identified by name within the namespace given by
        /// identifier. identifier must be one of GL_BUFFER, GL_SHADER, GL_PROGRAM,
        /// GL_VERTEX_ARRAY, GL_QUERY, GL_PROGRAM_PIPELINE, GL_TRANSFORM_FEEDBACK,
        /// GL_SAMPLER, GL_TEXTURE, GL_RENDERBUFFER, GL_FRAMEBUFFER, to indicate the
        /// namespace containing the names of buffers, shaders, programs, vertex array
        /// objects, query objects, program pipelines, transform feedback objects, samplers,
        /// textures, renderbuffers and frame buffers, respectively.
        /// </para>
        /// </summary>
        public static void ObjectLabel(OpenGL.ObjectLabel identifier, UInt32 name, Int32 length, String label)
        {
            Delegates.glObjectLabel(identifier, name, length, label);
        }

        /// <summary>
        /// Label a a sync object identified by a pointer.
        /// <para>
        /// glObjectPtrLabel labels the sync object identified by ptr.
        /// </para>
        /// </summary>
        public static void ObjectPtrLabel(IntPtr ptr, Int32 length, String label)
        {
            Delegates.glObjectPtrLabel(ptr, length, label);
        }

        /// <summary>
        /// Specifies the parameters for patch primitives.
        /// <para>
        /// glPatchParameter specifies the parameters that will be used for patch
        /// primitives. pname specifies the parameter to modify and must be either
        /// GL_PATCH_VERTICES, GL_PATCH_DEFAULT_OUTER_LEVEL or GL_PATCH_DEFAULT_INNER_LEVEL.
        /// For glPatchParameteri, value specifies the new value for the parameter specified
        /// by pname. For glPatchParameterfv, values specifies the address of an array
        /// containing the new values for the parameter specified by pname.
        /// </para>
        /// </summary>
        public static void PatchParameteri(Int32 pname, Int32 value)
        {
            Delegates.glPatchParameteri(pname, value);
        }

        /// <summary>
        /// Specifies the parameters for patch primitives.
        /// <para>
        /// glPatchParameter specifies the parameters that will be used for patch
        /// primitives. pname specifies the parameter to modify and must be either
        /// GL_PATCH_VERTICES, GL_PATCH_DEFAULT_OUTER_LEVEL or GL_PATCH_DEFAULT_INNER_LEVEL.
        /// For glPatchParameteri, value specifies the new value for the parameter specified
        /// by pname. For glPatchParameterfv, values specifies the address of an array
        /// containing the new values for the parameter specified by pname.
        /// </para>
        /// </summary>
        public static void PatchParameterfv(Int32 pname, Single[] values)
        {
            Delegates.glPatchParameterfv(pname, values);
        }

        /// <summary>
        /// Set pixel storage modes.
        /// <para>
        /// glPixelStore sets pixel storage modes that affect the operation of subsequent
        /// glReadPixels as well as the unpacking of texture patterns (see glTexImage1D,
        /// glTexImage2D, glTexImage3D, glTexSubImage1D, glTexSubImage2D, glTexSubImage3D),
        /// glCompressedTexImage1D, glCompressedTexImage2D, glCompressedTexImage3D,
        /// glCompressedTexSubImage1D, glCompressedTexSubImage2D or
        /// glCompressedTexSubImage1D.
        /// </para>
        /// </summary>
        public static void PixelStoref(OpenGL.PixelStoreParameter pname, Single param)
        {
            Delegates.glPixelStoref(pname, param);
        }

        /// <summary>
        /// Set pixel storage modes.
        /// <para>
        /// glPixelStore sets pixel storage modes that affect the operation of subsequent
        /// glReadPixels as well as the unpacking of texture patterns (see glTexImage1D,
        /// glTexImage2D, glTexImage3D, glTexSubImage1D, glTexSubImage2D, glTexSubImage3D),
        /// glCompressedTexImage1D, glCompressedTexImage2D, glCompressedTexImage3D,
        /// glCompressedTexSubImage1D, glCompressedTexSubImage2D or
        /// glCompressedTexSubImage1D.
        /// </para>
        /// </summary>
        public static void PixelStorei(OpenGL.PixelStoreParameter pname, Int32 param)
        {
            Delegates.glPixelStorei(pname, param);
        }

        /// <summary>
        /// Specify point parameters.
        /// <para>
        /// The following values are accepted for pname:.
        /// </para>
        /// </summary>
        public static void PointParameterf(OpenGL.PointParameterName pname, Single param)
        {
            Delegates.glPointParameterf(pname, param);
        }

        /// <summary>
        /// Specify point parameters.
        /// <para>
        /// The following values are accepted for pname:.
        /// </para>
        /// </summary>
        public static void PointParameteri(OpenGL.PointParameterName pname, Int32 param)
        {
            Delegates.glPointParameteri(pname, param);
        }

        /// <summary>
        /// Specify point parameters.
        /// <para>
        /// The following values are accepted for pname:.
        /// </para>
        /// </summary>
        public static void PointParameterfv(OpenGL.PointParameterName pname, Single[] @params)
        {
            Delegates.glPointParameterfv(pname, @params);
        }

        /// <summary>
        /// Specify point parameters.
        /// <para>
        /// The following values are accepted for pname:.
        /// </para>
        /// </summary>
        public static void PointParameteriv(OpenGL.PointParameterName pname, Int32[] @params)
        {
            Delegates.glPointParameteriv(pname, @params);
        }

        /// <summary>
        /// Specify the diameter of rasterized points.
        /// <para>
        /// glPointSize specifies the rasterized diameter of points. If point size mode is
        /// disabled (see glEnable with parameter GL_PROGRAM_POINT_SIZE), this value will be
        /// used to rasterize points. Otherwise, the value written to the shading language
        /// built-in variable gl_PointSize will be used.
        /// </para>
        /// </summary>
        public static void PointSize(Single size)
        {
            Delegates.glPointSize(size);
        }

        /// <summary>
        /// Select a polygon rasterization mode.
        /// <para>
        /// glPolygonMode controls the interpretation of polygons for rasterization. face
        /// describes which polygons mode applies to: both front and back-facing polygons
        /// (GL_FRONT_AND_BACK). The polygon mode affects only the final rasterization of
        /// polygons. In particular, a polygon's vertices are lit and the polygon is clipped
        /// and possibly culled before these modes are applied.
        /// </para>
        /// </summary>
        public static void PolygonMode(OpenGL.MaterialFace face, OpenGL.PolygonMode mode)
        {
            Delegates.glPolygonMode(face, mode);
        }

        /// <summary>
        /// Set the scale and units used to calculate depth values.
        /// <para>
        /// When GL_POLYGON_OFFSET_FILL, GL_POLYGON_OFFSET_LINE, or GL_POLYGON_OFFSET_POINT
        /// is enabled, each fragment's depth value will be offset after it is interpolated
        /// from the depth values of the appropriate vertices. The value of the offset is
        /// factor × DZ + r × units , where DZ is a measurement of the change in depth
        /// relative to the screen area of the polygon, and r is the smallest value that is
        /// guaranteed to produce a resolvable offset for a given implementation. The offset
        /// is added before the depth test is performed and before the value is written into
        /// the depth buffer.
        /// </para>
        /// </summary>
        public static void PolygonOffset(Single factor, Single units)
        {
            Delegates.glPolygonOffset(factor, units);
        }

        /// <summary>
        /// Specify the primitive restart index.
        /// <para>
        /// glPrimitiveRestartIndex specifies a vertex array element that is treated
        /// specially when primitive restarting is enabled. This is known as the primitive
        /// restart index.
        /// </para>
        /// </summary>
        public static void PrimitiveRestartIndex(UInt32 index)
        {
            Delegates.glPrimitiveRestartIndex(index);
        }

        /// <summary>
        /// Load a program object with a program binary.
        /// <para>
        /// glProgramBinary loads a program object with a program binary previously returned
        /// from glGetProgramBinary. binaryFormat and binary must be those returned by a
        /// previous call to glGetProgramBinary, and length must be the length returned by
        /// glGetProgramBinary, or by glGetProgram when called with pname set to
        /// GL_PROGRAM_BINARY_LENGTH. If these conditions are not met, loading the program
        /// binary will fail and program's GL_LINK_STATUS will be set to GL_FALSE.
        /// </para>
        /// </summary>
        public static void ProgramBinary(UInt32 program, Int32 binaryFormat, IntPtr binary, Int32 length)
        {
            Delegates.glProgramBinary(program, binaryFormat, binary, length);
        }

        /// <summary>
        /// Specify a parameter for a program object.
        /// <para>
        /// glProgramParameter specifies a new value for the parameter nameed by pname for
        /// the program object program.
        /// </para>
        /// </summary>
        public static void ProgramParameteri(UInt32 program, OpenGL.Version32 pname, Int32 value)
        {
            Delegates.glProgramParameteri(program, pname, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform1f(UInt32 program, Int32 location, Single v0)
        {
            Delegates.glProgramUniform1f(program, location, v0);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform2f(UInt32 program, Int32 location, Single v0, Single v1)
        {
            Delegates.glProgramUniform2f(program, location, v0, v1);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform3f(UInt32 program, Int32 location, Single v0, Single v1, Single v2)
        {
            Delegates.glProgramUniform3f(program, location, v0, v1, v2);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform4f(UInt32 program, Int32 location, Single v0, Single v1, Single v2, Single v3)
        {
            Delegates.glProgramUniform4f(program, location, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform1i(UInt32 program, Int32 location, Int32 v0)
        {
            Delegates.glProgramUniform1i(program, location, v0);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform2i(UInt32 program, Int32 location, Int32 v0, Int32 v1)
        {
            Delegates.glProgramUniform2i(program, location, v0, v1);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform3i(UInt32 program, Int32 location, Int32 v0, Int32 v1, Int32 v2)
        {
            Delegates.glProgramUniform3i(program, location, v0, v1, v2);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform4i(UInt32 program, Int32 location, Int32 v0, Int32 v1, Int32 v2, Int32 v3)
        {
            Delegates.glProgramUniform4i(program, location, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform1ui(UInt32 program, Int32 location, UInt32 v0)
        {
            Delegates.glProgramUniform1ui(program, location, v0);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform2ui(UInt32 program, Int32 location, Int32 v0, UInt32 v1)
        {
            Delegates.glProgramUniform2ui(program, location, v0, v1);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform3ui(UInt32 program, Int32 location, Int32 v0, Int32 v1, UInt32 v2)
        {
            Delegates.glProgramUniform3ui(program, location, v0, v1, v2);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform4ui(UInt32 program, Int32 location, Int32 v0, Int32 v1, Int32 v2, UInt32 v3)
        {
            Delegates.glProgramUniform4ui(program, location, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform1fv(UInt32 program, Int32 location, Int32 count, Single[] value)
        {
            Delegates.glProgramUniform1fv(program, location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform2fv(UInt32 program, Int32 location, Int32 count, Single[] value)
        {
            Delegates.glProgramUniform2fv(program, location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform3fv(UInt32 program, Int32 location, Int32 count, Single[] value)
        {
            Delegates.glProgramUniform3fv(program, location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform4fv(UInt32 program, Int32 location, Int32 count, Single[] value)
        {
            Delegates.glProgramUniform4fv(program, location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform1iv(UInt32 program, Int32 location, Int32 count, Int32[] value)
        {
            Delegates.glProgramUniform1iv(program, location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform2iv(UInt32 program, Int32 location, Int32 count, Int32[] value)
        {
            Delegates.glProgramUniform2iv(program, location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform3iv(UInt32 program, Int32 location, Int32 count, Int32[] value)
        {
            Delegates.glProgramUniform3iv(program, location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform4iv(UInt32 program, Int32 location, Int32 count, Int32[] value)
        {
            Delegates.glProgramUniform4iv(program, location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform1uiv(UInt32 program, Int32 location, Int32 count, UInt32[] value)
        {
            Delegates.glProgramUniform1uiv(program, location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform2uiv(UInt32 program, Int32 location, Int32 count, UInt32[] value)
        {
            Delegates.glProgramUniform2uiv(program, location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform3uiv(UInt32 program, Int32 location, Int32 count, UInt32[] value)
        {
            Delegates.glProgramUniform3uiv(program, location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniform4uiv(UInt32 program, Int32 location, Int32 count, UInt32[] value)
        {
            Delegates.glProgramUniform4uiv(program, location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniformMatrix2fv(UInt32 program, Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix2fv(program, location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniformMatrix3fv(UInt32 program, Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix3fv(program, location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniformMatrix4fv(UInt32 program, Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix4fv(program, location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniformMatrix2x3fv(UInt32 program, Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix2x3fv(program, location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniformMatrix3x2fv(UInt32 program, Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix3x2fv(program, location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniformMatrix2x4fv(UInt32 program, Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix2x4fv(program, location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniformMatrix4x2fv(UInt32 program, Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix4x2fv(program, location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniformMatrix3x4fv(UInt32 program, Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix3x4fv(program, location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for a specified program object.
        /// <para>
        /// glProgramUniform modifies the value of a uniform variable or a uniform variable
        /// array. The location of the uniform variable to be modified is specified by
        /// location, which should be a value returned by glGetUniformLocation.
        /// glProgramUniform operates on the program object specified by program.
        /// </para>
        /// </summary>
        public static void ProgramUniformMatrix4x3fv(UInt32 program, Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix4x3fv(program, location, count, transpose, value);
        }

        /// <summary>
        /// Specifiy the vertex to be used as the source of data for flat shaded varyings.
        /// <para>
        /// Flatshading a vertex shader varying output means to assign all vetices of the
        /// primitive the same value for that output. The vertex from which these values is
        /// derived is known as the provoking vertex and glProvokingVertex specifies which
        /// vertex is to be used as the source of data for flat shaded varyings.
        /// </para>
        /// </summary>
        public static void ProvokingVertex(OpenGL.ProvokingVertexMode provokeMode)
        {
            Delegates.glProvokingVertex(provokeMode);
        }

        /// <summary>
        /// Record the GL time into a query object after all previous commands have reached the GL server but have not yet necessarily executed.
        /// <para>
        /// glQueryCounter causes the GL to record the current time into the query object
        /// named id. target must be GL_TIMESTAMP. The time is recorded after all previous
        /// commands on the GL client and server state and the framebuffer have been fully
        /// realized. When the time is recorded, the query result for that object is marked
        /// available. glQueryCounter timer queries can be used within a glBeginQuery /
        /// glEndQuery block where the target is GL_TIME_ELAPSED and it does not affect the
        /// result of that query object.
        /// </para>
        /// </summary>
        public static void QueryCounter(UInt32 id, Int32 target)
        {
            Delegates.glQueryCounter(id, target);
        }

        /// <summary>
        /// Select a color buffer source for pixels.
        /// <para>
        /// glReadBuffer specifies a color buffer as the source for subsequent glReadPixels,
        /// glCopyTexImage1D, glCopyTexImage2D, glCopyTexSubImage1D, glCopyTexSubImage2D,
        /// and glCopyTexSubImage3D commands. mode accepts one of twelve or more predefined
        /// values. In a fully configured system, GL_FRONT, GL_LEFT, and GL_FRONT_LEFT all
        /// name the front left buffer, GL_FRONT_RIGHT and GL_RIGHT name the front right
        /// buffer, and GL_BACK_LEFT and GL_BACK name the back left buffer. Further more,
        /// the constants GL_COLOR_ATTACHMENTi may be used to indicate the ith color
        /// attachment where i ranges from zero to the value of GL_MAX_COLOR_ATTACHMENTS
        /// minus one.
        /// </para>
        /// </summary>
        public static void ReadBuffer(OpenGL.ReadBufferMode mode)
        {
            Delegates.glReadBuffer(mode);
        }

        /// <summary>
        /// Select a color buffer source for pixels.
        /// <para>
        /// glReadBuffer specifies a color buffer as the source for subsequent glReadPixels,
        /// glCopyTexImage1D, glCopyTexImage2D, glCopyTexSubImage1D, glCopyTexSubImage2D,
        /// and glCopyTexSubImage3D commands. mode accepts one of twelve or more predefined
        /// values. In a fully configured system, GL_FRONT, GL_LEFT, and GL_FRONT_LEFT all
        /// name the front left buffer, GL_FRONT_RIGHT and GL_RIGHT name the front right
        /// buffer, and GL_BACK_LEFT and GL_BACK name the back left buffer. Further more,
        /// the constants GL_COLOR_ATTACHMENTi may be used to indicate the ith color
        /// attachment where i ranges from zero to the value of GL_MAX_COLOR_ATTACHMENTS
        /// minus one.
        /// </para>
        /// </summary>
        public static void NamedFramebufferReadBuffer(UInt32 framebuffer, OpenGL.BeginMode mode)
        {
            Delegates.glNamedFramebufferReadBuffer(framebuffer, mode);
        }

        /// <summary>
        /// Read a block of pixels from the frame buffer.
        /// <para>
        /// glReadPixels and glReadnPixels return pixel data from the frame buffer, starting
        /// with the pixel whose lower left corner is at location (x, y), into client memory
        /// starting at location data. Several parameters control the processing of the
        /// pixel data before it is placed into client memory. These parameters are set with
        /// glPixelStore. This reference page describes the effects on glReadPixels and
        /// glReadnPixels of most, but not all of the parameters specified by these three
        /// commands.
        /// </para>
        /// </summary>
        public static void ReadPixels(Int32 x, Int32 y, Int32 width, Int32 height, OpenGL.PixelFormat format, OpenGL.PixelType type, Int32[] data)
        {
            Delegates.glReadPixels(x, y, width, height, format, type, data);
        }

        /// <summary>
        /// Read a block of pixels from the frame buffer.
        /// <para>
        /// glReadPixels and glReadnPixels return pixel data from the frame buffer, starting
        /// with the pixel whose lower left corner is at location (x, y), into client memory
        /// starting at location data. Several parameters control the processing of the
        /// pixel data before it is placed into client memory. These parameters are set with
        /// glPixelStore. This reference page describes the effects on glReadPixels and
        /// glReadnPixels of most, but not all of the parameters specified by these three
        /// commands.
        /// </para>
        /// </summary>
        public static void ReadnPixels(Int32 x, Int32 y, Int32 width, Int32 height, OpenGL.PixelFormat format, OpenGL.PixelType type, Int32 bufSize, Int32[] data)
        {
            Delegates.glReadnPixels(x, y, width, height, format, type, bufSize, data);
        }

        /// <summary>
        /// Establish data storage, format and dimensions of a renderbuffer object's image.
        /// <para>
        /// glRenderbufferStorage is equivalent to calling glRenderbufferStorageMultisample
        /// with the samples set to zero, and glNamedRenderbufferStorage is equivalent to
        /// calling glNamedRenderbufferStorageMultisample with the samples set to zero.
        /// </para>
        /// </summary>
        public static void RenderbufferStorage(OpenGL.RenderbufferTarget target, OpenGL.RenderbufferStorage internalFormat, Int32 width, Int32 height)
        {
            Delegates.glRenderbufferStorage(target, internalFormat, width, height);
        }

        /// <summary>
        /// Establish data storage, format and dimensions of a renderbuffer object's image.
        /// <para>
        /// glRenderbufferStorage is equivalent to calling glRenderbufferStorageMultisample
        /// with the samples set to zero, and glNamedRenderbufferStorage is equivalent to
        /// calling glNamedRenderbufferStorageMultisample with the samples set to zero.
        /// </para>
        /// </summary>
        public static void NamedRenderbufferStorage(UInt32 renderbuffer, OpenGL.RenderbufferStorage internalFormat, Int32 width, Int32 height)
        {
            Delegates.glNamedRenderbufferStorage(renderbuffer, internalFormat, width, height);
        }

        /// <summary>
        /// Establish data storage, format, dimensions and sample count of a renderbuffer object's image.
        /// <para>
        /// glRenderbufferStorageMultisample and glNamedRenderbufferStorageMultisample
        /// establish the data storage, format, dimensions and number of samples of a
        /// renderbuffer object's image.
        /// </para>
        /// </summary>
        public static void RenderbufferStorageMultisample(OpenGL.RenderbufferTarget target, Int32 samples, OpenGL.RenderbufferStorage internalFormat, Int32 width, Int32 height)
        {
            Delegates.glRenderbufferStorageMultisample(target, samples, internalFormat, width, height);
        }

        /// <summary>
        /// Establish data storage, format, dimensions and sample count of a renderbuffer object's image.
        /// <para>
        /// glRenderbufferStorageMultisample and glNamedRenderbufferStorageMultisample
        /// establish the data storage, format, dimensions and number of samples of a
        /// renderbuffer object's image.
        /// </para>
        /// </summary>
        public static void NamedRenderbufferStorageMultisample(UInt32 renderbuffer, Int32 samples, OpenGL.RenderbufferStorage internalFormat, Int32 width, Int32 height)
        {
            Delegates.glNamedRenderbufferStorageMultisample(renderbuffer, samples, internalFormat, width, height);
        }

        /// <summary>
        /// Specify multisample coverage parameters.
        /// <para>
        /// Multisampling samples a pixel multiple times at various implementation-dependent
        /// subpixel locations to generate antialiasing effects. Multisampling transparently
        /// antialiases points, lines, polygons, and images if it is enabled.
        /// </para>
        /// </summary>
        public static void SampleCoverage(Single value, Boolean invert)
        {
            Delegates.glSampleCoverage(value, invert);
        }

        /// <summary>
        /// Set the value of a sub-word of the sample mask.
        /// <para>
        /// glSampleMaski sets one 32-bit sub-word of the multi-word sample mask,
        /// GL_SAMPLE_MASK_VALUE.
        /// </para>
        /// </summary>
        public static void SampleMaski(UInt32 maskNumber, UInt32 mask)
        {
            Delegates.glSampleMaski(maskNumber, mask);
        }

        /// <summary>
        /// Set sampler parameters.
        /// <para>
        /// glSamplerParameter assigns the value or values in params to the sampler
        /// parameter specified as pname. sampler specifies the sampler object to be
        /// modified, and must be the name of a sampler object previously returned from a
        /// call to glGenSamplers. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void SamplerParameterf(UInt32 sampler, Int32 pname, Single param)
        {
            Delegates.glSamplerParameterf(sampler, pname, param);
        }

        /// <summary>
        /// Set sampler parameters.
        /// <para>
        /// glSamplerParameter assigns the value or values in params to the sampler
        /// parameter specified as pname. sampler specifies the sampler object to be
        /// modified, and must be the name of a sampler object previously returned from a
        /// call to glGenSamplers. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void SamplerParameteri(UInt32 sampler, Int32 pname, Int32 param)
        {
            Delegates.glSamplerParameteri(sampler, pname, param);
        }

        /// <summary>
        /// Set sampler parameters.
        /// <para>
        /// glSamplerParameter assigns the value or values in params to the sampler
        /// parameter specified as pname. sampler specifies the sampler object to be
        /// modified, and must be the name of a sampler object previously returned from a
        /// call to glGenSamplers. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void SamplerParameterfv(UInt32 sampler, Int32 pname, Single[] @params)
        {
            Delegates.glSamplerParameterfv(sampler, pname, @params);
        }

        /// <summary>
        /// Set sampler parameters.
        /// <para>
        /// glSamplerParameter assigns the value or values in params to the sampler
        /// parameter specified as pname. sampler specifies the sampler object to be
        /// modified, and must be the name of a sampler object previously returned from a
        /// call to glGenSamplers. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void SamplerParameteriv(UInt32 sampler, Int32 pname, Int32[] @params)
        {
            Delegates.glSamplerParameteriv(sampler, pname, @params);
        }

        /// <summary>
        /// Set sampler parameters.
        /// <para>
        /// glSamplerParameter assigns the value or values in params to the sampler
        /// parameter specified as pname. sampler specifies the sampler object to be
        /// modified, and must be the name of a sampler object previously returned from a
        /// call to glGenSamplers. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void SamplerParameterIiv(UInt32 sampler, OpenGL.TextureParameterName pname, Int32[] @params)
        {
            Delegates.glSamplerParameterIiv(sampler, pname, @params);
        }

        /// <summary>
        /// Set sampler parameters.
        /// <para>
        /// glSamplerParameter assigns the value or values in params to the sampler
        /// parameter specified as pname. sampler specifies the sampler object to be
        /// modified, and must be the name of a sampler object previously returned from a
        /// call to glGenSamplers. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void SamplerParameterIuiv(UInt32 sampler, OpenGL.TextureParameterName pname, UInt32[] @params)
        {
            Delegates.glSamplerParameterIuiv(sampler, pname, @params);
        }

        /// <summary>
        /// Define the scissor box.
        /// <para>
        /// glScissor defines a rectangle, called the scissor box, in window coordinates.
        /// The first two arguments, x and y, specify the lower left corner of the box.
        /// width and height specify the width and height of the box.
        /// </para>
        /// </summary>
        public static void Scissor(Int32 x, Int32 y, Int32 width, Int32 height)
        {
            Delegates.glScissor(x, y, width, height);
        }

        /// <summary>
        /// Define the scissor box for multiple viewports.
        /// <para>
        /// glScissorArrayv defines rectangles, called scissor boxes, in window coordinates
        /// for each viewport. first specifies the index of the first scissor box to modify
        /// and count specifies the number of scissor boxes to modify. first must be less
        /// than the value of GL_MAX_VIEWPORTS, and first + count must be less than or equal
        /// to the value of GL_MAX_VIEWPORTS. v specifies the address of an array containing
        /// integers specifying the lower left corner of the scissor boxes, and the width
        /// and height of the scissor boxes, in that order.
        /// </para>
        /// </summary>
        public static void ScissorArrayv(UInt32 first, Int32 count, Int32[] v)
        {
            Delegates.glScissorArrayv(first, count, v);
        }

        /// <summary>
        /// Define the scissor box for a specific viewport.
        /// <para>
        /// glScissorIndexed defines the scissor box for a specified viewport. index
        /// specifies the index of scissor box to modify. index must be less than the value
        /// of GL_MAX_VIEWPORTS. For glScissorIndexed, left, bottom, width and height
        /// specify the left, bottom, width and height of the scissor box, in pixels,
        /// respectively. For glScissorIndexedv, v specifies the address of an array
        /// containing integers specifying the lower left corner of the scissor box, and the
        /// width and height of the scissor box, in that order.
        /// </para>
        /// </summary>
        public static void ScissorIndexed(UInt32 index, Int32 left, Int32 bottom, Int32 width, Int32 height)
        {
            Delegates.glScissorIndexed(index, left, bottom, width, height);
        }

        /// <summary>
        /// Define the scissor box for a specific viewport.
        /// <para>
        /// glScissorIndexed defines the scissor box for a specified viewport. index
        /// specifies the index of scissor box to modify. index must be less than the value
        /// of GL_MAX_VIEWPORTS. For glScissorIndexed, left, bottom, width and height
        /// specify the left, bottom, width and height of the scissor box, in pixels,
        /// respectively. For glScissorIndexedv, v specifies the address of an array
        /// containing integers specifying the lower left corner of the scissor box, and the
        /// width and height of the scissor box, in that order.
        /// </para>
        /// </summary>
        public static void ScissorIndexedv(UInt32 index, Int32[] v)
        {
            Delegates.glScissorIndexedv(index, v);
        }

        /// <summary>
        /// Load pre-compiled shader binaries.
        /// <para>
        /// glShaderBinary loads pre-compiled shader binary code into the count shader
        /// objects whose handles are given in shaders. binary points to length bytes of
        /// binary shader code stored in client memory. binaryFormat specifies the format of
        /// the pre-compiled code.
        /// </para>
        /// </summary>
        public static void ShaderBinary(Int32 count, UInt32[] shaders, Int32 binaryFormat, IntPtr binary, Int32 length)
        {
            Delegates.glShaderBinary(count, shaders, binaryFormat, binary, length);
        }

        /// <summary>
        /// Replaces the source code in a shader object.
        /// <para>
        /// glShaderSource sets the source code in shader to the source code in the array of
        /// strings specified by string. Any source code previously stored in the shader
        /// object is completely replaced. The number of strings in the array is specified
        /// by count. If length is NULL, each string is assumed to be null terminated. If
        /// length is a value other than NULL, it points to an array containing a string
        /// length for each of the corresponding elements of string. Each element in the
        /// length array may contain the length of the corresponding string (the null
        /// character is not counted as part of the string length) or a value less than 0 to
        /// indicate that the string is null terminated. The source code strings are not
        /// scanned or parsed at this time; they are simply copied into the specified shader
        /// object.
        /// </para>
        /// </summary>
        public static void ShaderSource(UInt32 shader, Int32 count, String[] @string, Int32[] length)
        {
            Delegates.glShaderSource(shader, count, @string, length);
        }

        /// <summary>
        /// Change an active shader storage block binding.
        /// <para>
        /// glShaderStorageBlockBinding, changes the active shader storage block with an
        /// assigned index of storageBlockIndex in program object program. storageBlockIndex
        /// must be an active shader storage block index in program. storageBlockBinding
        /// must be less than the value of GL_MAX_SHADER_STORAGE_BUFFER_BINDINGS. If
        /// successful, glShaderStorageBlockBinding specifies that program will use the data
        /// store of the buffer object bound to the binding point storageBlockBinding to
        /// read and write the values of the buffer variables in the shader storage block
        /// identified by storageBlockIndex.
        /// </para>
        /// </summary>
        public static void ShaderStorageBlockBinding(UInt32 program, UInt32 storageBlockIndex, UInt32 storageBlockBinding)
        {
            Delegates.glShaderStorageBlockBinding(program, storageBlockIndex, storageBlockBinding);
        }

        /// <summary>
        /// Set front and back function and reference value for stencil testing.
        /// <para>
        /// Stenciling, like depth-buffering, enables and disables drawing on a per-pixel
        /// basis. Stencil planes are first drawn into using GL drawing primitives, then
        /// geometry and images are rendered using the stencil planes to mask out portions
        /// of the screen. Stenciling is typically used in multipass rendering algorithms to
        /// achieve special effects, such as decals, outlining, and constructive solid
        /// geometry rendering.
        /// </para>
        /// </summary>
        public static void StencilFunc(OpenGL.StencilFunction func, Int32 @ref, UInt32 mask)
        {
            Delegates.glStencilFunc(func, @ref, mask);
        }

        /// <summary>
        /// Set front and/or back function and reference value for stencil testing.
        /// <para>
        /// Stenciling, like depth-buffering, enables and disables drawing on a per-pixel
        /// basis. You draw into the stencil planes using GL drawing primitives, then render
        /// geometry and images, using the stencil planes to mask out portions of the
        /// screen. Stenciling is typically used in multipass rendering algorithms to
        /// achieve special effects, such as decals, outlining, and constructive solid
        /// geometry rendering.
        /// </para>
        /// </summary>
        public static void StencilFuncSeparate(OpenGL.StencilFace face, OpenGL.StencilFunction func, Int32 @ref, UInt32 mask)
        {
            Delegates.glStencilFuncSeparate(face, func, @ref, mask);
        }

        /// <summary>
        /// Control the front and back writing of individual bits in the stencil planes.
        /// <para>
        /// glStencilMask controls the writing of individual bits in the stencil planes. The
        /// least significant n bits of mask, where n is the number of bits in the stencil
        /// buffer, specify a mask. Where a 1 appears in the mask, it's possible to write to
        /// the corresponding bit in the stencil buffer. Where a 0 appears, the
        /// corresponding bit is write-protected. Initially, all bits are enabled for
        /// writing.
        /// </para>
        /// </summary>
        public static void StencilMask(UInt32 mask)
        {
            Delegates.glStencilMask(mask);
        }

        /// <summary>
        /// Control the front and/or back writing of individual bits in the stencil planes.
        /// <para>
        /// glStencilMaskSeparate controls the writing of individual bits in the stencil
        /// planes. The least significant n bits of mask, where n is the number of bits in
        /// the stencil buffer, specify a mask. Where a 1 appears in the mask, it's possible
        /// to write to the corresponding bit in the stencil buffer. Where a 0 appears, the
        /// corresponding bit is write-protected. Initially, all bits are enabled for
        /// writing.
        /// </para>
        /// </summary>
        public static void StencilMaskSeparate(OpenGL.StencilFace face, UInt32 mask)
        {
            Delegates.glStencilMaskSeparate(face, mask);
        }

        /// <summary>
        /// Set front and back stencil test actions.
        /// <para>
        /// Stenciling, like depth-buffering, enables and disables drawing on a per-pixel
        /// basis. You draw into the stencil planes using GL drawing primitives, then render
        /// geometry and images, using the stencil planes to mask out portions of the
        /// screen. Stenciling is typically used in multipass rendering algorithms to
        /// achieve special effects, such as decals, outlining, and constructive solid
        /// geometry rendering.
        /// </para>
        /// </summary>
        public static void StencilOp(OpenGL.StencilOp sfail, OpenGL.StencilOp dpfail, OpenGL.StencilOp dppass)
        {
            Delegates.glStencilOp(sfail, dpfail, dppass);
        }

        /// <summary>
        /// Set front and/or back stencil test actions.
        /// <para>
        /// Stenciling, like depth-buffering, enables and disables drawing on a per-pixel
        /// basis. You draw into the stencil planes using GL drawing primitives, then render
        /// geometry and images, using the stencil planes to mask out portions of the
        /// screen. Stenciling is typically used in multipass rendering algorithms to
        /// achieve special effects, such as decals, outlining, and constructive solid
        /// geometry rendering.
        /// </para>
        /// </summary>
        public static void StencilOpSeparate(OpenGL.StencilFace face, OpenGL.StencilOp sfail, OpenGL.StencilOp dpfail, OpenGL.StencilOp dppass)
        {
            Delegates.glStencilOpSeparate(face, sfail, dpfail, dppass);
        }

        /// <summary>
        /// Attach a buffer object's data store to a buffer texture object.
        /// <para>
        /// glTexBuffer and glTextureBuffer attaches the data store of a specified buffer
        /// object to a specified texture object, and specify the storage format for the
        /// texture image found found in the buffer object. The texture object must be a
        /// buffer texture.
        /// </para>
        /// </summary>
        public static void TexBuffer(OpenGL.TextureBufferTarget target, OpenGL.SizedInternalFormat internalFormat, UInt32 buffer)
        {
            Delegates.glTexBuffer(target, internalFormat, buffer);
        }

        /// <summary>
        /// Attach a buffer object's data store to a buffer texture object.
        /// <para>
        /// glTexBuffer and glTextureBuffer attaches the data store of a specified buffer
        /// object to a specified texture object, and specify the storage format for the
        /// texture image found found in the buffer object. The texture object must be a
        /// buffer texture.
        /// </para>
        /// </summary>
        public static void TextureBuffer(UInt32 texture, OpenGL.SizedInternalFormat internalFormat, UInt32 buffer)
        {
            Delegates.glTextureBuffer(texture, internalFormat, buffer);
        }

        /// <summary>
        /// Attach a range of a buffer object's data store to a buffer texture object.
        /// <para>
        /// glTexBufferRange and glTextureBufferRange attach a range of the data store of a
        /// specified buffer object to a specified texture object, and specify the storage
        /// format for the texture image found found in the buffer object. The texture
        /// object must be a buffer texture.
        /// </para>
        /// </summary>
        public static void TexBufferRange(OpenGL.BufferTarget target, OpenGL.SizedInternalFormat internalFormat, UInt32 buffer, IntPtr offset, IntPtr size)
        {
            Delegates.glTexBufferRange(target, internalFormat, buffer, offset, size);
        }

        /// <summary>
        /// Attach a range of a buffer object's data store to a buffer texture object.
        /// <para>
        /// glTexBufferRange and glTextureBufferRange attach a range of the data store of a
        /// specified buffer object to a specified texture object, and specify the storage
        /// format for the texture image found found in the buffer object. The texture
        /// object must be a buffer texture.
        /// </para>
        /// </summary>
        public static void TextureBufferRange(UInt32 texture, OpenGL.SizedInternalFormat internalFormat, UInt32 buffer, IntPtr offset, Int32 size)
        {
            Delegates.glTextureBufferRange(texture, internalFormat, buffer, offset, size);
        }

        /// <summary>
        /// Specify a one-dimensional texture image.
        /// <para>
        /// Texturing maps a portion of a specified texture image onto each graphical
        /// primitive for which texturing is enabled. To enable and disable one-dimensional
        /// texturing, call glEnable and glDisable with argument GL_TEXTURE_1D.
        /// </para>
        /// </summary>
        public static void TexImage1D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalFormat, Int32 width, Int32 border, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr data)
        {
            Delegates.glTexImage1D(target, level, internalFormat, width, border, format, type, data);
        }

        /// <summary>
        /// Specify a two-dimensional texture image.
        /// <para>
        /// Texturing allows elements of an image array to be read by shaders.
        /// </para>
        /// </summary>
        public static void TexImage2D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalFormat, Int32 width, Int32 height, Int32 border, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr data)
        {
            Delegates.glTexImage2D(target, level, internalFormat, width, height, border, format, type, data);
        }

        /// <summary>
        /// Establish the data storage, format, dimensions, and number of samples of a multisample texture's image.
        /// <para>
        /// glTexImage2DMultisample establishes the data storage, format, dimensions and
        /// number of samples of a multisample texture's image.
        /// </para>
        /// </summary>
        public static void TexImage2DMultisample(OpenGL.TextureTargetMultisample target, Int32 samples, OpenGL.PixelInternalFormat internalFormat, Int32 width, Int32 height, Boolean fixedsamplelocations)
        {
            Delegates.glTexImage2DMultisample(target, samples, internalFormat, width, height, fixedsamplelocations);
        }

        /// <summary>
        /// Specify a three-dimensional texture image.
        /// <para>
        /// Texturing maps a portion of a specified texture image onto each graphical
        /// primitive for which texturing is enabled. To enable and disable
        /// three-dimensional texturing, call glEnable and glDisable with argument
        /// GL_TEXTURE_3D.
        /// </para>
        /// </summary>
        public static void TexImage3D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalFormat, Int32 width, Int32 height, Int32 depth, Int32 border, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr data)
        {
            Delegates.glTexImage3D(target, level, internalFormat, width, height, depth, border, format, type, data);
        }

        /// <summary>
        /// Establish the data storage, format, dimensions, and number of samples of a multisample texture's image.
        /// <para>
        /// glTexImage3DMultisample establishes the data storage, format, dimensions and
        /// number of samples of a multisample texture's image.
        /// </para>
        /// </summary>
        public static void TexImage3DMultisample(OpenGL.TextureTargetMultisample target, Int32 samples, OpenGL.PixelInternalFormat internalFormat, Int32 width, Int32 height, Int32 depth, Boolean fixedsamplelocations)
        {
            Delegates.glTexImage3DMultisample(target, samples, internalFormat, width, height, depth, fixedsamplelocations);
        }

        /// <summary>
        /// Set texture parameters.
        /// <para>
        /// glTexParameter and glTextureParameter assign the value or values in params to
        /// the texture parameter specified as pname. For glTexParameter, target defines the
        /// target texture, either GL_TEXTURE_1D, GL_TEXTURE_1D_ARRAY, GL_TEXTURE_2D,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, GL_TEXTURE_2D_MULTISAMPLE_ARRAY,
        /// GL_TEXTURE_3D, GL_TEXTURE_CUBE_MAP, GL_TEXTURE_CUBE_MAP_ARRAY, or
        /// GL_TEXTURE_RECTANGLE. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void TexParameterf(OpenGL.TextureTarget target, OpenGL.TextureParameterName pname, Single param)
        {
            Delegates.glTexParameterf(target, pname, param);
        }

        /// <summary>
        /// Set texture parameters.
        /// <para>
        /// glTexParameter and glTextureParameter assign the value or values in params to
        /// the texture parameter specified as pname. For glTexParameter, target defines the
        /// target texture, either GL_TEXTURE_1D, GL_TEXTURE_1D_ARRAY, GL_TEXTURE_2D,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, GL_TEXTURE_2D_MULTISAMPLE_ARRAY,
        /// GL_TEXTURE_3D, GL_TEXTURE_CUBE_MAP, GL_TEXTURE_CUBE_MAP_ARRAY, or
        /// GL_TEXTURE_RECTANGLE. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void TexParameteri(OpenGL.TextureTarget target, OpenGL.TextureParameterName pname, Int32 param)
        {
            Delegates.glTexParameteri(target, pname, param);
        }

        /// <summary>
        /// Set texture parameters.
        /// <para>
        /// glTexParameter and glTextureParameter assign the value or values in params to
        /// the texture parameter specified as pname. For glTexParameter, target defines the
        /// target texture, either GL_TEXTURE_1D, GL_TEXTURE_1D_ARRAY, GL_TEXTURE_2D,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, GL_TEXTURE_2D_MULTISAMPLE_ARRAY,
        /// GL_TEXTURE_3D, GL_TEXTURE_CUBE_MAP, GL_TEXTURE_CUBE_MAP_ARRAY, or
        /// GL_TEXTURE_RECTANGLE. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void TextureParameterf(UInt32 texture, OpenGL.TextureParameter pname, Single param)
        {
            Delegates.glTextureParameterf(texture, pname, param);
        }

        /// <summary>
        /// Set texture parameters.
        /// <para>
        /// glTexParameter and glTextureParameter assign the value or values in params to
        /// the texture parameter specified as pname. For glTexParameter, target defines the
        /// target texture, either GL_TEXTURE_1D, GL_TEXTURE_1D_ARRAY, GL_TEXTURE_2D,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, GL_TEXTURE_2D_MULTISAMPLE_ARRAY,
        /// GL_TEXTURE_3D, GL_TEXTURE_CUBE_MAP, GL_TEXTURE_CUBE_MAP_ARRAY, or
        /// GL_TEXTURE_RECTANGLE. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void TextureParameteri(UInt32 texture, OpenGL.TextureParameter pname, Int32 param)
        {
            Delegates.glTextureParameteri(texture, pname, param);
        }

        /// <summary>
        /// Set texture parameters.
        /// <para>
        /// glTexParameter and glTextureParameter assign the value or values in params to
        /// the texture parameter specified as pname. For glTexParameter, target defines the
        /// target texture, either GL_TEXTURE_1D, GL_TEXTURE_1D_ARRAY, GL_TEXTURE_2D,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, GL_TEXTURE_2D_MULTISAMPLE_ARRAY,
        /// GL_TEXTURE_3D, GL_TEXTURE_CUBE_MAP, GL_TEXTURE_CUBE_MAP_ARRAY, or
        /// GL_TEXTURE_RECTANGLE. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void TexParameterfv(OpenGL.TextureTarget target, OpenGL.TextureParameterName pname, Single[] @params)
        {
            Delegates.glTexParameterfv(target, pname, @params);
        }

        /// <summary>
        /// Set texture parameters.
        /// <para>
        /// glTexParameter and glTextureParameter assign the value or values in params to
        /// the texture parameter specified as pname. For glTexParameter, target defines the
        /// target texture, either GL_TEXTURE_1D, GL_TEXTURE_1D_ARRAY, GL_TEXTURE_2D,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, GL_TEXTURE_2D_MULTISAMPLE_ARRAY,
        /// GL_TEXTURE_3D, GL_TEXTURE_CUBE_MAP, GL_TEXTURE_CUBE_MAP_ARRAY, or
        /// GL_TEXTURE_RECTANGLE. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void TexParameteriv(OpenGL.TextureTarget target, OpenGL.TextureParameterName pname, Int32[] @params)
        {
            Delegates.glTexParameteriv(target, pname, @params);
        }

        /// <summary>
        /// Set texture parameters.
        /// <para>
        /// glTexParameter and glTextureParameter assign the value or values in params to
        /// the texture parameter specified as pname. For glTexParameter, target defines the
        /// target texture, either GL_TEXTURE_1D, GL_TEXTURE_1D_ARRAY, GL_TEXTURE_2D,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, GL_TEXTURE_2D_MULTISAMPLE_ARRAY,
        /// GL_TEXTURE_3D, GL_TEXTURE_CUBE_MAP, GL_TEXTURE_CUBE_MAP_ARRAY, or
        /// GL_TEXTURE_RECTANGLE. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void TexParameterIiv(OpenGL.TextureTarget target, OpenGL.TextureParameterName pname, Int32[] @params)
        {
            Delegates.glTexParameterIiv(target, pname, @params);
        }

        /// <summary>
        /// Set texture parameters.
        /// <para>
        /// glTexParameter and glTextureParameter assign the value or values in params to
        /// the texture parameter specified as pname. For glTexParameter, target defines the
        /// target texture, either GL_TEXTURE_1D, GL_TEXTURE_1D_ARRAY, GL_TEXTURE_2D,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, GL_TEXTURE_2D_MULTISAMPLE_ARRAY,
        /// GL_TEXTURE_3D, GL_TEXTURE_CUBE_MAP, GL_TEXTURE_CUBE_MAP_ARRAY, or
        /// GL_TEXTURE_RECTANGLE. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void TexParameterIuiv(OpenGL.TextureTarget target, OpenGL.TextureParameterName pname, UInt32[] @params)
        {
            Delegates.glTexParameterIuiv(target, pname, @params);
        }

        /// <summary>
        /// Set texture parameters.
        /// <para>
        /// glTexParameter and glTextureParameter assign the value or values in params to
        /// the texture parameter specified as pname. For glTexParameter, target defines the
        /// target texture, either GL_TEXTURE_1D, GL_TEXTURE_1D_ARRAY, GL_TEXTURE_2D,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, GL_TEXTURE_2D_MULTISAMPLE_ARRAY,
        /// GL_TEXTURE_3D, GL_TEXTURE_CUBE_MAP, GL_TEXTURE_CUBE_MAP_ARRAY, or
        /// GL_TEXTURE_RECTANGLE. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void TextureParameterfv(UInt32 texture, OpenGL.TextureParameter pname, Single[] paramtexture)
        {
            Delegates.glTextureParameterfv(texture, pname, paramtexture);
        }

        /// <summary>
        /// Set texture parameters.
        /// <para>
        /// glTexParameter and glTextureParameter assign the value or values in params to
        /// the texture parameter specified as pname. For glTexParameter, target defines the
        /// target texture, either GL_TEXTURE_1D, GL_TEXTURE_1D_ARRAY, GL_TEXTURE_2D,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, GL_TEXTURE_2D_MULTISAMPLE_ARRAY,
        /// GL_TEXTURE_3D, GL_TEXTURE_CUBE_MAP, GL_TEXTURE_CUBE_MAP_ARRAY, or
        /// GL_TEXTURE_RECTANGLE. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void TextureParameteriv(UInt32 texture, OpenGL.TextureParameter pname, Int32[] param)
        {
            Delegates.glTextureParameteriv(texture, pname, param);
        }

        /// <summary>
        /// Set texture parameters.
        /// <para>
        /// glTexParameter and glTextureParameter assign the value or values in params to
        /// the texture parameter specified as pname. For glTexParameter, target defines the
        /// target texture, either GL_TEXTURE_1D, GL_TEXTURE_1D_ARRAY, GL_TEXTURE_2D,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, GL_TEXTURE_2D_MULTISAMPLE_ARRAY,
        /// GL_TEXTURE_3D, GL_TEXTURE_CUBE_MAP, GL_TEXTURE_CUBE_MAP_ARRAY, or
        /// GL_TEXTURE_RECTANGLE. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void TextureParameterIiv(UInt32 texture, OpenGL.TextureParameter pname, Int32[] @params)
        {
            Delegates.glTextureParameterIiv(texture, pname, @params);
        }

        /// <summary>
        /// Set texture parameters.
        /// <para>
        /// glTexParameter and glTextureParameter assign the value or values in params to
        /// the texture parameter specified as pname. For glTexParameter, target defines the
        /// target texture, either GL_TEXTURE_1D, GL_TEXTURE_1D_ARRAY, GL_TEXTURE_2D,
        /// GL_TEXTURE_2D_ARRAY, GL_TEXTURE_2D_MULTISAMPLE, GL_TEXTURE_2D_MULTISAMPLE_ARRAY,
        /// GL_TEXTURE_3D, GL_TEXTURE_CUBE_MAP, GL_TEXTURE_CUBE_MAP_ARRAY, or
        /// GL_TEXTURE_RECTANGLE. The following symbols are accepted in pname:.
        /// </para>
        /// </summary>
        public static void TextureParameterIuiv(UInt32 texture, OpenGL.TextureParameter pname, UInt32[] @params)
        {
            Delegates.glTextureParameterIuiv(texture, pname, @params);
        }

        /// <summary>
        /// Simultaneously specify storage for all levels of a one-dimensional texture.
        /// <para>
        /// glTexStorage1D and glTextureStorage1D specify the storage requirements for all
        /// levels of a one-dimensional texture simultaneously. Once a texture is specified
        /// with this command, the format and dimensions of all levels become immutable
        /// unless it is a proxy texture. The contents of the image may still be modified,
        /// however, its storage requirements may not change. Such a texture is referred to
        /// as an immutable-format texture.
        /// </para>
        /// </summary>
        public static void TexStorage1D(OpenGL.TextureTarget target, Int32 levels, OpenGL.SizedInternalFormat internalFormat, Int32 width)
        {
            Delegates.glTexStorage1D(target, levels, internalFormat, width);
        }

        /// <summary>
        /// Simultaneously specify storage for all levels of a one-dimensional texture.
        /// <para>
        /// glTexStorage1D and glTextureStorage1D specify the storage requirements for all
        /// levels of a one-dimensional texture simultaneously. Once a texture is specified
        /// with this command, the format and dimensions of all levels become immutable
        /// unless it is a proxy texture. The contents of the image may still be modified,
        /// however, its storage requirements may not change. Such a texture is referred to
        /// as an immutable-format texture.
        /// </para>
        /// </summary>
        public static void TextureStorage1D(UInt32 texture, Int32 levels, OpenGL.SizedInternalFormat internalFormat, Int32 width)
        {
            Delegates.glTextureStorage1D(texture, levels, internalFormat, width);
        }

        /// <summary>
        /// Simultaneously specify storage for all levels of a two-dimensional or one-dimensional array texture.
        /// <para>
        /// glTexStorage2D and glTextureStorage2D specify the storage requirements for all
        /// levels of a two-dimensional texture or one-dimensional texture array
        /// simultaneously. Once a texture is specified with this command, the format and
        /// dimensions of all levels become immutable unless it is a proxy texture. The
        /// contents of the image may still be modified, however, its storage requirements
        /// may not change. Such a texture is referred to as an immutable-format texture.
        /// </para>
        /// </summary>
        public static void TexStorage2D(OpenGL.TextureTarget target, Int32 levels, OpenGL.SizedInternalFormat internalFormat, Int32 width, Int32 height)
        {
            Delegates.glTexStorage2D(target, levels, internalFormat, width, height);
        }

        /// <summary>
        /// Simultaneously specify storage for all levels of a two-dimensional or one-dimensional array texture.
        /// <para>
        /// glTexStorage2D and glTextureStorage2D specify the storage requirements for all
        /// levels of a two-dimensional texture or one-dimensional texture array
        /// simultaneously. Once a texture is specified with this command, the format and
        /// dimensions of all levels become immutable unless it is a proxy texture. The
        /// contents of the image may still be modified, however, its storage requirements
        /// may not change. Such a texture is referred to as an immutable-format texture.
        /// </para>
        /// </summary>
        public static void TextureStorage2D(UInt32 texture, Int32 levels, OpenGL.SizedInternalFormat internalFormat, Int32 width, Int32 height)
        {
            Delegates.glTextureStorage2D(texture, levels, internalFormat, width, height);
        }

        /// <summary>
        /// Specify storage for a two-dimensional multisample texture.
        /// <para>
        /// glTexStorage2DMultisample and glTextureStorage2DMultisample specify the storage
        /// requirements for a two-dimensional multisample texture. Once a texture is
        /// specified with this command, its format and dimensions become immutable unless
        /// it is a proxy texture. The contents of the image may still be modified, however,
        /// its storage requirements may not change. Such a texture is referred to as an
        /// immutable-format texture.
        /// </para>
        /// </summary>
        public static void TexStorage2DMultisample(OpenGL.TextureTarget target, Int32 samples, OpenGL.SizedInternalFormat internalFormat, Int32 width, Int32 height, Boolean fixedsamplelocations)
        {
            Delegates.glTexStorage2DMultisample(target, samples, internalFormat, width, height, fixedsamplelocations);
        }

        /// <summary>
        /// Specify storage for a two-dimensional multisample texture.
        /// <para>
        /// glTexStorage2DMultisample and glTextureStorage2DMultisample specify the storage
        /// requirements for a two-dimensional multisample texture. Once a texture is
        /// specified with this command, its format and dimensions become immutable unless
        /// it is a proxy texture. The contents of the image may still be modified, however,
        /// its storage requirements may not change. Such a texture is referred to as an
        /// immutable-format texture.
        /// </para>
        /// </summary>
        public static void TextureStorage2DMultisample(UInt32 texture, Int32 samples, OpenGL.SizedInternalFormat internalFormat, Int32 width, Int32 height, Boolean fixedsamplelocations)
        {
            Delegates.glTextureStorage2DMultisample(texture, samples, internalFormat, width, height, fixedsamplelocations);
        }

        /// <summary>
        /// Simultaneously specify storage for all levels of a three-dimensional, two-dimensional array or cube-map array texture.
        /// <para>
        /// glTexStorage3D and glTextureStorage3D specify specify the storage requirements
        /// for all levels of a three-dimensional, two-dimensional array or cube-map array
        /// texture simultaneously. Once a texture is specified with this command, the
        /// format and dimensions of all levels become immutable unless it is a proxy
        /// texture. The contents of the image may still be modified, however, its storage
        /// requirements may not change. Such a texture is referred to as an
        /// immutable-format texture.
        /// </para>
        /// </summary>
        public static void TexStorage3D(OpenGL.TextureTarget target, Int32 levels, OpenGL.SizedInternalFormat internalFormat, Int32 width, Int32 height, Int32 depth)
        {
            Delegates.glTexStorage3D(target, levels, internalFormat, width, height, depth);
        }

        /// <summary>
        /// Simultaneously specify storage for all levels of a three-dimensional, two-dimensional array or cube-map array texture.
        /// <para>
        /// glTexStorage3D and glTextureStorage3D specify specify the storage requirements
        /// for all levels of a three-dimensional, two-dimensional array or cube-map array
        /// texture simultaneously. Once a texture is specified with this command, the
        /// format and dimensions of all levels become immutable unless it is a proxy
        /// texture. The contents of the image may still be modified, however, its storage
        /// requirements may not change. Such a texture is referred to as an
        /// immutable-format texture.
        /// </para>
        /// </summary>
        public static void TextureStorage3D(UInt32 texture, Int32 levels, OpenGL.SizedInternalFormat internalFormat, Int32 width, Int32 height, Int32 depth)
        {
            Delegates.glTextureStorage3D(texture, levels, internalFormat, width, height, depth);
        }

        /// <summary>
        /// Specify storage for a two-dimensional multisample array texture.
        /// <para>
        /// glTexStorage3DMultisample and glTextureStorage3DMultisample specify the storage
        /// requirements for a two-dimensional multisample array texture. Once a texture is
        /// specified with this command, its format and dimensions become immutable unless
        /// it is a proxy texture. The contents of the image may still be modified, however,
        /// its storage requirements may not change. Such a texture is referred to as an
        /// immutable-format texture.
        /// </para>
        /// </summary>
        public static void TexStorage3DMultisample(OpenGL.TextureTarget target, Int32 samples, OpenGL.SizedInternalFormat internalFormat, Int32 width, Int32 height, Int32 depth, Boolean fixedsamplelocations)
        {
            Delegates.glTexStorage3DMultisample(target, samples, internalFormat, width, height, depth, fixedsamplelocations);
        }

        /// <summary>
        /// Specify storage for a two-dimensional multisample array texture.
        /// <para>
        /// glTexStorage3DMultisample and glTextureStorage3DMultisample specify the storage
        /// requirements for a two-dimensional multisample array texture. Once a texture is
        /// specified with this command, its format and dimensions become immutable unless
        /// it is a proxy texture. The contents of the image may still be modified, however,
        /// its storage requirements may not change. Such a texture is referred to as an
        /// immutable-format texture.
        /// </para>
        /// </summary>
        public static void TextureStorage3DMultisample(UInt32 texture, Int32 samples, OpenGL.SizedInternalFormat internalFormat, Int32 width, Int32 height, Int32 depth, Boolean fixedsamplelocations)
        {
            Delegates.glTextureStorage3DMultisample(texture, samples, internalFormat, width, height, depth, fixedsamplelocations);
        }

        /// <summary>
        /// Specify a one-dimensional texture subimage.
        /// <para>
        /// Texturing maps a portion of a specified texture image onto each graphical
        /// primitive for which texturing is enabled. To enable or disable one-dimensional
        /// texturing, call glEnable and glDisable with argument GL_TEXTURE_1D.
        /// </para>
        /// </summary>
        public static void TexSubImage1D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 width, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels)
        {
            Delegates.glTexSubImage1D(target, level, xoffset, width, format, type, pixels);
        }

        /// <summary>
        /// Specify a one-dimensional texture subimage.
        /// <para>
        /// Texturing maps a portion of a specified texture image onto each graphical
        /// primitive for which texturing is enabled. To enable or disable one-dimensional
        /// texturing, call glEnable and glDisable with argument GL_TEXTURE_1D.
        /// </para>
        /// </summary>
        public static void TextureSubImage1D(UInt32 texture, Int32 level, Int32 xoffset, Int32 width, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels)
        {
            Delegates.glTextureSubImage1D(texture, level, xoffset, width, format, type, pixels);
        }

        /// <summary>
        /// Specify a two-dimensional texture subimage.
        /// <para>
        /// Texturing maps a portion of a specified texture image onto each graphical
        /// primitive for which texturing is enabled.
        /// </para>
        /// </summary>
        public static void TexSubImage2D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels)
        {
            Delegates.glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels);
        }

        /// <summary>
        /// Specify a two-dimensional texture subimage.
        /// <para>
        /// Texturing maps a portion of a specified texture image onto each graphical
        /// primitive for which texturing is enabled.
        /// </para>
        /// </summary>
        public static void TextureSubImage2D(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels)
        {
            Delegates.glTextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, type, pixels);
        }

        /// <summary>
        /// Specify a three-dimensional texture subimage.
        /// <para>
        /// Texturing maps a portion of a specified texture image onto each graphical
        /// primitive for which texturing is enabled.
        /// </para>
        /// </summary>
        public static void TexSubImage3D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels)
        {
            Delegates.glTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
        }

        /// <summary>
        /// Specify a three-dimensional texture subimage.
        /// <para>
        /// Texturing maps a portion of a specified texture image onto each graphical
        /// primitive for which texturing is enabled.
        /// </para>
        /// </summary>
        public static void TextureSubImage3D(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels)
        {
            Delegates.glTextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
        }

        /// <summary>
        /// Controls the ordering of reads and writes to rendered fragments across drawing commands.
        /// <para>
        /// The values of rendered fragments are undefined when a shader stage fetches
        /// texels and the same texels are written via fragment shader outputs, even if the
        /// reads and writes are not in the same drawing command. To safely read the result
        /// of a written texel via a texel fetch in a subsequent drawing command, call
        /// glTextureBarrier between the two drawing commands to guarantee that writes have
        /// completed and caches have been invalidated before subsequent drawing commands
        /// are executed.
        /// </para>
        /// </summary>
        public static void TextureBarrier()
        {
            Delegates.glTextureBarrier();
        }

        /// <summary>
        /// Initialize a texture as a data alias of another texture's data store.
        /// <para>
        /// glTextureView initializes a texture object as an alias, or view of another
        /// texture object, sharing some or all of the parent texture's data store with the
        /// initialized texture. texture specifies a name previously reserved by a
        /// successful call to glGenTextures but that has not yet been bound or given a
        /// target. target specifies the target for the newly initialized texture and must
        /// be compatible with the target of the parent texture, given in origtexture as
        /// specified in the following table:.
        /// </para>
        /// </summary>
        public static void TextureView(UInt32 texture, OpenGL.TextureTarget target, UInt32 origtexture, OpenGL.PixelInternalFormat internalFormat, UInt32 minlevel, UInt32 numlevels, UInt32 minlayer, UInt32 numlayers)
        {
            Delegates.glTextureView(texture, target, origtexture, internalFormat, minlevel, numlevels, minlayer, numlayers);
        }

        /// <summary>
        /// Bind a buffer object to a transform feedback buffer object.
        /// <para>
        /// glTransformFeedbackBufferBase binds the buffer object buffer to the binding
        /// point at index index of the transform feedback object xfb.
        /// </para>
        /// </summary>
        public static void TransformFeedbackBufferBase(UInt32 xfb, UInt32 index, UInt32 buffer)
        {
            Delegates.glTransformFeedbackBufferBase(xfb, index, buffer);
        }

        /// <summary>
        /// Bind a range within a buffer object to a transform feedback buffer object.
        /// <para>
        /// glTransformFeedbackBufferRange binds a range of the buffer object buffer
        /// represented by offset and size to the binding point at index index of the
        /// transform feedback object xfb.
        /// </para>
        /// </summary>
        public static void TransformFeedbackBufferRange(UInt32 xfb, UInt32 index, UInt32 buffer, IntPtr offset, Int32 size)
        {
            Delegates.glTransformFeedbackBufferRange(xfb, index, buffer, offset, size);
        }

        /// <summary>
        /// Specify values to record in transform feedback buffers.
        /// <para>
        /// The names of the vertex or geometry shader outputs to be recorded in transform
        /// feedback mode are specified using glTransformFeedbackVaryings. When a geometry
        /// shader is active, transform feedback records the values of selected geometry
        /// shader output variables from the emitted vertices. Otherwise, the values of the
        /// selected vertex shader outputs are recorded.
        /// </para>
        /// </summary>
        public static void TransformFeedbackVaryings(UInt32 program, Int32 count, String[] varyings, OpenGL.TransformFeedbackMode bufferMode)
        {
            Delegates.glTransformFeedbackVaryings(program, count, varyings, bufferMode);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform1f(Int32 location, Single v0)
        {
            Delegates.glUniform1f(location, v0);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform2f(Int32 location, Single v0, Single v1)
        {
            Delegates.glUniform2f(location, v0, v1);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform3f(Int32 location, Single v0, Single v1, Single v2)
        {
            Delegates.glUniform3f(location, v0, v1, v2);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform4f(Int32 location, Single v0, Single v1, Single v2, Single v3)
        {
            Delegates.glUniform4f(location, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform1i(Int32 location, Int32 v0)
        {
            Delegates.glUniform1i(location, v0);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform2i(Int32 location, Int32 v0, Int32 v1)
        {
            Delegates.glUniform2i(location, v0, v1);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform3i(Int32 location, Int32 v0, Int32 v1, Int32 v2)
        {
            Delegates.glUniform3i(location, v0, v1, v2);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform4i(Int32 location, Int32 v0, Int32 v1, Int32 v2, Int32 v3)
        {
            Delegates.glUniform4i(location, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform1ui(Int32 location, UInt32 v0)
        {
            Delegates.glUniform1ui(location, v0);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform2ui(Int32 location, UInt32 v0, UInt32 v1)
        {
            Delegates.glUniform2ui(location, v0, v1);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform3ui(Int32 location, UInt32 v0, UInt32 v1, UInt32 v2)
        {
            Delegates.glUniform3ui(location, v0, v1, v2);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform4ui(Int32 location, UInt32 v0, UInt32 v1, UInt32 v2, UInt32 v3)
        {
            Delegates.glUniform4ui(location, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform1fv(Int32 location, Int32 count, Single[] value)
        {
            Delegates.glUniform1fv(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform2fv(Int32 location, Int32 count, Single[] value)
        {
            Delegates.glUniform2fv(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform3fv(Int32 location, Int32 count, Single[] value)
        {
            Delegates.glUniform3fv(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform4fv(Int32 location, Int32 count, Single[] value)
        {
            Delegates.glUniform4fv(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform1iv(Int32 location, Int32 count, Int32[] value)
        {
            Delegates.glUniform1iv(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform2iv(Int32 location, Int32 count, Int32[] value)
        {
            Delegates.glUniform2iv(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform3iv(Int32 location, Int32 count, Int32[] value)
        {
            Delegates.glUniform3iv(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform4iv(Int32 location, Int32 count, Int32[] value)
        {
            Delegates.glUniform4iv(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform1uiv(Int32 location, Int32 count, UInt32[] value)
        {
            Delegates.glUniform1uiv(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform2uiv(Int32 location, Int32 count, UInt32[] value)
        {
            Delegates.glUniform2uiv(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform3uiv(Int32 location, Int32 count, UInt32[] value)
        {
            Delegates.glUniform3uiv(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void Uniform4uiv(Int32 location, Int32 count, UInt32[] value)
        {
            Delegates.glUniform4uiv(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void UniformMatrix2fv(Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glUniformMatrix2fv(location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void UniformMatrix3fv(Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glUniformMatrix3fv(location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void UniformMatrix4fv(Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glUniformMatrix4fv(location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void UniformMatrix2x3fv(Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glUniformMatrix2x3fv(location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void UniformMatrix3x2fv(Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glUniformMatrix3x2fv(location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void UniformMatrix2x4fv(Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glUniformMatrix2x4fv(location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void UniformMatrix4x2fv(Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glUniformMatrix4x2fv(location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void UniformMatrix3x4fv(Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glUniformMatrix3x4fv(location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object.
        /// <para>
        /// glUniform modifies the value of a uniform variable or a uniform variable array.
        /// The location of the uniform variable to be modified is specified by location,
        /// which should be a value returned by glGetUniformLocation. glUniform operates on
        /// the program object that was made part of current state by calling glUseProgram.
        /// </para>
        /// </summary>
        public static void UniformMatrix4x3fv(Int32 location, Int32 count, Boolean transpose, Single[] value)
        {
            Delegates.glUniformMatrix4x3fv(location, count, transpose, value);
        }

        /// <summary>
        /// Assign a binding point to an active uniform block.
        /// <para>
        /// Binding points for active uniform blocks are assigned using
        /// glUniformBlockBinding. Each of a program's active uniform blocks has a
        /// corresponding uniform buffer binding point. program is the name of a program
        /// object for which the command glLinkProgram has been issued in the past.
        /// </para>
        /// </summary>
        public static void UniformBlockBinding(UInt32 program, UInt32 uniformBlockIndex, UInt32 uniformBlockBinding)
        {
            Delegates.glUniformBlockBinding(program, uniformBlockIndex, uniformBlockBinding);
        }

        /// <summary>
        /// Load active subroutine uniforms.
        /// <para>
        /// glUniformSubroutines loads all active subroutine uniforms for shader stage
        /// shadertype of the current program with subroutine indices from indices, storing
        /// indices[i] into the uniform at location i. count must be equal to the value of
        /// GL_ACTIVE_SUBROUTINE_UNIFORM_LOCATIONS for the program currently in use at
        /// shader stage shadertype. Furthermore, all values in indices must be less than
        /// the value of GL_ACTIVE_SUBROUTINES for the shader stage.
        /// </para>
        /// </summary>
        public static void UniformSubroutinesuiv(OpenGL.ShaderType shadertype, Int32 count, UInt32[] indices)
        {
            Delegates.glUniformSubroutinesuiv(shadertype, count, indices);
        }

        /// <summary>
        /// Release the mapping of a buffer object's data store into the client's address space.
        /// <para>
        /// glUnmapBuffer and glUnmapNamedBuffer unmap (release) any mapping of a specified
        /// buffer object into the client's address space (see glMapBufferRange and
        /// glMapBuffer).
        /// </para>
        /// </summary>
        public static Boolean UnmapBuffer(OpenGL.BufferTarget target)
        {
            return Delegates.glUnmapBuffer(target);
        }

        /// <summary>
        /// Release the mapping of a buffer object's data store into the client's address space.
        /// <para>
        /// glUnmapBuffer and glUnmapNamedBuffer unmap (release) any mapping of a specified
        /// buffer object into the client's address space (see glMapBufferRange and
        /// glMapBuffer).
        /// </para>
        /// </summary>
        public static Boolean UnmapNamedBuffer(UInt32 buffer)
        {
            return Delegates.glUnmapNamedBuffer(buffer);
        }

        /// <summary>
        /// Installs a program object as part of current rendering state.
        /// <para>
        /// glUseProgram installs the program object specified by program as part of current
        /// rendering state. One or more executables are created in a program object by
        /// successfully attaching shader objects to it with glAttachShader, successfully
        /// compiling the shader objects with glCompileShader, and successfully linking the
        /// program object with glLinkProgram.
        /// </para>
        /// </summary>
        public static void UseProgram(UInt32 program)
        {
            Gl.currentProgram = program;
            Delegates.glUseProgram(program);
        }

        /// <summary>
        /// Bind stages of a program object to a program pipeline.
        /// <para>
        /// glUseProgramStages binds executables from a program object associated with a
        /// specified set of shader stages to the program pipeline object given by pipeline.
        /// pipeline specifies the program pipeline object to which to bind the executables.
        /// stages contains a logical combination of bits indicating the shader stages to
        /// use within program with the program pipeline object pipeline. stages must be a
        /// logical combination of GL_VERTEX_SHADER_BIT, GL_TESS_CONTROL_SHADER_BIT,
        /// GL_TESS_EVALUATION_SHADER_BIT, GL_GEOMETRY_SHADER_BIT, GL_FRAGMENT_SHADER_BIT
        /// and GL_COMPUTE_SHADER_BIT. Additionally, the special value GL_ALL_SHADER_BITS
        /// may be specified to indicate that all executables contained in program should be
        /// installed in pipeline.
        /// </para>
        /// </summary>
        public static void UseProgramStages(UInt32 pipeline, UInt32 stages, UInt32 program)
        {
            Gl.currentProgram = program;
            Delegates.glUseProgramStages(pipeline, stages, program);
        }

        /// <summary>
        /// Validates a program object.
        /// <para>
        /// glValidateProgram checks to see whether the executables contained in program can
        /// execute given the current OpenGL state. The information generated by the
        /// validation process will be stored in program's information log. The validation
        /// information may consist of an empty string, or it may be a string containing
        /// information about how the current program object interacts with the rest of
        /// current OpenGL state. This provides a way for OpenGL implementers to convey more
        /// information about why the current program is inefficient, suboptimal, failing to
        /// execute, and so on.
        /// </para>
        /// </summary>
        public static void ValidateProgram(UInt32 program)
        {
            Delegates.glValidateProgram(program);
        }

        /// <summary>
        /// Validate a program pipeline object against current GL state.
        /// <para>
        /// glValidateProgramPipeline instructs the implementation to validate the shader
        /// executables contained in pipeline against the current GL state. The
        /// implementation may use this as an opportunity to perform any internal shader
        /// modifications that may be required to ensure correct operation of the installed
        /// shaders given the current GL state.
        /// </para>
        /// </summary>
        public static void ValidateProgramPipeline(UInt32 pipeline)
        {
            Delegates.glValidateProgramPipeline(pipeline);
        }

        /// <summary>
        /// Configures element array buffer binding of a vertex array object.
        /// <para>
        /// glVertexArrayElementBuffer binds a buffer object with id buffer to the element
        /// array buffer bind point of a vertex array object with id vaobj. If buffer is
        /// zero, any existing element array buffer binding to vaobj is removed.
        /// </para>
        /// </summary>
        public static void VertexArrayElementBuffer(UInt32 vaobj, UInt32 buffer)
        {
            Delegates.glVertexArrayElementBuffer(vaobj, buffer);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib1f(UInt32 index, Single v0)
        {
            Delegates.glVertexAttrib1f(index, v0);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib1f(Int32 index, Single v0)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib1f((UInt32)index, v0);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib1s(UInt32 index, Int16 v0)
        {
            Delegates.glVertexAttrib1s(index, v0);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib1s(Int32 index, Int16 v0)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib1s((UInt32)index, v0);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib1d(UInt32 index, Double v0)
        {
            Delegates.glVertexAttrib1d(index, v0);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib1d(Int32 index, Double v0)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib1d((UInt32)index, v0);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI1i(UInt32 index, Int32 v0)
        {
            Delegates.glVertexAttribI1i(index, v0);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI1i(Int32 index, Int32 v0)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI1i((UInt32)index, v0);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI1ui(UInt32 index, UInt32 v0)
        {
            Delegates.glVertexAttribI1ui(index, v0);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI1ui(Int32 index, UInt32 v0)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI1ui((UInt32)index, v0);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib2f(UInt32 index, Single v0, Single v1)
        {
            Delegates.glVertexAttrib2f(index, v0, v1);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib2f(Int32 index, Single v0, Single v1)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib2f((UInt32)index, v0, v1);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib2s(UInt32 index, Int16 v0, Int16 v1)
        {
            Delegates.glVertexAttrib2s(index, v0, v1);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib2s(Int32 index, Int16 v0, Int16 v1)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib2s((UInt32)index, v0, v1);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib2d(UInt32 index, Double v0, Double v1)
        {
            Delegates.glVertexAttrib2d(index, v0, v1);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib2d(Int32 index, Double v0, Double v1)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib2d((UInt32)index, v0, v1);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI2i(UInt32 index, Int32 v0, Int32 v1)
        {
            Delegates.glVertexAttribI2i(index, v0, v1);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI2i(Int32 index, Int32 v0, Int32 v1)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI2i((UInt32)index, v0, v1);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI2ui(UInt32 index, UInt32 v0, UInt32 v1)
        {
            Delegates.glVertexAttribI2ui(index, v0, v1);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI2ui(Int32 index, UInt32 v0, UInt32 v1)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI2ui((UInt32)index, v0, v1);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib3f(UInt32 index, Single v0, Single v1, Single v2)
        {
            Delegates.glVertexAttrib3f(index, v0, v1, v2);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib3f(Int32 index, Single v0, Single v1, Single v2)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib3f((UInt32)index, v0, v1, v2);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib3s(UInt32 index, Int16 v0, Int16 v1, Int16 v2)
        {
            Delegates.glVertexAttrib3s(index, v0, v1, v2);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib3s(Int32 index, Int16 v0, Int16 v1, Int16 v2)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib3s((UInt32)index, v0, v1, v2);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib3d(UInt32 index, Double v0, Double v1, Double v2)
        {
            Delegates.glVertexAttrib3d(index, v0, v1, v2);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib3d(Int32 index, Double v0, Double v1, Double v2)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib3d((UInt32)index, v0, v1, v2);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI3i(UInt32 index, Int32 v0, Int32 v1, Int32 v2)
        {
            Delegates.glVertexAttribI3i(index, v0, v1, v2);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI3i(Int32 index, Int32 v0, Int32 v1, Int32 v2)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI3i((UInt32)index, v0, v1, v2);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI3ui(UInt32 index, UInt32 v0, UInt32 v1, UInt32 v2)
        {
            Delegates.glVertexAttribI3ui(index, v0, v1, v2);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI3ui(Int32 index, UInt32 v0, UInt32 v1, UInt32 v2)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI3ui((UInt32)index, v0, v1, v2);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4f(UInt32 index, Single v0, Single v1, Single v2, Single v3)
        {
            Delegates.glVertexAttrib4f(index, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4f(Int32 index, Single v0, Single v1, Single v2, Single v3)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4f((UInt32)index, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4s(UInt32 index, Int16 v0, Int16 v1, Int16 v2, Int16 v3)
        {
            Delegates.glVertexAttrib4s(index, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4s(Int32 index, Int16 v0, Int16 v1, Int16 v2, Int16 v3)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4s((UInt32)index, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4d(UInt32 index, Double v0, Double v1, Double v2, Double v3)
        {
            Delegates.glVertexAttrib4d(index, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4d(Int32 index, Double v0, Double v1, Double v2, Double v3)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4d((UInt32)index, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4Nub(UInt32 index, Byte v0, Byte v1, Byte v2, Byte v3)
        {
            Delegates.glVertexAttrib4Nub(index, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4Nub(Int32 index, Byte v0, Byte v1, Byte v2, Byte v3)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4Nub((UInt32)index, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI4i(UInt32 index, Int32 v0, Int32 v1, Int32 v2, Int32 v3)
        {
            Delegates.glVertexAttribI4i(index, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI4i(Int32 index, Int32 v0, Int32 v1, Int32 v2, Int32 v3)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI4i((UInt32)index, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI4ui(UInt32 index, UInt32 v0, UInt32 v1, UInt32 v2, UInt32 v3)
        {
            Delegates.glVertexAttribI4ui(index, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI4ui(Int32 index, UInt32 v0, UInt32 v1, UInt32 v2, UInt32 v3)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI4ui((UInt32)index, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribL1d(UInt32 index, Double v0)
        {
            Delegates.glVertexAttribL1d(index, v0);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribL1d(Int32 index, Double v0)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribL1d((UInt32)index, v0);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribL2d(UInt32 index, Double v0, Double v1)
        {
            Delegates.glVertexAttribL2d(index, v0, v1);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribL2d(Int32 index, Double v0, Double v1)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribL2d((UInt32)index, v0, v1);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribL3d(UInt32 index, Double v0, Double v1, Double v2)
        {
            Delegates.glVertexAttribL3d(index, v0, v1, v2);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribL3d(Int32 index, Double v0, Double v1, Double v2)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribL3d((UInt32)index, v0, v1, v2);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribL4d(UInt32 index, Double v0, Double v1, Double v2, Double v3)
        {
            Delegates.glVertexAttribL4d(index, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribL4d(Int32 index, Double v0, Double v1, Double v2, Double v3)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribL4d((UInt32)index, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib1fv(UInt32 index, Single[] v)
        {
            Delegates.glVertexAttrib1fv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib1fv(Int32 index, Single[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib1fv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib1sv(UInt32 index, Int16[] v)
        {
            Delegates.glVertexAttrib1sv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib1sv(Int32 index, Int16[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib1sv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib1dv(UInt32 index, Double[] v)
        {
            Delegates.glVertexAttrib1dv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib1dv(Int32 index, Double[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib1dv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI1iv(UInt32 index, Int32[] v)
        {
            Delegates.glVertexAttribI1iv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI1iv(Int32 index, Int32[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI1iv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI1uiv(UInt32 index, UInt32[] v)
        {
            Delegates.glVertexAttribI1uiv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI1uiv(Int32 index, UInt32[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI1uiv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib2fv(UInt32 index, Single[] v)
        {
            Delegates.glVertexAttrib2fv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib2fv(Int32 index, Single[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib2fv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib2sv(UInt32 index, Int16[] v)
        {
            Delegates.glVertexAttrib2sv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib2sv(Int32 index, Int16[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib2sv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib2dv(UInt32 index, Double[] v)
        {
            Delegates.glVertexAttrib2dv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib2dv(Int32 index, Double[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib2dv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI2iv(UInt32 index, Int32[] v)
        {
            Delegates.glVertexAttribI2iv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI2iv(Int32 index, Int32[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI2iv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI2uiv(UInt32 index, UInt32[] v)
        {
            Delegates.glVertexAttribI2uiv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI2uiv(Int32 index, UInt32[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI2uiv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib3fv(UInt32 index, Single[] v)
        {
            Delegates.glVertexAttrib3fv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib3fv(Int32 index, Single[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib3fv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib3sv(UInt32 index, Int16[] v)
        {
            Delegates.glVertexAttrib3sv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib3sv(Int32 index, Int16[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib3sv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib3dv(UInt32 index, Double[] v)
        {
            Delegates.glVertexAttrib3dv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib3dv(Int32 index, Double[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib3dv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI3iv(UInt32 index, Int32[] v)
        {
            Delegates.glVertexAttribI3iv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI3iv(Int32 index, Int32[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI3iv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI3uiv(UInt32 index, UInt32[] v)
        {
            Delegates.glVertexAttribI3uiv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI3uiv(Int32 index, UInt32[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI3uiv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4fv(UInt32 index, Single[] v)
        {
            Delegates.glVertexAttrib4fv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4fv(Int32 index, Single[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4fv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4sv(UInt32 index, Int16[] v)
        {
            Delegates.glVertexAttrib4sv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4sv(Int32 index, Int16[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4sv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4dv(UInt32 index, Double[] v)
        {
            Delegates.glVertexAttrib4dv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4dv(Int32 index, Double[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4dv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4iv(UInt32 index, Int32[] v)
        {
            Delegates.glVertexAttrib4iv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4iv(Int32 index, Int32[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4iv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4bv(UInt32 index, SByte[] v)
        {
            Delegates.glVertexAttrib4bv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4bv(Int32 index, SByte[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4bv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4ubv(UInt32 index, Byte[] v)
        {
            Delegates.glVertexAttrib4ubv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4ubv(Int32 index, Byte[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4ubv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4usv(UInt32 index, UInt16[] v)
        {
            Delegates.glVertexAttrib4usv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4usv(Int32 index, UInt16[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4usv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4uiv(UInt32 index, UInt32[] v)
        {
            Delegates.glVertexAttrib4uiv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4uiv(Int32 index, UInt32[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4uiv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4Nbv(UInt32 index, SByte[] v)
        {
            Delegates.glVertexAttrib4Nbv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4Nbv(Int32 index, SByte[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4Nbv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4Nsv(UInt32 index, Int16[] v)
        {
            Delegates.glVertexAttrib4Nsv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4Nsv(Int32 index, Int16[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4Nsv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4Niv(UInt32 index, Int32[] v)
        {
            Delegates.glVertexAttrib4Niv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4Niv(Int32 index, Int32[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4Niv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4Nubv(UInt32 index, Byte[] v)
        {
            Delegates.glVertexAttrib4Nubv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4Nubv(Int32 index, Byte[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4Nubv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4Nusv(UInt32 index, UInt16[] v)
        {
            Delegates.glVertexAttrib4Nusv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4Nusv(Int32 index, UInt16[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4Nusv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4Nuiv(UInt32 index, UInt32[] v)
        {
            Delegates.glVertexAttrib4Nuiv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttrib4Nuiv(Int32 index, UInt32[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttrib4Nuiv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI4bv(UInt32 index, SByte[] v)
        {
            Delegates.glVertexAttribI4bv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI4bv(Int32 index, SByte[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI4bv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI4ubv(UInt32 index, Byte[] v)
        {
            Delegates.glVertexAttribI4ubv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI4ubv(Int32 index, Byte[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI4ubv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI4sv(UInt32 index, Int16[] v)
        {
            Delegates.glVertexAttribI4sv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI4sv(Int32 index, Int16[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI4sv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI4usv(UInt32 index, UInt16[] v)
        {
            Delegates.glVertexAttribI4usv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI4usv(Int32 index, UInt16[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI4usv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI4iv(UInt32 index, Int32[] v)
        {
            Delegates.glVertexAttribI4iv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI4iv(Int32 index, Int32[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI4iv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI4uiv(UInt32 index, UInt32[] v)
        {
            Delegates.glVertexAttribI4uiv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribI4uiv(Int32 index, UInt32[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribI4uiv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribL1dv(UInt32 index, Double[] v)
        {
            Delegates.glVertexAttribL1dv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribL1dv(Int32 index, Double[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribL1dv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribL2dv(UInt32 index, Double[] v)
        {
            Delegates.glVertexAttribL2dv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribL2dv(Int32 index, Double[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribL2dv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribL3dv(UInt32 index, Double[] v)
        {
            Delegates.glVertexAttribL3dv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribL3dv(Int32 index, Double[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribL3dv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribL4dv(UInt32 index, Double[] v)
        {
            Delegates.glVertexAttribL4dv(index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribL4dv(Int32 index, Double[] v)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribL4dv((UInt32)index, v);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribP1ui(UInt32 index, OpenGL.VertexAttribPType type, Boolean normalized, UInt32 value)
        {
            Delegates.glVertexAttribP1ui(index, type, normalized, value);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribP1ui(Int32 index, OpenGL.VertexAttribPType type, Boolean normalized, UInt32 value)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribP1ui((UInt32)index, type, normalized, value);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribP2ui(UInt32 index, OpenGL.VertexAttribPType type, Boolean normalized, UInt32 value)
        {
            Delegates.glVertexAttribP2ui(index, type, normalized, value);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribP2ui(Int32 index, OpenGL.VertexAttribPType type, Boolean normalized, UInt32 value)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribP2ui((UInt32)index, type, normalized, value);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribP3ui(UInt32 index, OpenGL.VertexAttribPType type, Boolean normalized, UInt32 value)
        {
            Delegates.glVertexAttribP3ui(index, type, normalized, value);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribP3ui(Int32 index, OpenGL.VertexAttribPType type, Boolean normalized, UInt32 value)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribP3ui((UInt32)index, type, normalized, value);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribP4ui(UInt32 index, OpenGL.VertexAttribPType type, Boolean normalized, UInt32 value)
        {
            Delegates.glVertexAttribP4ui(index, type, normalized, value);
        }

        /// <summary>
        /// Specifies the value of a generic vertex attribute.
        /// <para>
        /// The glVertexAttrib family of entry points allows an application to pass generic
        /// vertex attributes in numbered locations.
        /// </para>
        /// </summary>
        public static void VertexAttribP4ui(Int32 index, OpenGL.VertexAttribPType type, Boolean normalized, UInt32 value)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribP4ui((UInt32)index, type, normalized, value);
        }

        /// <summary>
        /// Associate a vertex attribute and a vertex buffer binding for a vertex array object.
        /// <para>
        /// glVertexAttribBinding and glVertexArrayAttribBinding establishes an association
        /// between the generic vertex attribute of a vertex array object whose index is
        /// given by attribindex, and a vertex buffer binding whose index is given by
        /// bindingindex. For glVertexAttribBinding, the vertex array object affected is
        /// that currently bound. For glVertexArrayAttribBinding, vaobj is the name of the
        /// vertex array object.
        /// </para>
        /// </summary>
        public static void VertexAttribBinding(UInt32 attribindex, UInt32 bindingindex)
        {
            Delegates.glVertexAttribBinding(attribindex, bindingindex);
        }

        /// <summary>
        /// Associate a vertex attribute and a vertex buffer binding for a vertex array object.
        /// <para>
        /// glVertexAttribBinding and glVertexArrayAttribBinding establishes an association
        /// between the generic vertex attribute of a vertex array object whose index is
        /// given by attribindex, and a vertex buffer binding whose index is given by
        /// bindingindex. For glVertexAttribBinding, the vertex array object affected is
        /// that currently bound. For glVertexArrayAttribBinding, vaobj is the name of the
        /// vertex array object.
        /// </para>
        /// </summary>
        public static void VertexArrayAttribBinding(UInt32 vaobj, UInt32 attribindex, UInt32 bindingindex)
        {
            Delegates.glVertexArrayAttribBinding(vaobj, attribindex, bindingindex);
        }

        /// <summary>
        /// Modify the rate at which generic vertex attributes advance during instanced rendering.
        /// <para>
        /// glVertexAttribDivisor modifies the rate at which generic vertex attributes
        /// advance when rendering multiple instances of primitives in a single draw call.
        /// If divisor is zero, the attribute at slot index advances once per vertex. If
        /// divisor is non-zero, the attribute advances once per divisor instances of the
        /// set(s) of vertices being rendered. An attribute is referred to as instanced if
        /// its GL_VERTEX_ATTRIB_ARRAY_DIVISOR value is non-zero.
        /// </para>
        /// </summary>
        public static void VertexAttribDivisor(UInt32 index, UInt32 divisor)
        {
            Delegates.glVertexAttribDivisor(index, divisor);
        }

        /// <summary>
        /// Modify the rate at which generic vertex attributes advance during instanced rendering.
        /// <para>
        /// glVertexAttribDivisor modifies the rate at which generic vertex attributes
        /// advance when rendering multiple instances of primitives in a single draw call.
        /// If divisor is zero, the attribute at slot index advances once per vertex. If
        /// divisor is non-zero, the attribute advances once per divisor instances of the
        /// set(s) of vertices being rendered. An attribute is referred to as instanced if
        /// its GL_VERTEX_ATTRIB_ARRAY_DIVISOR value is non-zero.
        /// </para>
        /// </summary>
        public static void VertexAttribDivisor(Int32 index, UInt32 divisor)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribDivisor((UInt32)index, divisor);
        }

        /// <summary>
        /// Specify the organization of vertex arrays.
        /// <para>
        /// glVertexAttribFormat, glVertexAttribIFormat and glVertexAttribLFormat, as well
        /// as glVertexArrayAttribFormat, glVertexArrayAttribIFormat and
        /// glVertexArrayAttribLFormat specify the organization of data in vertex arrays.
        /// The first three calls operate on the bound vertex array object, whereas the last
        /// three ones modify the state of a vertex array object with ID vaobj. attribindex
        /// specifies the index of the generic vertex attribute array whose data layout is
        /// being described, and must be less than the value of GL_MAX_VERTEX_ATTRIBS.
        /// </para>
        /// </summary>
        public static void VertexAttribFormat(UInt32 attribindex, Int32 size, OpenGL.VertexAttribFormat type, Boolean normalized, UInt32 relativeoffset)
        {
            Delegates.glVertexAttribFormat(attribindex, size, type, normalized, relativeoffset);
        }

        /// <summary>
        /// Specify the organization of vertex arrays.
        /// <para>
        /// glVertexAttribFormat, glVertexAttribIFormat and glVertexAttribLFormat, as well
        /// as glVertexArrayAttribFormat, glVertexArrayAttribIFormat and
        /// glVertexArrayAttribLFormat specify the organization of data in vertex arrays.
        /// The first three calls operate on the bound vertex array object, whereas the last
        /// three ones modify the state of a vertex array object with ID vaobj. attribindex
        /// specifies the index of the generic vertex attribute array whose data layout is
        /// being described, and must be less than the value of GL_MAX_VERTEX_ATTRIBS.
        /// </para>
        /// </summary>
        public static void VertexAttribIFormat(UInt32 attribindex, Int32 size, OpenGL.VertexAttribFormat type, UInt32 relativeoffset)
        {
            Delegates.glVertexAttribIFormat(attribindex, size, type, relativeoffset);
        }

        /// <summary>
        /// Specify the organization of vertex arrays.
        /// <para>
        /// glVertexAttribFormat, glVertexAttribIFormat and glVertexAttribLFormat, as well
        /// as glVertexArrayAttribFormat, glVertexArrayAttribIFormat and
        /// glVertexArrayAttribLFormat specify the organization of data in vertex arrays.
        /// The first three calls operate on the bound vertex array object, whereas the last
        /// three ones modify the state of a vertex array object with ID vaobj. attribindex
        /// specifies the index of the generic vertex attribute array whose data layout is
        /// being described, and must be less than the value of GL_MAX_VERTEX_ATTRIBS.
        /// </para>
        /// </summary>
        public static void VertexAttribLFormat(UInt32 attribindex, Int32 size, OpenGL.VertexAttribFormat type, UInt32 relativeoffset)
        {
            Delegates.glVertexAttribLFormat(attribindex, size, type, relativeoffset);
        }

        /// <summary>
        /// Specify the organization of vertex arrays.
        /// <para>
        /// glVertexAttribFormat, glVertexAttribIFormat and glVertexAttribLFormat, as well
        /// as glVertexArrayAttribFormat, glVertexArrayAttribIFormat and
        /// glVertexArrayAttribLFormat specify the organization of data in vertex arrays.
        /// The first three calls operate on the bound vertex array object, whereas the last
        /// three ones modify the state of a vertex array object with ID vaobj. attribindex
        /// specifies the index of the generic vertex attribute array whose data layout is
        /// being described, and must be less than the value of GL_MAX_VERTEX_ATTRIBS.
        /// </para>
        /// </summary>
        public static void VertexArrayAttribFormat(UInt32 vaobj, UInt32 attribindex, Int32 size, OpenGL.VertexAttribFormat type, Boolean normalized, UInt32 relativeoffset)
        {
            Delegates.glVertexArrayAttribFormat(vaobj, attribindex, size, type, normalized, relativeoffset);
        }

        /// <summary>
        /// Specify the organization of vertex arrays.
        /// <para>
        /// glVertexAttribFormat, glVertexAttribIFormat and glVertexAttribLFormat, as well
        /// as glVertexArrayAttribFormat, glVertexArrayAttribIFormat and
        /// glVertexArrayAttribLFormat specify the organization of data in vertex arrays.
        /// The first three calls operate on the bound vertex array object, whereas the last
        /// three ones modify the state of a vertex array object with ID vaobj. attribindex
        /// specifies the index of the generic vertex attribute array whose data layout is
        /// being described, and must be less than the value of GL_MAX_VERTEX_ATTRIBS.
        /// </para>
        /// </summary>
        public static void VertexArrayAttribIFormat(UInt32 vaobj, UInt32 attribindex, Int32 size, OpenGL.VertexAttribFormat type, UInt32 relativeoffset)
        {
            Delegates.glVertexArrayAttribIFormat(vaobj, attribindex, size, type, relativeoffset);
        }

        /// <summary>
        /// Specify the organization of vertex arrays.
        /// <para>
        /// glVertexAttribFormat, glVertexAttribIFormat and glVertexAttribLFormat, as well
        /// as glVertexArrayAttribFormat, glVertexArrayAttribIFormat and
        /// glVertexArrayAttribLFormat specify the organization of data in vertex arrays.
        /// The first three calls operate on the bound vertex array object, whereas the last
        /// three ones modify the state of a vertex array object with ID vaobj. attribindex
        /// specifies the index of the generic vertex attribute array whose data layout is
        /// being described, and must be less than the value of GL_MAX_VERTEX_ATTRIBS.
        /// </para>
        /// </summary>
        public static void VertexArrayAttribLFormat(UInt32 vaobj, UInt32 attribindex, Int32 size, OpenGL.VertexAttribFormat type, UInt32 relativeoffset)
        {
            Delegates.glVertexArrayAttribLFormat(vaobj, attribindex, size, type, relativeoffset);
        }

        /// <summary>
        /// Define an array of generic vertex attribute data.
        /// <para>
        /// glVertexAttribPointer, glVertexAttribIPointer and glVertexAttribLPointer specify
        /// the location and data format of the array of generic vertex attributes at index
        /// index to use when rendering. size specifies the number of components per
        /// attribute and must be 1, 2, 3, 4, or GL_BGRA. type specifies the data type of
        /// each component, and stride specifies the byte stride from one attribute to the
        /// next, allowing vertices and attributes to be packed into a single array or
        /// stored in separate arrays.
        /// </para>
        /// </summary>
        public static void VertexAttribPointer(UInt32 index, Int32 size, OpenGL.VertexAttribPointerType type, Boolean normalized, Int32 stride, IntPtr pointer)
        {
            Delegates.glVertexAttribPointer(index, size, type, normalized, stride, pointer);
        }

        /// <summary>
        /// Define an array of generic vertex attribute data.
        /// <para>
        /// glVertexAttribPointer, glVertexAttribIPointer and glVertexAttribLPointer specify
        /// the location and data format of the array of generic vertex attributes at index
        /// index to use when rendering. size specifies the number of components per
        /// attribute and must be 1, 2, 3, 4, or GL_BGRA. type specifies the data type of
        /// each component, and stride specifies the byte stride from one attribute to the
        /// next, allowing vertices and attributes to be packed into a single array or
        /// stored in separate arrays.
        /// </para>
        /// </summary>
        public static void VertexAttribPointer(Int32 index, Int32 size, OpenGL.VertexAttribPointerType type, Boolean normalized, Int32 stride, IntPtr pointer)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribPointer((UInt32)index, size, type, normalized, stride, pointer);
        }

        /// <summary>
        /// Define an array of generic vertex attribute data.
        /// <para>
        /// glVertexAttribPointer, glVertexAttribIPointer and glVertexAttribLPointer specify
        /// the location and data format of the array of generic vertex attributes at index
        /// index to use when rendering. size specifies the number of components per
        /// attribute and must be 1, 2, 3, 4, or GL_BGRA. type specifies the data type of
        /// each component, and stride specifies the byte stride from one attribute to the
        /// next, allowing vertices and attributes to be packed into a single array or
        /// stored in separate arrays.
        /// </para>
        /// </summary>
        public static void VertexAttribIPointer(UInt32 index, Int32 size, OpenGL.VertexAttribPointerType type, Int32 stride, IntPtr pointer)
        {
            Delegates.glVertexAttribIPointer(index, size, type, stride, pointer);
        }

        /// <summary>
        /// Define an array of generic vertex attribute data.
        /// <para>
        /// glVertexAttribPointer, glVertexAttribIPointer and glVertexAttribLPointer specify
        /// the location and data format of the array of generic vertex attributes at index
        /// index to use when rendering. size specifies the number of components per
        /// attribute and must be 1, 2, 3, 4, or GL_BGRA. type specifies the data type of
        /// each component, and stride specifies the byte stride from one attribute to the
        /// next, allowing vertices and attributes to be packed into a single array or
        /// stored in separate arrays.
        /// </para>
        /// </summary>
        public static void VertexAttribIPointer(Int32 index, Int32 size, OpenGL.VertexAttribPointerType type, Int32 stride, IntPtr pointer)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribIPointer((UInt32)index, size, type, stride, pointer);
        }

        /// <summary>
        /// Define an array of generic vertex attribute data.
        /// <para>
        /// glVertexAttribPointer, glVertexAttribIPointer and glVertexAttribLPointer specify
        /// the location and data format of the array of generic vertex attributes at index
        /// index to use when rendering. size specifies the number of components per
        /// attribute and must be 1, 2, 3, 4, or GL_BGRA. type specifies the data type of
        /// each component, and stride specifies the byte stride from one attribute to the
        /// next, allowing vertices and attributes to be packed into a single array or
        /// stored in separate arrays.
        /// </para>
        /// </summary>
        public static void VertexAttribLPointer(UInt32 index, Int32 size, OpenGL.VertexAttribPointerType type, Int32 stride, IntPtr pointer)
        {
            Delegates.glVertexAttribLPointer(index, size, type, stride, pointer);
        }

        /// <summary>
        /// Define an array of generic vertex attribute data.
        /// <para>
        /// glVertexAttribPointer, glVertexAttribIPointer and glVertexAttribLPointer specify
        /// the location and data format of the array of generic vertex attributes at index
        /// index to use when rendering. size specifies the number of components per
        /// attribute and must be 1, 2, 3, 4, or GL_BGRA. type specifies the data type of
        /// each component, and stride specifies the byte stride from one attribute to the
        /// next, allowing vertices and attributes to be packed into a single array or
        /// stored in separate arrays.
        /// </para>
        /// </summary>
        public static void VertexAttribLPointer(Int32 index, Int32 size, OpenGL.VertexAttribPointerType type, Int32 stride, IntPtr pointer)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            Delegates.glVertexAttribLPointer((UInt32)index, size, type, stride, pointer);
        }

        /// <summary>
        /// Modify the rate at which generic vertex attributes advance.
        /// <para>
        /// glVertexBindingDivisor and glVertexArrayBindingDivisor modify the rate at which
        /// generic vertex attributes advance when rendering multiple instances of
        /// primitives in a single draw command. If divisor is zero, the attributes using
        /// the buffer bound to bindingindex advance once per vertex. If divisor is
        /// non-zero, the attributes advance once per divisor instances of the set(s) of
        /// vertices being rendered. An attribute is referred to as instanced if the
        /// corresponding divisor value is non-zero.
        /// </para>
        /// </summary>
        public static void VertexBindingDivisor(UInt32 bindingindex, UInt32 divisor)
        {
            Delegates.glVertexBindingDivisor(bindingindex, divisor);
        }

        /// <summary>
        /// Modify the rate at which generic vertex attributes advance.
        /// <para>
        /// glVertexBindingDivisor and glVertexArrayBindingDivisor modify the rate at which
        /// generic vertex attributes advance when rendering multiple instances of
        /// primitives in a single draw command. If divisor is zero, the attributes using
        /// the buffer bound to bindingindex advance once per vertex. If divisor is
        /// non-zero, the attributes advance once per divisor instances of the set(s) of
        /// vertices being rendered. An attribute is referred to as instanced if the
        /// corresponding divisor value is non-zero.
        /// </para>
        /// </summary>
        public static void VertexArrayBindingDivisor(UInt32 vaobj, UInt32 bindingindex, UInt32 divisor)
        {
            Delegates.glVertexArrayBindingDivisor(vaobj, bindingindex, divisor);
        }

        /// <summary>
        /// Set the viewport.
        /// <para>
        /// glViewport specifies the affine transformation of x and y from normalized device
        /// coordinates to window coordinates. Let x nd y nd be normalized device
        /// coordinates. Then the window coordinates x w y w are computed as follows:.
        /// </para>
        /// </summary>
        public static void Viewport(Int32 x, Int32 y, Int32 width, Int32 height)
        {
            Delegates.glViewport(x, y, width, height);
        }

        /// <summary>
        /// Set multiple viewports.
        /// <para>
        /// glViewportArrayv specifies the parameters for multiple viewports
        /// simulataneously. first specifies the index of the first viewport to modify and
        /// count specifies the number of viewports to modify. first must be less than the
        /// value of GL_MAX_VIEWPORTS, and first + count must be less than or equal to the
        /// value of GL_MAX_VIEWPORTS. Viewports whose indices lie outside the range [first,
        /// first + count) are not modified. v contains the address of an array of floating
        /// point values specifying the left (x), bottom (y), width (w), and height (h) of
        /// each viewport, in that order. x and y give the location of the viewport's lower
        /// left corner, and w and h give the width and height of the viewport,
        /// respectively. The viewport specifies the affine transformation of x and y from
        /// normalized device coordinates to window coordinates. Let x nd y nd be normalized
        /// device coordinates. Then the window coordinates x w y w are computed as
        /// follows:.
        /// </para>
        /// </summary>
        public static void ViewportArrayv(UInt32 first, Int32 count, Single[] v)
        {
            Delegates.glViewportArrayv(first, count, v);
        }

        /// <summary>
        /// Set a specified viewport.
        /// <para>
        /// glViewportIndexedf and glViewportIndexedfv specify the parameters for a single
        /// viewport. index specifies the index of the viewport to modify. index must be
        /// less than the value of GL_MAX_VIEWPORTS. For glViewportIndexedf, x, y, w, and h
        /// specify the left, bottom, width and height of the viewport in pixels,
        /// respectively. For glViewportIndexedfv, v contains the address of an array of
        /// floating point values specifying the left (x), bottom (y), width (w), and height
        /// (h) of each viewport, in that order. x and y give the location of the viewport's
        /// lower left corner, and w and h give the width and height of the viewport,
        /// respectively. The viewport specifies the affine transformation of x and y from
        /// normalized device coordinates to window coordinates. Let x nd y nd be normalized
        /// device coordinates. Then the window coordinates x w y w are computed as
        /// follows:.
        /// </para>
        /// </summary>
        public static void ViewportIndexedf(UInt32 index, Single x, Single y, Single w, Single h)
        {
            Delegates.glViewportIndexedf(index, x, y, w, h);
        }

        /// <summary>
        /// Set a specified viewport.
        /// <para>
        /// glViewportIndexedf and glViewportIndexedfv specify the parameters for a single
        /// viewport. index specifies the index of the viewport to modify. index must be
        /// less than the value of GL_MAX_VIEWPORTS. For glViewportIndexedf, x, y, w, and h
        /// specify the left, bottom, width and height of the viewport in pixels,
        /// respectively. For glViewportIndexedfv, v contains the address of an array of
        /// floating point values specifying the left (x), bottom (y), width (w), and height
        /// (h) of each viewport, in that order. x and y give the location of the viewport's
        /// lower left corner, and w and h give the width and height of the viewport,
        /// respectively. The viewport specifies the affine transformation of x and y from
        /// normalized device coordinates to window coordinates. Let x nd y nd be normalized
        /// device coordinates. Then the window coordinates x w y w are computed as
        /// follows:.
        /// </para>
        /// </summary>
        public static void ViewportIndexedfv(UInt32 index, Single[] v)
        {
            Delegates.glViewportIndexedfv(index, v);
        }

        /// <summary>
        /// Instruct the GL server to block until the specified sync object becomes signaled.
        /// <para>
        /// glWaitSync causes the GL server to block and wait until sync becomes signaled.
        /// sync is the name of an existing sync object upon which to wait. flags and
        /// timeout are currently not used and must be set to zero and the special value
        /// GL_TIMEOUT_IGNORED, respectively[1]. glWaitSync will always wait no longer than
        /// an implementation-dependent timeout. The duration of this timeout in nanoseconds
        /// may be queried by calling glGet with the parameter GL_MAX_SERVER_WAIT_TIMEOUT.
        /// There is currently no way to determine whether glWaitSync unblocked because the
        /// timeout expired or because the sync object being waited on was signaled.
        /// </para>
        /// </summary>
        public static void WaitSync(IntPtr sync, UInt32 flags, UInt64 timeout)
        {
            Delegates.glWaitSync(sync, flags, timeout);
        }
    }
}