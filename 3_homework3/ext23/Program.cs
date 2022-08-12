/*
Задача 23
Напишите метод, который принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
3 -> 1, 8, 27
5 -> 1, 8, 27, 64, 125
*/
//библиотека с методами
using static Librarium;
Librarium obj=new Librarium(); //для доступа к нестатическим методам (динамически меняемый возвращаемый тип данных от метода)

ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
choise=Console.ReadKey();
while (choise.Key!=ConsoleKey.Q)
{
    Console.Clear();
    int input=0;
    //ввод данных от пользователя, причём пусть будут лишь положительные значения
    input=Math.Abs(obj.check_input("Введите число кубов, которые вы хотите увидеть: ", input.GetType()));
    for (int i=1; i<=Convert.ToInt32(input); i++)
    {   
        //отображение
        string space=string.Concat(Enumerable.Repeat(" " , show_sign_count(Convert.ToInt32(Math.Pow(input,3)))-show_sign_count(Convert.ToInt32(Math.Pow(i,3))) + 1));
        Console.Write($"{Math.Pow(i,3)}{space}"); //вывод результата
        if ((i % 10)==0) Console.WriteLine(); //переход на новую строку
    }
    Console.WriteLine();
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
    choise=Console.ReadKey();
}