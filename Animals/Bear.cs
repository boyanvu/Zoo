namespace Zoo
{
    public class Bear : Animal
    {
        protected override int AlivePoints => 65;
        public Bear(string name)
            :base(name)
        {
            Species = AnimalSpecies.Bear;
        }
        protected override void IsDying()
        {
            IsAlive = Health >= 65;
        }
    }
}
