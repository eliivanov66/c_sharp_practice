/*   1. По двум заданным числам проверять является ли первое квадратом второго
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
    double number1=-1.0;
    double number2=-1.0;
    while (number1<0.0)
    {
        number1=check_int_input("Введите первое число "); //ввод числа 1
    }
    number2=check_int_input($"Первое число {number1}, введите второе число"); //ввод числа 2
    Console.Clear();
    if (Math.Sqrt(number1)==Math.Abs(number2))
    {
        Console.WriteLine($"Число {number1}, является квадратом числа {number2}");
    }
    else
    {
        Console.WriteLine($"Число {number1}, не является квадратом числа {number2}");
    }
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
    choise=Console.ReadKey();
}
