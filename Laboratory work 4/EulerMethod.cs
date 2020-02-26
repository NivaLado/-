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

        public EulerMethod()
        {
            XList = new List<float>();
            YList = new List<float>();
        }

        public (List<float>, List<float>) Solve(float startXPoint, float endXPoint, float initialСondition, float partition)
        {
            int overalSteps = (int)(1 / partition);
            var step = (endXPoint - startXPoint) * partition;
            step = (float)Math.Round(step * 100f) / 100f; // Round

            X = startXPoint;
            Y = initialСondition;

            XList.Add(X);
            YList.Add(Y);

            for (int i = 0; i < overalSteps; i++)
            {
                Y += step * F(X, Y);
                YList.Add(Y);

                X += (float)Math.Round(step * 100f) / 100f;  // Round
                XList.Add((float)Math.Round(X * 100f) / 100f);  // Round
            }

            return (XList, YList);
        }

        private float F(float x, float y)
        {
            return (1.8f * y) + (0.3f * (float)Math.Pow(x,2));
        }
    }
}
