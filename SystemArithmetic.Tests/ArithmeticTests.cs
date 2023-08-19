using MyUnit.Attributes;
using MyUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemArithmetic.Tests
{
    public class ArithmeticTests
    {
        [MyFact]
        public void TestTrue_OnePlusOne_EqualsTwo()
        {
            MyAssert.True(1 + 1 == 2);
        }

        [MyFact]
        public void TestTrue_OnePlusOne_EqualsZero()
        {
            MyAssert.True(1 + 1 == 0);
        }

        [MyFact]
        public void TestFalse_TwoPlusTwo_EqualsFour()
        {
            MyAssert.False(2 + 2 == 4);
        }

        [MyFact]
        public void TestFalse_TwoPlusTwo_EqualsZero()
        {
            MyAssert.False(2 + 2 == 0);
        }

        [MyFact]
        public void TestThrows_DivideByZero()
        {
            int no_zero = 1;
            int zero = 0;
            MyAssert.Throws(typeof(DivideByZeroException), () => no_zero / zero);
        }
    }
}
