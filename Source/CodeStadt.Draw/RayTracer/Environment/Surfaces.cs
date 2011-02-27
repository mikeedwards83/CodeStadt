namespace CodeStadt.Draw.RayTracer.Environment
{
    using System;

    /// <summary>
    /// List of pre-defined surfaces
    /// </summary>
    public static class Surfaces
    {
        // Only works with X-Z plane.
        public static readonly Surface CheckerBoard =
            new Surface()
            {
                Diffuse = pos => ((Math.Floor(pos.Z) + Math.Floor(pos.X)) % 2 != 0)
                                    ? new Color(1,1,1)
                                    : new Color(0,0,0),
                Specular = pos => new Color(1,1,1),
                Reflectiveness = pos => ((Math.Floor(pos.Z) + Math.Floor(pos.X)) % 2 != 0)
                                    ? .1
                                    : .7,
                Roughness = 150
            };


        public static readonly Surface Shiny =
            new Surface()
            {
                Diffuse = pos => new Color(1,1,1),
                Specular = pos => new Color(.5, .5, .5),
                Reflectiveness = pos => .6,
                Roughness = 50
            };

        public static readonly Surface Red =
            new Surface()
            {
                Diffuse = pos => new Color(1,0,0),
                Specular = pos => new Color(1,1,1),
                Reflectiveness = pos => 0.1,
                Roughness = 150
            };

        public static readonly Surface Green =
            new Surface()
            {
                Diffuse = pos => new Color(0, 1, 0),
                Specular = pos => new Color(0.5, 0.5, 0.5),
                Reflectiveness = pos => 0.8,
                Roughness = 100
            };

        public static readonly Surface Blue =
            new Surface()
            {
                Diffuse = pos => new Color(0, 0, 1),
                Specular = pos => new Color(0.5, 0.5, 0.5),
                Reflectiveness = pos => 0.8,
                Roughness = 100
            };

        public static readonly Surface White =
            new Surface()
            {
                Diffuse = pos => new Color(1, 1, 1),
                Specular = pos => new Color(0.5, 0.5, 0.5),
                Reflectiveness = pos => 0,
                Roughness = 100
            };
    }
}
