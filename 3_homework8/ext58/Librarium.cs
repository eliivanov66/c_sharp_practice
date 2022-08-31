public class Librarium
{
    //метод проверки вводимого значения
    public static int CheckIntInput(string message)
    {
        bool input_data_not_ok=true; //введены некорректные данные
        int input=0;                 //число для ввода
        string err_message="";
        while (input_data_not_ok) //пока введены некорректные данные
        {
            Console.WriteLine($"{err_message}{message} :");
            try
            {
                input=Convert.ToInt32(Console.ReadLine());
                input_data_not_ok=false; //считаем что данные введены корректно
            }
            catch (SystemException) 
            {
                input_data_not_ok=true; //пока введены некорректные данные
                err_message="Неправильный ввод. ";
            }
        }
        return input;
    }

    static public void DisplayMatrix(int[,] ArgMatrix)
    {
        int Min=(MinMatrix(ArgMatrix)); //минимальное значение в матрице
        int Max=(MaxMatrix(ArgMatrix)); //максимальное значение в матрице
        int MaxLenght=default(int);
        if (Math.Abs(Min)>Math.Abs(Max))
        {
            MaxLenght=Convert.ToString(Min).Length; //максимальная значение символов
        }
        else
        {
            MaxLenght=Convert.ToString(Max).Length; //максимальная значение символов 
        }
        if (ArgMatrix.GetLength(0).ToString().Length+2>MaxLenght) MaxLenght=ArgMatrix.GetLength(0).ToString().Length+2;
        if (ArgMatrix.GetLength(1).ToString().Length+2>MaxLenght) MaxLenght=ArgMatrix.GetLength(1).ToString().Length+2;
        //шапка матрицы
        Console.Write($"{string.Concat(Enumerable.Repeat(" " ,  MaxLenght))}||"); //вывод результата
        for (int i = 0; i < ArgMatrix.GetLength(1); i++) //y
        {  
            string Spaces=string.Concat(Enumerable.Repeat(" " , MaxLenght  - 2 - (i).ToString().Length));
            Console.Write($"n:{i}{Spaces}|"); //вывод результата
        }
        Console.WriteLine("|"); //вывод результата
        //построчное заполнение матрицы
        for (int i = 0; i < ArgMatrix.GetLength(0); i++) //x
        {
            string Spaces=string.Concat(Enumerable.Repeat(" " ,  MaxLenght  - 2 - (i).ToString().Length));
            Console.Write($"m:{i}{Spaces}||"); //вывод результата
            for (int j = 0; j < ArgMatrix.GetLength(1); j++) //y
            {
            //красивое отображение матрицы
            int SignCount=Convert.ToString(ArgMatrix[i,j]).Length;
            Spaces=string.Concat(Enumerable.Repeat(" " , MaxLenght-SignCount));
            Console.Write($"{ArgMatrix[i,j]}{Spaces}|"); //вывод результата
            }
        Console.Write("|");    
        Console.WriteLine();
        }
    }
    //метод поиска максимального значения в массиве
    public static int MaxMatrix(int[,] ArgMatrix)
    {
        int Max = ArgMatrix[0,0];
        for (int i = 0; i < ArgMatrix.GetLength(0); i++)
        {
            for (int j = 0; j <  ArgMatrix.GetLength(1); j++)
            {
                if (ArgMatrix[i,j]>Max) Max=ArgMatrix[i,j]; continue;
            }
            continue;
        }
        return Max;
    }
    //метод поиска минимального значения в массиве
    public static int MinMatrix(int[,] ArgMatrix)
    {
        int Min = ArgMatrix[0,0];
        for (int i = 0; i < ArgMatrix.GetLength(0); i++)
        {
            for (int j = 0; j <  ArgMatrix.GetLength(1); j++)
            {
                if (ArgMatrix[i,j]<Min) Min=ArgMatrix[i,j]; continue;
            }
            continue;
        }
        return Min;
    }
    
    //метод заполнения одномерного массива числами в диапазоне от start до end
    public static int[,] InitIntMatrix(int ArgRow, int ArgColumn, int ArgStart, int ArgEnd, bool AutoFill)
    {
        int[,] TempArray;
        if (ArgRow>=1 && ArgColumn>=1) TempArray=new int[ArgRow, ArgColumn]; //количество
        else TempArray=new int[1, 1];
        
        if (AutoFill) //1=автозаполнение
        {
            for (int i = 0; (i < TempArray.GetLength(0)); i++)
            {   
                for (int j = 0; j < TempArray.GetLength(1); j++)
                {
                    TempArray[i,j]=System.Random.Shared.Next(ArgStart, ArgEnd +1);
                }
                
            }
        }
        else
        {

            for (int i = 0; (i < TempArray.GetLength(0)); i++)
            {   
                for (int j = 0; j < TempArray.GetLength(1); j++)
                {
                    Console.Clear();
                    TempArray[i,j]=CheckIntInput($"Введите значение [{i},{j}]/[{ArgRow-1},{ArgColumn-1} элемента ");
                }
                
            }
        }
        return TempArray;
    }

    //метод сложения двух матриц
    public static int[,] SumMatrix(int[,] ArgMatrix1, int[,] ArgMatrix2)
    {
        int[,] ResultMatrix=new int[ArgMatrix1.GetLength(0), ArgMatrix1.GetLength(1)]; //буферного, результирующего массива
        //складывать можно только матрицы одинаковой размерности
        if ( (ArgMatrix1.GetLength(0)!=ArgMatrix2.GetLength(0)) || (ArgMatrix1.GetLength(1)!=ArgMatrix2.GetLength(1)) ) //если матрицы не совпадают по X или по Y
        {
            Console.WriteLine("Сложение матриц не возможно, так как они имеют разную размерность");
            return ResultMatrix;
        }
        else //если размерности совпадают
        {
            for (int i = 0; i < ResultMatrix.GetLength(0); i++) //x
            {
                for (int j = 0; j < ResultMatrix.GetLength(1); j++) //y
                {
                    ResultMatrix[i,j]=ArgMatrix1[i,j] + ArgMatrix2[i,j];
                }
            }
            return ResultMatrix;
        }
    }

    //метод умножения двух матриц
    public static (bool,int[,]) MultMatrix(int[,] ArgMatrix1, int[,] ArgMatrix2)
    {
        bool Posible=default(bool);
        int[,] ResultMatrix=new int[ArgMatrix1.GetLength(0), ArgMatrix2.GetLength(1)]; //буферного, результирующего массива
        //умножать можно лишь матрицы (l x m) * (m x n) = (l,n)
        if ( (ArgMatrix1.GetLength(1)!=ArgMatrix2.GetLength(0)) ) //если матрицы не совпадают по X или по Y
        {
            Posible=false;
        }
        else //если размерности подходят
        {   
            Posible=true;
            for (int i = 0; i < ArgMatrix1.GetLength(0); i++) //перебор по x1
            {
                for (int j = 0; j < ArgMatrix2.GetLength(1); j++) //перебор по по y2
                {
                    int Buffer=0; //буферная переменная
                    for (int k = 0; k < ArgMatrix1.GetLength(1); k++) //перебор по y1
                    {
                        Buffer=Buffer + ArgMatrix1[i,k]*ArgMatrix2[k,j];
                    }
                    
                    ResultMatrix[i,j]=Buffer;
                }
           }
          
        }   
        return (Posible,ResultMatrix);
    }


}