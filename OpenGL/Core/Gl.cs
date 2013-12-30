using System;
using System.Runtime.InteropServices;

namespace OpenGL
{
    // Automatically generated from GlCore.cs using BuildGl
    partial class Gl
    {
        public static void ActiveTexture(OpenGL.TextureUnit texture)
        {
            Delegates.glActiveTexture(texture);
        }

        public static void AttachShader(UInt32 program, UInt32 shader)
        {
            Delegates.glAttachShader(program, shader);
        }

        public static void BeginConditionalRender(UInt32 id, OpenGL.ConditionalRenderType mode)
        {
            Delegates.glBeginConditionalRender(id, mode);
        }

        public static void BeginQuery(OpenGL.QueryTarget target, UInt32 id)
        {
            Delegates.glBeginQuery(target, id);
        }

        public static void BeginTransformFeedback(OpenGL.BeginFeedbackMode primitiveMode)
        {
            Delegates.glBeginTransformFeedback(primitiveMode);
        }

        public static void BindAttribLocation(UInt32 program, UInt32 index, String name)
        {
            Delegates.glBindAttribLocation(program, index, name);
        }

        public static void BindBuffer(OpenGL.BufferTarget target, UInt32 buffer)
        {
            Delegates.glBindBuffer(target, buffer);
        }

        public static void BindBufferBase(OpenGL.BufferTarget target, UInt32 index, UInt32 buffer)
        {
            Delegates.glBindBufferBase(target, index, buffer);
        }

        public static void BindBufferRange(BufferTarget target, UInt32 index, UInt32 buffer, IntPtr offset, IntPtr size)
        {
            Delegates.glBindBufferRange(target, index, buffer, offset, size);
        }

        public static void BindFragDataLocation(UInt32 program, UInt32 color, String name)
        {
            Delegates.glBindFragDataLocation(program, color, name);
        }

        public static void BindFramebuffer(OpenGL.FramebufferTarget target, UInt32 framebuffer)
        {
            Delegates.glBindFramebuffer(target, framebuffer);
        }

        public static void BindRenderbuffer(OpenGL.RenderbufferTarget target, UInt32 renderbuffer)
        {
            Delegates.glBindRenderbuffer(target, renderbuffer);
        }

        public static void BindTexture(OpenGL.TextureTarget target, UInt32 texture)
        {
            Delegates.glBindTexture(target, texture);
        }

        public static void BindTransformFeedbackNV(OpenGL.NvTransformFeedback2 target, UInt32 id)
        {
            Delegates.glBindTransformFeedbackNV(target, id);
        }

        public static void BindVertexArray(UInt32 array)
        {
            Delegates.glBindVertexArray(array);
        }

        public static void BlendColor(Single red, Single green, Single blue, Single alpha)
        {
            Delegates.glBlendColor(red, green, blue, alpha);
        }

        public static void BlendEquation(OpenGL.BlendEquationMode mode)
        {
            Delegates.glBlendEquation(mode);
        }

        public static void BlendEquationSeparate(OpenGL.BlendEquationMode modeRGB, OpenGL.BlendEquationMode modeAlpha)
        {
            Delegates.glBlendEquationSeparate(modeRGB, modeAlpha);
        }

        public static void BlendFunc(OpenGL.BlendingFactorSrc sfactor, OpenGL.BlendingFactorDest dfactor)
        {
            Delegates.glBlendFunc(sfactor, dfactor);
        }

        public static void BlendFuncSeparate(OpenGL.BlendingFactorSrc sfactorRGB, OpenGL.BlendingFactorDest dfactorRGB, OpenGL.BlendingFactorSrc sfactorAlpha, OpenGL.BlendingFactorDest dfactorAlpha)
        {
            Delegates.glBlendFuncSeparate(sfactorRGB, dfactorRGB, sfactorAlpha, dfactorAlpha);
        }

        public static void BlitFramebuffer(Int32 srcX0, Int32 srcY0, Int32 srcX1, Int32 srcY1, Int32 dstX0, Int32 dstY0, Int32 dstX1, Int32 dstY1, OpenGL.ClearBufferMask mask, OpenGL.BlitFramebufferFilter filter)
        {
            Delegates.glBlitFramebuffer(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
        }

        public static void BufferData(OpenGL.BufferTarget target, IntPtr size, IntPtr data, OpenGL.BufferUsageHint usage)
        {
            Delegates.glBufferData(target, size, data, usage);
        }

        public static void BufferSubData(OpenGL.BufferTarget target, IntPtr offset, IntPtr size, IntPtr data)
        {
            Delegates.glBufferSubData(target, offset, size, data);
        }

        public static OpenGL.FramebufferErrorCode CheckFramebufferStatus(OpenGL.FramebufferTarget target)
        {
            return Delegates.glCheckFramebufferStatus(target);
        }

        public static void ClampColor(OpenGL.ClampColorTarget target, OpenGL.ClampColorMode clamp)
        {
            Delegates.glClampColor(target, clamp);
        }

        public static void Clear(OpenGL.ClearBufferMask mask)
        {
            Delegates.glClear(mask);
        }

        public static void ClearBufferfi(OpenGL.ClearBuffer buffer, Int32 drawbuffer, Single depth, Int32 stencil)
        {
            Delegates.glClearBufferfi(buffer, drawbuffer, depth, stencil);
        }

        public static void ClearDepth(Double depth)
        {
            Delegates.glClearDepth(depth);
        }

        public static void ClearStencil(Int32 s)
        {
            Delegates.glClearStencil(s);
        }

        public static OpenGL.ArbSync ClientWaitSync(IntPtr sync, UInt32 flags, UInt64 timeout)
        {
            return Delegates.glClientWaitSync(sync, flags, timeout);
        }

        public static void ColorMask(bool red, bool green, bool blue, bool alpha)
        {
            Delegates.glColorMask(red, green, blue, alpha);
        }

        public static void CompileShader(UInt32 shader)
        {
            Delegates.glCompileShader(shader);
        }

        public static void CompressedTexImage1D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 border, Int32 imageSize, IntPtr data)
        {
            Delegates.glCompressedTexImage1D(target, level, internalformat, width, border, imageSize, data);
        }

        public static void CompressedTexImage2D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 border, Int32 imageSize, IntPtr data)
        {
            Delegates.glCompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, data);
        }

        public static void CompressedTexImage3D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 depth, Int32 border, Int32 imageSize, IntPtr data)
        {
            Delegates.glCompressedTexImage3D(target, level, internalformat, width, height, depth, border, imageSize, data);
        }

        public static void CompressedTexSubImage1D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 width, OpenGL.PixelFormat format, Int32 imageSize, IntPtr data)
        {
            Delegates.glCompressedTexSubImage1D(target, level, xoffset, width, format, imageSize, data);
        }

        public static void CompressedTexSubImage2D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenGL.PixelFormat format, Int32 imageSize, IntPtr data)
        {
            Delegates.glCompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, data);
        }

        public static void CompressedTexSubImage3D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenGL.PixelFormat format, Int32 imageSize, IntPtr data)
        {
            Delegates.glCompressedTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data);
        }

        public static void CopyBufferSubData(OpenGL.BufferTarget readTarget, OpenGL.BufferTarget writeTarget, IntPtr readOffset, IntPtr writeOffset, IntPtr size)
        {
            Delegates.glCopyBufferSubData(readTarget, writeTarget, readOffset, writeOffset, size);
        }

        public static void CopyTexImage1D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalformat, Int32 x, Int32 y, Int32 width, Int32 border)
        {
            Delegates.glCopyTexImage1D(target, level, internalformat, x, y, width, border);
        }

        public static void CopyTexImage2D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalformat, Int32 x, Int32 y, Int32 width, Int32 height, Int32 border)
        {
            Delegates.glCopyTexImage2D(target, level, internalformat, x, y, width, height, border);
        }

        public static void CopyTexSubImage1D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 x, Int32 y, Int32 width)
        {
            Delegates.glCopyTexSubImage1D(target, level, xoffset, x, y, width);
        }

        public static void CopyTexSubImage2D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 x, Int32 y, Int32 width, Int32 height)
        {
            Delegates.glCopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height);
        }

        public static void CopyTexSubImage3D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 x, Int32 y, Int32 width, Int32 height)
        {
            Delegates.glCopyTexSubImage3D(target, level, xoffset, yoffset, zoffset, x, y, width, height);
        }

        public static UInt32 CreateProgram()
        {
            return Delegates.glCreateProgram();
        }

        public static UInt32 CreateShader(OpenGL.ShaderType type)
        {
            return Delegates.glCreateShader(type);
        }

        public static void CullFace(OpenGL.CullFaceMode mode)
        {
            Delegates.glCullFace(mode);
        }

        public static void DeleteBuffers(Int32 n, UInt32[] buffers)
        {
            Delegates.glDeleteBuffers(n, buffers);
        }

        public static void DeleteFramebuffers(Int32 n, UInt32[] framebuffers)
        {
            Delegates.glDeleteFramebuffers(n, framebuffers);
        }

        public static void DeleteProgram(UInt32 program)
        {
            Delegates.glDeleteProgram(program);
        }

        public static void DeleteQueries(Int32 n, UInt32[] ids)
        {
            Delegates.glDeleteQueries(n, ids);
        }

        public static void DeleteRenderbuffers(Int32 n, UInt32[] renderbuffers)
        {
            Delegates.glDeleteRenderbuffers(n, renderbuffers);
        }

        public static void DeleteShader(UInt32 shader)
        {
            Delegates.glDeleteShader(shader);
        }

        public static void DeleteSync(IntPtr sync)
        {
            Delegates.glDeleteSync(sync);
        }

        public static void DeleteTextures(Int32 n, UInt32[] textures)
        {
            Delegates.glDeleteTextures(n, textures);
        }

        public static void DeleteTransformFeedbacksNV(Int32 n, UInt32[] ids)
        {
            Delegates.glDeleteTransformFeedbacksNV(n, ids);
        }

        public static void DeleteVertexArrays(Int32 n, UInt32[] arrays)
        {
            Delegates.glDeleteVertexArrays(n, arrays);
        }

        public static void DepthFunc(OpenGL.DepthFunction func)
        {
            Delegates.glDepthFunc(func);
        }

        public static void DepthMask(bool flag)
        {
            Delegates.glDepthMask(flag);
        }

        public static void DepthRange(Double near, Double far)
        {
            Delegates.glDepthRange(near, far);
        }

        public static void DetachShader(UInt32 program, UInt32 shader)
        {
            Delegates.glDetachShader(program, shader);
        }

        public static void Disable(OpenGL.EnableCap cap)
        {
            Delegates.glDisable(cap);
        }

        public static void DisableVertexAttribArray(UInt32 index)
        {
            Delegates.glDisableVertexAttribArray(index);
        }

        public static void DrawArrays(OpenGL.BeginMode mode, Int32 first, Int32 count)
        {
            Delegates.glDrawArrays(mode, first, count);
        }

        public static void DrawArraysInstanced(OpenGL.BeginMode mode, Int32 first, Int32 count, Int32 primcount)
        {
            Delegates.glDrawArraysInstanced(mode, first, count, primcount);
        }

        public static void DrawBuffer(OpenGL.DrawBufferMode mode)
        {
            Delegates.glDrawBuffer(mode);
        }

        public static void DrawBuffers(Int32 n, OpenGL.DrawBuffersEnum[] bufs)
        {
            Delegates.glDrawBuffers(n, bufs);
        }

        public static void DrawElements(OpenGL.BeginMode mode, Int32 count, OpenGL.DrawElementsType type, IntPtr indices)
        {
            Delegates.glDrawElements(mode, count, type, indices);
        }

        public static void DrawElementsBaseVertex(OpenGL.BeginMode mode, Int32 count, OpenGL.DrawElementsType type, IntPtr indices, Int32 basevertex)
        {
            Delegates.glDrawElementsBaseVertex(mode, count, type, indices, basevertex);
        }

        public static void DrawElementsInstanced(OpenGL.BeginMode mode, Int32 count, OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount)
        {
            Delegates.glDrawElementsInstanced(mode, count, type, indices, primcount);
        }

        public static void DrawElementsInstancedBaseVertex(OpenGL.BeginMode mode, Int32 count, OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount, Int32 basevertex)
        {
            Delegates.glDrawElementsInstancedBaseVertex(mode, count, type, indices, primcount, basevertex);
        }

        public static void DrawRangeElements(OpenGL.BeginMode mode, UInt32 start, UInt32 end, Int32 count, OpenGL.DrawElementsType type, IntPtr indices)
        {
            Delegates.glDrawRangeElements(mode, start, end, count, type, indices);
        }

        public static void DrawRangeElementsBaseVertex(OpenGL.BeginMode mode, UInt32 start, UInt32 end, Int32 count, OpenGL.DrawElementsType type, IntPtr indices, Int32 basevertex)
        {
            Delegates.glDrawRangeElementsBaseVertex(mode, start, end, count, type, indices, basevertex);
        }

        public static void DrawTransformFeedbackNV(OpenGL.NvTransformFeedback2 mode, UInt32 id)
        {
            Delegates.glDrawTransformFeedbackNV(mode, id);
        }

        public static void Enable(OpenGL.EnableCap cap)
        {
            Delegates.glEnable(cap);
        }

        public static void EnableVertexAttribArray(UInt32 index)
        {
            Delegates.glEnableVertexAttribArray(index);
        }

        public static void EndConditionalRenderNV()
        {
            Delegates.glEndConditionalRenderNV();
        }

        public static void EndQuery(OpenGL.QueryTarget target)
        {
            Delegates.glEndQuery(target);
        }

        public static void EndTransformFeedback()
        {
            Delegates.glEndTransformFeedback();
        }

        public static IntPtr FenceSync(OpenGL.ArbSync condition, UInt32 flags)
        {
            return Delegates.glFenceSync(condition, flags);
        }

        public static void Finish()
        {
            Delegates.glFinish();
        }

        public static void Flush()
        {
            Delegates.glFlush();
        }

        public static void FlushMappedBufferRange(OpenGL.BufferTarget target, IntPtr offset, IntPtr length)
        {
            Delegates.glFlushMappedBufferRange(target, offset, length);
        }

        public static void FramebufferRenderbuffer(OpenGL.FramebufferTarget target, OpenGL.FramebufferAttachment attachment, OpenGL.RenderbufferTarget renderbuffertarget, UInt32 renderbuffer)
        {
            Delegates.glFramebufferRenderbuffer(target, attachment, renderbuffertarget, renderbuffer);
        }

        public static void FramebufferTexture(OpenGL.FramebufferTarget target, OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level)
        {
            Delegates.glFramebufferTexture(target, attachment, texture, level);
        }

        public static void FramebufferTextureFace(OpenGL.Version32 target, OpenGL.Version32 attachment, UInt32 texture, Int32 level, OpenGL.Version32 face)
        {
            Delegates.glFramebufferTextureFace(target, attachment, texture, level, face);
        }

        public static void FramebufferTextureLayer(OpenGL.FramebufferTarget target, OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level, Int32 layer)
        {
            Delegates.glFramebufferTextureLayer(target, attachment, texture, level, layer);
        }

        public static void FrontFace(OpenGL.FrontFaceDirection mode)
        {
            Delegates.glFrontFace(mode);
        }

        public static void GenBuffers(Int32 n, [OutAttribute] UInt32[] buffers)
        {
            Delegates.glGenBuffers(n, buffers);
        }

        public static void GenFramebuffers(Int32 n, [OutAttribute] UInt32[] framebuffers)
        {
            Delegates.glGenFramebuffers(n, framebuffers);
        }

        public static void GenQueries(Int32 n, [OutAttribute] UInt32[] ids)
        {
            Delegates.glGenQueries(n, ids);
        }

        public static void GenRenderbuffers(Int32 n, [OutAttribute] UInt32[] renderbuffers)
        {
            Delegates.glGenRenderbuffers(n, renderbuffers);
        }

        public static void GenTextures(Int32 n, [OutAttribute] UInt32[] textures)
        {
            Delegates.glGenTextures(n, textures);
        }

        public static void GenTransformFeedbacksNV(Int32 n, [OutAttribute] UInt32[] ids)
        {
            Delegates.glGenTransformFeedbacksNV(n, ids);
        }

        public static void GenVertexArrays(Int32 n, [OutAttribute] UInt32[] arrays)
        {
            Delegates.glGenVertexArrays(n, arrays);
        }

        public static void GenerateMipmap(OpenGL.GenerateMipmapTarget target)
        {
            Delegates.glGenerateMipmap(target);
        }

        public static void GetBooleanv(OpenGL.GetPName pname, [OutAttribute] bool[] @params)
        {
            Delegates.glGetBooleanv(pname, @params);
        }

        public static void GetDoublev(OpenGL.GetPName pname, [OutAttribute] Double[] @params)
        {
            Delegates.glGetDoublev(pname, @params);
        }

        public static void GetFloatv(OpenGL.GetPName pname, [OutAttribute] Single[] @params)
        {
            Delegates.glGetFloatv(pname, @params);
        }

        public static void GetIntegerv(OpenGL.GetPName pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetIntegerv(pname, @params);
        }

        public static void GetInteger64v(OpenGL.ArbSync pname, [OutAttribute] Int64[] @params)
        {
            Delegates.glGetInteger64v(pname, @params);
        }

        public static void GetActiveAttrib(UInt32 program, UInt32 index, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] Int32[] size, [OutAttribute] OpenGL.ActiveAttribType[] type, [OutAttribute] System.Text.StringBuilder name)
        {
            Delegates.glGetActiveAttrib(program, index, bufSize, length, size, type, name);
        }

        public static void GetActiveUniform(UInt32 program, UInt32 index, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] Int32[] size, [OutAttribute] OpenGL.ActiveUniformType[] type, [OutAttribute] System.Text.StringBuilder name)
        {
            Delegates.glGetActiveUniform(program, index, bufSize, length, size, type, name);
        }

        public static void GetActiveUniformBlockiv(UInt32 program, UInt32 uniformBlockIndex, OpenGL.ActiveUniformBlockParameter pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetActiveUniformBlockiv(program, uniformBlockIndex, pname, @params);
        }

        public static void GetActiveUniformBlockName(UInt32 program, UInt32 uniformBlockIndex, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder uniformBlockName)
        {
            Delegates.glGetActiveUniformBlockName(program, uniformBlockIndex, bufSize, length, uniformBlockName);
        }

        public static void GetActiveUniformName(UInt32 program, UInt32 uniformIndex, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder uniformName)
        {
            Delegates.glGetActiveUniformName(program, uniformIndex, bufSize, length, uniformName);
        }

        public static void GetAttachedShaders(UInt32 program, Int32 maxCount, [OutAttribute] Int32[] count, [OutAttribute] UInt32[] obj)
        {
            Delegates.glGetAttachedShaders(program, maxCount, count, obj);
        }

        public static Int32 GetAttribLocation(UInt32 program, String name)
        {
            return Delegates.glGetAttribLocation(program, name);
        }

        public static void GetBufferParameteriv(OpenGL.BufferTarget target, OpenGL.BufferParameterName pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetBufferParameteriv(target, pname, @params);
        }

        public static void GetBufferPointerv(OpenGL.BufferTarget target, OpenGL.BufferPointer pname, [OutAttribute] IntPtr @params)
        {
            Delegates.glGetBufferPointerv(target, pname, @params);
        }

        public static void GetBufferSubData(OpenGL.BufferTarget target, IntPtr offset, IntPtr size, [OutAttribute] IntPtr data)
        {
            Delegates.glGetBufferSubData(target, offset, size, data);
        }

        public static void GetCompressedTexImage(OpenGL.TextureTarget target, Int32 level, [OutAttribute] IntPtr img)
        {
            Delegates.glGetCompressedTexImage(target, level, img);
        }

        public static OpenGL.ErrorCode GetError()
        {
            return Delegates.glGetError();
        }

        public static Int32 GetFragDataLocation(UInt32 program, String name)
        {
            return Delegates.glGetFragDataLocation(program, name);
        }

        public static void GetFramebufferAttachmentParameteriv(OpenGL.FramebufferTarget target, OpenGL.FramebufferAttachment attachment, OpenGL.FramebufferParameterName pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetFramebufferAttachmentParameteriv(target, attachment, pname, @params);
        }

        public static void GetMultisamplefv(OpenGL.GetMultisamplePName pname, UInt32 index, [OutAttribute] Single[] val)
        {
            Delegates.glGetMultisamplefv(pname, index, val);
        }

        public static void GetProgramiv(UInt32 program, OpenGL.ProgramParameter pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetProgramiv(program, pname, @params);
        }

        public static void GetProgramInfoLog(UInt32 program, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder infoLog)
        {
            Delegates.glGetProgramInfoLog(program, bufSize, length, infoLog);
        }

        public static void GetQueryObjectiv(UInt32 id, OpenGL.GetQueryObjectParam pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetQueryObjectiv(id, pname, @params);
        }

        public static void GetQueryObjectuiv(UInt32 id, OpenGL.GetQueryObjectParam pname, [OutAttribute] UInt32[] @params)
        {
            Delegates.glGetQueryObjectuiv(id, pname, @params);
        }

        public static void GetQueryiv(OpenGL.QueryTarget target, OpenGL.GetQueryParam pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetQueryiv(target, pname, @params);
        }

        public static void GetRenderbufferParameteriv(OpenGL.RenderbufferTarget target, OpenGL.RenderbufferParameterName pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetRenderbufferParameteriv(target, pname, @params);
        }

        public static void GetShaderiv(UInt32 shader, OpenGL.ShaderParameter pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetShaderiv(shader, pname, @params);
        }

        public static void GetShaderInfoLog(UInt32 shader, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder infoLog)
        {
            Delegates.glGetShaderInfoLog(shader, bufSize, length, infoLog);
        }

        public static void GetShaderSource(UInt32 shader, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder source)
        {
            Delegates.glGetShaderSource(shader, bufSize, length, source);
        }

        public static System.IntPtr GetString(OpenGL.StringName name)
        {
            return Delegates.glGetString(name);
        }

        public static System.IntPtr GetStringi(OpenGL.StringName name, UInt32 index)
        {
            return Delegates.glGetStringi(name, index);
        }

        public static void GetSynciv(IntPtr sync, OpenGL.ArbSync pname, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] Int32[] values)
        {
            Delegates.glGetSynciv(sync, pname, bufSize, length, values);
        }

        public static void GetTexImage(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelFormat format, OpenGL.PixelType type, [OutAttribute] IntPtr pixels)
        {
            Delegates.glGetTexImage(target, level, format, type, pixels);
        }

        public static void GetTexParameterfv(OpenGL.TextureTarget target, OpenGL.GetTextureParameter pname, [OutAttribute] Single[] @params)
        {
            Delegates.glGetTexParameterfv(target, pname, @params);
        }

        public static void GetTexParameteriv(OpenGL.TextureTarget target, OpenGL.GetTextureParameter pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetTexParameteriv(target, pname, @params);
        }

        public static void GetTransformFeedbackVarying(UInt32 program, UInt32 index, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] Int32[] size, [OutAttribute] OpenGL.ActiveAttribType[] type, [OutAttribute] System.Text.StringBuilder name)
        {
            Delegates.glGetTransformFeedbackVarying(program, index, bufSize, length, size, type, name);
        }

        public static void GetUniformfv(UInt32 program, Int32 location, [OutAttribute] Single[] @params)
        {
            Delegates.glGetUniformfv(program, location, @params);
        }

        public static void GetUniformiv(UInt32 program, Int32 location, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetUniformiv(program, location, @params);
        }

        public static Int32 GetUniformLocation(UInt32 program, String name)
        {
            return Delegates.glGetUniformLocation(program, name);
        }

        public static void GetVertexAttribdv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Double[] @params)
        {
            Delegates.glGetVertexAttribdv(index, pname, @params);
        }

        public static void GetVertexAttribfv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Single[] @params)
        {
            Delegates.glGetVertexAttribfv(index, pname, @params);
        }

        public static void GetVertexAttribiv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetVertexAttribiv(index, pname, @params);
        }

        public static void GetVertexAttribIiv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetVertexAttribIiv(index, pname, @params);
        }

        public static void GetVertexAttribIuiv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] UInt32[] @params)
        {
            Delegates.glGetVertexAttribIuiv(index, pname, @params);
        }

        public static void GetVertexAttribLdv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Double[] @params)
        {
            Delegates.glGetVertexAttribLdv(index, pname, @params);
        }

        public static void GetVertexAttribPointerv(UInt32 index, OpenGL.VertexAttribPointerParameter pname, [OutAttribute] IntPtr pointer)
        {
            Delegates.glGetVertexAttribPointerv(index, pname, pointer);
        }

        public static void Hint(OpenGL.HintTarget target, OpenGL.HintMode mode)
        {
            Delegates.glHint(target, mode);
        }

        public static bool IsBuffer(UInt32 buffer)
        {
            return Delegates.glIsBuffer(buffer);
        }

        public static bool IsEnabled(OpenGL.EnableCap cap)
        {
            return Delegates.glIsEnabled(cap);
        }

        public static bool IsFramebuffer(UInt32 framebuffer)
        {
            return Delegates.glIsFramebuffer(framebuffer);
        }

        public static bool IsProgram(UInt32 program)
        {
            return Delegates.glIsProgram(program);
        }

        public static bool IsQuery(UInt32 id)
        {
            return Delegates.glIsQuery(id);
        }

        public static bool IsRenderbuffer(UInt32 renderbuffer)
        {
            return Delegates.glIsRenderbuffer(renderbuffer);
        }

        public static bool IsShader(UInt32 shader)
        {
            return Delegates.glIsShader(shader);
        }

        public static bool IsSync(IntPtr sync)
        {
            return Delegates.glIsSync(sync);
        }

        public static bool IsTexture(UInt32 texture)
        {
            return Delegates.glIsTexture(texture);
        }

        public static bool IsTransformFeedbackNV(UInt32 id)
        {
            return Delegates.glIsTransformFeedbackNV(id);
        }

        public static bool IsVertexArray(UInt32 array)
        {
            return Delegates.glIsVertexArray(array);
        }

        public static void LineWidth(Single width)
        {
            Delegates.glLineWidth(width);
        }

        public static void LinkProgram(UInt32 program)
        {
            Delegates.glLinkProgram(program);
        }

        public static void LogicOp(OpenGL.LogicOp opcode)
        {
            Delegates.glLogicOp(opcode);
        }

        public static System.IntPtr MapBuffer(OpenGL.BufferTarget target, OpenGL.BufferAccess access)
        {
            return Delegates.glMapBuffer(target, access);
        }

        public static System.IntPtr MapBufferRange(OpenGL.BufferTarget target, IntPtr offset, IntPtr length, OpenGL.BufferAccessMask access)
        {
            return Delegates.glMapBufferRange(target, offset, length, access);
        }

        public static void MultiDrawArrays(OpenGL.BeginMode mode, [OutAttribute] Int32[] first, [OutAttribute] Int32[] count, Int32 primcount)
        {
            Delegates.glMultiDrawArrays(mode, first, count, primcount);
        }

        public static void MultiDrawElements(OpenGL.BeginMode mode, Int32[] count, OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount)
        {
            Delegates.glMultiDrawElements(mode, count, type, indices, primcount);
        }

        public static void MultiDrawElementsBaseVertex(OpenGL.BeginMode mode, Int32[] count, OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount, Int32[] basevertex)
        {
            Delegates.glMultiDrawElementsBaseVertex(mode, count, type, indices, primcount, basevertex);
        }

        public static void PauseTransformFeedbackNV()
        {
            Delegates.glPauseTransformFeedbackNV();
        }

        public static void PixelStoref(OpenGL.PixelStoreParameter pname, Single param)
        {
            Delegates.glPixelStoref(pname, param);
        }

        public static void PixelStorei(OpenGL.PixelStoreParameter pname, Int32 param)
        {
            Delegates.glPixelStorei(pname, param);
        }

        public static void PointParameterf(OpenGL.PointParameterName pname, Single param)
        {
            Delegates.glPointParameterf(pname, param);
        }

        public static void PointParameteri(OpenGL.PointParameterName pname, Int32 param)
        {
            Delegates.glPointParameteri(pname, param);
        }

        public static void PointSize(float size)
        {
            Delegates.glPointSize(size);
        }

        public static void PolygonMode(OpenGL.MaterialFace face, OpenGL.PolygonMode mode)
        {
            Delegates.glPolygonMode(face, mode);
        }

        public static void PolygonOffset(Single factor, Single units)
        {
            Delegates.glPolygonOffset(factor, units);
        }

        public static void PrimitiveRestartIndex(UInt32 index)
        {
            Delegates.glPrimitiveRestartIndex(index);
        }

        public static void ProgramParameteri(UInt32 program, OpenGL.Version32 pname, Int32 value)
        {
            Delegates.glProgramParameteri(program, pname, value);
        }

        public static void ProvokingVertex(OpenGL.ProvokingVertexMode mode)
        {
            Delegates.glProvokingVertex(mode);
        }

        public static void ProgramUniform1fEXT(UInt32 program, Int32 location, Single v0)
        {
            Delegates.glProgramUniform1fEXT(program, location, v0);
        }

        public static void ProgramUniform1fvEXT(UInt32 program, Int32 location, Int32 count, Single[] value)
        {
            Delegates.glProgramUniform1fvEXT(program, location, count, value);
        }

        public static void ProgramUniform1iEXT(UInt32 program, Int32 location, Int32 v0)
        {
            Delegates.glProgramUniform1iEXT(program, location, v0);
        }

        public static void ProgramUniform1ivEXT(UInt32 program, Int32 location, Int32 count, Int32[] value)
        {
            Delegates.glProgramUniform1ivEXT(program, location, count, value);
        }

        public static void ProgramUniform1uiEXT(UInt32 program, Int32 location, UInt32 v0)
        {
            Delegates.glProgramUniform1uiEXT(program, location, v0);
        }

        public static void ProgramUniform1uivEXT(UInt32 program, Int32 location, Int32 count, UInt32[] value)
        {
            Delegates.glProgramUniform1uivEXT(program, location, count, value);
        }

        public static void ProgramUniform2fEXT(UInt32 program, Int32 location, Single v0, Single v1)
        {
            Delegates.glProgramUniform2fEXT(program, location, v0, v1);
        }

        public static void ProgramUniform2fvEXT(UInt32 program, Int32 location, Int32 count, Single[] value)
        {
            Delegates.glProgramUniform2fvEXT(program, location, count, value);
        }

        public static void ProgramUniform2iEXT(UInt32 program, Int32 location, Int32 v0, Int32 v1)
        {
            Delegates.glProgramUniform2iEXT(program, location, v0, v1);
        }

        public static void ProgramUniform2ivEXT(UInt32 program, Int32 location, Int32 count, Int32[] value)
        {
            Delegates.glProgramUniform2ivEXT(program, location, count, value);
        }

        public static void ProgramUniform2uiEXT(UInt32 program, Int32 location, UInt32 v0, UInt32 v1)
        {
            Delegates.glProgramUniform2uiEXT(program, location, v0, v1);
        }

        public static void ProgramUniform2uivEXT(UInt32 program, Int32 location, Int32 count, UInt32[] value)
        {
            Delegates.glProgramUniform2uivEXT(program, location, count, value);
        }

        public static void ProgramUniform3fEXT(UInt32 program, Int32 location, Single v0, Single v1, Single v2)
        {
            Delegates.glProgramUniform3fEXT(program, location, v0, v1, v2);
        }

        public static void ProgramUniform3fvEXT(UInt32 program, Int32 location, Int32 count, Single[] value)
        {
            Delegates.glProgramUniform3fvEXT(program, location, count, value);
        }

        public static void ProgramUniform3iEXT(UInt32 program, Int32 location, Int32 v0, Int32 v1, Int32 v2)
        {
            Delegates.glProgramUniform3iEXT(program, location, v0, v1, v2);
        }

        public static void ProgramUniform3ivEXT(UInt32 program, Int32 location, Int32 count, Int32[] value)
        {
            Delegates.glProgramUniform3ivEXT(program, location, count, value);
        }

        public static void ProgramUniform3uiEXT(UInt32 program, Int32 location, UInt32 v0, UInt32 v1, UInt32 v2)
        {
            Delegates.glProgramUniform3uiEXT(program, location, v0, v1, v2);
        }

        public static void ProgramUniform3uivEXT(UInt32 program, Int32 location, Int32 count, UInt32[] value)
        {
            Delegates.glProgramUniform3uivEXT(program, location, count, value);
        }

        public static void ProgramUniform4fEXT(UInt32 program, Int32 location, Single v0, Single v1, Single v2, Single v3)
        {
            Delegates.glProgramUniform4fEXT(program, location, v0, v1, v2, v3);
        }

        public static void ProgramUniform4fvEXT(UInt32 program, Int32 location, Int32 count, Single[] value)
        {
            Delegates.glProgramUniform4fvEXT(program, location, count, value);
        }

        public static void ProgramUniform4iEXT(UInt32 program, Int32 location, Int32 v0, Int32 v1, Int32 v2, Int32 v3)
        {
            Delegates.glProgramUniform4iEXT(program, location, v0, v1, v2, v3);
        }

        public static void ProgramUniform4ivEXT(UInt32 program, Int32 location, Int32 count, Int32[] value)
        {
            Delegates.glProgramUniform4ivEXT(program, location, count, value);
        }

        public static void ProgramUniform4uiEXT(UInt32 program, Int32 location, UInt32 v0, UInt32 v1, UInt32 v2, UInt32 v3)
        {
            Delegates.glProgramUniform4uiEXT(program, location, v0, v1, v2, v3);
        }

        public static void ProgramUniform4uivEXT(UInt32 program, Int32 location, Int32 count, UInt32[] value)
        {
            Delegates.glProgramUniform4uivEXT(program, location, count, value);
        }

        public static void ProgramUniformMatrix2fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix2fvEXT(program, location, count, transpose, value);
        }

        public static void ProgramUniformMatrix2x3fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix2x3fvEXT(program, location, count, transpose, value);
        }

        public static void ProgramUniformMatrix2x4fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix2x4fvEXT(program, location, count, transpose, value);
        }

        public static void ProgramUniformMatrix3fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix3fvEXT(program, location, count, transpose, value);
        }

        public static void ProgramUniformMatrix3x2fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix3x2fvEXT(program, location, count, transpose, value);
        }

        public static void ProgramUniformMatrix3x4fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix3x4fvEXT(program, location, count, transpose, value);
        }

        public static void ProgramUniformMatrix4fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix4fvEXT(program, location, count, transpose, value);
        }

        public static void ProgramUniformMatrix4x2fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix4x2fvEXT(program, location, count, transpose, value);
        }

        public static void ProgramUniformMatrix4x3fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glProgramUniformMatrix4x3fvEXT(program, location, count, transpose, value);
        }

        public static void ReadBuffer(OpenGL.ReadBufferMode mode)
        {
            Delegates.glReadBuffer(mode);
        }

        public static void ReadPixels(Int32 x, Int32 y, Int32 width, Int32 height, OpenGL.PixelFormat format, OpenGL.PixelType type, [OutAttribute] Int32[] pixels)
        {
            Delegates.glReadPixels(x, y, width, height, format, type, pixels);
        }

        public static void RenderbufferStorage(OpenGL.RenderbufferTarget target, OpenGL.RenderbufferStorage internalformat, Int32 width, Int32 height)
        {
            Delegates.glRenderbufferStorage(target, internalformat, width, height);
        }

        public static void RenderbufferStorageMultisample(OpenGL.RenderbufferTarget target, Int32 samples, OpenGL.RenderbufferStorage internalformat, Int32 width, Int32 height)
        {
            Delegates.glRenderbufferStorageMultisample(target, samples, internalformat, width, height);
        }

        public static void ResumeTransformFeedbackNV()
        {
            Delegates.glResumeTransformFeedbackNV();
        }

        public static void SampleCoverage(Single value, bool invert)
        {
            Delegates.glSampleCoverage(value, invert);
        }

        public static void SampleMaski(UInt32 index, UInt32 mask)
        {
            Delegates.glSampleMaski(index, mask);
        }

        public static void Scissor(Int32 x, Int32 y, Int32 width, Int32 height)
        {
            Delegates.glScissor(x, y, width, height);
        }

        public static void ShaderSource(UInt32 shader, Int32 count, String[] @string, Int32[] length)
        {
            Delegates.glShaderSource(shader, count, @string, length);
        }

        public static void StencilFunc(OpenGL.StencilFunction func, Int32 @ref, UInt32 mask)
        {
            Delegates.glStencilFunc(func, @ref, mask);
        }

        public static void StencilFuncSeparate(OpenGL.StencilFace face, OpenGL.StencilFunction func, Int32 @ref, UInt32 mask)
        {
            Delegates.glStencilFuncSeparate(face, func, @ref, mask);
        }

        public static void StencilMask(UInt32 mask)
        {
            Delegates.glStencilMask(mask);
        }

        public static void StencilMaskSeparate(OpenGL.StencilFace face, UInt32 mask)
        {
            Delegates.glStencilMaskSeparate(face, mask);
        }

        public static void StencilOp(OpenGL.StencilOp fail, OpenGL.StencilOp zfail, OpenGL.StencilOp zpass)
        {
            Delegates.glStencilOp(fail, zfail, zpass);
        }

        public static void StencilOpSeparate(OpenGL.StencilFace face, OpenGL.StencilOp sfail, OpenGL.StencilOp dpfail, OpenGL.StencilOp dppass)
        {
            Delegates.glStencilOpSeparate(face, sfail, dpfail, dppass);
        }

        public static void TexBuffer(OpenGL.TextureBufferTarget target, OpenGL.SizedInternalFormat internalformat, UInt32 buffer)
        {
            Delegates.glTexBuffer(target, internalformat, buffer);
        }

        public static void TexImage1D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 border, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels)
        {
            Delegates.glTexImage1D(target, level, internalformat, width, border, format, type, pixels);
        }

        public static void TexImage2D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 border, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels)
        {
            Delegates.glTexImage2D(target, level, internalformat, width, height, border, format, type, pixels);
        }

        public static void TexImage2DMultisample(OpenGL.TextureTargetMultisample target, Int32 samples, OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, bool fixedsamplelocations)
        {
            Delegates.glTexImage2DMultisample(target, samples, internalformat, width, height, fixedsamplelocations);
        }

        public static void TexImage3D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 depth, Int32 border, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels)
        {
            Delegates.glTexImage3D(target, level, internalformat, width, height, depth, border, format, type, pixels);
        }

        public static void TexImage3DMultisample(OpenGL.TextureTargetMultisample target, Int32 samples, OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 depth, bool fixedsamplelocations)
        {
            Delegates.glTexImage3DMultisample(target, samples, internalformat, width, height, depth, fixedsamplelocations);
        }

        public static void TexParameterf(OpenGL.TextureTarget target, OpenGL.TextureParameterName pname, Single param)
        {
            Delegates.glTexParameterf(target, pname, param);
        }

        public static void TexParameteri(OpenGL.TextureTarget target, OpenGL.TextureParameterName pname, Int32 param)
        {
            Delegates.glTexParameteri(target, pname, param);
        }

        public static void TexSubImage1D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 width, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels)
        {
            Delegates.glTexSubImage1D(target, level, xoffset, width, format, type, pixels);
        }

        public static void TexSubImage2D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels)
        {
            Delegates.glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels);
        }

        public static void TexSubImage3D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels)
        {
            Delegates.glTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
        }

        public static void TransformFeedbackVaryings(UInt32 program, Int32 count, String[] varyings, OpenGL.TransformFeedbackMode bufferMode)
        {
            Delegates.glTransformFeedbackVaryings(program, count, varyings, bufferMode);
        }

        public static void Uniform1f(Int32 location, Single v0)
        {
            Delegates.glUniform1f(location, v0);
        }

        public static void Uniform1fv(Int32 location, Int32 count, Single[] value)
        {
            Delegates.glUniform1fv(location, count, value);
        }

        public static void Uniform1i(Int32 location, Int32 v0)
        {
            Delegates.glUniform1i(location, v0);
        }

        public static void Uniform1iv(Int32 location, Int32 count, Int32[] value)
        {
            Delegates.glUniform1iv(location, count, value);
        }

        public static void Uniform1ui(Int32 location, UInt32 v0)
        {
            Delegates.glUniform1ui(location, v0);
        }

        public static void Uniform1uiv(Int32 location, Int32 count, UInt32[] value)
        {
            Delegates.glUniform1uiv(location, count, value);
        }

        public static void Uniform2f(Int32 location, Single v0, Single v1)
        {
            Delegates.glUniform2f(location, v0, v1);
        }

        public static void Uniform2fv(Int32 location, Int32 count, Single[] value)
        {
            Delegates.glUniform2fv(location, count, value);
        }

        public static void Uniform2i(Int32 location, Int32 v0, Int32 v1)
        {
            Delegates.glUniform2i(location, v0, v1);
        }

        public static void Uniform2iv(Int32 location, Int32 count, Int32[] value)
        {
            Delegates.glUniform2iv(location, count, value);
        }

        public static void Uniform2ui(Int32 location, UInt32 v0, UInt32 v1)
        {
            Delegates.glUniform2ui(location, v0, v1);
        }

        public static void Uniform2uiv(Int32 location, Int32 count, UInt32[] value)
        {
            Delegates.glUniform2uiv(location, count, value);
        }

        public static void Uniform3f(Int32 location, Single v0, Single v1, Single v2)
        {
            Delegates.glUniform3f(location, v0, v1, v2);
        }

        public static void Uniform3fv(Int32 location, Int32 count, Single[] value)
        {
            Delegates.glUniform3fv(location, count, value);
        }

        public static void Uniform3i(Int32 location, Int32 v0, Int32 v1, Int32 v2)
        {
            Delegates.glUniform3i(location, v0, v1, v2);
        }

        public static void Uniform3iv(Int32 location, Int32 count, Int32[] value)
        {
            Delegates.glUniform3iv(location, count, value);
        }

        public static void Uniform3ui(Int32 location, UInt32 v0, UInt32 v1, UInt32 v2)
        {
            Delegates.glUniform3ui(location, v0, v1, v2);
        }

        public static void Uniform3uiv(Int32 location, Int32 count, UInt32[] value)
        {
            Delegates.glUniform3uiv(location, count, value);
        }

        public static void Uniform4f(Int32 location, Single v0, Single v1, Single v2, Single v3)
        {
            Delegates.glUniform4f(location, v0, v1, v2, v3);
        }

        public static void Uniform4fv(Int32 location, Int32 count, Single[] value)
        {
            Delegates.glUniform4fv(location, count, value);
        }

        public static void Uniform4i(Int32 location, Int32 v0, Int32 v1, Int32 v2, Int32 v3)
        {
            Delegates.glUniform4i(location, v0, v1, v2, v3);
        }

        public static void Uniform4iv(Int32 location, Int32 count, Int32[] value)
        {
            Delegates.glUniform4iv(location, count, value);
        }

        public static void Uniform4ui(Int32 location, UInt32 v0, UInt32 v1, UInt32 v2, UInt32 v3)
        {
            Delegates.glUniform4ui(location, v0, v1, v2, v3);
        }

        public static void Uniform4uiv(Int32 location, Int32 count, UInt32[] value)
        {
            Delegates.glUniform4uiv(location, count, value);
        }

        public static void UniformMatrix2fv(Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glUniformMatrix2fv(location, count, transpose, value);
        }

        public static void UniformMatrix2x3fv(Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glUniformMatrix2x3fv(location, count, transpose, value);
        }

        public static void UniformMatrix2x4fv(Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glUniformMatrix2x4fv(location, count, transpose, value);
        }

        public static void UniformMatrix3fv(Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glUniformMatrix3fv(location, count, transpose, value);
        }

        public static void UniformMatrix3x2fv(Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glUniformMatrix3x2fv(location, count, transpose, value);
        }

        public static void UniformMatrix3x4fv(Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glUniformMatrix3x4fv(location, count, transpose, value);
        }

        public static void UniformMatrix4fv(Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glUniformMatrix4fv(location, count, transpose, value);
        }

        public static void UniformMatrix4x2fv(Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glUniformMatrix4x2fv(location, count, transpose, value);
        }

        public static void UniformMatrix4x3fv(Int32 location, Int32 count, bool transpose, Single[] value)
        {
            Delegates.glUniformMatrix4x3fv(location, count, transpose, value);
        }

        public static void UniformBlockBinding(UInt32 program, UInt32 uniformBlockIndex, UInt32 uniformBlockBinding)
        {
            Delegates.glUniformBlockBinding(program, uniformBlockIndex, uniformBlockBinding);
        }

        public static bool UnmapBuffer(OpenGL.BufferTarget target)
        {
            return Delegates.glUnmapBuffer(target);
        }

        public static void UseProgram(UInt32 program)
        {
            Delegates.glUseProgram(program);
        }

        public static void VertexAttrib1d(UInt32 index, Double x)
        {
            Delegates.glVertexAttrib1d(index, x);
        }

        public static void VertexAttrib1dv(UInt32 index, Double[] v)
        {
            Delegates.glVertexAttrib1dv(index, v);
        }

        public static void VertexAttrib1f(UInt32 index, Single x)
        {
            Delegates.glVertexAttrib1f(index, x);
        }

        public static void VertexAttrib1fv(UInt32 index, Single[] v)
        {
            Delegates.glVertexAttrib1fv(index, v);
        }

        public static void VertexAttrib1s(UInt32 index, Int16 x)
        {
            Delegates.glVertexAttrib1s(index, x);
        }

        public static void VertexAttrib1sv(UInt32 index, Int16[] v)
        {
            Delegates.glVertexAttrib1sv(index, v);
        }

        public static void VertexAttrib2d(UInt32 index, Double x, Double y)
        {
            Delegates.glVertexAttrib2d(index, x, y);
        }

        public static void VertexAttrib2dv(UInt32 index, Double[] v)
        {
            Delegates.glVertexAttrib2dv(index, v);
        }

        public static void VertexAttrib2f(UInt32 index, Single x, Single y)
        {
            Delegates.glVertexAttrib2f(index, x, y);
        }

        public static void VertexAttrib2fv(UInt32 index, Single[] v)
        {
            Delegates.glVertexAttrib2fv(index, v);
        }

        public static void VertexAttrib2s(UInt32 index, Int16 x, Int16 y)
        {
            Delegates.glVertexAttrib2s(index, x, y);
        }

        public static void VertexAttrib2sv(UInt32 index, Int16[] v)
        {
            Delegates.glVertexAttrib2sv(index, v);
        }

        public static void VertexAttrib3d(UInt32 index, Double x, Double y, Double z)
        {
            Delegates.glVertexAttrib3d(index, x, y, z);
        }

        public static void VertexAttrib3dv(UInt32 index, Double[] v)
        {
            Delegates.glVertexAttrib3dv(index, v);
        }

        public static void VertexAttrib3f(UInt32 index, Single x, Single y, Single z)
        {
            Delegates.glVertexAttrib3f(index, x, y, z);
        }

        public static void VertexAttrib3fv(UInt32 index, Single[] v)
        {
            Delegates.glVertexAttrib3fv(index, v);
        }

        public static void VertexAttrib3s(UInt32 index, Int16 x, Int16 y, Int16 z)
        {
            Delegates.glVertexAttrib3s(index, x, y, z);
        }

        public static void VertexAttrib3sv(UInt32 index, Int16[] v)
        {
            Delegates.glVertexAttrib3sv(index, v);
        }

        public static void VertexAttrib4bv(UInt32 index, SByte[] v)
        {
            Delegates.glVertexAttrib4bv(index, v);
        }

        public static void VertexAttrib4d(UInt32 index, Double x, Double y, Double z, Double w)
        {
            Delegates.glVertexAttrib4d(index, x, y, z, w);
        }

        public static void VertexAttrib4dv(UInt32 index, Double[] v)
        {
            Delegates.glVertexAttrib4dv(index, v);
        }

        public static void VertexAttrib4f(UInt32 index, Single x, Single y, Single z, Single w)
        {
            Delegates.glVertexAttrib4f(index, x, y, z, w);
        }

        public static void VertexAttrib4fv(UInt32 index, Single[] v)
        {
            Delegates.glVertexAttrib4fv(index, v);
        }

        public static void VertexAttrib4iv(UInt32 index, Int32[] v)
        {
            Delegates.glVertexAttrib4iv(index, v);
        }

        public static void VertexAttrib4Nbv(UInt32 index, SByte[] v)
        {
            Delegates.glVertexAttrib4Nbv(index, v);
        }

        public static void VertexAttrib4Niv(UInt32 index, Int32[] v)
        {
            Delegates.glVertexAttrib4Niv(index, v);
        }

        public static void VertexAttrib4Nsv(UInt32 index, Int16[] v)
        {
            Delegates.glVertexAttrib4Nsv(index, v);
        }

        public static void VertexAttrib4Nub(UInt32 index, Byte x, Byte y, Byte z, Byte w)
        {
            Delegates.glVertexAttrib4Nub(index, x, y, z, w);
        }

        public static void VertexAttrib4Nubv(UInt32 index, Byte[] v)
        {
            Delegates.glVertexAttrib4Nubv(index, v);
        }

        public static void VertexAttrib4Nuiv(UInt32 index, UInt32[] v)
        {
            Delegates.glVertexAttrib4Nuiv(index, v);
        }

        public static void VertexAttrib4Nusv(UInt32 index, UInt16[] v)
        {
            Delegates.glVertexAttrib4Nusv(index, v);
        }

        public static void VertexAttrib4s(UInt32 index, Int16 x, Int16 y, Int16 z, Int16 w)
        {
            Delegates.glVertexAttrib4s(index, x, y, z, w);
        }

        public static void VertexAttrib4sv(UInt32 index, Int16[] v)
        {
            Delegates.glVertexAttrib4sv(index, v);
        }

        public static void VertexAttrib4ubv(UInt32 index, Byte[] v)
        {
            Delegates.glVertexAttrib4ubv(index, v);
        }

        public static void VertexAttrib4uiv(UInt32 index, UInt32[] v)
        {
            Delegates.glVertexAttrib4uiv(index, v);
        }

        public static void VertexAttrib4usv(UInt32 index, UInt16[] v)
        {
            Delegates.glVertexAttrib4usv(index, v);
        }

        public static void VertexAttribI1i(UInt32 index, Int32 x)
        {
            Delegates.glVertexAttribI1i(index, x);
        }

        public static void VertexAttribI1iv(UInt32 index, Int32[] v)
        {
            Delegates.glVertexAttribI1iv(index, v);
        }

        public static void VertexAttribI1ui(UInt32 index, UInt32 x)
        {
            Delegates.glVertexAttribI1ui(index, x);
        }

        public static void VertexAttribI1uiv(UInt32 index, UInt32[] v)
        {
            Delegates.glVertexAttribI1uiv(index, v);
        }

        public static void VertexAttribI2i(UInt32 index, Int32 x, Int32 y)
        {
            Delegates.glVertexAttribI2i(index, x, y);
        }

        public static void VertexAttribI2iv(UInt32 index, Int32[] v)
        {
            Delegates.glVertexAttribI2iv(index, v);
        }

        public static void VertexAttribI2ui(UInt32 index, UInt32 x, UInt32 y)
        {
            Delegates.glVertexAttribI2ui(index, x, y);
        }

        public static void VertexAttribI2uiv(UInt32 index, UInt32[] v)
        {
            Delegates.glVertexAttribI2uiv(index, v);
        }

        public static void VertexAttribI3i(UInt32 index, Int32 x, Int32 y, Int32 z)
        {
            Delegates.glVertexAttribI3i(index, x, y, z);
        }

        public static void VertexAttribI3iv(UInt32 index, Int32[] v)
        {
            Delegates.glVertexAttribI3iv(index, v);
        }

        public static void VertexAttribI3ui(UInt32 index, UInt32 x, UInt32 y, UInt32 z)
        {
            Delegates.glVertexAttribI3ui(index, x, y, z);
        }

        public static void VertexAttribI3uiv(UInt32 index, UInt32[] v)
        {
            Delegates.glVertexAttribI3uiv(index, v);
        }

        public static void VertexAttribI4bv(UInt32 index, SByte[] v)
        {
            Delegates.glVertexAttribI4bv(index, v);
        }

        public static void VertexAttribI4i(UInt32 index, Int32 x, Int32 y, Int32 z, Int32 w)
        {
            Delegates.glVertexAttribI4i(index, x, y, z, w);
        }

        public static void VertexAttribI4iv(UInt32 index, Int32[] v)
        {
            Delegates.glVertexAttribI4iv(index, v);
        }

        public static void VertexAttribI4sv(UInt32 index, Int16[] v)
        {
            Delegates.glVertexAttribI4sv(index, v);
        }

        public static void VertexAttribI4ubv(UInt32 index, Byte[] v)
        {
            Delegates.glVertexAttribI4ubv(index, v);
        }

        public static void VertexAttribI4ui(UInt32 index, UInt32 x, UInt32 y, UInt32 z, UInt32 w)
        {
            Delegates.glVertexAttribI4ui(index, x, y, z, w);
        }

        public static void VertexAttribI4uiv(UInt32 index, UInt32[] v)
        {
            Delegates.glVertexAttribI4uiv(index, v);
        }

        public static void VertexAttribI4usv(UInt32 index, UInt16[] v)
        {
            Delegates.glVertexAttribI4usv(index, v);
        }

        public static void VertexAttribDivisor(UInt32 index, UInt32 divisor)
        {
            Delegates.glVertexAttribDivisor(index, divisor);
        }

        public static void VertexAttribPointer(UInt32 index, Int32 size, OpenGL.VertexAttribPointerType type, bool normalized, Int32 stride, IntPtr pointer)
        {
            Delegates.glVertexAttribPointer(index, size, type, normalized, stride, pointer);
        }

        public static void Viewport(Int32 x, Int32 y, Int32 width, Int32 height)
        {
            Delegates.glViewport(x, y, width, height);
        }

        public static void WaitSync(IntPtr sync, UInt32 flags, UInt64 timeout)
        {
            Delegates.glWaitSync(sync, flags, timeout);
        }

        public static void ActiveShaderProgram(UInt32 pipeline, UInt32 program)
        {
            Delegates.glActiveShaderProgram(pipeline, program);
        }

        public static void BeginQueryIndexed(UInt32 target, UInt32 index, UInt32 id)
        {
            Delegates.glBeginQueryIndexed(target, index, id);
        }

        public static void BindFragDataLocationIndexed(UInt32 program, UInt32 colorNumber, UInt32 index, char[] name)
        {
            Delegates.glBindFragDataLocationIndexed(program, colorNumber, index, name);
        }

        public static void BindSampler(UInt32 unit, UInt32 sampler)
        {
            Delegates.glBindSampler(unit, sampler);
        }

        public static Int32 CreateShaderProgram(OpenGL.ShaderType type, UInt32 count, string[] strings)
        {
            return Delegates.glCreateShaderProgram(type, count, strings);
        }

        public static void DeleteProgramPipelines(Int32 n, UInt32[] ids)
        {
            Delegates.glDeleteProgramPipelines(n, ids);
        }

        public static void DepthRangeArrayv(UInt32 index, Double near, Double far)
        {
            Delegates.glDepthRangeArrayv(index, near, far);
        }

        public static void DrawArraysIndirect(OpenGL.BeginMode mode, IntPtr indirect)
        {
            Delegates.glDrawArraysIndirect(mode, indirect);
        }

        public static void DrawTransformFeedbackStream(OpenGL.NvTransformFeedback2 mode, UInt32 id, UInt32 stream)
        {
            Delegates.glDrawTransformFeedbackStream(mode, id, stream);
        }

        public static void EndQueryIndexed(OpenGL.QueryTarget target, UInt32 index, UInt32 id)
        {
            Delegates.glEndQueryIndexed(target, index, id);
        }

        public static void GenProgramPipelines(Int32 n, [OutAttribute] UInt32[] pipelines)
        {
            Delegates.glGenProgramPipelines(n, pipelines);
        }

        public static void GenSamplers(Int32 n, [OutAttribute] UInt32[] samplers)
        {
            Delegates.glGenSamplers(n, samplers);
        }

        public static void GetFragDataIndex(UInt32 program, String name)
        {
            Delegates.glGetFragDataIndex(program, name);
        }

        public static void GetProgramBinary(UInt32 program, Int32 size, Int32[] length, Int32[] binaryFormat, IntPtr binary)
        {
            Delegates.glGetProgramBinary(program, size, length, binaryFormat, binary);
        }

        public static void GetProgramPipelineiv(UInt32 pipeline, Int32 pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetProgramPipelineiv(pipeline, pname, @params);
        }

        public static void GetProgramPipelineInfoLog(UInt32 pipeline, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder infoLog)
        {
            Delegates.glGetProgramPipelineInfoLog(pipeline, bufSize, length, infoLog);
        }

        public static void GetProgramStage(UInt32 program, OpenGL.ShaderType shadertype, Int32 pname, [OutAttribute] Int32[] @values)
        {
            Delegates.glGetProgramStage(program, shadertype, pname, @values);
        }

        public static void GetQueryObjecti64v(UInt32 id, OpenGL.GetQueryObjectParam pname, [OutAttribute] UInt64[] @params)
        {
            Delegates.glGetQueryObjecti64v(id, pname, @params);
        }

        public static void GetQueryObjectui64v(UInt32 id, OpenGL.GetQueryObjectParam pname, [OutAttribute] UInt64[] @params)
        {
            Delegates.glGetQueryObjectui64v(id, pname, @params);
        }

        public static void GetSamplerParameterfv(UInt32 sampler, Int32 pname, [OutAttribute] Single[] @params)
        {
            Delegates.glGetSamplerParameterfv(sampler, pname, @params);
        }

        public static void GetSamplerParameteriv(UInt32 sampler, Int32 pname, [OutAttribute] Int32[] @params)
        {
            Delegates.glGetSamplerParameteriv(sampler, pname, @params);
        }

        public static void GetShaderPrecisionFormat(OpenGL.ShaderType shaderType, Int32 precisionType, Int32[] range, [OutAttribute] Int32[] precision)
        {
            Delegates.glGetShaderPrecisionFormat(shaderType, precisionType, range, precision);
        }

        public static UInt32 GetUniformBlockIndex(UInt32 program, String uniformBlockName)
        {
            return Delegates.glGetUniformBlockIndex(program, uniformBlockName);
        }

        public static UInt32 GetUniformIndices(UInt32 program, Int32 uniformCount, String[] uniformNames, UInt32[] uniformIndices)
        {
            return Delegates.glGetUniformIndices(program, uniformCount, uniformNames, uniformIndices);
        }

        public static void GetUniformSubroutineuiv(OpenGL.ShaderType shaderType, Int32 location, [OutAttribute] UInt32[] values)
        {
            Delegates.glGetUniformSubroutineuiv(shaderType, location, values);
        }

        public static bool IsProgramPipeline(UInt32 pipeline)
        {
            return Delegates.glIsProgramPipeline(pipeline);
        }

        public static bool IsSampler(UInt32 id)
        {
            return Delegates.glIsSampler(id);
        }

        public static void PatchParameteri(Int32 pname, Int32 value)
        {
            Delegates.glPatchParameteri(pname, value);
        }

        public static void PatchParameterfv(Int32 pname, Single value)
        {
            Delegates.glPatchParameterfv(pname, value);
        }

        public static void ProgramBinary(UInt32 program, Int32 binaryFormat, IntPtr binary, Int32 length)
        {
            Delegates.glProgramBinary(program, binaryFormat, binary, length);
        }

        public static void QueryCounter(UInt32 id, Int32 target)
        {
            Delegates.glQueryCounter(id, target);
        }

        public static void ReleaseShaderCompiler()
        {
            Delegates.glReleaseShaderCompiler();
        }

        public static void SamplerParameterf(UInt32 sampler, Int32 pname, Single param)
        {
            Delegates.glSamplerParameterf(sampler, pname, param);
        }

        public static void SamplerParameteri(UInt32 sampler, Int32 pname, Int32 param)
        {
            Delegates.glSamplerParameteri(sampler, pname, param);
        }

        public static void ScissorArrayv(UInt32 first, Int32 count, Int32[] v)
        {
            Delegates.glScissorArrayv(first, count, v);
        }

        public static void ShaderBinary(Int32 count, UInt32[] shaders, Int32 binaryFormat, IntPtr binary, Int32 length)
        {
            Delegates.glShaderBinary(count, shaders, binaryFormat, binary, length);
        }

        public static void UniformSubroutinesuiv(ShaderType shaderType, Int32 count, UInt32[] indices)
        {
            Delegates.glUniformSubroutinesuiv(shaderType, count, indices);
        }

        public static void UseProgramStages(UInt32 pipeline, Int32 bitField, UInt32 program)
        {
            Delegates.glUseProgramStages(pipeline, bitField, program);
        }

        public static void ValidateProgram(UInt32 program)
        {
            Delegates.glValidateProgram(program);
        }

        public static void ValidateProgramPipeline(UInt32 pipeline)
        {
            Delegates.glValidateProgramPipeline(pipeline);
        }

        public static void ViewportArray(UInt32 first, Int32 count, Single[] v)
        {
            Delegates.glViewportArray(first, count, v);
        }

        public static void ViewportIndexedf(UInt32 index, Single x, Single y, Single w, Single h)
        {
            Delegates.glViewportIndexedf(index, x, y, w, h);
        }

        public static void ViewportIndexedfv(UInt32 index, Single[] v)
        {
            Delegates.glViewportIndexedfv(index, v);
        }

    }
}
