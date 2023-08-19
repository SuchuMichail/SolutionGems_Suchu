using System;
using MyUnit;
using SystemArithmetic.Tests;


TestRunner.OnTestFailure += (name, message) => Console.WriteLine($"\nТест не пройден: " +
    $"{name}{(string.IsNullOrWhiteSpace(message) ? string.Empty : $". Сообщение: {message}")}");

TestRunner.OnTestPass += (name, message) => Console.WriteLine($"\nТест пройден: " +
    $"{name}{(string.IsNullOrWhiteSpace(message) ? string.Empty : $". Сообщение: {message}")}");

var typeInfo = typeof(ArithmeticTests);

TestRunner.Run(typeInfo);   