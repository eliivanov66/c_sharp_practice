/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/
using static Librarium;
int InputRow=default(int);
int InputColumn=default(int);
int[,] InputArray;
int Result;
Console.Clear();
while (InputRow<=0) InputRow=CheckIntInput("Введите количество строк двумерного массива ");
while (InputColumn<=0) InputColumn=CheckIntInput("Введите количество столбцов двумерного массива ");
InputArray=InitIntMatrix(ArgRow:InputRow, 
                         ArgColumn: 
                         InputColumn, 
                         ArgStart:0, 
                         ArgEnd:5, 
                         AutoFill: true);
Console.WriteLine("Был сгенерирован следующий массив: ");
DisplayMatrix(InputArray);
//поиск строки с наименьшей суммой чисел
Result=FindMinRowSumMatrix(ArgMatrix:InputArray);
Console.WriteLine($"Наименьшая сумма находится в строке {Result}");
