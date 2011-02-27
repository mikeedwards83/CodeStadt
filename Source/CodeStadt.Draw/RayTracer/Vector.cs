namespace CodeStadt.Draw.RayTracer
{
    using System;

    /// <summary>
    /// Represent a vector in 3D space and provide standard mathematical 
    /// operations.
    /// </summary>
    /// <remarks>
    /// The class is immutable
    /// </remarks>
    [System.Diagnostics.DebuggerDisplay("X = {X}, Y = {Y}, Z = {Z}")]
    public sealed class Vector
    {
        /// <summary>
        /// The X component
        /// </summary>
        public double X { get; private set; }

        /// <summary>
        /// The Y component
        /// </summary>
        public double Y { get; private set; }

        /// <summary>
        /// The Z component
        /// </summary>
        public double Z { get; private set; }

        /// <summary>
        /// The magnitude of the vector
        /// </summary>
        public double Magnitude
        {
            get
            {
                return Math.Sqrt(this.Dot(this));
            }
        }

        /// <summary>
        /// Calculate the normalised vector (unit vector)
        /// </summary>
        public Vector Normalise
        {
            get
            {
                var mag = this.Magnitude;
                double divisor = (mag == 0) ? double.PositiveInfinity : 1 / mag;
                return this.Times(divisor);
            }
        }

        /// <summary>
        /// Initialise a new instance of the Vector class
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector(double x, double y, double z) 
        { 
            this.X = x; 
            this.Y = y; 
            this.Z = z; 
        }

        /// <summary>
        /// Add a vector to the current vector
        /// </summary>
        /// <param name="v">The vector to add</param>
        /// <returns>The resultant vector</returns>
        public Vector Plus(Vector v)
        {
            return new Vector(this.X + v.X, this.Y + v.Y, this.Z + v.Z);
        }
        
        /// <summary>
        /// Add two vectors together
        /// </summary>
        /// <param name="v1">The first vector</param>
        /// <param name="v2">The second vector</param>
        /// <returns>The resultant vector</returns>
        public static Vector Plus(Vector v1, Vector v2)
        {
            return v1.Plus(v2);
        }

        /// <summary>
        /// + operator to add two vectors
        /// </summary>
        /// <param name="v1">The first vector</param>
        /// <param name="v2">The second vector</param>
        /// <returns>The resultant vector</returns>
        public static Vector operator +(Vector v1, Vector v2)
        {
            return v1.Plus(v2);
        }

        /// <summary>
        /// Subtract a vector from the current vector
        /// </summary>
        /// <param name="v">The vector to subtract</param>
        /// <returns>The resultant vector</returns>
        public Vector Minus(Vector v)
        {
            return new Vector(this.X - v.X, this.Y - v.Y, this.Z - v.Z);
        }

        /// <summary>
        /// Subtract one vector from another
        /// </summary>
        /// <param name="v1">The first vector</param>
        /// <param name="v2">The second vector</param>
        /// <returns>The resultant vector</returns>
        public static Vector Minus(Vector v1, Vector v2)
        {
            return v1.Minus(v2);
        }

        /// <summary>
        /// - operator to subtract one vector from another
        /// </summary>
        /// <param name="v1">The first vector</param>
        /// <param name="v2">The second vector</param>
        /// <returns>The resultant vector</returns>
        public static Vector operator -(Vector v1, Vector v2)
        {
            return v1.Minus(v2);
        }

        /// <summary>
        /// Multiply the vector by a constant value
        /// </summary>
        /// <param name="n">The value to multiply by</param>
        /// <returns>The resultant vector</returns>
        public Vector Times(double n)
        {
            return new Vector(this.X * n, this.Y * n, this.Z * n);

        }

        /// <summary>
        /// Multiply a vector by a constant value
        /// </summary>
        /// <param name="v">The vector to multiply</param>
        /// <param name="n">The value to multiply by</param>
        /// <returns>The resultant vector</returns>
        public static Vector Times(double n, Vector v)
        {
            return v.Times(n);
        }

        /// <summary>
        /// * operator to multiply a vector by a constant value
        /// </summary>
        /// <param name="v">The vector to multiply</param>
        /// <param name="n">The value to multiply by</param>
        /// <returns>The resultant vector</returns>
        public static Vector operator *(double n, Vector v)
        {
            return v.Times(n);
        }

        /// <summary>
        /// Calculate the dot-product of this vector with another
        /// </summary>
        /// <param name="v">The vector to dot with</param>
        /// <returns>The result</returns>
        public double Dot(Vector v)
        {
            return (this.X * v.X) + (this.Y * v.Y) + (this.Z * v.Z);
        }

        /// <summary>
        /// Calculate the dot-product of two vectors
        /// </summary>
        /// <param name="v1">The first vector</param>
        /// <param name="v2">The second vector</param>
        /// <returns>The result</returns>
        public static double Dot(Vector v1, Vector v2)
        {
            return v1.Dot(v2);
        }

        /// <summary>
        /// Calculate the cross-product of this vector with another
        /// </summary>
        /// <param name="v">The vector to cross with</param>
        /// <returns>The resultant vector</returns>
        public Vector Cross(Vector v)
        {
            return new Vector(((this.Y * v.Z) - (this.Z * v.Y)),
                              ((this.Z * v.X) - (this.X * v.Z)),
                              ((this.X * v.Y) - (this.Y * v.X)));
        }

        /// <summary>
        /// Calculate the cross-product of two vectors
        /// </summary>
        /// <param name="v1">The first vector</param>
        /// <param name="v2">The second vector</param>
        /// <returns>The resultant vector</returns>
        public static Vector Cross(Vector v1, Vector v2)
        {
            return v1.Cross(v2);
        }

        /// <summary>
        /// Check if an object is equal to the current vector
        /// </summary>
        /// <param name="obj">The object to test</param>
        /// <returns>true if the object is equal</returns>
        public override bool Equals(object obj)
        {
            var v = obj as Vector;

            if (v != null)
            {
                // This works, but isn't always helpful as doubles aren't exact.
                return (this.X == v.X) && (this.Y == v.Y) && (this.Z == v.Z); //this.Equals(v);
            }

            return false;
        }

        /// <summary>
        /// Determinue if two vectors are equal
        /// </summary>
        /// <param name="v1">The first vector</param>
        /// <param name="v2">The second vector</param>
        /// <returns>True if the vectors are equal</returns>
        public static bool Equals(Vector v1, Vector v2)
        {
            return v1.Equals(v2);
        }

        /// <summary>
        /// Convert to a friendly string for debugging
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "X={0} Y={1} Z={2}".Formatted(this.X, this.Y, this.Z);
        }

    }
}
