/*=================================================================================================================*/
/*Задача 2: Напишите программу, которая на вход принимает два числа и выдаёт, какое число большее, а какое меньшее.*/
/*=================================================================================================================*/
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
double a=0.0;            //первое число  
double b=0.0;            //второе число
a=check_input("Введите первое число: ");
b=check_input("Введите второе число: ");

//сравнение и вывод результата
if (a>b)
{
    Console.Write($"Наибольшее число из чисел {a} и {b} равно {a}");
}
if (a<b)
{
    Console.Write($"Наибольшее число из чисел {a} и {b} равно {a}");
}
if (a==b)
{
    Console.Write($"Числа {a} и {b} равны");
}

