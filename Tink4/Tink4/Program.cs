using System;
using System.Linq;

namespace Tink4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            int[] denominations = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .OrderByDescending(x => x)
            .ToArray();

            int target = n * 2; // Джо хочет украсть n долларов, поэтому цель удвоена

            for (int i = 0; i < m; i++)
            {
                int count = target / denominations[i]; // Сколько купюр текущего номинала можно взять
                target -= Math.Min(count, 2) * denominations[i]; // Вычтем взятые купюры из цели
            }

            if (target == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
