// See https://aka.ms/new-console-template for more information

using System;
class Program
{
    public static void TheLongestWord()
    {
        Console.WriteLine("Вводите слова, завершая каждое нажатием Enter.\n");
        Console.WriteLine("Для выхода наберите \"exit\".");

        string input = Console.ReadLine() ?? "";
        string max_str = "";
        int max = 0;
        while (!input.Equals("exit"))
        {
            if (input.Length > max)
            {
                max = input.Length;
                max_str = input.ToUpper();
            }
            input = Console.ReadLine() ?? "";
        }
        Console.WriteLine("Считывание завершено.");
        Console.WriteLine("Самое длинное слово: \"" + max_str + $"\" ({max}).");
    }

    public static void PlayingWithCoin()
    {
        Console.WriteLine("Игра началась!");
        string input = "";
        int value = -1;
        Random random = new Random();
        int quantity = 0;
        int luck = 0;

        do
        {
            Console.Write("Введите число: ");
            input = Console.ReadLine() ?? "";
            
            if (int.TryParse(input, out value))
            {
                value = int.Parse(input);
            }
            else
            {
                value = -1;
            }

            if (value == 0 || value == 1)
            {
                quantity++;
                if (random.Next(2) == value)
                {
                    luck++;
                    Console.WriteLine("Угадали!");
                }
                else
                {
                    Console.WriteLine("Попробуйте снова");
                }
            }
        } while (value == 0 || value == 1) ;

        
        if (quantity == 0)
        {
            Console.WriteLine("Игра окончена. Вы не пытались угадывать.");
        }
        else
        {
            Console.WriteLine($"Игра окончена со счётом {luck}, угадано " + Math.Round(100.0 * luck / quantity).ToString() + "% бросков");
        }
    }

    public static void Main()
    {
        //TheLongestWord();
        PlayingWithCoin();
    }
}