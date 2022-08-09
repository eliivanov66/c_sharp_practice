/* Задача 15: Напишите программу, которая принимает на вход цифру, обозначающую день недели, и проверяет, является ли этот день выходным.

6 -> да
7 -> да
1 -> нет
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
string[] day_of_week = {"Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье"};
while (choise.Key!=ConsoleKey.Q)
{
    int number=0;
    while (number<1 || number>7)
    {
        number=check_int_input("Введите номер дня недели"); //ввод числа номера недели
    }

    Console.Clear();
    if (number>=6) //если в есть цифра под нужным нам номером
    {
        Console.WriteLine($"Вы ввели номер дня недели {number}, это {day_of_week[number-1].ToLower()} и это выходной");

    }
    else
    {
         Console.WriteLine($"Вы ввели номер дня недели {number}, это {day_of_week[number-1].ToLower()} и это будний день");
    }


    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
    choise=Console.ReadKey();
}
