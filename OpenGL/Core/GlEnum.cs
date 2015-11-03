using System;

namespace OpenGL
{
    public enum ActiveAttribType : int
    {
        Float = ((int)0x1406),
        FloatVec2 = ((int)0x8B50),
        FloatVec3 = ((int)0x8B51),
        FloatVec4 = ((int)0x8B52),
        FloatMat2 = ((int)0x8B5A),
        FloatMat3 = ((int)0x8B5B),
        FloatMat4 = ((int)0x8B5C),
    }

    public enum ActiveUniformBlockParameter : int
    {
        UniformBlockBinding = ((int)0x8A3F),
        UniformBlockDataSize = ((int)0x8A40),
        UniformBlockNameLength = ((int)0x8A41),
        UniformBlockActiveUniforms = ((int)0x8A42),
        UniformBlockActiveUniformIndices = ((int)0x8A43),
        UniformBlockReferencedByVertexShader = ((int)0x8A44),
        UniformBlockReferencedByFragmentShader = ((int)0x8A46),
    }

    public enum ActiveUniformType : int
    {
        Int = ((int)0x1404),
        Float = ((int)0x1406),
        FloatVec2 = ((int)0x8B50),
        FloatVec3 = ((int)0x8B51),
        FloatVec4 = ((int)0x8B52),
        IntVec2 = ((int)0x8B53),
        IntVec3 = ((int)0x8B54),
        IntVec4 = ((int)0x8B55),
        Bool = ((int)0x8B56),
        BoolVec2 = ((int)0x8B57),
        BoolVec3 = ((int)0x8B58),
        BoolVec4 = ((int)0x8B59),
        FloatMat2 = ((int)0x8B5A),
        FloatMat3 = ((int)0x8B5B),
        FloatMat4 = ((int)0x8B5C),
        Sampler1D = ((int)0x8B5D),
        Sampler2D = ((int)0x8B5E),
        Sampler3D = ((int)0x8B5F),
        SamplerCube = ((int)0x8B60),
        Sampler1DShadow = ((int)0x8B61),
        Sampler2DShadow = ((int)0x8B62),
        Sampler2DRect = ((int)0x8B63),
        Sampler2DRectShadow = ((int)0x8B64),
        FloatMat2x3 = ((int)0x8B65),
        FloatMat2x4 = ((int)0x8B66),
        FloatMat3x2 = ((int)0x8B67),
        FloatMat3x4 = ((int)0x8B68),
        FloatMat4x2 = ((int)0x8B69),
        FloatMat4x3 = ((int)0x8B6A),
        Sampler1DArray = ((int)0x8DC0),
        Sampler2DArray = ((int)0x8DC1),
        SamplerBuffer = ((int)0x8DC2),
        Sampler1DArrayShadow = ((int)0x8DC3),
        Sampler2DArrayShadow = ((int)0x8DC4),
        SamplerCubeShadow = ((int)0x8DC5),
        UnsignedIntVec2 = ((int)0x8DC6),
        UnsignedIntVec3 = ((int)0x8DC7),
        UnsignedIntVec4 = ((int)0x8DC8),
        IntSampler1D = ((int)0x8DC9),
        IntSampler2D = ((int)0x8DCA),
        IntSampler3D = ((int)0x8DCB),
        IntSamplerCube = ((int)0x8DCC),
        IntSampler2DRect = ((int)0x8DCD),
        IntSampler1DArray = ((int)0x8DCE),
        IntSampler2DArray = ((int)0x8DCF),
        IntSamplerBuffer = ((int)0x8DD0),
        UnsignedIntSampler1D = ((int)0x8DD1),
        UnsignedIntSampler2D = ((int)0x8DD2),
        UnsignedIntSampler3D = ((int)0x8DD3),
        UnsignedIntSamplerCube = ((int)0x8DD4),
        UnsignedIntSampler2DRect = ((int)0x8DD5),
        UnsignedIntSampler1DArray = ((int)0x8DD6),
        UnsignedIntSampler2DArray = ((int)0x8DD7),
        UnsignedIntSamplerBuffer = ((int)0x8DD8),
        Sampler2DMultisample = ((int)0x9108),
        IntSampler2DMultisample = ((int)0x9109),
        UnsignedIntSampler2DMultisample = ((int)0x910A),
        Sampler2DMultisampleArray = ((int)0x910B),
        IntSampler2DMultisampleArray = ((int)0x910C),
        UnsignedIntSampler2DMultisampleArray = ((int)0x910D),
    }

    public enum ArbSync : int
    {
        SyncFlushCommandsBit = ((int)0x00000001),
        MaxServerWaitTimeout = ((int)0x9111),
        ObjectType = ((int)0x9112),
        SyncCondition = ((int)0x9113),
        SyncStatus = ((int)0x9114),
        SyncFlags = ((int)0x9115),
        SyncFence = ((int)0x9116),
        SyncGpuCommandsComplete = ((int)0x9117),
        Unsignaled = ((int)0x9118),
        Signaled = ((int)0x9119),
        AlreadySignaled = ((int)0x911A),
        TimeoutExpired = ((int)0x911B),
        ConditionSatisfied = ((int)0x911C),
        WaitFailed = ((int)0x911D),
        TimeoutIgnored = unchecked((int)0xFFFFFFFFFFFFFFFF),
    }

    public enum AtomicCounterParameterName : int
    {
        AtomicCounterBufferBinding = ((int)0x92C1),
        AtomicCounterBufferDataSize = ((int)0x92C4),
        AtomicCounterBufferActiveAtomicCounters = ((int)0x92C5),
        AtomicCounterBufferActiveAtomicCounterIndices = ((int)0x92C6),
        AtomicCounterBufferReferencedByVertexShader = ((int)0x92C7),
        AtomicCounterBufferReferencedByTessControlShader = ((int)0x92C8),
        AtomicCounterBufferReferencedByTessEvaluationShader = ((int)0x92C9),
        AtomicCounterBufferReferencedByGeometryShader = ((int)0x92CA),
        AtomicCounterBufferReferencedByFragmentShader = ((int)0x92CB),
        AtomicCounterBufferReferencedByComputeShader = ((int)0x90ED)
    }

    public enum BeginFeedbackMode : int
    {
        Points = ((int)0x0000),
        Lines = ((int)0x0001),
        Triangles = ((int)0x0004),
    }

    public enum BeginMode : int
    {
        Points = ((int)0x0000),
        Lines = ((int)0x0001),
        LineLoop = ((int)0x0002),
        LineStrip = ((int)0x0003),
        Triangles = ((int)0x0004),
        TriangleStrip = ((int)0x0005),
        TriangleFan = ((int)0x0006),
        LinesAdjacency = ((int)0xA),
        LineStripAdjacency = ((int)0xB),
        TrianglesAdjacency = ((int)0xC),
        TriangleStripAdjacency = ((int)0xD),
        Patches = ((int)0xE),
        [Obsolete("OpenGL 4 Core does not support quads.")]
        Quads = ((int)0x0007),
        [Obsolete("OpenGL 4 Core does not support quads.")]
        QuadStrip = ((int)0x0008)
    }

    public enum BlendEquationMode : int
    {
        FuncAdd = ((int)0x8006),
        Min = ((int)0x8007),
        Max = ((int)0x8008),
        FuncSubtract = ((int)0x800A),
        FuncReverseSubtract = ((int)0x800B),
    }

    public enum BlendingFactorDest : int
    {
        Zero = ((int)0),
        SrcColor = ((int)0x0300),
        OneMinusSrcColor = ((int)0x0301),
        SrcAlpha = ((int)0x0302),
        OneMinusSrcAlpha = ((int)0x0303),
        DstAlpha = ((int)0x0304),
        OneMinusDstAlpha = ((int)0x0305),
        DstColor = ((int)0x0306),
        OneMinusDstColor = ((int)0x0307),
        ConstantColor = ((int)0x8001),
        ConstantColorExt = ((int)0x8001),
        OneMinusConstantColor = ((int)0x8002),
        OneMinusConstantColorExt = ((int)0x8002),
        ConstantAlpha = ((int)0x8003),
        ConstantAlphaExt = ((int)0x8003),
        OneMinusConstantAlpha = ((int)0x8004),
        OneMinusConstantAlphaExt = ((int)0x8004),
        One = ((int)1),
    }

    public enum BlendingFactorSrc : int
    {
        Zero = ((int)0),
        SrcAlpha = ((int)0x0302),
        OneMinusSrcAlpha = ((int)0x0303),
        DstAlpha = ((int)0x0304),
        OneMinusDstAlpha = ((int)0x0305),
        DstColor = ((int)0x0306),
        OneMinusDstColor = ((int)0x0307),
        SrcAlphaSaturate = ((int)0x0308),
        ConstantColor = ((int)0x8001),
        ConstantColorExt = ((int)0x8001),
        OneMinusConstantColor = ((int)0x8002),
        OneMinusConstantColorExt = ((int)0x8002),
        ConstantAlpha = ((int)0x8003),
        ConstantAlphaExt = ((int)0x8003),
        OneMinusConstantAlpha = ((int)0x8004),
        OneMinusConstantAlphaExt = ((int)0x8004),
        One = ((int)1),
    }

    public enum BlitFramebufferFilter : int
    {
        Nearest = ((int)0x2600),
        Linear = ((int)0x2601),
    }

    public enum BufferAccess : int
    {
        ReadOnly = ((int)0x88B8),
        WriteOnly = ((int)0x88B9),
        ReadWrite = ((int)0x88BA),
    }

    [Flags]
    public enum BufferAccessMask : int
    {
        MapReadBit = ((int)0x0001),
        MapWriteBit = ((int)0x0002),
        MapInvalidateRangeBit = ((int)0x0004),
        MapInvalidateBufferBit = ((int)0x0008),
        MapFlushExplicitBit = ((int)0x0010),
        MapUnsynchronizedBit = ((int)0x0020),
    }

    public enum BufferParameterName : int
    {
        BufferSize = ((int)0x8764),
        BufferUsage = ((int)0x8765),
        BufferAccess = ((int)0x88BB),
        BufferMapped = ((int)0x88BC),
    }

    public enum BufferPointer : int
    {
        BufferMapPointer = ((int)0x88BD),
    }

    public enum BufferTarget : int
    {
        ArrayBuffer = ((int)0x8892),
        ElementArrayBuffer = ((int)0x8893),
        PixelPackBuffer = ((int)0x88EB),
        PixelUnpackBuffer = ((int)0x88EC),
        UniformBuffer = ((int)0x8A11),
        TextureBuffer = ((int)0x8C2A),
        TransformFeedbackBuffer = ((int)0x8C8E),
        CopyReadBuffer = ((int)0x8F36),
        CopyWriteBuffer = ((int)0x8F37),
        DrawIndirectBuffer = ((int)0x8F3F),
        AtomicCounterBuffer = ((int)0x92C0),
        DispatchIndirectBuffer = ((int)0x90EE),
        QueryBuffer = ((int)0x9192),
        ShaderStorageBuffer = ((int)0x90D2),
    }

    public enum BufferUsageHint : int
    {
        StreamDraw = ((int)0x88E0),
        StreamRead = ((int)0x88E1),
        StreamCopy = ((int)0x88E2),
        StaticDraw = ((int)0x88E4),
        StaticRead = ((int)0x88E5),
        StaticCopy = ((int)0x88E6),
        DynamicDraw = ((int)0x88E8),
        DynamicRead = ((int)0x88E9),
        DynamicCopy = ((int)0x88EA),
    }

    public enum ClampColorMode : int
    {
        False = ((int)0),
        FixedOnly = ((int)0x891D),
        True = ((int)1),
    }

    public enum ClampColorTarget : int
    {
        ClampVertexColor = ((int)0x891A),
        ClampFragmentColor = ((int)0x891B),
        ClampReadColor = ((int)0x891C),
    }

    public enum ClearBuffer : int
    {
        Color = ((int)0x1800),
        Depth = ((int)0x1801),
        Stencil = ((int)0x1802),
        DepthStencil = ((int)0x84F9),
    }

    [Flags]
    public enum ClearBufferMask : int
    {
        DepthBufferBit = ((int)0x00000100),
        AccumBufferBit = ((int)0x00000200),
        StencilBufferBit = ((int)0x00000400),
        ColorBufferBit = ((int)0x00004000),
    }

    public enum ClipControlOrigin : int
    {
        LowerLeft = ((int)0x8CA1),
        UpperLeft = ((int)0x8CA2)
    }

    public enum ClipControlDepth : int
    {
        NegativeOneToOne = ((int)0x935E),
        ZeroToOne = ((int)0x935F)
    }

    public enum ConditionalRenderType : int
    {
        QueryWait = ((int)0x8E13),
        QueryNoWait = ((int)0x8E14),
        QueryByRegionWait = ((int)0x8E15),
        QueryByRegionNoWait = ((int)0x8E16),
    }

    public enum CullFaceMode : int
    {
        Front = ((int)0x0404),
        Back = ((int)0x0405),
        FrontAndBack = ((int)0x0408),
    }

    public enum DepthFunction : int
    {
        Never = ((int)0x0200),
        Less = ((int)0x0201),
        Equal = ((int)0x0202),
        Lequal = ((int)0x0203),
        Greater = ((int)0x0204),
        Notequal = ((int)0x0205),
        Gequal = ((int)0x0206),
        Always = ((int)0x0207),
    }

    public enum DrawBuffersEnum : int
    {
        None = ((int)0),
        FrontLeft = ((int)0x0400),
        FrontRight = ((int)0x0401),
        BackLeft = ((int)0x0402),
        BackRight = ((int)0x0403),
        Aux0 = ((int)0x0409),
        Aux1 = ((int)0x040A),
        Aux2 = ((int)0x040B),
        Aux3 = ((int)0x040C),
        ColorAttachment0 = ((int)0x8CE0),
        ColorAttachment1 = ((int)0x8CE1),
        ColorAttachment2 = ((int)0x8CE2),
        ColorAttachment3 = ((int)0x8CE3),
        ColorAttachment4 = ((int)0x8CE4),
        ColorAttachment5 = ((int)0x8CE5),
        ColorAttachment6 = ((int)0x8CE6),
        ColorAttachment7 = ((int)0x8CE7),
        ColorAttachment8 = ((int)0x8CE8),
        ColorAttachment9 = ((int)0x8CE9),
        ColorAttachment10 = ((int)0x8CEA),
        ColorAttachment11 = ((int)0x8CEB),
        ColorAttachment12 = ((int)0x8CEC),
        ColorAttachment13 = ((int)0x8CED),
        ColorAttachment14 = ((int)0x8CEE),
        ColorAttachment15 = ((int)0x8CEF),
    }

    public enum DrawBufferMode : int
    {
        None = ((int)0),
        FrontLeft = ((int)0x0400),
        FrontRight = ((int)0x0401),
        BackLeft = ((int)0x0402),
        BackRight = ((int)0x0403),
        Front = ((int)0x0404),
        Back = ((int)0x0405),
        Left = ((int)0x0406),
        Right = ((int)0x0407),
        FrontAndBack = ((int)0x0408),
        Aux0 = ((int)0x0409),
        Aux1 = ((int)0x040A),
        Aux2 = ((int)0x040B),
        Aux3 = ((int)0x040C),
        ColorAttachment0 = ((int)0x8CE0),
        ColorAttachment1 = ((int)0x8CE1),
        ColorAttachment2 = ((int)0x8CE2),
        ColorAttachment3 = ((int)0x8CE3),
        ColorAttachment4 = ((int)0x8CE4),
        ColorAttachment5 = ((int)0x8CE5),
        ColorAttachment6 = ((int)0x8CE6),
        ColorAttachment7 = ((int)0x8CE7),
        ColorAttachment8 = ((int)0x8CE8),
        ColorAttachment9 = ((int)0x8CE9),
        ColorAttachment10 = ((int)0x8CEA),
        ColorAttachment11 = ((int)0x8CEB),
        ColorAttachment12 = ((int)0x8CEC),
        ColorAttachment13 = ((int)0x8CED),
        ColorAttachment14 = ((int)0x8CEE),
        ColorAttachment15 = ((int)0x8CEF),
    }

    public enum DrawElementsType : int
    {
        UnsignedByte = ((int)0x1401),
        UnsignedShort = ((int)0x1403),
        UnsignedInt = ((int)0x1405),
    }

    public enum EnableCap : int
    {
        //PointSmooth = ((int)0x0B10),
        LineSmooth = ((int)0x0B20),
        //LineStipple = ((int)0x0B24),
        PolygonSmooth = ((int)0x0B41),
        //PolygonStipple = ((int)0x0B42),
        CullFace = ((int)0x0B44),
        //Lighting = ((int)0x0B50),
        //ColorMaterial = ((int)0x0B57),
        //Fog = ((int)0x0B60),
        DepthTest = ((int)0x0B71),
        StencilTest = ((int)0x0B90),
        //Normalize = ((int)0x0BA1),
        //AlphaTest = ((int)0x0BC0),
        Dither = ((int)0x0BD0),
        Blend = ((int)0x0BE2),
        IndexLogicOp = ((int)0x0BF1),
        ColorLogicOp = ((int)0x0BF2),
        ScissorTest = ((int)0x0C11),
        /*TextureGenS = ((int)0x0C60),
        TextureGenT = ((int)0x0C61),
        TextureGenR = ((int)0x0C62),
        TextureGenQ = ((int)0x0C63),*/
        AutoNormal = ((int)0x0D80),
        Map1Color4 = ((int)0x0D90),
        Map1Index = ((int)0x0D91),
        Map1Normal = ((int)0x0D92),
        Map1TextureCoord1 = ((int)0x0D93),
        Map1TextureCoord2 = ((int)0x0D94),
        Map1TextureCoord3 = ((int)0x0D95),
        Map1TextureCoord4 = ((int)0x0D96),
        Map1Vertex3 = ((int)0x0D97),
        Map1Vertex4 = ((int)0x0D98),
        Map2Color4 = ((int)0x0DB0),
        Map2Index = ((int)0x0DB1),
        Map2Normal = ((int)0x0DB2),
        Map2TextureCoord1 = ((int)0x0DB3),
        Map2TextureCoord2 = ((int)0x0DB4),
        Map2TextureCoord3 = ((int)0x0DB5),
        Map2TextureCoord4 = ((int)0x0DB6),
        Map2Vertex3 = ((int)0x0DB7),
        Map2Vertex4 = ((int)0x0DB8),
        Texture1D = ((int)0x0DE0),
        Texture2D = ((int)0x0DE1),
        PolygonOffsetPoint = ((int)0x2A01),
        PolygonOffsetLine = ((int)0x2A02),
        ClipPlane0 = ((int)0x3000),
        ClipPlane1 = ((int)0x3001),
        ClipPlane2 = ((int)0x3002),
        ClipPlane3 = ((int)0x3003),
        ClipPlane4 = ((int)0x3004),
        ClipPlane5 = ((int)0x3005),
        /*Light0 = ((int)0x4000),
        Light1 = ((int)0x4001),
        Light2 = ((int)0x4002),
        Light3 = ((int)0x4003),
        Light4 = ((int)0x4004),
        Light5 = ((int)0x4005),
        Light6 = ((int)0x4006),
        Light7 = ((int)0x4007),*/
        Convolution1D = ((int)0x8010),
        Convolution1DExt = ((int)0x8010),
        Convolution2D = ((int)0x8011),
        Convolution2DExt = ((int)0x8011),
        Separable2D = ((int)0x8012),
        Separable2DExt = ((int)0x8012),
        Histogram = ((int)0x8024),
        HistogramExt = ((int)0x8024),
        MinmaxExt = ((int)0x802E),
        PolygonOffsetFill = ((int)0x8037),
        //RescaleNormal = ((int)0x803A),
        RescaleNormalExt = ((int)0x803A),
        Texture3DExt = ((int)0x806F),
        VertexArray = ((int)0x8074),
        NormalArray = ((int)0x8075),
        ColorArray = ((int)0x8076),
        IndexArray = ((int)0x8077),
        TextureCoordArray = ((int)0x8078),
        EdgeFlagArray = ((int)0x8079),
        InterlaceSgix = ((int)0x8094),
        Multisample = ((int)0x809D),
        SampleAlphaToCoverage = ((int)0x809E),
        SampleAlphaToMaskSgis = ((int)0x809E),
        SampleAlphaToOne = ((int)0x809F),
        SampleAlphaToOneSgis = ((int)0x809F),
        SampleCoverage = ((int)0x80A0),
        SampleMaskSgis = ((int)0x80A0),
        TextureColorTableSgi = ((int)0x80BC),
        ColorTable = ((int)0x80D0),
        ColorTableSgi = ((int)0x80D0),
        PostConvolutionColorTable = ((int)0x80D1),
        PostConvolutionColorTableSgi = ((int)0x80D1),
        PostColorMatrixColorTable = ((int)0x80D2),
        PostColorMatrixColorTableSgi = ((int)0x80D2),
        Texture4DSgis = ((int)0x8134),
        PixelTexGenSgix = ((int)0x8139),
        SpriteSgix = ((int)0x8148),
        ReferencePlaneSgix = ((int)0x817D),
        IrInstrument1Sgix = ((int)0x817F),
        CalligraphicFragmentSgix = ((int)0x8183),
        FramezoomSgix = ((int)0x818B),
        FogOffsetSgix = ((int)0x8198),
        SharedTexturePaletteExt = ((int)0x81FB),
        AsyncHistogramSgix = ((int)0x832C),
        PixelTextureSgis = ((int)0x8353),
        AsyncTexImageSgix = ((int)0x835C),
        AsyncDrawPixelsSgix = ((int)0x835D),
        AsyncReadPixelsSgix = ((int)0x835E),
        FragmentLightingSgix = ((int)0x8400),
        FragmentColorMaterialSgix = ((int)0x8401),
        FragmentLight0Sgix = ((int)0x840C),
        FragmentLight1Sgix = ((int)0x840D),
        FragmentLight2Sgix = ((int)0x840E),
        FragmentLight3Sgix = ((int)0x840F),
        FragmentLight4Sgix = ((int)0x8410),
        FragmentLight5Sgix = ((int)0x8411),
        FragmentLight6Sgix = ((int)0x8412),
        FragmentLight7Sgix = ((int)0x8413),
        //FogCoordArray = ((int)0x8457),
        ColorSum = ((int)0x8458),
        SecondaryColorArray = ((int)0x845E),
        TextureCubeMap = ((int)0x8513),
        ProgramPointSize = ((int)0x8642),
        VertexProgramPointSize = ((int)0x8642),
        //VertexProgramTwoSide = ((int)0x8643),
        DepthClamp = ((int)0x864F),
        TextureCubeMapSeamless = ((int)0x884F),
        PointSprite = ((int)0x8861),
        RasterizerDiscard = ((int)0x8C89),
        FramebufferSrgb = ((int)0x8DB9),
        SampleMask = ((int)0x8E51),
        PrimitiveRestart = ((int)0x8F9D),
    }

    public enum ErrorCode : int
    {
        NoError = ((int)0),
        InvalidEnum = ((int)0x0500),
        InvalidValue = ((int)0x0501),
        InvalidOperation = ((int)0x0502),
        StackOverflow = ((int)0x0503),
        StackUnderflow = ((int)0x0504),
        OutOfMemory = ((int)0x0505),
        InvalidFramebufferOperation = ((int)0x0506),
        InvalidFramebufferOperationExt = ((int)0x0506),
        TableTooLargeExt = ((int)0x8031),
        TextureTooLargeExt = ((int)0x8065),
    }

    public enum FramebufferAttachment : int
    {
        DepthStencilAttachment = ((int)0x821A),
        ColorAttachment0 = ((int)0x8CE0),
        ColorAttachment0Ext = ((int)0x8CE0),
        ColorAttachment1 = ((int)0x8CE1),
        ColorAttachment1Ext = ((int)0x8CE1),
        ColorAttachment2 = ((int)0x8CE2),
        ColorAttachment2Ext = ((int)0x8CE2),
        ColorAttachment3 = ((int)0x8CE3),
        ColorAttachment3Ext = ((int)0x8CE3),
        ColorAttachment4 = ((int)0x8CE4),
        ColorAttachment4Ext = ((int)0x8CE4),
        ColorAttachment5 = ((int)0x8CE5),
        ColorAttachment5Ext = ((int)0x8CE5),
        ColorAttachment6 = ((int)0x8CE6),
        ColorAttachment6Ext = ((int)0x8CE6),
        ColorAttachment7 = ((int)0x8CE7),
        ColorAttachment7Ext = ((int)0x8CE7),
        ColorAttachment8 = ((int)0x8CE8),
        ColorAttachment8Ext = ((int)0x8CE8),
        ColorAttachment9 = ((int)0x8CE9),
        ColorAttachment9Ext = ((int)0x8CE9),
        ColorAttachment10 = ((int)0x8CEA),
        ColorAttachment10Ext = ((int)0x8CEA),
        ColorAttachment11 = ((int)0x8CEB),
        ColorAttachment11Ext = ((int)0x8CEB),
        ColorAttachment12 = ((int)0x8CEC),
        ColorAttachment12Ext = ((int)0x8CEC),
        ColorAttachment13 = ((int)0x8CED),
        ColorAttachment13Ext = ((int)0x8CED),
        ColorAttachment14 = ((int)0x8CEE),
        ColorAttachment14Ext = ((int)0x8CEE),
        ColorAttachment15 = ((int)0x8CEF),
        ColorAttachment15Ext = ((int)0x8CEF),
        DepthAttachment = ((int)0x8D00),
        DepthAttachmentExt = ((int)0x8D00),
        StencilAttachment = ((int)0x8D20),
        StencilAttachmentExt = ((int)0x8D20),
    }

    public enum FramebufferErrorCode : int
    {
        FramebufferUndefined = ((int)0x8219),
        FramebufferComplete = ((int)0x8CD5),
        FramebufferCompleteExt = ((int)0x8CD5),
        FramebufferIncompleteAttachment = ((int)0x8CD6),
        FramebufferIncompleteAttachmentExt = ((int)0x8CD6),
        FramebufferIncompleteMissingAttachment = ((int)0x8CD7),
        FramebufferIncompleteMissingAttachmentExt = ((int)0x8CD7),
        FramebufferIncompleteDimensionsExt = ((int)0x8CD9),
        FramebufferIncompleteFormatsExt = ((int)0x8CDA),
        FramebufferIncompleteDrawBuffer = ((int)0x8CDB),
        FramebufferIncompleteDrawBufferExt = ((int)0x8CDB),
        FramebufferIncompleteReadBuffer = ((int)0x8CDC),
        FramebufferIncompleteReadBufferExt = ((int)0x8CDC),
        FramebufferUnsupported = ((int)0x8CDD),
        FramebufferUnsupportedExt = ((int)0x8CDD),
        FramebufferIncompleteMultisample = ((int)0x8D56),
        FramebufferIncompleteLayerTargets = ((int)0x8DA8),
        FramebufferIncompleteLayerCount = ((int)0x8DA9),
    }

    public enum FramebufferPName : int
    {
        FramebufferDefaultWidth = ((int)0x9310),
        FramebufferDefaultHeight = ((int)0x9311),
        FramebufferDefaultLayers = ((int)0x9312),
        FramebufferDefaultSamples = ((int)0x9313),
        FramebufferDefaultFixedSampleLocations = ((int)0x9314)
    }

    public enum FramebufferParameterName : int
    {
        FramebufferAttachmentColorEncoding = ((int)0x8210),
        FramebufferAttachmentComponentType = ((int)0x8211),
        FramebufferAttachmentRedSize = ((int)0x8212),
        FramebufferAttachmentGreenSize = ((int)0x8213),
        FramebufferAttachmentBlueSize = ((int)0x8214),
        FramebufferAttachmentAlphaSize = ((int)0x8215),
        FramebufferAttachmentDepthSize = ((int)0x8216),
        FramebufferAttachmentStencilSize = ((int)0x8217),
        FramebufferAttachmentObjectType = ((int)0x8CD0),
        FramebufferAttachmentObjectTypeExt = ((int)0x8CD0),
        FramebufferAttachmentObjectName = ((int)0x8CD1),
        FramebufferAttachmentObjectNameExt = ((int)0x8CD1),
        FramebufferAttachmentTextureLevel = ((int)0x8CD2),
        FramebufferAttachmentTextureLevelExt = ((int)0x8CD2),
        FramebufferAttachmentTextureCubeMapFace = ((int)0x8CD3),
        FramebufferAttachmentTextureCubeMapFaceExt = ((int)0x8CD3),
        FramebufferAttachmentTexture3DZoffsetExt = ((int)0x8CD4),
        FramebufferAttachmentTextureLayer = ((int)0x8CD4),
        FramebufferAttachmentLayered = ((int)0x8DA7),
    }

    public enum FramebufferTarget : int
    {
        ReadFramebuffer = ((int)0x8CA8),
        DrawFramebuffer = ((int)0x8CA9),
        Framebuffer = ((int)0x8D40),
        FramebufferExt = ((int)0x8D40),
    }

    public enum FrontFaceDirection : int
    {
        Cw = ((int)0x0900),
        Ccw = ((int)0x0901),
    }

    public enum GenerateMipmapTarget : int
    {
        Texture1D = ((int)0x0DE0),
        Texture2D = ((int)0x0DE1),
        Texture3D = ((int)0x806F),
        TextureCubeMap = ((int)0x8513),
        Texture1DArray = ((int)0x8C18),
        Texture2DArray = ((int)0x8C1A),
        Texture2DMultisample = ((int)0x9100),
        Texture2DMultisampleArray = ((int)0x9102),
    }

    public enum GetMultisamplePName : int
    {
        SamplePosition = ((int)0x8E50),
    }

    public enum GetPName : int
    {
        ActiveTexture = ((int)0x84E0),
        AliasedLineWidthRange = ((int)0x846E),
        ArrayBufferBinding = ((int)0x8894),
        Blend = ((int)0x0BE2),
        BlendColor = ((int)0x8005),
        [Obsolete("Use BlendColor instead.")]
        BlendColorExt = ((int)0x8005),
        BlendDstAlpha = ((int)0x80CA),
        BlendDstRgb = ((int)0x80C8),
        BlendEquationAlpha = ((int)0x883D),
        BlendEquationRgb = ((int)0x8009),
        BlendSrcAlpha = ((int)0x80CB),
        BlendSrcRgb = ((int)0x80C9),
        ColorClearValue = ((int)0x0C22),
        ColorLogicOp = ((int)0x0BF2),
        ColorWritemask = ((int)0x0C23),
        CompressedTextureFormats = ((int)0x86A3),
        MaxComputeShaderStorageBlocks = ((int)0x90DB),
        MaxCombinedShaderStorageBlocks = ((int)0x90DC),
        MaxComputeUniformBlocks = ((int)0x91BB),
        MaxComputeTextureImageUnits = ((int)0x91BC),
        MaxComputeUniformComponents = ((int)0x8263),
        MaxComputeAtomicCounters = ((int)0x8265),
        MaxComputeAtomicCounterBuffers = ((int)0x8264),
        MaxCombinedComputeUniformComponents = ((int)0x8266),
        MaxComputeWorkGroupInvocations = ((int)0x90EB),
        MaxComputeWorkGroupCount = ((int)0x91BE),
        MaxComputeWorkGroupSize = ((int)0x91BF),
        DispatchIndirectBufferBinding = ((int)0x90EF),
        MaxDebugGroupStackDepth = ((int)0x826C),
        DebugGroupStackDepth = ((int)0x826D),
        ContextFlags = ((int)0x821E),
        CullFace = ((int)0x0B44),
        CurrentProgram = ((int)0x8B8D),
        DepthClearValue = ((int)0x0B73),
        DepthFunc = ((int)0x0B74),
        DepthRange = ((int)0x0B70),
        DepthScale = ((int)0x0D1E),
        DepthTest = ((int)0x0B71),
        DepthWritemask = ((int)0x0B72),
        Dither = ((int)0x0BD0),
        Doublebuffer = ((int)0x0C32),
        DrawBuffer = ((int)0x0C01),
        DrawBuffer0 = ((int)0x8825),
        DrawBuffer1 = ((int)0x8826),
        DrawBuffer10 = ((int)0x882F),
        DrawBuffer11 = ((int)0x8830),
        DrawBuffer12 = ((int)0x8831),
        DrawBuffer13 = ((int)0x8832),
        DrawBuffer14 = ((int)0x8833),
        DrawBuffer15 = ((int)0x8834),
        DrawBuffer2 = ((int)0x8827),
        DrawBuffer3 = ((int)0x8828),
        DrawBuffer4 = ((int)0x8829),
        DrawBuffer5 = ((int)0x882A),
        DrawBuffer6 = ((int)0x882B),
        DrawBuffer7 = ((int)0x882C),
        DrawBuffer8 = ((int)0x882D),
        DrawBuffer9 = ((int)0x882E),
        DrawFramebufferBinding = ((int)0x8CA6),
        ReadFramebufferBinding = ((int)0x8CAA),
        ElementArrayBufferBinding = ((int)0x8895),
        FragmentShaderDerivativeHint = ((int)0x8B8B),
        ImplementationColorReadFormat = ((int)0x8B9B),
        ImplementationColorReadType = ((int)0x8B9A),
        LineSmooth = ((int)0x0B20),
        LineSmoothHint = ((int)0x0C52),
        LineWidth = ((int)0x0B21),
        LayerProvokingVertex = ((int)0x825E),
        LogicOpMode = ((int)0x0BF0),
        MajorVersion = ((int)0x821B),
        Max3DTextureSize = ((int)0x8073),
        MaxArrayTextureLayers = ((int)0x88FF),
        MaxClipDistances = ((int)0x0D32),
        MaxColorTextureSamples = ((int)0x910E),
        MaxCombinedAtomicCounters = ((int)0x92D7),
        MaxCombinedFragmentUniformComponents = ((int)0x8A33),
        MaxCombinedGeometryUniformComponents = ((int)0x8A32),
        MaxCombinedTextureImageUnits = ((int)0x8B4D),
        MaxCombinedUniformBlocks = ((int)0x8A2E),
        MaxCombinedVertexUniformComponents = ((int)0x8A31),
        MaxCubeMapTextureSize = ((int)0x851C),
        MaxDepthTextureSamples = ((int)0x910F),
        MaxDrawBuffers = ((int)0x8824),
        MaxElementsIndices = ((int)0x80E9),
        MaxElementsVertices = ((int)0x80E8),
        MaxFragmentAtomicCounters = ((int)0x92D6),
        MaxFragmentShaderStorageBlocks = ((int)0x90DA),
        MaxFragmentInputComponents = ((int)0x9125),
        MaxFragmentUniformComponents = ((int)0x8B49),
        MaxFragmentUniformVectors = ((int)0x8DFD),
        MaxFragmentUniformBlocks = ((int)0x8A2D),
        MaxFramebufferWidth = ((int)0x9315),
        MaxFramebufferHeight = ((int)0x9316),
        MaxFramebufferLayers = ((int)0x9317),
        MaxFramebufferSamples = ((int)0x9318),
        MaxGeometryAtomicCounters = ((int)0x92D5),
        MaxGeometryShaderStorageBlocks = ((int)0x90D7),
        MaxGeometryInputComponents = ((int)0x9123),
        MaxGeometryOutputComponents = ((int)0x9124),
        MaxGeometryTextureImageUnits = ((int)0x8C29),
        MaxGeometryUniformBlocks = ((int)0x8A2C),
        MaxGeometryUniformComponents = ((int)0x8DDF),
        MaxIntegerSamples = ((int)0x9110),
        MinMapBufferAlignment = ((int)0x90BC),
        MaxLabelLength = ((int)0x82E8),
        MaxProgramTexelOffset = ((int)0x8905),
        MinProgramTexelOffset = ((int)0x8904),
        MaxRectangleTextureSize = ((int)0x84F8),
        MaxRenderbufferSize = ((int)0x84E8),
        MaxSampleMaskWords = ((int)0x8E59),
        MaxServerWaitTimeout = ((int)0x9111),
        MaxShaderStorageBufferBindings,
        MaxTessControlAtomicCounters,
        MaxTessEvaluationAtomicCounters,
        MaxTessControlShaderStorageBlocks,
        MaxTessEvaluationShaderStorageBlocks,
        MaxTextureBufferSize = ((int)0x8C2B),
        MaxTextureImageUnits = ((int)0x8872),
        MaxTextureLodBias = ((int)0x84FD),
        MaxTextureSize = ((int)0x0D33),
        MaxUniformBlockSize = ((int)0x8A30),
        MaxUniformBufferBindings = ((int)0x8A2F),
        MaxUniformLocations = ((int)0x826E),
        MaxVaryingComponents = ((int)0x8B4B),
        MaxVaryingVectors = ((int)0x8DFC),
        MaxVaryingFloats = ((int)0x8B4B),
        MaxVertexAtomicCounters = ((int)0x92D2),
        MaxVertexAttribs = ((int)0x8869),
        MaxVertexShaderStorageBlocks = ((int)0x90D6),
        MaxVertexTextureImageUnits = ((int)0x8B4C),
        MaxVertexUniformComponents = ((int)0x8B4A),
        MaxVertexUniformVectors = ((int)0x8DFB),
        MaxVertexOutputComponents = ((int)0x9122),
        MaxVertexUniformBlocks = ((int)0x8A2B),
        MaxViewportDims = ((int)0x0D3A),
        MaxViewports = ((int)0x825B),
        MinorVersion = ((int)0x821C),
        NumCompressedTextureFormats = ((int)0x86A2),
        NumExtensions = ((int)0x821D),
        NumProgramBinaryFormats = ((int)0x87FE),
        NumShaderBinaryFormats = ((int)0x8DF9),
        PackAlignment = ((int)0x0D05),
        PackImageHeight = ((int)0x806C),
        [Obsolete("Use PackImageHeight instead.")]
        PackImageHeightExt = ((int)0x806C),
        PackLsbFirst = ((int)0x0D01),
        PackRowLength = ((int)0x0D02),
        PackSkipImages = ((int)0x806B),
        [Obsolete("Use PackSkipImages instead.")]
        PackSkipImagesExt = ((int)0x806B),
        PackSkipPixels = ((int)0x0D04),
        PackSkipRows = ((int)0x0D03),
        PackSwapBytes = ((int)0x0D00),
        PixelPackBufferBinding = ((int)0x88ED),
        PixelUnpackBufferBinding = ((int)0x88EF),
        PointFadeThresholdSize = ((int)0x8128),
        PrimitiveRestartIndex = ((int)0x8F9E),
        ProgramBinaryFormats = ((int)0x87FF),
        ProgramPipelineBinding = ((int)0x825A),
        ProgramPointSize = ((int)0x8642),
        ProvokingVertex = ((int)0x8E4F),
        PointSize = ((int)0x0B11),
        PointSizeGranularity = ((int)0x0B13),
        PointSizeRange = ((int)0x0B12),
        PolygonOffsetFactor = ((int)0x8038),
        PolygonOffsetFill = ((int)0x8037),
        PolygonOffsetLine = ((int)0x2A02),
        PolygonOffsetPoint = ((int)0x2A01),
        PolygonOffsetUnits = ((int)0x2A00),
        PolygonSmooth = ((int)0x0B41),
        PolygonSmoothHint = ((int)0x0C53),
        ReadBuffer = ((int)0x0C02),
        RenderbufferBinding = ((int)0x8CA7),
        SampleBuffers = ((int)0x80A8),
        SampleCoverageInvert = ((int)0x80AB),
        SampleCoverageValue = ((int)0x80AA),
        SamplerBinding = ((int)0x8919),
        Samples = ((int)0x80A9),
        ScissorBox = ((int)0x0C10),
        ScissorTest = ((int)0x0C11),
        ShaderCompiler = ((int)0x8DFA),
        ShaderStorageBufferBinding = ((int)0x90D3),
        ShaderStorageBufferOffsetAlignment = ((int)0x90DF),
        ShaderStorageBufferStart = ((int)0x90D4),
        ShaderStorageBufferSize = ((int)0x90D5),
        SmoothLineWidthGranularity = ((int)0x0B23),
        SmoothLineWidthRange = ((int)0x0B22),
        SmoothPointSizeGranularity = ((int)0x0B13),
        SmoothPointSizeRange = ((int)0x0B12),
        StencilBackFail = ((int)0x8801),
        StencilBackPassDepthFail = ((int)0x8802),
        StencilBackPassDepthPass = ((int)0x8803),
        StencilBackRef = ((int)0x8CA3),
        StencilBackValueMask = ((int)0x8CA4),
        StencilBackWritemask = ((int)0x8CA5),
        StencilClearValue = ((int)0x0B91),
        StencilFail = ((int)0x0B94),
        StencilFunc = ((int)0x0B92),
        StencilPassDepthFail = ((int)0x0B95),
        StencilPassDepthPass = ((int)0x0B96),
        StencilRef = ((int)0x0B97),
        StencilTest = ((int)0x0B90),
        StencilValueMask = ((int)0x0B93),
        StencilWritemask = ((int)0x0B98),
        Stereo = ((int)0x0C33),
        SubpixelBits = ((int)0x0D50),
        TextureBinding1D = ((int)0x8068),
        TextureBinding1DArray = ((int)0x8C1C),
        TextureBinding2D = ((int)0x8069),
        TextureBinding2DArray = ((int)0x8C1D),
        TextureBinding2DMultisample = ((int)0x9104),
        TextureBinding2DMultisampleArray = ((int)0x9105),
        TextureBinding3D = ((int)0x806A),
        TextureBindingBuffer = ((int)0x8C2C),
        TextureBindingCubeMap = ((int)0x8514),
        TextureBindingRectangle = ((int)0x84F6),
        TextureCompressionHint = ((int)0x84EF),
        TextureBufferOffsetAlignment = ((int)0x919F),
        Timestamp = ((int)0x8E28),
        TransformFeedbackBufferBinding = ((int)0x8C8F),
        TransformFeedbackBufferStart = ((int)0x8C84),
        TransformFeedbackBufferSize = ((int)0x8C85),
        UniformBufferBinding = ((int)0x8A28),
        UniformBufferOffsetAlignment = ((int)0x8A34),
        UniformBufferStart = ((int)0x8A29),
        UniformBufferSize = ((int)0x8A2A),
        UnpackAlignment = ((int)0x0CF5),
        UnpackImageHeight = ((int)0x806E),
        [Obsolete("Use UnpackImageHeight instead.")]
        UnpackImageHeightExt = ((int)0x806E),
        UnpackLsbFirst = ((int)0x0CF1),
        UnpackRowLength = ((int)0x0CF2),
        UnpackSkipImages = ((int)0x806D),
        [Obsolete("Use UnpackSkipImages instead.")]
        UnpackSkipImagesExt = ((int)0x806D),
        UnpackSkipPixels = ((int)0x0CF4),
        UnpackSkipRows = ((int)0x0CF3),
        UnpackSwapBytes = ((int)0x0CF0),
        VertexArrayBinding = ((int)0x85B5),
        VertexBindingDivisor = ((int)0x82D6),
        VertexBindingOffset = ((int)0x82D7),
        VertexBindingStride = ((int)0x82D8),
        MaxVertexAttribRelativeOffset = ((int)0x82D9),
        MaxVertexAttribBindings = ((int)0x82DA),
        Viewport = ((int)0x0BA2),
        ViewportBoundsRange = ((int)0x825D),
        ViewportIndexProvokingVertex = ((int)0x825F),
        ViewportSubpixelBits = ((int)0x825C),
        MaxElementIndex = ((int)0x8D6B)
    }

    public enum GetPointerParameter : int
    {
        DebugCallbackFunction = ((int)0x8244),
        DebugCallbackUserParam = ((int)0x8245)
    }

    public enum GetQueryObjectParam : int
    {
        QueryResult = ((int)0x8866),
        QueryResultAvailable = ((int)0x8867),
    }

    public enum GetQueryParam : int
    {
        QueryCounterBits = ((int)0x8864),
        CurrentQuery = ((int)0x8865),
    }

    public enum GetTextureParameter : int
    {
        TextureWidth = ((int)0x1000),
        TextureHeight = ((int)0x1001),
        TextureComponents = ((int)0x1003),
        TextureInternalFormat = ((int)0x1003),
        TextureBorderColor = ((int)0x1004),
        TextureBorder = ((int)0x1005),
        TextureMagFilter = ((int)0x2800),
        TextureMinFilter = ((int)0x2801),
        TextureWrapS = ((int)0x2802),
        TextureWrapT = ((int)0x2803),
        TextureRedSize = ((int)0x805C),
        TextureGreenSize = ((int)0x805D),
        TextureBlueSize = ((int)0x805E),
        TextureAlphaSize = ((int)0x805F),
        TextureLuminanceSize = ((int)0x8060),
        TextureIntensitySize = ((int)0x8061),
        TexturePriority = ((int)0x8066),
        TextureResident = ((int)0x8067),
        TextureDepth = ((int)0x8071),
        TextureDepthExt = ((int)0x8071),
        TextureWrapR = ((int)0x8072),
        TextureWrapRExt = ((int)0x8072),
        DetailTextureLevelSgis = ((int)0x809A),
        DetailTextureModeSgis = ((int)0x809B),
        DetailTextureFuncPointsSgis = ((int)0x809C),
        SharpenTextureFuncPointsSgis = ((int)0x80B0),
        ShadowAmbientSgix = ((int)0x80BF),
        DualTextureSelectSgis = ((int)0x8124),
        QuadTextureSelectSgis = ((int)0x8125),
        Texture4DsizeSgis = ((int)0x8136),
        TextureWrapQSgis = ((int)0x8137),
        TextureMinLod = ((int)0x813A),
        TextureMinLodSgis = ((int)0x813A),
        TextureMaxLod = ((int)0x813B),
        TextureMaxLodSgis = ((int)0x813B),
        TextureBaseLevel = ((int)0x813C),
        TextureBaseLevelSgis = ((int)0x813C),
        TextureMaxLevel = ((int)0x813D),
        TextureMaxLevelSgis = ((int)0x813D),
        TextureFilter4SizeSgis = ((int)0x8147),
        TextureClipmapCenterSgix = ((int)0x8171),
        TextureClipmapFrameSgix = ((int)0x8172),
        TextureClipmapOffsetSgix = ((int)0x8173),
        TextureClipmapVirtualDepthSgix = ((int)0x8174),
        TextureClipmapLodOffsetSgix = ((int)0x8175),
        TextureClipmapDepthSgix = ((int)0x8176),
        PostTextureFilterBiasSgix = ((int)0x8179),
        PostTextureFilterScaleSgix = ((int)0x817A),
        TextureLodBiasSSgix = ((int)0x818E),
        TextureLodBiasTSgix = ((int)0x818F),
        TextureLodBiasRSgix = ((int)0x8190),
        GenerateMipmap = ((int)0x8191),
        GenerateMipmapSgis = ((int)0x8191),
        TextureCompareSgix = ((int)0x819A),
        TextureCompareOperatorSgix = ((int)0x819B),
        TextureLequalRSgix = ((int)0x819C),
        TextureGequalRSgix = ((int)0x819D),
        TextureMaxClampSSgix = ((int)0x8369),
        TextureMaxClampTSgix = ((int)0x836A),
        TextureMaxClampRSgix = ((int)0x836B),
        TextureCompressedImageSize = ((int)0x86A0),
        TextureCompressed = ((int)0x86A1),
        TextureDepthSize = ((int)0x884A),
        DepthTextureMode = ((int)0x884B),
        TextureCompareMode = ((int)0x884C),
        TextureCompareFunc = ((int)0x884D),
        TextureStencilSize = ((int)0x88F1),
        TextureRedType = ((int)0x8C10),
        TextureGreenType = ((int)0x8C11),
        TextureBlueType = ((int)0x8C12),
        TextureAlphaType = ((int)0x8C13),
        TextureLuminanceType = ((int)0x8C14),
        TextureIntensityType = ((int)0x8C15),
        TextureDepthType = ((int)0x8C16),
        TextureSharedSize = ((int)0x8C3F),
        TextureSamples = ((int)0x9106),
        TextureFixedSampleLocations = ((int)0x9107),
        TextureBufferOffset = ((int)0x919D)
    }

    public enum GetTextureLevelParameter : int
    {
        TextureWidth = ((int)0x1000),
        TextureHeight = ((int)0x1001),
        TextureDepth = ((int)0x8071),
        TextureInternalFormat = ((int)0x1003),
        TextureRedSize = ((int)0x805C),
        TextureGreenSize = ((int)0x805D),
        TextureBlueSize = ((int)0x805E),
        TextureAlphaSize = ((int)0x805F),
        TextureDepthSize = ((int)0x884A),
        TextureCompressed = ((int)0x86A1),
        TextureCompressedImageSize = ((int)0x86A0),
        TextureBufferOffset = ((int)0x919D)
    }

    public enum GraphicResetStatus : int
    {
        NoError = ((int)0),
        GuiltyContextReset = ((int)0x8253),
        InnocentContextReset = ((int)0x8254),
        UnknownContextReset = ((int)0x8255)
    }

    public enum HintMode : int
    {
        DontCare = ((int)0x1100),
        Fastest = ((int)0x1101),
        Nicest = ((int)0x1102),
    }

    public enum HintTarget : int
    {
        PerspectiveCorrectionHint = ((int)0x0C50),
        PointSmoothHint = ((int)0x0C51),
        LineSmoothHint = ((int)0x0C52),
        PolygonSmoothHint = ((int)0x0C53),
        FogHint = ((int)0x0C54),
        PackCmykHintExt = ((int)0x800E),
        UnpackCmykHintExt = ((int)0x800F),
        TextureMultiBufferHintSgix = ((int)0x812E),
        GenerateMipmapHint = ((int)0x8192),
        GenerateMipmapHintSgis = ((int)0x8192),
        ConvolutionHintSgix = ((int)0x8316),
        VertexPreclipHintSgix = ((int)0x83EF),
        TextureCompressionHint = ((int)0x84EF),
        FragmentShaderDerivativeHint = ((int)0x8B8B),
    }

    public enum LogicOp : int
    {
        Clear = ((int)0x1500),
        And = ((int)0x1501),
        AndReverse = ((int)0x1502),
        Copy = ((int)0x1503),
        AndInverted = ((int)0x1504),
        Noop = ((int)0x1505),
        Xor = ((int)0x1506),
        Or = ((int)0x1507),
        Nor = ((int)0x1508),
        Equiv = ((int)0x1509),
        Invert = ((int)0x150A),
        OrReverse = ((int)0x150B),
        CopyInverted = ((int)0x150C),
        OrInverted = ((int)0x150D),
        Nand = ((int)0x150E),
        Set = ((int)0x150F),
    }

    public enum MaterialFace : int
    {
        Front = ((int)0x0404),
        Back = ((int)0x0405),
        FrontAndBack = ((int)0x0408),
    }

    public enum NvTransformFeedback2 : int
    {
        TransformFeedbackNv = ((int)0x8E22),
        TransformFeedbackBufferPausedNv = ((int)0x8E23),
        TransformFeedbackBufferActiveNv = ((int)0x8E24),
        TransformFeedbackBindingNv = ((int)0x8E25),
    }

    public enum ObjectLabel : int
    {
        Buffer = ((int)0x82E0),
        Shader = ((int)0x82E1),
        Program = ((int)0x82E2),
        VertexArray = ((int)0x8074),
        Query = ((int)0x82E3),
        ProgramPipeline = ((int)0x82E4),
        TransformFeedback = ((int)0x8E22),
        Sampler = ((int)0x82E6),
        Texture = ((int)0x1702),
        RenderBuffer = ((int)0x8D41),
        FrameBuffer = ((int)0x8D40)
    }

    public enum PixelFormat : int
    {
        ColorIndex = ((int)0x1900),
        StencilIndex = ((int)0x1901),
        DepthComponent = ((int)0x1902),
        Red = ((int)0x1903),
        Green = ((int)0x1904),
        Blue = ((int)0x1905),
        Alpha = ((int)0x1906),
        Rgb = ((int)0x1907),
        Rgba = ((int)0x1908),
        Luminance = ((int)0x1909),
        LuminanceAlpha = ((int)0x190A),
        AbgrExt = ((int)0x8000),
        CmykExt = ((int)0x800C),
        CmykaExt = ((int)0x800D),
        Bgr = ((int)0x80E0),
        Bgra = ((int)0x80E1),
        Ycrcb422Sgix = ((int)0x81BB),
        Ycrcb444Sgix = ((int)0x81BC),
        Rg = ((int)0x8227),
        RgInteger = ((int)0x8228),
        DepthStencil = ((int)0x84F9),
        RedInteger = ((int)0x8D94),
        GreenInteger = ((int)0x8D95),
        BlueInteger = ((int)0x8D96),
        AlphaInteger = ((int)0x8D97),
        RgbInteger = ((int)0x8D98),
        RgbaInteger = ((int)0x8D99),
        BgrInteger = ((int)0x8D9A),
        BgraInteger = ((int)0x8D9B),
    }

    public enum PixelInternalFormat : int
    {
        DepthComponent = ((int)0x1902),
        Alpha = ((int)0x1906),
        Rgb = ((int)0x1907),
        Rgba = ((int)0x1908),
        Luminance = ((int)0x1909),
        LuminanceAlpha = ((int)0x190A),
        R3G3B2 = ((int)0x2A10),
        Alpha4 = ((int)0x803B),
        Alpha8 = ((int)0x803C),
        Alpha12 = ((int)0x803D),
        Alpha16 = ((int)0x803E),
        Luminance4 = ((int)0x803F),
        Luminance8 = ((int)0x8040),
        Luminance12 = ((int)0x8041),
        Luminance16 = ((int)0x8042),
        Luminance4Alpha4 = ((int)0x8043),
        Luminance6Alpha2 = ((int)0x8044),
        Luminance8Alpha8 = ((int)0x8045),
        Luminance12Alpha4 = ((int)0x8046),
        Luminance12Alpha12 = ((int)0x8047),
        Luminance16Alpha16 = ((int)0x8048),
        Intensity = ((int)0x8049),
        Intensity4 = ((int)0x804A),
        Intensity8 = ((int)0x804B),
        Intensity12 = ((int)0x804C),
        Intensity16 = ((int)0x804D),
        Rgb2Ext = ((int)0x804E),
        Rgb4 = ((int)0x804F),
        Rgb5 = ((int)0x8050),
        Rgb8 = ((int)0x8051),
        Rgb10 = ((int)0x8052),
        Rgb12 = ((int)0x8053),
        Rgb16 = ((int)0x8054),
        Rgba2 = ((int)0x8055),
        Rgba4 = ((int)0x8056),
        Rgb5A1 = ((int)0x8057),
        Rgba8 = ((int)0x8058),
        Rgb10A2 = ((int)0x8059),
        Rgba12 = ((int)0x805A),
        Rgba16 = ((int)0x805B),
        DualAlpha4Sgis = ((int)0x8110),
        DualAlpha8Sgis = ((int)0x8111),
        DualAlpha12Sgis = ((int)0x8112),
        DualAlpha16Sgis = ((int)0x8113),
        DualLuminance4Sgis = ((int)0x8114),
        DualLuminance8Sgis = ((int)0x8115),
        DualLuminance12Sgis = ((int)0x8116),
        DualLuminance16Sgis = ((int)0x8117),
        DualIntensity4Sgis = ((int)0x8118),
        DualIntensity8Sgis = ((int)0x8119),
        DualIntensity12Sgis = ((int)0x811A),
        DualIntensity16Sgis = ((int)0x811B),
        DualLuminanceAlpha4Sgis = ((int)0x811C),
        DualLuminanceAlpha8Sgis = ((int)0x811D),
        QuadAlpha4Sgis = ((int)0x811E),
        QuadAlpha8Sgis = ((int)0x811F),
        QuadLuminance4Sgis = ((int)0x8120),
        QuadLuminance8Sgis = ((int)0x8121),
        QuadIntensity4Sgis = ((int)0x8122),
        QuadIntensity8Sgis = ((int)0x8123),
        DepthComponent16 = ((int)0x81a5),
        DepthComponent16Sgix = ((int)0x81A5),
        DepthComponent24 = ((int)0x81a6),
        DepthComponent24Sgix = ((int)0x81A6),
        DepthComponent32 = ((int)0x81a7),
        DepthComponent32Sgix = ((int)0x81A7),
        CompressedRed = ((int)0x8225),
        CompressedRg = ((int)0x8226),
        R8 = ((int)0x8229),
        R16 = ((int)0x822A),
        Rg8 = ((int)0x822B),
        Rg16 = ((int)0x822C),
        R16f = ((int)0x822D),
        R32f = ((int)0x822E),
        Rg16f = ((int)0x822F),
        Rg32f = ((int)0x8230),
        R8i = ((int)0x8231),
        R8ui = ((int)0x8232),
        R16i = ((int)0x8233),
        R16ui = ((int)0x8234),
        R32i = ((int)0x8235),
        R32ui = ((int)0x8236),
        Rg8i = ((int)0x8237),
        Rg8ui = ((int)0x8238),
        Rg16i = ((int)0x8239),
        Rg16ui = ((int)0x823A),
        Rg32i = ((int)0x823B),
        Rg32ui = ((int)0x823C),
        CompressedRgbS3tcDxt1Ext = ((int)0x83F0),
        CompressedRgbaS3tcDxt1Ext = ((int)0x83F1),
        CompressedRgbaS3tcDxt3Ext = ((int)0x83F2),
        CompressedRgbaS3tcDxt5Ext = ((int)0x83F3),
        CompressedAlpha = ((int)0x84E9),
        CompressedLuminance = ((int)0x84EA),
        CompressedLuminanceAlpha = ((int)0x84EB),
        CompressedIntensity = ((int)0x84EC),
        CompressedRgb = ((int)0x84ED),
        CompressedRgba = ((int)0x84EE),
        DepthStencil = ((int)0x84F9),
        Rgba32f = ((int)0x8814),
        Rgb32f = ((int)0x8815),
        Rgba16f = ((int)0x881A),
        Rgb16f = ((int)0x881B),
        Depth24Stencil8 = ((int)0x88F0),
        R11fG11fB10f = ((int)0x8C3A),
        Rgb9E5 = ((int)0x8C3D),
        Srgb = ((int)0x8C40),
        Srgb8 = ((int)0x8C41),
        SrgbAlpha = ((int)0x8C42),
        Srgb8Alpha8 = ((int)0x8C43),
        SluminanceAlpha = ((int)0x8C44),
        Sluminance8Alpha8 = ((int)0x8C45),
        Sluminance = ((int)0x8C46),
        Sluminance8 = ((int)0x8C47),
        CompressedSrgb = ((int)0x8C48),
        CompressedSrgbAlpha = ((int)0x8C49),
        CompressedSluminance = ((int)0x8C4A),
        CompressedSluminanceAlpha = ((int)0x8C4B),
        CompressedSrgbS3tcDxt1Ext = ((int)0x8C4C),
        CompressedSrgbAlphaS3tcDxt1Ext = ((int)0x8C4D),
        CompressedSrgbAlphaS3tcDxt3Ext = ((int)0x8C4E),
        CompressedSrgbAlphaS3tcDxt5Ext = ((int)0x8C4F),
        DepthComponent32f = ((int)0x8CAC),
        Depth32fStencil8 = ((int)0x8CAD),
        Rgba32ui = ((int)0x8D70),
        Rgb32ui = ((int)0x8D71),
        Rgba16ui = ((int)0x8D76),
        Rgb16ui = ((int)0x8D77),
        Rgba8ui = ((int)0x8D7C),
        Rgb8ui = ((int)0x8D7D),
        Rgba32i = ((int)0x8D82),
        Rgb32i = ((int)0x8D83),
        Rgba16i = ((int)0x8D88),
        Rgb16i = ((int)0x8D89),
        Rgba8i = ((int)0x8D8E),
        Rgb8i = ((int)0x8D8F),
        Float32UnsignedInt248Rev = ((int)0x8DAD),
        CompressedRedRgtc1 = ((int)0x8DBB),
        CompressedSignedRedRgtc1 = ((int)0x8DBC),
        CompressedRgRgtc2 = ((int)0x8DBD),
        CompressedSignedRgRgtc2 = ((int)0x8DBE),
        One = ((int)1),
        Two = ((int)2),
        Three = ((int)3),
        Four = ((int)4),
    }

    public enum PixelStoreParameter : int
    {
        UnpackSwapBytes = ((int)0x0CF0),
        UnpackLsbFirst = ((int)0x0CF1),
        UnpackRowLength = ((int)0x0CF2),
        UnpackSkipRows = ((int)0x0CF3),
        UnpackSkipPixels = ((int)0x0CF4),
        UnpackAlignment = ((int)0x0CF5),
        PackSwapBytes = ((int)0x0D00),
        PackLsbFirst = ((int)0x0D01),
        PackRowLength = ((int)0x0D02),
        PackSkipRows = ((int)0x0D03),
        PackSkipPixels = ((int)0x0D04),
        PackAlignment = ((int)0x0D05),
        PackSkipImages = ((int)0x806B),
        PackSkipImagesExt = ((int)0x806B),
        PackImageHeight = ((int)0x806C),
        PackImageHeightExt = ((int)0x806C),
        UnpackSkipImages = ((int)0x806D),
        UnpackSkipImagesExt = ((int)0x806D),
        UnpackImageHeight = ((int)0x806E),
        UnpackImageHeightExt = ((int)0x806E),
        PackSkipVolumesSgis = ((int)0x8130),
        PackImageDepthSgis = ((int)0x8131),
        UnpackSkipVolumesSgis = ((int)0x8132),
        UnpackImageDepthSgis = ((int)0x8133),
        PixelTileWidthSgix = ((int)0x8140),
        PixelTileHeightSgix = ((int)0x8141),
        PixelTileGridWidthSgix = ((int)0x8142),
        PixelTileGridHeightSgix = ((int)0x8143),
        PixelTileGridDepthSgix = ((int)0x8144),
        PixelTileCacheSizeSgix = ((int)0x8145),
        PackResampleSgix = ((int)0x842C),
        UnpackResampleSgix = ((int)0x842D),
        PackSubsampleRateSgix = ((int)0x85A0),
        UnpackSubsampleRateSgix = ((int)0x85A1),
    }

    public enum PixelType : int
    {
        Byte = ((int)0x1400),
        UnsignedByte = ((int)0x1401),
        Short = ((int)0x1402),
        UnsignedShort = ((int)0x1403),
        Int = ((int)0x1404),
        UnsignedInt = ((int)0x1405),
        Float = ((int)0x1406),
        HalfFloat = ((int)0x140B),
        Bitmap = ((int)0x1A00),
        UnsignedByte332 = ((int)0x8032),
        UnsignedByte332Ext = ((int)0x8032),
        UnsignedShort4444 = ((int)0x8033),
        UnsignedShort4444Ext = ((int)0x8033),
        UnsignedShort5551 = ((int)0x8034),
        UnsignedShort5551Ext = ((int)0x8034),
        UnsignedInt8888 = ((int)0x8035),
        UnsignedInt8888Ext = ((int)0x8035),
        UnsignedInt1010102 = ((int)0x8036),
        UnsignedInt1010102Ext = ((int)0x8036),
        UnsignedByte233Reversed = ((int)0x8362),
        UnsignedShort565 = ((int)0x8363),
        UnsignedShort565Reversed = ((int)0x8364),
        UnsignedShort4444Reversed = ((int)0x8365),
        UnsignedShort1555Reversed = ((int)0x8366),
        UnsignedInt8888Reversed = ((int)0x8367),
        UnsignedInt2101010Reversed = ((int)0x8368),
        UnsignedInt248 = ((int)0x84FA),
        UnsignedInt10F11F11FRev = ((int)0x8C3B),
        UnsignedInt5999Rev = ((int)0x8C3E),
        Float32UnsignedInt248Rev = ((int)0x8DAD),
    }

    public enum PointParameterName : int
    {
        PointSizeMin = ((int)0x8126),
        PointSizeMax = ((int)0x8127),
        PointFadeThresholdSize = ((int)0x8128),
        PointDistanceAttenuation = ((int)0x8129),
        PointSpriteCoordOrigin = ((int)0x8CA0),
    }

    public enum PolygonMode : int
    {
        Point = ((int)0x1B00),
        Line = ((int)0x1B01),
        Fill = ((int)0x1B02),
    }

    public enum ProgramInterface : int
    {
        Uniform = ((int)0x92E1),
        UniformBlock = ((int)0x92E2),
        AtomicCounterBuffer = ((int)0x92C0),
        ProgramInput = ((int)0x92E3),
        ProgramOutput = ((int)0x92E4),
        VertexSubroutine = ((int)0x92E8),
        TessControlSubroutine = ((int)0x92E9),
        TessEvaluationSubroutine = ((int)0x92EA),
        GeometrySubroutine = ((int)0x92EB),
        FragmentSubroutine = ((int)0x92EC),
        ComputeSubroutine = ((int)0x92ED),
        VertexSubroutineUniform = ((int)0x92EE),
        TessControlSubroutineUniform = ((int)0x92EF),
        TessEvaluationSubroutineUniform = ((int)0x92F0),
        GeometrySubroutineUniform = ((int)0x92F1),
        FragmentSubroutineUniform = ((int)0x92F2),
        ComputeSubroutineUniform = ((int)0x92F3),
        TransformFeedbackVarying = ((int)0x92F4),
        BufferVariable = ((int)0x92E5),
        ShaderStorageBlock = ((int)0x92E6),
        TransformFeedbackBuffer = ((int)0x8C8E)
    }

    public enum ProgramInterfaceParameterName : int
    {
        ActiveResources = ((int)0x92F5),
        MaxNameLength = ((int)0x92F6),
        MaxNumActiveVariables = ((int)0x92F7),
        MaxNumCompatibleSubroutines = ((int)0x92F8)
    }

    public enum ProgramParameter : int
    {
        ActiveUniformBlockMaxNameLength = ((int)0x8A35),
        ActiveUniformBlocks = ((int)0x8A36),
        DeleteStatus = ((int)0x8B80),
        LinkStatus = ((int)0x8B82),
        ValidateStatus = ((int)0x8B83),
        InfoLogLength = ((int)0x8B84),
        AttachedShaders = ((int)0x8B85),
        ActiveUniforms = ((int)0x8B86),
        ActiveUniformMaxLength = ((int)0x8B87),
        ActiveAttributes = ((int)0x8B89),
        ActiveAttributeMaxLength = ((int)0x8B8A),
        TransformFeedbackVaryingMaxLength = ((int)0x8C76),
        TransformFeedbackBufferMode = ((int)0x8C7F),
        TransformFeedbackVaryings = ((int)0x8C83),
        GeometryVerticesOut = ((int)0x8DDA),
        GeometryInputType = ((int)0x8DDB),
        GeometryOutputType = ((int)0x8DDC),
    }

    public enum ProgramResourceParameterName : int
    {
        NameLength = ((int)0x92F9),
        Type = ((int)0x92FA),
        ArraySize = ((int)0x92FB),
        Offset = ((int)0x92FC),
        BlockIndex = ((int)0x92FD),
        ArrayStride = ((int)0x92FE),
        MatrixStride = ((int)0x92FF),
        IsRowMajor = ((int)0x9300),
        AtomicCounterBufferIndex = ((int)0x9301),
        TextureBuffer = ((int)0x8C2A),
        BufferBinding = ((int)0x9302),
        BufferDataSize = ((int)0x9303),
        NumActiveVariables = ((int)0x9304),
        ActiveVariables = ((int)0x9305),
        ReferencedByVertexShader = ((int)0x9306),
        ReferencedByTessControlShader = ((int)0x9307),
        ReferencedByTessEvaluationShader = ((int)0x9308),
        ReferencedByGeometryShader = ((int)0x9309),
        ReferencedByFragmentShader = ((int)0x930A),
        ReferencedByComputeShader = ((int)0x930B),
        NumCompatibleSubroutines = ((int)0x8E4A),
        CompatibleSubroutines = ((int)0x8E4B),
        TopLevelArraySize = ((int)0x930C),
        TopLevelArrayStride = ((int)0x930D),
        Location = ((int)0x930E),
        LocationIndex = ((int)0x930F),
        IsPerPatch = ((int)0x92E7),
        LocationComponent = ((int)0x934A),
        TransformFeedbackBufferIndex = ((int)0x934B),
        TransformFeedbackBufferStride = ((int)0x934C)
    }

    public enum ProgramStageParameterName : int
    {
        ActiveSubroutineUniforms = ((int)0x8DE6),
        ActiveSubroutineUniformLocations = ((int)0x8E47),
        ActiveSubroutines = ((int)0x8DE5),
        ActiveSubroutineUniformMaxLength = ((int)0x8E49),
        ActiveSubroutineMaxLength = ((int)0x8E48)
    }

    public enum ProvokingVertexMode : int
    {
        FirstVertexConvention = ((int)0x8E4D),
        LastVertexConvention = ((int)0x8E4E),
    }

    public enum QueryTarget : int
    {
        SamplesPassed = ((int)0x8914),
        PrimitivesGenerated = ((int)0x8C87),
        TransformFeedbackPrimitivesWritten = ((int)0x8C88),
        AnySamplesPassed = ((int)0x8C2F),
        AnySamplesPassedConservative = ((int)0x8D6A),
        TimeElapsed = ((int)0x88BF),
        TimeStamp = ((int)0x8E28),
    }

    public enum ReadBufferMode : int
    {
        None = ((int)0x0000),
        FrontLeft = ((int)0x0400),
        FrontRight = ((int)0x0401),
        BackLeft = ((int)0x0402),
        BackRight = ((int)0x0403),
        Front = ((int)0x0404),
        Back = ((int)0x0405),
        Left = ((int)0x0406),
        Right = ((int)0x0407),
        Aux0 = ((int)0x0409),
        Aux1 = ((int)0x040A),
        Aux2 = ((int)0x040B),
        Aux3 = ((int)0x040C),
        ColorAttachment0 = ((int)0x8CE0),
        ColorAttachment1 = ((int)0x8CE1),
        ColorAttachment2 = ((int)0x8CE2),
        ColorAttachment3 = ((int)0x8CE3),
        ColorAttachment4 = ((int)0x8CE4),
        ColorAttachment5 = ((int)0x8CE5),
        ColorAttachment6 = ((int)0x8CE6),
        ColorAttachment7 = ((int)0x8CE7),
        ColorAttachment8 = ((int)0x8CE8),
        ColorAttachment9 = ((int)0x8CE9),
        ColorAttachment10 = ((int)0x8CEA),
        ColorAttachment11 = ((int)0x8CEB),
        ColorAttachment12 = ((int)0x8CEC),
        ColorAttachment13 = ((int)0x8CED),
        ColorAttachment14 = ((int)0x8CEE),
        ColorAttachment15 = ((int)0x8CEF),
    }

    public enum RenderbufferParameterName : int
    {
        RenderbufferSamples = ((int)0x8CAB),
        RenderbufferWidth = ((int)0x8D42),
        RenderbufferWidthExt = ((int)0x8D42),
        RenderbufferHeight = ((int)0x8D43),
        RenderbufferHeightExt = ((int)0x8D43),
        RenderbufferInternalFormat = ((int)0x8D44),
        RenderbufferInternalFormatExt = ((int)0x8D44),
        RenderbufferRedSize = ((int)0x8D50),
        RenderbufferRedSizeExt = ((int)0x8D50),
        RenderbufferGreenSize = ((int)0x8D51),
        RenderbufferGreenSizeExt = ((int)0x8D51),
        RenderbufferBlueSize = ((int)0x8D52),
        RenderbufferBlueSizeExt = ((int)0x8D52),
        RenderbufferAlphaSize = ((int)0x8D53),
        RenderbufferAlphaSizeExt = ((int)0x8D53),
        RenderbufferDepthSize = ((int)0x8D54),
        RenderbufferDepthSizeExt = ((int)0x8D54),
        RenderbufferStencilSize = ((int)0x8D55),
        RenderbufferStencilSizeExt = ((int)0x8D55),
    }

    public enum RenderbufferStorage : int
    {
        R3G3B2 = ((int)0x2A10),
        Alpha4 = ((int)0x803B),
        Alpha8 = ((int)0x803C),
        Alpha12 = ((int)0x803D),
        Alpha16 = ((int)0x803E),
        Rgb4 = ((int)0x804F),
        Rgb5 = ((int)0x8050),
        Rgb8 = ((int)0x8051),
        Rgb10 = ((int)0x8052),
        Rgb12 = ((int)0x8053),
        Rgb16 = ((int)0x8054),
        Rgba2 = ((int)0x8055),
        Rgba4 = ((int)0x8056),
        Rgba8 = ((int)0x8058),
        Rgb10A2 = ((int)0x8059),
        Rgba12 = ((int)0x805A),
        Rgba16 = ((int)0x805B),
        DepthComponent16 = ((int)0x81a5),
        DepthComponent24 = ((int)0x81a6),
        DepthComponent32 = ((int)0x81a7),
        R8 = ((int)0x8229),
        R16 = ((int)0x822A),
        Rg8 = ((int)0x822B),
        Rg16 = ((int)0x822C),
        R16f = ((int)0x822D),
        R32f = ((int)0x822E),
        Rg16f = ((int)0x822F),
        Rg32f = ((int)0x8230),
        R8i = ((int)0x8231),
        R8ui = ((int)0x8232),
        R16i = ((int)0x8233),
        R16ui = ((int)0x8234),
        R32i = ((int)0x8235),
        R32ui = ((int)0x8236),
        Rg8i = ((int)0x8237),
        Rg8ui = ((int)0x8238),
        Rg16i = ((int)0x8239),
        Rg16ui = ((int)0x823A),
        Rg32i = ((int)0x823B),
        Rg32ui = ((int)0x823C),
        Rgba32f = ((int)0x8814),
        Rgb32f = ((int)0x8815),
        Rgba16f = ((int)0x881A),
        Rgb16f = ((int)0x881B),
        Depth24Stencil8 = ((int)0x88F0),
        R11fG11fB10f = ((int)0x8C3A),
        Rgb9E5 = ((int)0x8C3D),
        Srgb8 = ((int)0x8C41),
        Srgb8Alpha8 = ((int)0x8C43),
        DepthComponent32f = ((int)0x8CAC),
        Depth32fStencil8 = ((int)0x8CAD),
        StencilIndex1 = ((int)0x8D46),
        StencilIndex1Ext = ((int)0x8D46),
        StencilIndex4 = ((int)0x8D47),
        StencilIndex4Ext = ((int)0x8D47),
        StencilIndex8 = ((int)0x8D48),
        StencilIndex8Ext = ((int)0x8D48),
        StencilIndex16 = ((int)0x8D49),
        StencilIndex16Ext = ((int)0x8D49),
        Rgba32ui = ((int)0x8D70),
        Rgb32ui = ((int)0x8D71),
        Rgba16ui = ((int)0x8D76),
        Rgb16ui = ((int)0x8D77),
        Rgba8ui = ((int)0x8D7C),
        Rgb8ui = ((int)0x8D7D),
        Rgba32i = ((int)0x8D82),
        Rgb32i = ((int)0x8D83),
        Rgba16i = ((int)0x8D88),
        Rgb16i = ((int)0x8D89),
        Rgba8i = ((int)0x8D8E),
        Rgb8i = ((int)0x8D8F),
    }

    public enum RenderbufferTarget : int
    {
        Renderbuffer = ((int)0x8D41),
        RenderbufferExt = ((int)0x8D41),
    }

    public enum ShaderParameter : int
    {
        ShaderType = ((int)0x8B4F),
        DeleteStatus = ((int)0x8B80),
        CompileStatus = ((int)0x8B81),
        InfoLogLength = ((int)0x8B84),
        ShaderSourceLength = ((int)0x8B88),
    }

    public enum ShaderType : int
    {
        FragmentShader = ((int)0x8B30),
        VertexShader = ((int)0x8B31),
        GeometryShader = ((int)0x8DD9),
        TessControlShader = ((int)0x8E88),
        TessEvaluationShader = ((int)0x8E87),
        ComputeShader = ((int)0x91B9)
    }

    public enum SizedInternalFormat : int
    {
        Rgba8 = ((int)0x8058),
        Rgba16 = ((int)0x805B),
        R8 = ((int)0x8229),
        R16 = ((int)0x822A),
        Rg8 = ((int)0x822B),
        Rg16 = ((int)0x822C),
        R16f = ((int)0x822D),
        R32f = ((int)0x822E),
        Rg16f = ((int)0x822F),
        Rg32f = ((int)0x8230),
        R8i = ((int)0x8231),
        R8ui = ((int)0x8232),
        R16i = ((int)0x8233),
        R16ui = ((int)0x8234),
        R32i = ((int)0x8235),
        R32ui = ((int)0x8236),
        Rg8i = ((int)0x8237),
        Rg8ui = ((int)0x8238),
        Rg16i = ((int)0x8239),
        Rg16ui = ((int)0x823A),
        Rg32i = ((int)0x823B),
        Rg32ui = ((int)0x823C),
        Rgba32f = ((int)0x8814),
        Rgba16f = ((int)0x881A),
        Rgba32ui = ((int)0x8D70),
        Rgba16ui = ((int)0x8D76),
        Rgba8ui = ((int)0x8D7C),
        Rgba32i = ((int)0x8D82),
        Rgba16i = ((int)0x8D88),
        Rgba8i = ((int)0x8D8E),
    }

    public enum StencilFace : int
    {
        Front = ((int)0x0404),
        Back = ((int)0x0405),
        FrontAndBack = ((int)0x0408),
    }

    public enum StencilFunction : int
    {
        Never = ((int)0x0200),
        Less = ((int)0x0201),
        Equal = ((int)0x0202),
        Lequal = ((int)0x0203),
        Greater = ((int)0x0204),
        Notequal = ((int)0x0205),
        Gequal = ((int)0x0206),
        Always = ((int)0x0207),
    }

    public enum StencilOp : int
    {
        Zero = ((int)0),
        Invert = ((int)0x150A),
        Keep = ((int)0x1E00),
        Replace = ((int)0x1E01),
        Incr = ((int)0x1E02),
        Decr = ((int)0x1E03),
        IncrWrap = ((int)0x8507),
        DecrWrap = ((int)0x8508),
    }

    public enum StringName : int
    {
        Vendor = ((int)0x1F00),
        Renderer = ((int)0x1F01),
        Version = ((int)0x1F02),
        Extensions = ((int)0x1F03),
        ShadingLanguageVersion = ((int)0x8B8C),
    }

    public enum SubroutineParameterName : int
    {
        NumCompatibleSubroutines = ((int)0x8E4A),
        CompatibleSubroutines = ((int)0x8E4B),
        UniformSize = ((int)0x8A38),
        UniformNameLength = ((int)0x8A39)
    }

    public enum TextureBufferTarget : int
    {
        TextureBuffer = ((int)0x8C2A),
    }

    public enum TextureParameter : int
    {
        Nearest = ((int)0x2600),
        Linear = ((int)0x2601),
        NearestMipMapNearest = ((int)0x2700),
        LinearMipMapNearest = ((int)0x2701),
        NearestMipMapLinear = ((int)0x2702),
        LinearMipMapLinear = ((int)0x2703),
        ClampToEdge = ((int)0x812F),
        ClampToBorder = ((int)0x812D),
        MirrorClampToEdge = ((int)0x8743),
        MirroredRepeat = ((int)0x8370),
        Repeat = ((int)0x2901),
        Red = ((int)0x1903),
        Green = ((int)0x1904),
        Blue = ((int)0x1905),
        Alpha = ((int)0x1906),
        Zero = ((int)0),
        One = ((int)1),
        CompareRefToTexture = ((int)0x884E),
        None = ((int)0),
        StencilIndex = ((int)0x1901),
        DepthComponent = ((int)0x1902)
    }

    public enum TextureParameterName : int
    {
        TextureBaseLevel = ((int)0x813C),
        TextureBorderColor = ((int)0x1004),
        TextureCompareMode = ((int)0x884C),
        TextureCompareFunc = ((int)0x884D),
        TextureLodBias = ((int)0x8501),
        TextureMagFilter = ((int)0x2800),
        TextureMaxLevel = ((int)0x813D),
        TextureMaxLod = ((int)0x813B),
        TextureMinFilter = ((int)0x2801),
        TextureMinLod = ((int)0x813A),
        TextureSwizzleR = ((int)0x8E42),
        TextureSwizzleG = ((int)0x8E43),
        TextureSwizzleB = ((int)0x8E44),
        TextureSwizzleA = ((int)0x8E45),
        TextureSwizzleRGBA = ((int)0x8E46),
        TextureWrapS = ((int)0x2802),
        TextureWrapT = ((int)0x2803),
        TextureWrapR = ((int)0x8072)
    }

    public enum TextureTarget : int
    {
        Texture1D = ((int)0x0DE0),
        Texture2D = ((int)0x0DE1),
        Texture3D = ((int)0x806F),
        Texture1DArray = ((int)0x8C18),
        Texture2DArray = ((int)0x8C1A),
        TextureRectangle = ((int)0x84F5),
        TextureCubeMap = ((int)0x8513),
        TextureCubeMapArray = ((int)0x9009),
        Texture2DMultisample = ((int)0x9100),
        Texture2DMultisampleArray = ((int)0x9102)
    }

    public enum TextureTargetMultisample : int
    {
        Texture2DMultisample = ((int)0x9100),
        ProxyTexture2DMultisample = ((int)0x9101),
        Texture2DMultisampleArray = ((int)0x9102),
        ProxyTexture2DMultisampleArray = ((int)0x9103),
    }

    public enum TextureUnit : int
    {
        Texture0 = ((int)0x84C0),
        Texture1 = ((int)0x84C1),
        Texture2 = ((int)0x84C2),
        Texture3 = ((int)0x84C3),
        Texture4 = ((int)0x84C4),
        Texture5 = ((int)0x84C5),
        Texture6 = ((int)0x84C6),
        Texture7 = ((int)0x84C7),
        Texture8 = ((int)0x84C8),
        Texture9 = ((int)0x84C9),
        Texture10 = ((int)0x84CA),
        Texture11 = ((int)0x84CB),
        Texture12 = ((int)0x84CC),
        Texture13 = ((int)0x84CD),
        Texture14 = ((int)0x84CE),
        Texture15 = ((int)0x84CF),
        Texture16 = ((int)0x84D0),
        Texture17 = ((int)0x84D1),
        Texture18 = ((int)0x84D2),
        Texture19 = ((int)0x84D3),
        Texture20 = ((int)0x84D4),
        Texture21 = ((int)0x84D5),
        Texture22 = ((int)0x84D6),
        Texture23 = ((int)0x84D7),
        Texture24 = ((int)0x84D8),
        Texture25 = ((int)0x84D9),
        Texture26 = ((int)0x84DA),
        Texture27 = ((int)0x84DB),
        Texture28 = ((int)0x84DC),
        Texture29 = ((int)0x84DD),
        Texture30 = ((int)0x84DE),
        Texture31 = ((int)0x84DF),
    }

    public enum TransformFeedbackMode : int
    {
        InterleavedAttribs = ((int)0x8C8C),
        SeparateAttribs = ((int)0x8C8D),
    }

    public enum TransformFeedbackParameterName : int
    {
        TransformFeedbackBufferBinding = ((int)0x8C8F),
        TransformFeedbackBufferStart = ((int)0x8C84),
        TransformFeedbackBufferSize = ((int)0x8C85),
        TransformFeedbackPaused = ((int)0x8E23),
        TransformFeedbackActive = ((int)0x8E24)
    }

    public enum Version32 : int
    {
        ContextCoreProfileBit = ((int)0x00000001),
        SyncFlushCommandsBit = ((int)0x00000001),
        ContextCompatibilityProfileBit = ((int)0x00000002),
        LinesAdjacency = ((int)0x000A),
        LineStripAdjacency = ((int)0x000B),
        TrianglesAdjacency = ((int)0x000C),
        TriangleStripAdjacency = ((int)0x000D),
        ProgramPointSize = ((int)0x8642),
        DepthClamp = ((int)0x864F),
        TextureCubeMapSeamless = ((int)0x884F),
        GeometryVerticesOut = ((int)0x8916),
        GeometryInputType = ((int)0x8917),
        GeometryOutputType = ((int)0x8918),
        MaxVaryingComponents = ((int)0x8B4B),
        MaxGeometryTextureImageUnits = ((int)0x8C29),
        FramebufferAttachmentTextureLayer = ((int)0x8CD4),
        FramebufferAttachmentLayered = ((int)0x8DA7),
        FramebufferIncompleteLayerTargets = ((int)0x8DA8),
        GeometryShader = ((int)0x8DD9),
        MaxGeometryUniformComponents = ((int)0x8DDF),
        MaxGeometryOutputVertices = ((int)0x8DE0),
        MaxGeometryTotalOutputComponents = ((int)0x8DE1),
        QuadsFollowProvokingVertexConvention = ((int)0x8E4C),
        FirstVertexConvention = ((int)0x8E4D),
        LastVertexConvention = ((int)0x8E4E),
        ProvokingVertex = ((int)0x8E4F),
        SamplePosition = ((int)0x8E50),
        SampleMask = ((int)0x8E51),
        SampleMaskValue = ((int)0x8E52),
        MaxSampleMaskWords = ((int)0x8E59),
        Texture2DMultisample = ((int)0x9100),
        ProxyTexture2DMultisample = ((int)0x9101),
        Texture2DMultisampleArray = ((int)0x9102),
        ProxyTexture2DMultisampleArray = ((int)0x9103),
        TextureBinding2DMultisample = ((int)0x9104),
        TextureBinding2DMultisampleArray = ((int)0x9105),
        TextureSamples = ((int)0x9106),
        TextureFixedSampleLocations = ((int)0x9107),
        Sampler2DMultisample = ((int)0x9108),
        IntSampler2DMultisample = ((int)0x9109),
        UnsignedIntSampler2DMultisample = ((int)0x910A),
        Sampler2DMultisampleArray = ((int)0x910B),
        IntSampler2DMultisampleArray = ((int)0x910C),
        UnsignedIntSampler2DMultisampleArray = ((int)0x910D),
        MaxColorTextureSamples = ((int)0x910E),
        MaxDepthTextureSamples = ((int)0x910F),
        MaxIntegerSamples = ((int)0x9110),
        MaxServerWaitTimeout = ((int)0x9111),
        ObjectType = ((int)0x9112),
        SyncCondition = ((int)0x9113),
        SyncStatus = ((int)0x9114),
        SyncFlags = ((int)0x9115),
        SyncFence = ((int)0x9116),
        SyncGpuCommandsComplete = ((int)0x9117),
        Unsignaled = ((int)0x9118),
        Signaled = ((int)0x9119),
        AlreadySignaled = ((int)0x911A),
        TimeoutExpired = ((int)0x911B),
        ConditionSatisfied = ((int)0x911C),
        WaitFailed = ((int)0x911D),
        MaxVertexOutputComponents = ((int)0x9122),
        MaxGeometryInputComponents = ((int)0x9123),
        MaxGeometryOutputComponents = ((int)0x9124),
        MaxFragmentInputComponents = ((int)0x9125),
        ContextProfileMask = ((int)0x9126),
        TimeoutIgnored = unchecked((int)0xFFFFFFFFFFFFFFFF),
    }

    public enum VertexAttribParameter : int
    {
        ArrayEnabled = ((int)0x8622),
        ArraySize = ((int)0x8623),
        ArrayStride = ((int)0x8624),
        ArrayType = ((int)0x8625),
        CurrentVertexAttrib = ((int)0x8626),
        ArrayNormalized = ((int)0x886A),
        VertexAttribArrayInteger = ((int)0x88FD),
        ArrayLong = ((int)0x874E),
        ArrayDivisor = ((int)0x88FE),
        RelativeOffset = ((int)0x82D5)
    }

    public enum VertexAttribPointerParameter : int
    {
        ArrayPointer = ((int)0x8645),
    }

    public enum VertexAttribFormat : int
    {
        Byte = ((int)0x1400),
        UnsignedByte = ((int)0x1401),
        Short = ((int)0x1402),
        UnsignedShort = ((int)0x1403),
        Int = ((int)0x1404),
        UnsignedInt = ((int)0x1405),
        Float = ((int)0x1406),
        Double = ((int)0x140A),
        HalfFloat = ((int)0x140B),
        UnsignedUInt2101010Reversed = ((int)0x8368),
        UnsignedInt2101010Reversed = ((int)0x8D9F),
        UnsignedUInt101111Reversed = ((int)0x8C3B)
    }

    public enum VertexAttribPType : int
    {
        UnsignedUInt2101010Reversed = ((int)0x8368),
        UnsignedInt2101010Reversed = ((int)0x8D9F)
    }

    public enum VertexAttribPointerType : int
    {
        Byte = ((int)0x1400),
        UnsignedByte = ((int)0x1401),
        Short = ((int)0x1402),
        UnsignedShort = ((int)0x1403),
        Int = ((int)0x1404),
        UnsignedInt = ((int)0x1405),
        Float = ((int)0x1406),
        Double = ((int)0x140A),
        HalfFloat = ((int)0x140B),
        UnsignedUInt2101010Reversed = ((int)0x8368),
        UnsignedInt2101010Reversed = ((int)0x8D9F)
    }
}
