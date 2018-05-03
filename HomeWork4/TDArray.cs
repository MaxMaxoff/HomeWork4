using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/// <summary>
/// Class for Task4
/// two-dimensional array
/// </summary>
namespace HomeWork4
{
    class TDArray
    {
        /// <summary>
        /// create new array
        /// </summary>
        int[,] a;

        /// <summary>
        /// initialize new array
        /// </summary>
        /// <param name="n"></param>
        public TDArray(int n, int m)
        {
            a = new int[n, m];
        }

        /// <summary>
        /// initialize array with requested params
        /// </summary>
        /// <param name="n">size of array (rows)</param>
        /// <param name="m">size of array (columns)</param>
        /// <param name="min">min value of array element</param>
        /// <param name="max">max value of array element</param>
        public TDArray(int n, int m, int min, int max) : this(n, m)
        {
            Random random = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a[i, j] = random.Next(min, max + 1);
        }

        /// <summary>
        /// initialize array from file
        /// </summary>
        /// <param name="filename"></param>
        public TDArray(string filename)
        {            
            string line;
            int rowCount = 0;
            int i = 0;

            StreamReader streamReader = null;

            if (File.Exists(filename))
            {
                //Determine rows qty
                rowCount = File.ReadLines(filename).Count() - 1;

                try
                {
                    streamReader = new StreamReader(filename);

                    //determine cols qty
                    //read 1 line
                    line = streamReader.ReadLine();
                    //split line by "\t" symbol
                    int colCount = line.Split('\t').Length - 1;

                    //initialize array with params rowCount & colCount
                    a = new int[rowCount, colCount];
                    
                    //reset streamReader
                    streamReader.DiscardBufferedData();
                    streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

                    while (!streamReader.EndOfStream)
                    {
                        try
                        {
                            //read line
                            line = streamReader.ReadLine();
                            //split line by "\t" symbol and put data into string array
                            string[] fields = line.Split('\t');

                            //convert elements of fields array to int values and out into int array
                            for (int j = 0; j < fields.GetLength(0) - 1; j++)
                            {
                                Int32.TryParse(fields[j], out a[i, j]);
                            }
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

            
            
        }

        /// <summary>
        /// Properties for calculation sum of all elements in array
        /// </summary>
        public int Sum
        {
            get
            {
                int sum = 0;

                foreach (int element in a)
                {
                    sum += element;
                }

                return sum;
            }
        }

        /// <summary>
        /// Properties for calculation sum of elements in array bigger than number
        /// </summary>
        /// <param name="number">number for compare</param>
        /// <returns></returns>
        public int SumMoreThan(int number)
        {
            {
                int sum = 0;

                foreach (int element in a)
                {
                    if (element > number) sum += element;
                }

                return sum;
            }
        }

        /// <summary>
        /// Properties for searching min of all elements in array
        /// </summary>
        public int Min
        {
            get
            {
                int min = a[0, 0];

                foreach (int element in a)
                {
                    if (element < min) min = element;
                }

                return min;
            }
        }

        /// <summary>
        /// Properties for searching max of all elements in array
        /// </summary>
        public int Max
        {
            get
            {
                int max = a[0, 0];

                foreach (int element in a)
                {
                    if (element > max) max = element;
                }

                return max;
            }
        }

        /// <summary>
        /// Method for searching position of max element in array
        /// </summary>
        public void PositionOfMax(out int n, out int m)
        {
            {
                int max = a[0,0];
                int ii = 0;
                int jj = 0;

                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (a[i,j] > max)
                        {
                            max = a[i,j];
                            ii = i;
                            jj = j;
                        }
                    }

                n = ii;
                m = jj;
            }
        }

        /// <summary>
        /// print out array
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string t = String.Empty;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++) t = t + $"{a[i,j].ToString()}\t";

                t = t + $"\n";
            }            
            return t;
        }

        /// <summary>
        /// Write array to file
        /// </summary>
        /// <param name="filename"></param>
        public void Write(string filename)
        {
            StreamWriter streamWriter = null;
            string t = String.Empty;
            try
            {
                streamWriter = new StreamWriter(filename);

                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++) t = t + $"{a[i, j]}\t";

                    streamWriter.WriteLine($"{t}");
                    t = String.Empty;
                }

                streamWriter.WriteLine(t);

                //for (int i = 0; i < a.Length; i++)
                //    streamWriter.WriteLine(a[i]);
            }
            catch (DirectoryNotFoundException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Something goes wrong!");
            }
            finally
            {
                //if (streamWriter!=null)
                //streamWriter.Close();
                streamWriter?.Close();

            }

        }
    }
}
