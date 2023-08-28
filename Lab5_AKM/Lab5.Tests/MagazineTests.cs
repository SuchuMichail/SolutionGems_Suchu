using MyUnit.Attributes;
using Lab5.Elements;
using MyUnit;
using Lab5.Exceptions;

namespace Lab5.Tests
{
    public class MagazineTests
    {
        [MyFact]
        public void RemovingCartridgeFromEmptyMagazine() 
        {
            Magazine magazine = new Magazine();

            var res = magazine.RemoveCartridge();

            MyAssert.True(res == null);
        }

        [MyFact]
        public void AddingCartridgeToEmptyMagazine()
        {
            Magazine magazine = new Magazine(2);
            MyAssert.True(magazine.CountAmmos == 0);

            magazine.AddCartridge();

            MyAssert.True(magazine.CountAmmos > 0);
        }

        [MyFact]
        public void RemovingCartridgeFromNotEmptyMagazine()
        {
            Magazine magazine = new Magazine(3);
            magazine.AddCartridge();
            magazine.AddCartridge();

            MyAssert.True(magazine.CountAmmos == 2);

            magazine.RemoveCartridge();
            MyAssert.True(magazine.CountAmmos < 2);
        }

        [MyFact]
        public void AddingCartridgeToFullMagazine()
        {
            Magazine magazine = new Magazine(1);
            magazine.AddCartridge();

            MyAssert.Throws<MagazineException>(() => magazine.AddCartridge());
        }
    }
}
