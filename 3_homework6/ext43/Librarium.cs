public class Librarium
{
    public static double check_int_input(string message)
    {
        bool input_data_not_ok=true; //введены некорректные данные
        double input=0.0;                 //число для ввода
        string err_message="";
        string temp_input="";
        while (input_data_not_ok) //пока введены некорректные данные
        {
            Console.WriteLine($"{err_message}{message} :");
            try
            {
                temp_input=$"{Console.ReadLine()}";
                temp_input=temp_input.Replace(".",",");
                input=Convert.ToDouble(temp_input);
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
}