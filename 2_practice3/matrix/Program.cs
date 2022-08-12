/*
Задача о сложении матриц
*/
//using Library; //библиотека

    int randomizer(int start, int end)
    {
        System.Random temp_randomizer=new System.Random(); //новый объект генератор псевдослучайных чисел
        return temp_randomizer.Next(start, end);
    }

    //метод проверки вводимого значения
    int check_int_input(string message)
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

    //метод возвращающий количество знаков в числе
    int show_sign_count (int input)
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

    //поиск максимального значения в матрице
    int find_max_matrix(int[,] arg_matrix)
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
    int find_min_matrix(int[,] arg_matrix)
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
    void display_matrix(int[,] arg_matrix)
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
    int[,] init_matrix(int x, int y)
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
    int[,] sum_matrix(int[,] arg_matrix1, int[,] arg_matrix2)
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
    int[,] mult_matrix(int[,] arg_matrix1, int[,] arg_matrix2)
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



/*======================================================================*/
/*================ Сложение двух матриц ================================*/
/*======================================================================*/
Console.WriteLine("===========================================================");
Console.WriteLine("=============== Сложение двух матриц ======================");
Console.WriteLine("===========================================================");
int matrix_x1=check_int_input("Введите ширину первой матрицы для сложения ");
int matrix_y1=check_int_input("Введите высоту первой матрицы для сложения ");
int[,] matrix_1=init_matrix(matrix_x1, matrix_y1); //создание первой матрицы
Console.WriteLine("Первая матрица :");
display_matrix(matrix_1); //отображение первой матрицы

int matrix_x2=check_int_input("Введите ширину второй матрицы для сложения ");
int matrix_y2=check_int_input("Введите высоту второй матрицы для сложения ");
Console.WriteLine("Вторая матрица :");
int[,] matrix_2=init_matrix(matrix_x2, matrix_y2); //создание второй матрицы
display_matrix(matrix_2); //отображение второй матрицы
Console.WriteLine("Результат сложения матриц :");
display_matrix(sum_matrix(matrix_1,matrix_2)); //результат отображения матриц
/*======================================================================*/
/*================ умножение двух матриц ================================*/
/*======================================================================*/
Console.WriteLine("===========================================================");
Console.WriteLine("=============== умножение двух матриц =====================");
Console.WriteLine("===========================================================");
int matrix_x3=check_int_input("Введите ширину первой матрицы для умножения ");
int matrix_y3=check_int_input("Введите высоту первой матрицы для умножения ");
int[,] matrix_3=init_matrix(matrix_x3, matrix_y3); //создание первой матрицы
Console.WriteLine("Первая матрица :");
display_matrix(matrix_3); //отображение первой матрицы
int matrix_x4=check_int_input("Введите ширину второй матрицы для умножения ");
int matrix_y4=check_int_input("Введите высоту второй матрицы для умножения ");
Console.WriteLine("Вторая матрица :");
int[,] matrix_4=init_matrix(matrix_x4, matrix_y4); //создание второй матрицы
display_matrix(matrix_4); //отображение второй матрицы
Console.WriteLine("Результат умножения матриц :");
display_matrix(mult_matrix(matrix_3,matrix_4)); //результат отображения матриц

/* одномерный массив
Console.Clear();
int array1_lenght=check_int_input("Введите глубину первого массива для сложения ");
int array2_lenght=check_int_input("Введите глубину второго массива для сложения ");
if (array1_lenght!=array2_lenght) //если размерность массива не совпадают
{
    Console.WriteLine("Сложение не возможно, введены разные размерности массивов");
}
else
{
    int[] array1=init_int_array_auto(array1_lenght, 0, 10); //генерирование первого массива, случайными числами
    int[] array2=init_int_array_auto(array2_lenght, 0, 10); //генерирование второго массива, случайными числами
    Console.WriteLine("Первая матрица: ");   //новая строка
    display_array(array1); //первый массив показать
    Console.WriteLine("Вторая матрица:");   //новая строка
    Console.WriteLine();   //новая строка
    display_array(array2); //второй массив показать
    Console.WriteLine();   //новая строка
    int[] result_sum=new int[array1_lenght]; //буфферного массива массива
    result_sum=matrix_sum(array1, array2);
    Console.WriteLine("Результирующая матрица сложения: ");   //новая строка
    display_array(result_sum); //показать рельтирующий массив
    int result_multi=0;
    result_multi=matrix_mult(array1,array2);
    Console.WriteLine($"Результат умножения матриц: {result_multi} ");   //новая строка
    Console.WriteLine();   //новая строка
}
*/