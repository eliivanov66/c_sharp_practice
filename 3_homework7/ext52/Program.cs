/*
Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
*/
using static Librarium;
int[,] Array;
double[] Result;
Console.Clear();
//заполнение матрицы
Array=InitIntMatrix(
                       ArgLine:  5,
                       ArgRow:   5,
                       ArgStart: 0,
                       ArgEnd:   10,
                       AutoFill: true
                      );
//отоброжение матрицы
Console.WriteLine("Сгенерирована следующая матрица: ");                   
DisplayMatrix(
                ArgMatrix: Array
             );
Result=FindSumRow(Array);
//вывод результата
Console.WriteLine("Среднее арифметическое каждого из её столбцов: ");
for (int i = 0; i < Result.GetLength(0); i++)
{
    Console.Write($"{Result[i]};");
}

            
