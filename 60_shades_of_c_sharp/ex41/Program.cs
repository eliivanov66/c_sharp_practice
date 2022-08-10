/*
41. Выяснить являются ли три числа сторонами треугольника 
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
//метод проверки являются ли числа сторонами треугольника
bool check_triangle(double a, double b, double c)
{
    //через следствие теоремы косинусов
    double acos_alfa= System.Math.Acos((System.Math.Pow(b,2) + System.Math.Pow(c,2) - System.Math.Pow(a,2))/(2*b * c));
    double acos_betta=System.Math.Acos((System.Math.Pow(a,2) + System.Math.Pow(c,2) - System.Math.Pow(b,2))/(2*a * c));
    double acos_gamma=System.Math.Acos((System.Math.Pow(a,2) + System.Math.Pow(b,2) - System.Math.Pow(c,2))/(2*a * b));
    //проверка будет условию что сумма углов равна Пи
    return ((acos_alfa + acos_betta + acos_gamma) == System.Math.PI);
    
}
ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите Q");
choise=Console.ReadKey();
while (choise.Key!=ConsoleKey.Q)
{
    Console.Clear();
    //ввод данных
    int edge_1=0;
    int edge_2=0;
    int edge_3=0;
    while (edge_1<=0)
    {
        edge_1=check_int_input("Введите значение длины первой стороны треугольника");
    }
    Console.WriteLine($"Длина первой стороны равна {edge_1}");
    while (edge_2<=0)
    {
        edge_2=check_int_input("Введите значение длины второй стороны треугольника");
    }
    Console.WriteLine($"Длина второй стороны равна {edge_2}");
    while (edge_3<=0)
    {
        edge_3=check_int_input("Введите значение длины третьей стороны стороны треугольника");
    }
    Console.WriteLine($"Длина третьей стороны равна {edge_3}");
    //анализ являются ли числа сторонами треугольника
    if (check_triangle(System.Convert.ToDouble(edge_1), System.Convert.ToDouble(edge_2), System.Convert.ToDouble(edge_3)))
    {
        Console.WriteLine($"Введённые числа {edge_1}, {edge_2}, {edge_3} являются сторонами треугольника"); 
    }
    else
    {
        Console.WriteLine($"Введённые числа {edge_1}, {edge_2}, {edge_3} не являются сторонами треугольника"); 
    }
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите Q");
    choise=Console.ReadKey();
}