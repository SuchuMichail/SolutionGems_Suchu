using Lab5.Elements;
using Lab5.Exceptions;

namespace Lab5
{
    public class Rifle
    {
        public bool IsFuse { get; private set; }//предохранитель включен
        private Cartridge? Chamber = null;//патронник
        public Magazine RifleMagazine { get; private set; }

        public bool IsLoaded => Chamber is not null;
        public Rifle(Magazine magazine, bool fuse)
        {
            RifleMagazine = magazine;
            IsFuse = fuse;    
        }

        public void Reload()
        {
            if (IsFuse) throw new RifleException();
            
            Chamber = RifleMagazine?.RemoveCartridge();
        }

        public Cartridge? Fire()
        {
            if (IsFuse) throw new RifleException();
            if (Chamber == null) throw new RifleException();

            Chamber.Use();
            Cartridge? chamber_cartridge = Chamber;
            Chamber = null;
            return chamber_cartridge;
        }
    }
}
