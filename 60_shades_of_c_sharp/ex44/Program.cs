/*
44. Найти точку пересечения двух прямых заданных уравнением y = k1 * x + b1, y = k2 * x + b2, b1 k1 и b2 и k2 заданы
*/
//метод проверяющий вводимые значения - INT числа
double check_int_input(string message)
{
    bool input_data_not_ok=true; //введены некорректные данные
    double input=0.0;                 //число для ввода
    string err_message="";
    while (input_data_not_ok) //пока введены некорректные данные
    {
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
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите Q");
choise=Console.ReadKey();
double x_coord=0.0;
double y_coord=0.0;
double k1=0.0;
double b1=0.0;
double k2=0.0;
double b2=0.0;
string temp_b1="";
string temp_b2="";
while (choise.Key!=ConsoleKey.Q)
{
    //ввод данных первого уравнения
    while (choise.Key!=ConsoleKey.N)
    {
        Console.Clear();
        k1=check_int_input($"Введите k1, для y=k1*x + b1 ");
        b1=check_int_input($"Введите b1, для y={k1}*x + b1 ");
        if (b1>0) temp_b1="+" + Math.Abs(b1);
        if (b1<0.0) temp_b1="-"  + Math.Abs(b1);
        if (b1==0.0) temp_b1="";
        Console.Clear();
        Console.WriteLine($"Вы ввели данные первого уравнения: y={k1}*x {temp_b1}, N - продолжить, R - скорректировать ввод, Q - выход из программы");
        choise=Console.ReadKey();
        if (choise.Key==ConsoleKey.Q) break; //выход из приложения
    }
    Console.Clear();
    //удаляем прошлое подтверждение
    if (choise.Key==ConsoleKey.N) 
    {
        choise=new ConsoleKeyInfo(); 
    }
    //ввод данных второго уровнения
    while (choise.Key!=ConsoleKey.N)
    {
        Console.Clear();
        k2=check_int_input($"Введите k2, для y=k2*x + b2 ");
        b2=check_int_input($"Введите b2, для y={k2}*x + b2 ");
        if (b2>0) temp_b2="+" + Math.Abs(b2);
        if (b2<0.0) temp_b2="-"  + Math.Abs(b2);
        if (b2==0.0) temp_b2="";
        Console.Clear();
        Console.WriteLine($"Вы ввели данные второго уравнения: y={k2}*x {temp_b2}, N - продолжить, R - скорректировать ввод, Q - выход из программы");
        choise=Console.ReadKey();
        if (choise.Key==ConsoleKey.Q) break; //выход из приложения
    }
    Console.Clear();
    if (k1==k2)
    {
        Console.WriteLine($"Линии (y={k1}*x {temp_b1}) и (y={k2}*x {temp_b2}) параллельны и не пересекаются");
    }
    else
    {
        //пересечение прямых при x1=x2, y1=y2
        //y1=y2=k1*x + b1 = k2*x + b2
        //x=(b2-b1)/(k1-k2);
        x_coord=(b2-b1)/(k1-k2);
        y_coord=k1*x_coord + b1;
        Console.WriteLine($"Линии (y={k1}*x {temp_b1}) и (y={k2}*x {temp_b2}) пересекаются в точке ({x_coord};{y_coord})");
    }
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите Q");
    choise=Console.ReadKey();
}