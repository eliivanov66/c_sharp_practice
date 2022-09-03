public static class Labyrint
{
    // Ввод и перевод массива пользователем с клавиатуры в числовой массив с помощью разделителя
    public static int[] InputToIntArray(char splitter)
    {
        string str = Console.ReadLine()!;
        str = str.Replace(',', ' ');
        str = str.Replace('(', ' ');
        str = str.Replace(')', ' ');
        string[] strarray = str.Split(splitter);
        int[] intarray = new int[strarray.Length];

        for (int i = 0; i < intarray.Length; i++)
        {
            intarray[i] = int.Parse(strarray[i]);
        }
        return intarray;
    }

    // Ввод и перевод массива пользователем с клавиатуры в вещественный массив с помощью разделителя
    public static double[] InputToFloatArray(char splitter)
    {
        string str = Console.ReadLine()!;
        str = str.Replace(',', ' ');
        str = str.Replace('(', ' ');
        str = str.Replace(')', ' ');
        string[] strarray = str.Split(splitter);
        double[] intarray = new double[strarray.Length];

        for (int i = 0; i < intarray.Length; i++)
        {
            intarray[i] = double.Parse(strarray[i]);
        }
        return intarray;
    }


    // метод ввода:D
    public static int InputToInt(string input)
    {
        int output = 0;
        output = int.Parse(input);
        return output;
    }

    // метод проверки на четность
    public static bool IfEven(int input)
    {
        if (input % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // метод сравнения чисел
    public static (int i1, int i2) MaxAndMin(int input1, int input2)
    {
        if (input1 > input2)
        {
            return (i1: input1, i2: input2);
        }
        else
        {
            return (i1: input2, i2: input1);
        }
    }

    // метод проверки строки на палиндромность
    public static int IfStringIsPalidrome(string input)
    {
        int count = 0;
        for (int i = 0; i < input.Length / 2; i++)
        {
            if (input[i] == input[input.Length - 1 - (i)])
            {
                count = count + 1;
            }
            else
            {
                count = count + 0;
            }
        }
        if (count == input.Length / 2)
        {
            return count = 1;
        }
        else
        {
            return count = 0;
        }
    }

    // метод проверки числа на палиндромность
    public static int IfIntIsPalidrome(int input)
    {
        int numbertemp = input;
        int element = 0;
        int sumtemp = 0;
        while (numbertemp != 0)
        {
            element = numbertemp % 10;
            sumtemp = (sumtemp * 10) + element;

            numbertemp = numbertemp / 10;
        }
        if (sumtemp == input)
        {
            return sumtemp = 1;
        }
        else
        {
            return sumtemp = 0;
        }
    }


    // метод нахождения расстояния между 2-умя точками в 2D/3D пространствах
    public static float FindDistanceBtwCoords(float[] coord1, float[] coord2)
    {
        float x = 0;
        float y = 0;
        float z = 0;
        float distance = 0;
        switch ((coord1.Length + coord2.Length) / 2)
        {
            case 3:
                {
                    x = (coord2[0] - coord1[0]) * (coord2[0] - coord1[0]);
                    y = (coord2[1] - coord1[1]) * (coord2[1] - coord1[1]);
                    z = (coord2[2] - coord1[2]) * (coord2[2] - coord1[2]);
                    distance = MathF.Sqrt(x + y + z);
                    Console.WriteLine($"  Distance between yours coordinates == {distance}");
                    break;
                }
            case 2:
                {
                    x = (coord2[0] - coord1[0]) * (coord2[0] - coord1[0]);
                    y = (coord2[1] - coord1[1]) * (coord2[1] - coord1[1]);
                    distance = MathF.Sqrt(x + y + z);
                    Console.WriteLine($"  Distance between yours coordinates == {distance}");
                    break;
                }
            default:
                {

                    Console.WriteLine("  ERROR! SUCH COORDINATES CANNOT EXIST");

                    break;
                }
        }
        return distance;

    }


    // метод, который возводит A в натуральную степень B
    public static int AInSqrB(int number1, int number2)
    {
        int step = 1;
        for (int i = 0; i < number2; i++)
        {
            step = step * number1;
        }
        return step;

    }


    // метод рандомайзера натуральных чисел одномерного массива
    public static void NaturalRamdomizer(int[] array, int min, int max)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = new Random().Next(min, max);
        }
    }


    // метод рандомайзера натуральных чисел двумерного массива
    public static void TwoDNaturalRamdomizer(int[,] array, int min, int max)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)

                array[i, j] = new Random().Next(min, max);
        }
    }


    // метод рандомного двумерного массива натуральных чисел
    public static int[,] TwoDArray(int m, int n, int min, int max)
    {
        int[,] output = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                TwoDNaturalRamdomizer(output, min, max);
            }
        }
        return output;
    }


    // метод рандомайзера вещественных чисел
    public static void FloatRandomizer(double[] array, int min, int max)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = new Random().NextDouble() * max - min;
        }
    }


    // // метод рандомайзера вещественных чисел двумерного массива
    public static void TwoDFloatRandomizer(double[,] array, double min, double max)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)

                array[i, j] = new Random().NextDouble() * (max - min);
        }
    }

    // метод рандомного двумерного массива вещественных чисел
    public static double[,] TwoDFloatArray(int m, int n, double min, double max)
    {
        double[,] output = new double[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                TwoDFloatRandomizer(output, min, max);
            }
        }
        return output;
    }



    // метод вывода одномерного массива натуральных чисел
    public static void OneDArrayPrint(int[] yorsarrayprint)
    {
        for (int i = 0; i < yorsarrayprint.Length; i++)
        {
            Console.Write($" [{yorsarrayprint[i]}]");
        }
        Console.WriteLine("\n");
    }


    // метод вывода двумерного массива натуральных чисел
    public static void TwoDArrayPrint(int[,] yorsarrayprint)
    {
        for (int i = 0; i < yorsarrayprint.GetLength(0); i++)
        {
            for (int j = 0; j < yorsarrayprint.GetLength(1); j++)
            {
                Console.Write($" {yorsarrayprint[i, j]}");
            }
            Console.WriteLine();

        }
        Console.WriteLine("\n");
    }


    // метод вывода двумерного массива вещественных чисел
    public static void TwoDFloatArrayPrint(double[,] yorsarrayprint)
    {
        for (int i = 0; i < yorsarrayprint.GetLength(0); i++)
        {
            for (int j = 0; j < yorsarrayprint.GetLength(1); j++)
            {
                Console.Write($" [{yorsarrayprint[i, j]:F3}]");
            }
            Console.WriteLine();

        }
        Console.WriteLine("\n");
    }


    // метод вывода одномерного массива вещественных чисел
    public static void OneDArrayFloatPrint(double[] yorsarrayprint)
    {
        for (int i = 0; i < yorsarrayprint.Length; i++)
        {
            Console.Write($"[{yorsarrayprint[i]}]");
        }
        Console.WriteLine("\n");
    }


    // метод, принимающий десятичное представление и основание СС в которую нужно это число перевести
    public static string TenDimensionalTo(int number, int osnovanie)
    {
        string str = "";
        while (number > 0)
        {
            int sum = 0;
            sum = number % osnovanie;
            number = number / osnovanie;
            str = sum + str;
        }
        return str;
    }


    public static int[] DarrayFindElementI(int[,] array, int input)
    {
        int sizecount = 0;                                                 // 42 - 54 строки делаю это для "красивого" вывода
        int count = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] == input)
                {
                    sizecount += 2;
                    count++;
                }
            }
        }
        int k = 0;                       // новая переменная что бы новый массив заполнялся с начала, а не с i или j индекса, когда элемент который мы ищем найдется
        int[] foundindexes = new int[sizecount];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] == input)
                {
                    foundindexes[k] = i;
                    foundindexes[k + 1] = j;
                    k += 2;
                }
            }
        }
        return foundindexes;
    }

}