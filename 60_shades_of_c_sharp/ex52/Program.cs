/*
52. В двумерном массиве заменить элементы, у которых оба индекса чётные на их квадраты
*/
using static Librarium;

//переменные
int m=0;               //размерность m
int n=0;               //размерность n  

ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
choise=Console.ReadKey();
while (choise.Key!=ConsoleKey.Q)
{
    Console.Clear();
    m=0;
    n=0;
    //генерация массива
    int [,] result; //массив результат
    while (m<=0) m=check_int_input("Введите размерность m ");
    while (n<=0) n=check_int_input("Введите размерность n ");
    result=init_matrix(m, n, -999, 999);
    //случайно сгенерированная матрица
    Console.WriteLine("Была сгенерирована следующая матрица целых чисел: ");
    display_matrix(result);

    for (int i=0; i< result.GetLength(0); i++)
    {
        for (int j=0; j< result.GetLength(1); j++)
        {
            if ((i%2==0) && (i!=0) && (j%2==0) && (j!=0))
            {
                result[i,j]=result[i,j]*result[i,j];
            }
        }
    }
    //случайно сгенерированная матрица
    Console.WriteLine("После замены чётных на квадраты матрица имеет ввид: ");
    display_matrix(result);
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
    choise=Console.ReadKey();

}
