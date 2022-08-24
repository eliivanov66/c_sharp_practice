
using static My_tetris;
char _0='0';
char _1=Convert.ToChar(9632);
char[,] field      =new char[16,16];
char[,] figure;//=new int[4,4] {{0,0,0,0},{0,0,0,0},{0,1,0,0},{1,1,1,0}};
char[,] line       =new char[1,4] {{_1,_1,_1,_1}};
char[,] square     =new char[2,2] {{_1,_1},{_1,_1}};
char[,] angle      =new char[3,2] {{_1,_0},{_1,_0},{_1,_1}};
char[,] sig_left   =new char[3,2] {{_1,_0},{_1,_1},{_0,_1}};
char[,] sig_right  =new char[3,2] {{_0,_1},{_1,_1},{_1,_0}};
char[,] triangle   =new char[2,3] {{_0,_1,_0},{_1,_1,_1}};

List<char[,]> list_figures = new List<char[,]> {line,square,angle,sig_left,sig_right,triangle};


int start_x=0;
int start_y=field.GetLength(1)/2;
//0000
//0000
//0100
//1110

ConsoleKeyInfo choise; //ввод клавиши
Console.WriteLine("Вверх/вниз поворот фигуры. Для выхода нажмите Q");
figure=list_figures[Random.Shared.Next(0,6)]; //берём любую фигуру из листа
place_figures(ref field, figure, start_x, start_y); //рисование фигуры на поле
print_figure(field);
choise=Console.ReadKey();
while (choise.Key!=ConsoleKey.Q)
{
    Console.Clear();
    Console.WriteLine("Вверх/вниз поворот фигуры. Для выхода нажмите Q");
    //обновление анимации
    //if (DateTime.Now.Second%2==0) 
    //{
    if (start_x+figure.GetLength(0)==field.GetLength(0))
    {
        start_x=0; 
        start_y=field.GetLength(1)/2;
        figure=list_figures[Random.Shared.Next(0,6)]; //берём любую фигуру из листа
    }

    place_figures(ref field, figure, start_x, start_y); //рисование фигуры на поле
    print_figure(field);
    choise=Console.ReadKey();
    //}

    if (choise.Key==ConsoleKey.UpArrow)
    {
        rotate_figure(ref figure, 90, true); //вращение по часовой стрелке
        if (start_x+figure.GetLength(0)<field.GetLength(0)) start_x++; //движение вниз
    }
    if (choise.Key==ConsoleKey.RightArrow)
    {
        if (start_y+figure.GetLength(1)<field.GetLength(1)) start_y++; //движение влево
        if (start_x+figure.GetLength(0)<field.GetLength(0)) start_x++; //движение вниз
    }
    if (choise.Key==ConsoleKey.LeftArrow)
    {
        if (start_y>0) start_y--; //движение влево //движение вправо
        if (start_x+figure.GetLength(0)<field.GetLength(0)) start_x++; //движение вниз
    }
    if (choise.Key==ConsoleKey.DownArrow)
    {
        if (start_x+figure.GetLength(0)<field.GetLength(0)) start_x++; //движение вниз
    }
}
