/*
Задача 10: Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает вторую цифру этого числа.
456 -> 5
782 -> 8
918 -> 1
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
//метод вычленяющий нужный нам знак
int show_sign_by_number(int input, int sign)
{
    if (sign>=1)
    {
        return (input % Convert.ToInt32(Math.Pow(10.0, Convert.ToDouble(sign)))/
                       Convert.ToInt32(Math.Pow(10.0, Convert.ToDouble(sign-1)) ));
    }
    else
    {
        Console.WriteLine("show_sign_by_number: Параметры метода заданы некорректно");
        return -1;
    }
}
//метод возвращающий количество знаков в числе
int show_sign_count (int input)
{
    int temp=input;
    int sign_count=0;
    //проверка сколько знаков в числе
    while (temp>0)
    {
        temp=temp/10;
        sign_count++;
    }
    return sign_count;
}

ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
choise=Console.ReadKey();
while (choise.Key!=ConsoleKey.Q)
{
    int number=check_int_input("Введите число "); //ввод числа, в котором ищем цифру
    int sign=check_int_input($"Введите номер цифры числа {number} числа для отображения"); //ввод номера цифры, которую ишем в числе
    int sign_count=show_sign_count(number); //находим сколько цифр в числе
    int result=show_sign_by_number(number, sign); //находим цифру в числе

    Console.Clear();
    Console.WriteLine($"Вы ввели число {number} и хотели найти его {sign} цифру, результат: в числе {sign_count} цифр, {sign}ая цифра это {result}");
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
    choise=Console.ReadKey();
}
