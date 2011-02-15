using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStadt.Draw.Shapes;

namespace CodeStadt.Draw.Builders
{
    public class RandomCubeBuilder : ICityBuilder
    {

        int _minHeight;
        int _maxHeight;
        int _minWidth;
        int _maxWidth;
        int _minDepth;
        int _maxDepth;
        int _numCubeWide;
        int _numCubeDeep;

        public RandomCubeBuilder(
            int minHeight,
            int maxHeight,
            int minWidth,
            int maxWidth,
            int minDepth,
            int maxDepth,
            int numCubeWide,
            int numCubeDeep)
        {

            _minHeight = minHeight;
            _maxHeight = maxHeight;
            _minWidth = minWidth;
            _maxWidth = maxWidth;
            _minDepth = minDepth;
            _maxDepth = maxDepth;
            _numCubeWide = numCubeWide;
            _numCubeDeep = numCubeDeep;

        }



        #region ICityBuilder Members

        public IEnumerable<CodeStadt.Draw.Shapes.IShape> CreateCity(CodeStadt.Core.DrivenMetrics.Reporting.ResultOutput output)
        {
            int preX = 10,preZ = 10;
            List<IShape> shapes = new List<IShape>();


            Random rand = new Random();

            for (int i = 0; i < _numCubeDeep; i++)
            {
                int z = rand.Next(preZ, preZ + _maxDepth/2);
                preX = 10;
                for (int j = 0; j < _numCubeWide; j++)
                {
                    int x = rand.Next(preX, preX + _maxWidth);

                    int width = rand.Next(_minWidth, _maxWidth);
                    int height = rand.Next(_minHeight, _maxHeight);
                    int depth = rand.Next(_minDepth, _maxDepth);

                    Coordinate3D bottomLeft = new Coordinate3D(x, 0, z);
                    Cube cube = new Cube(bottomLeft, width, height, depth);
                    shapes.Add(cube);

                    preX = x+_maxWidth; 
                   
                }

                preZ = z+_maxDepth*2;
            }
            
            return shapes;
        }

        #endregion
    }
}
