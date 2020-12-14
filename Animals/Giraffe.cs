namespace Zoo
{
    public class Giraffe : Animal
    {
        public Giraffe(string name)
            :base(name)
        {
            Species = AnimalSpecies.Giraffe;
        }

        protected override int AlivePoints => 60;

        protected override void IsDying()
        {
            this.IsAlive = this.Health >= this.AlivePoints;
        }

    }
}
