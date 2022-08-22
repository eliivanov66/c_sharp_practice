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
    
    //метод проверки вводимого значения универсальный
    public dynamic check_input (string message, Type arg_type)
    {
        bool input_data_not_ok=true; //введены некорректные данные
        dynamic input=0;          //число для ввода
        string err_message="";
        while (input_data_not_ok) //пока введены некорректные данные
        {
            Console.WriteLine($"{err_message}{message} :");
            try
            {
                string temp_input=Console.ReadLine()+"";
                temp_input=temp_input.Replace(".",",");
                switch (arg_type.Name)
                {
                    case ("Int32"):
                            input=Convert.ToInt32(temp_input);
                            break;
                    case ("Double"):
                            input=Convert.ToDouble(temp_input);
                            break;
                    case ("Int64"):
                            input=Convert.ToInt64(temp_input);
                            break;
                    case ("Int16"):
                            input=Convert.ToInt16(temp_input);
                            break;
                    default:
                            input=Convert.ToInt32(temp_input);
                            break;
                }
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
    public static double[] init_double_array(int number, int start, int end)
    {
        Random randomizer=new Random();
        double[] temp_array=new double[number]; //количество
        for (int i = 0; (i < temp_array.GetLength(0)); i++)
        {   
            
            temp_array[i]=Math.Round((Random.Shared.NextDouble()*Random.Shared.Next(start, end+1)),3);
        }
        return temp_array;
    }

    //метод рисования массива
    public static void display_double_array (double[] input)
    {
        Console.Write("[");
        for (int i = 0; i < (input.GetLength(0)); i++)
        {
            Console.Write($"{input[i]};"); //вывод результата  
        }
        Console.Write("]");
        Console.WriteLine();
    }
}