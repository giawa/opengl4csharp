using System;

namespace OpenGL.Platform
{
    public enum SpecialKey
    {
        Alt, Control, Shift
    };

    /// <summary>Enumeration holding the mouse button values.</summary>
    public enum MouseButton : int
    {
        /// <summary>The left mouse button is a valid chord modifier for input.</summary>
        Left = 1,
        /// <summary>The right mouse button is a valid chord modifier for input.</summary>
        Right = 3,
        /// <summary>The middle mouse button is a valid chord modifier for input.</summary>
        Middle = 2
    }

    /// <summary>
    /// Enumeration holding the mouse state values.
    /// </summary>
    public enum MouseState : int
    {
        Up = 0,
        Down = 1
    }

    public class MouseEventArgs : EventArgs
    {
        public Point Location { get; private set; }
        public Point LastLocaton { get; private set; }
        public MouseButton Button { get; private set; }
        public MouseState State { get; private set; }

        public MouseEventArgs(Click MousePosition, Click LastMousePosition)
            : this(new Point(MousePosition.X, MousePosition.Y), MousePosition.Button, MousePosition.State)
        {
            this.LastLocaton = new Point(LastMousePosition.X, LastMousePosition.Y);
        }

        public MouseEventArgs()
            : this(new Point(0, 0))
        {
        }

        public MouseEventArgs(Point Location)
        {
            this.LastLocaton = new Point(Location.X, Location.Y);
            this.Location = this.LastLocaton;
        }

        public MouseEventArgs(Point Location, MouseButton Button, MouseState State)
        {
            this.LastLocaton = new Point(Location.X, Location.Y);
            this.Location = this.LastLocaton;
            this.Button = Button;
            this.State = State;
        }

        internal void SetLocation(Point Location)
        {
            this.LastLocaton = this.Location;
            this.Location = new Point(Location.X, Location.Y);
        }

        internal void SetState(Point Location, MouseButton Button, MouseState State)
        {
            this.LastLocaton = this.Location;
            this.Location = new Point(Location.X, Location.Y);
            this.Button = Button;
            this.State = State;
        }
    }

    /// <summary>
    /// A click stores information about the mouse location
    /// and button at the time of a click event.
    /// </summary>
    public struct Click
    {
        #region Fields
        /// <summary>
        /// The x-location of the mouse wrt the top-left.
        /// </summary>
        public int X;

        /// <summary>
        /// The y-location of the mouse wrt the top-left.
        /// </summary>
        public int Y;

        /// <summary>
        /// The mouse button pressed on the click event.
        /// </summary>
        public MouseButton Button;

        /// <summary>
        /// True if the mouse button has been pressed, false if it has been released.
        /// </summary>
        public MouseState State;
        #endregion

        #region Methods
        /// <summary>
        /// A new click object with x, y and button data.
        /// </summary>
        /// <param name="x">The x-location of the mouse wrt the top-left.</param>
        /// <param name="y">The y-location of the mouse wrt the top-left.</param>
        /// <param name="button">The mouse button pressed on the click event.</param>
        /// <param name="pressed">True if the mouse has been pressed, false if released.</param>
        public Click(int x, int y, MouseButton button, MouseState state)
        {
            X = x;
            Y = y;
            Button = button;
            State = state;
        }

        /// <summary>
        /// A new click object with x, y and button data.
        /// </summary>
        /// <param name="_x">The x-location of the mouse wrt the top-left.</param>
        /// <param name="_y">The y-location of the mouse wrt the top-left.</param>
        /// <param name="left">True if the left button is pressed.</param>
        /// <param name="middle">True if the middle button is pressed.</param>
        /// <param name="right">True if the right button is pressed.</param>
        /// <param name="pressed">True if the mouse has been pressed, false if released.</param>
        public Click(int x, int y, bool left, bool middle, bool right, bool pressed) :
            this(x, y, (left ? MouseButton.Left : (right ? MouseButton.Right : MouseButton.Middle)), pressed ? MouseState.Down : MouseState.Up) { }

        /// <summary>
        /// A new click object with button data.
        /// </summary>
        /// <param name="left">True if the left button is pressed.</param>
        /// <param name="middle">True if the middle button is pressed.</param>
        /// <param name="right">True if the right button is pressed.</param>
        /// <param name="pressed">True if the mouse has been pressed, false if released.</param>
        //public Click(bool left, bool middle, bool right, bool pressed) :
        //    this(Input.MousePosition.x, Input.MousePosition.y, left, middle, right, pressed) { }

        /// <summary>
        /// ToString override to give some information about the mouse state.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Mouse at {0},{1} and is {2}.", X, Y, State);
        }
        #endregion
    }
}
