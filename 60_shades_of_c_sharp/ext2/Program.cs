/*   2. Даны два числа. Показать большее и меньшее число
*/
//метод для коррекции ввода
double check_int_input(string message)
{
    bool input_data_not_ok=true; //введены некорректные данные
    double input=0;                 //число для ввода
    string err_message="";
    while (input_data_not_ok) //пока введены некорректные данные
    {
        Console.Clear();
        Console.WriteLine($"{err_message}{message} :");
        try
        {
            input=Convert.ToDouble(Console.ReadLine());
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

ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
choise=Console.ReadKey();
while (choise.Key!=ConsoleKey.Q)
{
    double number1=check_int_input("Введите первое число "); //ввод числа 1
    double number2=check_int_input("Введите второе число");  //ввод числа 2
    double min=0.0;
    double max=0.0;
    Console.Clear();
    if (number1>number2)
    {
        max=number1;
        min=number2;
    }
    if (number1<number2)
    {
        max=number2;
        min=number1;
    }
    if (number1==number2)
    {
        max=min=number1;
    }

    if (max!=min)
    {
        Console.WriteLine($"Миниальное число равно {min}, максимальное число равно {max}");
    }
    else
    {
        Console.WriteLine($"Числа {min} и {max} эквиваленты");
    }

    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
    choise=Console.ReadKey();
}
