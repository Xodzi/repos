string[] input = Console.ReadLine().Split(' ');
int n = int.Parse(input[0]);
int s = int.Parse(input[1]);
string[] input2 = Console.ReadLine().Split(' ');
int maxprice = 0;
for (int i = 0;i < n; i++)
{
    int current_price = int.Parse(input2[i]);
    if (s >= current_price && maxprice < current_price)
    {
        maxprice= current_price;
    }
}
Console.WriteLine(maxprice);