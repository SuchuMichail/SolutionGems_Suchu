using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnit.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class MyInlineDataAttribute : Attribute
    {
        public object[] Paramet;

        public MyInlineDataAttribute(params object[] parameters)
        {
            if (parameters == null || parameters.Length == 0) 
                throw new ArgumentNullException($"Для атрибута {typeof(MyInlineDataAttribute)} нужны параметры");

            Paramet = new object[parameters.Length];
            for(int i=0; i<parameters.Length; i++)
            {
                Paramet[i] = parameters[i];
            }
        }

        public object[] GetParamet()
        {
            return Paramet;
        }
    }
}
