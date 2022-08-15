/*1. Написать метод, который генерирует массив 0 и 1 заданного количества N

3 -> 1 1 0
	 1 0 0
	 0 0 1
*/

int check_int_input(string message)
{
    bool input_data_not_ok=true; //введены некорректные данные
    int input=0;                 //число для ввода
    string err_message="";
    while (input_data_not_ok) //пока введены некорректные данные
    {
        Console.Clear();
        Console.WriteLine($"{err_message}{message} :");
        try
        {
            input=Convert.ToInt32(Console.ReadLine());
            input_data_not_ok=false; //считаем что данные введены корректно
        }
        catch (SystemException) 
        {
            input_data_not_ok=true; //пока введены некорректные данные
            err_message="Неправильный ввод. ";
        }
    }
    return input;
}

//метод заполнения одномерного массива числами в диапазоне от start до end
int[] init_int_array(int number, int start, int end)
{
    Random randomizer=new Random();
    int[] temp_array=new int[number]; //количество
    for (int i = 0; (i < temp_array.GetLength(0)); i++)
    {   
        
        temp_array[i]=randomizer.Next(start, end +1);
    }
    return temp_array;
}

 //метод рисования массива
void display_array (int[] input)
    {
        Console.Write("{");
        for (int i = 0; i < (input.GetLength(0)); i++)
        {
            Console.Write($"{input[i]}"); //вывод результата  
            if (i!=0 && ((i % 10) == 0) ) 
            {
                //Console.Write(",");
                Console.WriteLine();
            }
            else
            {
                //Console.Write(",");
            }
        }
        Console.Write("}"); Console.WriteLine();
    }

//метод поиска минимального значения в массиве
int find_min_array(int[] input_array)
    {
        int min = input_array[0];
        for (int i = 0; (i < input_array.Count()); i++)
        {
            if (input_array[i]<min) min=input_array[i]; continue;
        }
        return min;
    }
//метод поиска максимального значения в массиве
int find_max_array(int[] input_array)
    {
        int max = input_array[0];
        for (int i = 0; (i < input_array.Count()); i++)
        {
            if (input_array[i]>max) max=input_array[i]; continue;
        }
        return max;
    }

//код задачи
int N=0;
while (N<=0)
{
    N=check_int_input("Введите число N, размерность массива");
}
int[] array; //создание пустого массива
array=init_int_array(N,0,1); //заполнение массива
Console.WriteLine($"Получен следующий массив значений 0/1 длиной {N}");
display_array(array);   