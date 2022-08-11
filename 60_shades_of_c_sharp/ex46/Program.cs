/*
46. Написать программу масштабирования фигуры
Тут для тех кто далеко улетел, чтобы задавались вершины фигуры списком (одной строкой)
например: "(0,0) (2,0) (2,2) (0,2)"
коэффициент масштабирования k задавался отдельно - 2 или 4 или 0.5
В результате показать координаты, которые получатся.
при k = 2 получаем "(0,0) (4,0) (4,4) (0,4)"
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
List<char> list_numbers= new List<char> {'0','1','2','3','4','5','6','7','8','9'};
ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите Q");
choise=Console.ReadKey();
while (choise.Key!=ConsoleKey.Q)
{
    //ввод данных
    Console.Clear();
    //Console.WriteLine(coordinates.Count());
    Console.WriteLine("Введите координаты ");
    string user_input=Console.ReadLine();
    char[] temp_user_input=user_input.ToCharArray();

    bool find_x1=false; bool assemble_x1=false; int x1=0;
    bool find_y1=false; bool assemble_y1=false; int y1=0;
    bool find_x2=false; bool assemble_x2=false; int x2=0;
    bool find_y2=false; bool assemble_y2=false; int y2=0;
    bool find_x3=false; bool assemble_x3=false; int x3=0;
    bool find_y=false3; bool assemble_y3=false; int y3=0;
    int sign=1;

    for (int i=0; i< temp_user_input.Count(); i++)
    {
        if ((temp_user_input[i]=='(') && (!find_x1))
        {
            find_x1=true;
            x1=0;
            sign=1;
        }
        if (find_x1)
        {
            if ((temp_user_input[i]=='-') && (x1==0))
            {
                sign=-1;
            }
            if (list_numbers.Contains(temp_user_input[i]) && (!assemble_x1))
            {
                x1=x1 + Convert.ToInt32(temp_user_input[i]);
            }
        }
    }
    /*
    for (int i = 0; i < temp_user_input.Count(); i++)
    {
        //Console.WriteLine($"[{i}] : {temp_user_input[i]}");
        
        if ((temp_user_input[i]=="(") && (!find_x1))
        {
            find_x1=true;
        }
        if (find_x1)
        {
            string s = "9quali52ty3";
            foreach(char c in s)
            {
            Console.WriteLine((int)c);
            }
        }
    }
    */
    Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите Q");
    choise=Console.ReadKey();
}
