namespace Memory
{
    public class Foo
    {
        public int Value { get; set; }
    }

    public struct Bar
    {
        public int Value { get; set; }
    }

    public static class Tests
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
    }
}
