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
            Console.Write($"{err_message}{message} :");
            try
            {
                input=Convert.ToInt32(Console.ReadLine());
                input_data_not_ok=false; //считаем что данные введены корректно
            }
            catch (SystemException) 
            {
                input_data_not_ok=true; //пока введены некорректные данные
                err_message="Неправильный ввод. ";
                Console.WriteLine();
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
    public static int show_sign_count_int (int input)
    {
        int temp=input;
        int sign_count=0;
        //проверка сколько знаков в числе
        while (Math.Abs(temp)>0)
        {
            temp=temp/10;
            sign_count++;
        }
        if (input==0) sign_count=1;
        return sign_count;
    }

    //метод возвращающий количество знаков в числе
    public static int show_sign_count_double (double input)
    {
        int sign_count=0;
        //проверка сколько знаков в числе
        if (input==0.0) sign_count=3;
        else sign_count=Convert.ToString(input).Length; 
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

    //метод зеркального отображения числа
    public static int mirror_int (int input)
    {
        int result=0;
        int sign=1; //знак
        if (input<0) sign=-1; //запоминаем какой знак был у числа
        int temp_input=Math.Abs(input);
        while (temp_input>0)
        {
            result = result * 10 + temp_input % 10; 
            temp_input=temp_input /10;

        }
        return result*sign;
    }

    //метод проверяющий является ли число палиндромом
    public static bool check_palindrom(int arg_input)
    {   
        bool result=false;
        int middle_sign = 0; //цифра, которая находится посередине числа
        if ( (show_sign_count_int(arg_input) % 2)==0 ) //если число знаков чётное, это не может быть палиндром
        {
            result=false;
        }
        else
        {
            //4123214
            middle_sign= ((show_sign_count_int(arg_input) / 2) + 1); //цифра, которая находится посередине числа
            for (int i=1; i<  (middle_sign - 1); i++)
            {
                if (show_sign_by_number(arg_input, i) == show_sign_by_number(arg_input, show_sign_count_int(arg_input) - i +1))
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
   
    //поиск максимального значения в матрице по x или y
    public static int find_max_matrix(int[,] arg_matrix, int arg_dimension)
    {   
        int max=0;
        if (arg_dimension==0) //0 - поиск по x
        {
            max = arg_matrix[0,0];
            for (int i = 0; i < arg_matrix.GetLength(0); i++)
            {
                if (arg_matrix[i,0]>max) max=arg_matrix[i,0]; continue;
            }
        }
        if (arg_dimension!=0) //1 - поиск по y
        {
            max = arg_matrix[0,1];
            for (int i = 0; i < arg_matrix.GetLength(0); i++)
            {
                if (arg_matrix[i,1]>max) max=arg_matrix[i,1]; continue;
            }
        }
        return max;
    }

//поиск максимального значения в матрице по x или y
    public static double find_max_matrix_double(double[,] arg_matrix)
    {   
        double max = arg_matrix[0,0];
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

    //метод поиска минимального значения в массиве
    public static double find_min_matrix_double(double[,] arg_matrix)
    {
        double min = arg_matrix[0,0];
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

    //метод поиска минимального значения в массиве
    public static int find_min_matrix(int[,] arg_matrix, int arg_dimension)
    {
        int min=0;
        if (arg_dimension==0) //0 - поиск по x
        {
            min = arg_matrix[0,0];
            for (int i = 0; i < arg_matrix.GetLength(0); i++)
            {
                if (arg_matrix[i,0]<min) min=arg_matrix[i,0]; continue;
            }
        }
        if (arg_dimension!=0) //1 - поиск по y
        {
            min = arg_matrix[0,1];
            for (int i = 0; i < arg_matrix.GetLength(0); i++)
            {
                if (arg_matrix[i,1]<min) min=arg_matrix[i,1]; continue;
            }
        }
        return min;
    }

    //метод рисования матрицы
    public static void display_matrix(int[,] arg_matrix)
    {
        int min=find_min_matrix(arg_matrix); //минимальное значение в матрице
        int max=find_max_matrix(arg_matrix); //максимальное значение в матрице
        int max_element_lenght=0;            //максимальная значение
        if (Math.Abs(min)>=Math.Abs(max))    //максимальная значение символов
        {
            max_element_lenght=show_sign_count_int(min) + 1; //максимальная значение символов
        }
        else
        {
            max_element_lenght=show_sign_count_int(max); //максимальная значение символов
        }
        //построчное заполнение матрицы
        for (int i = 0; i < arg_matrix.GetLength(0); i++) //x
        {
            Console.Write("||"); 
            for (int j = 0; j < arg_matrix.GetLength(1); j++) //y
            {
            //красивое отображение матрицы
            int sign_count=0;
            if (arg_matrix[i,j]<0) 
            {
                sign_count=show_sign_count_int(Math.Abs(arg_matrix[i,j])) + 1;
            }
            else
            {
                sign_count=show_sign_count_int(Math.Abs(arg_matrix[i,j]));
            }
            string space=string.Concat(Enumerable.Repeat(" " , max_element_lenght-sign_count + 1));
            Console.Write($"{arg_matrix[i,j]}{space}|"); //вывод результата
            }
        Console.Write("|");    
        Console.WriteLine();
        }
    }
    
    //метод рисования матрицы
    public static void display_matrix_double(double[,] arg_matrix, int digits)
    {
        double min=find_min_matrix_double(arg_matrix); //минимальное значение в матрице
        double max=find_max_matrix_double(arg_matrix); //максимальное значение в матрице
        int max_element_lenght=0;            //максимальная значение
        if (show_sign_count_double(min)>=show_sign_count_double(max))    //максимальная значение символов
        {
            max_element_lenght=show_sign_count_double(Math.Round(min,digits)); //максимальная значение символов
        }
        else
        {
            max_element_lenght=show_sign_count_double(Math.Round(max,digits)); //максимальная значение символов
        }
        //построчное заполнение матрицы
        for (int i = 0; i < arg_matrix.GetLength(0); i++) //x
        {
            Console.Write("||"); 
            for (int j = 0; j < arg_matrix.GetLength(1); j++) //y
            {
            //красивое отображение матрицы
            int sign_count=0;
            double temp_arg_matrix=Math.Round(arg_matrix[i,j], digits);
            sign_count=show_sign_count_double(temp_arg_matrix);
            string space=string.Concat(Enumerable.Repeat(" " , max_element_lenght-sign_count + 1));
            Console.Write($"{temp_arg_matrix}{space}|"); //вывод результата
            }
        Console.Write("|");    
        Console.WriteLine();
        }
    }
    

    //метод рисования массива
    public static void display_array (int[] input)
    {
        Console.Write("{");
        for (int i = 0; i < (input.GetLength(0)); i++)
        {
            Console.Write($" {input[i]}"); //вывод результата  
            if (i!=0 && ((i % 10) == 0) ) 
            {
                Console.Write(",");
                Console.WriteLine();
            }
            else
            {
                Console.Write(",");
            }
        }
        Console.Write(" }"); Console.WriteLine();
    }

    //метод заполнения матрицы
    public static int[,] init_matrix(int x, int y)
    {
        int temp_x=x;
        int temp_y=y;
        if (temp_x<0) temp_x=-x;
        if (temp_y<0) temp_y=-y;
        int[,] matrix=new int[temp_x,temp_y]; //создание матрицы
        //построчное заполнение матрицы
        for (int i = 0; i < matrix.GetLength(0); i++) //x
        {
            for (int j = 0; j < matrix.GetLength(1); j++) //y
            {
                matrix[i,j]=randomizer(0, 10);
            }
        }
        return matrix;
    }

    public static int[,] init_matrix(int x, int y, int start, int end)
    {
        int temp_x=x;
        int temp_y=y;
        if (temp_x<0) temp_x=-x;
        if (temp_y<0) temp_y=-y;
        int temp_start=start;
        int temp_end=end;
        int[,] matrix=new int[temp_x,temp_y]; //создание матрицы
        if (start>=(end+1))
        { 
            temp_end=start;
            temp_start=end;
        } 
        //построчное заполнение матрицы
        for (int i = 0; i < matrix.GetLength(0); i++) //x
        {
            for (int j = 0; j < matrix.GetLength(1); j++) //y
            {
                matrix[i,j]=randomizer(temp_start, temp_end+1);
            }
        }
        return matrix;
    }


    //метод заполнения матрицы
    public static double[,] init_matrix_double(int x, int y, int start, int end)
    {
        int temp_x=x;
        int temp_y=y;
        if (temp_x<0) temp_x=-x;
        if (temp_y<0) temp_y=-y;
        int temp_start=start;
        int temp_end=end;
        double[,] matrix=new double[temp_x,temp_y]; //создание матрицы
        System.Random rand=new System.Random();
        if (start>=(end+1))
        { 
            temp_end=start;
            temp_start=end;
        }  
        //построчное заполнение матрицы
        for (int i = 0; i < matrix.GetLength(0); i++) //x
        {
            for (int j = 0; j < matrix.GetLength(1); j++) //y
            {
                matrix[i,j]=rand.NextDouble()*rand.Next(temp_start, temp_end+1);
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

    //метод возвращающий координаты в трёхмерном пространстве из строки
    public static void get_3d_coordinates(string arg_input, ref int arg_x, ref int arg_y, ref int arg_z, ref int arg_retval)
    {
        string temp_input=arg_input.Replace(" ,",",");
        temp_input=temp_input.Replace(",,",",");
        temp_input=temp_input.Replace(", ",",");
        temp_input=temp_input.Replace(" .",".");
        temp_input=temp_input.Replace("..",".");
        temp_input=temp_input.Replace(". ",".");
        temp_input=temp_input.Replace(" ;",";");
        temp_input=temp_input.Replace(";;",";");
        temp_input=temp_input.Replace("; ",";");
        temp_input=temp_input.Replace("  "," ");
        temp_input=temp_input.Replace(" _","_");
        temp_input=temp_input.Replace("__","_");
        temp_input=temp_input.Replace("_ ","_");
        List<char> list_numbers = new List<char> {'0','1','2','3','4','5','6','7','8','9'};
        List<char> list_start   = new List<char> {'[','(','{'};
        List<char> list_end     = new List<char> {']',')','}'};
        List<char> list_space   = new List<char> {'.',',',';',' ', '_'};
        List<char> list_ignore  = new List<char> {'-', '='};
        char[] temp_user_input=temp_input.ToCharArray();
        bool look_for_x=false;
        bool look_for_y=false;
        bool look_for_z=false;
        int sign=1;
        int power=0;
        int number=0;
        for (int i=0; i < temp_user_input.Length; i++)
        {
            //============================================================//
            //==================   расчёт значений координат =============//
            //============================================================//
            //Значение координаты 
            if ( (look_for_x || look_for_y || look_for_z) && (list_numbers.Contains(temp_user_input[i])) )
            {
                number= number + Convert.ToInt32(temp_input[i].ToString()) * Convert.ToInt32(Math.Pow(10, power));
                power++;
            }

            //определение знака координаты
            if ( (temp_user_input[i]=='-') )
            {
                sign=-1;
            }

            //============================================================//
            //==================    Поиск координаты x ===================//
            //============================================================//
            //начало поиска x координаты
            if (list_start.Contains(temp_user_input[i]))                                                   //если символ начала координат  
            {
                look_for_x=true;
                power=0;
                number=0;
                continue;
            }
            if ((list_numbers.Contains(temp_user_input[i]) || temp_user_input[i]=='-') && !(look_for_x || look_for_y || look_for_z)) //если кто-то написал без скобок
            {
                look_for_x=true;
                power=0;
                number=0;
                if (list_numbers.Contains(temp_user_input[i]))
                {
                    number= number + Convert.ToInt32(temp_input[i].ToString()) * Convert.ToInt32(Math.Pow(10, power));
                    power++;
                }
            }

            //============================================================//
            //================== поиск координаты y ======================//
            //============================================================//
            //начало поиска y координаты 
            if  ( (list_space.Contains(temp_user_input[i])) && (look_for_x) ) //знаки разделения
            {
                look_for_x=false;
                arg_x=sign * mirror_int(number);
                look_for_y=true;
                sign=1;
                power=0;
                number=0;
                continue;
            }
            //============================================================//
            //================== поиск координаты z ======================//
            //============================================================//
            //начало поиска z координаты 
            if  ( (list_space.Contains(temp_user_input[i])) && (look_for_y) ) //знаки разделения
            {
                look_for_y=false;
                arg_y=sign * mirror_int(number);
                look_for_z=true;
                sign=1;
                power=0;
                number=0;
                continue;
            }

            //окончание поиска координат 
            if (( (list_end.Contains(temp_user_input[i])) && (look_for_z) ) || //знаки окончания поиска координат
                ( i==temp_user_input.Length-1) )                               //строка закончилась
            {
                look_for_z=false;
                arg_z=sign * mirror_int(number);
                sign=1;
                power=0;
                number=0;
                arg_retval=1; //координата успешно сформирована
                break;
            }


            //некорректный ввод данных
            if ( (list_end.Contains(temp_user_input[i])) && (look_for_x || look_for_y) )
            {
                Console.WriteLine($" {arg_input} : некорректный ввод, ранний символ окончания");
                arg_x=0;
                arg_y=0;
                arg_z=0;
                arg_retval=-1; //неверный ввод данных, код ошибки для отладки
                break;
            }
            //некорректный ввод данных
            if ( (list_start.Contains(temp_user_input[i])) && (look_for_x || look_for_y || look_for_z) )
            {
                Console.WriteLine($" {arg_input} : некорректный ввод, стока содержит два символа начала");
                arg_x=0;
                arg_y=0;
                arg_z=0;
                arg_retval=-2; //неверный ввод данных, код ошибки для отладки
                break;
            }
            //некорректный ввод данных
            if ( (list_numbers.Contains(temp_user_input[i])) !& //если символ не цифра
                (list_space.Contains(temp_user_input[i])) !&   //если символ не разделитель
                (list_start.Contains(temp_user_input[i])) !&   //если символ не символ начала ввода координат
                (list_end.Contains(temp_user_input[i])) !&     //если символ не символ конца ввода координат   
                (list_ignore.Contains(temp_user_input[i])) )   //если символ не спец символ знака или пробел
            {
                Console.WriteLine($" {arg_input} : некорректный ввод, строка содержит символы в координатах");
                arg_x=0;
                arg_y=0;
                arg_z=0;
                arg_retval=-3; //неверный ввод данных, код ошибки для отладки
                break;
            }
        }
    }

    //метод возвращающий расстояние в трёхмерном пространстве для двух точек
    public static double get_3d_distance(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        return Math.Sqrt(Math.Pow((x2-x1),2) + Math.Pow((y2-y1),2) +Math.Pow((z2-z1),2));
    }


    //метод возвращающий координаты в двумерном пространстве из строки
    public static void get_2d_coordinates(string arg_input, ref int arg_x, ref int arg_y, ref int arg_retval)
    {
        string temp_input=arg_input.Replace(" ,",",");
        temp_input=temp_input.Replace(",,",",");
        temp_input=temp_input.Replace(", ",",");
        temp_input=temp_input.Replace(" .",".");
        temp_input=temp_input.Replace("..",".");
        temp_input=temp_input.Replace(". ",".");
        temp_input=temp_input.Replace(" ;",";");
        temp_input=temp_input.Replace(";;",";");
        temp_input=temp_input.Replace("; ",";");
        temp_input=temp_input.Replace("  "," ");
        temp_input=temp_input.Replace(" _","_");
        temp_input=temp_input.Replace("__","_");
        temp_input=temp_input.Replace("_ ","_");
        List<char> list_numbers = new List<char> {'0','1','2','3','4','5','6','7','8','9'};
        List<char> list_start   = new List<char> {'[','(','{'};
        List<char> list_end     = new List<char> {']',')','}'};
        List<char> list_space   = new List<char> {'.',',',';',' ', '_'};
        List<char> list_ignore  = new List<char> {'-', '='};
        char[] temp_user_input=temp_input.ToCharArray();
        bool look_for_x=false;
        bool look_for_y=false;
        int sign=1;
        int power=0;
        int number=0;
        for (int i=0; i < temp_user_input.Length; i++)
        {
            //============================================================//
            //==================   расчёт значений координат =============//
            //============================================================//
            //Значение координаты 
            if ( (look_for_x || look_for_y) && (list_numbers.Contains(temp_user_input[i])) )
            {
                number= number + Convert.ToInt32(temp_input[i].ToString()) * Convert.ToInt32(Math.Pow(10, power));
                power++;
            }

            //определение знака координаты
            if ( (temp_user_input[i]=='-') )
            {
                sign=-1;
            }

            //============================================================//
            //==================    Поиск координаты x ===================//
            //============================================================//
            //начало поиска x координаты
            if (list_start.Contains(temp_user_input[i])) //если символ начала координат  
            {
                look_for_x=true;
                power=0;
                number=0;
                continue;
            }
            if ((list_numbers.Contains(temp_user_input[i]) || temp_user_input[i]=='-') && !(look_for_x || look_for_y)) //если кто-то написал без скобок
            {
                look_for_x=true;
                power=0;
                number=0;
                if (list_numbers.Contains(temp_user_input[i]))
                {
                    number= number + Convert.ToInt32(temp_input[i].ToString()) * Convert.ToInt32(Math.Pow(10, power));
                    power++;
                }
            }

            //============================================================//
            //================== поиск координаты y ======================//
            //============================================================//
            //начало поиска y координаты 
            if  ( (list_space.Contains(temp_user_input[i])) && (look_for_x) )//знаки разделения
            {
                look_for_x=false;
                arg_x=sign * mirror_int(number);
                look_for_y=true;
                sign=1;
                power=0;
                number=0;
                continue;
            }
            //окончание поиска координат 
            if (( (list_end.Contains(temp_user_input[i])) && (look_for_y) ) || //знаки окончания поиска координат
                ( i==temp_user_input.Length-1) )                               //строка закончилась
            {
                look_for_y=false;
                arg_y=sign * mirror_int(number);
                sign=1;
                power=0;
                number=0;
                arg_retval=1; //координата успешно сформирована
                break;
            }

            //некорректный ввод данных
            if ( (list_end.Contains(temp_user_input[i])) && (look_for_x) )
            {
                Console.WriteLine($" {arg_input} : некорректный ввод, ранний символ окончания");
                arg_x=0;
                arg_y=0;
                arg_retval=-1; //неверный ввод данных, код ошибки для отладки
                break;
            }
            //некорректный ввод данных
            if ( (list_start.Contains(temp_user_input[i])) && (look_for_x || look_for_y) )
            {
                Console.WriteLine($" {arg_input} : некорректный ввод, стока содержит два символа начала");
                arg_x=0;
                arg_y=0;
                arg_retval=-2; //неверный ввод данных, код ошибки для отладки
                break;
            }
            //некорректный ввод данных
            if ( (list_numbers.Contains(temp_user_input[i])) !& //если символ не цифра
                (list_space.Contains(temp_user_input[i])) !&   //если символ не разделитель
                (list_start.Contains(temp_user_input[i])) !&   //если символ не символ начала ввода координат
                (list_end.Contains(temp_user_input[i])) !&     //если символ не символ конца ввода координат   
                (list_ignore.Contains(temp_user_input[i])) )   //если символ не спец символ знака или пробел
            {
                Console.WriteLine($" {arg_input} : некорректный ввод, строка содержит символы в координатах");
                arg_x=0;
                arg_y=0;
                arg_retval=-3; //неверный ввод данных, код ошибки для отладки
                break;
            }
        }
    }
    
    //перегрузка метода возвращающего координаты в двумерном пространстве из строки
    public static int[,] get_2d_coordinates(string arg_input, ref int arg_retval)
    {
        int point_count=0; //количество найденных точек
        int [,] temp_coordinates=new int[point_count+1,2]; //результирующий массив
        int [,] buffer_coordinates; //буферный массив 
        string temp_input=arg_input.Replace(" ,",",");
        temp_input=temp_input.Replace(",,",",");
        temp_input=temp_input.Replace(", ",",");
        temp_input=temp_input.Replace(" .",".");
        temp_input=temp_input.Replace("..",".");
        temp_input=temp_input.Replace(". ",".");
        temp_input=temp_input.Replace(" ;",";");
        temp_input=temp_input.Replace(";;",";");
        temp_input=temp_input.Replace("; ",";");
        temp_input=temp_input.Replace("  "," ");
        temp_input=temp_input.Replace(" _","_");
        temp_input=temp_input.Replace("__","_");
        temp_input=temp_input.Replace("_ ","_");
        List<char> list_numbers = new List<char> {'0','1','2','3','4','5','6','7','8','9'};
        List<char> list_start   = new List<char> {'[','(','{'};
        List<char> list_end     = new List<char> {']',')','}'};
        List<char> list_space   = new List<char> {'.',',',';',' ', '_'};
        List<char> list_ignore  = new List<char> {'-', '='};
        char[] temp_user_input=temp_input.ToCharArray();
        bool look_for_x=false;
        bool look_for_y=false;
        int sign=1;
        int power=0;
        int number=0;
        for (int i=0; i < temp_user_input.Length; i++)
        {
            //============================================================//
            //==================   расчёт значений координат =============//
            //============================================================//
            //Значение координаты 
            if ( (look_for_x || look_for_y) && (list_numbers.Contains(temp_user_input[i])) )
            {
                number= number + Convert.ToInt32(temp_input[i].ToString()) * Convert.ToInt32(Math.Pow(10, power));
                power++;
            }

            //определение знака координаты
            if ( (temp_user_input[i]=='-') )
            {
                sign=-1;
            }

            //============================================================//
            //==================    Поиск координаты x ===================//
            //============================================================//
            //начало поиска x координаты
            if (list_start.Contains(temp_user_input[i])) //если символ начала координат  
            {
                look_for_x=true;
                power=0;
                number=0;
                continue;
            }
            if ((list_numbers.Contains(temp_user_input[i]) || temp_user_input[i]=='-') && !(look_for_x || look_for_y)) //если кто-то написал без скобок
            {
                look_for_x=true;
                power=0;
                number=0;
                if (list_numbers.Contains(temp_user_input[i]))
                {
                    number= number + Convert.ToInt32(temp_input[i].ToString()) * Convert.ToInt32(Math.Pow(10, power));
                    power++;
                }
            }

            //============================================================//
            //================== поиск координаты y ======================//
            //============================================================//
            //начало поиска y координаты 
            if  ( (list_space.Contains(temp_user_input[i])) && (look_for_x) )//знаки разделения
            {
                look_for_x=false;
                temp_coordinates[point_count,0]=sign * mirror_int(number);
                look_for_y=true;
                sign=1;
                power=0;
                number=0;
                continue;
            }
            //окончание поиска координат 
            if (( (list_end.Contains(temp_user_input[i]) || list_space.Contains(temp_user_input[i]) ) && (look_for_y) ) || //знаки окончания поиска координат
                ( i==temp_user_input.Length-1) )                               //строка закончилась
            {
                look_for_y=false;
                temp_coordinates[point_count,1]=sign * mirror_int(number);
                sign=1;
                power=0;
                number=0;
                arg_retval=point_count+1; //координата успешно сформирована
                if (i==temp_user_input.Length-1)
                {    
                    break;
                }
                else
                {
                    buffer_coordinates = new int[point_count+1,2];                   //переопределение массива
                    Array.Copy(temp_coordinates, buffer_coordinates, temp_coordinates.Length);
                    temp_coordinates = new int[point_count+2,2];                     //переопределение массива
                    Array.Copy(buffer_coordinates, temp_coordinates, buffer_coordinates.Length); //копирование массива
                    point_count++;
                    continue; 
                }
            }

            //некорректный ввод данных
            if ( (list_end.Contains(temp_user_input[i])) && (look_for_x) )
            {
                Console.WriteLine($" {arg_input} : некорректный ввод, ранний символ окончания");
                //temp_coordinates[0,0]=0;
                //temp_coordinates[0,1]=0;
                arg_retval=-1; //неверный ввод данных, код ошибки для отладки
                break;
            }
            //некорректный ввод данных
            if ( (list_start.Contains(temp_user_input[i])) && (look_for_x || look_for_y) )
            {
                Console.WriteLine($" {arg_input} : некорректный ввод, стока содержит два символа начала");
                //temp_coordinates[0,0]=0;
                //temp_coordinates[0,1]=0;
                arg_retval=-2; //неверный ввод данных, код ошибки для отладки
                break;
            }
            //некорректный ввод данных
            if ( (list_numbers.Contains(temp_user_input[i])) !& //если символ не цифра
                (list_space.Contains(temp_user_input[i])) !&   //если символ не разделитель
                (list_start.Contains(temp_user_input[i])) !&   //если символ не символ начала ввода координат
                (list_end.Contains(temp_user_input[i])) !&     //если символ не символ конца ввода координат   
                (list_ignore.Contains(temp_user_input[i])) )   //если символ не спец символ знака или пробел
            {
                Console.WriteLine($" {arg_input} : некорректный ввод, строка содержит символы в координатах");
                //temp_coordinates[0,0]=0;
                //temp_coordinates[0,1]=0;
                arg_retval=-3; //неверный ввод данных, код ошибки для отладки
                break;
            }
        }
    return temp_coordinates;
    }
    
    //метод маштабирующий фигуру в двумерном пространстве
    public static int[,] resize_2d_coordinates(int[,] arg_matrix, double k)
    {
        int[,] buffer_matrix=arg_matrix;
        if (k<=0 || (arg_matrix.GetLength(0)==1)) return arg_matrix;
        else
        {
            for (int i = 0; i < arg_matrix.GetLength(0); i++)
            {
                for (int j = 0; j < arg_matrix.GetLength(1); j++)
                {
                    buffer_matrix[i,j]=Convert.ToInt32(k * (Convert.ToDouble(arg_matrix[i,j])));
                }
            }
            return buffer_matrix;
        }
    }

    //автозаполнение массива указанной глубины
    public static int[] init_int_array_auto(int number, int start, int end)
    {
        int[] temp_array=new int[number]; //создание массива заданной глубины
        for (int i = 0; (i < temp_array.Count()); i++)
        {   
            temp_array[i]=randomizer(start, end);
        }
        return temp_array;
    }
    //заполнение массива заданной глубины руками
    public static int[] init_int_array_manual(int number)
    {
        int[] temp_array=new int[number]; //создание массива заданной глубины
        for (int i = 0; (i < temp_array.Count()); i++)
        {   
            temp_array[i]=check_int_input($"Элемент массива номер [{i}] равен: ");
        }
        return temp_array;
    }
    //метод поиска минимального значения в массиве
    public static int find_min_array(int[] input_array)
    {
        int min = input_array[0];
        for (int i = 0; (i < input_array.Count()); i++)
        {
            if (input_array[i]<min) min=input_array[i]; continue;
        }
        return min;
    }
    //метод поиска максимального значения в массиве
    public static int find_max_array(int[] input_array)
    {
        int max = input_array[0];
        for (int i = 0; (i < input_array.Count()); i++)
        {
            if (input_array[i]>max) max=input_array[i]; continue;
        }
        return max;
    }

    //метод копирующий содержимое из одного массива в другой
    public static int copy_array(int[] arg_source, ref int[] arg_target, int arg_count)
    {
        if (arg_count > arg_target.GetLength(0))
        {
            Console.WriteLine("Копирование массивов невозможно, длина принимающего массива недостаточна");
            return -1;
        }
        else
        {
            for (int i = 0; i < arg_count; i++)
            {
                arg_target[i]=arg_source[i];
            }
            return 0;
        }
    } 
}