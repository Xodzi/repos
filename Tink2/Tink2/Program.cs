using System;
using System.Collections.Generic;

namespace Tink2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string word = "sheriff";
            Dictionary<char, int> wordLetter = new Dictionary<char, int> { { 's', 1 }, { 'h', 1 }, { 'e', 1 }, {'r', 1 }, { 'i', 1 }, { 'f', 2 } };
            Dictionary<char, int> inputLetter = new Dictionary<char, int>();
            char[] chars = s.ToCharArray();
            foreach(char c in chars)
            {
                if (inputLetter.ContainsKey(c))
                {
                    inputLetter[c]++;
                }
                else
                {
                    inputLetter[c] = 1;
                }
            }
            int max = -1;
            foreach(var elem in wordLetter)
            {
                char letter = elem.Key;
                int count = elem.Value;
                if(inputLetter.ContainsKey(letter))
                {
                    int possible = inputLetter[letter] / count;
                    if(max == -1 || possible < max)
                    {
                        max = possible;
                    }
                }
                else
                {
                    max = 0;
                    break;
                }
            }
            Console.WriteLine(max);
        }
    }
}
