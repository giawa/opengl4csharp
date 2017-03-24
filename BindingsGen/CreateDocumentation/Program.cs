using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace OpenGL
{
    partial class Gl
    {
        private static uint currentProgram;
        private const string Library = "opengl32.dll";
    }
}

namespace OpenGLManPages
{
    class Program
    {
        static void Main(string[] args)
        {
            var gl = typeof(OpenGL.Gl);
            Dictionary<string, GlCommand> glCommands = new Dictionary<string, GlCommand>();
            var pages = GetWebPages();

            foreach (var method in gl.GetMethods())
            {
                if (method.IsPublic)
                {
                    if (!pages.ContainsKey("gl" + method.Name))
                    {
                        Console.WriteLine("No webpage for method: " + method.Name);
                        continue;
                    }

                    string page = pages["gl" + method.Name];

                    if (!glCommands.ContainsKey(method.Name))
                        glCommands.Add(method.Name, new GlCommand(method, page));
                }
            }

            using (StreamReader glCs = new StreamReader(@"Gl.cs"))
            using (StreamWriter output = new StreamWriter("GlDocumented.cs"))
            {
                List<string> attributes = new List<string>();

                while (!glCs.EndOfStream)
                {
                    string line = glCs.ReadLine();

                    if (line.Trim().StartsWith("["))
                    {
                        attributes.Add(line);
                        continue;
                    }
                    else if (line.StartsWith("        public static"))
                    {
                        // get the method name
                        string name = line.Substring(0, line.IndexOf('('));
                        name = name.Substring(name.LastIndexOf(' ')).Trim();

                        //if (descriptions.ContainsKey(name))
                        if (glCommands.ContainsKey(name))
                        {
                            var command = glCommands[name];

                            output.WriteLine("        /// <summary>");
                            output.WriteLine("        /// " + StripHTML(command.Summary));
                            output.WriteLine("        /// <para>");
                            string text = command.Description;
                            if (text.StartsWith("Gl")) text = text.Replace("Gl", "gl");
                            WriteMultiLine(output, text);
                            output.WriteLine("        /// </para>");

                            output.WriteLine("        /// </summary>");

                            foreach (var parameter in command.Method.GetParameters())
                            {
                                if (command.MethodDescriptions.ContainsKey(parameter.Name.ToLower()))
                                {
                                    output.WriteLine("        /// <param name=\"" + parameter.Name + "\">");
                                    WriteMultiLine(output, command.MethodDescriptions[parameter.Name.ToLower()]);
                                    output.WriteLine("        /// </param>");
                                }
                            }
                        }
                        else throw new Exception("Could not find documentation!");
                    }

                    foreach (var attr in attributes) output.WriteLine(attr);
                    output.WriteLine(line);

                    attributes.Clear();
                }
            }
        }

        private static void WriteMultiLine(StreamWriter stream, string text, int maxLine = 100)
        {
            while (text.Length > maxLine)
            {
                int i = maxLine;
                for (; i > 0; i--) if (text[i] == ' ') break;
                stream.WriteLine("        /// " + text.Substring(0, i).Trim());
                text = text.Substring(i + 1).Trim();
            }
            stream.WriteLine("        /// " + text.Trim());
        }

        public class GlCommand
        {
            public string Name { get; private set; }

            public string Summary { get; private set; }

            public string Description { get; private set; }

            public MethodInfo Method { get; private set; }

            public Dictionary<string, string> MethodDescriptions { get; private set; }

            public string XHTMLPage { get; private set; }

            public GlCommand(MethodInfo method, string xhtmlPage)
            {
                Method = method;
                XHTMLPage = xhtmlPage;
                MethodDescriptions = new Dictionary<string, string>();
                Name = "gl" + method.Name;

                if (!Directory.Exists("cache")) Directory.CreateDirectory("cache");

                if (!File.Exists(string.Format("cache/{0}", xhtmlPage))) DownloadXHTMLPage();

                string htmlCode = File.ReadAllText(string.Format("cache/{0}", xhtmlPage));

                ParseXHTMLCode(htmlCode);
            }

            private bool DownloadXHTMLPage()
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        string htmlCode = client.DownloadString(string.Format("https://www.khronos.org/registry/OpenGL-Refpages/gl4/html/{0}", XHTMLPage));
                        File.WriteAllText(string.Format("cache/{0}", XHTMLPage), htmlCode);
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("No documentation.");
                        return false;
                    }
                }
            }

            private void ParseXHTMLCode(string xhtmlCode)
            {
                string summary = xhtmlCode.Substring(xhtmlCode.IndexOf("<p>") + 3);
                summary = summary.Substring(0, summary.IndexOf("</p>"));
                string names = summary.Substring(0, summary.IndexOf((char)226)).Trim();
                summary = summary.Substring(summary.IndexOf((char)8221) + 1);
                summary = summary.Replace('\n', ' ').Trim(new char[] { ' ', '\t', '.' });
                while (summary.Contains("  ")) summary = summary.Replace("  ", " ");
                this.Summary = string.Format("{0}{1}.", char.ToUpper(summary[0]), summary.Substring(1));

                string description = xhtmlCode.Substring(xhtmlCode.IndexOf("<h2>Description</h2>") + 20);
                description = description.Substring(0, description.IndexOf("</p>"));
                description = StripHTML(description);
                description = description.Replace('\n', ' ').Trim(new char[] { ' ', '\t', '.' });
                while (description.Contains("  ")) description = description.Replace("  ", " ");

                // special case for math formatting from the man pages
                if (description.Contains("clamped to the range 0 "))
                    description = description.Replace("clamped to the range 0 ", "clamped to the range [0, ").Replace("1", "1]");

                this.Description = string.Format("{0}{1}.", char.ToUpper(description[0]), description.Substring(1));

                if (xhtmlCode.IndexOf("id=\"parameters\"") > 0)
                {
                    xhtmlCode = xhtmlCode.Substring(xhtmlCode.IndexOf("id=\"parameters\""));

                    // check if multiple methods are in here - if so, move to the correct method
                    if (xhtmlCode.Contains("parameters2"))
                    {
                        xhtmlCode = xhtmlCode.Substring(xhtmlCode.IndexOf(Name));
                    }

                    xhtmlCode = xhtmlCode.Substring(0, xhtmlCode.IndexOf("div class=\"refsect1\""));

                    while (xhtmlCode.Contains("<span class=\"term\">"))
                    {
                        xhtmlCode = xhtmlCode.Substring(xhtmlCode.IndexOf("<em class=\"parameter\"") + 17);

                        List<string> parameterNames = new List<string>();

                        while (xhtmlCode.IndexOf("<code>") > 0 && xhtmlCode.IndexOf("<code>") < xhtmlCode.IndexOf("<p>"))
                        {
                            string parameterName = xhtmlCode.Substring(xhtmlCode.IndexOf("<code>") + 6);
                            parameterName = parameterName.Substring(0, parameterName.IndexOf("</code>")).Trim(new char[] { '\r', '\n', '\t', ' ' });

                            parameterNames.Add(parameterName);

                            xhtmlCode = xhtmlCode.Substring(xhtmlCode.IndexOf("</code>") + 7);
                        }

                        string parameterText = xhtmlCode.Substring(xhtmlCode.IndexOf("<p>") + 3);
                        parameterText = parameterText.Substring(0, parameterText.IndexOf("</dd>"));
                        parameterText = parameterText.Replace('\n', ' ').Trim(new char[] { '\r', '\n', '\t', ' ' });
                        parameterText = StripHTML(parameterText);
                        while (parameterText.Contains("  ")) parameterText = parameterText.Replace("  ", " ");

                        // special case for math formatting from the man pages
                        if (parameterText.Contains("clamped to the range 0 "))
                            parameterText = parameterText.Replace("clamped to the range 0 ", "clamped to the range [0, ").Replace("1 .", "1].").Replace("2 n - 1 ,", "2^n - 1],");

                        xhtmlCode = xhtmlCode.Substring(xhtmlCode.IndexOf("</dd"));

                        foreach (var parameterName in parameterNames)
                        {
                            if (MethodDescriptions.ContainsKey(parameterName) && parameterName == "buffers")
                            {
                                MethodDescriptions.Add("strides", parameterText); // fix typo in glBindVertexBuffers.xhtml
                            }
                            else
                            {
                                MethodDescriptions.Add(parameterName.ToLower(), parameterText);
                            }
                        }
                    }
                }
            }
        }

        private static string StripHTML(string data)
        {
            StringBuilder sb = new StringBuilder();

            char[] chars = data.ToCharArray();
            for (int i = 0; i < data.Length; i++)
            {
                if (chars[i] == '<')
                {
                    while (chars[i] != '>') i++;
                    continue;
                }

                sb.Append(chars[i]);
            }

            return sb.ToString();
        }

        private static void AddBackwards(Dictionary<string, string> dictionary, string value, string key)
        {
            dictionary.Add(key, value);
        }

        private static Dictionary<string, string> GetWebPages()
        {
            Dictionary<string, string> pages = new Dictionary<string, string>();
            AddBackwards(pages, "abs.xhtml", "abs");
            AddBackwards(pages, "acos.xhtml", "acos");
            AddBackwards(pages, "acosh.xhtml", "acosh");
            AddBackwards(pages, "glActiveShaderProgram.xhtml", "glActiveShaderProgram");
            AddBackwards(pages, "glActiveTexture.xhtml", "glActiveTexture");
            AddBackwards(pages, "all.xhtml", "all");
            AddBackwards(pages, "any.xhtml", "any");
            AddBackwards(pages, "asin.xhtml", "asin");
            AddBackwards(pages, "asinh.xhtml", "asinh");
            AddBackwards(pages, "atan.xhtml", "atan");
            AddBackwards(pages, "atanh.xhtml", "atanh");
            AddBackwards(pages, "atomicAdd.xhtml", "atomicAdd");
            AddBackwards(pages, "atomicAnd.xhtml", "atomicAnd");
            AddBackwards(pages, "atomicCompSwap.xhtml", "atomicCompSwap");
            AddBackwards(pages, "atomicCounter.xhtml", "atomicCounter");
            AddBackwards(pages, "atomicCounterDecrement.xhtml", "atomicCounterDecrement");
            AddBackwards(pages, "atomicCounterIncrement.xhtml", "atomicCounterIncrement");
            AddBackwards(pages, "atomicExchange.xhtml", "atomicExchange");
            AddBackwards(pages, "atomicMax.xhtml", "atomicMax");
            AddBackwards(pages, "atomicMin.xhtml", "atomicMin");
            AddBackwards(pages, "atomicOr.xhtml", "atomicOr");
            AddBackwards(pages, "atomicXor.xhtml", "atomicXor");
            AddBackwards(pages, "glAttachShader.xhtml", "glAttachShader");
            AddBackwards(pages, "barrier.xhtml", "barrier");
            AddBackwards(pages, "glBeginConditionalRender.xhtml", "glBeginConditionalRender");
            AddBackwards(pages, "glBeginQuery.xhtml", "glBeginQuery");
            AddBackwards(pages, "glBeginQueryIndexed.xhtml", "glBeginQueryIndexed");
            AddBackwards(pages, "glBeginTransformFeedback.xhtml", "glBeginTransformFeedback");
            AddBackwards(pages, "glBindAttribLocation.xhtml", "glBindAttribLocation");
            AddBackwards(pages, "glBindBuffer.xhtml", "glBindBuffer");
            AddBackwards(pages, "glBindBufferBase.xhtml", "glBindBufferBase");
            AddBackwards(pages, "glBindBufferRange.xhtml", "glBindBufferRange");
            AddBackwards(pages, "glBindBuffersBase.xhtml", "glBindBuffersBase");
            AddBackwards(pages, "glBindBuffersRange.xhtml", "glBindBuffersRange");
            AddBackwards(pages, "glBindFragDataLocation.xhtml", "glBindFragDataLocation");
            AddBackwards(pages, "glBindFragDataLocationIndexed.xhtml", "glBindFragDataLocationIndexed");
            AddBackwards(pages, "glBindFramebuffer.xhtml", "glBindFramebuffer");
            AddBackwards(pages, "glBindImageTexture.xhtml", "glBindImageTexture");
            AddBackwards(pages, "glBindImageTextures.xhtml", "glBindImageTextures");
            AddBackwards(pages, "glBindProgramPipeline.xhtml", "glBindProgramPipeline");
            AddBackwards(pages, "glBindRenderbuffer.xhtml", "glBindRenderbuffer");
            AddBackwards(pages, "glBindSampler.xhtml", "glBindSampler");
            AddBackwards(pages, "glBindSamplers.xhtml", "glBindSamplers");
            AddBackwards(pages, "glBindTexture.xhtml", "glBindTexture");
            AddBackwards(pages, "glBindTextures.xhtml", "glBindTextures");
            AddBackwards(pages, "glBindTextureUnit.xhtml", "glBindTextureUnit");
            AddBackwards(pages, "glBindTransformFeedback.xhtml", "glBindTransformFeedback");
            AddBackwards(pages, "glBindVertexArray.xhtml", "glBindVertexArray");
            AddBackwards(pages, "glBindVertexBuffer.xhtml", "glBindVertexBuffer");
            AddBackwards(pages, "glBindVertexBuffers.xhtml", "glBindVertexBuffers");
            AddBackwards(pages, "bitCount.xhtml", "bitCount");
            AddBackwards(pages, "bitfieldExtract.xhtml", "bitfieldExtract");
            AddBackwards(pages, "bitfieldInsert.xhtml", "bitfieldInsert");
            AddBackwards(pages, "bitfieldReverse.xhtml", "bitfieldReverse");
            AddBackwards(pages, "glBlendColor.xhtml", "glBlendColor");
            AddBackwards(pages, "glBlendEquation.xhtml", "glBlendEquation");
            AddBackwards(pages, "glBlendEquation.xhtml", "glBlendEquationi");
            AddBackwards(pages, "glBlendEquationSeparate.xhtml", "glBlendEquationSeparate");
            AddBackwards(pages, "glBlendEquationSeparate.xhtml", "glBlendEquationSeparatei");
            AddBackwards(pages, "glBlendFunc.xhtml", "glBlendFunc");
            AddBackwards(pages, "glBlendFunc.xhtml", "glBlendFunci");
            AddBackwards(pages, "glBlendFuncSeparate.xhtml", "glBlendFuncSeparate");
            AddBackwards(pages, "glBlendFuncSeparate.xhtml", "glBlendFuncSeparatei");
            AddBackwards(pages, "glBlitFramebuffer.xhtml", "glBlitFramebuffer");
            AddBackwards(pages, "glBlitFramebuffer.xhtml", "glBlitNamedFramebuffer");
            AddBackwards(pages, "glBufferData.xhtml", "glBufferData");
            AddBackwards(pages, "glBufferStorage.xhtml", "glBufferStorage");
            AddBackwards(pages, "glBufferSubData.xhtml", "glBufferSubData");
            AddBackwards(pages, "ceil.xhtml", "ceil");
            AddBackwards(pages, "glCheckFramebufferStatus.xhtml", "glCheckFramebufferStatus");
            AddBackwards(pages, "glCheckFramebufferStatus.xhtml", "glCheckNamedFramebufferStatus");
            AddBackwards(pages, "clamp.xhtml", "clamp");
            AddBackwards(pages, "glClampColor.xhtml", "glClampColor");
            AddBackwards(pages, "glClear.xhtml", "glClear");
            AddBackwards(pages, "glClearBuffer.xhtml", "glClearBuffer");
            AddBackwards(pages, "glClearBufferData.xhtml", "glClearBufferData");
            AddBackwards(pages, "glClearBuffer.xhtml", "glClearBufferfi");
            AddBackwards(pages, "glClearBuffer.xhtml", "glClearBufferfv");
            AddBackwards(pages, "glClearBuffer.xhtml", "glClearBufferiv");
            AddBackwards(pages, "glClearBufferSubData.xhtml", "glClearBufferSubData");
            AddBackwards(pages, "glClearBuffer.xhtml", "glClearBufferuiv");
            AddBackwards(pages, "glClearColor.xhtml", "glClearColor");
            AddBackwards(pages, "glClearDepth.xhtml", "glClearDepth");
            AddBackwards(pages, "glClearDepth.xhtml", "glClearDepthf");
            AddBackwards(pages, "glClearBufferData.xhtml", "glClearNamedBufferData");
            AddBackwards(pages, "glClearBufferSubData.xhtml", "glClearNamedBufferSubData");
            AddBackwards(pages, "glClearBuffer.xhtml", "glClearNamedFramebufferfi");
            AddBackwards(pages, "glClearBuffer.xhtml", "glClearNamedFramebufferfv");
            AddBackwards(pages, "glClearBuffer.xhtml", "glClearNamedFramebufferiv");
            AddBackwards(pages, "glClearBuffer.xhtml", "glClearNamedFramebufferuiv");
            AddBackwards(pages, "glClearStencil.xhtml", "glClearStencil");
            AddBackwards(pages, "glClearTexImage.xhtml", "glClearTexImage");
            AddBackwards(pages, "glClearTexSubImage.xhtml", "glClearTexSubImage");
            AddBackwards(pages, "glClientWaitSync.xhtml", "glClientWaitSync");
            AddBackwards(pages, "glClipControl.xhtml", "glClipControl");
            AddBackwards(pages, "glColorMask.xhtml", "glColorMask");
            AddBackwards(pages, "glColorMask.xhtml", "glColorMaski");
            AddBackwards(pages, "glCompileShader.xhtml", "glCompileShader");
            AddBackwards(pages, "glCompressedTexImage1D.xhtml", "glCompressedTexImage1D");
            AddBackwards(pages, "glCompressedTexImage2D.xhtml", "glCompressedTexImage2D");
            AddBackwards(pages, "glCompressedTexImage3D.xhtml", "glCompressedTexImage3D");
            AddBackwards(pages, "glCompressedTexSubImage1D.xhtml", "glCompressedTexSubImage1D");
            AddBackwards(pages, "glCompressedTexSubImage2D.xhtml", "glCompressedTexSubImage2D");
            AddBackwards(pages, "glCompressedTexSubImage3D.xhtml", "glCompressedTexSubImage3D");
            AddBackwards(pages, "glCompressedTexSubImage1D.xhtml", "glCompressedTextureSubImage1D");
            AddBackwards(pages, "glCompressedTexSubImage2D.xhtml", "glCompressedTextureSubImage2D");
            AddBackwards(pages, "glCompressedTexSubImage3D.xhtml", "glCompressedTextureSubImage3D");
            AddBackwards(pages, "glCopyBufferSubData.xhtml", "glCopyBufferSubData");
            AddBackwards(pages, "glCopyImageSubData.xhtml", "glCopyImageSubData");
            AddBackwards(pages, "glCopyBufferSubData.xhtml", "glCopyNamedBufferSubData");
            AddBackwards(pages, "glCopyTexImage1D.xhtml", "glCopyTexImage1D");
            AddBackwards(pages, "glCopyTexImage2D.xhtml", "glCopyTexImage2D");
            AddBackwards(pages, "glCopyTexSubImage1D.xhtml", "glCopyTexSubImage1D");
            AddBackwards(pages, "glCopyTexSubImage2D.xhtml", "glCopyTexSubImage2D");
            AddBackwards(pages, "glCopyTexSubImage3D.xhtml", "glCopyTexSubImage3D");
            AddBackwards(pages, "glCopyTexSubImage1D.xhtml", "glCopyTextureSubImage1D");
            AddBackwards(pages, "glCopyTexSubImage2D.xhtml", "glCopyTextureSubImage2D");
            AddBackwards(pages, "glCopyTexSubImage3D.xhtml", "glCopyTextureSubImage3D");
            AddBackwards(pages, "cos.xhtml", "cos");
            AddBackwards(pages, "cosh.xhtml", "cosh");
            AddBackwards(pages, "glCreateBuffers.xhtml", "glCreateBuffers");
            AddBackwards(pages, "glCreateFramebuffers.xhtml", "glCreateFramebuffers");
            AddBackwards(pages, "glCreateProgram.xhtml", "glCreateProgram");
            AddBackwards(pages, "glCreateProgramPipelines.xhtml", "glCreateProgramPipelines");
            AddBackwards(pages, "glCreateQueries.xhtml", "glCreateQueries");
            AddBackwards(pages, "glCreateRenderbuffers.xhtml", "glCreateRenderbuffers");
            AddBackwards(pages, "glCreateSamplers.xhtml", "glCreateSamplers");
            AddBackwards(pages, "glCreateShader.xhtml", "glCreateShader");
            AddBackwards(pages, "glCreateShaderProgram.xhtml", "glCreateShaderProgram");
            AddBackwards(pages, "glCreateShaderProgram.xhtml", "glCreateShaderProgramv");
            AddBackwards(pages, "glCreateTextures.xhtml", "glCreateTextures");
            AddBackwards(pages, "glCreateTransformFeedbacks.xhtml", "glCreateTransformFeedbacks");
            AddBackwards(pages, "glCreateVertexArrays.xhtml", "glCreateVertexArrays");
            AddBackwards(pages, "cross.xhtml", "cross");
            AddBackwards(pages, "glCullFace.xhtml", "glCullFace");
            AddBackwards(pages, "glDebugMessageCallback.xhtml", "glDebugMessageCallback");
            AddBackwards(pages, "glDebugMessageControl.xhtml", "glDebugMessageControl");
            AddBackwards(pages, "glDebugMessageInsert.xhtml", "glDebugMessageInsert");
            AddBackwards(pages, "degrees.xhtml", "degrees");
            AddBackwards(pages, "glDeleteBuffers.xhtml", "glDeleteBuffers");
            AddBackwards(pages, "glDeleteFramebuffers.xhtml", "glDeleteFramebuffers");
            AddBackwards(pages, "glDeleteProgram.xhtml", "glDeleteProgram");
            AddBackwards(pages, "glDeleteProgramPipelines.xhtml", "glDeleteProgramPipelines");
            AddBackwards(pages, "glDeleteQueries.xhtml", "glDeleteQueries");
            AddBackwards(pages, "glDeleteRenderbuffers.xhtml", "glDeleteRenderbuffers");
            AddBackwards(pages, "glDeleteSamplers.xhtml", "glDeleteSamplers");
            AddBackwards(pages, "glDeleteShader.xhtml", "glDeleteShader");
            AddBackwards(pages, "glDeleteSync.xhtml", "glDeleteSync");
            AddBackwards(pages, "glDeleteTextures.xhtml", "glDeleteTextures");
            AddBackwards(pages, "glDeleteTransformFeedbacks.xhtml", "glDeleteTransformFeedbacks");
            AddBackwards(pages, "glDeleteVertexArrays.xhtml", "glDeleteVertexArrays");
            AddBackwards(pages, "glDepthFunc.xhtml", "glDepthFunc");
            AddBackwards(pages, "glDepthMask.xhtml", "glDepthMask");
            AddBackwards(pages, "glDepthRange.xhtml", "glDepthRange");
            AddBackwards(pages, "glDepthRangeArray.xhtml", "glDepthRangeArray");
            AddBackwards(pages, "glDepthRangeArray.xhtml", "glDepthRangeArrayv");
            AddBackwards(pages, "glDepthRange.xhtml", "glDepthRangef");
            AddBackwards(pages, "glDepthRangeIndexed.xhtml", "glDepthRangeIndexed");
            AddBackwards(pages, "glDetachShader.xhtml", "glDetachShader");
            AddBackwards(pages, "determinant.xhtml", "determinant");
            AddBackwards(pages, "dFdx.xhtml", "dFdx");
            AddBackwards(pages, "dFdx.xhtml", "dFdxCoarse");
            AddBackwards(pages, "dFdx.xhtml", "dFdxFine");
            AddBackwards(pages, "dFdx.xhtml", "dFdy");
            AddBackwards(pages, "dFdx.xhtml", "dFdyCoarse");
            AddBackwards(pages, "dFdx.xhtml", "dFdyFine");
            AddBackwards(pages, "glEnable.xhtml", "glDisable");
            AddBackwards(pages, "glEnable.xhtml", "glDisablei");
            AddBackwards(pages, "glEnableVertexAttribArray.xhtml", "glDisableVertexArrayAttrib");
            AddBackwards(pages, "glEnableVertexAttribArray.xhtml", "glDisableVertexAttribArray");
            AddBackwards(pages, "glDispatchCompute.xhtml", "glDispatchCompute");
            AddBackwards(pages, "glDispatchComputeIndirect.xhtml", "glDispatchComputeIndirect");
            AddBackwards(pages, "distance.xhtml", "distance");
            AddBackwards(pages, "dot.xhtml", "dot");
            AddBackwards(pages, "glDrawArrays.xhtml", "glDrawArrays");
            AddBackwards(pages, "glDrawArraysIndirect.xhtml", "glDrawArraysIndirect");
            AddBackwards(pages, "glDrawArraysInstanced.xhtml", "glDrawArraysInstanced");
            AddBackwards(pages, "glDrawArraysInstancedBaseInstance.xhtml", "glDrawArraysInstancedBaseInstance");
            AddBackwards(pages, "glDrawBuffer.xhtml", "glDrawBuffer");
            AddBackwards(pages, "glDrawBuffers.xhtml", "glDrawBuffers");
            AddBackwards(pages, "glDrawElements.xhtml", "glDrawElements");
            AddBackwards(pages, "glDrawElementsBaseVertex.xhtml", "glDrawElementsBaseVertex");
            AddBackwards(pages, "glDrawElementsIndirect.xhtml", "glDrawElementsIndirect");
            AddBackwards(pages, "glDrawElementsInstanced.xhtml", "glDrawElementsInstanced");
            AddBackwards(pages, "glDrawElementsInstancedBaseInstance.xhtml", "glDrawElementsInstancedBaseInstance");
            AddBackwards(pages, "glDrawElementsInstancedBaseVertex.xhtml", "glDrawElementsInstancedBaseVertex");
            AddBackwards(pages, "glDrawElementsInstancedBaseVertexBaseInstance.xhtml", "glDrawElementsInstancedBaseVertexBaseInstance");
            AddBackwards(pages, "glDrawRangeElements.xhtml", "glDrawRangeElements");
            AddBackwards(pages, "glDrawRangeElementsBaseVertex.xhtml", "glDrawRangeElementsBaseVertex");
            AddBackwards(pages, "glDrawTransformFeedback.xhtml", "glDrawTransformFeedback");
            AddBackwards(pages, "glDrawTransformFeedbackInstanced.xhtml", "glDrawTransformFeedbackInstanced");
            AddBackwards(pages, "glDrawTransformFeedbackStream.xhtml", "glDrawTransformFeedbackStream");
            AddBackwards(pages, "glDrawTransformFeedbackStreamInstanced.xhtml", "glDrawTransformFeedbackStreamInstanced");
            AddBackwards(pages, "EmitStreamVertex.xhtml", "EmitStreamVertex");
            AddBackwards(pages, "EmitVertex.xhtml", "EmitVertex");
            AddBackwards(pages, "glEnable.xhtml", "glEnable");
            AddBackwards(pages, "glEnable.xhtml", "glEnablei");
            AddBackwards(pages, "glEnableVertexAttribArray.xhtml", "glEnableVertexArrayAttrib");
            AddBackwards(pages, "glEnableVertexAttribArray.xhtml", "glEnableVertexAttribArray");
            AddBackwards(pages, "glBeginConditionalRender.xhtml", "glEndConditionalRender");
            AddBackwards(pages, "EndPrimitive.xhtml", "EndPrimitive");
            AddBackwards(pages, "glBeginQuery.xhtml", "glEndQuery");
            AddBackwards(pages, "glBeginQueryIndexed.xhtml", "glEndQueryIndexed");
            AddBackwards(pages, "EndStreamPrimitive.xhtml", "EndStreamPrimitive");
            AddBackwards(pages, "glBeginTransformFeedback.xhtml", "glEndTransformFeedback");
            AddBackwards(pages, "equal.xhtml", "equal");
            AddBackwards(pages, "exp.xhtml", "exp");
            AddBackwards(pages, "exp2.xhtml", "exp2");
            AddBackwards(pages, "faceforward.xhtml", "faceforward");
            AddBackwards(pages, "glFenceSync.xhtml", "glFenceSync");
            AddBackwards(pages, "findLSB.xhtml", "findLSB");
            AddBackwards(pages, "findMSB.xhtml", "findMSB");
            AddBackwards(pages, "glFinish.xhtml", "glFinish");
            AddBackwards(pages, "floatBitsToInt.xhtml", "floatBitsToInt");
            AddBackwards(pages, "floatBitsToInt.xhtml", "floatBitsToUint");
            AddBackwards(pages, "floor.xhtml", "floor");
            AddBackwards(pages, "glFlush.xhtml", "glFlush");
            AddBackwards(pages, "glFlushMappedBufferRange.xhtml", "glFlushMappedBufferRange");
            AddBackwards(pages, "glFlushMappedBufferRange.xhtml", "glFlushMappedNamedBufferRange");
            AddBackwards(pages, "fma.xhtml", "fma");
            AddBackwards(pages, "fract.xhtml", "fract");
            AddBackwards(pages, "glFramebufferParameteri.xhtml", "glFramebufferParameteri");
            AddBackwards(pages, "glFramebufferRenderbuffer.xhtml", "glFramebufferRenderbuffer");
            AddBackwards(pages, "glFramebufferTexture.xhtml", "glFramebufferTexture");
            AddBackwards(pages, "glFramebufferTexture.xhtml", "glFramebufferTexture1D");
            AddBackwards(pages, "glFramebufferTexture.xhtml", "glFramebufferTexture2D");
            AddBackwards(pages, "glFramebufferTexture.xhtml", "glFramebufferTexture3D");
            AddBackwards(pages, "glFramebufferTextureLayer.xhtml", "glFramebufferTextureLayer");
            AddBackwards(pages, "frexp.xhtml", "frexp");
            AddBackwards(pages, "glFrontFace.xhtml", "glFrontFace");
            AddBackwards(pages, "fwidth.xhtml", "fwidth");
            AddBackwards(pages, "fwidth.xhtml", "fwidthCoarse");
            AddBackwards(pages, "fwidth.xhtml", "fwidthFine");
            AddBackwards(pages, "glGenBuffers.xhtml", "glGenBuffers");
            AddBackwards(pages, "glGenerateMipmap.xhtml", "glGenerateMipmap");
            AddBackwards(pages, "glGenerateMipmap.xhtml", "glGenerateTextureMipmap");
            AddBackwards(pages, "glGenFramebuffers.xhtml", "glGenFramebuffers");
            AddBackwards(pages, "glGenProgramPipelines.xhtml", "glGenProgramPipelines");
            AddBackwards(pages, "glGenQueries.xhtml", "glGenQueries");
            AddBackwards(pages, "glGenRenderbuffers.xhtml", "glGenRenderbuffers");
            AddBackwards(pages, "glGenSamplers.xhtml", "glGenSamplers");
            AddBackwards(pages, "glGenTextures.xhtml", "glGenTextures");
            AddBackwards(pages, "glGenTransformFeedbacks.xhtml", "glGenTransformFeedbacks");
            AddBackwards(pages, "glGenVertexArrays.xhtml", "glGenVertexArrays");
            AddBackwards(pages, "glGet.xhtml", "glGet");
            AddBackwards(pages, "glGetActiveAtomicCounterBufferiv.xhtml", "glGetActiveAtomicCounterBufferiv");
            AddBackwards(pages, "glGetActiveAttrib.xhtml", "glGetActiveAttrib");
            AddBackwards(pages, "glGetActiveSubroutineName.xhtml", "glGetActiveSubroutineName");
            AddBackwards(pages, "glGetActiveSubroutineUniform.xhtml", "glGetActiveSubroutineUniform");
            AddBackwards(pages, "glGetActiveSubroutineUniform.xhtml", "glGetActiveSubroutineUniformiv");
            AddBackwards(pages, "glGetActiveSubroutineUniformName.xhtml", "glGetActiveSubroutineUniformName");
            AddBackwards(pages, "glGetActiveUniform.xhtml", "glGetActiveUniform");
            AddBackwards(pages, "glGetActiveUniformBlock.xhtml", "glGetActiveUniformBlock");
            AddBackwards(pages, "glGetActiveUniformBlock.xhtml", "glGetActiveUniformBlockiv");
            AddBackwards(pages, "glGetActiveUniformBlockName.xhtml", "glGetActiveUniformBlockName");
            AddBackwards(pages, "glGetActiveUniformName.xhtml", "glGetActiveUniformName");
            AddBackwards(pages, "glGetActiveUniformsiv.xhtml", "glGetActiveUniformsiv");
            AddBackwards(pages, "glGetAttachedShaders.xhtml", "glGetAttachedShaders");
            AddBackwards(pages, "glGetAttribLocation.xhtml", "glGetAttribLocation");
            AddBackwards(pages, "glGet.xhtml", "glGetBooleani_v");
            AddBackwards(pages, "glGet.xhtml", "glGetBooleanv");
            AddBackwards(pages, "glGetBufferParameter.xhtml", "glGetBufferParameter");
            AddBackwards(pages, "glGetBufferParameter.xhtml", "glGetBufferParameteri64v");
            AddBackwards(pages, "glGetBufferParameter.xhtml", "glGetBufferParameteriv");
            AddBackwards(pages, "glGetBufferPointerv.xhtml", "glGetBufferPointerv");
            AddBackwards(pages, "glGetBufferSubData.xhtml", "glGetBufferSubData");
            AddBackwards(pages, "glGetCompressedTexImage.xhtml", "glGetCompressedTexImage");
            AddBackwards(pages, "glGetCompressedTexImage.xhtml", "glGetCompressedTextureImage");
            AddBackwards(pages, "glGetCompressedTextureSubImage.xhtml", "glGetCompressedTextureSubImage");
            AddBackwards(pages, "glGetDebugMessageLog.xhtml", "glGetDebugMessageLog");
            AddBackwards(pages, "glGet.xhtml", "glGetDoublei_v");
            AddBackwards(pages, "glGet.xhtml", "glGetDoublev");
            AddBackwards(pages, "glGetError.xhtml", "glGetError");
            AddBackwards(pages, "glGet.xhtml", "glGetFloati_v");
            AddBackwards(pages, "glGet.xhtml", "glGetFloatv");
            AddBackwards(pages, "glGetFragDataIndex.xhtml", "glGetFragDataIndex");
            AddBackwards(pages, "glGetFragDataLocation.xhtml", "glGetFragDataLocation");
            AddBackwards(pages, "glGetFramebufferAttachmentParameter.xhtml", "glGetFramebufferAttachmentParameter");
            AddBackwards(pages, "glGetFramebufferAttachmentParameter.xhtml", "glGetFramebufferAttachmentParameteriv");
            AddBackwards(pages, "glGetFramebufferParameter.xhtml", "glGetFramebufferParameter");
            AddBackwards(pages, "glGetFramebufferParameter.xhtml", "glGetFramebufferParameteriv");
            AddBackwards(pages, "glGetGraphicsResetStatus.xhtml", "glGetGraphicsResetStatus");
            AddBackwards(pages, "glGet.xhtml", "glGetInteger64i_v");
            AddBackwards(pages, "glGet.xhtml", "glGetInteger64v");
            AddBackwards(pages, "glGet.xhtml", "glGetIntegeri_v");
            AddBackwards(pages, "glGet.xhtml", "glGetIntegerv");
            AddBackwards(pages, "glGetInternalformat.xhtml", "glGetInternalformat");
            AddBackwards(pages, "glGetInternalformat.xhtml", "glGetInternalformati64v");
            AddBackwards(pages, "glGetInternalformat.xhtml", "glGetInternalformativ");
            AddBackwards(pages, "glGetMultisample.xhtml", "glGetMultisample");
            AddBackwards(pages, "glGetMultisample.xhtml", "glGetMultisamplefv");
            AddBackwards(pages, "glGetBufferParameter.xhtml", "glGetNamedBufferParameteri64v");
            AddBackwards(pages, "glGetBufferParameter.xhtml", "glGetNamedBufferParameteriv");
            AddBackwards(pages, "glGetBufferPointerv.xhtml", "glGetNamedBufferPointerv");
            AddBackwards(pages, "glGetBufferSubData.xhtml", "glGetNamedBufferSubData");
            AddBackwards(pages, "glGetFramebufferAttachmentParameter.xhtml", "glGetNamedFramebufferAttachmentParameteriv");
            AddBackwards(pages, "glGetFramebufferParameter.xhtml", "glGetNamedFramebufferParameteriv");
            AddBackwards(pages, "glGetRenderbufferParameter.xhtml", "glGetNamedRenderbufferParameteriv");
            AddBackwards(pages, "glGetCompressedTexImage.xhtml", "glGetnCompressedTexImage");
            AddBackwards(pages, "glGetTexImage.xhtml", "glGetnTexImage");
            AddBackwards(pages, "glGetUniform.xhtml", "glGetnUniformdv");
            AddBackwards(pages, "glGetUniform.xhtml", "glGetnUniformfv");
            AddBackwards(pages, "glGetUniform.xhtml", "glGetnUniformiv");
            AddBackwards(pages, "glGetUniform.xhtml", "glGetnUniformuiv");
            AddBackwards(pages, "glGetObjectLabel.xhtml", "glGetObjectLabel");
            AddBackwards(pages, "glGetObjectPtrLabel.xhtml", "glGetObjectPtrLabel");
            AddBackwards(pages, "glGetPointerv.xhtml", "glGetPointerv");
            AddBackwards(pages, "glGetProgram.xhtml", "glGetProgram");
            AddBackwards(pages, "glGetProgramBinary.xhtml", "glGetProgramBinary");
            AddBackwards(pages, "glGetProgramInfoLog.xhtml", "glGetProgramInfoLog");
            AddBackwards(pages, "glGetProgramInterface.xhtml", "glGetProgramInterface");
            AddBackwards(pages, "glGetProgramInterface.xhtml", "glGetProgramInterfaceiv");
            AddBackwards(pages, "glGetProgram.xhtml", "glGetProgramiv");
            AddBackwards(pages, "glGetProgramPipeline.xhtml", "glGetProgramPipeline");
            AddBackwards(pages, "glGetProgramPipelineInfoLog.xhtml", "glGetProgramPipelineInfoLog");
            AddBackwards(pages, "glGetProgramPipeline.xhtml", "glGetProgramPipelineiv");
            AddBackwards(pages, "glGetProgramResource.xhtml", "glGetProgramResource");
            AddBackwards(pages, "glGetProgramResourceIndex.xhtml", "glGetProgramResourceIndex");
            AddBackwards(pages, "glGetProgramResource.xhtml", "glGetProgramResourceiv");
            AddBackwards(pages, "glGetProgramResourceLocation.xhtml", "glGetProgramResourceLocation");
            AddBackwards(pages, "glGetProgramResourceLocationIndex.xhtml", "glGetProgramResourceLocationIndex");
            AddBackwards(pages, "glGetProgramResourceName.xhtml", "glGetProgramResourceName");
            AddBackwards(pages, "glGetProgramStage.xhtml", "glGetProgramStage");
            AddBackwards(pages, "glGetProgramStage.xhtml", "glGetProgramStageiv");
            AddBackwards(pages, "glGetQueryIndexed.xhtml", "glGetQueryIndexed");
            AddBackwards(pages, "glGetQueryIndexed.xhtml", "glGetQueryIndexediv");
            AddBackwards(pages, "glGetQueryiv.xhtml", "glGetQueryiv");
            AddBackwards(pages, "glGetQueryObject.xhtml", "glGetQueryObject");
            AddBackwards(pages, "glGetQueryObject.xhtml", "glGetQueryObjecti64v");
            AddBackwards(pages, "glGetQueryObject.xhtml", "glGetQueryObjectiv");
            AddBackwards(pages, "glGetQueryObject.xhtml", "glGetQueryObjectui64v");
            AddBackwards(pages, "glGetQueryObject.xhtml", "glGetQueryObjectuiv");
            AddBackwards(pages, "glGetRenderbufferParameter.xhtml", "glGetRenderbufferParameter");
            AddBackwards(pages, "glGetRenderbufferParameter.xhtml", "glGetRenderbufferParameteriv");
            AddBackwards(pages, "glGetSamplerParameter.xhtml", "glGetSamplerParameter");
            AddBackwards(pages, "glGetSamplerParameter.xhtml", "glGetSamplerParameterfv");
            AddBackwards(pages, "glGetSamplerParameter.xhtml", "glGetSamplerParameterIiv");
            AddBackwards(pages, "glGetSamplerParameter.xhtml", "glGetSamplerParameterIuiv");
            AddBackwards(pages, "glGetSamplerParameter.xhtml", "glGetSamplerParameteriv");
            AddBackwards(pages, "glGetShader.xhtml", "glGetShader");
            AddBackwards(pages, "glGetShaderInfoLog.xhtml", "glGetShaderInfoLog");
            AddBackwards(pages, "glGetShader.xhtml", "glGetShaderiv");
            AddBackwards(pages, "glGetShaderPrecisionFormat.xhtml", "glGetShaderPrecisionFormat");
            AddBackwards(pages, "glGetShaderSource.xhtml", "glGetShaderSource");
            AddBackwards(pages, "glGetString.xhtml", "glGetString");
            AddBackwards(pages, "glGetString.xhtml", "glGetStringi");
            AddBackwards(pages, "glGetSubroutineIndex.xhtml", "glGetSubroutineIndex");
            AddBackwards(pages, "glGetSubroutineUniformLocation.xhtml", "glGetSubroutineUniformLocation");
            AddBackwards(pages, "glGetSync.xhtml", "glGetSync");
            AddBackwards(pages, "glGetSync.xhtml", "glGetSynciv");
            AddBackwards(pages, "glGetTexImage.xhtml", "glGetTexImage");
            AddBackwards(pages, "glGetTexLevelParameter.xhtml", "glGetTexLevelParameter");
            AddBackwards(pages, "glGetTexLevelParameter.xhtml", "glGetTexLevelParameterfv");
            AddBackwards(pages, "glGetTexLevelParameter.xhtml", "glGetTexLevelParameteriv");
            AddBackwards(pages, "glGetTexParameter.xhtml", "glGetTexParameter");
            AddBackwards(pages, "glGetTexParameter.xhtml", "glGetTexParameterfv");
            AddBackwards(pages, "glGetTexParameter.xhtml", "glGetTexParameterIiv");
            AddBackwards(pages, "glGetTexParameter.xhtml", "glGetTexParameterIuiv");
            AddBackwards(pages, "glGetTexParameter.xhtml", "glGetTexParameteriv");
            AddBackwards(pages, "glGetTexImage.xhtml", "glGetTextureImage");
            AddBackwards(pages, "glGetTexLevelParameter.xhtml", "glGetTextureLevelParameterfv");
            AddBackwards(pages, "glGetTexLevelParameter.xhtml", "glGetTextureLevelParameteriv");
            AddBackwards(pages, "glGetTexParameter.xhtml", "glGetTextureParameterfv");
            AddBackwards(pages, "glGetTexParameter.xhtml", "glGetTextureParameterIiv");
            AddBackwards(pages, "glGetTexParameter.xhtml", "glGetTextureParameterIuiv");
            AddBackwards(pages, "glGetTexParameter.xhtml", "glGetTextureParameteriv");
            AddBackwards(pages, "glGetTextureSubImage.xhtml", "glGetTextureSubImage");
            AddBackwards(pages, "glGetTransformFeedback.xhtml", "glGetTransformFeedback");
            AddBackwards(pages, "glGetTransformFeedback.xhtml", "glGetTransformFeedbacki64_v");
            AddBackwards(pages, "glGetTransformFeedback.xhtml", "glGetTransformFeedbacki_v");
            AddBackwards(pages, "glGetTransformFeedback.xhtml", "glGetTransformFeedbackiv");
            AddBackwards(pages, "glGetTransformFeedbackVarying.xhtml", "glGetTransformFeedbackVarying");
            AddBackwards(pages, "glGetUniform.xhtml", "glGetUniform");
            AddBackwards(pages, "glGetUniformBlockIndex.xhtml", "glGetUniformBlockIndex");
            AddBackwards(pages, "glGetUniform.xhtml", "glGetUniformdv");
            AddBackwards(pages, "glGetUniform.xhtml", "glGetUniformfv");
            AddBackwards(pages, "glGetUniformIndices.xhtml", "glGetUniformIndices");
            AddBackwards(pages, "glGetUniform.xhtml", "glGetUniformiv");
            AddBackwards(pages, "glGetUniformLocation.xhtml", "glGetUniformLocation");
            AddBackwards(pages, "glGetUniformSubroutine.xhtml", "glGetUniformSubroutine");
            AddBackwards(pages, "glGetUniformSubroutine.xhtml", "glGetUniformSubroutineuiv");
            AddBackwards(pages, "glGetUniform.xhtml", "glGetUniformuiv");
            AddBackwards(pages, "glGetVertexArrayIndexed.xhtml", "glGetVertexArrayIndexed");
            AddBackwards(pages, "glGetVertexArrayIndexed.xhtml", "glGetVertexArrayIndexed64iv");
            AddBackwards(pages, "glGetVertexArrayIndexed.xhtml", "glGetVertexArrayIndexediv");
            AddBackwards(pages, "glGetVertexArrayiv.xhtml", "glGetVertexArrayiv");
            AddBackwards(pages, "glGetVertexAttrib.xhtml", "glGetVertexAttrib");
            AddBackwards(pages, "glGetVertexAttrib.xhtml", "glGetVertexAttribdv");
            AddBackwards(pages, "glGetVertexAttrib.xhtml", "glGetVertexAttribfv");
            AddBackwards(pages, "glGetVertexAttrib.xhtml", "glGetVertexAttribIiv");
            AddBackwards(pages, "glGetVertexAttrib.xhtml", "glGetVertexAttribIuiv");
            AddBackwards(pages, "glGetVertexAttrib.xhtml", "glGetVertexAttribiv");
            AddBackwards(pages, "glGetVertexAttrib.xhtml", "glGetVertexAttribLdv");
            AddBackwards(pages, "glGetVertexAttribPointerv.xhtml", "glGetVertexAttribPointerv");
            AddBackwards(pages, "gl_ClipDistance.xhtml", "gl_ClipDistance");
            AddBackwards(pages, "gl_CullDistance.xhtml", "gl_CullDistance");
            AddBackwards(pages, "gl_FragCoord.xhtml", "gl_FragCoord");
            AddBackwards(pages, "gl_FragDepth.xhtml", "gl_FragDepth");
            AddBackwards(pages, "gl_FrontFacing.xhtml", "gl_FrontFacing");
            AddBackwards(pages, "gl_GlobalInvocationID.xhtml", "gl_GlobalInvocationID");
            AddBackwards(pages, "gl_HelperInvocation.xhtml", "gl_HelperInvocation");
            AddBackwards(pages, "gl_InstanceID.xhtml", "gl_InstanceID");
            AddBackwards(pages, "gl_InvocationID.xhtml", "gl_InvocationID");
            AddBackwards(pages, "gl_Layer.xhtml", "gl_Layer");
            AddBackwards(pages, "gl_LocalInvocationID.xhtml", "gl_LocalInvocationID");
            AddBackwards(pages, "gl_LocalInvocationIndex.xhtml", "gl_LocalInvocationIndex");
            AddBackwards(pages, "gl_NumSamples.xhtml", "gl_NumSamples");
            AddBackwards(pages, "gl_NumWorkGroups.xhtml", "gl_NumWorkGroups");
            AddBackwards(pages, "gl_PatchVerticesIn.xhtml", "gl_PatchVerticesIn");
            AddBackwards(pages, "gl_PointCoord.xhtml", "gl_PointCoord");
            AddBackwards(pages, "gl_PointSize.xhtml", "gl_PointSize");
            AddBackwards(pages, "gl_Position.xhtml", "gl_Position");
            AddBackwards(pages, "gl_PrimitiveID.xhtml", "gl_PrimitiveID");
            AddBackwards(pages, "gl_PrimitiveIDIn.xhtml", "gl_PrimitiveIDIn");
            AddBackwards(pages, "gl_SampleID.xhtml", "gl_SampleID");
            AddBackwards(pages, "gl_SampleMask.xhtml", "gl_SampleMask");
            AddBackwards(pages, "gl_SampleMaskIn.xhtml", "gl_SampleMaskIn");
            AddBackwards(pages, "gl_SamplePosition.xhtml", "gl_SamplePosition");
            AddBackwards(pages, "gl_TessCoord.xhtml", "gl_TessCoord");
            AddBackwards(pages, "gl_TessLevelInner.xhtml", "gl_TessLevelInner");
            AddBackwards(pages, "gl_TessLevelOuter.xhtml", "gl_TessLevelOuter");
            AddBackwards(pages, "gl_VertexID.xhtml", "gl_VertexID");
            AddBackwards(pages, "gl_ViewportIndex.xhtml", "gl_ViewportIndex");
            AddBackwards(pages, "gl_WorkGroupID.xhtml", "gl_WorkGroupID");
            AddBackwards(pages, "gl_WorkGroupSize.xhtml", "gl_WorkGroupSize");
            AddBackwards(pages, "greaterThan.xhtml", "greaterThan");
            AddBackwards(pages, "greaterThanEqual.xhtml", "greaterThanEqual");
            AddBackwards(pages, "groupMemoryBarrier.xhtml", "groupMemoryBarrier");
            AddBackwards(pages, "glHint.xhtml", "glHint");
            AddBackwards(pages, "imageAtomicAdd.xhtml", "imageAtomicAdd");
            AddBackwards(pages, "imageAtomicAnd.xhtml", "imageAtomicAnd");
            AddBackwards(pages, "imageAtomicCompSwap.xhtml", "imageAtomicCompSwap");
            AddBackwards(pages, "imageAtomicExchange.xhtml", "imageAtomicExchange");
            AddBackwards(pages, "imageAtomicMax.xhtml", "imageAtomicMax");
            AddBackwards(pages, "imageAtomicMin.xhtml", "imageAtomicMin");
            AddBackwards(pages, "imageAtomicOr.xhtml", "imageAtomicOr");
            AddBackwards(pages, "imageAtomicXor.xhtml", "imageAtomicXor");
            AddBackwards(pages, "imageLoad.xhtml", "imageLoad");
            AddBackwards(pages, "imageSamples.xhtml", "imageSamples");
            AddBackwards(pages, "imageSize.xhtml", "imageSize");
            AddBackwards(pages, "imageStore.xhtml", "imageStore");
            AddBackwards(pages, "umulExtended.xhtml", "imulExtended");
            AddBackwards(pages, "intBitsToFloat.xhtml", "intBitsToFloat");
            AddBackwards(pages, "interpolateAtCentroid.xhtml", "interpolateAtCentroid");
            AddBackwards(pages, "interpolateAtOffset.xhtml", "interpolateAtOffset");
            AddBackwards(pages, "interpolateAtSample.xhtml", "interpolateAtSample");
            AddBackwards(pages, "glInvalidateBufferData.xhtml", "glInvalidateBufferData");
            AddBackwards(pages, "glInvalidateBufferSubData.xhtml", "glInvalidateBufferSubData");
            AddBackwards(pages, "glInvalidateFramebuffer.xhtml", "glInvalidateFramebuffer");
            AddBackwards(pages, "glInvalidateFramebuffer.xhtml", "glInvalidateNamedFramebufferData");
            AddBackwards(pages, "glInvalidateSubFramebuffer.xhtml", "glInvalidateNamedFramebufferSubData");
            AddBackwards(pages, "glInvalidateSubFramebuffer.xhtml", "glInvalidateSubFramebuffer");
            AddBackwards(pages, "glInvalidateTexImage.xhtml", "glInvalidateTexImage");
            AddBackwards(pages, "glInvalidateTexSubImage.xhtml", "glInvalidateTexSubImage");
            AddBackwards(pages, "inverse.xhtml", "inverse");
            AddBackwards(pages, "inversesqrt.xhtml", "inversesqrt");
            AddBackwards(pages, "glIsBuffer.xhtml", "glIsBuffer");
            AddBackwards(pages, "glIsEnabled.xhtml", "glIsEnabled");
            AddBackwards(pages, "glIsEnabled.xhtml", "glIsEnabledi");
            AddBackwards(pages, "glIsFramebuffer.xhtml", "glIsFramebuffer");
            AddBackwards(pages, "isinf.xhtml", "isinf");
            AddBackwards(pages, "isnan.xhtml", "isnan");
            AddBackwards(pages, "glIsProgram.xhtml", "glIsProgram");
            AddBackwards(pages, "glIsProgramPipeline.xhtml", "glIsProgramPipeline");
            AddBackwards(pages, "glIsQuery.xhtml", "glIsQuery");
            AddBackwards(pages, "glIsRenderbuffer.xhtml", "glIsRenderbuffer");
            AddBackwards(pages, "glIsSampler.xhtml", "glIsSampler");
            AddBackwards(pages, "glIsShader.xhtml", "glIsShader");
            AddBackwards(pages, "glIsSync.xhtml", "glIsSync");
            AddBackwards(pages, "glIsTexture.xhtml", "glIsTexture");
            AddBackwards(pages, "glIsTransformFeedback.xhtml", "glIsTransformFeedback");
            AddBackwards(pages, "glIsVertexArray.xhtml", "glIsVertexArray");
            AddBackwards(pages, "ldexp.xhtml", "ldexp");
            AddBackwards(pages, "length.xhtml", "length");
            AddBackwards(pages, "lessThan.xhtml", "lessThan");
            AddBackwards(pages, "lessThanEqual.xhtml", "lessThanEqual");
            AddBackwards(pages, "glLineWidth.xhtml", "glLineWidth");
            AddBackwards(pages, "glLinkProgram.xhtml", "glLinkProgram");
            AddBackwards(pages, "log.xhtml", "log");
            AddBackwards(pages, "log2.xhtml", "log2");
            AddBackwards(pages, "glLogicOp.xhtml", "glLogicOp");
            AddBackwards(pages, "glMapBuffer.xhtml", "glMapBuffer");
            AddBackwards(pages, "glMapBufferRange.xhtml", "glMapBufferRange");
            AddBackwards(pages, "glMapBuffer.xhtml", "glMapNamedBuffer");
            AddBackwards(pages, "glMapBufferRange.xhtml", "glMapNamedBufferRange");
            AddBackwards(pages, "matrixCompMult.xhtml", "matrixCompMult");
            AddBackwards(pages, "max.xhtml", "max");
            AddBackwards(pages, "glMemoryBarrier.xhtml", "glMemoryBarrier");
            AddBackwards(pages, "memoryBarrier.xhtml", "memoryBarrier");
            AddBackwards(pages, "memoryBarrierAtomicCounter.xhtml", "memoryBarrierAtomicCounter");
            AddBackwards(pages, "memoryBarrierBuffer.xhtml", "memoryBarrierBuffer");
            AddBackwards(pages, "glMemoryBarrier.xhtml", "glMemoryBarrierByRegion");
            AddBackwards(pages, "memoryBarrierImage.xhtml", "memoryBarrierImage");
            AddBackwards(pages, "memoryBarrierShared.xhtml", "memoryBarrierShared");
            AddBackwards(pages, "min.xhtml", "min");
            AddBackwards(pages, "glMinSampleShading.xhtml", "glMinSampleShading");
            AddBackwards(pages, "mix.xhtml", "mix");
            AddBackwards(pages, "mod.xhtml", "mod");
            AddBackwards(pages, "modf.xhtml", "modf");
            AddBackwards(pages, "glMultiDrawArrays.xhtml", "glMultiDrawArrays");
            AddBackwards(pages, "glMultiDrawArraysIndirect.xhtml", "glMultiDrawArraysIndirect");
            AddBackwards(pages, "glMultiDrawElements.xhtml", "glMultiDrawElements");
            AddBackwards(pages, "glMultiDrawElementsBaseVertex.xhtml", "glMultiDrawElementsBaseVertex");
            AddBackwards(pages, "glMultiDrawElementsIndirect.xhtml", "glMultiDrawElementsIndirect");
            AddBackwards(pages, "glBufferData.xhtml", "glNamedBufferData");
            AddBackwards(pages, "glBufferStorage.xhtml", "glNamedBufferStorage");
            AddBackwards(pages, "glBufferSubData.xhtml", "glNamedBufferSubData");
            AddBackwards(pages, "glDrawBuffer.xhtml", "glNamedFramebufferDrawBuffer");
            AddBackwards(pages, "glDrawBuffers.xhtml", "glNamedFramebufferDrawBuffers");
            AddBackwards(pages, "glFramebufferParameteri.xhtml", "glNamedFramebufferParameteri");
            AddBackwards(pages, "glReadBuffer.xhtml", "glNamedFramebufferReadBuffer");
            AddBackwards(pages, "glFramebufferRenderbuffer.xhtml", "glNamedFramebufferRenderbuffer");
            AddBackwards(pages, "glFramebufferTexture.xhtml", "glNamedFramebufferTexture");
            AddBackwards(pages, "glFramebufferTextureLayer.xhtml", "glNamedFramebufferTextureLayer");
            AddBackwards(pages, "glRenderbufferStorage.xhtml", "glNamedRenderbufferStorage");
            AddBackwards(pages, "glRenderbufferStorageMultisample.xhtml", "glNamedRenderbufferStorageMultisample");
            AddBackwards(pages, "noise.xhtml", "noise");
            AddBackwards(pages, "noise.xhtml", "noise1");
            AddBackwards(pages, "noise.xhtml", "noise2");
            AddBackwards(pages, "noise.xhtml", "noise3");
            AddBackwards(pages, "noise.xhtml", "noise4");
            AddBackwards(pages, "normalize.xhtml", "normalize");
            AddBackwards(pages, "not.xhtml", "not");
            AddBackwards(pages, "notEqual.xhtml", "notEqual");
            AddBackwards(pages, "glObjectLabel.xhtml", "glObjectLabel");
            AddBackwards(pages, "glObjectPtrLabel.xhtml", "glObjectPtrLabel");
            AddBackwards(pages, "outerProduct.xhtml", "outerProduct");
            AddBackwards(pages, "packDouble2x32.xhtml", "packDouble2x32");
            AddBackwards(pages, "packHalf2x16.xhtml", "packHalf2x16");
            AddBackwards(pages, "packUnorm.xhtml", "packSnorm2x16");
            AddBackwards(pages, "packUnorm.xhtml", "packSnorm4x8");
            AddBackwards(pages, "packUnorm.xhtml", "packUnorm");
            AddBackwards(pages, "packUnorm.xhtml", "packUnorm2x16");
            AddBackwards(pages, "packUnorm.xhtml", "packUnorm4x8");
            AddBackwards(pages, "glPatchParameter.xhtml", "glPatchParameter");
            AddBackwards(pages, "glPatchParameter.xhtml", "glPatchParameterfv");
            AddBackwards(pages, "glPatchParameter.xhtml", "glPatchParameteri");
            AddBackwards(pages, "glPauseTransformFeedback.xhtml", "glPauseTransformFeedback");
            AddBackwards(pages, "glPixelStore.xhtml", "glPixelStore");
            AddBackwards(pages, "glPixelStore.xhtml", "glPixelStoref");
            AddBackwards(pages, "glPixelStore.xhtml", "glPixelStorei");
            AddBackwards(pages, "glPointParameter.xhtml", "glPointParameter");
            AddBackwards(pages, "glPointParameter.xhtml", "glPointParameterf");
            AddBackwards(pages, "glPointParameter.xhtml", "glPointParameterfv");
            AddBackwards(pages, "glPointParameter.xhtml", "glPointParameteri");
            AddBackwards(pages, "glPointParameter.xhtml", "glPointParameteriv");
            AddBackwards(pages, "glPointSize.xhtml", "glPointSize");
            AddBackwards(pages, "glPolygonMode.xhtml", "glPolygonMode");
            AddBackwards(pages, "glPolygonOffset.xhtml", "glPolygonOffset");
            AddBackwards(pages, "glPopDebugGroup.xhtml", "glPopDebugGroup");
            AddBackwards(pages, "pow.xhtml", "pow");
            AddBackwards(pages, "glPrimitiveRestartIndex.xhtml", "glPrimitiveRestartIndex");
            AddBackwards(pages, "glProgramBinary.xhtml", "glProgramBinary");
            AddBackwards(pages, "glProgramParameter.xhtml", "glProgramParameter");
            AddBackwards(pages, "glProgramParameter.xhtml", "glProgramParameteri");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform1f");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform1fv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform1i");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform1iv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform1ui");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform1uiv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform2f");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform2fv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform2i");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform2iv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform2ui");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform2uiv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform3f");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform3fv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform3i");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform3iv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform3ui");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform3uiv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform4f");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform4fv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform4i");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform4iv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform4ui");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniform4uiv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniformMatrix2fv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniformMatrix2x3fv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniformMatrix2x4fv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniformMatrix3fv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniformMatrix3x2fv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniformMatrix3x4fv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniformMatrix4fv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniformMatrix4x2fv");
            AddBackwards(pages, "glProgramUniform.xhtml", "glProgramUniformMatrix4x3fv");
            AddBackwards(pages, "glProvokingVertex.xhtml", "glProvokingVertex");
            AddBackwards(pages, "glPushDebugGroup.xhtml", "glPushDebugGroup");
            AddBackwards(pages, "glQueryCounter.xhtml", "glQueryCounter");
            AddBackwards(pages, "radians.xhtml", "radians");
            AddBackwards(pages, "glReadBuffer.xhtml", "glReadBuffer");
            AddBackwards(pages, "glReadPixels.xhtml", "glReadnPixels");
            AddBackwards(pages, "glReadPixels.xhtml", "glReadPixels");
            AddBackwards(pages, "reflect.xhtml", "reflect");
            AddBackwards(pages, "refract.xhtml", "refract");
            AddBackwards(pages, "glReleaseShaderCompiler.xhtml", "glReleaseShaderCompiler");
            AddBackwards(pages, "removedTypes.xhtml", "removedTypes");
            AddBackwards(pages, "glRenderbufferStorage.xhtml", "glRenderbufferStorage");
            AddBackwards(pages, "glRenderbufferStorageMultisample.xhtml", "glRenderbufferStorageMultisample");
            AddBackwards(pages, "glResumeTransformFeedback.xhtml", "glResumeTransformFeedback");
            AddBackwards(pages, "round.xhtml", "round");
            AddBackwards(pages, "roundEven.xhtml", "roundEven");
            AddBackwards(pages, "glSampleCoverage.xhtml", "glSampleCoverage");
            AddBackwards(pages, "glSampleMaski.xhtml", "glSampleMaski");
            AddBackwards(pages, "glSamplerParameter.xhtml", "glSamplerParameter");
            AddBackwards(pages, "glSamplerParameter.xhtml", "glSamplerParameterf");
            AddBackwards(pages, "glSamplerParameter.xhtml", "glSamplerParameterfv");
            AddBackwards(pages, "glSamplerParameter.xhtml", "glSamplerParameteri");
            AddBackwards(pages, "glSamplerParameter.xhtml", "glSamplerParameterIiv");
            AddBackwards(pages, "glSamplerParameter.xhtml", "glSamplerParameterIuiv");
            AddBackwards(pages, "glSamplerParameter.xhtml", "glSamplerParameteriv");
            AddBackwards(pages, "glScissor.xhtml", "glScissor");
            AddBackwards(pages, "glScissorArray.xhtml", "glScissorArray");
            AddBackwards(pages, "glScissorArray.xhtml", "glScissorArrayv");
            AddBackwards(pages, "glScissorIndexed.xhtml", "glScissorIndexed");
            AddBackwards(pages, "glScissorIndexed.xhtml", "glScissorIndexedv");
            AddBackwards(pages, "glShaderBinary.xhtml", "glShaderBinary");
            AddBackwards(pages, "glShaderSource.xhtml", "glShaderSource");
            AddBackwards(pages, "glShaderStorageBlockBinding.xhtml", "glShaderStorageBlockBinding");
            AddBackwards(pages, "sign.xhtml", "sign");
            AddBackwards(pages, "sin.xhtml", "sin");
            AddBackwards(pages, "sinh.xhtml", "sinh");
            AddBackwards(pages, "smoothstep.xhtml", "smoothstep");
            AddBackwards(pages, "sqrt.xhtml", "sqrt");
            AddBackwards(pages, "glStencilFunc.xhtml", "glStencilFunc");
            AddBackwards(pages, "glStencilFuncSeparate.xhtml", "glStencilFuncSeparate");
            AddBackwards(pages, "glStencilMask.xhtml", "glStencilMask");
            AddBackwards(pages, "glStencilMaskSeparate.xhtml", "glStencilMaskSeparate");
            AddBackwards(pages, "glStencilOp.xhtml", "glStencilOp");
            AddBackwards(pages, "glStencilOpSeparate.xhtml", "glStencilOpSeparate");
            AddBackwards(pages, "step.xhtml", "step");
            AddBackwards(pages, "tan.xhtml", "tan");
            AddBackwards(pages, "tanh.xhtml", "tanh");
            AddBackwards(pages, "glTexBuffer.xhtml", "glTexBuffer");
            AddBackwards(pages, "glTexBufferRange.xhtml", "glTexBufferRange");
            AddBackwards(pages, "texelFetch.xhtml", "texelFetch");
            AddBackwards(pages, "texelFetchOffset.xhtml", "texelFetchOffset");
            AddBackwards(pages, "glTexImage1D.xhtml", "glTexImage1D");
            AddBackwards(pages, "glTexImage2D.xhtml", "glTexImage2D");
            AddBackwards(pages, "glTexImage2DMultisample.xhtml", "glTexImage2DMultisample");
            AddBackwards(pages, "glTexImage3D.xhtml", "glTexImage3D");
            AddBackwards(pages, "glTexImage3DMultisample.xhtml", "glTexImage3DMultisample");
            AddBackwards(pages, "glTexParameter.xhtml", "glTexParameter");
            AddBackwards(pages, "glTexParameter.xhtml", "glTexParameterf");
            AddBackwards(pages, "glTexParameter.xhtml", "glTexParameterfv");
            AddBackwards(pages, "glTexParameter.xhtml", "glTexParameteri");
            AddBackwards(pages, "glTexParameter.xhtml", "glTexParameterIiv");
            AddBackwards(pages, "glTexParameter.xhtml", "glTexParameterIuiv");
            AddBackwards(pages, "glTexParameter.xhtml", "glTexParameteriv");
            AddBackwards(pages, "glTexStorage1D.xhtml", "glTexStorage1D");
            AddBackwards(pages, "glTexStorage2D.xhtml", "glTexStorage2D");
            AddBackwards(pages, "glTexStorage2DMultisample.xhtml", "glTexStorage2DMultisample");
            AddBackwards(pages, "glTexStorage3D.xhtml", "glTexStorage3D");
            AddBackwards(pages, "glTexStorage3DMultisample.xhtml", "glTexStorage3DMultisample");
            AddBackwards(pages, "glTexSubImage1D.xhtml", "glTexSubImage1D");
            AddBackwards(pages, "glTexSubImage2D.xhtml", "glTexSubImage2D");
            AddBackwards(pages, "glTexSubImage3D.xhtml", "glTexSubImage3D");
            AddBackwards(pages, "texture.xhtml", "texture");
            AddBackwards(pages, "glTextureBarrier.xhtml", "glTextureBarrier");
            AddBackwards(pages, "glTexBuffer.xhtml", "glTextureBuffer");
            AddBackwards(pages, "glTexBufferRange.xhtml", "glTextureBufferRange");
            AddBackwards(pages, "textureGather.xhtml", "textureGather");
            AddBackwards(pages, "textureGatherOffset.xhtml", "textureGatherOffset");
            AddBackwards(pages, "textureGatherOffsets.xhtml", "textureGatherOffsets");
            AddBackwards(pages, "textureGrad.xhtml", "textureGrad");
            AddBackwards(pages, "textureGradOffset.xhtml", "textureGradOffset");
            AddBackwards(pages, "textureLod.xhtml", "textureLod");
            AddBackwards(pages, "textureLodOffset.xhtml", "textureLodOffset");
            AddBackwards(pages, "textureOffset.xhtml", "textureOffset");
            AddBackwards(pages, "glTexParameter.xhtml", "glTextureParameterf");
            AddBackwards(pages, "glTexParameter.xhtml", "glTextureParameterfv");
            AddBackwards(pages, "glTexParameter.xhtml", "glTextureParameteri");
            AddBackwards(pages, "glTexParameter.xhtml", "glTextureParameterIiv");
            AddBackwards(pages, "glTexParameter.xhtml", "glTextureParameterIuiv");
            AddBackwards(pages, "glTexParameter.xhtml", "glTextureParameteriv");
            AddBackwards(pages, "textureProj.xhtml", "textureProj");
            AddBackwards(pages, "textureProjGrad.xhtml", "textureProjGrad");
            AddBackwards(pages, "textureProjGradOffset.xhtml", "textureProjGradOffset");
            AddBackwards(pages, "textureProjLod.xhtml", "textureProjLod");
            AddBackwards(pages, "textureProjLodOffset.xhtml", "textureProjLodOffset");
            AddBackwards(pages, "textureProjOffset.xhtml", "textureProjOffset");
            AddBackwards(pages, "textureQueryLevels.xhtml", "textureQueryLevels");
            AddBackwards(pages, "textureQueryLod.xhtml", "textureQueryLod");
            AddBackwards(pages, "textureSamples.xhtml", "textureSamples");
            AddBackwards(pages, "textureSize.xhtml", "textureSize");
            AddBackwards(pages, "glTexStorage1D.xhtml", "glTextureStorage1D");
            AddBackwards(pages, "glTexStorage2D.xhtml", "glTextureStorage2D");
            AddBackwards(pages, "glTexStorage2DMultisample.xhtml", "glTextureStorage2DMultisample");
            AddBackwards(pages, "glTexStorage3D.xhtml", "glTextureStorage3D");
            AddBackwards(pages, "glTexStorage3DMultisample.xhtml", "glTextureStorage3DMultisample");
            AddBackwards(pages, "glTexSubImage1D.xhtml", "glTextureSubImage1D");
            AddBackwards(pages, "glTexSubImage2D.xhtml", "glTextureSubImage2D");
            AddBackwards(pages, "glTexSubImage3D.xhtml", "glTextureSubImage3D");
            AddBackwards(pages, "glTextureView.xhtml", "glTextureView");
            AddBackwards(pages, "glTransformFeedbackBufferBase.xhtml", "glTransformFeedbackBufferBase");
            AddBackwards(pages, "glTransformFeedbackBufferRange.xhtml", "glTransformFeedbackBufferRange");
            AddBackwards(pages, "glTransformFeedbackVaryings.xhtml", "glTransformFeedbackVaryings");
            AddBackwards(pages, "transpose.xhtml", "transpose");
            AddBackwards(pages, "trunc.xhtml", "trunc");
            AddBackwards(pages, "uaddCarry.xhtml", "uaddCarry");
            AddBackwards(pages, "intBitsToFloat.xhtml", "uintBitsToFloat");
            AddBackwards(pages, "umulExtended.xhtml", "umulExtended");
            AddBackwards(pages, "glUniform.xhtml", "glUniform");
            AddBackwards(pages, "glUniform.xhtml", "glUniform1f");
            AddBackwards(pages, "glUniform.xhtml", "glUniform1fv");
            AddBackwards(pages, "glUniform.xhtml", "glUniform1i");
            AddBackwards(pages, "glUniform.xhtml", "glUniform1iv");
            AddBackwards(pages, "glUniform.xhtml", "glUniform1ui");
            AddBackwards(pages, "glUniform.xhtml", "glUniform1uiv");
            AddBackwards(pages, "glUniform.xhtml", "glUniform2f");
            AddBackwards(pages, "glUniform.xhtml", "glUniform2fv");
            AddBackwards(pages, "glUniform.xhtml", "glUniform2i");
            AddBackwards(pages, "glUniform.xhtml", "glUniform2iv");
            AddBackwards(pages, "glUniform.xhtml", "glUniform2ui");
            AddBackwards(pages, "glUniform.xhtml", "glUniform2uiv");
            AddBackwards(pages, "glUniform.xhtml", "glUniform3f");
            AddBackwards(pages, "glUniform.xhtml", "glUniform3fv");
            AddBackwards(pages, "glUniform.xhtml", "glUniform3i");
            AddBackwards(pages, "glUniform.xhtml", "glUniform3iv");
            AddBackwards(pages, "glUniform.xhtml", "glUniform3ui");
            AddBackwards(pages, "glUniform.xhtml", "glUniform3uiv");
            AddBackwards(pages, "glUniform.xhtml", "glUniform4f");
            AddBackwards(pages, "glUniform.xhtml", "glUniform4fv");
            AddBackwards(pages, "glUniform.xhtml", "glUniform4i");
            AddBackwards(pages, "glUniform.xhtml", "glUniform4iv");
            AddBackwards(pages, "glUniform.xhtml", "glUniform4ui");
            AddBackwards(pages, "glUniform.xhtml", "glUniform4uiv");
            AddBackwards(pages, "glUniformBlockBinding.xhtml", "glUniformBlockBinding");
            AddBackwards(pages, "glUniform.xhtml", "glUniformMatrix2fv");
            AddBackwards(pages, "glUniform.xhtml", "glUniformMatrix2x3fv");
            AddBackwards(pages, "glUniform.xhtml", "glUniformMatrix2x4fv");
            AddBackwards(pages, "glUniform.xhtml", "glUniformMatrix3fv");
            AddBackwards(pages, "glUniform.xhtml", "glUniformMatrix3x2fv");
            AddBackwards(pages, "glUniform.xhtml", "glUniformMatrix3x4fv");
            AddBackwards(pages, "glUniform.xhtml", "glUniformMatrix4fv");
            AddBackwards(pages, "glUniform.xhtml", "glUniformMatrix4x2fv");
            AddBackwards(pages, "glUniform.xhtml", "glUniformMatrix4x3fv");
            AddBackwards(pages, "glUniformSubroutines.xhtml", "glUniformSubroutines");
            AddBackwards(pages, "glUniformSubroutines.xhtml", "glUniformSubroutinesuiv");
            AddBackwards(pages, "glUnmapBuffer.xhtml", "glUnmapBuffer");
            AddBackwards(pages, "glUnmapBuffer.xhtml", "glUnmapNamedBuffer");
            AddBackwards(pages, "unpackDouble2x32.xhtml", "unpackDouble2x32");
            AddBackwards(pages, "unpackHalf2x16.xhtml", "unpackHalf2x16");
            AddBackwards(pages, "unpackUnorm.xhtml", "unpackSnorm2x16");
            AddBackwards(pages, "unpackUnorm.xhtml", "unpackSnorm4x8");
            AddBackwards(pages, "unpackUnorm.xhtml", "unpackUnorm");
            AddBackwards(pages, "unpackUnorm.xhtml", "unpackUnorm2x16");
            AddBackwards(pages, "unpackUnorm.xhtml", "unpackUnorm4x8");
            AddBackwards(pages, "glUseProgram.xhtml", "glUseProgram");
            AddBackwards(pages, "glUseProgramStages.xhtml", "glUseProgramStages");
            AddBackwards(pages, "usubBorrow.xhtml", "usubBorrow");
            AddBackwards(pages, "glValidateProgram.xhtml", "glValidateProgram");
            AddBackwards(pages, "glValidateProgramPipeline.xhtml", "glValidateProgramPipeline");
            AddBackwards(pages, "glVertexAttribBinding.xhtml", "glVertexArrayAttribBinding");
            AddBackwards(pages, "glVertexAttribFormat.xhtml", "glVertexArrayAttribFormat");
            AddBackwards(pages, "glVertexAttribFormat.xhtml", "glVertexArrayAttribIFormat");
            AddBackwards(pages, "glVertexAttribFormat.xhtml", "glVertexArrayAttribLFormat");
            AddBackwards(pages, "glVertexBindingDivisor.xhtml", "glVertexArrayBindingDivisor");
            AddBackwards(pages, "glVertexArrayElementBuffer.xhtml", "glVertexArrayElementBuffer");
            AddBackwards(pages, "glBindVertexBuffer.xhtml", "glVertexArrayVertexBuffer");
            AddBackwards(pages, "glBindVertexBuffers.xhtml", "glVertexArrayVertexBuffers");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib1d");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib1dv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib1f");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib1fv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib1s");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib1sv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib2d");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib2dv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib2f");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib2fv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib2s");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib2sv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib3d");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib3dv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib3f");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib3fv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib3s");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib3sv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4bv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4d");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4dv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4f");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4fv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4iv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4Nbv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4Niv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4Nsv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4Nub");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4Nubv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4Nuiv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4Nusv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4s");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4sv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4ubv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4uiv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttrib4usv");
            AddBackwards(pages, "glVertexAttribBinding.xhtml", "glVertexAttribBinding");
            AddBackwards(pages, "glVertexAttribDivisor.xhtml", "glVertexAttribDivisor");
            AddBackwards(pages, "glVertexAttribFormat.xhtml", "glVertexAttribFormat");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI1i");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI1iv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI1ui");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI1uiv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI2i");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI2iv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI2ui");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI2uiv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI3i");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI3iv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI3ui");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI3uiv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI4bv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI4i");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI4iv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI4sv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI4ubv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI4ui");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI4uiv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribI4usv");
            AddBackwards(pages, "glVertexAttribFormat.xhtml", "glVertexAttribIFormat");
            AddBackwards(pages, "glVertexAttribPointer.xhtml", "glVertexAttribIPointer");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribL1d");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribL1dv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribL2d");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribL2dv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribL3d");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribL3dv");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribL4d");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribL4dv");
            AddBackwards(pages, "glVertexAttribFormat.xhtml", "glVertexAttribLFormat");
            AddBackwards(pages, "glVertexAttribPointer.xhtml", "glVertexAttribLPointer");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribP1ui");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribP2ui");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribP3ui");
            AddBackwards(pages, "glVertexAttrib.xhtml", "glVertexAttribP4ui");
            AddBackwards(pages, "glVertexAttribPointer.xhtml", "glVertexAttribPointer");
            AddBackwards(pages, "glVertexBindingDivisor.xhtml", "glVertexBindingDivisor");
            AddBackwards(pages, "glViewport.xhtml", "glViewport");
            AddBackwards(pages, "glViewportArray.xhtml", "glViewportArray");
            AddBackwards(pages, "glViewportArray.xhtml", "glViewportArrayv");
            AddBackwards(pages, "glViewportIndexed.xhtml", "glViewportIndexed");
            AddBackwards(pages, "glViewportIndexed.xhtml", "glViewportIndexedf");
            AddBackwards(pages, "glViewportIndexed.xhtml", "glViewportIndexedfv");
            AddBackwards(pages, "glWaitSync.xhtml", "glWaitSync");
            return pages;
        }
    }
}
