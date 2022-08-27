
using static My_tetris;
char _0='0';
char _1=Convert.ToChar(9632);
char[,] field      =new char[15,16];
char[,] fill_field =new char[15,16];
char[,] figure;
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

//List<char[,]> list_figures = new List<char[,]> {line,square,angle_left, angle_right,sig_left,sig_right,triangle,star, snake_left,snake_right};
List<char[,]> list_figures = new List<char[,]> {line,square,angle_left, angle_right,sig_left,sig_right,triangle};

//переменные
int coord_x=0;                        //координата фигуры по X
int coord_y=field.GetLength(1)/2;     //координата фигуры по Y
int size_x=0;                         //размер фигуры по X
int size_y=0;                         //размер фигуры по Y
bool floor_collision=false;           //фигура попала на заполненное поле
(bool,int) reset_level=(false,0);     //выстроена линия, обнуляем
int score=0;                          //очки
int speed=500;                        //скорость задержки между движениями, мсек
ConsoleKeyInfo choise;                //переменная ввода клавиши
//инициализация поля и поля результатов, первой фигуры
init_field(ref fill_field,'0');
init_field(ref field,'0');
print_figure(fill_field);
figure=list_figures[Random.Shared.Next(0,list_figures.Count)]; //берём любую фигуру из листа
//поток отрисовки фигуры на плоскости
new Thread(() =>
{
  while (true)
  {
    //снятие геометрии текущей фигуры
    size_x=figure.GetLength(0);
    size_y=figure.GetLength(1);
    //проверка достигла ли фигура пола или есть ли колизии с другими объектами, если да, то новая фигура
    floor_collision=colision_field(fill_field, figure, coord_x , coord_y); //проверка на пересечение с фигурами уже стоящими на поле
    if (((coord_x+size_x>field.GetLength(0))) || (floor_collision))        //фигура установлена, нужна новая фигура
    {
        fill_field=field;
        coord_x=0; 
        coord_y=field.GetLength(1)/2;
        figure=list_figures[Random.Shared.Next(0,list_figures.Count)]; //берём любую фигуру из листа
        //удаление заполненных строк
        reset_level=line_analyse(fill_field); //проверка собрана ли нижняя линия
        while (reset_level.Item1)
        {
            fill_field=remove_line(fill_field, reset_level.Item2);
            reset_level=line_analyse(fill_field); //проверка собрана ли нижняя линия
            score++;
        }
    }
    //рисование поля и фигуры на нём
    field=place_figures(fill_field, figure, coord_x, coord_y); //рисование фигуры на поле
    print_figure(field);
    Console.WriteLine($"У вас {score} очков, скорость падения {speed}");
    Thread.Sleep(speed);
    coord_x++;
  }
}).Start();

//поток управления
new Thread(() =>
{
    while (true)
    {
        choise=Console.ReadKey();
        if ((choise.Key==ConsoleKey.Q) || 
            (choise.Key==ConsoleKey.Escape) || 
            (choise.Key==ConsoleKey.Spacebar) ||
            ((false))
           )
        {
            Console.Clear();
            Console.WriteLine($"=============================");
            Console.WriteLine($"Ваш результат - {score} очков");
            Console.WriteLine($"=============================");
            Environment.Exit(0); //выход из приложения
        }
        if (choise.Key==ConsoleKey.UpArrow)
        {
            if ((coord_y+size_x) > field.GetLength(1)) coord_y--;
            rotate_figure(ref figure, 90, true); //вращение по часовой стрелке
        }
        if (choise.Key==ConsoleKey.RightArrow)
        {
            if (coord_y+size_y<field.GetLength(1)) coord_y++; //движение влево
        }
        if (choise.Key==ConsoleKey.LeftArrow)
        {
            if (coord_y>0) coord_y--; //движение влево //движение вправо
        }
        if (choise.Key==ConsoleKey.DownArrow)
        {
            if (coord_x+size_x<field.GetLength(0)) coord_x++; //движение вниз
        }
        if (choise.Key==ConsoleKey.S)
        {
            if (speed<1900) speed+=100; //замедление скорости падения
        }
        if (choise.Key==ConsoleKey.A)
        {
            if (speed>200) speed-=100;  //увеличение скорости падения
        }
    }
}).Start();




