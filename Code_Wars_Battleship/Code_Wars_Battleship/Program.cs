using System.Data.Common;

int[,] field = new int[10, 10]
                     {{1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                      {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                      {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                      {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
Console.WriteLine(ValidateBattlefield(field));
Console.WriteLine(DiagonalValid(field, 0, 0));

static bool ValidateBattlefield(int[,] field)
{
    int rows = field.GetUpperBound(0) + 1;
    int columns = field.GetUpperBound(1) + 1;
    int count = 0;
    for(int i=0; i < rows; i++)
    {
        if (!RowValid(field, i)) return false;
        for(int j=0; j < columns; j++)
        {
            if (!ColumnValid(field, j)) return false;
            if (field[i, j] == 1)
            {
                count++;
                if (!DiagonalValid(field, i, j)) { Console.WriteLine($"{i} {j}"); return false; }
            }
        }
    }
    if (count != 20) return false;
    return true;
}
static bool ColumnValid (int[,] field, int column)
{
    int max = 0;
    for (int i = 0; i < field.GetLength(1); i++)
    {
        if(max>4) return false;
        if(field[i, column]==0)
        {
            max = 0;
        }
        max++;
    }
    return true;
}
static bool RowValid(int[,] field, int row)
{
    int max = 0;
    for (int i = 0; i < field.GetLength(0); i++)
    {
        if (max > 4) return false;
        if (field[row, i] == 0)
        {
            max = 0;
        }
        max++;
    }
    return true;
}

static bool DiagonalValid(int[,] field,int row, int column)
{
    if(row == 0 && column == 0) //левый верх угол
    {
        if (field[row + 1, column + 1] == 1) return false;
        return true;
    }
    if (row == field.GetLength(0) && column == 0) //левый низ угол
    {
        if (field[row - 1, column + 1] == 1) return false;
        return true;
    }
    if (row == 0 && column == field.GetLength(1)) //правый верх угол
    {
        if (field[row + 1, column - 1] == 1) return false;
        return true;
    }
    if (row == field.GetLength(0) && column == field.GetLength(1)) //правый низ угол
    {
        if (field[row - 1, column - 1] == 1) return false;
        return true;
    }
    if (row == 0 && column != 0) //верхняя граница
    {
        if (field[row + 1, column + 1] == 1) return false;
        if (field[row + 1, column - 1] == 1) return false;
        return true;
    }
    if(row !=0 && column == 0) //левая граница
    {
        if (field[row + 1, column + 1] == 1) return false;
        if (field[row - 1, column + 1] == 1) return false;
        return true;
    }
    if(row == field.GetLength(0) && column != field.GetLength(1)) //нижняя граница
    {
        if (field[row - 1, column + 1] == 1) return false;
        if (field[row - 1, column - 1] == 1) return false;
        return true;
    }
    if(row != field.GetLength(0) && column == field.GetLength(1)) //правая граница
    {
        if (field[row - 1, column - 1] == 1) return false;
        if (field[row + 1, column - 1] == 1) return false;
        return true;
    }
    //иначе
    if (field[row - 1, column - 1] == 1) return false;
    if (field[row - 1, column + 1] == 1) return false;
    if (field[row + 1, column + 1] == 1) return false;
    if (field[row + 1, column - 1] == 1) return false;
    return true;
}
