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

    public static double CheckDoubleInput(string Message)
    {
        bool DataNotOk=true;            //введены некорректные данные
        double Input=default(double); //число для ввода
        string TempInput=$"{default(string)}";
        string ErrMessage=$"{default(string)}"; //сообщение об ошибке
        while (DataNotOk) //пока введены некорректные данные
        {
            Console.WriteLine($"{ErrMessage}{Message} :");
            try
            {   
                TempInput=$"{Console.ReadLine()}";
                TempInput.Replace(".",",");
                Input=Convert.ToDouble(TempInput);
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
    public static double[,] InitDoubleMatrix(int ArgLine, int ArgRow, int ArgStart, int ArgEnd, bool AutoFill)
    {
        double[,] TempArray;
        if (ArgLine>=1 && ArgRow>=1) TempArray=new double[ArgLine, ArgRow]; //количество
        else TempArray=new double[1, 1];
        
        if (AutoFill) //1=автозаполнение
        {
            for (int i = 0; (i < TempArray.GetLength(0)); i++)
            {   
                for (int j = 0; j < TempArray.GetLength(1); j++)
                {
                    TempArray[i,j]=System.Random.Shared.NextDouble()*System.Random.Shared.Next(ArgStart, ArgEnd +1);
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
                    TempArray[i,j]=CheckDoubleInput($"Введите значение [{i},{j}]/[{ArgLine-1},{ArgRow-1} элемента ");
                }
                
            }
        }
        return TempArray;
    }
    //метод рисования матрицы
   static public void DisplayMatrix(double[,] ArgMatrix)
    {
        double Min=(MinMatrix(ArgMatrix)); //минимальное значение в матрице
        double Max=(MaxMatrix(ArgMatrix)); //максимальное значение в матрице
        int MaxLenght=default(int);
        if (Math.Abs(Min)>Math.Abs(Max))
        {
            MaxLenght=Convert.ToString(Math.Round(Min,2)).Length; //максимальная значение символов
        }
        else
        {
            MaxLenght=Convert.ToString(Math.Round(Max,2)).Length; //максимальная значение символов 
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
            int SignCount=Convert.ToString(Math.Round(ArgMatrix[i,j],2)).Length;
            Spaces=string.Concat(Enumerable.Repeat(" " , MaxLenght-SignCount + 1));
            Console.Write($"{Math.Round(ArgMatrix[i,j],2)}{Spaces}|"); //вывод результата
            }
        Console.Write("|");    
        Console.WriteLine();
        }
    }
    //метод поиска максимального значения в массиве
    public static double MaxMatrix(double[,] ArgMatrix)
    {
        double Max = ArgMatrix[0,0];
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
    public static double MinMatrix(double[,] ArgMatrix)
    {
        double Min = ArgMatrix[0,0];
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
}