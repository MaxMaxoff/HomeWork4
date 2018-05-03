using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Class for Task1
/// </summary>
namespace HomeWork4
{
    /// <summary>
    /// Class for Task1
    /// </summary>
    class MyArray
    {
        /// <summary>
        /// create new array
        /// </summary>
        int[] a;

        /// <summary>
        /// initialize array with tests values
        /// </summary>
        public MyArray()
        {
            a = new int[5] { 6, 2, 9, -3, 6 };
        }

        /// <summary>
        /// initialize empty array
        /// </summary>
        public MyArray(int n)
        {
            a = new int[n];
        }

        /// <summary>
        /// initialize array with requested params
        /// </summary>
        /// <param name="n">size of array</param>
        /// <param name="min">min value of array element</param>
        /// <param name="max">max value of array element</param>
        public MyArray(int n, int min, int max) : this (n)
        {
            Random random = new Random();
            for (int i = 0; i < n; i++)
                a[i] = random.Next(min, max + 1);
        }

        /// <summary>
        /// prepare string for print out array elements
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string t = String.Empty;
            for (int i = 0; i < a.Length; i++)
                t = t + a[i].ToString() + " ";
            return t;
        }

        /// <summary>
        /// Properties for calculation pairs where any element of the pair can be divided by 3 without remainder.
        /// except 0, as we know 0 can be divided by any number without remainder
        /// </summary>
        public int PairQty
        {
            get
            {
                int pairqty = 0;

                for (int i = 0; i < a.Length-1; i++)
                {
                    if ((a[i] % 3 == 0 && a[i] != 0) || (a[i + 1] % 3 == 0 && a[i + 1] != 0))
                    {
                        pairqty++;
                        Console.WriteLine($"{a[i]}:{a[i + 1]}");
                    }
                }

                return pairqty;
            }
        }
    }
}
