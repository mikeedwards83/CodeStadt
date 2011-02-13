using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Driven.Metrics.metrics;
using Driven.Metrics;
using Driven.Metrics.Reporting;
using System.Drawing;
using CodeStadt.Draw;
using System.Drawing.Imaging;
using System.IO;

namespace CodeStadt.Application
{
    class Program
    {

        static void Main(string[] args)
        {

            CommandLineArguments cArgs = new CommandLineArguments(args);

            Configuration config = new Configuration();

            var something = new Driven.Metrics.DrivenMetrics.Factory().Create(
                 cArgs.Assemblies.ToArray(),
                 config.Container.ResolveAll<IMetricCalculator>() ,
                     "TestReport",
                 config.Container.Resolve<IReport>());

            something.RunAllMetricsAndGenerateReport();

            CodeStadt.Core.DrivenMetrics.Reporting.ResultOutput results = something.Report.As<Core.DrivenMetrics.Reporting.ResultOutput>();

            if (results != null)
            {
                results.Results.ForEach(x =>
                {
                    Console.WriteLine("Metric: {0}".Formatted(x.Name));
                    Console.WriteLine("");

                    x.ClassResults.ForEach(y =>
                    {
                        Console.WriteLine("  Class: {0}".Formatted(y.Name));
                        Console.WriteLine("");
                        y.MethodResults.ForEach(z =>
                        {
                            Console.WriteLine("    Method: {0} \n\r    Result: {1}".Formatted(z.Name, z.Result));
                            Console.WriteLine("");

                        });
                    });
                });
            }

          // Console.ReadLine();

            Console.WriteLine("Going to try and draw an image :-)");


            string fileName = "test.jpg";
            int screenZ = 1;

            if (File.Exists(fileName)) File.Delete(fileName);

            Bitmap map = new Bitmap(100, 100);
            
            Graphics img = Graphics.FromImage(map);

            



            //front square
            Coordinate3D coord1 = new Coordinate3D(30, 30, 1);
            Coordinate3D coord2 = new Coordinate3D(80, 30, 1);
            Coordinate3D coord3 = new Coordinate3D(80, 80, 1);
            Coordinate3D coord4 = new Coordinate3D(30, 80, 1);

            //rear square
            Coordinate3D coord11 = new Coordinate3D(50, 50, 2);
            Coordinate3D coord21 = new Coordinate3D(120, 50, 2);
            Coordinate3D coord31 = new Coordinate3D(120, 120, 2);
            Coordinate3D coord41 = new Coordinate3D(50, 120, 2);


            //draw front square
            SimpleDrawer.DrawLine(img, coord1, coord2, screenZ);
            SimpleDrawer.DrawLine(img, coord2, coord3, screenZ);
            SimpleDrawer.DrawLine(img, coord3, coord4, screenZ);
            SimpleDrawer.DrawLine(img, coord4, coord1, screenZ);


            //draw rear square

            SimpleDrawer.DrawLine(img, coord11, coord21, screenZ);
            SimpleDrawer.DrawLine(img, coord21, coord31, screenZ);
            SimpleDrawer.DrawLine(img, coord31, coord41, screenZ);
            SimpleDrawer.DrawLine(img, coord41, coord11, screenZ);

            //link front to rear

            SimpleDrawer.DrawLine(img, coord1, coord11, screenZ);
            SimpleDrawer.DrawLine(img, coord2, coord21, screenZ);
            SimpleDrawer.DrawLine(img, coord3, coord31, screenZ);
            SimpleDrawer.DrawLine(img, coord4, coord41, screenZ);


           
            map.Save("test.jpg", ImageFormat.Jpeg);

            




        }
    }
}
