//метод инициализации массива задаваемой размерности
int[] initialize_array(int arr_lenght)
{
    int[] temp_array=new int[arr_lenght]; //создание массива
    Random randomizer=new Random();

    for (int i = 0; i < temp_array.Count(); i++)
    {
        temp_array[i]=randomizer.Next(10,99);
        Console.WriteLine($"    Значение {temp_array[i]} добавлено в элемент массива : {i}");
    }
    return temp_array;
}
//метод нахождения максимального значения в указанном массиве
int max_array(int[] input_array)
{
    int max_value;
    max_value=input_array[0];
    for (int i = 0; i < input_array.Count(); i++)
    {
        if (input_array[i]>max_value) max_value=input_array[i];
    }
    return max_value;
}

//ввод данных
Console.Clear();
Console.Write("Введите размерность массива : ");
int _array_zise = Convert.ToInt32(Console.ReadLine());
//вывод результата
Console.WriteLine($"Максимальное значение массива равно : {max_array(initialize_array(_array_zise))}");
