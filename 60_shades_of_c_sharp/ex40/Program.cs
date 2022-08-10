﻿/*
40. В Указанном массиве вещественных чисел найдите разницу между максимальным и минимальным элементом
*/
//метод проверяющий вводимые значения - INT числа
int check_int_input(string message)
{
    bool input_data_not_ok=true; //введены некорректные данные
    int input=0;                 //число для ввода
    string err_message="";
    while (input_data_not_ok) //пока введены некорректные данные
    {
        Console.WriteLine($"{err_message}{message} :");
        try
        {
            input=Convert.ToInt32(Console.ReadLine());
            input_data_not_ok=false; //считаем что данные введены корректно
        }
        catch (SystemException) 
        {
            input_data_not_ok=true; //пока введены некорректные данные
            err_message="Неправильный ввод. ";
        }
    }
    return input;
}
//метод, генерирующий случайные числа в диапазоне start/stop
int randomizer(int start, int end)
{
    System.Random temp_randomizer=new System.Random(); //новый объект генератор псевдослучайных чисел
    return temp_randomizer.Next(start, end);
}
//автозаполнение массива указанной глубины
int[] init_int_array_auto(int number, int start, int end)
{
    int[] temp_array=new int[number]; //создание массива заданной глубины
    for (int i = 0; (i < temp_array.Count()); i++)
    {   
        temp_array[i]=randomizer(start, end);
    }
    return temp_array;
}
//заполнение массива заданной глубины руками
int[] init_int_array_manual(int number)
{
    int[] temp_array=new int[number]; //создание массива заданной глубины
    for (int i = 0; (i < temp_array.Count()); i++)
    {   
        temp_array[i]=check_int_input($"Элемент массива номер [{i}] равен: ");

    }
    return temp_array;
}
//метод поиска минимального значения в массиве
int find_min_array(int[] input_array)
{
    int min = input_array[0];
    for (int i = 0; (i < input_array.Count()); i++)
    {
        if (input_array[i]<min) min=input_array[i]; continue;
    }
    return min;
}
//метод поиска максимального значения в массиве
int find_max_array(int[] input_array)
{
    int max = input_array[0];
    for (int i = 0; (i < input_array.Count()); i++)
    {
        if (input_array[i]>max) max=input_array[i]; continue;
    }
    return max;
}


ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите Q");
choise=Console.ReadKey();
while (choise.Key!=ConsoleKey.Q)
{
    Console.Clear();
    int number=check_int_input("Введите количество элементов массива "); //ввод числа
    //выбор метода заполнения массива
    int fill_type=0;
    int[] result_array;
    while ((fill_type!=1) && (fill_type!=2))
    {
        Console.Clear();
        fill_type=check_int_input($"Как заполнить массив, 1-автоматически, 2-самостоятельно "); //ввод числа
    }
    //инициализация массива
    int start=0;
    int end=0;
    if (fill_type==1)
    {
        start=check_int_input($"Начальное число значений массива "); //ввод числа
        while (end<=start)
        {
            end=check_int_input($"Конечное число значений массива ");  //ввод числа
        }
        result_array=init_int_array_auto(number, start, end+1);           //инициализация массива автоматически
    }
    else
    {
        result_array=init_int_array_manual(number);
    }
    //вывод результатов    
    Console.Clear();
    //просто вывод массива
    for (int i = 0; (i < result_array.Count()); i++)
    {
        Console.WriteLine($"Элемент массива номер [{i}] равен: {result_array[i]}");
    }
    //создание буферного массива
    int min_value=find_min_array(result_array);
    int max_value=find_max_array(result_array);
    //поиск и вывод результата поиска внутри массива
    Console.WriteLine($"Разница между максимальным значением {max_value} и минимальным значением {min_value} равна {(max_value-min_value)}"); 


    Array.Clear(result_array);
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите Q");
    choise=Console.ReadKey();
}