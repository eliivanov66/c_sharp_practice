/*
Задача о сложении/ умножение матриц
*/
using static Librarium; //библиотека

/*======================================================================*/
/*================ Сложение двух матриц ================================*/
/*======================================================================*/
Console.WriteLine("===========================================================");
Console.WriteLine("=============== Сложение двух матриц ======================");
Console.WriteLine("===========================================================");
int matrix_x1=Librarium.check_int_input("Введите ширину первой матрицы для сложения ");
int matrix_y1=Librarium.check_int_input("Введите высоту первой матрицы для сложения ");
int[,] matrix_1=Librarium.init_matrix(matrix_x1, matrix_y1); //создание первой матрицы
Console.WriteLine("Первая матрица :");
Librarium.display_matrix(matrix_1); //отображение первой матрицы

int matrix_x2=Librarium.check_int_input("Введите ширину второй матрицы для сложения ");
int matrix_y2=Librarium.check_int_input("Введите высоту второй матрицы для сложения ");
Console.WriteLine("Вторая матрица :");
int[,] matrix_2=Librarium.init_matrix(matrix_x2, matrix_y2); //создание второй матрицы
Librarium.display_matrix(matrix_2); //отображение второй матрицы
Console.WriteLine("Результат сложения матриц :");
Librarium.display_matrix(Librarium.sum_matrix(matrix_1,matrix_2)); //результат отображения матриц
/*======================================================================*/
/*================ умножение двух матриц ================================*/
/*======================================================================*/
Console.WriteLine("===========================================================");
Console.WriteLine("=============== умножение двух матриц =====================");
Console.WriteLine("===========================================================");
int matrix_x3=Librarium.check_int_input("Введите ширину первой матрицы для умножения ");
int matrix_y3=Librarium.check_int_input("Введите высоту первой матрицы для умножения ");
int[,] matrix_3=Librarium.init_matrix(matrix_x3, matrix_y3); //создание первой матрицы
Console.WriteLine("Первая матрица :");
Librarium.display_matrix(matrix_3); //отображение первой матрицы
int matrix_x4=Librarium.check_int_input("Введите ширину второй матрицы для умножения ");
int matrix_y4=Librarium.check_int_input("Введите высоту второй матрицы для умножения ");
Console.WriteLine("Вторая матрица :");
int[,] matrix_4=Librarium.init_matrix(matrix_x4, matrix_y4); //создание второй матрицы
Librarium.display_matrix(matrix_4); //отображение второй матрицы
Console.WriteLine("Результат умножения матриц :");
Librarium.display_matrix(Librarium.mult_matrix(matrix_3,matrix_4)); //результат отображения матриц

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