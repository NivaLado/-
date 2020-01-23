using System;
using System.Collections.Generic;
using System.Text;

namespace EulerMethod
{
    public class EulerMethod
    {
        public double X { get; set; }
        public double Y { get; set; }

        public List<double> XList { get; set; }

        public List<double> YList { get; set; }

        public EulerMethod()
        {
            XList = new List<double>();
            YList = new List<double>();
        }

        public (List<double>, List<double>) Solve(double startXPoint, double endXPoint, double initialСondition, double step)
        {
            int overalSteps = (int)((endXPoint - startXPoint) / step);

            X = startXPoint;
            Y = initialСondition;

            XList.Add(X);
            YList.Add(Y);

            for (int i = 0; i < overalSteps; i++)
            {
                Y += step * F(X, Y);
                YList.Add(Y);

                X += step;
                XList.Add(X);
            }

            return (XList, YList);
        }

        private double F(double x, double y)
        {
            return (-3 * y) + (2 * Math.Pow(x,2));
        }
    }
}
