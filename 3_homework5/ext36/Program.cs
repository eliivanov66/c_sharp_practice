/*Задача 36: Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.

[3, 7, 23, 12] -> 19

[-4, -6, 89, 6] -> 0
*/
using static Librarium;
int even_summ=0; //количество нечётных чисил в массиве
int input=0; //размерность массива
while (input<=1) input=check_int_input("Введите размерность массива "); //получаем размерность массива
int[] result_array= init_int_array(input, -999, 999); //заполнение массива случайными числами
Console.WriteLine("Был сгенерирован следующий массив: "); 
display_array(result_array); //вывод сгенерированного массива
for (int i=0; i< result_array.GetLength(0); i++)
{
    if ((i%2!=0)) even_summ=even_summ+result_array[i];
}
Console.WriteLine($"Сумма чисел нечётных элементов равна {even_summ}");