// See https://aka.ms/new-console-template for more information
using Memory;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");


var s = new Foo() { Value = 1 };
// `s` is a local variable on the stack, but since Foo is a class (reference type),
// the variable only holds a reference (pointer).
// The Foo instance itself is created on the heap.
// Foo.Value is an int (value type), but because it's a field of Foo (a heap object),
// it is stored on the heap together with the Foo instance.

var b = new Bar() { Value = 2 };
// `b` is a local variable on the stack, and since Bar is a struct (value type),
// the variable itself contains the actual data of Bar.
// Bar.Value is an int, stored inline with Bar.
// If Bar were a field of a class, then both Bar and its Value would be on the heap
// (because structs live wherever their parent lives).

var array = new[] { 1, 2, 3, 4 };
var span = new Span<int>(array);

span[0] = 25;

Console.WriteLine(array[0]);

IntPtr ptr = Marshal.AllocHGlobal(5);
try
{
    Span<byte> bytes;
    unsafe { bytes = new Span<byte>((byte*)ptr, 5); }
    bytes[0] = 42;
    Console.WriteLine(Marshal.ReadByte(ptr));
    Console.WriteLine(bytes[0]);
} finally { Marshal.FreeHGlobal(ptr); }