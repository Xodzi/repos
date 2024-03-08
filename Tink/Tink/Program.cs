List<int> numbers = new List<int> { 1, 2, 3, 4 };
IEnumerable<int> squares = numbers
    .Where(x => x % 2 == 0)
    .Select(x => x * 2);

foreach (var square in squares)
{
    Console.WriteLine(square);
}
