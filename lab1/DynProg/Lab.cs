using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynProg
{
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
    public class Lab
    {
        private Elem[,] table;
        private int size, initialIncome, expenses;
        public Lab(int size, int initialIncome, int expenses)
        {
            table = new Elem[size + 2, size];
            this.size = size;
            this.initialIncome = initialIncome;
            this.expenses = expenses;
        }
        public void Solve()
        {
            Initialize();
            CreateTable();
            ShowTable();
            Count();
        }

        private void Initialize()
        {
            for (int i = 0; i < size + 1; i++)
            {
                int difference = initialIncome - i;
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

        private void ShowTable()
        {
            for (int i = 0; i < size + 1; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(Convert.ToInt32(table[i, j].Change) + " " + table[i, j].Income + "   ");
                }
                Console.WriteLine();
            }
        }

        private void CreateTable()
        {
            for (int i = 1; i < size; i++)
            {
                int tmp = initialIncome - expenses + table[1, i - 1].Income;
                for (int j = 0; j < size + 1; j++)
                {
                    int income = initialIncome - j + table[j + 1, i - 1].Income;
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

        private void Count()
        {
            int row = 0;
            int col = size - 1;
            while (col >= 0)
            {
                Console.WriteLine(table[row, col].Income);
                if (table[row, col].Change)
                {
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
}
