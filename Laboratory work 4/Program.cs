using System;
using System.Collections.Generic;

namespace EulerMethod
{

    struct XYCoordinates
    {
        public List<double> X, Y;

        public int Length;

        public XYCoordinates(List<double> x,List<double> y)
        {
            X = x;
            Y = y;

            Length = x.Count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var euler = new EulerMethod();

            var result = euler.Solve(0, 1, 13, 0.01f);

            XYCoordinates coordinates = new XYCoordinates(result.Item1, result.Item2);

            for (int i = 0; i < coordinates.Length; i++)
            {
                Console.WriteLine($"X is : {coordinates.X[i]}, Y is {coordinates.Y[i]}");
            }

            Console.ReadLine();
        }
    }
}
