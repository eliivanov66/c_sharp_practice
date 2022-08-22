/*Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.

[3 7 22 2 78] -> 76
*/
using static Librarium;
int input=0; //размерность массива
double min=0.0;
double max=0.0;

while (input<=1) input=check_int_input("Введите размерность массива "); //получаем размерность массива
double[] result_array= init_double_array(input, -999, 999); //заполнение массива случайными числами
Console.WriteLine("Был сгенерирован следующий массив: "); 
display_double_array(result_array); //вывод сгенерированного массива
min=result_array[0];
max=result_array[0];
for (int i=0; i< result_array.GetLength(0); i++)
{
    if (result_array[i]<min) min=result_array[i];
    if (result_array[i]>max) max=result_array[i];
}
Console.WriteLine($"Разница между максимальным и минимальным значением равна: {max - min}");