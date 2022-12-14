/*============================================================================================== */
/*========================================== переменные ======================================== */
/*============================================================================================== */
double time=0.0;                                   //время, которое бежит собака к другу номер, с
double speed_friend_1=1.0;                         //скорость друга 1, м/с
double speed_friend_2=2.0;                         //скорость друга 2, м/с
double speed_dog=5.0;                              //скорость собаки, м/с
double way=0.0;                                    //начальное расстояние между друзьями, м
double delta_way=0.0;                              //расстояние встречи, м
int friend_1_count=0;                              //количество встреч с другом 1
int friend_2_count=0;                              //количество встреч с другом 2
int input_data_not_ok=1;                           //исходных данных завершён
int friend=1;                                      //направление в котором бежит собака 1 - к другу 1, 2 - к другу 2
string error_message="Ввод исходных данных: ";     //сообщение о необходимости ввода 
/*============================================================================================== */

/*============================================================================================== */
/*================================ ввод исходных данных ======================================== */
/*============================================================================================== */
while (input_data_not_ok==1)
{
    Console.Clear();
    Console.WriteLine(error_message);
    try
    {
        Console.WriteLine("Введите скорость первого друга: ");
        speed_friend_1=Convert.ToDouble(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Введите скорость второго друга: ");
        speed_friend_2=Convert.ToDouble(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Введите скорость собаки: ");
        speed_dog=Convert.ToDouble(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Введите начальное расстояние между друзьями: ");
        way=Convert.ToDouble(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Введите расстояние встречи: ");
        delta_way=Convert.ToDouble(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Вначале собака бежит к другу номер: ");
        friend=Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        //защита от дурака, только положительные скорости и расстояния
        input_data_not_ok=0;
        if ((speed_dog<=0.0) || (speed_friend_1<=0.0) || (speed_friend_2<=0.0) || (way<=0.0) || (delta_way<=0.0) || (friend>2) || (friend<=0))
        {
            input_data_not_ok=1;
            error_message="Данные введены некорректно. Повторите ввод: ";
        }
    }
    catch (SystemException) //если ввели не те типы
    {
        input_data_not_ok=1;
        error_message="Данные введены некорректно. Повторите ввод :";
    }
}
/*============================================================================================== */

/*============================================================================================== */
/*================================== математика                 ================================ */
/*============================================================================================== */
//промежуточные расчёты
double k_1=speed_friend_1/speed_dog; //переменная, которая показывает как собака быстрее друга 1
double k_2=speed_friend_2/speed_dog; //переменная, которая показывает как собака быстрее друга 2

while (way>=delta_way) //пока расстояние между друзьями больше расстояния встречи
{
       if (friend==1) //если движение идёт к другу 1
       {
            friend_1_count=friend_1_count+1; //собака побывала у друга 1
            time=way/(k_1*speed_dog + speed_dog); //время, которое бежит собака до друга 1
            friend=2; //Бежим к другу 2
            way=way-(time*speed_friend_1)-(time*speed_friend_2); //оставшееся расстояние между друзьями
            continue; //следующий шаг цикла
       }
       if (friend==2) //если движение идёт к другу 2
       {
            friend_2_count=friend_2_count+1; //собака побывала у друга 2
            time=way/(k_2*speed_dog + speed_dog); //время, которое бежит собака до друга 2
            friend=1; //бежим к другу 1
            way=way-(time*speed_friend_1)-(time*speed_friend_2); //оставшееся расстояние между друзьями
            continue; //следующий шаг цикла
       }
}
/*============================================================================================== */

/*============================================================================================== */
/*========================== сообщения о результатах ========================================= */
/*============================================================================================== */
Console.Clear();
Console.WriteLine($"Собака прибегала к другу 1 : {friend_1_count} раз");
Console.WriteLine($"Собака прибегала к другу 1 : {friend_2_count} раз");
/*============================================================================================== */
