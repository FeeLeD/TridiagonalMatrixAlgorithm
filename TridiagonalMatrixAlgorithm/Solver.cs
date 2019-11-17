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

            return answers;
        }

    }
}
