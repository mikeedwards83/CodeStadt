namespace CodeStadt.Draw.RayTracer
{
    using System;

    /// <summary>
    /// Represent an RGB color and provide useful operations
    /// </summary>
    /// <remarks>
    /// This class is immutable
    /// </remarks>
    public class Color
    {
        /// <summary>
        /// The red component (0-1)
        /// </summary>
        public double R { get; private set; }

        /// <summary>
        /// The green component (0-1)
        /// </summary>
        public double G { get; private set; }

        /// <summary>
        /// The blue component (0-1)
        /// </summary>
        public double B { get; private set; }

        /// <summary>
        /// Initialise a new instance of the color class
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public Color(double r, double g, double b) 
        { 
            this.R = r; 
            this.G = g; 
            this.B = b; 
        }

        /// <summary>
        /// Multiply the components of the color by a constant value
        /// </summary>
        /// <param name="n">The value to multiple by</param>
        /// <returns>The resultant color</returns>
        public Color Times(double n)
        {
            return new Color(n * this.R, n * this.G, n * this.B);
        }

        /// <summary>
        /// Multiply the components of a color by a constant value
        /// </summary>
        /// <param name="n">The value to multiply by</param>
        /// <param name="v">The color</param>
        /// <returns>The resultant color</returns>
        public static Color Times(double n, Color v)
        {
            return v.Times(n);
        }

        /// <summary>
        /// * operator to multiply the components of a color by a constant value
        /// </summary>
        /// <param name="n">The value to multiply by</param>
        /// <param name="v">The color</param>
        /// <returns>The resultant color</returns>
        public static Color operator *(double n, Color v)
        {
            return v.Times(n);
        }

        /// <summary>
        /// Multiply this color by another color
        /// </summary>
        /// <param name="c">The color to multiply by</param>
        /// <returns>The resultant color</returns>
        public Color Times(Color c)
        {
            return new Color(this.R * c.R, this.G * c.G, this.B * c.B);
        }

        /// <summary>
        /// Multiply two colors together
        /// </summary>
        /// <param name="v1">The first color</param>
        /// <param name="v2">The second color</param>
        /// <returns>The resultant color</returns>
        public static Color Times(Color v1, Color v2)
        {
            return v1.Times(v2);
        }

        /// <summary>
        /// * operator for two colors
        /// </summary>
        /// <param name="v1">The first color</param>
        /// <param name="v2">The second color</param>
        /// <returns>The resultant color</returns>
        public static Color operator *(Color v1, Color v2)
        {
            return v1.Times(v2);
        }

        /// <summary>
        /// Add another color to this color
        /// </summary>
        /// <param name="c">The color to add</param>
        /// <returns>The resultant color</returns>
        public Color Plus(Color c)
        {
            return new Color(this.R + c.R, this.G + c.G, this.B + c.B);
        }

        /// <summary>
        /// Add two colors together
        /// </summary>
        /// <param name="v1">The first color</param>
        /// <param name="v2">The second color</param>
        /// <returns>The resultant color</returns>
        public static Color Plus(Color v1, Color v2)
        {
            return v1.Plus(v2);
        }

        /// <summary>
        /// + operator to add a color to this one
        /// </summary>
        /// <param name="v1">The first color</param>
        /// <param name="v2">The second color</param>
        /// <returns>The resultant color</returns>
        public static Color operator +(Color v1, Color v2)
        {
            return v1.Plus(v2);
        }

        /// <summary>
        /// Subtract a color from the current color
        /// </summary>
        /// <param name="c">The color to subtract</param>
        /// <returns>The resultant color</returns>
        public Color Minus(Color c)
        {
            return new Color(this.R - c.R, this.G - c.G, this.B - c.B);
        }

        /// <summary>
        /// Subtract one color from another
        /// </summary>
        /// <param name="v1">The first color</param>
        /// <param name="v2">The second color</param>
        /// <returns>The resultant color</returns>
        public static Color Minus(Color v1, Color v2)
        {
            return v1.Minus(v2);
        }

        /// <summary>
        /// - operator to subtract one color from another
        /// </summary>
        /// <param name="v1">The first color</param>
        /// <param name="v2">The second color</param>
        /// <returns>The resultant color</returns>
        public static Color operator -(Color v1, Color v2)
        {
            return v1.Minus(v2);
        }

        /// <summary>
        /// Convert the value of the current object to a system color object
        /// </summary>
        /// <returns>A system color object</returns>
        public System.Drawing.Color ToDrawingColor()
        {
            return System.Drawing.Color.FromArgb(
                            (int)(Math.Min(1, this.R) * 255), 
                            (int)(Math.Min(1, this.G) * 255), 
                            (int)(Math.Min(1, this.B) * 255));
        }

        public static readonly Color DefaultColor = new Color(0, 0, 0);
        public static readonly Color Background = new Color(0, 0, 0);

        public override bool Equals(object obj)
        {
            var c = obj as Color;

            if (c == null)
            {
                return false;
            }

            return (this.R == c.R) && (this.G == c.G) && (this.B == c.B);
        }

        public static bool Equals(Color c1, Color c2)
        {
            return c1.Equals(c2);
        }
    }
}
