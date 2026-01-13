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
        public long a, b, c, d, e, f, g, h;
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
        public void Test1()
        {
            Foo foo = new Foo();
            int sum = 0;
            for (int i = 0; i < 100_000; i++)
            {
                sum += SixteenByteTest(foo);
            }
        }

        [Benchmark]
        public void Test2()
        {
            Bar bar = new Bar();
            long sum = 0;
            for (int i = 0; i < 100_000; i++)
            {
                sum += TwentyFourByteTest(bar);
            }
        }


        public static int SixteenByteTest(Foo foo)
        {
            foo.Valu1 = 1;
            foo.Value = 3;
            foo.Valu2 = 1;
            foo.Valu3 = 2;

            int sum = foo.Valu1 + foo.Valu2 + foo.Valu3 + foo.Value;
            return sum;
        }

        public static long TwentyFourByteTest(Bar bar)
        {
            // Assign a unique number to each long field in bar
            bar.a = 1L;
            bar.b = 2L;
            bar.c = 3L;
            bar.d = 4L;
            bar.e = 5L;
            bar.f = 6L;
            bar.g = 7L;
            bar.h = 8L;

            // Sum all fields
            long sum = bar.a + bar.b + bar.c + bar.d + bar.e + bar.f + bar.g + bar.h;
            return sum;
        }

    }
}
