// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    public static void CheckYear()
    {
        Console.Write("Введите год: ");
        string input = Console.ReadLine() ?? "";
        int year = int.Parse(input);

        if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
        {
            Console.WriteLine($"{year} - високосный год");
        }
        else
        {
            Console.WriteLine($"{year} - невисокосный год");
        }
    }

    public static void DegreeConverter()
    {
        Console.Write("Введите значение температуры: ");
        string input = Console.ReadLine() ?? "";
        double value = double.Parse(input);


        Console.Write("Введите значение шкалы: ");
        input = Console.ReadLine() ?? "";

        if (input.Equals("C") || input.Equals("c"))
        {
            value = Math.Round(value * 9 / 5 + 32);
            input = "F";
        }
        else if (input.Equals("F") || input.Equals("f"))
        {
            value = Math.Round((value - 32) * 5 / 9);
            input = "C";
        }

        Console.WriteLine("Результат: " + value.ToString() + input);
    }

    public static void Main()
    {
        //CheckYear();
        DegreeConverter();
    }
}
