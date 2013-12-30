#define OPENGL4

using System;
using System.Runtime.InteropServices;

namespace OpenGL
{
    partial class Gl
    {
        internal static partial class Core
        {
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glActiveTexture", ExactSpelling = true)]
            internal extern static void ActiveTexture(OpenGL.TextureUnit texture);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glAttachShader", ExactSpelling = true)]
            internal extern static void AttachShader(UInt32 program, UInt32 shader);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBeginConditionalRender", ExactSpelling = true)]
            internal extern static void BeginConditionalRender(UInt32 id, OpenGL.ConditionalRenderType mode);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBeginQuery", ExactSpelling = true)]
            internal extern static void BeginQuery(OpenGL.QueryTarget target, UInt32 id);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBeginTransformFeedback", ExactSpelling = true)]
            internal extern static void BeginTransformFeedback(OpenGL.BeginFeedbackMode primitiveMode);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBindAttribLocation", ExactSpelling = true)]
            internal extern static void BindAttribLocation(UInt32 program, UInt32 index, String name);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBindBuffer", ExactSpelling = true)]
            internal extern static void BindBuffer(OpenGL.BufferTarget target, UInt32 buffer);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBindBufferBase", ExactSpelling = true)]
            internal extern static void BindBufferBase(OpenGL.BufferTarget target, UInt32 index, UInt32 buffer);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBindBufferRange", ExactSpelling = true)]
            internal extern static void BindBufferRange(BufferTarget target, UInt32 index, UInt32 buffer, IntPtr offset, IntPtr size);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBindFragDataLocation", ExactSpelling = true)]
            internal extern static void BindFragDataLocation(UInt32 program, UInt32 color, String name);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBindFramebuffer", ExactSpelling = true)]
            internal extern static void BindFramebuffer(OpenGL.FramebufferTarget target, UInt32 framebuffer);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBindRenderbuffer", ExactSpelling = true)]
            internal extern static void BindRenderbuffer(OpenGL.RenderbufferTarget target, UInt32 renderbuffer);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBindTexture", ExactSpelling = true)]
            internal extern static void BindTexture(OpenGL.TextureTarget target, UInt32 texture);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBindTransformFeedbackNV", ExactSpelling = true)]
            internal extern static void BindTransformFeedbackNV(OpenGL.NvTransformFeedback2 target, UInt32 id);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBindVertexArray", ExactSpelling = true)]
            internal extern static void BindVertexArray(UInt32 array);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBlendColor", ExactSpelling = true)]
            internal extern static void BlendColor(Single red, Single green, Single blue, Single alpha);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBlendEquation", ExactSpelling = true)]
            internal extern static void BlendEquation(OpenGL.BlendEquationMode mode);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBlendEquationSeparate", ExactSpelling = true)]
            internal extern static void BlendEquationSeparate(OpenGL.BlendEquationMode modeRGB, OpenGL.BlendEquationMode modeAlpha);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBlendFunc", ExactSpelling = true)]
            internal extern static void BlendFunc(OpenGL.BlendingFactorSrc sfactor, OpenGL.BlendingFactorDest dfactor);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBlendFuncSeparate", ExactSpelling = true)]
            internal extern static void BlendFuncSeparate(OpenGL.BlendingFactorSrc sfactorRGB, OpenGL.BlendingFactorDest dfactorRGB, OpenGL.BlendingFactorSrc sfactorAlpha, OpenGL.BlendingFactorDest dfactorAlpha);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBlitFramebuffer", ExactSpelling = true)]
            internal extern static void BlitFramebuffer(Int32 srcX0, Int32 srcY0, Int32 srcX1, Int32 srcY1, Int32 dstX0, Int32 dstY0, Int32 dstX1, Int32 dstY1, OpenGL.ClearBufferMask mask, OpenGL.BlitFramebufferFilter filter);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBufferData", ExactSpelling = true)]
            internal extern static void BufferData(OpenGL.BufferTarget target, IntPtr size, IntPtr data, OpenGL.BufferUsageHint usage);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBufferSubData", ExactSpelling = true)]
            internal extern static void BufferSubData(OpenGL.BufferTarget target, IntPtr offset, IntPtr size, IntPtr data);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCheckFramebufferStatus", ExactSpelling = true)]
            internal extern static OpenGL.FramebufferErrorCode CheckFramebufferStatus(OpenGL.FramebufferTarget target);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glClampColor", ExactSpelling = true)]
            internal extern static void ClampColor(OpenGL.ClampColorTarget target, OpenGL.ClampColorMode clamp);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glClear", ExactSpelling = true)]
            internal extern static void Clear(OpenGL.ClearBufferMask mask);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glClearBufferfi", ExactSpelling = true)]
            internal extern static void ClearBufferfi(OpenGL.ClearBuffer buffer, Int32 drawbuffer, Single depth, Int32 stencil);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glClearDepth", ExactSpelling = true)]
            internal extern static void ClearDepth(Double depth);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glClearStencil", ExactSpelling = true)]
            internal extern static void ClearStencil(Int32 s);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glClientWaitSync", ExactSpelling = true)]
            internal extern static OpenGL.ArbSync ClientWaitSync(IntPtr sync, UInt32 flags, UInt64 timeout);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glColorMask", ExactSpelling = true)]
            internal extern static void ColorMask(bool red, bool green, bool blue, bool alpha);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCompileShader", ExactSpelling = true)]
            internal extern static void CompileShader(UInt32 shader);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCompressedTexImage1D", ExactSpelling = true)]
            internal extern static void CompressedTexImage1D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 border, Int32 imageSize, IntPtr data);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCompressedTexImage2D", ExactSpelling = true)]
            internal extern static void CompressedTexImage2D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 border, Int32 imageSize, IntPtr data);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCompressedTexImage3D", ExactSpelling = true)]
            internal extern static void CompressedTexImage3D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 depth, Int32 border, Int32 imageSize, IntPtr data);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCompressedTexSubImage1D", ExactSpelling = true)]
            internal extern static void CompressedTexSubImage1D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 width, OpenGL.PixelFormat format, Int32 imageSize, IntPtr data);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCompressedTexSubImage2D", ExactSpelling = true)]
            internal extern static void CompressedTexSubImage2D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenGL.PixelFormat format, Int32 imageSize, IntPtr data);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCompressedTexSubImage3D", ExactSpelling = true)]
            internal extern static void CompressedTexSubImage3D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenGL.PixelFormat format, Int32 imageSize, IntPtr data);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCopyBufferSubData", ExactSpelling = true)]
            internal extern static void CopyBufferSubData(OpenGL.BufferTarget readTarget, OpenGL.BufferTarget writeTarget, IntPtr readOffset, IntPtr writeOffset, IntPtr size);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCopyTexImage1D", ExactSpelling = true)]
            internal extern static void CopyTexImage1D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalformat, Int32 x, Int32 y, Int32 width, Int32 border);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCopyTexImage2D", ExactSpelling = true)]
            internal extern static void CopyTexImage2D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalformat, Int32 x, Int32 y, Int32 width, Int32 height, Int32 border);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCopyTexSubImage1D", ExactSpelling = true)]
            internal extern static void CopyTexSubImage1D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 x, Int32 y, Int32 width);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCopyTexSubImage2D", ExactSpelling = true)]
            internal extern static void CopyTexSubImage2D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 x, Int32 y, Int32 width, Int32 height);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCopyTexSubImage3D", ExactSpelling = true)]
            internal extern static void CopyTexSubImage3D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 x, Int32 y, Int32 width, Int32 height);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCreateProgram", ExactSpelling = true)]
            internal extern static UInt32 CreateProgram();
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCreateShader", ExactSpelling = true)]
            internal extern static UInt32 CreateShader(OpenGL.ShaderType type);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCullFace", ExactSpelling = true)]
            internal extern static void CullFace(OpenGL.CullFaceMode mode);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDeleteBuffers", ExactSpelling = true)]
            internal extern static void DeleteBuffers(Int32 n, UInt32[] buffers);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDeleteFramebuffers", ExactSpelling = true)]
            internal extern static void DeleteFramebuffers(Int32 n, UInt32[] framebuffers);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDeleteProgram", ExactSpelling = true)]
            internal extern static void DeleteProgram(UInt32 program);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDeleteQueries", ExactSpelling = true)]
            internal extern static void DeleteQueries(Int32 n, UInt32[] ids);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDeleteRenderbuffers", ExactSpelling = true)]
            internal extern static void DeleteRenderbuffers(Int32 n, UInt32[] renderbuffers);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDeleteShader", ExactSpelling = true)]
            internal extern static void DeleteShader(UInt32 shader);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDeleteSync", ExactSpelling = true)]
            internal extern static void DeleteSync(IntPtr sync);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDeleteTextures", ExactSpelling = true)]
            internal extern static void DeleteTextures(Int32 n, UInt32[] textures);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDeleteTransformFeedbacksNV", ExactSpelling = true)]
            internal extern static void DeleteTransformFeedbacksNV(Int32 n, UInt32[] ids);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDeleteVertexArrays", ExactSpelling = true)]
            internal extern static void DeleteVertexArrays(Int32 n, UInt32[] arrays);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDepthFunc", ExactSpelling = true)]
            internal extern static void DepthFunc(OpenGL.DepthFunction func);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDepthMask", ExactSpelling = true)]
            internal extern static void DepthMask(bool flag);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDepthRange", ExactSpelling = true)]
            internal extern static void DepthRange(Double near, Double far);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDetachShader", ExactSpelling = true)]
            internal extern static void DetachShader(UInt32 program, UInt32 shader);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDisable", ExactSpelling = true)]
            internal extern static void Disable(OpenGL.EnableCap cap);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDisableVertexAttribArray", ExactSpelling = true)]
            internal extern static void DisableVertexAttribArray(UInt32 index);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDrawArrays", ExactSpelling = true)]
            internal extern static void DrawArrays(OpenGL.BeginMode mode, Int32 first, Int32 count);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDrawArraysInstanced", ExactSpelling = true)]
            internal extern static void DrawArraysInstanced(OpenGL.BeginMode mode, Int32 first, Int32 count, Int32 primcount);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDrawBuffer", ExactSpelling = true)]
            internal extern static void DrawBuffer(OpenGL.DrawBufferMode mode);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDrawBuffers", ExactSpelling = true)]
            internal extern static void DrawBuffers(Int32 n, OpenGL.DrawBuffersEnum[] bufs);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDrawElements", ExactSpelling = true)]
            internal extern static void DrawElements(OpenGL.BeginMode mode, Int32 count, OpenGL.DrawElementsType type, IntPtr indices);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDrawElementsBaseVertex", ExactSpelling = true)]
            internal extern static void DrawElementsBaseVertex(OpenGL.BeginMode mode, Int32 count, OpenGL.DrawElementsType type, IntPtr indices, Int32 basevertex);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDrawElementsInstanced", ExactSpelling = true)]
            internal extern static void DrawElementsInstanced(OpenGL.BeginMode mode, Int32 count, OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDrawElementsInstancedBaseVertex", ExactSpelling = true)]
            internal extern static void DrawElementsInstancedBaseVertex(OpenGL.BeginMode mode, Int32 count, OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount, Int32 basevertex);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDrawRangeElements", ExactSpelling = true)]
            internal extern static void DrawRangeElements(OpenGL.BeginMode mode, UInt32 start, UInt32 end, Int32 count, OpenGL.DrawElementsType type, IntPtr indices);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDrawRangeElementsBaseVertex", ExactSpelling = true)]
            internal extern static void DrawRangeElementsBaseVertex(OpenGL.BeginMode mode, UInt32 start, UInt32 end, Int32 count, OpenGL.DrawElementsType type, IntPtr indices, Int32 basevertex);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDrawTransformFeedbackNV", ExactSpelling = true)]
            internal extern static void DrawTransformFeedbackNV(OpenGL.NvTransformFeedback2 mode, UInt32 id);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glEnable", ExactSpelling = true)]
            internal extern static void Enable(OpenGL.EnableCap cap);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glEnableVertexAttribArray", ExactSpelling = true)]
            internal extern static void EnableVertexAttribArray(UInt32 index);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glEndConditionalRenderNV", ExactSpelling = true)]
            internal extern static void EndConditionalRenderNV();
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glEndQuery", ExactSpelling = true)]
            internal extern static void EndQuery(OpenGL.QueryTarget target);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glEndTransformFeedback", ExactSpelling = true)]
            internal extern static void EndTransformFeedback();

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glFenceSync", ExactSpelling = true)]
            internal extern static IntPtr FenceSync(OpenGL.ArbSync condition, UInt32 flags);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glFinish", ExactSpelling = true)]
            internal extern static void Finish();
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glFlush", ExactSpelling = true)]
            internal extern static void Flush();
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glFlushMappedBufferRange", ExactSpelling = true)]
            internal extern static void FlushMappedBufferRange(OpenGL.BufferTarget target, IntPtr offset, IntPtr length);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glFramebufferRenderbuffer", ExactSpelling = true)]
            internal extern static void FramebufferRenderbuffer(OpenGL.FramebufferTarget target, OpenGL.FramebufferAttachment attachment, OpenGL.RenderbufferTarget renderbuffertarget, UInt32 renderbuffer);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glFramebufferTexture", ExactSpelling = true)]
            internal extern static void FramebufferTexture(OpenGL.FramebufferTarget target, OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glFramebufferTextureFace", ExactSpelling = true)]
            internal extern static void FramebufferTextureFace(OpenGL.Version32 target, OpenGL.Version32 attachment, UInt32 texture, Int32 level, OpenGL.Version32 face);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glFramebufferTextureLayer", ExactSpelling = true)]
            internal extern static void FramebufferTextureLayer(OpenGL.FramebufferTarget target, OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level, Int32 layer);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glFrontFace", ExactSpelling = true)]
            internal extern static void FrontFace(OpenGL.FrontFaceDirection mode);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGenBuffers", ExactSpelling = true)]
            internal extern static void GenBuffers(Int32 n, [OutAttribute] UInt32[] buffers);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGenFramebuffers", ExactSpelling = true)]
            internal extern static void GenFramebuffers(Int32 n, [OutAttribute] UInt32[] framebuffers);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGenQueries", ExactSpelling = true)]
            internal extern static void GenQueries(Int32 n, [OutAttribute] UInt32[] ids);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGenRenderbuffers", ExactSpelling = true)]
            internal extern static void GenRenderbuffers(Int32 n, [OutAttribute] UInt32[] renderbuffers);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGenTextures", ExactSpelling = true)]
            internal extern static void GenTextures(Int32 n, [OutAttribute] UInt32[] textures);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGenTransformFeedbacksNV", ExactSpelling = true)]
            internal extern static void GenTransformFeedbacksNV(Int32 n, [OutAttribute] UInt32[] ids);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGenVertexArrays", ExactSpelling = true)]
            internal extern static void GenVertexArrays(Int32 n, [OutAttribute] UInt32[] arrays);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGenerateMipmap", ExactSpelling = true)]
            internal extern static void GenerateMipmap(OpenGL.GenerateMipmapTarget target);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetBooleanv", ExactSpelling = true)]
            internal extern static void GetBooleanv(OpenGL.GetPName pname, [OutAttribute] bool[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetDoublev", ExactSpelling = true)]
            internal extern static void GetDoublev(OpenGL.GetPName pname, [OutAttribute] Double[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetFloatv", ExactSpelling = true)]
            internal extern static void GetFloatv(OpenGL.GetPName pname, [OutAttribute] Single[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetIntegerv", ExactSpelling = true)]
            internal extern static void GetIntegerv(OpenGL.GetPName pname, [OutAttribute] Int32[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetInteger64v", ExactSpelling = true)]
            internal extern static void GetInteger64v(OpenGL.ArbSync pname, [OutAttribute] Int64[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetActiveAttrib", ExactSpelling = true)]
            internal extern static void GetActiveAttrib(UInt32 program, UInt32 index, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] Int32[] size, [OutAttribute] OpenGL.ActiveAttribType[] type, [OutAttribute] System.Text.StringBuilder name);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetActiveUniform", ExactSpelling = true)]
            internal extern static void GetActiveUniform(UInt32 program, UInt32 index, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] Int32[] size, [OutAttribute] OpenGL.ActiveUniformType[] type, [OutAttribute] System.Text.StringBuilder name);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetActiveUniformBlockiv", ExactSpelling = true)]
            internal extern static void GetActiveUniformBlockiv(UInt32 program, UInt32 uniformBlockIndex, OpenGL.ActiveUniformBlockParameter pname, [OutAttribute] Int32[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetActiveUniformBlockName", ExactSpelling = true)]
            internal extern static void GetActiveUniformBlockName(UInt32 program, UInt32 uniformBlockIndex, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder uniformBlockName);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetActiveUniformName", ExactSpelling = true)]
            internal extern static void GetActiveUniformName(UInt32 program, UInt32 uniformIndex, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder uniformName);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetAttachedShaders", ExactSpelling = true)]
            internal extern static void GetAttachedShaders(UInt32 program, Int32 maxCount, [OutAttribute] Int32[] count, [OutAttribute] UInt32[] obj);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetAttribLocation", ExactSpelling = true)]
            internal extern static Int32 GetAttribLocation(UInt32 program, String name);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetBufferParameteriv", ExactSpelling = true)]
            internal extern static void GetBufferParameteriv(OpenGL.BufferTarget target, OpenGL.BufferParameterName pname, [OutAttribute] Int32[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetBufferPointerv", ExactSpelling = true)]
            internal extern static void GetBufferPointerv(OpenGL.BufferTarget target, OpenGL.BufferPointer pname, [OutAttribute] IntPtr @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetBufferSubData", ExactSpelling = true)]
            internal extern static void GetBufferSubData(OpenGL.BufferTarget target, IntPtr offset, IntPtr size, [OutAttribute] IntPtr data);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetCompressedTexImage", ExactSpelling = true)]
            internal extern static void GetCompressedTexImage(OpenGL.TextureTarget target, Int32 level, [OutAttribute] IntPtr img);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetError", ExactSpelling = true)]
            internal extern static OpenGL.ErrorCode GetError();
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetFragDataLocation", ExactSpelling = true)]
            internal extern static Int32 GetFragDataLocation(UInt32 program, String name);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetFramebufferAttachmentParameteriv", ExactSpelling = true)]
            internal extern static void GetFramebufferAttachmentParameteriv(OpenGL.FramebufferTarget target, OpenGL.FramebufferAttachment attachment, OpenGL.FramebufferParameterName pname, [OutAttribute] Int32[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetMultisamplefv", ExactSpelling = true)]
            internal extern static void GetMultisamplefv(OpenGL.GetMultisamplePName pname, UInt32 index, [OutAttribute] Single[] val);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetProgramiv", ExactSpelling = true)]
            internal extern static void GetProgramiv(UInt32 program, OpenGL.ProgramParameter pname, [OutAttribute] Int32[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetProgramInfoLog", ExactSpelling = true)]
            internal extern static void GetProgramInfoLog(UInt32 program, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder infoLog);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetQueryObjectiv", ExactSpelling = true)]
            internal extern static void GetQueryObjectiv(UInt32 id, OpenGL.GetQueryObjectParam pname, [OutAttribute] Int32[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetQueryObjectuiv", ExactSpelling = true)]
            internal extern static void GetQueryObjectuiv(UInt32 id, OpenGL.GetQueryObjectParam pname, [OutAttribute] UInt32[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetQueryiv", ExactSpelling = true)]
            internal extern static void GetQueryiv(OpenGL.QueryTarget target, OpenGL.GetQueryParam pname, [OutAttribute] Int32[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetRenderbufferParameteriv", ExactSpelling = true)]
            internal extern static void GetRenderbufferParameteriv(OpenGL.RenderbufferTarget target, OpenGL.RenderbufferParameterName pname, [OutAttribute] Int32[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetShaderiv", ExactSpelling = true)]
            internal extern static void GetShaderiv(UInt32 shader, OpenGL.ShaderParameter pname, [OutAttribute] Int32[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetShaderInfoLog", ExactSpelling = true)]
            internal extern static void GetShaderInfoLog(UInt32 shader, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder infoLog);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetShaderSource", ExactSpelling = true)]
            internal extern static void GetShaderSource(UInt32 shader, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder source);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetString", ExactSpelling = true)]
            internal extern static System.IntPtr GetString(OpenGL.StringName name);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetStringi", ExactSpelling = true)]
            internal extern static System.IntPtr GetStringi(OpenGL.StringName name, UInt32 index);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetSynciv", ExactSpelling = true)]
            internal extern static void GetSynciv(IntPtr sync, OpenGL.ArbSync pname, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] Int32[] values);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetTexImage", ExactSpelling = true)]
            internal extern static void GetTexImage(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelFormat format, OpenGL.PixelType type, [OutAttribute] IntPtr pixels);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetTexParameterfv", ExactSpelling = true)]
            internal extern static void GetTexParameterfv(OpenGL.TextureTarget target, OpenGL.GetTextureParameter pname, [OutAttribute] Single[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetTexParameteriv", ExactSpelling = true)]
            internal extern static void GetTexParameteriv(OpenGL.TextureTarget target, OpenGL.GetTextureParameter pname, [OutAttribute] Int32[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetTransformFeedbackVarying", ExactSpelling = true)]
            internal extern static void GetTransformFeedbackVarying(UInt32 program, UInt32 index, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] Int32[] size, [OutAttribute] OpenGL.ActiveAttribType[] type, [OutAttribute] System.Text.StringBuilder name);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetUniformfv", ExactSpelling = true)]
            internal extern static void GetUniformfv(UInt32 program, Int32 location, [OutAttribute] Single[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetUniformiv", ExactSpelling = true)]
            internal extern static void GetUniformiv(UInt32 program, Int32 location, [OutAttribute] Int32[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetUniformLocation", ExactSpelling = true)]
            internal extern static Int32 GetUniformLocation(UInt32 program, String name);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetVertexAttribdv", ExactSpelling = true)]
            internal extern static void GetVertexAttribdv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Double[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetVertexAttribfv", ExactSpelling = true)]
            internal extern static void GetVertexAttribfv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Single[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetVertexAttribiv", ExactSpelling = true)]
            internal extern static void GetVertexAttribiv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Int32[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetVertexAttribIiv", ExactSpelling = true)]
            internal extern static void GetVertexAttribIiv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Int32[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetVertexAttribIuiv", ExactSpelling = true)]
            internal extern static void GetVertexAttribIuiv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] UInt32[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetVertexAttribLdv", ExactSpelling = true)]
            internal extern static void GetVertexAttribLdv(UInt32 index, OpenGL.VertexAttribParameter pname, [OutAttribute] Double[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetVertexAttribPointerv", ExactSpelling = true)]
            internal extern static void GetVertexAttribPointerv(UInt32 index, OpenGL.VertexAttribPointerParameter pname, [OutAttribute] IntPtr pointer);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glHint", ExactSpelling = true)]
            internal extern static void Hint(OpenGL.HintTarget target, OpenGL.HintMode mode);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glIsBuffer", ExactSpelling = true)]
            internal extern static bool IsBuffer(UInt32 buffer);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glIsEnabled", ExactSpelling = true)]
            internal extern static bool IsEnabled(OpenGL.EnableCap cap);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glIsFramebuffer", ExactSpelling = true)]
            internal extern static bool IsFramebuffer(UInt32 framebuffer);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glIsProgram", ExactSpelling = true)]
            internal extern static bool IsProgram(UInt32 program);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glIsQuery", ExactSpelling = true)]
            internal extern static bool IsQuery(UInt32 id);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glIsRenderbuffer", ExactSpelling = true)]
            internal extern static bool IsRenderbuffer(UInt32 renderbuffer);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glIsShader", ExactSpelling = true)]
            internal extern static bool IsShader(UInt32 shader);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glIsSync", ExactSpelling = true)]
            internal extern static bool IsSync(IntPtr sync);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glIsTexture", ExactSpelling = true)]
            internal extern static bool IsTexture(UInt32 texture);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glIsTransformFeedbackNV", ExactSpelling = true)]
            internal extern static bool IsTransformFeedbackNV(UInt32 id);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glIsVertexArray", ExactSpelling = true)]
            internal extern static bool IsVertexArray(UInt32 array);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glLineWidth", ExactSpelling = true)]
            internal extern static void LineWidth(Single width);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glLinkProgram", ExactSpelling = true)]
            internal extern static void LinkProgram(UInt32 program);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glLogicOp", ExactSpelling = true)]
            internal extern static void LogicOp(OpenGL.LogicOp opcode);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glMapBuffer", ExactSpelling = true)]
            internal extern static System.IntPtr MapBuffer(OpenGL.BufferTarget target, OpenGL.BufferAccess access);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glMapBufferRange", ExactSpelling = true)]
            internal extern static System.IntPtr MapBufferRange(OpenGL.BufferTarget target, IntPtr offset, IntPtr length, OpenGL.BufferAccessMask access);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glMultiDrawArrays", ExactSpelling = true)]
            internal extern static void MultiDrawArrays(OpenGL.BeginMode mode, [OutAttribute] Int32[] first, [OutAttribute] Int32[] count, Int32 primcount);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glMultiDrawElements", ExactSpelling = true)]
            internal extern static void MultiDrawElements(OpenGL.BeginMode mode, Int32[] count, OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glMultiDrawElementsBaseVertex", ExactSpelling = true)]
            internal extern static void MultiDrawElementsBaseVertex(OpenGL.BeginMode mode, Int32[] count, OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount, Int32[] basevertex);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glPauseTransformFeedbackNV", ExactSpelling = true)]
            internal extern static void PauseTransformFeedbackNV();
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glPixelStoref", ExactSpelling = true)]
            internal extern static void PixelStoref(OpenGL.PixelStoreParameter pname, Single param);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glPixelStorei", ExactSpelling = true)]
            internal extern static void PixelStorei(OpenGL.PixelStoreParameter pname, Int32 param);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glPointParameterf", ExactSpelling = true)]
            internal extern static void PointParameterf(OpenGL.PointParameterName pname, Single param);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glPointParameteri", ExactSpelling = true)]
            internal extern static void PointParameteri(OpenGL.PointParameterName pname, Int32 param);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glPointSize", ExactSpelling = true)]
            internal extern static void PointSize(float size);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glPolygonMode", ExactSpelling = true)]
            internal extern static void PolygonMode(OpenGL.MaterialFace face, OpenGL.PolygonMode mode);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glPolygonOffset", ExactSpelling = true)]
            internal extern static void PolygonOffset(Single factor, Single units);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glPrimitiveRestartIndex", ExactSpelling = true)]
            internal extern static void PrimitiveRestartIndex(UInt32 index);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramParameteri", ExactSpelling = true)]
            internal extern static void ProgramParameteri(UInt32 program, OpenGL.Version32 pname, Int32 value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProvokingVertex", ExactSpelling = true)]
            internal extern static void ProvokingVertex(OpenGL.ProvokingVertexMode mode);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform1fEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform1fEXT(UInt32 program, Int32 location, Single v0);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform1fvEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform1fvEXT(UInt32 program, Int32 location, Int32 count, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform1iEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform1iEXT(UInt32 program, Int32 location, Int32 v0);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform1ivEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform1ivEXT(UInt32 program, Int32 location, Int32 count, Int32[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform1uiEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform1uiEXT(UInt32 program, Int32 location, UInt32 v0);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform1uivEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform1uivEXT(UInt32 program, Int32 location, Int32 count, UInt32[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform2fEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform2fEXT(UInt32 program, Int32 location, Single v0, Single v1);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform2fvEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform2fvEXT(UInt32 program, Int32 location, Int32 count, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform2iEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform2iEXT(UInt32 program, Int32 location, Int32 v0, Int32 v1);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform2ivEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform2ivEXT(UInt32 program, Int32 location, Int32 count, Int32[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform2uiEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform2uiEXT(UInt32 program, Int32 location, UInt32 v0, UInt32 v1);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform2uivEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform2uivEXT(UInt32 program, Int32 location, Int32 count, UInt32[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform3fEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform3fEXT(UInt32 program, Int32 location, Single v0, Single v1, Single v2);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform3fvEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform3fvEXT(UInt32 program, Int32 location, Int32 count, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform3iEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform3iEXT(UInt32 program, Int32 location, Int32 v0, Int32 v1, Int32 v2);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform3ivEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform3ivEXT(UInt32 program, Int32 location, Int32 count, Int32[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform3uiEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform3uiEXT(UInt32 program, Int32 location, UInt32 v0, UInt32 v1, UInt32 v2);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform3uivEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform3uivEXT(UInt32 program, Int32 location, Int32 count, UInt32[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform4fEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform4fEXT(UInt32 program, Int32 location, Single v0, Single v1, Single v2, Single v3);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform4fvEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform4fvEXT(UInt32 program, Int32 location, Int32 count, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform4iEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform4iEXT(UInt32 program, Int32 location, Int32 v0, Int32 v1, Int32 v2, Int32 v3);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform4ivEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform4ivEXT(UInt32 program, Int32 location, Int32 count, Int32[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform4uiEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform4uiEXT(UInt32 program, Int32 location, UInt32 v0, UInt32 v1, UInt32 v2, UInt32 v3);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniform4uivEXT", ExactSpelling = true)]
            internal extern static void ProgramUniform4uivEXT(UInt32 program, Int32 location, Int32 count, UInt32[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniformMatrix2fvEXT", ExactSpelling = true)]
            internal extern static void ProgramUniformMatrix2fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniformMatrix2x3fvEXT", ExactSpelling = true)]
            internal extern static void ProgramUniformMatrix2x3fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniformMatrix2x4fvEXT", ExactSpelling = true)]
            internal extern static void ProgramUniformMatrix2x4fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniformMatrix3fvEXT", ExactSpelling = true)]
            internal extern static void ProgramUniformMatrix3fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniformMatrix3x2fvEXT", ExactSpelling = true)]
            internal extern static void ProgramUniformMatrix3x2fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniformMatrix3x4fvEXT", ExactSpelling = true)]
            internal extern static void ProgramUniformMatrix3x4fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniformMatrix4fvEXT", ExactSpelling = true)]
            internal extern static void ProgramUniformMatrix4fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniformMatrix4x2fvEXT", ExactSpelling = true)]
            internal extern static void ProgramUniformMatrix4x2fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramUniformMatrix4x3fvEXT", ExactSpelling = true)]
            internal extern static void ProgramUniformMatrix4x3fvEXT(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glReadBuffer", ExactSpelling = true)]
            internal extern static void ReadBuffer(OpenGL.ReadBufferMode mode);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glReadPixels", ExactSpelling = true)]
            internal extern static void ReadPixels(Int32 x, Int32 y, Int32 width, Int32 height, OpenGL.PixelFormat format, OpenGL.PixelType type, [OutAttribute] Int32[] pixels);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glRenderbufferStorage", ExactSpelling = true)]
            internal extern static void RenderbufferStorage(OpenGL.RenderbufferTarget target, OpenGL.RenderbufferStorage internalformat, Int32 width, Int32 height);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glRenderbufferStorageMultisample", ExactSpelling = true)]
            internal extern static void RenderbufferStorageMultisample(OpenGL.RenderbufferTarget target, Int32 samples, OpenGL.RenderbufferStorage internalformat, Int32 width, Int32 height);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glResumeTransformFeedbackNV", ExactSpelling = true)]
            internal extern static void ResumeTransformFeedbackNV();

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glSampleCoverage", ExactSpelling = true)]
            internal extern static void SampleCoverage(Single value, bool invert);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glSampleMaski", ExactSpelling = true)]
            internal extern static void SampleMaski(UInt32 index, UInt32 mask);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glScissor", ExactSpelling = true)]
            internal extern static void Scissor(Int32 x, Int32 y, Int32 width, Int32 height);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glShaderSource", ExactSpelling = true)]
            internal extern static void ShaderSource(UInt32 shader, Int32 count, String[] @string, Int32[] length);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glStencilFunc", ExactSpelling = true)]
            internal extern static void StencilFunc(OpenGL.StencilFunction func, Int32 @ref, UInt32 mask);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glStencilFuncSeparate", ExactSpelling = true)]
            internal extern static void StencilFuncSeparate(OpenGL.StencilFace face, OpenGL.StencilFunction func, Int32 @ref, UInt32 mask);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glStencilMask", ExactSpelling = true)]
            internal extern static void StencilMask(UInt32 mask);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glStencilMaskSeparate", ExactSpelling = true)]
            internal extern static void StencilMaskSeparate(OpenGL.StencilFace face, UInt32 mask);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glStencilOp", ExactSpelling = true)]
            internal extern static void StencilOp(OpenGL.StencilOp fail, OpenGL.StencilOp zfail, OpenGL.StencilOp zpass);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glStencilOpSeparate", ExactSpelling = true)]
            internal extern static void StencilOpSeparate(OpenGL.StencilFace face, OpenGL.StencilOp sfail, OpenGL.StencilOp dpfail, OpenGL.StencilOp dppass);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glTexBuffer", ExactSpelling = true)]
            internal extern static void TexBuffer(OpenGL.TextureBufferTarget target, OpenGL.SizedInternalFormat internalformat, UInt32 buffer);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glTexImage1D", ExactSpelling = true)]
            internal extern static void TexImage1D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 border, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glTexImage2D", ExactSpelling = true)]
            internal extern static void TexImage2D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 border, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glTexImage2DMultisample", ExactSpelling = true)]
            internal extern static void TexImage2DMultisample(OpenGL.TextureTargetMultisample target, Int32 samples, OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, bool fixedsamplelocations);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glTexImage3D", ExactSpelling = true)]
            internal extern static void TexImage3D(OpenGL.TextureTarget target, Int32 level, OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 depth, Int32 border, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glTexImage3DMultisample", ExactSpelling = true)]
            internal extern static void TexImage3DMultisample(OpenGL.TextureTargetMultisample target, Int32 samples, OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 depth, bool fixedsamplelocations);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glTexParameterf", ExactSpelling = true)]
            internal extern static void TexParameterf(OpenGL.TextureTarget target, OpenGL.TextureParameterName pname, Single param);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glTexParameteri", ExactSpelling = true)]
            internal extern static void TexParameteri(OpenGL.TextureTarget target, OpenGL.TextureParameterName pname, Int32 param);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glTexSubImage1D", ExactSpelling = true)]
            internal extern static void TexSubImage1D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 width, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glTexSubImage2D", ExactSpelling = true)]
            internal extern static void TexSubImage2D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glTexSubImage3D", ExactSpelling = true)]
            internal extern static void TexSubImage3D(OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenGL.PixelFormat format, OpenGL.PixelType type, IntPtr pixels);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glTransformFeedbackVaryings", ExactSpelling = true)]
            internal extern static void TransformFeedbackVaryings(UInt32 program, Int32 count, String[] varyings, OpenGL.TransformFeedbackMode bufferMode);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform1f", ExactSpelling = true)]
            internal extern static void Uniform1f(Int32 location, Single v0); 
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform1fv", ExactSpelling = true)]
            internal extern static void Uniform1fv(Int32 location, Int32 count, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform1i", ExactSpelling = true)]
            internal extern static void Uniform1i(Int32 location, Int32 v0);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform1iv", ExactSpelling = true)]
            internal extern static void Uniform1iv(Int32 location, Int32 count, Int32[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform1ui", ExactSpelling = true)]
            internal extern static void Uniform1ui(Int32 location, UInt32 v0);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform1uiv", ExactSpelling = true)]
            internal extern static void Uniform1uiv(Int32 location, Int32 count, UInt32[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform2f", ExactSpelling = true)]
            internal extern static void Uniform2f(Int32 location, Single v0, Single v1);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform2fv", ExactSpelling = true)]
            internal extern static void Uniform2fv(Int32 location, Int32 count, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform2i", ExactSpelling = true)]
            internal extern static void Uniform2i(Int32 location, Int32 v0, Int32 v1);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform2iv", ExactSpelling = true)]
            internal extern static void Uniform2iv(Int32 location, Int32 count, Int32[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform2ui", ExactSpelling = true)]
            internal extern static void Uniform2ui(Int32 location, UInt32 v0, UInt32 v1);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform2uiv", ExactSpelling = true)]
            internal extern static void Uniform2uiv(Int32 location, Int32 count, UInt32[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform3f", ExactSpelling = true)]
            internal extern static void Uniform3f(Int32 location, Single v0, Single v1, Single v2);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform3fv", ExactSpelling = true)]
            internal extern static void Uniform3fv(Int32 location, Int32 count, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform3i", ExactSpelling = true)]
            internal extern static void Uniform3i(Int32 location, Int32 v0, Int32 v1, Int32 v2);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform3iv", ExactSpelling = true)]
            internal extern static void Uniform3iv(Int32 location, Int32 count, Int32[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform3ui", ExactSpelling = true)]
            internal extern static void Uniform3ui(Int32 location, UInt32 v0, UInt32 v1, UInt32 v2);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform3uiv", ExactSpelling = true)]
            internal extern static void Uniform3uiv(Int32 location, Int32 count, UInt32[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform4f", ExactSpelling = true)]
            internal extern static void Uniform4f(Int32 location, Single v0, Single v1, Single v2, Single v3);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform4fv", ExactSpelling = true)]
            internal extern static void Uniform4fv(Int32 location, Int32 count, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform4i", ExactSpelling = true)]
            internal extern static void Uniform4i(Int32 location, Int32 v0, Int32 v1, Int32 v2, Int32 v3);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform4iv", ExactSpelling = true)]
            internal extern static void Uniform4iv(Int32 location, Int32 count, Int32[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform4ui", ExactSpelling = true)]
            internal extern static void Uniform4ui(Int32 location, UInt32 v0, UInt32 v1, UInt32 v2, UInt32 v3);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniform4uiv", ExactSpelling = true)]
            internal extern static void Uniform4uiv(Int32 location, Int32 count, UInt32[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniformMatrix2fv", ExactSpelling = true)]
            internal extern static void UniformMatrix2fv(Int32 location, Int32 count, bool transpose, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniformMatrix2x3fv", ExactSpelling = true)]
            internal extern static void UniformMatrix2x3fv(Int32 location, Int32 count, bool transpose, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniformMatrix2x4fv", ExactSpelling = true)]
            internal extern static void UniformMatrix2x4fv(Int32 location, Int32 count, bool transpose, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniformMatrix3fv", ExactSpelling = true)]
            internal extern static void UniformMatrix3fv(Int32 location, Int32 count, bool transpose, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniformMatrix3x2fv", ExactSpelling = true)]
            internal extern static void UniformMatrix3x2fv(Int32 location, Int32 count, bool transpose, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniformMatrix3x4fv", ExactSpelling = true)]
            internal extern static void UniformMatrix3x4fv(Int32 location, Int32 count, bool transpose, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniformMatrix4fv", ExactSpelling = true)]
            internal extern static void UniformMatrix4fv(Int32 location, Int32 count, bool transpose, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniformMatrix4x2fv", ExactSpelling = true)]
            internal extern static void UniformMatrix4x2fv(Int32 location, Int32 count, bool transpose, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniformMatrix4x3fv", ExactSpelling = true)]
            internal extern static void UniformMatrix4x3fv(Int32 location, Int32 count, bool transpose, Single[] value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniformBlockBinding", ExactSpelling = true)]
            internal extern static void UniformBlockBinding(UInt32 program, UInt32 uniformBlockIndex, UInt32 uniformBlockBinding);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUnmapBuffer", ExactSpelling = true)]
            internal extern static bool UnmapBuffer(OpenGL.BufferTarget target);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUseProgram", ExactSpelling = true)]
            internal extern static void UseProgram(UInt32 program);
            
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib1d", ExactSpelling = true)]
            internal extern static void VertexAttrib1d(UInt32 index, Double x);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib1dv", ExactSpelling = true)]
            internal extern static void VertexAttrib1dv(UInt32 index, Double[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib1f", ExactSpelling = true)]
            internal extern static void VertexAttrib1f(UInt32 index, Single x);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib1fv", ExactSpelling = true)]
            internal extern static void VertexAttrib1fv(UInt32 index, Single[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib1s", ExactSpelling = true)]
            internal extern static void VertexAttrib1s(UInt32 index, Int16 x);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib1sv", ExactSpelling = true)]
            internal extern static void VertexAttrib1sv(UInt32 index, Int16[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib2d", ExactSpelling = true)]
            internal extern static void VertexAttrib2d(UInt32 index, Double x, Double y);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib2dv", ExactSpelling = true)]
            internal extern static void VertexAttrib2dv(UInt32 index, Double[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib2f", ExactSpelling = true)]
            internal extern static void VertexAttrib2f(UInt32 index, Single x, Single y);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib2fv", ExactSpelling = true)]
            internal extern static void VertexAttrib2fv(UInt32 index, Single[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib2s", ExactSpelling = true)]
            internal extern static void VertexAttrib2s(UInt32 index, Int16 x, Int16 y);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib2sv", ExactSpelling = true)]
            internal extern static void VertexAttrib2sv(UInt32 index, Int16[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib3d", ExactSpelling = true)]
            internal extern static void VertexAttrib3d(UInt32 index, Double x, Double y, Double z);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib3dv", ExactSpelling = true)]
            internal extern static void VertexAttrib3dv(UInt32 index, Double[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib3f", ExactSpelling = true)]
            internal extern static void VertexAttrib3f(UInt32 index, Single x, Single y, Single z);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib3fv", ExactSpelling = true)]
            internal extern static void VertexAttrib3fv(UInt32 index, Single[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib3s", ExactSpelling = true)]
            internal extern static void VertexAttrib3s(UInt32 index, Int16 x, Int16 y, Int16 z);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib3sv", ExactSpelling = true)]
            internal extern static void VertexAttrib3sv(UInt32 index, Int16[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4bv", ExactSpelling = true)]
            internal extern static void VertexAttrib4bv(UInt32 index, SByte[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4d", ExactSpelling = true)]
            internal extern static void VertexAttrib4d(UInt32 index, Double x, Double y, Double z, Double w);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4dv", ExactSpelling = true)]
            internal extern static void VertexAttrib4dv(UInt32 index, Double[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4f", ExactSpelling = true)]
            internal extern static void VertexAttrib4f(UInt32 index, Single x, Single y, Single z, Single w);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4fv", ExactSpelling = true)]
            internal extern static void VertexAttrib4fv(UInt32 index, Single[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4iv", ExactSpelling = true)]
            internal extern static void VertexAttrib4iv(UInt32 index, Int32[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4Nbv", ExactSpelling = true)]
            internal extern static void VertexAttrib4Nbv(UInt32 index, SByte[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4Niv", ExactSpelling = true)]
            internal extern static void VertexAttrib4Niv(UInt32 index, Int32[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4Nsv", ExactSpelling = true)]
            internal extern static void VertexAttrib4Nsv(UInt32 index, Int16[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4Nub", ExactSpelling = true)]
            internal extern static void VertexAttrib4Nub(UInt32 index, Byte x, Byte y, Byte z, Byte w);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4Nubv", ExactSpelling = true)]
            internal extern static void VertexAttrib4Nubv(UInt32 index, Byte[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4Nuiv", ExactSpelling = true)]
            internal extern static void VertexAttrib4Nuiv(UInt32 index, UInt32[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4Nusv", ExactSpelling = true)]
            internal extern static void VertexAttrib4Nusv(UInt32 index, UInt16[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4s", ExactSpelling = true)]
            internal extern static void VertexAttrib4s(UInt32 index, Int16 x, Int16 y, Int16 z, Int16 w);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4sv", ExactSpelling = true)]
            internal extern static void VertexAttrib4sv(UInt32 index, Int16[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4ubv", ExactSpelling = true)]
            internal extern static void VertexAttrib4ubv(UInt32 index, Byte[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4uiv", ExactSpelling = true)]
            internal extern static void VertexAttrib4uiv(UInt32 index, UInt32[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttrib4usv", ExactSpelling = true)]
            internal extern static void VertexAttrib4usv(UInt32 index, UInt16[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI1i", ExactSpelling = true)]
            internal extern static void VertexAttribI1i(UInt32 index, Int32 x);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI1iv", ExactSpelling = true)]
            internal extern static void VertexAttribI1iv(UInt32 index, Int32[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI1ui", ExactSpelling = true)]
            internal extern static void VertexAttribI1ui(UInt32 index, UInt32 x);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI1uiv", ExactSpelling = true)]
            internal extern static void VertexAttribI1uiv(UInt32 index, UInt32[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI2i", ExactSpelling = true)]
            internal extern static void VertexAttribI2i(UInt32 index, Int32 x, Int32 y);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI2iv", ExactSpelling = true)]
            internal extern static void VertexAttribI2iv(UInt32 index, Int32[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI2ui", ExactSpelling = true)]
            internal extern static void VertexAttribI2ui(UInt32 index, UInt32 x, UInt32 y);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI2uiv", ExactSpelling = true)]
            internal extern static void VertexAttribI2uiv(UInt32 index, UInt32[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI3i", ExactSpelling = true)]
            internal extern static void VertexAttribI3i(UInt32 index, Int32 x, Int32 y, Int32 z);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI3iv", ExactSpelling = true)]
            internal extern static void VertexAttribI3iv(UInt32 index, Int32[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI3ui", ExactSpelling = true)]
            internal extern static void VertexAttribI3ui(UInt32 index, UInt32 x, UInt32 y, UInt32 z);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI3uiv", ExactSpelling = true)]
            internal extern static void VertexAttribI3uiv(UInt32 index, UInt32[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI4bv", ExactSpelling = true)]
            internal extern static void VertexAttribI4bv(UInt32 index, SByte[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI4i", ExactSpelling = true)]
            internal extern static void VertexAttribI4i(UInt32 index, Int32 x, Int32 y, Int32 z, Int32 w);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI4iv", ExactSpelling = true)]
            internal extern static void VertexAttribI4iv(UInt32 index, Int32[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI4sv", ExactSpelling = true)]
            internal extern static void VertexAttribI4sv(UInt32 index, Int16[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI4ubv", ExactSpelling = true)]
            internal extern static void VertexAttribI4ubv(UInt32 index, Byte[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI4ui", ExactSpelling = true)]
            internal extern static void VertexAttribI4ui(UInt32 index, UInt32 x, UInt32 y, UInt32 z, UInt32 w);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI4uiv", ExactSpelling = true)]
            internal extern static void VertexAttribI4uiv(UInt32 index, UInt32[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribI4usv", ExactSpelling = true)]
            internal extern static void VertexAttribI4usv(UInt32 index, UInt16[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribDivisor", ExactSpelling = true)]
            internal extern static void VertexAttribDivisor(UInt32 index, UInt32 divisor);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glVertexAttribPointer", ExactSpelling = true)]
            internal extern static void VertexAttribPointer(UInt32 index, Int32 size, OpenGL.VertexAttribPointerType type, bool normalized, Int32 stride, IntPtr pointer);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glViewport", ExactSpelling = true)]
            internal extern static void Viewport(Int32 x, Int32 y, Int32 width, Int32 height);
            
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glWaitSync", ExactSpelling = true)]
            internal extern static void WaitSync(IntPtr sync, UInt32 flags, UInt64 timeout);

#if OPENGL4
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glActiveShaderProgram", ExactSpelling = true)]
            internal extern static void ActiveShaderProgram(UInt32 pipeline, UInt32 program);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBeginQueryIndexed", ExactSpelling = true)]
            internal extern static void BeginQueryIndexed(UInt32 target, UInt32 index, UInt32 id);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBindFragDataLocationIndexed", ExactSpelling = true)]
            internal extern static void BindFragDataLocationIndexed(UInt32 program, UInt32 colorNumber, UInt32 index, char[] name);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glBindSampler", ExactSpelling = true)]
            internal extern static void BindSampler(UInt32 unit, UInt32 sampler);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glCreateShaderProgramv", ExactSpelling = true)]
            internal extern static Int32 CreateShaderProgram(OpenGL.ShaderType type, UInt32 count, string[] strings);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDeleteProgramPipelines", ExactSpelling = true)]
            internal extern static void DeleteProgramPipelines(Int32 n, UInt32[] ids);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDepthRangeArrayv", ExactSpelling = true)]
            internal extern static void DepthRangeArrayv(UInt32 index, Double near, Double far);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDrawArraysIndirect", ExactSpelling = true)]
            internal extern static void DrawArraysIndirect(OpenGL.BeginMode mode, IntPtr indirect);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glDrawTransformFeedbackStream", ExactSpelling = true)]
            internal extern static void DrawTransformFeedbackStream(OpenGL.NvTransformFeedback2 mode, UInt32 id, UInt32 stream);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glEndQueryIndexed", ExactSpelling = true)]
            internal extern static void EndQueryIndexed(OpenGL.QueryTarget target, UInt32 index, UInt32 id);

            /* Missing glGetActiveSubroutine* */
            /* Missed glGetSubroutine* */
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGenProgramPipelines", ExactSpelling = true)]
            internal extern static void GenProgramPipelines(Int32 n, [OutAttribute] UInt32[] pipelines);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGenSamplers", ExactSpelling = true)]
            internal extern static void GenSamplers(Int32 n, [OutAttribute] UInt32[] samplers);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetFragDataIndex", ExactSpelling = true)]
            internal extern static void GetFragDataIndex(UInt32 program, String name);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetProgramBinary", ExactSpelling = true)]
            internal extern static void GetProgramBinary(UInt32 program, Int32 size, Int32[] length, Int32[] binaryFormat, IntPtr binary);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetProgramPipelineiv", ExactSpelling = true)]
            internal extern static void GetProgramPipelineiv(UInt32 pipeline, Int32 pname, [OutAttribute] Int32[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetProgramPipelineInfoLog", ExactSpelling = true)]
            internal extern static void GetProgramPipelineInfoLog(UInt32 pipeline, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] System.Text.StringBuilder infoLog);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetProgramStageiv", ExactSpelling = true)]
            internal extern static void GetProgramStage(UInt32 program, OpenGL.ShaderType shadertype, Int32 pname, [OutAttribute] Int32[] @values);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetQueryObjecti64v", ExactSpelling = true)]
            internal extern static void GetQueryObjecti64v(UInt32 id, OpenGL.GetQueryObjectParam pname, [OutAttribute] UInt64[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetQueryObjectui64v", ExactSpelling = true)]
            internal extern static void GetQueryObjectui64v(UInt32 id, OpenGL.GetQueryObjectParam pname, [OutAttribute] UInt64[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetSamplerParameterfv", ExactSpelling = true)]
            internal extern static void GetSamplerParameterfv(UInt32 sampler, Int32 pname, [OutAttribute] Single[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetSamplerParameteriv", ExactSpelling = true)]
            internal extern static void GetSamplerParameteriv(UInt32 sampler, Int32 pname, [OutAttribute] Int32[] @params);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetShaderPrecisionFormat", ExactSpelling = true)]
            internal extern static void GetShaderPrecisionFormat(OpenGL.ShaderType shaderType, Int32 precisionType, Int32[] range, [OutAttribute] Int32[] precision);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetUniformBlockIndex", ExactSpelling = true)]
            internal extern static UInt32 GetUniformBlockIndex(UInt32 program, String uniformBlockName);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetUniformIndices", ExactSpelling = true)]
            internal extern static UInt32 GetUniformIndices(UInt32 program, Int32 uniformCount, String[] uniformNames, UInt32[] uniformIndices);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glGetUniformSubroutineuiv", ExactSpelling = true)]
            internal extern static void GetUniformSubroutineuiv(OpenGL.ShaderType shaderType, Int32 location, [OutAttribute] UInt32[] values);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glIsProgramPipeline", ExactSpelling = true)]
            internal extern static bool IsProgramPipeline(UInt32 pipeline);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glIsSampler", ExactSpelling = true)]
            internal extern static bool IsSampler(UInt32 id);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glPatchParameteri", ExactSpelling = true)]
            internal extern static void PatchParameteri(Int32 pname, Int32 value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glPatchParameterfv", ExactSpelling = true)]
            internal extern static void PatchParameterfv(Int32 pname, Single value);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glProgramBinary", ExactSpelling = true)]
            internal extern static void ProgramBinary(UInt32 program, Int32 binaryFormat, IntPtr binary, Int32 length);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glQueryCounter", ExactSpelling = true)]
            internal extern static void QueryCounter(UInt32 id, Int32 target);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glReleaseShaderCompiler", ExactSpelling = true)]
            internal extern static void ReleaseShaderCompiler();

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glSamplerParameterf", ExactSpelling = true)]
            internal extern static void SamplerParameterf(UInt32 sampler, Int32 pname, Single param);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glSamplerParameteri", ExactSpelling = true)]
            internal extern static void SamplerParameteri(UInt32 sampler, Int32 pname, Int32 param);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glScissorArrayv", ExactSpelling = true)]
            internal extern static void ScissorArrayv(UInt32 first, Int32 count, Int32[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glShaderBinary", ExactSpelling = true)]
            internal extern static void ShaderBinary(Int32 count, UInt32[] shaders, Int32 binaryFormat, IntPtr binary, Int32 length);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUniformSubroutinesuiv", ExactSpelling = true)]
            internal extern static void UniformSubroutinesuiv(ShaderType shaderType, Int32 count, UInt32[] indices);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glUseProgramStages", ExactSpelling = true)]
            internal extern static void UseProgramStages(UInt32 pipeline, Int32 bitField, UInt32 program);

            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glValidateProgram", ExactSpelling = true)]
            internal extern static void ValidateProgram(UInt32 program);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glValidateProgramPipeline", ExactSpelling = true)]
            internal extern static void ValidateProgramPipeline(UInt32 pipeline);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glViewportArray", ExactSpelling = true)]
            internal extern static void ViewportArray(UInt32 first, Int32 count, Single[] v);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glViewportIndexedf", ExactSpelling = true)]
            internal extern static void ViewportIndexedf(UInt32 index, Single x, Single y, Single w, Single h);
            [System.Runtime.InteropServices.DllImport(Gl.Library, EntryPoint = "glViewportIndexedfv", ExactSpelling = true)]
            internal extern static void ViewportIndexedfv(UInt32 index, Single[] v);
#endif
        }
    }
}
