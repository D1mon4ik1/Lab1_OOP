using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _1
{
    public partial class Lab_1 : Form
    {
        public Lab_1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Завдання 1
            nameX.Text = "x = ";
            nameResult.Text = "Результат: ";
            btnResult.Text = "Порахувати";
            txtResult.Text = " ";

            //Завдання 2
            nameD.Text = "Довжина кола = ";
            nameS.Text = "Площа круга: ";
            btnS.Text = "Порахувати";
            resultS.Text = " ";

            //Завдання 3
            nameN.Text = "N = ";
            nameResultN.Text = "Натуральне число N \nє точним квадратом: ";
            btnN.Text = "Порахувати";
            txtResultN.Text = " ";

            //Завдання 4
            nameA.Text = "a = ";
            nameB.Text = "b = ";
            nameResultAB.Text = "Розв'язки рівняння: ";
            btnAB.Text = "Порахувати";
            txtResultAB.Text = " ";

            //Завдання 5
            nameNumber.Text = "n = ";
            nameResultNumber.Text = "Числа: ";
            btnNumber.Text = "Порахувати";
            resultNumber.Text = "";

            //Завдання 6
            nameNum.Text = "n = ";
            nameBuyer.Text = "i = ";
            btnTime.Text = "Порахувати";
            txtTime.Text = "";

            //Завдання 7
            nameText.Text = "Текст: ";
            nameResultText.Text = "Слова, які\nмістять букву К:";
            btnText.Text = "Знайти";
            resultText.Text = "";
        }

        //Завдання 1
        private void btnResult_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtX.Text))
            {
                MessageBox.Show("Будьласка, введіть цифру");
                return;
            }
            double x = Convert.ToDouble(txtX.Text);
            double result = Math.Abs(Math.Pow(x, 2) - Math.Pow(x, 3)) - ((7 * x) / (Math.Pow(x, 3) - 15 * x)); ;
            txtResult.Text = result.ToString("F2");            
        }

        private void txtX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == ',')
            {
                return;
            }
            e.Handled = true;
        }

        //Завдання 2
        private void btnS_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtD.Text))
            {
                MessageBox.Show("Будьласка, введіть цифру");
                return;
            }
            double d = Convert.ToDouble(txtD.Text);
            double results = Math.PI * Math.Pow(d / (2 * Math.PI), 2);
            resultS.Text = results.ToString("F2");
        }

        private void txtD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == ',')
            {
                return;
            }
            e.Handled = true;
        }

        //Завдання 3
        private void btnN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtN.Text))
            {
                MessageBox.Show("Будьласка, введіть цифру");
                return;
            }
            double n1 = Convert.ToDouble(txtN.Text);
            bool resultN = IsPerfectSquare(n1);
            txtResultN.Text = resultN.ToString();            
        }
        static bool IsPerfectSquare(double number)
        {
            double resuntN = Math.Sqrt(number);
            return resuntN % 1 == 0;
        }

        private void txtN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == ',')
            {
                return;
            }
            e.Handled = true;
        }

        //Завдання 4
        private void btnAB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtA.Text))
            {
                MessageBox.Show("Будьласка, введіть цифру");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtB.Text))
            {
                MessageBox.Show("Будьласка, введіть цифру");
                return;
            }
            try
            {
                double a = double.Parse(txtA.Text);
                double b = double.Parse(txtB.Text);

                List<string> solutions = SolveEquation(a, b);

                string solutionString = "";
                foreach (string solution in solutions)
                {
                    solutionString += solution + "\n";
                }

                txtResultAB.Text = solutionString;
            }
            finally
            {
                txtResultAB.Focus();
            }
        }

        private List<string> SolveEquation(double a, double b)
        {
            List<string> solutions = new List<string>();

            if (a == 0)
            {
                solutions.Add("x = 0");
            }
            else
            {
                double discriminant = (Math.Pow(b, 2) * Math.Pow(a, 2) * (3 * b * Math.Pow(a, 2) - 4 * Math.Pow(b, 3))) / Math.Pow(a, 3);

                if (discriminant >= 0)
                {
                    double x1 = 0;
                    double x2 = Math.Sqrt((-b + Math.Sqrt(discriminant)) / (2 * a));
                    double x3 = -Math.Sqrt((-b + Math.Sqrt(discriminant)) / (2 * a));

                    solutions.Add($"x1 = {x1}");
                    solutions.Add($"x2 = {x2:F5}");
                    solutions.Add($"x3 = {x3:F5}");
                }
                else
                {
                    solutions.Add("Немає дійсних \nрозв'язків");
                }
            }
            return solutions;
        }
        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == ',')
            {
                return;
            }
            e.Handled = true;
        }

        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == ',')
            {
                return;
            }
            e.Handled = true;
        }

        //Завдання 5
        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                MessageBox.Show("Будьласка, введіть цифру");
                return;
            }
            int n = Convert.ToInt32(txtNumber.Text);
            List<int> result = FindNumbers(n);
            resultNumber.Text = "";
            int count = 0;
            foreach (int num in result)
            {
                resultNumber.Text += num.ToString() + ", ";
                count++;

                if (count == 10)
                {
                    resultNumber.Text += "\n";
                    count = 0;
                }
            }
        }
        static bool DividesByAllDigits(int num)
        {
            int originalNum = num;
            while (num > 0)
            {
                int digit = num % 10;
                if (digit == 0 || originalNum % digit != 0)
                {
                    return false;
                }
                num /= 10;
            }
            return true;
        }
        static List<int> FindNumbers(int n)
        {
            List<int> result = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                if (DividesByAllDigits(i))
                {
                    result.Add(i);
                }
            }
            return result;
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == ',')
            {
                return;
            }
            e.Handled = true;
        }

        //Завдання 6
        private void btnTime_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNum.Text))
            {
                MessageBox.Show("Будьласка, введіть цифру");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtBuyer.Text))
            {
                MessageBox.Show("Будьласка, введіть цифру");
                return;
            }
            int num = Convert.ToInt32(txtNum.Text);
            int buyer = Convert.ToInt32(txtBuyer.Text);
            int queueTime = CalculateQueueTime(buyer);
            txtTime.Text = $"Час перебування в черзі для {buyer} \nпокупця з {num} покупців: {queueTime} хв.";            
        }
        private int CalculateQueueTime(int buyer)
        {
            int queueTime = 0;
            for (int i = 1; i <= buyer; i++)
            {
                queueTime += i;
            }
            return queueTime;
        }
        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == ',')
            {
                return;
            }
            e.Handled = true;
        }

        private void txtBuyer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == ',')
            {
                return;
            }            
            e.Handled = true;
        }

        //Завдання 7
        private void btnText_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtText.Text))
            {
                MessageBox.Show("Будьласка, введіть рядок");
                return;
            }
            string input = txtText.Text;
            string[] words = input.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            resultText.Items.Clear();

            foreach (string word in words)
            {
                if (word.Contains('к') || word.Contains('К'))
                {
                    resultText.Items.Add(word);
                }
            }
        }
                
    }

}
