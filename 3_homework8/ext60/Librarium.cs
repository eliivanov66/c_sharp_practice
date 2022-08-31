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
    //метод заполнения трёхмерного массива числами в диапазоне от start до end
    public static int[,,] InitInt3D(int ArgRow, int ArgColumn, int ArgDeep, int ArgStart, int ArgEnd, bool AutoFill)
    {
        int[,,] TempArray;
        List<int> UsedNumbers=new List<int>{0};
        if (ArgRow>=1 && ArgColumn>=1 && ArgDeep>=1) TempArray=new int[ArgRow, ArgColumn, ArgDeep]; //количество
        else TempArray=new int[1, 1, 1];
        
        for (int i=0; i<TempArray.GetLength(0); i++)
        {
            for (int j=0; j<TempArray.GetLength(1); j++)
            {
                for (int k=0; k<TempArray.GetLength(2); k++)
                {
                    TempArray[i,j,k]=default(int);
                } 
            }  
        }
        if (AutoFill) //1=автозаполнение
        {
            for (int i = 0; (i < TempArray.GetLength(0)); i++)
            {   
                for (int j = 0; j < TempArray.GetLength(1); j++)
                {
                    for (int k = 0; k < TempArray.GetLength(2); k++)
                    {
                        while ( (UsedNumbers.Contains(TempArray[i,j,k])) || 
                                (TempArray[i,j,k]==default(int))          
                                )
                        {
                            TempArray[i,j,k]=System.Random.Shared.Next(ArgStart, ArgEnd +1);
                        }
                        UsedNumbers.Add(TempArray[i,j,k]);
                    }
                }
                
            }
        }
        else
        {

            for (int i = 0; (i < TempArray.GetLength(0)); i++)
            {   
                for (int j = 0; j < TempArray.GetLength(1); j++)
                {
                    
                    for (int k = 0; k < TempArray.GetLength(2); k++)
                    {
                        Console.Clear();
                        while ( (UsedNumbers.Contains(TempArray[i,j,k])) || 
                                (TempArray[i,j,k]==default(int))         ||
                                (TempArray[i,j,k]<ArgStart)              ||
                                (TempArray[i,j,k]>ArgEnd+1)
                                )
                        {
                            TempArray[i,j,k]=CheckIntInput($"Введите значение [{i},{j},{k}]/[{ArgRow-1},{ArgColumn-1},{ArgDeep-1}] элемента ");
                        }
                        UsedNumbers.Add(TempArray[i,j,k]);                   
                    }
                    
                }
                
            }
        }
        return TempArray;
    }

    //метод рисования матрицы
    static public void Display3D(int[,,] ArgMatrix)
    {
        for (int i = 0; i < ArgMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < ArgMatrix.GetLength(1); j++)
            {
                for (int k = 0; k < ArgMatrix.GetLength(2); k++)
                {
                    Console.WriteLine($"{ArgMatrix[i,j,k]} ({i},{j},{k})");
                }
            }
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
}