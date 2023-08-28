using Lab5.Tests;
using MyUnit;

TestRunner.OnTestFailure += (name, message) => Console.WriteLine($"\nТест не пройден: " +
    $"{name}{(string.IsNullOrWhiteSpace(message) ? string.Empty : $". Сообщение: {message}")}");

TestRunner.OnTestPass += (name, message) => Console.WriteLine($"\nТест пройден: " +
    $"{name}{(string.IsNullOrWhiteSpace(message) ? string.Empty : $". Сообщение: {message}")}");


TestRunner.Run(typeof(CartridgeTests));
TestRunner.Run(typeof(MagazineTests));
TestRunner.Run(typeof(RifleTests));