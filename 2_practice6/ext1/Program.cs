/*Составить частотный словарь элементов двумерного массива */
using System.Globalization;

//заполнение массива
void fill_array_char(ref char[,] input)
{
    for (int i=0; i<input.GetLength(0); i++)
    {
        for (int j=0; j<input.GetLength(1); j++)
        {   
            input[i,j]=Convert.ToChar(System.Random.Shared.Next(0, 65535));    
        }
    }
}

//печать массива
void print_array_char(char[,] input)
{
    for (int i=0; i<input.GetLength(0); i++)
    {
        for (int j=0; j<input.GetLength(1); j++)
        {
            Console.Write($"{input[i,j]}");   
        }
        Console.WriteLine();
    }
}


double[] power_array (string arg_input, string arg_alphafet)
{
    double[] buffer_array=new double[arg_alphafet.Length];
    double perzent_sum=0.0;
    for (int i=0; i<arg_alphafet.Length; i++)
    {
        for (int j=0; j<arg_input.Length; j++)
        {
            if (arg_alphafet[i]==arg_input[j])  buffer_array[i]=buffer_array[i]+1.0; 
        } 
        buffer_array[i]=100.0*buffer_array[i]/(arg_input.Length);
        perzent_sum=perzent_sum+buffer_array[i];
        if (buffer_array[i]>0.0) Console.WriteLine($"{arg_alphafet[i]}: {buffer_array[i]} %");
    }
    Console.WriteLine($"Сумма всех мощностей равна {perzent_sum}% (если <100 % - метод работает неправильно)");
    return buffer_array;
}

//string abc ="abcdefghijklmnopqrstuwvyxz"; //алфавит 65-90 ASCII
string abc =""; //таблица ASCII 255 элементов
//заполнение словаря
for (int i=0; i<65535; i++)
{
    abc=String.Concat(abc, Convert.ToChar(i));
}

Console.Clear();
//чтение исходного текста
Console.WriteLine("Введите текст для анализа частот заполнения: ");
string input=$"{Console.ReadLine()}";            //исходный текст
double [] result_array = new double[abc.Length]; //массив частот

Console.WriteLine("Получен следующий исходный текст: ");
Console.WriteLine(input);
Console.WriteLine("Массив мощностей: ");
result_array=power_array(input, abc);