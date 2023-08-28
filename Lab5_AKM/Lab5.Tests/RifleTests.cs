using MyUnit;
using MyUnit.Attributes;
using Lab5.Elements;
using Lab5.Exceptions;

namespace Lab5.Tests
{
    public class RifleTests
    {
        [MyFact]
        public void FirstReloading()
        {

            Magazine magazine = new Magazine(1);
            magazine.AddCartridge();

            Rifle rifle = new Rifle(magazine, false);

            rifle.Reload();
            MyAssert.True(rifle.IsLoaded);
        }

        [MyFact]
        public void ReloadingAfterReloading()
        {
            Magazine magazine = new Magazine(1);
            magazine.AddCartridge();

            Rifle rifle = new Rifle(magazine, false);
            rifle.Reload();

            rifle.Reload();
            MyAssert.False(rifle.IsLoaded);
        }

        [MyFact]
        public void FireWithFuse()
        {
            Magazine magazine = new Magazine(1);
            magazine.AddCartridge();

            Rifle rifle = new Rifle(magazine, true);

            MyAssert.Throws<RifleException>(()=> rifle.Fire());
        }

        [MyFact]
        public void ReloadWithFuse()
        {
            Magazine magazine = new Magazine(1);
            magazine.AddCartridge();

            Rifle rifle = new Rifle(magazine, true);

            MyAssert.Throws<RifleException>(() => rifle.Reload());
        }

        [MyFact]
        public void FireWithoutReloading()
        {
            Magazine magazine = new Magazine(1);
            magazine.AddCartridge();

            Rifle rifle = new Rifle(magazine, false);

            MyAssert.Throws<RifleException>(() => rifle.Fire());
        }

        [MyFact]
        public void UsedCartridgeIsMagazineCartridge()
        {
            Magazine magazine = new Magazine(1);
            magazine.AddCartridge();

            var magazine_cartridge = magazine.PeekCartridge();

            Rifle rifle = new Rifle(magazine, false);
            rifle.Reload();

            MyAssert.True(magazine_cartridge == rifle.Fire());
            //из патронника выбросился тот патрон, который раньше лежал в магазине
        }
    }
}
