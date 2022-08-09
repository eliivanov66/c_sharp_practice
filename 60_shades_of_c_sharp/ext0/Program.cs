/*  0. Вывести квадрат числа
*/
//метод для коррекции ввода
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

ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
choise=Console.ReadKey();
while (choise.Key!=ConsoleKey.Q)
{
    int number=check_int_input("Введите число "); //ввод числа
    int power=check_int_input($"Введите степень в которую нужно возвести число {number}");
    power=Math.Abs(power);
    Console.Clear();
    Console.WriteLine($"Число {number}, в степени {power} это {Convert.ToInt32(Math.Pow(Convert.ToDouble(number), Convert.ToDouble(power)))}");

    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
    choise=Console.ReadKey();
}
