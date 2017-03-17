namespace OpenGL.Platform
{
    public static class Time
    {
        #region Static Fields and Properties
        private static System.Diagnostics.Stopwatch Timer;
        private static int deltaTimeIntegrator;
        private static float physicsAccumulator = 0f;

        /// <summary>
        /// Gets the amount of time in seconds that the previous frame took to render.
        /// </summary>
        public static float DeltaTime { get; private set; }

        /// <summary>
        /// Gets the total number of frames since the game started;
        /// </summary>
        public static uint FrameCount { get; private set; }

        /// <summary>
        /// Gets a smoothed version of time (the average delta time for the last 256 frames or so).
        /// </summary>
        public static float SmoothDeltaTime { get; private set; }

        /// <summary>
        /// Scales all of the time values so that time appears to 'warp'.
        /// Defaults to a value of 1.0f;
        /// </summary>
        public static float TimeScale { get; set; }

        /// <summary>
        /// The number of physics steps that should occur given the previous frame time and current frame time.
        /// Note:  Physics steps occur at a rate of 20fps
        /// </summary>
        public static int PhysicsSteps { get; private set; }

        /// <summary>
        /// Gets the number of physics steps multiplied by the time between physics time steps.
        /// ex)  With physics time steps of 0.05s this value will be PhysicsSteps * 0.05
        /// </summary>
        public static float PhysicsTimeStep { get; private set; }

        /// <summary>
        /// Gets or sets the amount of time between physics updates.
        /// This defaults to 0.025s, which is equivalent to 20fps.
        /// </summary>
        public static float PhysicsUpdateRate { get; set; }
        #endregion

        #region Static Methods
        /// <summary>
        /// Initializes and begins a Stopwatch for the Time static class.
        /// </summary>
        public static void Init()
        {
            Timer = System.Diagnostics.Stopwatch.StartNew();
            FrameCount = 0;
            deltaTimeIntegrator = 0;
            TimeScale = 1.0f;
            PhysicsUpdateRate = 0.025f;
        }

        /// <summary>
        /// Updates the privately updated static properties and resets the Stopwatch.
        /// </summary>
        public static float Update()
        {
            float frequencyInverse = TimeScale / System.Diagnostics.Stopwatch.Frequency;

            DeltaTime = (float)Timer.ElapsedTicks * frequencyInverse + float.Epsilon;

            if (FrameCount == int.MaxValue)
            {
                // player has been playing for a long time, so wipe out some of the frame count
                FrameCount = (int.MaxValue >> 1);
            }
            FrameCount++;

            deltaTimeIntegrator += (int)(Timer.ElapsedTicks - (deltaTimeIntegrator >> 4));
            SmoothDeltaTime = (deltaTimeIntegrator >> 4) * frequencyInverse;

            physicsAccumulator += DeltaTime;
            PhysicsSteps = (int)(physicsAccumulator / PhysicsUpdateRate);
            PhysicsTimeStep = PhysicsSteps * PhysicsUpdateRate;
            physicsAccumulator -= PhysicsTimeStep;

            Timer.Restart();

            return DeltaTime;
        }
        #endregion
    }
}
