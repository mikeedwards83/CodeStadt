namespace CodeStadt.Draw.RayTracer.Environment
{
    /// <summary>
    /// Represent the camera used to view the scene
    /// </summary>
    public class Camera
    {
        /// <summary>
        /// The position of the camera
        /// </summary>
        public Vector Position { get; private set; }

        /// <summary>
        /// Vector pointing forwards from the camera towards lookAt from position.
        /// </summary>
        public Vector Forward { get; private set; }

        /// <summary>
        /// Vector pointing perpendicular and right of the camera
        /// </summary>
        public Vector Up { get; private set; }

        /// <summary>
        /// Vector pointing perpendicular and up from the camera
        /// </summary>
        public Vector Right { get; private set; }

        /// <summary>
        /// The screen we are rendering to
        /// </summary>
        public Screen Screen { get; private set; }

        /// <summary>
        /// Create a new instance of the camera class
        /// </summary>
        /// <param name="position">The position of the camera in 3D space</param>
        /// <param name="lookAt">The point the camera is looking at</param>
        public Camera(Vector position, Vector lookAt, Screen screen)
        {
            // Remember: The cross of two vectors gives you a normal vector out of the cross
            var down = new Vector(0, -1, 0);
            
            this.Position = position;
            this.Forward = (lookAt - position).Normalise;   
            this.Right = this.Forward.Cross(down).Normalise; 
            this.Up = this.Forward.Cross(this.Right).Normalise;

            this.Screen = screen;
        }

        /// <summary>
        /// The camera points at the center of the screen. This function calculates
        /// the X offset required to point the camera at the pixel to render
        /// </summary>
        /// <param name="x">The x co-ord of the pixel to render</param>
        /// <returns></returns>
        private double OffsetX(double x)
        {
            return (x - (this.Screen.Width / 2.0)) / (2.0 * this.Screen.Width);
        }

        /// <summary>
        /// The camera points at the center of the screen. This function calculates
        /// the Y offset required to point the camera at the pixel to render
        /// </summary>
        /// <param name="y">The y co-ord of the pixel to render</param>
        /// <returns></returns>
        private double OffsetY(double y)
        {
            return -(y - (this.Screen.Height / 2.0)) / (2.0 * this.Screen.Height);
        }

        /// <summary>
        /// Get the direction of the ray to trace.  From the position of the camera
        /// to the point (x,y) in the scene.
        /// </summary>
        /// <param name="x">The x co-ordinate of the pixel to draw</param>
        /// <param name="y">The y co-ordinate of the pixel to draw</param>
        /// <returns>The direction of the ray to trace to find color of (x,y)</returns>
        public Vector GetRayDirection(double x, double y)
        {
            // Forward is the starting direction of the camera, we then need to offset to look at the point (x,y)
            return (this.Forward + ((this.OffsetX(x) * this.Right) + (this.OffsetY(y) * this.Up))).Normalise;
        }
    }
}
