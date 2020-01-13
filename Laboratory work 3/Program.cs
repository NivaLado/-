using System;

namespace Lab_3_NonLinearEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            double PreviousX;
            int iterations = 0;

            Console.WriteLine("Enter initial approximation");
            input = Console.ReadLine();

            double CurrentX = Convert.ToInt32(input);

            Console.WriteLine($"X0 = {CurrentX}");
            double dX = double.MaxValue;

            while (Math.Abs(dX) > 1e-4)
            {
                PreviousX = CurrentX;
                CurrentX = F2(PreviousX);
                dX = CurrentX - PreviousX;
                iterations++;
            }

            Console.WriteLine($"Iterations = {iterations}");
            Console.WriteLine($"X = {CurrentX}");
            Console.ReadLine();
        }

        static double F (double x)
        {
            return (x * x + 4) / 5;
        }


        // X * e^X/2 = 4
        // Приводим к x
        static double F2 (double x)
        {
            return 4 / (Math.Pow(Math.E, x / 2));
        }
    }
}
