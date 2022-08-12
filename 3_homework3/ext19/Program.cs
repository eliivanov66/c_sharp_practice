/*
19. Напишите метод, который принимает на вход шестизначное число и проверяет, является ли оно палиндромом.

14212 -> нет

12821 -> да

23432 -> да
строки использовать нельзя
*/
//библиотека с методами
using static Librarium;

ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
choise=Console.ReadKey();
while (choise.Key!=ConsoleKey.Q)
{
    Console.Clear();
    int input=check_int_input("Введите число для проверки на палиндром ");
    if (check_palindrom(input))
    {
        Console.WriteLine($"Число {input} является палиндромом");
    }
    else
    {
        Console.WriteLine($"Число {input} является не является палиндромом");  
    }
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
    choise=Console.ReadKey();
}
