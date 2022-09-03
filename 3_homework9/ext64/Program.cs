/*
Задача 64: Задайте значения M и N. Напишите программу, которая выведет все натуральные числа в промежутке от M до N.

M = 1; N = 5. -> ""1, 2, 3, 4, 5""
M = 4; N = 8. -> ""4, 6, 7, 8""
*/
using static Librarium;
int StartValue=default(int);
int EndValue=default(int);
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
}
Console.Write(")");
Console.WriteLine();
