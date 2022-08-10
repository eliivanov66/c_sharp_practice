/*
43. Написать программу преобразования десятичного числа в двоичное
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
//метод конверсии десятичного числа в двоичное
int convert_dec_to_bin(int arg_input)
{
    int temp_input=0;
    int result=0;
    int position=0; //разряд, движется справо на лево, возводя 10 в степень разряда
    temp_input=arg_input;
    while (temp_input>0)
    {
        result = result + Convert.ToInt32((temp_input % 2) != 0) * Convert.ToInt32(Math.Pow(10.0, Convert.ToDouble(position))); 
        temp_input=temp_input / 2;
        position++;
    }
    return result;
}

ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите Q");
choise=Console.ReadKey();
int input=0;
int way=0;
while (choise.Key!=ConsoleKey.Q)
{
    Console.Clear();
    input=check_int_input("Введите десятичное число, для конверсии его в двоичное ");
    while (way<1 || way>2)
    {
        way=check_int_input($"Введённое число {input}, 1 - конвертировать через форматирование, 2 - конвертировать через мат. алгоритм");
    }
    if (way==1)
    {
        //конверсия через форматирование
        Console.WriteLine($"Вы ввели ({input}), его двоичный вид ({Convert.ToString(input, 2)}), для выхода из программы нажмите Q");
    }
    else
    {
        //конверсия через функцию преобразования
        Console.WriteLine($"Вы ввели ({input}), его двоичный вид ({convert_dec_to_bin(input)}), для выхода из программы нажмите Q");
    }
    way=0;
    choise=Console.ReadKey();
}