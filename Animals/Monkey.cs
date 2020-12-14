namespace Zoo
{
    public class Monkey : Animal
    {
        public Monkey(string name)
            :base(name)
        {
            Species = AnimalSpecies.Monkey;
        }

        protected override int AlivePoints => 40;

        protected override void IsDying()
        {
            this.IsAlive = this.Health >= this.AlivePoints;
        }
    }
}
