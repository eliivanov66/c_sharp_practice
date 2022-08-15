//библиотека методов из прошлого задания
using static Librarys;

/*
3. Написать метод, принимающий  десятиченое представление
   и основание СС в которую нужно это число перевести
   2<= основание <= 9
10,2 -> 1010
10,8 -> 12
7,6 ->  10
*/

int input_number=0; //данные от пользователя
int input_base=0;  //

while (input_number<=0)
{
    input_number=check_int_input("Введите число для конверсии ");
}

while (input_base<=0)
{
    input_base=check_int_input("Введите базу новой системы изчисления ");
}

Console.WriteLine($"Результат конвертация числа {input_number} в {input_base} чистему исчесления равен: {convert_dec_to_base(input_number, input_base)}");