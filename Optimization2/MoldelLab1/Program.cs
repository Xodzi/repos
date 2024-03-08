using System.Data;
using Google.OrTools.LinearSolver;

Solver solver = new Solver("LinearProgrammingExample", Solver.OptimizationProblemType.GLOP_LINEAR_PROGRAMMING);

// Определение переменных
Variable xA = solver.MakeNumVar(0.0, double.PositiveInfinity, "xA");
Variable xB = solver.MakeNumVar(0.0, double.PositiveInfinity, "xB");
Variable xC = solver.MakeNumVar(0.0, double.PositiveInfinity, "xC");
Variable xD = solver.MakeNumVar(0.0, double.PositiveInfinity, "xD");

// Определение целевой функции
Objective objective = solver.Objective();
objective.SetMaximization();
objective.SetCoefficient(xA, 3);
objective.SetCoefficient(xB, 2);
objective.SetCoefficient(xC, 4);
objective.SetCoefficient(xD, 5);

// Ограничение по бюджету
Constraint budgetConstraint = solver.MakeConstraint(0.0, 140.0);
budgetConstraint.SetCoefficient(xA, 4);
budgetConstraint.SetCoefficient(xB, 3);
budgetConstraint.SetCoefficient(xC, 5);
budgetConstraint.SetCoefficient(xD, 4);

// Ограничение по площади
Constraint areaConstraint = solver.MakeConstraint(0.0, 200.0);
areaConstraint.SetCoefficient(xA, 3);
areaConstraint.SetCoefficient(xB, 8);
areaConstraint.SetCoefficient(xC, 6);
areaConstraint.SetCoefficient(xD, 5);

// Решение задачи
solver.Solve();

// Вывод результатов
Console.WriteLine("Результаты оптимизации:");
Console.WriteLine($"Тип A: {xA.SolutionValue()}");
Console.WriteLine($"Тип B: {xB.SolutionValue()}");
Console.WriteLine($"Тип C: {xC.SolutionValue()}");
Console.WriteLine($"Тип D: {xD.SolutionValue()}");
Console.ReadLine();

// Закрытие солвера
solver.Dispose();