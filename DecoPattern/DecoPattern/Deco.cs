namespace DecoPattern
{
    internal interface IComponent
    {
        string Name { get; }
        decimal Price { get; }
    }

    public class Pizza : IComponent
    {
        public string Name => "Pizza";

        public decimal Price => 8.6m;
    }

    public class Brot : IComponent
    {
        public string Name => "Brot";

        public decimal Price => 2.8m;
    }

    abstract class Deco : IComponent
    {
        protected readonly IComponent parent;

        protected Deco(IComponent parent)
        {
            this.parent = parent;
        }

        public abstract string Name { get; }

        public abstract decimal Price { get; }
    }

    class Salami : Deco
    {
        public Salami(IComponent parent) : base(parent)
        { }

        public override string Name => parent.Name + " Salami";

        public override decimal Price => parent.Price + 3.2m;
    }

    class Käse : Deco
    {
        public Käse(IComponent parent) : base(parent)
        { }

        public override string Name => parent.Name + " Käse";

        public override decimal Price => parent.Price + 2.1m;
    }

}
