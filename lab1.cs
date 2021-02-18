using System;
using System.IO;
using System.Diagnostics;
namespace lab1TA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Натисніть клавішу:\n1 для генерації випадкового масиву і запису його в файл\n2 для введення масиву вручну\n3 для зчитування масиву з файлу");
            var key = Console.ReadKey();
            Console.WriteLine("\n");
            // Console.Clear();

            if (key.Key == ConsoleKey.D1)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                int[,] arr = GenerateRandomArray();
                Console.WriteLine($"Кількість нулів у випадково згенерованому масиві розміром {arr.GetLength(0)} x {arr.GetLength(1)} ел.: {CountZeros(arr)}");
                sw.Stop();
                Console.WriteLine("Витрачено часу: {0}", sw.Elapsed);
                WriteToFile(arr);
            }
            else if (key.Key == ConsoleKey.D2)
            {
                int firstsize, secondsize;
                Console.WriteLine("Кількість рядків: ");

                if (!Int32.TryParse(Console.ReadLine(), out firstsize))
                {
                    Console.WriteLine("Помилка введення");
                    Environment.Exit(0);
                }
                else Console.WriteLine("Кількість елементів у рядку: ");
                if (!Int32.TryParse(Console.ReadLine(), out secondsize)) Console.WriteLine("Помилка введення");
                else
                {
                    int[,] array = new int[firstsize, secondsize];
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {

                            Console.WriteLine($"Елемент у комірці [{i}, {j}]: ");
                            if (!Int32.TryParse(Console.ReadLine(), out array[i, j]))
                            {
                                Console.WriteLine("Помилка введення");
                                Environment.Exit(0);
                            }

                        }
                    }
                    Console.WriteLine($"Кількість нулів у масиві: {CountZeros(array)}");
                }
            }
            else if (key.Key == ConsoleKey.D3)
            {
                int[,] num = ReadFromFile();
                // проверяем выводом на консоль
                for (int i = 0; i < num.GetLength(0); i++)
                {
                    for (int j = 0; j < num.GetLength(1); j++) Console.Write($"{num[i, j]} ");
                    Console.WriteLine();
                }
                Console.WriteLine($"Кількість нулів у масиві: {CountZeros(num)}");
            }
            else Console.WriteLine("Помилка: Ви натиснули неправильну клавішу.");

            Console.ReadKey();
        }
        public static int[,] GenerateRandomArray()
        {
            Random random = new Random();
            int n = random.Next(100);
            int m = random.Next(100);
            int[,] arr = new int[n, m];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = random.Next(100);
                }
            }
            return arr;
        }
        public static int CountZeros(int[,] arr)
        {
            int count = 0;
            foreach (var item in arr) if (item == 0) count++;
            return count;
        }
        public static void WriteToFile(int[,] arr)
        {
            string writePath = @"D:\lab.txt";

            using (StreamWriter sw = new StreamWriter(writePath))
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        sw.WriteLine(String.Format("{0}|{1}|{2}|", i, j, arr[i, j]));
                    }
                }
                sw.Close();
            }
        }
        public static int[,] ReadFromFile()
        {
            string path = @"D:\labta.txt";
            Console.WriteLine("Масив з файлу:");
            string[] lines = File.ReadAllLines(path);
            int[,] num = new int[lines.Length, lines[0].Split(' ').Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                    num[i, j] = Convert.ToInt32(temp[j]);
            }
            return num;
        }
    }
}
