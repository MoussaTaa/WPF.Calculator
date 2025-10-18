using System.Data;
using System.Linq.Expressions;
using System.Security.Permissions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calcWPF
{

    public partial class MainWindow : Window
    {
        string equation = "";
        double result;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            this.MouseDown += delegate
            {
                DragMove();
            };
        }

        public void addToEquation(string value)
        {
            equation += value;
            lblEquation.Content = equation;
        }
        public void addOperatorToEquation(string op) {
            if (equation == "")
            {
                addToEquation(result.ToString());
                addToEquation(op);
            }
            else if (containOperator())
            {

                equation = equation.Remove(equation.Length - 1);
                addToEquation(op);
            }
            else
            {
                addToEquation(op);
            }
        }
        public bool containOperator() 
        {
            bool isContainOperator = false;
            char lastChar = equation[equation.Length - 1];
            if (lastChar == '+' || lastChar == '*' || lastChar == '-' || lastChar == '/' )
            {
                isContainOperator = true;
            }
            return isContainOperator;
        }
        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            addToEquation("0");
        }

        private void btnOne_Click(object sender, RoutedEventArgs e)
        {
            addToEquation("1");
        }

        private void btnTwo_Click(object sender, RoutedEventArgs e)
        {
            addToEquation("2");
        }

        private void btnThree_Click(object sender, RoutedEventArgs e)
        {
            addToEquation("3");
        }

        private void btnFour_Click(object sender, RoutedEventArgs e)
        {
            addToEquation("4");
        }

        private void btnFive_Click(object sender, RoutedEventArgs e)
        {
            addToEquation("5");
        }

        private void btnSix_Click(object sender, RoutedEventArgs e)
        {
            addToEquation("6");
        }

        private void btnSeven_Click(object sender, RoutedEventArgs e)
        {
            addToEquation("7");
        }

        private void btnEight_Click(object sender, RoutedEventArgs e)
        {
            addToEquation("8");
        }

        private void btnNine_Click(object sender, RoutedEventArgs e)
        {
            addToEquation("9");
        }

        private void btnPoint_Click(object sender, RoutedEventArgs e)
        {
            addToEquation(".");
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            addOperatorToEquation("+");
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            addOperatorToEquation("-");
        }

        private void btnMultiplication_Click(object sender, RoutedEventArgs e)
        {
            addOperatorToEquation("*");
        }

        private void btnDivision_Click(object sender, RoutedEventArgs e)
        {
            addOperatorToEquation("/");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            equation = "";
            result = 0;
            lblEquation.Content = "";
            lblResult.Content = "0";
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            var equationToResult = new DataTable().Compute(equation, null);
            result = Convert.ToDouble(equationToResult);
            lblResult.Content = result.ToString();
        }
    }
}