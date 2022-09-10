/*
Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.

m = 2, n = 3 -> A(m,n) = 29
*/

//m=0: n+1
//a(m-1,1) m>0, n=0
//a(m-1, A(m,n-1)), m>0, n>0

using static Librarium;
int Akkerman(int ArgM, int ArgN)
{
    int Result=default(int);
    if (ArgM==0) Result=ArgN+1;
    if ((ArgM>0) && (ArgN==0)) Result=Akkerman(ArgM-1,1);
    if ((ArgM>0) && (ArgN>0)) Result=Akkerman(ArgM-1, Akkerman(ArgM,ArgN-1));
    return Result;
}
int m=-1;
int n=-1;
Console.Clear();
while ((m<0) || (n<0))
{
    m=CheckIntInput("Введите аргумент m функции Аккермана");
    n=CheckIntInput("Введите аргумент n функции Аккермана");
}
Console.WriteLine($"Результат выполнения функции Аккермана({m},{n}): {Akkerman(m,n)}");
