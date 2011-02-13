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

            
            
            int screenZ = 1;

            string simpleFileName = "simple.jpg";
            if (File.Exists(simpleFileName)) File.Delete(simpleFileName);

            Bitmap simpleMap = new Bitmap(100, 100);
            
            Graphics simpleImage = Graphics.FromImage(simpleMap);

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
            SimpleDrawer.DrawLine(simpleImage, coord1, coord2, screenZ);
            SimpleDrawer.DrawLine(simpleImage, coord2, coord3, screenZ);
            SimpleDrawer.DrawLine(simpleImage, coord3, coord4, screenZ);
            SimpleDrawer.DrawLine(simpleImage, coord4, coord1, screenZ);


            //draw rear square

            SimpleDrawer.DrawLine(simpleImage, coord11, coord21, screenZ);
            SimpleDrawer.DrawLine(simpleImage, coord21, coord31, screenZ);
            SimpleDrawer.DrawLine(simpleImage, coord31, coord41, screenZ);
            SimpleDrawer.DrawLine(simpleImage, coord41, coord11, screenZ);

            //link front to rear

            SimpleDrawer.DrawLine(simpleImage, coord1, coord11, screenZ);
            SimpleDrawer.DrawLine(simpleImage, coord2, coord21, screenZ);
            SimpleDrawer.DrawLine(simpleImage, coord3, coord31, screenZ);
            SimpleDrawer.DrawLine(simpleImage, coord4, coord41, screenZ);


           
            simpleMap.Save(simpleFileName, ImageFormat.Jpeg);

            //view point
            //note that the blue square is the back face of the cube


            string advancedFileName = "advanced.jpg";
            if (File.Exists(advancedFileName)) File.Delete(advancedFileName);

            Bitmap advancedMap = new Bitmap(400, 400);

            Graphics advancedImage = Graphics.FromImage(advancedMap);

            Coordinate3D viewPoint = new Coordinate3D(120, 60, -1);

            //draw rear square

            //AdvancedDrawer.DrawLine(advancedImage, coord11, coord21, viewPoint, screenZ);
            //AdvancedDrawer.DrawLine(advancedImage, coord21, coord31, viewPoint, screenZ);
            //AdvancedDrawer.DrawLine(advancedImage, coord31, coord41, viewPoint, screenZ);
            //AdvancedDrawer.DrawLine(advancedImage, coord41, coord11, viewPoint, screenZ);

            AdvancedDrawer.DrawSquare(advancedImage, coord11, coord21, coord31, coord41, viewPoint, screenZ);

            //draw front square
            AdvancedDrawer.DrawLine(advancedImage, coord1, coord2, viewPoint, screenZ);
            AdvancedDrawer.DrawLine(advancedImage, coord2, coord3, viewPoint, screenZ);
            AdvancedDrawer.DrawLine(advancedImage, coord3, coord4, viewPoint, screenZ);
            AdvancedDrawer.DrawLine(advancedImage, coord4, coord1, viewPoint, screenZ);




            

            //link front to rear

            AdvancedDrawer.DrawLine(advancedImage, coord1, coord11, viewPoint, screenZ);
            AdvancedDrawer.DrawLine(advancedImage, coord2, coord21, viewPoint, screenZ);
            AdvancedDrawer.DrawLine(advancedImage, coord3, coord31, viewPoint, screenZ);
            AdvancedDrawer.DrawLine(advancedImage, coord4, coord41, viewPoint, screenZ);

            advancedMap.Save(advancedFileName);



        }
    }
}
