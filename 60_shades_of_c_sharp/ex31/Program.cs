/*
Задать массив из 8 элементов и вывести их на экран 
*/
//метод проверяющий вводимые значения - INT числа
int check_int_input(string message)
{
    bool input_data_not_ok=true; //введены некорректные данные
    int input=0;                 //число для ввода
    string err_message="";
    while (input_data_not_ok) //пока введены некорректные данные
    {
        Console.Clear();
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

int[] init_int_array(int number, int start, int end)
{
    int[] temp_array=new int[number]; //b
    for (int i = 0; (i < temp_array.Count()); i++)
    {   
        temp_array[i]=randomizer(start, end);
    }
    return temp_array;
}


ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
choise=Console.ReadKey();
while (choise.Key!=ConsoleKey.Q)
{
    int number=check_int_input("Введите количество элементов массива "); //ввод числа
    int[] result_array=init_int_array(number, 1, 999);                   //инициализация массива
    Console.Clear();
    for (int i = 0; (i < result_array.Count()); i++)
    {
        Console.WriteLine($"Элемент массива номер [{i}] равен: {result_array[i]}");
    }
    Array.Clear(result_array);
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
    choise=Console.ReadKey();
}