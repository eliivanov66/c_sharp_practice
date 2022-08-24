/*Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.

0, 7, 8, -2, -2 -> 2

1, -7, 567, 89, 223-> 3
*/

using static Librarium;

int array_size=default;
int[] input_array;
int positive_count=default;
while (array_size<=0)
{
    array_size=check_int_input("Введите размерность массива ");
}
input_array=init_int_array(array_size, -999, 999, false); //ручной ввод массива
Console.WriteLine($"Получен массив: ");
display_array(input_array);
for (int i = 0; i < input_array.GetLength(0); i++)
{
    if (input_array[i]>0) positive_count++;
}
Console.WriteLine($"Пользователь ввёл {positive_count} положительных чисел");