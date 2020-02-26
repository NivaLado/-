using System;
using System.Collections.Generic;

namespace EulerMethod
{
    public class EulerMethod
    {
        public float X { get; set; }
        public float Y { get; set; }

        public List<float> XList { get; set; }

        public List<float> YList { get; set; }

        public List<float> IDeal { get; set; }

        public EulerMethod()
        {
            XList = new List<float>();
            YList = new List<float>();
            IDeal = new List<float>();
        }

        public (List<float>, List<float>, List<float>) Solve(float startXPoint, float endXPoint, float initialСondition, float partition)
        {
            int overalSteps = (int)((endXPoint - startXPoint) / partition);
            var step = partition;
            step = (float)Math.Round(step * 100f) / 100f; // Round
            float y0 = 0f;

            X = startXPoint;
            Y = initialСondition;

            XList.Add(X);
            YList.Add(Y);
            IDeal.Add(Ideal(1.8f, 0.3f, 1f, startXPoint));
            Console.WriteLine(y0);
            for (int i = 0; i < overalSteps; i++)
            {
                Y += step * F(X, Y);
                YList.Add(Y);

                X += (float)Math.Round(step * 100f) / 100f;  // Round
                XList.Add((float)Math.Round(X * 100f) / 100f);  // Round
                IDeal.Add(Ideal(1.8f, 0.3f, 1f, X));
            }

            return (XList, YList, IDeal);
        }

        private float F(float x, float y)
        {
            return (1.8f * y) - (0.3f * (float)Math.Pow(y,2));
        }

        private float Ideal(float a, float b, float y0, float t)
        {
            float at = a * t;
            float epow = (float)Math.Pow(Math.E, at);
            var result = (a * y0 * epow) / (a + b * y0 * (epow - 1));
            return result;
        }
    }
}
