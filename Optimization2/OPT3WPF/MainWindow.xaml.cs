using Google.OrTools.LinearSolver;
using System.Security.AccessControl;
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

namespace OPT3WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Solver solver = new Solver("SimplexSolver", Solver.OptimizationProblemType.GLOP_LINEAR_PROGRAMMING);


            //solver.SetSolverSpecificParametersAsString("simplex_dual:true");


            // Создание переменных решения
            Variable x1 = solver.MakeNumVar(0, double.PositiveInfinity, "x1");
            Variable x2 = solver.MakeNumVar(0, double.PositiveInfinity, "x2");
            Variable x3 = solver.MakeNumVar(0, double.PositiveInfinity, "x3");
            Variable x4 = solver.MakeNumVar(0, double.PositiveInfinity, "x4");
            Variable x5 = solver.MakeNumVar(0, double.PositiveInfinity, "x5");

            // Добавление ограничений
            solver.Add(x1 + x2 + 4 * x3 + 4 * x4 + 3 * x5 <= 3);
            solver.Add(x1 - x2 - 2 * x3 + 2 * x4 + 5 * x5 <= 1);

            // Определение целевой функции для максимизации
            Objective objective = solver.Objective();
            objective.SetMaximization();
            objective.SetCoefficient(x1, 1);
            objective.SetCoefficient(x2, -1);
            objective.SetCoefficient(x3, 1);
            objective.SetCoefficient(x4, -1);
            objective.SetCoefficient(x5, 1);

            // Решение задачи ЛП
            solver.Solve();

            // Вывод результатов
            TextBoxRes.Text = "";
            TextBoxRes.Text += "Objective value = " + objective.Value() + "\n";
            TextBoxRes.Text += "x1 = " + x1.SolutionValue() + "\n";
            TextBoxRes.Text += "x2 = " + x2.SolutionValue() + "\n";
            TextBoxRes.Text += "x3 = " + x3.SolutionValue() + "\n";
            TextBoxRes.Text += "x4 = " + x4.SolutionValue() + "\n";
            TextBoxRes.Text += "x5 = " + x5.SolutionValue() + "\n";
            //TextBoxRes.Text += "x1 = " + x1.SolutionValue() + "\n";
        }
    }
}