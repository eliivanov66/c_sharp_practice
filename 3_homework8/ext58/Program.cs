/*
Задача о сложении/ умножение матриц
*/
using static Librarium; //библиотека

int Matrix1x=default(int);
int Matrix1y=default(int);
int[,] Matrix1;
int Matrix2x=default(int);
int Matrix2y=default(int);
int[,] Matrix2;
(bool, int[,]) Result;

Console.Clear();
Console.WriteLine("===========================================================");
Console.WriteLine("=============== Умножение двух матриц =====================");
Console.WriteLine("===========================================================");
Matrix1x=CheckIntInput("Введите количество строк первой матрицы ");
Matrix1y=CheckIntInput("Введите количество столбцов первой матрицы ");
Matrix1=InitIntMatrix(Matrix1x, Matrix1y,0,9,true); //создание первой матрицы
Console.WriteLine("Первая матрица :");
DisplayMatrix(Matrix1); //отображение первой матрицы

Matrix2x=CheckIntInput("Введите количество строк второй матрицы ");
Matrix2y=CheckIntInput("Введите количество столбцов второй матрицы ");
Console.WriteLine("Вторая матрица :");
Matrix2=InitIntMatrix(Matrix2x, Matrix2y,0,9,true); //создание второй матрицы
DisplayMatrix(Matrix2); //отображение второй матрицы
Console.WriteLine("Результат умножения матриц :");
Result=MultMatrix(Matrix1,Matrix2);
if (Result.Item1) DisplayMatrix(Result.Item2); //результат отображения матриц
else Console.WriteLine($"Умножение матриц не возможно, так как число столбцов первой матрицы {Matrix1x}!=числу строк творой матрицы {Matrix2y}");
