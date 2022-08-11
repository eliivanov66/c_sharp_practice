/*
Задача о сложении матриц
*/
//using Library; //библиотека
    //автозаполнение массива указанной глубины
    int[] init_int_array_auto(int number, int start, int end)
    {
        int[] temp_array=new int[number]; //создание массива заданной глубины
        for (int i = 0; (i < temp_array.Count()); i++)
        {   
            temp_array[i]=randomizer(start, end);
        }
        return temp_array;
    }

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

    void display_array (int[] input)
    {
        int max_size=show_sign_count(find_max_array(input)); //поиск длины максимального из чисел
        for (int i = 0; i < (input.Count()); i++)
        {
            string space=string.Concat(Enumerable.Repeat(" " , max_size-show_sign_count(input[i]) + 1));
            Console.Write($"|{input[i]}{space}"); 
            if (((i+1)%10)==0) Console.WriteLine(); //переход на новую строку
        }
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

    int find_max_array(int[] input_array)
    {
        int max = input_array[0];
        for (int i = 0; (i < input_array.Count()); i++)
        {
            if (input_array[i]>max) max=input_array[i]; continue;
        }
        return max;
    }

    //метод поиска минимального значения в массиве
    int find_min_array(int[] input_array)
    {
        int min = input_array[0];
        for (int i = 0; (i < input_array.Count()); i++)
        {
            if (input_array[i]<min) min=input_array[i]; continue;
        }
        return min;
    }
 
    //метод суммирования одномерных матриц
    int[] matrix_sum(int[] arg_array1, int[] arg_array2)
    {
        int[] result=new int[arg_array1.Count()]; //буфферного массива массива
        if (arg_array1.Count()!=arg_array2.Count())
        {
            Console.WriteLine("Размерность матриц не совпадает");
        }
        else
        {

            for (int i = 0; i < (arg_array1.Count()); i++)
            {
                result[i]=arg_array1[i]+arg_array2[i];
            }
        }
        return result;
    }

    //метод умножения одномерных матриц
    int matrix_mult(int[] arg_array1, int[] arg_array2)
    {
        int result=0; //результат умножения матриц
        if (arg_array1.Count()!=arg_array2.Count())
        {
            Console.WriteLine("Размерность матриц не совпадает");
        }
        else
        {

            for (int i = 0; i < (arg_array1.Count()); i++)
            {
                result=result + arg_array1[i]*arg_array2[i];
            }
        }
        return result;
    }

    //метод рисования матрицы
    void display_matrix(int[,] arg_matrix)
    {
        int[] temp_array = new int[6];
        //построчное заполнение матрицы
        for (int i = 0; i < arg_matrix.GetLength(0); i++) //x
        {
            for (int j = 0; j < arg_matrix.GetLength(1); j++) //y
            {
            Console.Write($" {arg_matrix[i,j]}"); //вывод результата
            }
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