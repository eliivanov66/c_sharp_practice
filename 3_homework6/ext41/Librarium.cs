public class Librarium
{
    public static int randomizer(int start, int end)
    {
        System.Random temp_randomizer=new System.Random(); //новый объект генератор псевдослучайных чисел
        return temp_randomizer.Next(start, end);
    }

    //метод проверки вводимого значения
    public static int check_int_input(string message)
    {
        bool input_data_not_ok=true; //введены некорректные данные
        int input=0;                 //число для ввода
        string err_message="";
        while (input_data_not_ok) //пока введены некорректные данные
        {
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
    public static int[] init_int_array(int number, int start, int end, bool auto_fill)
    {
        int[] temp_array=new int[number]; //количество
        if (auto_fill) //1=автозаполнение
        {
            for (int i = 0; (i < temp_array.GetLength(0)); i++)
            {   
                
                temp_array[i]=System.Random.Shared.Next(start, end +1);
            }
        }
        else
        {
            for (int i = 0; (i < temp_array.GetLength(0)); i++)
            {   
                
                Console.Clear();
                temp_array[i]=check_int_input($"Введите значение {i}/{number-1} элемента ");
            }
        }
        return temp_array;
    }

    //метод рисования массива
    public static void display_array (int[] input)
    {
        Console.Write("[");
        for (int i = 0; i < (input.GetLength(0)); i++)
        {
            Console.Write($"{input[i]}"); //вывод результата  
            if ((i+1) < (input.GetLength(0))) 
            {
                Console.Write(",");
            }
            else
            {
                Console.Write("]");
            }
        }
        Console.WriteLine();
    }
}