using Google.OrTools.LinearSolver;
using System.Security.AccessControl;

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
solver.Add(4 * xA + 3 * xB + 5 * xC + 4 * xD <= 140);

// Ограничение по площади
solver.Add(3 * xA + 8 * xB + 6 * xC + 5 * xD <= 200);

// Решение задачи
solver.Solve();

// Вывод результатов
Console.WriteLine("Результаты оптимизации:");
Console.WriteLine(objective.Value());
Console.WriteLine($"Тип A: {xA.SolutionValue()}");
Console.WriteLine($"Тип B: {xB.SolutionValue()}");
Console.WriteLine($"Тип C: {xC.SolutionValue()}");
Console.WriteLine($"Тип D: {xD.SolutionValue()}");
Console.ReadLine();

Solver solver2 = new Solver("Производственная задача", Solver.OptimizationProblemType.GLOP_LINEAR_PROGRAMMING);

// Определяем переменные
Variable x12 = solver2.MakeNumVar(0.0, 10, "x12");
Variable x22 = solver2.MakeNumVar(0.0, 0, "x22");

// Определяем целевую функцию для максимизации
Objective objective2 = solver2.Objective();
objective2.SetMaximization();
objective2.SetCoefficient(x12, 12);
objective2.SetCoefficient(x22, 4);

// Определяем ограничения
Constraint constraint1 = solver2.MakeConstraint(double.NegativeInfinity, 310);
constraint1.SetCoefficient(x12, 1);
constraint1.SetCoefficient(x22, 2);

Constraint constraint2 = solver2.MakeConstraint(double.NegativeInfinity, 120);
constraint2.SetCoefficient(x12, 1);
constraint2.SetCoefficient(x22, 3);

Constraint constraint3 = solver2.MakeConstraint(double.NegativeInfinity, 450);
constraint3.SetCoefficient(x12, 2);
constraint3.SetCoefficient(x22, 3);


// Решаем задачу
solver2.Solve();

// Выводим результаты
Console.WriteLine($"Оптимальное количество товара 1: {x12.SolutionValue()}");
Console.WriteLine($"Оптимальное количество товара 2: {x22.SolutionValue()}");
Console.WriteLine($"Максимальная прибыль: {objective2.Value()}");
Console.ReadLine();

Solver solver3 = new Solver("LinearProgrammingExample", Solver.OptimizationProblemType.GLOP_LINEAR_PROGRAMMING);

// Определение переменных
Variable xA3 = solver3.MakeIntVar(2, 2, "xA");
Variable xB3 = solver3.MakeIntVar(3, 3, "xB");
Variable xC3 = solver3.MakeIntVar(0, int.MaxValue, "xC");

xA3.SetInteger(true);
xB3.SetInteger(true);
xC3.SetInteger(true);

// Определение целевой функции
Objective objective3 = solver3.Objective();
objective3.SetMinimization();
objective3.SetCoefficient(xA3, 31);
objective3.SetCoefficient(xB3, 23);
objective3.SetCoefficient(xC3, 26);


// Ограничение по бюджету
solver3.Add(310 * xA3 + 240 * xB3 + 300 * xC >= 800);

// Ограничение по площади
solver3.Add(170* xA3 + xB3* 120 + xC3 * 110 >= 700);

solver3.Add(xA3 * 380+xB3 * 440+ xC3 * 450 >= 900);


// Решение задачи
solver3.Solve();

// Вывод результатов
Console.WriteLine("Результаты оптимизации:");
Console.WriteLine(objective3.Value());
Console.WriteLine($"Тип A: {xA3.SolutionValue()}");
Console.WriteLine($"Тип B: {xB3.SolutionValue()}");
Console.WriteLine($"Тип C: {xC3.SolutionValue()}");
Console.ReadLine();

