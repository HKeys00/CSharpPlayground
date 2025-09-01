namespace Keywords
{
    public class Interface
    {
        public static void Main()
        {
            Dog dog = new Dog();
            Cat cat = new Cat();
            Vacuum vacuum = new Vacuum();

            List<ICanMakeSound> canMakeSounds = new List<ICanMakeSound>()
            {
                dog, cat, vacuum
            };

            foreach (var soundMaker in canMakeSounds)
            {
                soundMaker.MakeSound();
            }
        }

        public interface ICanMakeSound
        {
            public int Volume { get; set; }

            public void MakeSound();
        }

        public class Dog: ICanMakeSound
        {
            public int Volume { get; set; }

            public Dog()
            {
                Volume = 5;
            }

            public void MakeSound()
            {

            }
        }

        public class Cat: ICanMakeSound
        {
            public int Volume { get; set; }

            public Cat()
            {
                Volume = 3;
            }

            public void MakeSound()
            {

            }
        }

        public class Vacuum: ICanMakeSound
        {
            public int Volume { get; set; }

            public Vacuum()
            {
                Volume = 8;
            }

            public void MakeSound()
            {

            }
        }

    }
}
