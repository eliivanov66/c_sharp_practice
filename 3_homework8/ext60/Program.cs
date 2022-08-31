/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0)
25(0,1,0)
34(1,0,0)
41(1,1,0)
27(0,0,1)
90(0,1,1)
26(1,0,1)
55(1,1,1)
*/
using static Librarium;
int InputX=default(int);
int InputY=default(int);
int InputZ=default(int);
int[,,] InputArray;

Console.Clear();
while (InputX<=0) InputX=CheckIntInput("Введите размерность X трёхмерного массива ");
while (InputY<=0) InputY=CheckIntInput("Введите размерность Y трёхмерного массива ");
while (InputZ<=0) InputZ=CheckIntInput("Введите размерность Z трёхмерного массива ");
InputArray=InitInt3D(ArgRow: InputX, 
                     ArgColumn: InputY, 
                     ArgDeep: InputZ,    
                     ArgStart:10, 
                     ArgEnd:98, 
                     AutoFill: true);
Console.WriteLine("Была получена следующий массив: ");
Display3D(InputArray);

