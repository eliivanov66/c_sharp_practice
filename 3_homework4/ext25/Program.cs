/*
Задача 25: Напишите метод, который принимает на вход два числа (A и B) и возводит число A в натуральную степень B.
нельзя использовать pow
3, 5 -> 243 (3⁵)

2, 4 -> 16
*/
using static Librarium;

ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
choise=Console.ReadKey();
while (choise.Key!=ConsoleKey.Q)
{
    Console.Clear();
    int A=check_int_input("Введите число ");
    int B=check_int_input("Введите степень, в которую нужно возвести число ");
    Console.WriteLine($"Результат возведения числа {A} в степень {B} равно {power(A,B)}");
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
    choise=Console.ReadKey();
}

