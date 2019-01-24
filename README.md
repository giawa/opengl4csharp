# OpenGL 4 for C#/.NET
[![Build Status](https://travis-ci.org/giawa/opengl4csharp.svg?branch=master)](https://travis-ci.org/giawa/opengl4csharp)

This code started as a limited subset of the Open Toolkit bindings to OpenGL, but has evolved to include the latest functionality by parsing the OpenGL man pages directly.  I have kept only the methods that are OpenGL 4+ compatible, meaning that any legacy fixed function pipeline methods have been removed.  I've also removed several enums and other code that dealt with supporting the fixed function pipeline.

Similar to the Open Toolkit bindings, these bindings work on Windows, Mac OS X and Linux (under the Mono framework).

This library also includes some common Math libraries, taken from my own graphics engine that I was developing.  These include Bounding Box (AABB and OBB), Frustum, Matrix4, Plane, Quaternion, Ray, Vector2, Vector3 and Vector4.  The class library also supports some common OpenGL constructs such as Frame Buffer Objects (FBO), Shader Programs (vertex, fragment and geometry), Textures, Vertex Array Objects (VAO) and Vertex Buffer Objects (VBO).

Random History:  This code was written to help my friend with his Masters thesis, as he was wanting to do work with GLSL and OpenGL.  I wrote up these OpenGL 4 bindings over the course of two weeks in 2011 and they were never used.  It is about time someone got to play with them!  I'm also working on a [Voxel Engine](http://www.giawa.com) using this library, which is largely open source.

Note:  To use this library you will need a valid OpenGL context.  You can get this using FreeGLUT, SDL, or some equivalent.

## License
Check the included [LICENSE.md](https://github.com/giawa/opengl4csharp/blob/master/LICENSE.md) file for the license associated with this code.

## Getting the Project
This project can be downloaded and built manually (see below) or can be loaded easily from [nuget](https://www.nuget.org/packages/Giawa.OpenGL/).

```
Install-Package Giawa.OpenGL
```

## Building the Project
This project includes a .sln and .csproj file which will create an OpenGL class library.  This library includes a dll.config which will load the correct OpenGL on Windows, Mac OS X and Linux.  So, you need only compile this project once and it will work across platforms.

## Examples

### Getting started with [SDL 2.0](https://www.libsdl.org/download-2.0.php)

The purpose of these examples is to walk through the setup of this OpenGL library.  To do so, we need an OpenGL context.  So, I'm going to use [SDL 2.0](https://www.libsdl.org/download-2.0.php) and show an example of how to use it.  If you already have an OpenGL context, you can skip this example.  In this case I am using OpenGL.Platform (which uses SDL 2.0) to open and manage a window for me, and to create an OpenGL context.

```csharp
// create an OpenGL window
OpenGL.Platform.Window.CreateWindow("OpenGL", 1280, 720);
   
// handle events and render the frame
while (true)
{
   OpenGL.Platform.Window.HandleEvents();
   OnRenderFrame();
}
```

Note:  OnRenderFrame will be the method where we will be drawing something.  For now, you can leave it empty.

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

First, create the cube during initialization (just after CreateWindow, but before the main loop).  We also need to set up the shader with some defaults for the modelview and projection matrices.

```csharp
// set up some defaults for the shader program project and modelview matrices
program["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.45f, (float)width / height, 0.1f, 1000f));
program["modelview_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(2, 2, -10)) * Matrix4.CreateRotation(new Vector3(1, -1, 0), 0.2f));

// create a cube
cube = OpenGL.Geometry.CreateCube(program, new Vector3(-1, -1, -1), new Vector3(1, 1, 1));
```

Now draw the cube by using the shader program, drawing the cube and then swapping the buffers.

```csharp
private static void OnRenderFrame()
{
   Gl.Viewport(0, 0, width, height);
   Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

   cube.Program.Use();
   cube.Draw();

   OpenGL.Platform.Window.SwapBuffers();
}
```

### Loading a Texture

You can load a texture that is any format that the .NET framework can parse (.png, .bmp, .jpg, etc) as well as DDS compressed textures by using the Texture class.  The OpenGL library has overrides for passing a Texture object directly into BindTexture.  You can also get the Texture ID from the Texture object (available as a property).

Note:  Make sure to dispose of your textures, VAOs, VBOs and Shader Programs before exiting your program!

```csharp
Texture newTexture = new Texture("file_path.jpg");
Gl.BindTexture(newTexture);
```

### Vertex Buffer Objects (VBOs) and Vertex Array Objects (VAOs)

This is an example of creating a quad using a VBO for vertices (Vector3 data), a VBO for UV coordinates (Vector2 data) and a VBO of indices (uint data).  This VBO can then be rendered in a similar fashion to the cube method above.

```csharp
// create the vertex data
Vector3[] vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 1, 0), new Vector3(0, 1, 0) };
VBO<Vector3> vertexVBO = new VBO<Vector3>(vertices);

// create the UV data
Vector2[] uvs = new Vector2[] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) };
VBO<Vector2> uvVBO = new VBO<Vector2>(uvs);

// create the index data (the order in which the vertices should be drawn in groups of 3 to form triangles)
uint[] indices = new uint[] { 0, 1, 2, 2, 3, 0 };
VBO<uint> indexVBO = new VBO<uint>(indices, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead);

// create a vertex array object (VAO) from the vertex, UV and index data
VAO quad = new VAO(program, vertexVBO, uvVBO, indexVBO);
```

### A Note on System.Numerics and SIMD Support

The OpenGL library can now use System.Numerics for Vector2, Vector3, Vector4 and Quaternion, which can provide performance improvements by utilizing SIMD.  To enable System.Numerics support you must compile with the USE_NUMERICS option.  Make sure to add System.Numerics as a reference to your project, and then use Vector3/etc as normal.  The [nuget](https://www.nuget.org/packages/Giawa.OpenGL/) package and [dotnetcore](https://github.com/giawa/opengl4csharp/tree/dotnetcore) branch use SIMD by default.

## Extensions of OpenGL 4 for C#

### OpenGL.Platform

OpenGL.Platform is an optional class library that can be included in your projects.  The class library helps to create and manage an SDL window and OpenGL context.  The class library also supports some helpful functionality such as input handling, vertical sync and more.

### [OpenGL.UI](https://github.com/giawa/gui4opengl4csharp)

OpenGL.UI provides several basic user interface components.  OpenGL.UI relies upon OpenGL.Platform for input handling.  Several example projects are included and are mentioned in the project [README](https://github.com/giawa/gui4opengl4csharp/blob/master/README.md).

## Further Reading
There isn't much documentation for this project at this time.  The source code for both the math and constructs is quite well documented.  I have also compiled [OpenGL 4 for C#/.NET Tutorials](https://github.com/giawa/opengl4tutorials) which reference this library.  Work is underway to automatically pull the relevant OpenGL documentation from the man pages.

There is a [.NET Standard/Core branch](https://github.com/giawa/opengl4csharp/tree/dotnetcore) for this project, which is what has been used to build the [nuget](https://www.nuget.org/packages/Giawa.OpenGL/) package.  This package uses the excellent [ImageSharp](https://github.com/JimBobSquarePants/ImageSharp) library to load images, since .NET Standard does not include System.Drawing.  At some point I would like to merge the [dotnetcore](https://github.com/giawa/opengl4csharp/tree/dotnetcore) branch into master, but it needs further testing.