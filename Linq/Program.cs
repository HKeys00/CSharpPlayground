// See https://aka.ms/new-console-template for more information
using Linq;

Console.WriteLine("Hello, World!");


List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
var num = numbers.Where(x => x < 8).WhereEven();

foreach( int number in num)
{
    Console.WriteLine(number);
    num = Enumerable.Range(0, 10);
}

var batches =
    Enumerable.Range(1, 10)
              .Batch(3);

foreach (var batch in batches)
{
    Console.WriteLine(string.Join(",", batch));
}