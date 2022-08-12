public class Librarium
{
    public static int randomizer(int start, int end)
    {
        System.Random temp_randomizer=new System.Random(); //новый объект генератор псевдослучайных чисел
        return temp_randomizer.Next(start, end);
    }

    //метод проверки вводимого значения
    public static int check_int_input(string message)
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
    
    //метод проверки вводимого значения универсальный
    public dynamic check_input (string message, Type arg_type)
    {
        bool input_data_not_ok=true; //введены некорректные данные
        dynamic input=0;          //число для ввода
        string err_message="";
        while (input_data_not_ok) //пока введены некорректные данные
        {
            Console.WriteLine($"{err_message}{message} :");
            try
            {
                string temp_input=Console.ReadLine()+"";
                temp_input=temp_input.Replace(".",",");
                switch (arg_type.Name)
                {
                    case ("Int32"):
                            input=Convert.ToInt32(temp_input);
                            break;
                    case ("Double"):
                            input=Convert.ToDouble(temp_input);
                            break;
                    case ("Int64"):
                            input=Convert.ToInt64(temp_input);
                            break;
                    case ("Int16"):
                            input=Convert.ToInt16(temp_input);
                            break;
                    default:
                            input=Convert.ToInt32(temp_input);
                            break;
                }
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

    //метод возвращающий количество знаков в числе
    public static int show_sign_count (int input)
    {
        int temp=input;
        int sign_count=0;
        //проверка сколько знаков в числе
        while (temp>0)
        {
            temp=temp/10;
            sign_count++;
        }
        if (input==0) sign_count=1;
        return sign_count;
    }

    //метод вычленяющий нужный нам знак
    public static int show_sign_by_number(int input, int sign)
    {
        if (sign>=1)
        {
            return (input % Convert.ToInt32(Math.Pow(10.0, Convert.ToDouble(sign)))/
                        Convert.ToInt32(Math.Pow(10.0, Convert.ToDouble(sign-1)) ));
        }
        else
        {
            Console.WriteLine("show_sign_by_number: Параметры метода заданы некорректно");
            return -1;
        }
    }

    //метод проверяющий является ли число палиндромом
    public static bool check_palindrom(int arg_input)
    {   
        bool result=false;
        int middle_sign = 0; //цифра, которая находится посередине числа
        if ( (show_sign_count(arg_input) % 2)==0 ) //если число знаков чётное, это не может быть палиндром
        {
            result=false;
        }
        else
        {
            //4123214
            middle_sign= ((show_sign_count(arg_input) / 2) + 1); //цифра, которая находится посередине числа
            for (int i=1; i<  (middle_sign - 1); i++)
            {
                if (show_sign_by_number(arg_input, i) == show_sign_by_number(arg_input, show_sign_count(arg_input) - i +1))
                {
                        result=true; continue;
                }
                else
                {
                        result=false;
                }
            }
        }
        return result;
    }

    //поиск максимального значения в матрице
    public static int find_max_matrix(int[,] arg_matrix)
    {
        int max = arg_matrix[0,0];
        for (int i = 0; i < arg_matrix.GetLength(0); i++)
        {
            for (int j = 0; j <  arg_matrix.GetLength(1); j++)
            {
                if (arg_matrix[i,j]>max) max=arg_matrix[i,j]; continue;
            }
            continue;
        }
        return max;
    }
    //метод поиска минимального значения в массиве
    public static int find_min_matrix(int[,] arg_matrix)
    {
        int min = arg_matrix[0,0];
        for (int i = 0; i < arg_matrix.GetLength(0); i++)
        {
            for (int j = 0; j <  arg_matrix.GetLength(1); j++)
            {
                if (arg_matrix[i,j]<min) min=arg_matrix[i,j]; continue;
            }
            continue;
        }
        return min;
    }

    //метод рисования матрицы
    public static void display_matrix(int[,] arg_matrix)
    {
        int min=find_min_matrix(arg_matrix); //минимальное значение в матрице
        int max=find_max_matrix(arg_matrix); //максимальное значение в матрице
        int max_element_lenght=show_sign_count(max); //максимальная значение
        //построчное заполнение матрицы
        for (int i = 0; i < arg_matrix.GetLength(0); i++) //x
        {
            Console.Write("|"); 
            for (int j = 0; j < arg_matrix.GetLength(1); j++) //y
            {
            //красивое отображение матрицы
            string space=string.Concat(Enumerable.Repeat(" " , max_element_lenght-show_sign_count(arg_matrix[i,j]) + 1));
            Console.Write($"{arg_matrix[i,j]}{space}"); //вывод результата
            }
        Console.Write("|");    
        Console.WriteLine();
        }
    }
    
    //метод заполнения матрицы
    public static int[,] init_matrix(int x, int y)
    {
        int[,] matrix=new int[x,y]; //создание матрицы
        //построчное заполнение матрицы
        for (int i = 0; i < Convert.ToInt32(Math.Abs(Convert.ToDouble(x))); i++) //x
        {
            for (int j = 0; j < Convert.ToInt32(Math.Abs(Convert.ToDouble(y))); j++) //y
            {
                matrix[i,j]=randomizer(0, 10);
            }
        }
        return matrix;
    }

    //метод сложения двух матриц
    public static int[,] sum_matrix(int[,] arg_matrix1, int[,] arg_matrix2)
    {
        int[,] buffer_matrix=new int[arg_matrix1.GetLength(0), arg_matrix1.GetLength(1)]; //буферного, результирующего массива
        //складывать можно только матрицы одинаковой размерности
        if ( (arg_matrix1.GetLength(0)!=arg_matrix2.GetLength(0)) || (arg_matrix1.GetLength(1)!=arg_matrix2.GetLength(1)) ) //если матрицы не совпадают по X или по Y
        {
            Console.WriteLine("Сложение матриц не возможно, так как они имеют разную размерность");
            return buffer_matrix;
        }
        else //если размерности совпадают
        {
            for (int i = 0; i < buffer_matrix.GetLength(0); i++) //x
            {
                for (int j = 0; j < buffer_matrix.GetLength(1); j++) //y
                {
                    buffer_matrix[i,j]=arg_matrix1[i,j] + arg_matrix2[i,j];
                }
            }
            return buffer_matrix;
        }
    }

    //метод умножения двух матриц
    public static int[,] mult_matrix(int[,] arg_matrix1, int[,] arg_matrix2)
    {
        int[,] buffer_matrix=new int[arg_matrix1.GetLength(0), arg_matrix2.GetLength(1)]; //буферного, результирующего массива
        //умножать можно лишь матрицы (l x m) * (m x n) = (l,n)
        if ( (arg_matrix1.GetLength(1)!=arg_matrix2.GetLength(0)) ) //если матрицы не совпадают по X или по Y
        {
            Console.WriteLine("Умножение матриц не возможно, не выполнено условие (l x m) * (m x n) = (l,n)");
            return buffer_matrix;
        }
        else //если размерности подходят
        {
            for (int i = 0; i < arg_matrix1.GetLength(0); i++) //перебор по x1
            {
                for (int j = 0; j < arg_matrix2.GetLength(1); j++) //перебор по по y2
                {
                    int buffer=0; //буферная переменная
                    for (int k = 0; k < arg_matrix1.GetLength(1); k++) //перебор по y1
                    {
                        buffer=buffer + arg_matrix1[i,k]*arg_matrix2[k,j];
                    }
                    
                    buffer_matrix[i,j]=buffer;
                }
           }
           return buffer_matrix;
        }   
    }


}