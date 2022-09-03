/*
66. Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.

M = 1; N = 15 -> 120
M = 4; N = 8. -> 30
*/
using static Librarium;
int StartValue=default(int);
int EndValue=default(int);
int Sum=default(int);
while (StartValue>=EndValue)
{
    Console.Clear();
    StartValue=CheckIntInput("Введите начальное значение ");
    EndValue=CheckIntInput("Введите конечное значение ");
}
Console.WriteLine($"Числа в промежутке ({StartValue};{EndValue}): ");
Console.Write("(");
for (int i = Convert.ToInt32(StartValue); i <= Convert.ToInt32(EndValue); i++)
{
    Console.Write($" {i}");
    Sum+=i;   
}
Console.WriteLine(")");
Console.WriteLine($"Сумма этих числе равна: {Sum}");
