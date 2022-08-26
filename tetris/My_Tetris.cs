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
        int size_x=arg_figure.GetLength(1); //4 -- 3
        int size_y=arg_figure.GetLength(0); //3 -- 4

        char[,] result_figure=new char[size_x,size_y]; //3x4
        init_field(ref result_figure, '0');

        int rotate_count=arg_angle/90;
        if (arg_direction)
        {
            for (int k=0; k<rotate_count; k++)
            { 
                //поворот на 90 по часовой стрелке
                for (int i = 0; i < arg_figure.GetLength(0); i++) //4x3
                {
                    for (int j = 0; j < arg_figure.GetLength(1); j++) //4x3
                    {
                        result_figure[j,size_y-i - 1]=
                        arg_figure[i,j];
                    }
                }
            }
        }
        else
        {
            for (int k=0; k<rotate_count; k++)
            {
                //поворот на 90 против часовой стрелке
                for (int i = 0; i < arg_figure.GetLength(0); i++)
                {
                    for (int j = 0; j < arg_figure.GetLength(1); j++)
                    {
                        result_figure[size_x-j - 1 ,i]=
                        result_figure[i,j];
                    }
                }
            }
        }
        arg_figure=result_figure;

    }
    public static char[,] place_figures(char[,] arg_field, char[,] arg_figure, int arg_x, int arg_y)
    {
        Console.Clear();
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
        if ( (arg_field.GetLength(0)>=arg_figure.GetLength(0)+arg_x) &&
             (arg_field.GetLength(1)>=arg_figure.GetLength(1)+arg_y))
        {
            for (int i=0; i<arg_figure.GetLength(0);i++)
            {
                for (int j = 0; j < arg_figure.GetLength(1); j++)
                {
                    if (buffer_field[i+ arg_x,j+ arg_y]!='0') 
                        continue;
                    else
                        buffer_field[ i+ arg_x, j+ arg_y]=arg_figure[i,j];
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
    public static bool colision_field(char[,] arg_field, char[,] arg_figure, int arg_x, int arg_y)
    {
        bool result=false;
        //фигура меньше поля, всегда
        if ( (arg_field.GetLength(0)>=arg_figure.GetLength(0)+arg_x) &&
             (arg_field.GetLength(1)>=arg_figure.GetLength(1)+arg_y))
        {
            for (int i = 0; i < arg_figure.GetLength(0); i++)
            {
                for (int j = 0; j < arg_figure.GetLength(1); j++)
                {
                    if ((arg_field[i + arg_x, j + arg_y]!='0') && (arg_field[i + arg_x, j + arg_y]==arg_figure[i,j]))  
                    {    
                        result=true;
                    }
                }
            }
        }
        return result;
    }
    public static (bool,int) line_analyse(char[,] arg_field)
    {
        bool line=false;
        int line_number=0;
        for (int i = 0; i < arg_field.GetLength(0); i++)
        {
            if (line) break;
            for (int j=0; j<arg_field.GetLength(1); j++)
            {
                if (arg_field[i,j]!='0') //просмотр значений на последней строке
                {
                    line=true;
                    line_number=i;
                }
                else
                {
                    line=false;
                    line_number=0;
                    break;
                }
            }
        }
        return (line,line_number);
    }

    public static char[,] remove_line(char[,] arg_field, int arg_line_number)
    {
        int m=0;
        char[,] buffer_field=new char[arg_field.GetLength(0), arg_field.GetLength(1)];
        for (int j=0; j < arg_field.GetLength(1); j++)
        {
            buffer_field[0,j]='0';
        }
        for (int i = 1; i < arg_field.GetLength(0); i++) //i это строка
        {
            if (i<=arg_line_number) m=-1; else m=0;
            for (int j = 0; j < arg_field.GetLength(1); j++)
            {
                buffer_field[i,j]=arg_field[i + m, j];
            }
        }
        return buffer_field;
    }
}