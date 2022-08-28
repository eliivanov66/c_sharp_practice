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
    public static int[,] InitIntMatrix(int ArgLine, int ArgRow, int ArgStart, int ArgEnd, bool AutoFill)
    {
        int[,] TempArray;
        if (ArgLine>=1 && ArgRow>=1) TempArray=new int[ArgLine, ArgRow]; //количество
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
                    TempArray[i,j]=CheckIntInput($"Введите значение [{i},{j}]/[{ArgLine-1},{ArgRow-1} элемента ");
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
        //шапка матрицы
        Console.Write($"{string.Concat(Enumerable.Repeat(" " ,  ArgMatrix.GetLength(0).ToString().Length+2))}||"); //вывод результата
        for (int i = 0; i < ArgMatrix.GetLength(0); i++) //x
        {  
            string Spaces=string.Concat(Enumerable.Repeat(" " , MaxLenght - 1 - i.ToString().Length));
            Console.Write($"n:{i+1}{Spaces}|"); //вывод результата
        }
        Console.WriteLine("|"); //вывод результата
        //построчное заполнение матрицы
        for (int i = 0; i < ArgMatrix.GetLength(0); i++) //x
        {
            string Spaces=string.Concat(Enumerable.Repeat(" " ,  ArgMatrix.GetLength(0).ToString().Length - i.ToString().Length));
            Console.Write($"m:{i+1}{Spaces}||"); //вывод результата
            for (int j = 0; j < ArgMatrix.GetLength(1); j++) //y
            {
            //красивое отображение матрицы
            int SignCount=Convert.ToString(ArgMatrix[i,j]).Length;
            Spaces=string.Concat(Enumerable.Repeat(" " , MaxLenght-SignCount + 1));
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
    //метод находящий первое вхождение в двумерный массив
    public static double[] FindSumRow(int[,] ArgMatrix)
    {
        double[] TempResult=new double[ArgMatrix.GetLength(1)];
        for (int i = 0; i < ArgMatrix.GetLength(1); i++)
        {
            for (int j = 0; j < ArgMatrix.GetLength(0); j++)
            {
                TempResult[i]=TempResult[i]+ArgMatrix[j,i];
            }
            TempResult[i]=TempResult[i]/ArgMatrix.GetLength(0);
        }
        return (TempResult);
    }
}