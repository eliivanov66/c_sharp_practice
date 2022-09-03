public class Librarium
{
    //метод проверки ввода от пользователя
    public static int CheckIntInput(string Message)
    {
        bool DataNotOk=true;            //введены некорректные данные
        int Input=default(int); //число для ввода
        string ErrMessage=$"{default(string)}"; //сообщение об ошибке
        while (DataNotOk) //пока введены некорректные данные
        {
            Console.WriteLine($"{ErrMessage}{Message} :");
            try
            {   
                Input=Convert.ToInt32(Console.ReadLine());
                DataNotOk=false; //считаем что данные введены корректно
            }
            catch (SystemException) 
            {
                DataNotOk=true; //пока введены некорректные данные
                ErrMessage="Неправильный ввод. ";
            }
        }
        return Input;
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
    //метод рисования матрицы
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
    //метод копирования массива
    public static int[,] CopyMatrix(int[,] ArgMatrix)
    {
        int[,] TempResult=new int[ArgMatrix.GetLength(0), ArgMatrix.GetLength(1)];

        for (int i = 0; i < ArgMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < ArgMatrix.GetLength(1); j++)
            {
                TempResult[i,j]=ArgMatrix[i,j];
            }
        }
        return TempResult;
    }

    public static int[,] SortRowMatrix(int[,] ArgMatrix, bool ArgWay)
    {
        int[,] TempResult=new int[ArgMatrix.GetLength(0), ArgMatrix.GetLength(1)];
        TempResult=CopyMatrix(ArgMatrix);
        //сортировка по-убыванию
        if (!ArgWay)
        {
            for (int i = 0; i < ArgMatrix.GetLength(0); i++) //столбцы
            {
                for (int j = 0; j < ArgMatrix.GetLength(1)-1; j++) //строки
                {
                    if (TempResult[i,j]<TempResult[i, j + 1]) 
                    {
                        int temp1=TempResult[i, j];
                        int temp2=TempResult[i, j+1];
                        TempResult[i, j]  =temp2;
                        TempResult[i, j+1]=temp1;
                        j=-1;
                    }
                }
            }
        }
        else
        //сортировка по-возрастанию
        {
            for (int i = 0; i < ArgMatrix.GetLength(0); i++) //столбцы
            {
                for (int j = 0; j < ArgMatrix.GetLength(1)-1; j++) //строки
                {
                    if (TempResult[i,j]>TempResult[i, j + 1]) 
                    {
                        int temp1=TempResult[i, j];
                        int temp2=TempResult[i, j+1];
                        TempResult[i, j]  =temp2;
                        TempResult[i, j+1]=temp1;
                        j=-1;
                    }
                }
            }
        }
        return TempResult;
    }

    public static int FindMinRowSumMatrix(int[,] ArgMatrix)
    {
        int[] TempMatrix=new int[ArgMatrix.GetLength(0)];
        int Min=int.MaxValue;
        int Result=default(int);
        for (int i = 0; i < ArgMatrix.GetLength(0); i++)
        {
           for (int j = 0; j < ArgMatrix.GetLength(1); j++)
           {
                TempMatrix[i]=TempMatrix[i]+ArgMatrix[i,j];
           }
           if (TempMatrix[i]<Min) 
           {
            Min=TempMatrix[i];
            Result=i;
           } 
        }
        return Result;
    }
}