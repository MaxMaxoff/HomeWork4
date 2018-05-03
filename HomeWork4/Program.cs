using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportLibrary;
using System.IO;

/// <summary>
/// Максим Торопов
/// Ярославль
/// Домашняя работа 4 урока
/// </summary>
namespace HomeWork4
{
    class Program
    {
        /// <summary>
        /// Задание 1.
        /// Дан целочисленный массив из 20 элементов.
        /// Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
        /// Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3.
        /// В данной задаче под парой подразумевается два подряд идущих элемента массива.
        /// Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.
        /// </summary>
        static void Task1()
        {
            //consts according to task
            const int min = -10;
            const int max = 10;
            const int arrsize = 20;

            //Clear console and print info regarding current task
            SupportMethods.PrepareConsoleForHomeTask("Задание 1.\n" +
                "Массив из 20 элементов, подсчитать количество пар, в которых хотя бы 1 член делится на 3 без остатка.");
            
            //Create new array and initialize according to const parameters
            MyArray arr = new MyArray(arrsize, min, max);
                        
            //Print out current array
            SupportMethods.Pause($"Current array {arr.ToString()}");

            //Print out result of the task
            SupportMethods.Pause($"Total: {arr.PairQty}");
        }

        /// <summary>
        /// Задание 2.
        /// а) Дописать класс для работы с одномерным массивом.
        /// Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом.
        /// Создать свойство Sum, которые возвращают сумму элементов массива,
        /// метод Inverse, меняющий знаки у всех элементов массива,
        /// Метод Multi, умножающий каждый элемент массива на определенное число,
        /// свойство MaxCount, возвращающее количество максимальных элементов.
        /// В Main продемонстрировать работу класса.
        /// 
        /// б)*Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
        /// </summary>
        static void Task2()
        {            
            //Clear console and print info regarding current task
            SupportMethods.PrepareConsoleForHomeTask("Задание 2.");

            //Request array size
            int arrsize = SupportMethods.RequestIntValue("Please input array size");

            //Request first element
            int first = SupportMethods.RequestIntValue("Please input first element of array");

            //request step for next elements
            int step = SupportMethods.RequestIntValue("Please input step for each next elements");

            ArrayT2 arr = new ArrayT2(arrsize, first, step);

            //Print out current array
            SupportMethods.Pause($"Current array {arr.ToString()}");

            //Print out sum of elements in current array
            SupportMethods.Pause($"Sum of elements of current array is {arr.Sum}");

            //inversion of int array
            arr.Multi(-1);
            //Print out sum of elements in current array
            SupportMethods.Pause($"Current array after inversion {arr.ToString()}");

            //request multiplicator
            int multi = SupportMethods.RequestIntValue("Please input multiplicator");

            //multiplication of int aaray
            arr.Multi(multi);
            //Print out sum of elements in current array
            SupportMethods.Pause($"Current array after multiplication {arr.ToString()}");

            //Print out quantity of max elements in current array
            SupportMethods.Pause($"Quantity of Max elements of current array is {arr.MaxCount}");
        }

        /// <summary>
        /// Задание 3.
        /// Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив.
        /// </summary>
        static void Task3()
        {
            //Clear console and print info regarding current task
            SupportMethods.PrepareConsoleForHomeTask("Задание 3.");

            const string filename = "passwd.txt";
            int lineCount = 0;
            int maxcount = 3;

            Authentication records;

            //fill array
            if (File.Exists(filename))
            {
                //get lines qty from file
                lineCount = File.ReadLines(filename).Count();

                //initialize new array with lines from file
                records = new Authentication(lineCount, filename);

                //print out array
                //SupportMethods.Pause($"{records.ToString()}");

                if (records.Authenticate(maxcount))
                {
                    SupportMethods.Pause("Authentication successfull");
                } else
                {
                    SupportMethods.Pause("Authentication failed!");
                }   
            }
            else
            {
                Console.WriteLine($"{filename} not Found");
            }
        }

        /// <summary>
        /// Задание 4.
        /// *а) Реализовать класс для работы с двумерным массивом.
        /// Реализовать конструктор, заполняющий массив случайными числами.
        /// Создать методы, которые возвращают сумму всех элементов массива,
        /// сумму всех элементов массива больше заданного,
        /// свойство, возвращающее минимальный элемент массива,
        /// свойство, возвращающее максимальный элемент массива,
        /// метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out)
        /// 
        /// **б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
        /// </summary>
        static void Task4()
        {
            const string filename = "array.txt";

            //Clear console and print info regarding current task
            SupportMethods.PrepareConsoleForHomeTask("Задание 4.");

            TDArray arr;

            //How to fill array, using random or fill from file?
            if (SupportMethods.RequestIntValue("1 - Fill array by default using random values\n" +
                "any other value - Fill from file") == 1)
            {
                //Request array size
                int rows = SupportMethods.RequestIntValue("Please input array size (rows)");
                int cols = SupportMethods.RequestIntValue("Please input array size (columns)");


                //Initialization of empty array with rows and cols params
                //arr = new TDArray(rows, cols);

                //Initialization of array with rows and cols params and random values of each elements in array
                arr = new TDArray(rows, cols, 0, 100);

            }
            else
            {
                //fill array from file
                arr = new TDArray(filename);
            }

            //print out current array
            SupportMethods.Pause($"Current array:\n {arr.ToString()}");

            //print out sum of all elements in current array
            SupportMethods.Pause($"Sum of all elements in current array is {arr.Sum}");

            //Request max number
            int maxnumber = SupportMethods.RequestIntValue("Please input max number");

            //print out sum of elements which is more than maxnumber in current array
            SupportMethods.Pause($"Sum of all elements which are more than {maxnumber} in current array is {arr.SumMoreThan(maxnumber)}");

            // print out min element
            SupportMethods.Pause($"Min element in array is {arr.Min}");

            // print out max element
            SupportMethods.Pause($"Max element in array is {arr.Max}");

            //determine position of max element
            int n = 0;
            int m = 0;
            arr.PositionOfMax(out n, out m);
            //print out position of max element
            SupportMethods.Pause($"Number of the first Max element in array is row:{n+1} column:{m+1}");

            //save or not save
            if (SupportMethods.RequestIntValue("1 - Save array to file\n" +
                "any other value - Do not save array to file") == 1)
            {
                arr.Write(filename);
            }
            
        }

        /// <summary>
        /// Задание 5.
        /// **Существует алгоритмическая игра “Удвоитель”.
        /// В этой игре человеку предлагается какое-то число, а человек должен, управляя роботом “Удвоитель”, достичь этого числа за минимальное число шагов.
        /// Робот умеет выполнять несколько команд: увеличить число на 1, умножить число на 2 и сбросить число до 1.
        /// Начальное значение удвоителя равно 1.
        /// 
        /// Реализовать класс “Удвоитель”.
        /// Класс хранит в себе поле current - текущее значение,
        /// finish - число, которого нужно достичь,
        /// конструктор, в котором задается конечное число.
        /// 
        /// Методы: увеличить число на 1,
        /// увеличить число в два раза,
        /// сброс текущего до 1,
        /// 
        /// свойство Current, которое возвращает текущее значение,
        /// свойство Finish, которое возвращает конечное значение.
        /// 
        /// Создать с помощью этого класса игру, в которой компьютер загадывает число,
        /// а человек.выбирая из меню на экране, отдает команды удвоителю и старается получить это число за наименьшее число ходов.
        /// Если человек получает число больше положенного, игра прекращается.
        /// </summary>
        static void Task5()
        {
            //Clear console and print info regarding current task
            SupportMethods.PrepareConsoleForHomeTask($"Задание 5. Игра \"Удвоитель\"\n");
            Doubler game = new Doubler();
                        
            do
            {
                SupportMethods.PrepareConsoleForHomeTask("Задание 5. Игра \"Удвоитель\"\n" +
                    $"Загаданное число: {game.Finish}\n" +
                    $"Число у игрока: {game.Current}\n" +
                    $"Шагов: {game.Steps}\n\n" +
                    "Список команд:\n" +
                    "1 - увеличить число на 1\n" +
                  "2 - умножить число на 2\n" +
                  "3 - сбросить число до 1\n" +
                  "0 (Esc) - Exit\n");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        game.Increment();
                        break;
                    case ConsoleKey.D2:
                        game.Doubling();
                        break;
                    case ConsoleKey.D3:
                        game.Reset();
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            } while (game.Finish > game.Current);
            
            if (game.Finish == game.Current)
            {
                SupportMethods.PrepareConsoleForHomeTask("Задание 5. Игра \"Удвоитель\"\n" +
                    $"Загаданное число: {game.Finish}\n" +
                    $"Число у игрока: {game.Current}\n" +
                    $"Шагов: {game.Steps}\n\n");
                SupportMethods.Pause($"Поздравляем! Вы победили за {game.Steps} шагов!");
            } else
            {
                SupportMethods.PrepareConsoleForHomeTask("Задание 5. Игра \"Удвоитель\"\n" +
                    $"Загаданное число: {game.Finish}\n" +
                    $"Число у игрока: {game.Current}\n" +
                    $"Шагов: {game.Steps}\n\n");
                SupportMethods.Pause($"К сожалению, Вы проиграли!\n Попробуйте еще раз!");
            }
        }

        /// <summary>
        /// ***Написать игру “Верю. Не верю”.
        /// В файле хранятся некоторые данные и правда это или нет.
        /// Например: “Шариковую ручку изобрели в древнем Египте”, “Да”.
        /// Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задает их игроку.
        /// Игрок пытается ответить правда или нет, то что ему загадали и набирает баллы.
        /// Список вопросов ищите во вложении или можно воспользоваться Интернетом.
        /// </summary>
        static void Task6()
        {
            //Clear console and print info regarding current task
            //SupportMethods.PrepareConsoleForHomeTask($"Задание 6. Игра \"Верю, не верю.\"\n");

            string filename = "game_trust.csv";
            int rowCount = 0;

            TrustGame game;

            //fill array
            if (File.Exists(filename))
            {
                //get lines qty from file            
                rowCount = File.ReadLines(filename).Count();

                //initialize new array with lines from file
                game = new TrustGame(rowCount, filename);

                do
                {
                    //get question number from the array
                    int questionNumber;
                    questionNumber = game.GetQuestionNumber(0, rowCount);
                    
                    //Prepare game screen for game
                    SupportMethods.PrepareConsoleForHomeTask("Задание 6. Игра \"Верю, не верю.\"\n" +
                        $"Набрано баллов: {game.Points} \n" +
                        $"Вопрос № {game.Steps}\n\n" +
                        $"Вопрос: {game.GetQuestion(questionNumber)}\n" +
                        "Верите ли Вы?\n" +
                        "1 - Да\n" +
                        "2 - Нет\n" +
                        "0 (Esc) - Exit\n");
                    ConsoleKeyInfo key = Console.ReadKey();
                    Console.WriteLine();
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            if (game.GetAnswer(questionNumber))
                            {
                                game.CorrectAnswer();
                            } else
                            {
                                game.WrongAnswer();
                            }
                            break;
                        case ConsoleKey.D2:
                            if (!game.GetAnswer(questionNumber))
                            {
                                game.CorrectAnswer();
                            }
                            else
                            {
                                game.WrongAnswer();
                            }
                            break;
                        case ConsoleKey.D0:
                        case ConsoleKey.Escape:
                            return;
                        default:
                            break;
                    }
                } while (game.Steps < 5);

                //prepare game screen for result
                SupportMethods.PrepareConsoleForHomeTask("Задание 6. Игра \"Верю, не верю.\"\n");
                SupportMethods.Pause($"Поздравляем! Вы набрали {game.Points} баллов!");

                //print out array
                //SupportMethods.Pause($"{records.ToString()}");
            }
            else
            {
                Console.WriteLine($"{filename} not Found");
            }                        
        }

        static void Main(string[] args)
        {
            do
            {
                SupportMethods.PrepareConsoleForHomeTask("1 - Task 1\n" +
                  "2 - Task 2\n" +
                  "3 - Task 3\n" +
                  "4 - Task 4\n" +
                  "5 - Task 5\n" +
                  "6 - Task 6\n" +
                  "0 (Esc) - Exit\n");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Task1();
                        break;
                    case ConsoleKey.D2:
                        Task2();
                        break;
                    case ConsoleKey.D3:
                        Task3();
                        break;
                    case ConsoleKey.D4:
                        Task4();
                        break;
                    case ConsoleKey.D5:
                        Task5();
                        break;
                    case ConsoleKey.D6:
                        Task6();
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
