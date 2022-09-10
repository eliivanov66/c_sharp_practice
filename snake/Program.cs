
using static My_Snake;
char _1=Convert.ToChar(9632);
char[,] field      =new char[16,32];
char[,] fill_field =new char[16,32];
char[,] snake = new char [1,1] {{Convert.ToChar(9632)}};
char[,] target = new char [1,1] {{'+'}};
//переменные
int snake_coord_x=0;                    //координата головы змейки по X
int snake_coord_y=field.GetLength(0)/2; //координата головы змейки по Y
int moving_direction=2;                 //направление движения
int snake_lenght=0;                     //длина змеи
int target_coord_x=Random.Shared.Next(0, field.GetLength(1));//координата цели по X
int target_coord_y=Random.Shared.Next(0, field.GetLength(0));//координата цели по Y
bool collision=false;                   //фигура попала на заполненное поле
bool pause_game=false;                  //пауза игры
bool game_over=false;                   //игра окончена
int score=0;                            //очки
int speed=500;                          //скорость задержки между движениями, мсек
ConsoleKeyInfo choise;                  //переменная ввода клавиши
//инициализация поля и поля результатов, первой фигуры
init_field(ref fill_field,' ');
init_field(ref field,' ');
print_figure(fill_field);
//поток отрисовки фигуры на плоскости
new Thread(() =>
{
  while (true)
  {
    //снятие геометрии текущей фигуры
    //проверка достигла ли фигура пола или есть ли колизии с другими объектами, если да, то новая фигура
    //рисование поля и фигуры на нём
    switch (moving_direction)
    {
        case 0: 
            if (!pause_game) snake_coord_y--;
            if ((snake_coord_y) < 0) snake_coord_y=field.GetLength(0)-1; //движение вверх
            break;
        case 1: 
            if (!pause_game) snake_coord_y++;
            if ((snake_coord_y) >= field.GetLength(0)) snake_coord_y=0; //движение вниз
            break;
        case 2:
            if (!pause_game) snake_coord_x++;
            if ((snake_coord_x) >= field.GetLength(1)) snake_coord_x=0; //движение вправо
            break;
        case 3: 
            if (!pause_game) snake_coord_x--;
            if ((snake_coord_x) < 0) snake_coord_x=field.GetLength(1)-1; //движение влево
            break;
    }
    field=place_figures(fill_field, snake, snake_coord_x, snake_coord_y); //рисование фигуры на поле
    field=place_figures(field, target, target_coord_x, target_coord_y); //рисование фигуры на поле
    print_figure(field);

    //провера переполнения игрового поля
    collision=(target_coord_x==snake_coord_x) && (target_coord_y==snake_coord_y);
    if (collision) //касаение змейкой цели
    {
        snake_lenght++;
        target_coord_x=Random.Shared.Next(0, field.GetLength(1));
        target_coord_y=Random.Shared.Next(0, field.GetLength(0));
        char[,] snake = new char [1,1] {{Convert.ToChar(9632)}};
    }
    if (!pause_game) 
        Console.WriteLine($"Управление: ВВЕРХ/ВНИЗ/ВЛЕВО/ВПРАВО - движение, ПРОБЕЛ - пауза");
    else
        Console.WriteLine($"ПАУЗА АКТИВНА, ПРОБЕЛ - отменить паузу");
    score=snake_lenght;
    Console.WriteLine($"У вас {score} очков, скорость движения {speed} (A/S - изменение скорости)");
    Console.WriteLine($"x {snake_coord_x}, y {snake_coord_y}");
    Thread.Sleep(speed);
    //if (!pause_game) coord_x++;

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
        //движение вверх   
        if ((choise.Key==ConsoleKey.UpArrow) && (!pause_game))
        {
            //coord_y--;
            moving_direction=0;
        }
        //движение вниз   
        if ((choise.Key==ConsoleKey.DownArrow) && (!pause_game))
        {
            //coord_y++;
            moving_direction=1;
        }
        //движение вправо
        if ((choise.Key==ConsoleKey.RightArrow) && (!pause_game))
        {   
            //coord_x++;
            moving_direction=2;
        }
        //движение влево
        if ((choise.Key==ConsoleKey.LeftArrow) && (!pause_game))
        {
            //coord_x--;
            moving_direction=3;
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



