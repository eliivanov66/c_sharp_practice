/*
35. Определить, присутствует ли в заданном массиве, некоторое число
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
    //количество чётных/нечётных чисел
    int even_count=0; //счётчик чётных чисел
    int odd_count=0;  //счётчик нечётных чисел    
    //поиск и вывод результата поиска внутри массива
    for (int i = 0; (i < result_array.Count()); i++)
    {
        if (result_array[i]==0) //ноль - в этом празднике не учавствует
        {
            continue;
        }
        if ((result_array[i] % 2)==0)
        {
            even_count=even_count+1;
        }
        else
        {
            odd_count=odd_count+1;
        }
    }
    Console.WriteLine($"Количество чётных чисел в массие равно {even_count}");
    Console.WriteLine($"Количество нечётных чисел в массие равно {odd_count}");
    Array.Clear(result_array);
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите Q");
    choise=Console.ReadKey();
}