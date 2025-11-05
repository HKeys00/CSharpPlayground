// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


IEnumerable<int> CreateSimpleIterator()
{
    yield return 10;
    for (int i = 0; i < 3; i++)
    {
        yield return i;
    }
    yield return 20;
}

IEnumerable<int> enumerable = CreateSimpleIterator();
IEnumerator<int> enumerator = enumerable.GetEnumerator();

while (enumerator.MoveNext())
{
    int value = enumerator.Current;
    Console.WriteLine(value); 
}