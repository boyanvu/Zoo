using System;
using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private const int MinHungerPoints = 15;
        private const int MaxHungerPoints = 35;
        private const int MinFeedPoints = 10;
        private const int MaxFeedPoints = 25;
        private static Zoo instance = null;
        private Random random;
        private Zoo()
        {
            this.random = new Random();
        }
        public static Zoo Instance 
        {
            get
            {
                if (instance==null)
                {
                    instance = new Zoo();
                }
                return instance;
            }
         }
        public List<Animal> Animals { get; set; } = new List<Animal>();

        public void AddAnimal(Animal animal)
        {
            this.Animals.Add(animal);
        }
        public int CountAliveAnimals()
        {
            return GetAliveAnimals().Count();
        }
        public int GetMinHealth(AnimalSpecies animalSpecies)
        {
            var aliveAnimalsOfSpecies = GetAliveAnimals().Where(a => a.Species == animalSpecies).ToList();
            if (aliveAnimalsOfSpecies.Count()>0)
            {
                return aliveAnimalsOfSpecies.Min(a => a.Health);
            }
            else
            {
                return 0;
            }
        }
        public void FeedAnymals()
        {
            var aliveEnimals = GetAliveAnimals();
            if (aliveEnimals.Count()>0)
            {
                var nrToBeFed = (int)Math.Floor(aliveEnimals.Count() * 0.9);
                foreach (var animal in aliveEnimals.OrderByDescending(a => a.Health).Take(nrToBeFed))
                {
                    animal.Eat(random.Next(MinFeedPoints, MaxFeedPoints + 1));
                }
            }

        }
        public void AnimalsGetHungry()
        {
            var aliveEnimals = GetAliveAnimals();
            if (aliveEnimals.Count>0)
            {
                Dictionary<AnimalSpecies, int> reducePointsPerSpices = new Dictionary<AnimalSpecies, int>();
                reducePointsPerSpices.Add(AnimalSpecies.Bear, random.Next(MinHungerPoints, MaxHungerPoints+1));
                reducePointsPerSpices.Add(AnimalSpecies.Giraffe, random.Next(MinHungerPoints, MaxHungerPoints + 1));
                reducePointsPerSpices.Add(AnimalSpecies.Monkey, random.Next(MinHungerPoints, MaxHungerPoints + 1));
                aliveEnimals.ForEach(a => a.GetHungry(reducePointsPerSpices[a.Species]));
            }
        }
        public void PrintAllAnimals()
        {
            this.Animals.ForEach(a=>Console.WriteLine(a));
        }

        public void PrintAnimalsBySpecies(AnimalSpecies species)
        {
            this.Animals.Where(a=>a.Species == species).ToList().ForEach(a => Console.WriteLine(a));
        }
        private List<Animal> GetAliveAnimals()
        {
            return this.Animals.Where(a => a.IsAlive == true).ToList();
        }

    }
}
