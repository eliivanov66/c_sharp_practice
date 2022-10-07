//возведение в указанную степень
void power (ref double x, double y)
{
    File.AppendAllText("Logger.txt", $"Оператор запросил возведение в степень {y} числа {x}");
    x= Math.Pow(x,y);
}

//Коррекция ввода
double check_input(string message)
{
    int input_data_not_ok=1; //данные введены корректно
    string err_message = "";
    double temp=0.0;
    string temp_input="";
    while (input_data_not_ok==1)
    {
        try
        {
            Console.Clear();
            Console.Write($"{err_message}{message}");
            temp_input=$"{Console.ReadLine()}";
            temp=Convert.ToDouble(temp_input);
            input_data_not_ok=0;
        }
        catch (SystemException) //если это не Double
        {
            input_data_not_ok=1;
            err_message="Вы ввели не число. ";
            File.AppendAllText("Logger.txt", $"Оператор ввёл неверное значение {temp_input}");
        }
    }
    File.AppendAllText("Logger.txt", $"Оператор ввёл значение {temp}");
    return temp;
}

string input_message="";
while (input_message.ToLower()!="q")
{
    Console.WriteLine("Нажмите любую клавишу для возведения в степень? q - для выхода");
    input_message=$"{Console.Read()}";
    double input_numer=check_input("Введите число для возведения в степень:");
    double input_power=check_input("Введите степень числа :");
    power(ref input_numer, input_power);
}