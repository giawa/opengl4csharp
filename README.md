opengl4csharp
=============
## About
This code provides a limited subset of the Open Toolkit bindings to OpenGL.  I have kept only the methods that are OpenGL 4 compatible, meaning that any legacy fixed function pipeline methods have been removed.  I've also removed several enums and other code that dealt with supporting the fixed function pipeline.

Similar to the Open Toolkit bindings, these bindings work on Windows, Mac OS X and Linux (under the Mono framework).

This library also includes some common Math libraries, taken from my own graphics engine that I was developing.  These include bounding boxes, frustum, matrix4, plane, quaternion, ray, vector2, vector3 and vector4.  The class library also supports some common OpenGL constructs such as frame buffer objects (FBO), shader programs (both vertex and fragment), textures, vertex array objects (VAO) and vertex buffer objects (VBO).

Random History:  This code was written to help my friend with his Masters thesis, as he was wanting to do work with GLSL and OpenGL.  I wrote up these OpenGL 4 bindings over the course of two weeks in 2011 and they were never used.  It is about time someone got to play with them!  I'm also working on a [Voxel Engine](http://www.giawa.com) using this library, which is largely open source.

Note:  To use this library you will need a valid OpenGL context.  You can do this using FreeGLUT, or some equivalent.

## License
Check the included LICENSE.md file for the license associated with this code.

## Examples

### Getting started with [FreeGLUT](http://sourceforge.net/projects/opentk/)

The purpose of these examples is to walk through most of the functionality of this OpenGL library.  To do so, we need an OpenGL context.  So, I'm going to use [FreeGLUT](http://sourceforge.net/projects/opentk/) and show an example of how to use it.  If you already have an OpenGL context, you can skip this example.  In this case I am using Tao.FreeGlut, but OpenTK also has an implementation.

```csharp
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(width, height);
            Glut.glutCreateWindow("OpenGL");
            
            Glut.glutIdleFunc(OnRenderFrame);
            
            Glut.glutMainLoop();
```

Note:  OnRenderFrame will be the method we will be drawing something.  For now, you can leave it empty.

### Creating a Shader Program

Since we cannot use the fixed function pipeline, we'll first need a shader program that can manipulate our vertices and then draw our pixels.

Here is a simple vertex shader to transform our vertices:

```csharp
        public static string vertexShader2Source = @"
uniform mat4 projection_matrix;
uniform mat4 modelview_matrix;

attribute vec3 in_position;

void main(void)
{
  gl_Position = projection_matrix * modelview_matrix * vec4(in_position, 1);
}";
```

Here is a sample fragment shader that will draw pixels a color that we define:

```csharp
        public static string fragmentShader2Source = @"
uniform vec3 color;

void main(void)
{
  gl_FragColor = vec4(color, 1);
}";
```

Here is how we load the vertex and fragment programs, and then link them together to create a shader program.  We can also set the 'color' uniform value to blue (0, 0, 1).

```csharp
            // create the shader program
            ShaderProgram program = new ShaderProgram(vertexShader2Source, fragmentShader2Source);
            
            // set the color to blue
            program["color"].SetValue(new Vector3(0, 0, 1));
```

Note:  Make sure that you dispose of your new shader once your program closes!  The class library will alert you if the destructor of the object is called by the .NET framework before you call the Dispose method.

### Drawing to the screen

I'm assuming that you have your shader program loaded (use the example one above if not).  Here we'll use the Geometry class to quickly build up a cube and render it in our OnRenderFrame method.

First, create the cube during initialization (just after setting up FreeGLUT, but just before Glut.glutMainLoop()).  We also need to set up the shader with some defaults for the modelview and projection matrices.

```csharp
            // set up some defaults for the shader program project and modelview matrices
            program["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.45f, (float)width / height, 0.1f, 1000f));
            program["modelview_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(2, 2, -10)) * Matrix4.CreateRotation(new Vector3(1, -1, 0), 0.2f));

            // create a cube
            quad = OpenGL.Constructs.Geometry.CreateCube(program, new Vector3(-1, -1, -1), new Vector3(1, 1, 1));
```

Now draw the cube by using the shader program, drawing the cube and then swapping the Glut buffers.

```csharp
        private static void OnRenderFrame()
        {
            Gl.Viewport(0, 0, width, height);
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            quad.Program.Use();
            quad.Draw();

            Glut.glutSwapBuffers();
        }
```

### Loading a Texture

You can load a texture that is any format that the .NET framework can parse (.png, .bmp, .jpg, etc) as well as DDS compressed textures by using the Texture class.  The OpenGL library has overrides for passing a Texture object directly into BindTexture.  You can also get the Texture ID from the Texture object (available as a property).

Note:  Make sure to dispose of your textures, VAOs, VBOs and Shader Programs before exiting your program!

```csharp
            Texture newTexture = new Texture("file_path.jpg");
            Gl.BindTexture(newTexture);
```

## Further Reading
I quickly pushed this project to GitHub, so there isn't much documentation at this time.  The math objects are quite well documented, and some of the constructs also have decent documentation.  Check my website, [http://www.giawa.com](http://www.giawa.com) for some examples as I develope with this code.