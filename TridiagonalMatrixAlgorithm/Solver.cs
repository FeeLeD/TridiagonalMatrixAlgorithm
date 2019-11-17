using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TridiagonalMatrixAlgorithm
{
    class Solver
    {
        private double[,] Matrix;
        public Solver(double [,] matrix)
        {
            Matrix = matrix;
        }
        public double[] GetSolution()
        {
            var answers = new double[4];
            var coefficients = new double[4, 2];
            double y, alpha, beta, a = Double.MinValue, b, c, d; //'a' дано значение, чтобы не ругался
            for (var str = 0; str < 4; str++)
            {
                if (str != 0) 
                    a = Matrix[str, str - 1];
                b = Matrix[str, str];
                c = Matrix[str, str + 1];
                d = Matrix[str, 4];

                if (str == 0)
                {
                    y = b;
                    alpha = -c / y;
                    beta = d / y;
                    coefficients[str, 0] = alpha;
                    coefficients[str, 1] = beta;
                }
                else if (str == 3)
                {
                    y = b + a * coefficients[str - 1, 0];
                    beta = (d - a * coefficients[str - 1, 1]) / y;
                    coefficients[str, 1] = beta;
                }
                else
                {
                    y = b + a * coefficients[str - 1, 0];
                    alpha = -c / y;
                    beta = (d - a * coefficients[str - 1, 1]) / y;
                    coefficients[str, 0] = alpha;
                    coefficients[str, 1] = beta;
                }
            }

            for (var str = 3; str >= 0; str--)
            {
                if (str == 3)
                    answers[str] = coefficients[str, 1];
                else
                    answers[str] = coefficients[str, 0] * answers[str + 1] + coefficients[str, 1];
            }

            if (AreAnswersCorrect(answers))
                return answers;
            else
                return null;
        }

        private bool AreAnswersCorrect(double[] answers)
        {
            double a, b, c, d, r;
            for (var str = 0; str < 4; str++)
            {
                b = Matrix[str, str];
                d = Matrix[str, 4];

                if (str == 0) 
                {
                    c = Matrix[str, str + 1];
                    r = Math.Round((d - b * answers[str] - c * answers[str + 1]), 5);
                } 
                else if (str == 3)
                {
                    a = Matrix[str, str - 1];
                    r = Math.Round((d - (a * answers[str - 1] + b * answers[str])), 5);
                }
                else
                {
                    a = Matrix[str, str - 1];
                    c = Matrix[str, str + 1];
                    r = Math.Round((d - a * answers[str - 1] - b * answers[str] - c * answers[str + 1]), 5);
                }

                if (r != 0)
                    return false;
            } 
            return true;
        }

    }
}
