//библиотека методов из прошлого задания
using static Librarys;

//код задачи
int input=0; //ввод от пользователя

while (input<=0)
{
    input=check_int_input("Введите число для конверсии ");
}
int result=convert_bin_to_dec(input, 10);
Console.WriteLine($"Число после конверсии: {result}");
