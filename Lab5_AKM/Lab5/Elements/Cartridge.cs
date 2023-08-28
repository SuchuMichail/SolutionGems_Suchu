using Lab5.Exceptions;

namespace Lab5.Elements
{
    public class Cartridge
    {
        public bool isUsed { get; private set; }
        public Cartridge()
        {
            isUsed = false;
        }
        public void Use()
        {
            if (isUsed)
            {
                throw new CartridgeException();
            }

            isUsed = true;
        }
    }
}