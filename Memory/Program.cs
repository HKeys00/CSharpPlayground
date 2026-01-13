// See https://aka.ms/new-console-template for more information

using System.Buffers;
using Memory;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Running;

Console.WriteLine("Hello, World!");


var s = new Foo() { Value = 1 };
// `s` is a local variable on the stack, but since Foo is a class (reference type),
// the variable only holds a reference (pointer).
// The Foo instance itself is created on the heap.
// Foo.Value is an int (value type), but because it's a field of Foo (a heap object),
// it is stored on the heap together with the Foo instance.

//var b = new Bar() { Value = 2 };
// `b` is a local variable on the stack, and since Bar is a struct (value type),
// the variable itself contains the actual data of Bar.
// Bar.Value is an int, stored inline with Bar.
// If Bar were a field of a class, then both Bar and its Value would be on the heap
// (because structs live wherever their parent lives).

//const int num = 100;
//Foo[][] a = new Foo[num][];
//for (int i = 0; i < num; i++)
//{
//    a[i] = new Foo[100_000_000];
//    for (int j = 0; j < 100_000; j++)
//    {
//        a[i][j] = new Foo();
//    }
//}


//const int num = 100;
//ArrayPool<Foo> foo = ArrayPool<Foo>.Shared;

//for (int i = 0; i < num; i++)
//{
//    var a = foo.Rent(100_000_000);
//    for (int j = 0; j < 100_000; j++)
//    {
//        a[i] = new Foo();
//    }

//    foo.Return(a, true);
//}

BenchmarkRunner.Run<Tests>();


var m = s;
Console.WriteLine(ReferenceEquals(m, s));
Tests.PassRefByRef(ref s);
Console.WriteLine(ReferenceEquals(m, s));

Tests.PassByIn(in m);
Tests.PassByRefReadonly(in m);
Tests.PassByOut(out m);