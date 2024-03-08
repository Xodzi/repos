using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

//Console.WriteLine(calculate("1 + 2"));
Console.WriteLine(formatDuration(120));


static double calculate(string s)
{
    //s.Replace(" ", string.Empty);
    double first = 0;
    double second = 0;
    double res = 0;
    bool flag = false;
    char[] arr = s.ToCharArray();
    for(int i=0; i < arr.Length; i++)
    {
        if (Char.IsWhiteSpace(arr[i])) continue;
        if (Char.IsDigit(arr[i]))
        {
            if (!flag)
            {
                first = Double.Parse(Convert.ToString(arr[i]));
                flag = true;
            }
            else
            {
                second = Double.Parse(Convert.ToString(arr[i]));
            }
        }
        else
        {
            switch (arr[i])
            {
                case'/':
                    res += first / second;
                    flag = false;
                    break;
                case'*':
                    res += first * second;
                    flag = false;
                    break;
                case '+':
                    res += first + second;
                    flag = false;
                    break;
                case '-':
                    res += first - second;
                    flag = false;
                    break;
                case '^':
                    res += Math.Pow(first, second);
                    flag = false;
                    break;
            }
        }
    } 
    return res;
}

static int[] Snail(int[][] array)
{
    List<int> res = new List<int>();
    for(int j=0;j<array.GetLength(1); j++)
    {
        res.Add(array[0][j]);
    }
    for (int j = 0; j < array.GetLength(0); j++)
    {
        res.Add(array[j][array.GetLength(1)]);
    }



    return res.ToArray();
}

static string formatDuration(int seconds)
{
    if (seconds == 0) return "now";
    StringBuilder sb = new StringBuilder();
    int minutes = 0, hours = 0, days = 0, years = 0;
    while(seconds > 59)
    {
        minutes++;
        seconds -= 60;
    }
    if(minutes > 0)
    {
        if(minutes==1) sb.Append($"{minutes} minute and {seconds} seconds");
        else sb.Append($"{minutes} minutes and {seconds} seconds");
    }
    else
    {
        return $"{seconds} seconds";
    }
    while(minutes > 59)
    {
        hours++;
        minutes -= 60;
    }
    if(hours > 0)
    {
        if(hours==1) sb.Insert(0,$"{hours} hour");
        else sb.Insert(0, $"{hours} hour");
    }
    else
    {
        return sb.ToString();
    }


    return sb.ToString();
}