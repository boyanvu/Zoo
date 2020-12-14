namespace Zoo
{
    public abstract class Animal
    {
        public Animal(string name)
        {
            this.Name = name;
        }
        public AnimalSpecies Species { get; protected set; }
        public string Name { get; set; }
        public int Health { get; private set; } = 100;

        public bool IsAlive { get; protected set; } = true;
        protected abstract int AlivePoints { get; }
        public void Eat(int healthPoints)
        {
            this.Health = this.Health + healthPoints > 100 ? 100 : this.Health + healthPoints;
        }
        public void GetHungry(int healthPoints)
        {
            Health = this.Health - healthPoints < 0 ? 0 : this.Health - healthPoints;
            IsDying();
        }
        protected abstract void IsDying();
        public override string ToString()
        {
            var isAlive = this.IsAlive ? "Yes" : "No";
            return $"Name: {this.Name} Species: {this.Species} IsAlive:{isAlive} Health: {this.Health}";
        }
    }
}
