using System;
using System.Linq;

namespace Tink3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] firstCards = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
            int[] winCards = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

            if(n == 1)
            {
                if (firstCards[0] == winCards[0])
                {
                    Console.WriteLine("YES");
                    return;
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            for (int i=0; i<n; i++)
            {
                for(int j=i+1; j<n; j++)
                {
                    int[] temp = new int[n];
                    Array.Copy(firstCards,temp,n);
                    Array.Sort(temp, i, j - i);
                    if (Enumerable.SequenceEqual(temp, winCards))
                    {
                        Console.WriteLine("YES");
                        return;
                    }
                }
            }
            Console.WriteLine("NO");
        }
    }
}
