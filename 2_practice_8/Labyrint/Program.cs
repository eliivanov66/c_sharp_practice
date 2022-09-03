using static Labyrint;

int[,] labirint = new int[10, 10]
{
    {1, 1, 2, 1, 1, 1, 1, 1, 1, 1},
    {1, 1, 0, 0, 1, 0, 1, 0, 0, 1},
    {1, 1, 1, 0, 1, 0, 1, 0, 1, 1},
    {1, 0, 0, 0, 0, 0, 1, 0, 0, 1},
    {1, 0, 1, 0, 1, 1, 1, 1, 0, 1},
    {1, 0, 1, 0, 0, 0, 0, 0, 1, 1},
    {1, 1, 1, 1, 1, 1, 1, 0, 1, 1},
    {1, 0, 0, 0, 1, 0, 0, 0, 0, 1},
    {1, 0, 1, 0, 0, 0, 1, 0, 0, 1},
    {1, 3, 1, 1, 1, 1, 1, 1, 1, 1}
};

//Library.TwoDArrayPrint(labirint);

int startX = 9;
int startY = 1;

static void PrintMatrix2DBeautifully(int[,] matrix) //Вывод двумерного массива (матрицы) в консоль
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] == 1) Console.Write("х ");
            if (matrix[i, j] == 0) Console.Write("  ");
            if (matrix[i, j] == 2) Console.Write("В ");
            if(matrix[i, j] == 3) Console.Write("K ");
            if (matrix[i, j] == 4) Console.Write("- ");

        }
        Console.WriteLine();
    }
    Console.WriteLine();
}
PrintMatrix2DBeautifully(labirint);
int[,] bufferLabirint = new int[labirint.GetLength(0), labirint.GetLength(1)];
for (int i = 0; i < labirint.GetLength(0); i++)
{
    for (int j = 0; j < labirint.GetLength(1); j++)
    {
        bufferLabirint[i, j] = labirint[i, j];
    }
}


(int[,], int, int) Movment(int[,] matrix, int xPos, int yPos)
{
    
    int xPosBuf = xPos;
    int yPosBuf = yPos;

    //Движение вверх i - 1 вниз i + 1 влево y - 1 вправо y + 1
    if (matrix[xPosBuf, yPosBuf] != 2)
    {
        if ((matrix[xPosBuf - 1, yPosBuf] != 1 && matrix[xPosBuf - 1, yPosBuf] != 4) && (xPosBuf < matrix.GetLength(0) && xPosBuf > 0))
        {
            bufferLabirint[xPosBuf - 1, yPosBuf] = 3;
            bufferLabirint[xPosBuf, yPosBuf] = 4;
            xPosBuf--;
            //PrintMatrix2DBeautifully(bufferLabirint);
            Movment(bufferLabirint, xPosBuf, yPosBuf);
        }
        else if ((matrix[xPosBuf, yPosBuf + 1] != 1  && matrix[xPosBuf, yPosBuf + 1] != 4) && (yPosBuf < matrix.GetLength(1) && yPosBuf > 0))
        {
            bufferLabirint[xPosBuf, yPosBuf + 1] = 3;
            bufferLabirint[xPosBuf, yPosBuf] = 4;
            yPosBuf++;
            //PrintMatrix2DBeautifully(bufferLabirint);
            Movment(bufferLabirint, xPosBuf, yPosBuf);
        }
        else if ((matrix[xPosBuf + 1, yPosBuf] != 1 && matrix[xPosBuf + 1, yPosBuf] != 4) && (xPosBuf < matrix.GetLength(0) && xPosBuf > 0))
        {
            bufferLabirint[xPosBuf + 1, yPosBuf] = 3;
            bufferLabirint[xPosBuf, yPosBuf] = 4;
            xPosBuf++;
            //PrintMatrix2DBeautifully(bufferLabirint);
            Movment(bufferLabirint, xPosBuf, yPosBuf);
        }
        else if ((matrix[xPosBuf, yPosBuf - 1] != 1 && matrix[xPosBuf, yPosBuf - 1] != 4) && (yPosBuf < matrix.GetLength(1) && yPosBuf > 0))
        {
            bufferLabirint[xPosBuf, yPosBuf - 1] = 3;
            bufferLabirint[xPosBuf, yPosBuf] = 4;
            yPosBuf--;
            //PrintMatrix2DBeautifully(bufferLabirint);
            Movment(bufferLabirint, xPosBuf, yPosBuf);
        }
    }
    else
    {
        Console.WriteLine("ПОБЕДА!\n");
    }
    return (bufferLabirint, xPosBuf, yPosBuf);
}

(labirint, startX, startY) = Movment(labirint, startX, startY);
PrintMatrix2DBeautifully(labirint);

Console.WriteLine($"{startX}, {startY}");