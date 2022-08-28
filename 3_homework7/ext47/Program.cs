/*
Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

m = 3, n = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9
*/

using static Librarium;

int m=default(int);
int n=default(int);
double[,] Array;
Console.Clear();
//запрос количества строк
while (m<=0) 
{
    m=CheckIntInput(
                    Message: "Введите количество строк массива: "
                   );
}
//запрос количества столбцов
while (n<=0) 
{
    n=CheckIntInput(
                    Message: "Введите количество столбцов массива: "
                   );
}
//заполнение матрицы
Array=InitDoubleMatrix(
                       ArgLine:  m,
                       ArgRow:   n,
                       ArgStart: -100,
                       ArgEnd:   100,
                       AutoFill: true
                      );
//отоброжение матрицы                   
DisplayMatrix(
                ArgMatrix: Array
             );
            
