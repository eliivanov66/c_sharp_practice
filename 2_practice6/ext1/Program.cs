/*Составить частотный словарь элементов двумерного массива */


//заполнение массива
void fill_array_char(ref char[,] input)
{
    for (int i=0; i<input.GetLength(0); i++)
    {
        for (int j=0; j<input.GetLength(1); j++)
        {
            //input[i,j]=Convert.ToChar(System.Random.Shared.Next(65, 91)); 
            input[i,j]=Convert.ToChar(System.Random.Shared.Next(97, 123));    
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

//печать массива
void print_array_double(double[] input)
{
    Console.Write("[");
    for (int i=0; i<input.GetLength(0); i++)
    {

        Console.Write($"{input[i]};");   
        
    }
    Console.Write("]");
    Console.WriteLine();
}

double[] power_array (char[,] arg_input_array, string arg_alphafet)
{
    double[] buffer_array=new double[arg_alphafet.Length];
    double perzent_sum=0.0;
    for (int i=0; i<arg_alphafet.Length; i++)
    {
        for (int j=0; j<arg_input_array.GetLength(0); j++)
        {
            for (int k=0; k<arg_input_array.GetLength(1); k++)
            {
            if (arg_alphafet[i]==arg_input_array[j,k])  buffer_array[i]=buffer_array[i]+1.0;
            }     
        } 
        buffer_array[i]=100.0*buffer_array[i]/(arg_input_array.GetLength(0)*arg_input_array.GetLength(1));
        perzent_sum=perzent_sum+buffer_array[i];
        if (buffer_array[i]>0.0) Console.WriteLine($"{arg_alphafet[i]}: {buffer_array[i]} %");
    }
    Console.WriteLine($"Сумма всех мощностей равна {perzent_sum}% (если <100 % - метод работает неправильно)");
    return buffer_array;
}

string abc ="abcdefghijklmnopqrstuwvyxz"; //алфавит 65-90 ASCII
char[,] input_array=new char[10,10];    //массив - текст
double [] result_array = new double[abc.Length]; //массив частот

Console.Clear();
fill_array_char(ref input_array);
Console.WriteLine("Сгенерирован следующий массив: ");
print_array_char(input_array);
Console.WriteLine("Массив мощностей: ");
result_array=power_array(input_array, abc);



//Console.WriteLine($"Получен символ кодом {temp} : {System.Convert.ToChar(temp)}");
//Console.WriteLine(Convert.ToChar(65));