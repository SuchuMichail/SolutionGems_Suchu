using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnit
{
    public static class MyAssert
    {
        public static void True(bool actual)
        {
            if (!actual)
            {
                throw new MyAssertTestFailureException();
            }
        }

        public static void False(bool actual)
        {
            if (actual)
            {
                throw new MyAssertTestFailureException();
            }
        }

        public static void Throws(Type expected, Func<object?> lambda)
        {
            try
            {
                lambda.Invoke();
            }
            catch (Exception ex)
            {
                if(ex.GetType() != expected)
                {
                    throw new MyAssertTestFailureException();
                }
            }
        }
    }
}
