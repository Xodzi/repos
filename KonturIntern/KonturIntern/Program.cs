//var tokens = Console.ReadLine().Split();
//var N  = int.Parse(tokens[0]);
//var M = int.Parse(tokens[1]);
//if(N == M)
//{
//    Console.WriteLine(2*M+N);
//    return;
//}
//var lenght = 0;
//var min = Math.Min(N,M);
//if(min == N)
//{
//    Console.WriteLine(N+2*N+2);
//    return;
//}
//else
//{
//    Console.WriteLine(2*M+M+1);
//}

//using System.Text;

//var count = int.Parse(Console.ReadLine());
//var tokens = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
//var sum = 0;
//int temp_sum = tokens.Sum();
//for (int i = 0; i < tokens.Length; i++)
//{
//    sum += tokens[i];
//    temp_sum -= tokens[i];
//    if (sum == temp_sum)
//    {
//        StringBuilder sb = new StringBuilder();
//        for (int z = 0; z < i + 1; z++)
//        {
//            sb.Append(tokens[z]);
//            sb.Append("+");
//        }
//        sb.Length--;
//        sb.Append("=");
//        for (int y = i + 1; y < tokens.Length; y++)
//        {
//            sb.Append(tokens[y]);
//            sb.Append("+");
//        }
//        sb.Length--;
//        Console.WriteLine(sb.ToString());
//        return;
//    }
//}
//Console.WriteLine(-1);


//var size = Console.ReadLine().Split().ToList();
//var count_command = int.Parse(Console.ReadLine());
//string[] commands_line = new string[count_command];
//for (int i = 0; i < count_command; i++)
//{
//    commands_line[i] = Console.ReadLine();
//}

//int[,] matrix = new int[int.Parse(size[0]), int.Parse(size[1])];
//var prev_command = "";
//for (int i = 0; i < commands_line.Length; i++)
//{
//    if (prev_command.Equals(commands_line[i])) continue;

//    var command = commands_line[i].Split().ToList();
//    var row = int.Parse(command[0]) - 1;
//    var column = int.Parse(command[1]) - 1;
//    var color = int.Parse(command[2]);

//    for (int j = 0; j < matrix.GetLength(1); j++)
//    {
//        matrix[row, j] = color;
//    }
//    for (int j = 0; j < matrix.GetLength(0); j++)
//    {
//        matrix[j, column] = color;
//    }
//    prev_command = commands_line[i];
//}

//for (int i = 0; i < matrix.GetLength(0); i++)
//{
//    for (int j = 0; j < matrix.GetLength(1); j++)
//    {
//        Console.Write("{0} ", matrix[i, j]);
//    }
//    Console.WriteLine();
//}

int[,] matrix = new int[1000, 1000];
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write("{0} ", matrix[i, j]);
    }
    Console.WriteLine();
}

List<Tuple<int, char>> substrings = new List<Tuple<int, char>>();
string input = "BRGBBRR";
for (int i = 0; i < input.Length; i++)
{
    char currentChar = input[i].ToString()[0];
    var lenght = 1;
    //string substring = currentChar.ToString();

    for (int j = i + 1; j < input.Length; j++)
    {
        char nextChar = input[j].ToString()[0];

        if (nextChar == currentChar)
        {
            lenght++;
            //substring += nextChar;
        }
        else
        {
            substrings.Add(new Tuple<int, char>(lenght, currentChar));
            break;
        }
    }

}
