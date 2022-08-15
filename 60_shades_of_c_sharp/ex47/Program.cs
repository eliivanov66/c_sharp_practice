/*
47. Написать программу копирования массива
*/
using static Librarium;

//переменные
int answer_1=0;               //ответ 1 от пользователя - метод генерации массива
int answer_2=0;               //ответ 2 от пользователя - глубина массива  

ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
choise=Console.ReadKey();
while (choise.Key!=ConsoleKey.Q)
{
    Console.Clear();
    //массив 1
    answer_1=0;
    answer_2=0;
    int [] source={0}; //массив источник данных для копирования
    int [] target={0}; //массив цель для копирования
    while ((answer_1!=1) && (answer_1!=2)) //запроса как генерировать массив
    {
        //Console.Clear();
        answer_1=check_int_input("Первый массив, 1- ввести вручную, 2-заполнить случайными числами ");
    }
    if ((answer_1==1) || (answer_1==2)) //генерация массива
    {
        while (answer_2<=0)
        {
            answer_2=check_int_input("Введите число элеметов первого массива ");
        }
        if (answer_1==1)
        {
            source=init_int_array_manual(answer_2);
            Console.WriteLine("Первый массив :");
            display_array(source);
        }
        if (answer_1==2)
        {
            source=init_int_array_auto(answer_2, 0, 10);
            Console.WriteLine("Первый массив :");
            display_array(source);
        }
    }

    //массив 2
    answer_1=0;
    answer_2=0;
    while ((answer_1!=1) && (answer_1!=2)) //запроса как генерировать массив
    {
        //Console.Clear();
        answer_1=check_int_input("Второй массив массив, 1- ввести вручную, 2-заполнить случайными числами ");
    }
    if ((answer_1==1) || (answer_1==2)) //генерация массива
    {
        while (answer_2<=0)
        {
            answer_2=check_int_input("Введите число элеметов второго массива ");
        }
        if (answer_1==1)
        {
            target=init_int_array_manual(answer_2);
            Console.WriteLine("Второй массив :");
            display_array(target);
        }
        if (answer_1==2)
        {
            target=init_int_array_auto(answer_2, 0, 10);
            Console.WriteLine("Второй массив :");
            display_array(target);
        }
    }
    //копирование массивов
    if (copy_array(source, ref target, source.GetLength(0))==0) //копирование целиком
    {
        Console.WriteLine("Результат копирования: ");
        display_array(target);
    }
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите q");
    choise=Console.ReadKey();
}
