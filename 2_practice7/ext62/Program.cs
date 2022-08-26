/*
62. В двумерном массиве целых чисел. Удалить строку и столбец, на пересечении которых расположен наименьший элемент.
*/
int[,] GenerationRandomMatrix(int x, int y, int min, int max)
{
    int[,] matrix1 = new int[x, y];
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix1.GetLength(1); j++)
        {
            matrix1[i, j] = new Random().Next(min, max+1);
        }
    }
    return matrix1;
}
//метод отображения матрицы
void displayMatrix(int[,] arg_matrix)
    {
        int min=(findMinMatrix(arg_matrix)).Item1; //минимальное значение в матрице
        int max=(findMaxMatrix(arg_matrix)).Item1; //максимальное значение в матрице
        int max_element_lenght=0;
        if (Math.Abs(min)>Math.Abs(max))
        {
            max_element_lenght=Convert.ToString(min).Length; //максимальная значение символов
        }
        else
        {
            max_element_lenght=Convert.ToString(max).Length; //максимальная значение символов 
        }
        //шапка матрицы
        Console.Write($"{string.Concat(Enumerable.Repeat(" " ,  arg_matrix.GetLength(0).ToString().Length+2))}||"); //вывод результата
        for (int i = 0; i < arg_matrix.GetLength(0); i++) //x
        {  
            string space=string.Concat(Enumerable.Repeat(" " , max_element_lenght - 1 - i.ToString().Length));
            Console.Write($"n:{i+1}{space}|"); //вывод результата
        }
        Console.WriteLine("|"); //вывод результата
        //построчное заполнение матрицы
        for (int i = 0; i < arg_matrix.GetLength(0); i++) //x
        {
            string space=string.Concat(Enumerable.Repeat(" " ,  arg_matrix.GetLength(0).ToString().Length - i.ToString().Length));
            Console.Write($"m:{i+1}{space}||"); //вывод результата
            for (int j = 0; j < arg_matrix.GetLength(1); j++) //y
            {
            //красивое отображение матрицы
            int sign_count=Convert.ToString(arg_matrix[i,j]).Length;
            space=string.Concat(Enumerable.Repeat(" " , max_element_lenght-sign_count + 1));
            Console.Write($"{arg_matrix[i,j]}{space}|"); //вывод результата
            }
        Console.Write("|");    
        Console.WriteLine();
        }
    }
//метод поиска максимального значения в массиве
(int,int,int) findMaxMatrix(int[,] arg_matrix)
    {
        int max = arg_matrix[0,0];
        int max_x=0;
        int max_y=0;
        for (int i = 0; i < arg_matrix.GetLength(0); i++)
        {
            for (int j = 0; j <  arg_matrix.GetLength(1); j++)
            {
                if (arg_matrix[i,j]>max) 
                {
                    max=arg_matrix[i,j];
                    max_x=i;
                    max_y=j;
                }
            }
        }
        return (max,max_x,max_y);
    }
//метод поиска минимального значения в массиве
(int,int,int) findMinMatrix(int[,] arg_matrix)
{
    int min = arg_matrix[0,0];
    int min_x=0;
    int min_y=0;
    for (int i = 0; i < arg_matrix.GetLength(0); i++)
    {
        for (int j = 0; j <  arg_matrix.GetLength(1); j++)
        {
            if (arg_matrix[i,j]<min)
            { 
                min=arg_matrix[i,j];
                min_x=i;
                min_y=j;
            }
        }
    }
    return (min, min_x, min_y);
}
//метод поиска минимального значения в массиве
int[,] RemoveElementMatrix(int[,] matrix, int x, int y)
{
    int[,] result=new int[matrix.GetLength(0)-1, matrix.GetLength(1)-1];
    int m=0;
    int n=0;
    for (int i = 0; i < result.GetLength(0); i++)
    {
        if (i<x) m=0; 
        else m=1;
        for (int j = 0; j < result.GetLength(1); j++)
        {
            if (i<y) n=0; 
            else n=1;
            result[i,j]=matrix[i+m,j+n];
            //00R00 //0000
            //00R00 //0000
            //RRDRR //0000
            //00R00
        }
    }
    return result;
}

int[,] inputArray;
int M;
int N;
ConsoleKeyInfo choise;
Console.WriteLine("Для продолжения нажмите любую клавишу, для выхода Q ");
choise=Console.ReadKey();

while (choise.Key!=ConsoleKey.Q)
{
    Console.Clear();
    Console.WriteLine("Введите размерность матрицы m: ");
    M=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите размерность матрицы n: ");
    N=Convert.ToInt32(Console.ReadLine());

    inputArray=GenerationRandomMatrix(M,N, 0, 100);
    Console.WriteLine("Получена следующая матрица :");
    displayMatrix(inputArray);
    (int,int,int) result=findMinMatrix(inputArray);
    Console.WriteLine($"Наименьший элементы матрицы является {result.Item1}, он находится на строке {result.Item2+1}, на столбце {result.Item3+1}");

    int [,] resultArray=RemoveElementMatrix(inputArray, result.Item2, result.Item3);
    Console.WriteLine("Результирующая матрица :");
    displayMatrix(resultArray);
    Console.WriteLine("Для продолжения нажмите любую клавишу, для выхода Q ");
    choise=Console.ReadKey();
}

