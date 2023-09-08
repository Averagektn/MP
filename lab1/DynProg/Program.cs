int time = 12;
int replacementCost = 10;
int initialIncome = 10;
Elem[,] values = new Elem[time, time];


for (int i = 0; i < time; i++)
{
    values[i, 0].Income = initialIncome - i;

    for (int j = 1; j < time; j++)
    {
        values[i, j].Income = values[i, j - 1].Income + initialIncome - j;
        values[i, j].Change = values[i, 0].Income <= replacementCost - initialIncome + values[0, 0].Income - 1;
        Console.Write(values[i, 0].Income + "<->" + (replacementCost - initialIncome + values[0, 0].Income - 1) + " ");
    }
    Console.WriteLine();
}



Show(values, time);



void Show(Elem[,] arr, int size)
{
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            Console.Write(arr[i, j].Income + " " + arr[i, j].Change + "   ");
        }
        Console.WriteLine();
    }

}

public struct Elem
{
    public bool Change;
    public int Income;
    public Elem()
    {
        Change = false;
        Income = 0;
    }
}