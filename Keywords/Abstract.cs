namespace Keywords
{
    public class Abstract
    {
        public static void Main()
        {
            Animal animal = new Animal();
            Dog dog = new Dog();
            Cat cat = new Cat();
            Human human = new Human();
        }


        private abstract class Animal
        {
            protected int NumberOfLegs = 4;

            public void Eat()
            {
                Console.WriteLine("Eating");
            }

            public void GetNumLegs()
            {
                Console.WriteLine($"Number of Legs: {NumberOfLegs}");
            }

            public virtual void Run()
            {
                Console.WriteLine("Running on 4 legs");
            }

            public abstract void MakeSound();
        }

        private class Dog: Animal
        {
        }

        private class Cat: Animal
        {

        }

        private class Human: Animal
        {

        }


    }
}
