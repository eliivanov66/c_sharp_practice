/*
45. Показать числа Фибоначчи
*/
//метод проверяющий вводимые значения - INT числа
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
//метод генерирующий числа в ряде Фибоначчи
int generate_Fibonacci(int input)
{   
    //константа Фи из формулы
    double Fi=(1+Math.Sqrt(5.0))/2.0; 
    return Convert.ToInt32((Math.Pow(Fi, Convert.ToDouble(input)) - Math.Pow((-Fi), -(Convert.ToDouble(input))))/(2.0*Fi-1.0));
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

//метод поиска максимального значения в массиве
int find_max_array(int[] input_array)
{
    int max = input_array[0];
    for (int i = 0; (i < input_array.Count()); i++)
    {
        if (input_array[i]>max) max=input_array[i]; continue;
    }
    return max;
}

//метод отображающий массив
void display_array (int[] input)
{
    int max_size=show_sign_count(find_max_array(input)); //поиск длины максимального из чисел
    for (int i = 0; i < (input.Count()); i++)
    {
        string space=string.Concat(Enumerable.Repeat(" " , max_size-show_sign_count(input[i]) + 1));
        Console.Write($"|{input[i]}{space}"); 
        if (((i+1)%12)==0) Console.WriteLine(); //переход на новую строку
    }
}

ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите Q");
choise=Console.ReadKey();
int lenght=-1;
while (choise.Key!=ConsoleKey.Q)
{
    //ввод данных
    Console.Clear();
    while (lenght<1 || lenght>47) //47 - так как значения выходят за диапазон чисел int32
    {
        lenght=check_int_input("Введите длину ряда чисел Фибоначчи ");
    }
    //создание массива результатов
    Console.Clear();
    int[] buffer_array=new int[lenght]; //создание буферного массива 
    for (int i = 0; i < (buffer_array.Count()); i++)
    {
        buffer_array[i]=generate_Fibonacci(i);
    }
    //вывод результов
    Console.WriteLine("Запрошенный ряд Фибоначчи: ");
    display_array(buffer_array);
    Console.WriteLine(); //переход на новую строку
    Array.Clear(buffer_array); //очистка массива
    lenght=0;
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите Q");
    choise=Console.ReadKey();
}
