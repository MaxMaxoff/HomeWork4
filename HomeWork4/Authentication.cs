using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SupportLibrary;

/// <summary>
/// Class for Task3
/// Authentication
/// </summary>
namespace HomeWork4
{
    /// <summary>
    /// Class for Task3
    /// </summary>
    class Authentication
    {
        /// <summary>
        /// create new array
        /// </summary>
        string[,] a;

        /// <summary>
        /// initialize new array
        /// </summary>
        /// <param name="n"></param>
        public Authentication(int n)
        {
            a = new string[n,2];            
        }

        /// <summary>
        /// Initialize and fill arrays from username:password file
        /// </summary>
        /// <param name="n">lines in file</param>
        /// <param name="filename">file name</param>
        public Authentication(int n, string filename) : this (n)
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
                        string[] fields = line.Split(':');
                        a[i,0] = fields[0];
                        a[i,1] = fields[1];
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
        /// Authentication method
        /// </summary>
        /// <param name="records">array of username:password records</param>
        /// <param name="maxcount">max attempts</param>
        /// <returns></returns>
        public bool Authenticate(int maxcount)
        {
            int count = 0;

            do
            {
                count++;

                //get username
                string username = SupportMethods.RequestString("Please type your Username: ");

                //get password
                string password = SupportMethods.RequestString("Please type your password: ");

                //check if username & password are in the array of usernames & passwords
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (a[i,0] == username && a[i,1] == password)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        return true;
                    }
                }

                Console.WriteLine("Wrong username or password!");
                Console.WriteLine($"{maxcount - count} attempts remaining!");
            } while (count < maxcount);

            return false;
        }

        /// <summary>
        /// print out array
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string t = String.Empty;

            for (int i = 0; i < a.GetLength(0); i++)
                t = t + $"{a[i,0].ToString()}:::{a[i,1].ToString()}\n";
            return t;
        }
    }
}
