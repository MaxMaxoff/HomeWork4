using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/// <summary>
/// Class for Task 6
/// Trust Game
/// </summary>
namespace HomeWork4
{
    /// <summary>
    /// Class for Trust Game
    /// </summary>
    class TrustGame
    {
        /// <summary>
        /// Steps in games
        /// </summary>
        int steps;

        /// <summary>
        /// Points in games
        /// </summary>
        int points;

        /// <summary>
        /// Array of question
        /// </summary>
        string[,] a;

        /// <summary>
        /// Properties return steps value
        /// </summary>
        public int Steps
        {
            get
            {
                return steps;
            }
        }

        /// <summary>
        /// Properties return points value
        /// </summary>
        public int Points
        {
            get
            {
                return points;
            }
        }

        /// <summary>
        /// initialize new array
        /// </summary>
        /// <param name="n"></param>
        public TrustGame(int n)
        {
            a = new string[n, 2];
            steps = 0;
            points = 0;
        }

        /// <summary>
        /// Initialize and fill array from game_trust.csv file
        /// </summary>
        /// <param name="n">lines in file</param>
        /// <param name="filename">file name</param>
        public TrustGame(int n, string filename) : this(n)
        {
            int i = 0;
            string line;

            StreamReader streamReader = null;

            try
            {
                streamReader = new StreamReader(filename);

                while (!streamReader.EndOfStream)
                {
                    try
                    {
                        line = streamReader.ReadLine();
                        string[] fields = line.Split(';');
                        a[i, 0] = fields[0];
                        a[i, 1] = fields[1];
                    }
                    catch
                    {

                    }
                    i++;
                }
            }
            catch
            {
                Console.WriteLine($"Something goes wrong! Please check the file {filename}");
            }
            finally
            {
                streamReader?.Close();
            }


        }

        /// <summary>
        /// Method Get Question Number
        /// </summary>
        /// <param name="min">min question number</param>
        /// <param name="max">max question number</param>
        /// <returns></returns>
        public int GetQuestionNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        /// <summary>
        /// Method GetQuestion
        /// </summary>
        /// <param name="questionNumber">number of the question</param>
        /// <returns>string with question</returns>
        public string GetQuestion(int questionNumber)
        {
            return a[questionNumber, 0];
        }

        /// <summary>
        /// Method GetAnswer
        /// </summary>
        /// <param name="questionNumber">number of the question</param>
        /// <returns>true or false</returns>
        public bool GetAnswer(int questionNumber)
        {
            if (a[questionNumber, 1] == "1") { return true; }
            else { return false; }
        }

        /// <summary>
        /// Method Correct Answer
        /// </summary>
        /// <returns>points</returns>
        public void CorrectAnswer()
        {
            points++;
            steps++;
        }

        /// <summary>
        /// Method Wrong Answer
        /// </summary>
        /// <returns>points</returns>
        public void WrongAnswer()
        {
            steps++;
        }

        /// <summary>
        /// print out array
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string t = String.Empty;

            for (int i = 0; i < a.GetLength(0); i++)
                t = t + $"*** {a[i, 0].ToString()};{a[i, 1].ToString()}\n";
            return t;
        }

    }
}
