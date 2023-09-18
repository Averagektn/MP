namespace DynProg
{
    /// <summary>
    /// Class that solves the first task of the 6'th lab
    /// </summary>
    public class Task_1 : ISolvable
    {
        /// <summary>
        /// The result table with incomes from all posible ways of interchanging the equipment
        /// </summary>
        private readonly Elem[,] table;
        private readonly int size, initialIncome, expenses;
        private int[] incomeTable;

        /// <param name="size">Size of the table. Time period when equipment is used</param>
        /// <param name="initialIncome">The income of the brand new equipment</param>
        /// <param name="expenses">How much does equipment cost</param>
        public Task_1(int size, int initialIncome, int expenses, int[] incomeTable)
        {
            Console.WriteLine();
            Console.WriteLine("TASK №1");
            Console.WriteLine();

            this.incomeTable = incomeTable;

            table = new Elem[size + 2, size];
            this.size = size;
            this.initialIncome = initialIncome;
            this.expenses = expenses;
        }

        /// <summary>
        /// Implemetation of <see cref="ISolvable"/> interface
        /// </summary>
        public void Solve()
        {
            Initialize();
            CreateTable();
            ShowTable();
            Count();
        }

        /// <summary>
        /// Initialization of the first column of the resulting table
        /// </summary>
        private void Initialize()
        {
            for (int i = 0; i < size + 1; i++)
            {
                int difference = incomeTable[i];
                if (difference <= 0)
                {
                    table[i, 0].Change = true;
                }
                else
                {
                    table[i, 0].Income = difference;
                }
            }
        }

        /// <summary>
        /// Table generation
        /// </summary>
        private void CreateTable()
        {
            for (int i = 1; i < size; i++)
            {
                int tmp = initialIncome - expenses + table[1, i - 1].Income;
                for (int j = 0; j < size + 1; j++)
                {
                    int income = incomeTable[j]  + table[j + 1, i - 1].Income;
                    if (income > tmp)
                    {
                        table[j, i].Income = income;
                    }
                    else
                    {
                        table[j, i].Income = tmp;
                        table[j, i].Change = true;
                    }

                }
            }
        }

        /// <summary>
        /// Output of the table
        /// </summary>
        private void ShowTable()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write($"  x|B{size - i}");
            }
            Console.WriteLine();
            for (int i = 0; i < size + 1; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write( "{0, 3}{1, 3}", Convert.ToInt32(table[i, j].Change), table[i, j].Income);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Counting the strategy
        /// </summary>
        private void Count()
        {
            int row = 0;
            int col = size - 1;

            Console.WriteLine();

            while (col >= 0)
            {
                Console.WriteLine(table[row, col].Income);
                if (table[row, col].Change)
                {
                    Console.WriteLine("Change on " + (size - col) + " year");
                    row = 1;
                    col--;
                }
                else
                {
                    row++;
                    col--;
                }
            }
        }
    }
    /// <summary>
    /// Element of the table
    /// </summary>
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
}