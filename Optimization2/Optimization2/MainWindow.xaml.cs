using Google.OrTools.LinearSolver;
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

namespace Optimization2
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Solver solver = new Solver("SimplexSolver", Solver.OptimizationProblemType.GLOP_LINEAR_PROGRAMMING);
            Variable x1 = solver.MakeNumVar(0, double.PositiveInfinity, "x1");
            Variable x2 = solver.MakeNumVar(0, double.PositiveInfinity, "x2");
            Variable x3 = solver.MakeNumVar(0, double.PositiveInfinity, "x3");

            // Создание целевой функции
            Objective objective = solver.Objective();
            objective.SetCoefficient(x1, 1.08);
            objective.SetCoefficient(x2, 1.12);
            objective.SetCoefficient(x3, 1.28);
            objective.SetMaximization();

            // Добавление ограничений
            solver.Add(x1 * 0.6 + x2 * 0.5 + x3 * 0.6 <= 800);
            solver.Add(x1 * 0.4 + x2 * 0.4 + x3 * 0.3 <= 600);
            solver.Add(x1 * 0.1 + x2 * 0.2 + x3 * 0.2 <= 120);

            // Решение задачи
            Solver.ResultStatus resultStatus = solver.Solve();

            // Вывод результатов
            if (resultStatus == Solver.ResultStatus.OPTIMAL)
            {
                TextBoxResult.Text = "Прибыль: " + (int)objective.Value() + '\n' + "x1: " + (int)x1.SolutionValue() + '\n' + "x2: " + x2.SolutionValue() + '\n' + "x3: " + x3.SolutionValue();
            }
            else
            {
                TextBoxResult.Text = "Нет решения";
            }
            

            Solver solver2 = new Solver("SimplexSolver2", Solver.OptimizationProblemType.GLOP_LINEAR_PROGRAMMING);
            Variable x11 = solver2.MakeNumVar(0, double.PositiveInfinity, "x1");
            Variable x22 = solver2.MakeNumVar(0, double.PositiveInfinity, "x2");
            Variable x33 = solver2.MakeNumVar(0, double.PositiveInfinity, "x3");

            // Создание целевой функции
            Objective objective2 = solver2.Objective();
            objective2.SetCoefficient(x11, 1.20);
            objective2.SetCoefficient(x22, 1.34);
            objective2.SetCoefficient(x33, 1.40);
            objective2.SetMaximization();

            // Добавление ограничений
            solver2.Add(x11 * 0.6 + x22 * 0.5 + x33 * 0.6 <= 400);
            solver2.Add(x11 * 0.4 + x22 * 0.4 + x33 * 0.3 <= 400);
            solver2.Add(x11 * 0.1 + x22 * 0.2 + x33 * 0.2 <= 250);

            // Решение задачи
            Solver.ResultStatus resultStatus2 = solver2.Solve();

            // Вывод результатов
            TextBoxResult.Text += "\nВторой вариант:\n";
            if (resultStatus == Solver.ResultStatus.OPTIMAL)
            {
                TextBoxResult.Text += "Прибыль: " + (int)objective2.Value() + '\n' + "x1: " + (int)x11.SolutionValue() + '\n' + "x2: " + (int)x22.SolutionValue() + '\n' + "x3: " + x33.SolutionValue();
            }
            else
            {
                TextBoxResult.Text = "Нет решения";
            }

            Solver solver3 = new Solver("SimplexSolver2", Solver.OptimizationProblemType.GLOP_LINEAR_PROGRAMMING);
            Variable x111 = solver3.MakeNumVar(0, double.PositiveInfinity, "x1");
            Variable x222 = solver3.MakeNumVar(0, double.PositiveInfinity, "x2");
            Variable x333 = solver3.MakeNumVar(0, double.PositiveInfinity, "x3");

            // Создание целевой функции
            Objective objective3 = solver3.Objective();
            objective3.SetCoefficient(x111, 1.0);
            objective3.SetCoefficient(x222, 1.10);
            objective3.SetCoefficient(x333, 1.18);
            objective3.SetMaximization();

            // Добавление ограничений
            solver3.Add(x111 * 0.6 + x222 * 0.5 + x333 * 0.6 <= 300);
            solver3.Add(x111 * 0.4 + x222 * 0.4 + x333 * 0.3 <= 400);
            solver3.Add(x111 * 0.1 + x222 * 0.2 + x333 * 0.2 <= 100);

            // Решение задачи
            Solver.ResultStatus resultStatus22 = solver3.Solve();

            // Вывод результатов
            TextBoxResult.Text += "\nТретьий вариант:\n";
            if (resultStatus == Solver.ResultStatus.OPTIMAL)
            {
                TextBoxResult.Text += "Прибыль: " + (int)objective3.Value() + '\n' + "x1: " + (int)x111.SolutionValue() + '\n' + "x2: " + (int)x222.SolutionValue() + '\n' + "x3: " + x333.SolutionValue();
            }
            else
            {
                TextBoxResult.Text = "Нет решения";
            }
        }
    }
}