using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Class for Task2
/// </summary>
namespace HomeWork4
{
    /// <summary>
    /// Class for Task2
    /// </summary>
    class ArrayT2
    {
        /// <summary>
        /// create new array
        /// </summary>
        int[] a;

        /// <summary>
        /// initialize array with tests values
        /// </summary>
        public ArrayT2()
        {
            a = new int[5] { 1, 2, 3, 4, 5 };
        }

        /// <summary>
        /// initialize empty array
        /// </summary>
        public ArrayT2(int n)
        {
            a = new int[n];
        }

        /// <summary>
        /// initialize array with requested params
        /// </summary>
        /// <param name="n">size of array</param>
        /// <param name="min">min value of array element</param>
        /// <param name="max">max value of array element</param>
        public ArrayT2(int n, int startnum, int step) : this(n)
        {
            int number = startnum;

            for (int i = 0; i < n; i++)
            {
                a[i] = number;
                number += step;
            }                
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
        /// Properties for calculation sum of all elements in array
        /// </summary>
        public int Sum
        {
            get
            {
                int sum = 0;

                //for (int i = 0; i <= a.Length-1; i++)
                foreach (int element in a)
                {
                    sum += element;
                }

                return sum;
            }
        }

        /// <summary>
        /// Method for multiply each elements of array to number
        /// </summary>
        /// <param name="arr">array of int elements</param>
        /// <param name="number">multiplicator</param>
        public void Multi(int number)
        {
            for (int i = 0; i <= a.Length - 1; i++)
            {
                a[i] *= number;
            }
        }

        /// <summary>
        /// Properties for calculation quantity of max elements in array
        /// </summary>
        public int MaxCount
        {
            get
            {
                int qty = 0;
                int max = a[0];

                //for (int i = 0; i <= a.Length-1; i++)
                foreach (int element in a)
                {
                    if (element > max)
                    {
                        max = element;
                        qty = 1;                        
                    }
                    if (element == max)
                    {
                        qty++;
                    }
                }

                return qty;
            }
        }
    }
}
