using DynProg;

/*int time = 11, initialIncome = 11, replacementCost = 11;
Solvable lab = new Task_1(time, initialIncome, replacementCost);
lab.Solve();*/

/*var arr = new int[5, 4] 
{ 
    { 15, 12, 17, 13 },
    { 32, 30, 33, 31 },
    { 39, 38, 40, 37 },
    { 46, 45, 47, 44 },
    { 52, 54, 60, 63 } 
};*/
var arr = new int[6, 3]
{
    { 0,  0,  0  },
    { 10, 12, 11 },
    { 31, 26, 36 },
    { 42, 36, 45 },
    { 62, 54, 60 },
    { 76, 78, 77 }
};

var res = new int[6, 6];

for (int i = 0; i < 6; i++)
{
    for (int j = 0; j <= i; j ++)
    {
        res[i, j] = arr[i - j, 0] + arr[j, 1];
    }
}

for (int i = 0; i < 6; i++)
{
    for (int j = 0; j < 6; j++)
    {
        Console.Write(res[i, j] + " ");
    }
    Console.WriteLine();
}

// выделить максимумы из каждой строки массива. Они и будут оптимальными.
var res1 = new int[6, 6];

for (int i = 0; i < 6; i++)
{
    for (int j = 0; j <= i; j++)
    {
        res1[i, j] = arr[i - j, 0] + arr[j, 2];
    }
}

for (int i = 0; i < 6; i++)
{
    for (int j = 0; j < 6; j++)
    {
        Console.Write(res[i, j] + " ");
    }
    Console.WriteLine();
}

/*lab = new Task_2();
lab.Solve();*/