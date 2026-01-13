using BenchmarkDotNet.Attributes;

namespace Memory
{
    // 16 byte struct
    public struct Foo
    {
        public int Value { get; set; }
        public int Valu1 { get; set; }
        public int Valu2 { get; set; }
        public int Valu3 { get; set; }

    }

    // 24 byte struct
    public struct Bar
    {
        public int Value { get; set; }
        public int Valu1 { get; set; }
        public int Valu2 { get; set; }
        public int Valu3 { get; set; }

        public int Value4 { get; set; }

        public int Value5 { get; set; }
    }


    [MemoryDiagnoser]
    public class Tests
    {
        public static void PassRefByRef(ref Foo foo)
        {
            foo = new Foo();
        }

        public static void PassByIn(in Foo foo)
        {
            
        }

        public static void PassByRefReadonly(ref readonly Foo foo)
        {
            
        }

        public static void PassByOut(out Foo foo)
        {
            foo = new Foo();
            foo.Value = 42;
        }


        [Benchmark]
        public static void Test1()
        {
            Foo foo = new Foo();
            for (int i = 0; i < 100_000; i++)
            {
                SixteenByteTest(foo);
            }
        }

        [Benchmark]
        public static void Test2()
        {
            Bar bar = new Bar();
            for (int i = 0; i < 100_000; i++)
            {
                TwentyFourByteTest(bar);
            }
        }


        public static void SixteenByteTest(Foo foo)
        {
            foo.Valu1 = 1;
        }

        public static void TwentyFourByteTest(Bar bar)
        {
            bar.Valu1 = 1;
        }
    }
}
