using System;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            var zoo = Zoo.Instance;

            for (int i = 0; i < 10; i++)
            {
                zoo.AddAnimal(new Bear(String.Concat("Bear_", i + 1)));
                zoo.AddAnimal(new Giraffe(String.Concat("Giraffe_", i + 1)));
                zoo.AddAnimal(new Monkey(String.Concat("Monkey_", i + 1)));
            }

            zoo.AnimalsGetHungry();
            zoo.PrintAnimalsBySpecies(AnimalSpecies.Bear);
            zoo.AnimalsGetHungry();
            zoo.PrintAnimalsBySpecies(AnimalSpecies.Bear);
            zoo.FeedAnymals();
            zoo.AnimalsGetHungry();
            Console.WriteLine(zoo.GetMinHealth(AnimalSpecies.Monkey));

        }
    }
}
