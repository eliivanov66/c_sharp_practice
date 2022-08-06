/*======================================================================================================================*/
/* Задача 8: Напишите программу, которая на вход принимает число (N), а на выходе показывает все чётные числа от 1 до N */
/*======================================================================================================================*/
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
double input=0.0;  //вводные данные
int temp_input=0;  //промежуточная конверсия  
double result=0.0; //переменная для вывода результата

input=check_input("Введите число ");
//избавляемся от хвоста после запятой
temp_input=Convert.ToInt32(input);
input=Convert.ToDouble(temp_input);

result=0.0;
Console.WriteLine($"Чётные числа между 0 и {input}:");
while (Math.Abs(result)<Math.Abs(input))
{
    if (result!=0.0) Console.Write($" {result}");
    //выбираем направление отчёта
    if (input<0.0)
    {
        result=result-2.0;  
    }
    if (input>0.0)
    {
        result=result+2.0;
    }
} 
