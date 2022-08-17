/*
Задача 29: Напишите метод, который задаёт массив из 8 элементов (диапазон от 1 до 100) и выводит их на экран.
пример вывода
[1,4,5,3,1,2,3,9]
[4,45,53,31,14,25,63,19]

*/
using static Librarium;

ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
choise=Console.ReadKey();
while (choise.Key!=ConsoleKey.Q)
{
    Console.Clear();
    //код задачи
    int input=0;
    while (input<=0)
    {
        input=check_int_input("Введите число N, размерность массива");
    }
    int[] array; //создание пустого массива
    array=init_int_array(input,0,100); //заполнение массива
    Console.WriteLine($"Получен следующий массив значений длиной {input}");
    display_array(array); 
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
    choise=Console.ReadKey();
}

