
using static My_tetris;
char _0='0';
char _1=Convert.ToChar(9632);
char[,] field      =new char[16,16];
char[,] fill_field =new char[16,16];
char[,] figure;//=new int[4,4] {{0,0,0,0},{0,0,0,0},{0,1,0,0},{1,1,1,0}};
char[,] line       =new char[1,4] {{_1,_1,_1,_1}};
char[,] square     =new char[2,2] {{_1,_1},{_1,_1}};
char[,] angle_left =new char[3,2] {{_0,_1},{_0,_1},{_1,_1}};
char[,] angle_right=new char[3,2] {{_1,_0},{_1,_0},{_1,_1}};
char[,] sig_left   =new char[3,2] {{_1,_0},{_1,_1},{_0,_1}};
char[,] sig_right  =new char[3,2] {{_0,_1},{_1,_1},{_1,_0}};
char[,] triangle   =new char[2,3] {{_0,_1,_0},{_1,_1,_1}};
char[,] star       =new char[3,3] {{_0,_1,_0},{_1,_1,_1},{_0,_1,_0}};
char[,] snake_left =new char[3,3] {{_1,_0,_0},{_1,_1,_1},{_0,_0,_1}};
char[,] snake_right=new char[3,3] {{_0,_0,_1},{_1,_1,_1},{_1,_0,_0}};

List<char[,]> list_figures = new List<char[,]> {line,square,angle_left, angle_right,sig_left,sig_right,triangle,star, snake_left,sig_right};


int coord_x=0;
int coord_y=field.GetLength(1)/2;
int size_x=0;
int size_y=0;
bool floor_collision=false; //фигура попала на заполненное поле
bool reset_level=false;     //выстроена линия, обнуляем
int score=0;
//0000
//0000
//0100
//1110

init_field(ref fill_field,'0');
init_field(ref field,'0');
print_figure(fill_field);
ConsoleKeyInfo choise; //ввод клавиши
Console.WriteLine("Вверх/вниз поворот фигуры. Для выхода нажмите Q");
figure=list_figures[Random.Shared.Next(0,list_figures.Count)]; //берём любую фигуру из листа


//поток отрисовки фигуры на плоскости
new Thread(() =>
{
  while (true)
  {
    size_x=figure.GetLength(0);
    size_y=figure.GetLength(1);

    floor_collision=colision_field(fill_field, figure, coord_x , coord_y); //проверка на пересечение с фигурами уже стоящими на поле
    if (((coord_x+size_x>field.GetLength(0))) || (floor_collision))        //фигура установлена, нужна новая фигура
    {
        fill_field=field;
        coord_x=0; 
        coord_y=field.GetLength(1)/2;
        figure=list_figures[Random.Shared.Next(0,list_figures.Count)]; //берём любую фигуру из листа
        Console.Beep(500,100);
    }

    reset_level=line_is_filled(fill_field); //проверка собрана ли нижняя линия

    //if (reset_level)
    //{
    //    fill_field=remove_line(fill_field);
    //} 

    field=place_figures(fill_field, figure, coord_x, coord_y); //рисование фигуры на поле
    print_figure(field);
    Thread.Sleep(500);
    coord_x++;
  }
}).Start();

//поток управления
new Thread(() =>
{
    choise=Console.ReadKey();
    while (true)
    {
        choise=Console.ReadKey();
        if ((choise.Key==ConsoleKey.Q) || (choise.Key==ConsoleKey.Escape) || (choise.Key==ConsoleKey.Spacebar))
        {
            Environment.Exit(0); //выход из приложения
        }
        if (choise.Key==ConsoleKey.UpArrow)
        {
            if ((coord_y+size_x) > field.GetLength(1)) coord_y--;
            rotate_figure(ref figure, 90, true); //вращение по часовой стрелке
            Console.Beep(2000, 100);
        }
        if (choise.Key==ConsoleKey.RightArrow)
        {
            if (coord_y+size_y<field.GetLength(1)) coord_y++; //движение влево
            Console.Beep(2000, 100);
        }
        if (choise.Key==ConsoleKey.LeftArrow)
        {
            if (coord_y>0) coord_y--; //движение влево //движение вправо
            Console.Beep(2000, 100);
        }
        if (choise.Key==ConsoleKey.DownArrow)
        {
            if (coord_x+size_x<field.GetLength(0)) coord_x++; //движение вниз
            Console.Beep(2000, 100);
        }
    }
}).Start();




