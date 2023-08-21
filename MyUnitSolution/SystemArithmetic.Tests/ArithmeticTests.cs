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
        /*[MyFact]
        public void FactWithParameters(int a)
        {
            //должна выброситься ошибка из-за наличия параметра
        }*/
        
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

        /*[MyFact]
        [MyInlineData(0)]
        public void TestTwoAttributes()
        {
            //должна выброситься ошибка из-за одновременного использования MyFact и MyInlineData
        }*/

        /*[MyFact]
        [MyInlineData(1)]
        public void TestTwoAttributes(int a)
        {
            //должна выброситься ошибка из-за одновременного использования MyFact и MyInlineData
        }*/

        /*
        [MyInlineData(0, 2)]
        public void TestCountParameters(int a)
        {
            //здесь ошибка из-за количества параметров 
        }*/


        [MyInlineData(0, 1)]
        public void TestInlineData(int a, int b)
        {
            MyAssert.True(a + b == 1);//верный тест
        }
    }
}
