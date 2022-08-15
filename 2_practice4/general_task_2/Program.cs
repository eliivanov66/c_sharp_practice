//библиотека методов из прошлого задания
using static Librarys;

//метод конверсии десятичного числа в двоичное
int convert_bin_to_dec(int arg_input, int arg_base)
{
    int result=0;
    int sign_count=show_sign_count_int(arg_input); //сколько разрядов в числе
    Console.WriteLine($"Количество разрядов числа sign_count = {sign_count}");
    //111101
    for (int i = 0; i < sign_count; i++)
    {
        int sign_value=show_sign_by_number(arg_input, i + 1); //показывает значение в текущем разряде
        Console.WriteLine($"Значение в разряде sign_value = {sign_value}");
        result=result + sign_value * Convert.ToInt32(Math.Pow(2.0, i));      //значение результата для текущего разряда
        Console.WriteLine($"Промежуточный результат result = {result}");
    }
    return result;
}


//код задачи
int input=0; //ввод от пользователя

while (input<=0)
{
    input=check_int_input("Введите число для конверсии ");
}
int result=convert_bin_to_dec(input, 10);
Console.WriteLine($"Число после конверсии: {result}");
