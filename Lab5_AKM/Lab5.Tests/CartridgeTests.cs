using MyUnit;
using MyUnit.Attributes;
using Lab5.Exceptions;
using Lab5.Elements;

namespace Lab5.Tests
{
    public class CartridgeTests
    {
        [MyFact]
        public void CartridgeUsedTwice()
        {
            Cartridge cartridge = new Cartridge();

            MyAssert.False(cartridge.isUsed);

            cartridge.Use();

            MyAssert.True(cartridge.isUsed);
            MyAssert.Throws<CartridgeException>(() => cartridge.Use());
        }
    }
}