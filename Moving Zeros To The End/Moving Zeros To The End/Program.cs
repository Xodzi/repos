// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Numerics;
using System.Text;

Console.WriteLine("Hello, World!");
int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
int[] arr1 = new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1, 0, 0 ,0, 5 };
string test = "     ";
Console.WriteLine(sumStrings("123", "456"));




static string sumStrings(string a, string b)
{
    BigInteger first = 0;
    BigInteger second = 0;
    if (!string.IsNullOrEmpty(a))
    {
        first = BigInteger.Parse(a);
    }
    if(!string.IsNullOrEmpty(b))
    {
        second = BigInteger.Parse(b);
    }
    BigInteger sum = first + second;
    return sum.ToString();
}
static bool Alphanumeric(string str)
{
    if (str.Length == 0) return false;
    char[] chars = str.ToCharArray();
    foreach(char elem in chars)
    {
        if(!char.IsLetter(elem) && !char.IsNumber(elem))
        {
            return false;
        }
    }
    return true;
}

static int[] MoveZeroes(int[] arr)
{
    for(int i=0;i < arr.Length; i++)
    {
        int tempind = i;
        if (arr[i] == 0)
        {
            for(int j=i; j < arr.Length - 1; j++)
            {
                int temp= arr[j];
                arr[j] = arr[j+1];
                arr[j+1]= temp;
            }
           tempind--;
        }
        Console.Write(string.Join(' ', arr));
        Console.WriteLine();
    }

    return arr;
}
static string CreatePhoneNumber(int[] numbers)
{
    StringBuilder sb = new StringBuilder();
    sb.Append('(');
    for(int i=0; i < numbers.Length;i++)
    {
        sb.Append(numbers[i]);
    }
    sb.Insert(4, ')');
    sb.Insert(5, ' ');
    sb.Insert(9, '-');
    Console.WriteLine(sb.ToString());
    string res = sb.ToString();
    return res;
}