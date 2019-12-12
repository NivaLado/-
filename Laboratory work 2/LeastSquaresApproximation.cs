using System;
using System.Collections.Generic;
using System.Text;

namespace LeastSquaresApproximation
{
    public class LeastSquaresApproximation
    {
        public double[,] CreateEquationMatrix(double[,] xyTable, int basis)
        {
            double[,] matrix = new double[basis, basis + 1];

            for (int i = 0; i < basis; i++)
            {
                for (int j = 0; j < basis; j++)
                {
                    double sumA = 0, Y = 0;

                    for (int k = 0; k < xyTable.Length / 2; k++)
                    {
                        sumA += Math.Pow(xyTable[0, k], i) * Math.Pow(xyTable[0, k], j); // A = x^n * x^n
                        Y += xyTable[1, k] * Math.Pow(xyTable[0, k], i); // Y = y * x^n
                    }

                    matrix[i, Math.Abs(j - basis + 1)] = sumA;
                    matrix[i, basis] = Y;
                }
            }

            return matrix;
        }
    }
}
