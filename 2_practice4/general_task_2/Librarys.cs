/*1. Написать метод, который генерирует массив 0 и 1 заданного количества N

3 -> 1 1 0
	 1 0 0
	 0 0 1
*/
public class Librarys
{
    public static int check_int_input(string message)
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
    public static int[] init_int_array(int number, int start, int end)
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
    public static void display_array (int[] input)
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
    public static int find_min_array(int[] input_array)
        {
            int min = input_array[0];
            for (int i = 0; (i < input_array.Count()); i++)
            {
                if (input_array[i]<min) min=input_array[i]; continue;
            }
            return min;
        }
    //метод поиска максимального значения в массиве
    public static int find_max_array(int[] input_array)
        {
            int max = input_array[0];
            for (int i = 0; (i < input_array.Count()); i++)
            {
                if (input_array[i]>max) max=input_array[i]; continue;
            }
            return max;
        }
    //метод возвращает количество цифр в числе Int32
    public static int show_sign_count_int (int input)
    {
        int temp=input;
        int sign_count=0;
        //проверка сколько знаков в числе
        while (Math.Abs(temp)>0)
        {
            temp=temp/10;
            sign_count++;
        }
        if (input==0) sign_count=1;
        return sign_count;
    }

    //метод вычленяющий нужный нам знак
    public static int show_sign_by_number(int input, int sign)
    {
        if (sign>=1)
        {
            return (input % Convert.ToInt32(Math.Pow(10.0, Convert.ToDouble(sign)))/
                        Convert.ToInt32(Math.Pow(10.0, Convert.ToDouble(sign-1)) ));
        }
        else
        {
            Console.WriteLine("show_sign_by_number: Параметры метода заданы некорректно");
            return -1;
        }
    }
    //метод конверсии десятичного числа в двоичное
    public static int convert_bin_to_dec(int arg_input, int arg_base)
    {
        int result=0;
        int sign_count=show_sign_count_int(arg_input); //сколько разрядов в числе
        Console.WriteLine($"Количество разрядов числа sign_count = {sign_count}");
        //111101
        for (int i = 0; i < sign_count; i++)
        {
            int sign_value=show_sign_by_number(arg_input, i + 1); //показывает значение в текущем разряде
            Console.WriteLine($"Значение в разряде sign_value = {sign_value}");
            result=result + sign_value * Convert.ToInt32(Math.Pow(2.0, i));      //значение результата для текущего разряда
            Console.WriteLine($"Промежуточный результат result = {result}");
        }
        return result;
    }
}