// See https://aka.ms/new-console-template for more information
using static Delegates.Delegates;

//Getting used familiar with the syntax of custom delegates
Int32Printer int32Printer = new Int32Printer((x) => Console.WriteLine(x));
Int64Printer int64Printer = new Int64Printer((x) => Console.WriteLine(x));

Delegates.Delegates.PrintInt32(int32Printer);
Delegates.Delegates.PrintInt64(int64Printer);