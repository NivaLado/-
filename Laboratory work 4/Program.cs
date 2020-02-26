using System;
using System.Collections.Generic;

namespace EulerMethod
{

    struct XYCoordinates
    {
        public List<float> X, Y;

        public int Length;

        public XYCoordinates(List<float> x,List<float> y)
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

            var result = euler.Solve(0, 10, 1, 0.01f);

            XYCoordinates coordinates = new XYCoordinates(result.Item1, result.Item2);

            for (int i = 0; i < coordinates.Length; i++)
            {
                Console.WriteLine($"X is : {coordinates.X[i]}, Y is {coordinates.Y[i]}");
            }

            Console.ReadLine();
        }
    }
}
