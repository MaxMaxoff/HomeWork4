using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Class for Task 5
/// Doubler
/// </summary>
namespace HomeWork4
{
    /// <summary>
    /// Class Doubler
    /// </summary>
    class Doubler
    {
        /// <summary>
        /// Current value
        /// </summary>
        int current;

        /// <summary>
        /// Target value
        /// </summary>
        int finish;

        /// <summary>
        /// Steps
        /// </summary>
        int steps;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="finish"></param>
        public Doubler()
        {
            Random random = new Random();
            finish = random.Next(2,101);
            current = 1;
            steps = 0;
        }

        /// <summary>
        /// Properties Current, return current value
        /// </summary>
        public int Current
        {
            get
            {
                return current;
            }
        }

        /// <summary>
        /// Properties Finish, return finish value
        /// </summary>
        public int Finish
        {
            get
            {
                return finish;
            }
        }

        /// <summary>
        /// Properties Steps, return steps value
        /// </summary>
        public int Steps
        {
            get
            {
                return steps;
            }
        }

        /// <summary>
        /// Increment by 1
        /// </summary>
        public int Increment()
        {
            current++;
            steps++;
            return current;

        }

        /// <summary>
        /// Doubling
        /// </summary>
        public int Doubling()
        {

            current *= 2;
            steps++;
            return current;

        }

        /// <summary>
        /// Reset to default (1)
        /// </summary>
        public int Reset()
        {
            current = 1;
            steps++;
            return current;
        }
    }
}
