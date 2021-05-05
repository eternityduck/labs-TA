using System;
using System.Collections.Generic;

namespace lab9TA
{
    class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();
            int amount = random.Next(50, 100);
            List<int> first = new();
            //List<int> second = new() { 2, 3, 4, 5, 6, 2, 21, 53 };
            for (int i = 0; i < amount; i++)
            {
                first.Add(random.Next(1000));
                
            }
            Console.WriteLine("Имеем такой стартовый список: ");
            foreach (var item in first)
            {
                Console.WriteLine(item);
            }
            SelectionSort(ref first);
            //SelectionSort(ref second);
            foreach (var item in first)
            {
                Console.WriteLine(item);
            }
            amount = random.Next(50);
            for (int i = 0; i < amount; i++)
            {
                first.Add(random.Next(1000));
            }
            Console.WriteLine("После добавления элементов: ");
            foreach (var item in first)
            {
                Console.WriteLine(item);
            }
            shellSort(ref first);

            foreach (var item in first)
            {
                Console.WriteLine(item);
            }
            amount = random.Next(100);
            for (int i = 0; i < amount; i++)
            {

                int count = random.Next(1, 2);
                if (count == 1) first.Add(first[i]);
                else first.Add(random.Next(1000));
            }
            Console.WriteLine("После того, как соседи добавили свои сокровища: ");
            foreach (var item in first)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Отсортированы после добавления соседями: ");
            foreach (var item in BasicCountingSort(first))
            {
                Console.WriteLine(item);
            }

        }
        static List<int> BasicCountingSort(List<int> array)
        {
            long ellapledTicks = DateTime.Now.Ticks;
            var count = new int[1000 + 1];
            for (var i = 0; i < array.Count; i++)
            {
                count[array[i]]++;
            }
            var index = 0;
            for (var i = 0; i < count.Length; i++)
            {
                for (var j = 0; j < count[i]; j++)
                {
                    array[index] = i;
                    index++;
                }
            }
            Console.WriteLine($"Время выполнения {DateTime.Now.Ticks - ellapledTicks}");
            return array;
        }
        static void SelectionSort(ref List<int> arr)
        {
            long ellapledTicks = DateTime.Now.Ticks;
            int min, temp;
            int length = arr.Count;

            for (int i = 0; i < length - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
            }
            Console.WriteLine("После сортировки выбором: ");
            Console.WriteLine($"Время выполнения {DateTime.Now.Ticks - ellapledTicks}");

        }
        static void shellSort(ref List<int> list)
        {
            long ellapledTicks = DateTime.Now.Ticks;
            int step = list.Count / 2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < list.Count; i++)
                {
                    int value = list[i];
                    for (j = i - step; (j >= 0) && (list[j] > value); j -= step)
                        list[j + step] = list[j];
                    list[j + step] = value;
                }
                step /= 2;
            }
            Console.WriteLine("После сортировки Шеллом: ");
            Console.WriteLine($"Время выполнения {DateTime.Now.Ticks - ellapledTicks}");

        }

    }
}
