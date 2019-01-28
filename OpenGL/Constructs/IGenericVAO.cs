namespace OpenGL
{
    public interface IGenericVAO
    {
        int Offset { get; set; }
        int VertexCount { get; set; }
        bool DisposeChildren { get; set; }
        bool DisposeElementArray { get; set; }
        ShaderProgram Program { get; }
        BeginMode DrawMode { get; set; }
        uint ID { get; }
        GenericVAO.DrawFunc Draw { get; }
        GenericVAO.DrawInstancedFunc DrawInstanced { get; }
        void DrawProgram(ShaderProgram program);
    }
}
