using System;
using System.Collections.Generic;

namespace lab9TA
{
    class Program
    {
        static int partitionUpdated(List<int> A, int start, int end)
        {
           
            int pivot = A[(start + end) / 2];
            
            int i = start;
            int j = end;
            while (i <= j)
            {
                while (A[i] < pivot)
                    i++;
                while (A[j] > pivot)
                    j--;
                if (i <= j)
                {
                    int temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;

                    i++;
                    j--;
                }
            }
            return i;
        }

        static void qSort(List<int> A, int start, int end)
        {
            if (start < end)
            {
                int temp = partitionUpdated(A, start, end);
                qSort(A, start, temp - 1);
                qSort(A, temp, end);
            }
        }

        static void print(List<int> A)
        {
            for (int i = 0; i < A.Count; ++i)
                Console.Write("{0} ", A[i]);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = 100;
            List<int> A = new();

            for (int i = 0; i < n; i++)
                A.Add(rnd.Next(100));

            print(A);
            long start = DateTime.Now.Ticks;
            quicksort(A, 0, A.Count - 1);
            Console.WriteLine(DateTime.Now.Ticks - start);
            print(A);
            Console.WriteLine("После добавления новых(обычная быстрая сортировка): ");
            //A.Clear();
            for(int i = 0; i < 200; i++)
            {
                A.Add(rnd.Next(1000));
            }
            print(A);
            start = DateTime.Now.Ticks;
            qSort(A, 0, A.Count - 1);
            Console.WriteLine("Время: " + (DateTime.Now.Ticks - start));
            print(A);
            Console.WriteLine("После добавления новых, улучшенная быстрая сортировка: ");
            for (int i = 0; i < 200; i++)
            {
                A.Add(rnd.Next(100));
            }
            print(A);
            start = DateTime.Now.Ticks;
            quicksort(A, 0, A.Count - 1);
            Console.WriteLine("Время: " + (DateTime.Now.Ticks - start));
            print(A);

        }
        static int partition(List<int> array, int start, int end)
        {
            int temp;
            int marker = start;
            for (int i = start; i < end; i++)
            {
                if (array[i] < array[end]) 
                {
                    temp = array[marker]; 
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        static void quicksort(List<int> array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = partition(array, start, end);
            quicksort(array, start, pivot - 1);
            quicksort(array, pivot + 1, end);
        }
    }
}
