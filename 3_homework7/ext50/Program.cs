/*
Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
17 -> такого числа в массиве нет
*/
using static Librarium;

int Target=default(int);
int[,] Array;
(bool, int, int) Result;
Console.Clear();
//заполнение матрицы
Array=InitIntMatrix(
                       ArgLine:  5,
                       ArgRow:   5,
                       ArgStart: -100,
                       ArgEnd:   100,
                       AutoFill: true
                      );
//отоброжение матрицы
Console.WriteLine("Сгенерирована следующая матрица: ");                   
DisplayMatrix(
                ArgMatrix: Array
             );
//запрос искомого числа
Target=CheckIntInput(
                    Message: "Введите искомое число: "
                    );
//поиск числа в матрице
Result=FindInMatrix(
             ArgMatrix: Array, 
             ArgTarget: Target
            );
//вывод результата
if (Result.Item1)
{
    Console.WriteLine($"Число {Target} найдено на строке {Result.Item2+1}, столбце {Result.Item3+1}");
}
else
{
    Console.WriteLine($"Число {Target} не найдено в матрице");
}

            
