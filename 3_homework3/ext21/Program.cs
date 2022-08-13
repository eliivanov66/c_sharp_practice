/*
Задача 21
Напишите метод, который принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
A (3,6,8); B (2,1,-7), -> 15.84
A (7,-5, 0); B (1,-1,9) -> 11.53
*/
//библиотека с методами
using static Librarium;






int x1=0; int y1=0; int z1=0; int retval1=0;
int x2=0; int y2=0; int z2=0; int retval2=0; 

ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите Q");
choise=Console.ReadKey();
while (choise.Key!=ConsoleKey.Q)
{
    while ((retval1!=1) || (choise.Key==ConsoleKey.R))//пока оператор не введёт данные корректно
    {
        Console.Clear();
        Console.WriteLine("Введите координаты первой точки в виде x,y,z : ");
        string input1=$" {Console.ReadLine()}";
        get_3d_coordinates(input1,ref x1,ref y1,ref z1,ref retval1);
        Console.WriteLine($"Получены координаты x: {x1}, y: {y1}, z: {z1}");
        Console.WriteLine("Скорректировать ввод R,  Продолжить N, для выхода из программы нажмите Q");
        choise=Console.ReadKey();
    }
    retval1=0;
    if ((choise.Key==ConsoleKey.N) || (choise.Key==ConsoleKey.R)) choise=new ConsoleKeyInfo(); //отмена ввода
    while ((retval2!=1) || (choise.Key==ConsoleKey.R)) //пока оператор не введёт данные корректно
    {
        Console.Clear();
        Console.WriteLine("Введите координаты второй точки точки в виде x,y,z : ");
        string input2=$" {Console.ReadLine()}";
        get_3d_coordinates(input2,ref x2,ref y2,ref z2,ref retval2);
        Console.WriteLine($"Получены координаты x: {x2}, y: {y2}, z: {z2}");
        Console.WriteLine("Скорректировать ввод R,  Продолжить N, для выхода из программы нажмите Q");
        choise=Console.ReadKey();
    }
    retval2=0;
    if ((choise.Key==ConsoleKey.N) || (choise.Key==ConsoleKey.R)) choise=new ConsoleKeyInfo(); //отмена ввода
    if (choise.Key!=ConsoleKey.Q)
    {
        //вывод результатов
        Console.WriteLine($"Расстояние между точкой ({x1},{y1},{z1}) и точкой ({x2},{y2},{z2}) равно: {get_3d_distance(x1,y1,z1,x2,y2,z2)}");
        retval1=0; retval2=0;
        Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите Q");
        choise=Console.ReadKey();
    }
}