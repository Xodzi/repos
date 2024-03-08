// See https://aka.ms/new-console-template for more information
using Google.OrTools.LinearSolver;

Solver solver = new Solver("SimplexSolver", Solver.OptimizationProblemType.GLOP_LINEAR_PROGRAMMING);

// Создание переменных решения
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
    Console.WriteLine("Optimal Objective Value: " + objective.Value());
    Console.WriteLine("x1: " + x1.SolutionValue());
    Console.WriteLine("x2: " + x2.SolutionValue());
    Console.WriteLine("x3: " + x3.SolutionValue());
}
else
{
    Console.WriteLine("No optimal solution found.");
}
