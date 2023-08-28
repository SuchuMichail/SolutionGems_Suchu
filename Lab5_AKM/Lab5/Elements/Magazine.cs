using Lab5.Exceptions;

namespace Lab5.Elements
{
    public class Magazine
    {
        private Stack<Cartridge> Ammos = new();

        public int Capacity { get; private set; }//max
        public int CountAmmos => Ammos.Count;

        public Magazine() { }

        public Magazine(int capacity)
        {
            Capacity = capacity;
        }

        public Cartridge? RemoveCartridge()
        {
            if (CountAmmos == 0) return null;
            return Ammos.Pop();
        }

        public void AddCartridge()
        {
            if (CountAmmos == Capacity) throw new MagazineException();
            Ammos.Push(new Cartridge());
        }

        public Cartridge? PeekCartridge()
        {
            return Ammos.Peek();
        }
    }
}
