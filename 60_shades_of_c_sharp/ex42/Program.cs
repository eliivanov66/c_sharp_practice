/*
42. Определить сколько чисел больше 0 введено с клавиатуры
*/

ConsoleKeyInfo choise; //ввод клавиши
Console.Clear();
Console.WriteLine("Для ввода значений нажмите любую клавишу, для выхода из программы нажмите Q");
choise=Console.ReadKey();
int key_count=0;
while (choise.Key!=ConsoleKey.Q)
{
    Console.Clear();
    if ( (choise.Key.GetHashCode()>=48) && (choise.Key.GetHashCode()<=57) ) //хэшкоды для клавиш 1..9
    {
        key_count++; 
    }
    if ( (choise.Key.GetHashCode()>=96) && (choise.Key.GetHashCode()<=105) ) //хэшкоды для клавиш Num 0..9
    {
        key_count++; 
    }
    Console.WriteLine($"Вы нажали цифровые клавишы {key_count} раз, для выхода из программы нажмите Q");
    choise=Console.ReadKey();
}