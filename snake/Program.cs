
using static My_Snake;
char _0='0';
char _1=Convert.ToChar(9632);
char[,] field      =new char[16,16];
char[,] fill_field =new char[16,16];
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
bool collision=false;                 //фигура попала на заполненное поле
bool pause_game=false;                //пауза игры
bool game_over=false;                 //игра окончена
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
    //рисование поля и фигуры на нём
    field=place_figures(fill_field, figure, coord_x, coord_y); //рисование фигуры на поле
    print_figure(field);
    //провера переполнения игрового поля
    collision=colision_field(fill_field, figure, coord_x , coord_y); //проверка на пересечение с фигурами уже стоящими на поле
    if (collision) game_over=true; //поле переполнено
    Console.WriteLine($"Управление: ВВЕРХ - вращение, ВЛЕВО/ВПРАВО - смещение");
    Console.WriteLine($"Управление: ПРОБЕЛ - пауза, A/S - изменеие скорости падения, Q/ESC - выход");
    Console.WriteLine($"У вас {score} очков, скорость падения {speed}");
    Thread.Sleep(speed);
    if (!pause_game) coord_x++;

    //выход из приложения
    if (game_over)
    {
    Console.Clear();
    Console.WriteLine($"============================================");
    Console.WriteLine($"Игра окончена. Ваш результат - {score} очков");
    Console.WriteLine($"============================================");
    Environment.Exit(0); //выход из приложения
    }
  }
}).Start();
//поток управления
new Thread(() =>
{
    while (true)
    {     
        choise=Console.ReadKey();
        //выход из приложения по команде
        if ((choise.Key==ConsoleKey.Q) || 
            (choise.Key==ConsoleKey.Escape)
           )
        {
            game_over=true;
        }
        //пауза игры
        if (choise.Key==ConsoleKey.Spacebar)
        {
            pause_game=!pause_game;
        }
        //вращение фигуры   
        if ((choise.Key==ConsoleKey.UpArrow) && (!pause_game))
        {
            if ((coord_y+size_x) > field.GetLength(1)) coord_y--;
            rotate_figure(ref figure, 90, true); //вращение по часовой стрелке
        }
        //движение вправо
        if ((choise.Key==ConsoleKey.RightArrow) && (!pause_game))
        {   
            collision=colision_field(fill_field, figure, coord_x , coord_y); //проверка на пересечение с фигурами уже стоящими на поле
            if (coord_y+size_y<field.GetLength(1) && !collision) coord_y++; //движение вправо
        }
        //движение влево
        if ((choise.Key==ConsoleKey.LeftArrow) && (!pause_game))
        {
            collision=colision_field(fill_field, figure, coord_x , coord_y); //проверка на пересечение с фигурами уже стоящими на поле
            if (coord_y>0 && !collision) coord_y--; 
        }
        //движение вниз
        if ((choise.Key==ConsoleKey.DownArrow) && (!pause_game))
        {
            if (coord_x+size_x<field.GetLength(0)) coord_x++; //движение вниз
        }
        if ((choise.Key==ConsoleKey.S) && (!pause_game))
        {
            if (speed<1900) speed+=100; //замедление скорости падения
        }
        if ((choise.Key==ConsoleKey.A) && (!pause_game))
        {
            if (speed>200) speed-=100;  //увеличение скорости падения
        }
    }
}).Start();



