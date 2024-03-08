// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Calculator calculator= new Calculator();
while (true)
{
    Console.Clear();
    Console.WriteLine("0 - выход \n 1 - сложение \n 2 - вычитание \n 3 - умножение \n 4 - деление");
    try
    {
        switch (Convert.ToInt32(Console.ReadLine()))
        {
            case 0: return;
            case 1: Console.WriteLine("Результат = " + calculator.Plus(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()))); break;
            case 2: Console.WriteLine("Результат = " + calculator.Minus(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()))); break;
            case 3: Console.WriteLine("Результат = " + calculator.Multi(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()))); break;
            case 4: Console.WriteLine("Результат = " + calculator.Division(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()))); break;
        }
        Console.ReadKey();
    }
    catch
    {
        Console.WriteLine("Некорректный ввод");
        Console.ReadKey();
    }
}

public class Calculator
{
    public double Plus(double x, double y)
    {
        return x + y;
    }
    public double Minus(double x, double y)
    {
        return x - y;
    }
    public double Multi(double x, double y)
    {
        return x * y;
    }
    public double Division(double x, double y)
    {
        return x / y;
    }

}