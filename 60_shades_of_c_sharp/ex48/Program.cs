/*
48. Показать двумерный массив размером m×n заполненный целыми числами
*/
using static Librarium;

//переменные
int m=0;               //размерность m
int n=0;               //размерность n  

ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
choise=Console.ReadKey();
while (choise.Key!=ConsoleKey.Q)
{
    Console.Clear();
    m=0;
    n=0;
    //генерация массива
    int [,] result={{0,0}}; //массив результат
    while (m<=0) m=check_int_input("Введите размерность m ");
    while (n<=0) n=check_int_input("Введите размерность n ");
    result=init_matrix(m, n, -999, 999);
    //случайно сгенерированная матрица
    Console.WriteLine("Была сгенерирована следующая матрица целых чисел: ");
    display_matrix(result);
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
    choise=Console.ReadKey();
}
