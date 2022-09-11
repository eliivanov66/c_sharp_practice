public class My_Snake
{
    public static void print_figure(char[,] input)
    {
        Console.Clear();
        for (int i=0; i<input.GetLength(0); i++)
        {
            for (int j=0; j<input.GetLength(1); j++)
            {
                Console.Write($"{input[i,j]}");   
            }
            Console.WriteLine();
        }
    }
    public static char[,] place_figures(char[,] arg_field, char[,] arg_figure, int arg_x, int arg_y)
    {
        //Console.Clear();
        //буфурное поле
        char[,] buffer_field=new char[arg_field.GetLength(0), arg_field.GetLength(1)];
        for (int i=0; i<arg_field.GetLength(0);i++)
        {
            for (int j = 0; j < arg_field.GetLength(1); j++)
            {
                buffer_field[ i, j]=arg_field[i,j];
            }
        }
        //фигура меньше поля, всегда
        if ( (arg_field.GetLength(0)>=arg_figure.GetLength(0)+arg_y) &&
             (arg_field.GetLength(1)>=arg_figure.GetLength(1)+arg_x))
        {
            for (int i=0; i<arg_figure.GetLength(0);i++)
            {
                for (int j = 0; j < arg_figure.GetLength(1); j++)
                {
                    if (buffer_field[i+ arg_y,j+ arg_x]!=' ') 
                        continue;
                    else
                        buffer_field[ i+ arg_y, j+ arg_x]=arg_figure[i,j];
                }
            }
        }
        return buffer_field;
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