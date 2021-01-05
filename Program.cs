using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace EquationOfParabola
{
    class Coordinate
    {
        private double X;
        private double Y;
        public Coordinate (double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public double getX()
        {
            return X;
        }
        public double getY()
        {
            return Y;
        }
        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Coordinate> coordinates = new List<Coordinate>();

            double[] GivenXs = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16}; 
            int[] X = { 1, 4, 2 };
            int[] Y = { 3, 9, 1 };
            var Xs = Matrix<double>.Build.DenseOfArray(new double[,] {
                    { X[0]*X[0], X[0], 1 },
                    { X[1]*X[1], X[1], 1 },
                    { X[2]*X[2], X[2], 1 }
             });
            var ys = Vector<double>.Build.Dense(new double[] { Y[0],Y[1],Y[2]});
            var abc = Xs.Solve(ys);
            
            var a = abc[0];
            var b = abc[1];
            var c = abc[2];
            
            Console.WriteLine("a = " + a.ToString() + ", b =" + b.ToString()+", c = "+c.ToString());
            foreach (var x in GivenXs)
            {
                double y = a * x * x + b * x + c;
                coordinates.Add(new Coordinate(x, y));
            }
            foreach (Coordinate C in coordinates)
            {
                Console.WriteLine(C.ToString() + '\n');
            }
        }
    }
}
