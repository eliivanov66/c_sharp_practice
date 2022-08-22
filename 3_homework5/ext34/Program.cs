/*Задача 34: Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.

[345, 897, 568, 234] -> 2
*/
using static Librarium;
int odd_count=0; //количество нечётных чисил в массиве
int input=0; //размерность массива
while (input<=1) input=check_int_input("Введите размерность массива "); //получаем размерность массива
int[] result_array= init_int_array(input, 100, 999); //заполнение массива случайными числами
Console.WriteLine("Был сгенерирован следующий массив: "); 
display_array(result_array); //вывод сгенерированного массива
for (int i=0; i< result_array.GetLength(0); i++)
{
    if ((result_array[i]!=0) && (result_array[i]%2==0)) odd_count++;
}
Console.WriteLine($"В массиве находится {odd_count} нечётных числа");