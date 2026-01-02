// See https://aka.ms/new-console-template for more information



Span<MutableStruct> spanStructs = new MutableStruct[1];
List<MutableStruct> listStructs = new List<MutableStruct>() { new MutableStruct() };

spanStructs[0] = listStructs[0];
listStructs[0].Value = 0;

var arr = new byte[10];

Span<byte> bytes = arr;
bytes[0] = 10;

Console.ReadLine();

struct MutableStruct
{
    public int Value;
}