/*
Задача 27: Напишите матод, который принимает на вход число и выдаёт сумму цифр в числе.

452 -> 11

82 -> 10

9012 -> 12

*/
using static Librarium;

ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
choise=Console.ReadKey();
while (choise.Key!=ConsoleKey.Q)
{
    Console.Clear();
    int input=check_int_input("Введите число ");
    Console.WriteLine($"Сумма цифр числа {input} равно {sum_sign(input)}");
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
    choise=Console.ReadKey();
}

