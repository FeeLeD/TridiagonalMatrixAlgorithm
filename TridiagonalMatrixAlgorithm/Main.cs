using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TridiagonalMatrixAlgorithm
{
    public partial class Main : Form
    {
        private double[,] Matrix;
        public Main()
        {
            Matrix = new double[4, 5];
            InitializeComponent();
        }

        private void SolveBtn_Click(object sender, EventArgs e)
        {
            FillTheMatrix();
            var solver = new Solver(Matrix);
            var answers = solver.GetSolution();
            if (answers != null)
                ShowAnswers(answers);
            else
                ShowWarning();
        }

        private void FillTheMatrix()
        {
            var coefficient = new StringBuilder();
            var number = 0.0;
            for (var i = 0; i < 4; i++)
            {
                coefficient.Append("x");
                coefficient.Append(i.ToString());
                for (var j = 0; j < 5; j++) 
                {
                    coefficient.Append(j.ToString());
                    if (!double.TryParse(this.Controls[coefficient.ToString()].Text.Replace('.', ','), out number))
                        number = 0.0;
                    Matrix[i, j] = number;
                    coefficient.Remove(2, 1); //очистка номера столбца
                }
                coefficient.Clear();
            }
        }

        private void ShowAnswers(double[] answers)
        {
            w0.Hide();
            w1.Hide();
            w2.Hide();
            w3.Hide();

            a0.Text = Math.Round(answers[0], 5).ToString();
            a1.Text = Math.Round(answers[1], 5).ToString();
            a2.Text = Math.Round(answers[2], 5).ToString();
            a3.Text = Math.Round(answers[3], 5).ToString();
        }

        private void ShowWarning()
        {
            w0.Visible = Visible;
            w1.Visible = Visible;
            w2.Visible = Visible;
            w3.Visible = Visible;
        }
    }
}
