/*=====================================================================================================================================*/
/*Задача 6: Напишите программу, которая на вход принимает число и выдаёт, является ли число чётным (делится ли оно на два без остатка).*/
/*=====================================================================================================================================*/
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
        catch (SystemException) //если это не Double
        {
            input_data_not_ok=1;
            err_message="Вы ввели не число. ";
        }
    }
    return temp;
}
double a=0.0; //делимое
double b=0.0; //делитель

a=check_input("Введите делимое, любое число: ");

while (b==0.0) //делить на нуль нельзя
{
    b=check_input("Введите делитель: ");
}
if (a%b==0.0)
{
    Console.WriteLine($"Число {a} делится на число {b} без остатка");
}
else
{
    Console.WriteLine($"Число {a} делится на число {b} с остатком {a%b}");
}