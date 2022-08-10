/*
37. В одномерном массиве из 123 чисел найти количество элементов из отрезка [10,99]
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
    if (fill_type==1)
    {
        result_array=init_int_array_auto(number, 0, 1000);              //инициализация массива автоматически
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
    //задание параметров отрезка
    int start_vector=check_int_input($"Введите начальное значение для поиска отрезка "); //начало отрезка
    int end_vector  =check_int_input($"Введите конечное значение для поиска отрезка ");  //окончание отрезка
    int lenght_vector=0;                                                                 //длина отрезка 
    bool start_calculating=false; //признак начала подсчёта
    int start_index=0;
    int end_index=0;
    //поиск и вывод результата поиска внутри массива
    for (int i = 0; (i < result_array.Count()); i++)
    {
        //начало подсчёта длины отрезка
        if (result_array[i]==start_vector) 
        {
            start_index=i;
            start_calculating=true; //начать калькуляцию
        }
        if (start_calculating) lenght_vector++; //подсчёт длины
        //длина отрезка найдена
        if ((result_array[i]==end_vector) && (start_calculating))
        {
            end_index=i;
            start_calculating=false;
            break;
        }
        //длина отрезка не найдена
        if ((start_calculating) && (i == result_array.Count()-1) && (result_array[i]!=end_vector))
        {
            lenght_vector=0;
        } 
    }
    start_calculating=false;
    if (lenght_vector!=0)
    {
        Console.WriteLine($"Искомый отрезок {start_vector}-->{end_vector} найден, его длина {lenght_vector}, начало в индексе {start_index}, окончание {end_index}");
    }
    else
    {
        Console.WriteLine($"Искомый отрезок {start_vector}-->{end_vector} найден, его длина {lenght_vector}");
    }
    Array.Clear(result_array);
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите Q");
    choise=Console.ReadKey();
}