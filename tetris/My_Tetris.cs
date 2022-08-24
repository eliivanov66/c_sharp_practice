public class My_tetris
{
    public static void print_figure(char[,] input)
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
    public static void rotate_figure(ref char[,] arg_figure, int arg_angle, bool arg_direction)
    {
        char[,] result_figure;
        char[,] buffer_figure;

        if (arg_figure.GetLength(0)>=arg_figure.GetLength(1))
        {
            result_figure=new char[arg_figure.GetLength(0),arg_figure.GetLength(0)];
            buffer_figure=new char[arg_figure.GetLength(0),arg_figure.GetLength(0)];
        }
        else
        {
            result_figure=new char[arg_figure.GetLength(1),arg_figure.GetLength(1)];
            buffer_figure=new char[arg_figure.GetLength(1),arg_figure.GetLength(1)];
        }
        init_field(ref result_figure, '0');
        init_field(ref buffer_figure, '0');
        for (int i=0; i<arg_figure.GetLength(0);i++)
        {
            for (int j = 0; j < arg_figure.GetLength(1); j++)
            {
                buffer_figure[i,j]=arg_figure[i,j];
            }
        }
        //поворот на 180
        //for (int i = 0; i < arg_figure.GetLength(0); i++)
        //{
        //    for (int j = 0; j < arg_figure.GetLength(1); j++)
        //   {
        //        buffer_figure[j,i]=arg_figure[i,j];
        //    }
            
        //}
        int rotate_count=arg_angle/90;
        if (arg_direction)
        {
            for (int k=0; k<rotate_count; k++)
            { 
                //поворот на 90 по часовой стрелке
                for (int i = 0; i < buffer_figure.GetLength(0); i++)
                {
                    for (int j = 0; j < buffer_figure.GetLength(1); j++)
                    {
                        result_figure[j,buffer_figure.GetLength(1)-i-1]=buffer_figure[i,j];
                    }
                }
            }
        }
        else
        {
            for (int k=0; k<rotate_count; k++)
            {
                //поворот на 90 против часовой стрелке
                for (int i = 0; i < buffer_figure.GetLength(0); i++)
                {
                    for (int j = 0; j < buffer_figure.GetLength(1); j++)
                    {
                        result_figure[buffer_figure.GetLength(0)-j-1,i]=buffer_figure[i,j];
                    }
                }
            }
        }
        arg_figure=result_figure;

    }
    
    public static void store_figures(ref char[,] arg_field, char[,] arg_figure, int arg_x, int arg_y) 
    {
        //фигура меньше поля, всегда
        for (int i=0; i<arg_figure.GetLength(0);i++)
        {
            for (int j = 0; j < arg_figure.GetLength(1); j++)
            {
                    arg_field[i+arg_x,j+arg_y]=arg_figure[i,j];
            }
        }
        Console.WriteLine("State saved");
    }
    public static void place_figures(ref char[,] arg_field, char[,] arg_figure, int arg_x, int arg_y)
    {
        Console.WriteLine($"Inside block x= {arg_x}, y={arg_y}");
        Console.WriteLine($"Inside block figure_x= {arg_figure.GetLength(0)}, figure_y={arg_figure.GetLength(1)}");
        //буфурное поле
        char[,] buffer_field=new char[arg_field.GetLength(0), arg_field.GetLength(1)];
        for (int i=0; i<buffer_field.GetLength(0);i++)
        {
            for (int j = 0; j < buffer_field.GetLength(1); j++)
            {
                buffer_field[ i, j]='0';
            }
        }
        //фигура меньше поля, всегда
        if ( (arg_field.GetLength(0)>=arg_figure.GetLength(0)+arg_x) &&
             (arg_field.GetLength(1)>=arg_figure.GetLength(1)+arg_y))
        {
            for (int i=0; i<arg_figure.GetLength(0);i++)
            {
                for (int j = 0; j < arg_figure.GetLength(1); j++)
                {
                    buffer_field[ i+ arg_x, j+ arg_y]=arg_figure[i,j];
                }
            }
            arg_field=buffer_field;
        }
    }
    public static void init_field(ref char[,] arg_field, char arg_symbol)
    {

        for (int i=0; i<arg_field.GetLength(0);i++)
        {
            for (int j = 0; j < arg_field.GetLength(1); j++)
            {
                arg_field[ i, j]=arg_symbol;
            }
        }
    }
}