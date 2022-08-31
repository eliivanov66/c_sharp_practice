/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/
using static Librarium;
int InputRow=default(int);
int InputColumn=default(int);
int[,] InputArray;
int[,] ResultArray;
Console.Clear();
while (InputRow<=0) InputRow=CheckIntInput("Введите количество строк двумерного массива ");
while (InputColumn<=0) InputColumn=CheckIntInput("Введите количество столбцов двумерного массива ");
InputArray=InitIntMatrix(ArgRow:InputRow, 
                         ArgColumn: 
                         InputColumn, 
                         ArgStart:0, 
                         ArgEnd:100, 
                         AutoFill: true);
Console.WriteLine("Был сгенерирован следующий массив: ");
DisplayMatrix(InputArray);
//сортировка по-убыванию
ResultArray=SortRowMatrix(ArgMatrix:InputArray,
                          ArgWay: false);

Console.WriteLine("Массив после сортировки: ");
DisplayMatrix(ResultArray);
