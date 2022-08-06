/*=================================================================================================*/
/*=== Напишите программу, которая принимает на вход три числа и выдаёт максимальное из этих чисел. */
/*=================================================================================================*/
//метод, мы ведь методы изучали
double check_input(string message)
{
    int input_data_not_ok=1; //данные введены корректно
    string err_message = "";
    double temp=0.0;
    while (input_data_not_ok==1)
    {
        try
        {
            Console.Clear();
            Console.Write($"{err_message}{message}");
            temp=Convert.ToDouble(Console.ReadLine());
            input_data_not_ok=0;
        }
        catch (SystemException) //если это не integer
        {
            input_data_not_ok=1;
            err_message="Некорректные данные. ";
        }
    }
    return temp;
}
//переменные
double a=0.0;   //первое число
double b=0.0;   //второе число
double c=0.0;   //третье число
double max=0.0; //максимальное число
//получение данных
a=check_input("Введите первое число: ");
b=check_input("Введите второе число: ");
c=check_input("Введите третье число: ");
//логика
max=a;
if (b>max) max=b;
if (c>max) max=c;

//вывод результата
Console.WriteLine($"Максимальное число из чисел {a} {b} {c} равно {max}");