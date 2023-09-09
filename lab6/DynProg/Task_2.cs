namespace DynProg
{
    /// <summary>
    /// Class that solves the second task of the 6'th lab
    /// </summary>
    public class Task_2 : ISolvable
    {
        private readonly int[,] incomeTable, industriesInvestitions;
        private readonly int[] f1, f2;
        private readonly int interprisesNum, budgetDiscreteness, steps;
        private int currCol;

        /// <summary>
        /// Generates solution for the task
        /// </summary>
        /// <param name="incomeTable">Inital table with each industry income deoending on the invesments</param>
        /// <param name="interprisesNum">The amount of interprises</param>
        /// <param name="budget">Investor's budget</param>
        /// <param name="budgetDiscreteness">Discreteness of investor's budget</param>
        public Task_2(int[,] incomeTable, int interprisesNum, int budget, int budgetDiscreteness)
        {
            Console.WriteLine();
            Console.WriteLine("TASK №2");
            Console.WriteLine();

            steps = budget / budgetDiscreteness + 1;

            this.incomeTable = incomeTable;
            this.interprisesNum = interprisesNum;
            this.budgetDiscreteness = budgetDiscreteness;
            f1 = new int[steps];
            f2 = new int[steps];
            currCol = 2;
            industriesInvestitions = new int[steps, interprisesNum];
        }

        /// <summary>
        /// Implemetation of <see cref="ISolvable"/> interface
        /// </summary>
        public void Solve()
        {
            InitializeFs();
            var table = CountTable();

            Count(table);
            ShowResult();
        }

        /// <summary>
        /// Prints result to console
        /// </summary>
        private void ShowResult()
        { 
            for (int i = 1; i < steps; i++)
            {
                int tmp = i * budgetDiscreteness;
                Console.WriteLine("Budget: " + tmp);
                for (int j = interprisesNum - 1; j >= 1; j--)
                {
                    Console.WriteLine("No {0} investments {1}", j + 1, industriesInvestitions[tmp / budgetDiscreteness, j] * budgetDiscreteness);
                    tmp -= industriesInvestitions[tmp / budgetDiscreteness, j] * budgetDiscreteness;
                }
                Console.WriteLine("No 1 investments {0}", tmp);
            }
        }

        /// <summary>
        /// Counts the investition strategy
        /// </summary>
        /// <param name="arr"></param>
        private void Count(int[,] arr)
        {
            for (int i = currCol; i < interprisesNum; i++)
            {
                UpdateF1(arr);
                UpdateF2();
                arr = CountTable();
            }
            UpdateF1(arr);
        }

        /// <summary>
        /// Initializes tables with start values
        /// </summary>
        private void InitializeFs()
        {
            for (int i = 0; i < steps; i++)
            {
                f1[i] = incomeTable[i, 0];
                f2[i] = incomeTable[i, 1];
            }
        }

        /// <summary>
        /// Counts the incomes of every investition
        /// </summary>
        /// <returns>Returns the table of possible incomes</returns>
        private int[,] CountTable()
        {
            var res = new int[steps, steps];

            for (int i = 0; i < steps; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    res[i, j] = f1[i - j] + f2[j];
                }
            }
            ShowCurrentTable(res);

            return res;
        }

        /// <summary>
        /// Find the best income for every investment
        /// </summary>
        /// <param name="res">Income table</param>
        private void UpdateF1(int[,] res)
        {
            for (int i = 0; i < steps; i++)
            {
                int tmp = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (res[i, tmp] < res[i, j])
                    {
                        tmp = j;
                    }
                }
                f1[i] = res[i, tmp];
                industriesInvestitions[i, currCol - 1] = tmp;
            }
            foreach (var elem in f1)
            {
                Console.WriteLine(elem);
            }
        }

        /// <summary>
        /// Takes the new column of <see cref="incomeTable"/>
        /// </summary>
        private void UpdateF2()
        {
            for (int i = 0; i < 6; i++)
            {
                f2[i] = incomeTable[i, currCol];
            }
            currCol++;
        }

        /// <summary>
        /// Show the current table condition
        /// </summary>
        /// <param name="arr">Current table</param>
        private void ShowCurrentTable(int[,] arr)
        {
            for (int i = 0; i < steps; i++)
            {
                for (int j = 0; j < steps; j++)
                {
                    Console.Write("{0, 5}", arr[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}