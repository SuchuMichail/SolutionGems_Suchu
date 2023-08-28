using MyUnit.Attributes;
using System.Reflection;

namespace MyUnit
{
    public static class TestRunner
    {
        public static event TestRunEventHandler OnTestPass;
        public static event TestRunEventHandler OnTestFailure;

        public static void Run(Type sourceType)
        {
            var methodsFact = sourceType
                .GetMethods()
                .Where(o => o.GetCustomAttribute(typeof(MyFactAttribute)) is not null);

            var methodsInlineData = sourceType
                .GetMethods()
                .Where(o => o.GetCustomAttribute(typeof(MyInlineDataAttribute)) is not null);


           /* Console.WriteLine("      fact");
            foreach(var met in methodsFact)
            {
                Console.WriteLine(met.Name);
            }
            Console.WriteLine("");*/
            /*Console.WriteLine("      inlinedata");
            foreach (var met in methodsInlineData)
            {
                Console.WriteLine(met.Name);
            }*/

            foreach (var method in methodsFact)
            {
                if (methodsInlineData.Contains(method))
                {
                    throw new ArgumentException($"Метод {method.Name} не должен иметь сразу " +
                        $"{typeof(MyFactAttribute)} и {typeof(MyInlineDataAttribute)}");
                }
            }


            if (!sourceType.GetConstructors().Any(o => o.GetParameters().Length == 0))
            {
                throw new InvalidOperationException($"В типе {sourceType.FullName} необходим конструктор без параметров");
            }

            var instance = Activator.CreateInstance(sourceType)!;

            foreach (var method in methodsFact)
            {
                if (method.GetParameters().Any())
                {
                    throw new InvalidOperationException($"Тестовый метод {method.Name}, отмеченный атрибутом {nameof(MyFactAttribute)}, не должен принимать параметры");
                }

                try
                {
                    method.Invoke(instance, null);

                    OnTestPass?.Invoke($"{sourceType.Name}.{method.Name}");
                } 
                catch (TargetInvocationException ex) when (ex.InnerException is MyAssertTestFailureException)
                {
                    OnTestFailure?.Invoke($"{sourceType.Name}.{method.Name}");
                }
            }

            foreach (var method in methodsInlineData)
            {
                var attributes = method.GetCustomAttributes<MyInlineDataAttribute>();

                foreach(var attribute in attributes)
                {
                    try
                    {
                        var allMethodParam = method.GetParameters();
                        var allAttributeParam = attribute.GetParamet();

                        if (allMethodParam.Length != allAttributeParam.Length)
                        {
                            throw new ArgumentException($"Количество параметров в методе {method.Name} должно быть таким же, как в атрибуте");
                        }

                        //здесь должна быть проверка типов параметров метода и атрибута (не получилось)
                        /*
                        for(int i=0; i<allMethodParam.Length; i++)
                        {
                            if (allMethodParam[i].GetType() != allAttributeParam[i].GetType())
                            {
                                throw new ArgumentException($"Параметры метода {method.Name} и атрибута должны быть одного типа");
                            }
                        }*/

                        method.Invoke(instance, allAttributeParam);

                        OnTestPass?.Invoke($"{sourceType.Name}.{method.Name}");
                    } 
                    catch (TargetInvocationException ex) when (ex.InnerException is MyAssertTestFailureException)
                    {
                        OnTestFailure?.Invoke($"{sourceType.Name}.{method.Name}");
                    }
                }

            }
        }
    }
}