using System;
using System.Collections.Generic;
using System.Linq;

namespace lab9TA
{
    class Program
    {

        static void print(int[] A)
        {
            for (int i = 0; i < A.Length; ++i)
                Console.Write("{0} ", A[i]);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = 100000;
            List<int> A = new();
            List<int> A2 = new();
            int[] a2 = new int[100000];
            Console.WriteLine("После добавления новых, сортировка слиянием: ");
            for (int i = 0; i < n; i++)
            {
                A.Add(rnd.Next(100000));
                A2.Add(rnd.Next(10000));
                a2[i] = rnd.Next(100000);
            }

            long start = DateTime.Now.Ticks;
            int[] B = MergeSort(A.ToArray());
            Console.WriteLine("Время: " + (DateTime.Now.Ticks - start));
            start = DateTime.Now.Ticks;
            Pyramid_Sort(a2, 100000);
            Console.WriteLine("Пирамидальная сортировка: ");
            Console.WriteLine("Время: " + (DateTime.Now.Ticks - start));
            print(B);
            Console.WriteLine("После добавления новых(пирамидальная сортировка): ");
            Array.Resize(ref B, 200000);
            Array.Resize(ref a2, 200000);

            for (int i = 100000; i < 200000; i++)
            {
                B[i] = rnd.Next(10000);
                a2[i] = rnd.Next(10000);
            }
            start = DateTime.Now.Ticks;
            Pyramid_Sort(B, 200000);
            Console.WriteLine("Пирамидальная для элементов с частичной сортировкой:");
            Console.WriteLine("Время: " + (DateTime.Now.Ticks - start));

            start = DateTime.Now.Ticks;
            int[] B3 = MergeSort(a2);
            Console.WriteLine("Слиянием для элементов с частичной сортировкой: ");
            Console.WriteLine("Время: " + (DateTime.Now.Ticks - start));
            List<int> A3 = new(A2);
            start = DateTime.Now.Ticks;
            Pyramid_Sort(A2.ToArray(), 100000);
            Console.WriteLine("Пирамидальной для элементов с повторами: ");
            Console.WriteLine("Время: " + (DateTime.Now.Ticks - start));
            start = DateTime.Now.Ticks;
            int[] B4 = MergeSort(A3.ToArray());
            Console.WriteLine("Слиянием для элементов с повторами: ");
            Console.WriteLine("Время: " + (DateTime.Now.Ticks - start));
        }
        static Int32[] MergeSort(Int32[] array)
        {
            if (array.Length == 1)
            {
                return array;
            }

            Int32 middle = array.Length / 2;
            return Merge(MergeSort(array.Take(middle).ToArray()), MergeSort(array.Skip(middle).ToArray()));
        }

        static Int32[] Merge(Int32[] arr1, Int32[] arr2)
        {
            Int32 ptr1 = 0, ptr2 = 0;
            Int32[] merged = new Int32[arr1.Length + arr2.Length];

            for (Int32 i = 0; i < merged.Length; ++i)
            {
                if (ptr1 < arr1.Length && ptr2 < arr2.Length)
                {
                    merged[i] = arr1[ptr1] > arr2[ptr2] ? arr2[ptr2++] : arr1[ptr1++];
                }
                else
                {
                    merged[i] = ptr2 < arr2.Length ? arr2[ptr2++] : arr1[ptr1++];
                }
            }

            return merged;
        }
        static Int32 add2pyramid(Int32[] arr, Int32 i, Int32 N)
        {
            Int32 imax;
            Int32 buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] < arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }

        static void Pyramid_Sort(Int32[] arr, Int32 len)
        {      
            for (Int32 i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(arr, i, len);
                if (prev_i != i) ++i;
            }
            
            Int32 buf;
            for (Int32 k = len - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                Int32 i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(arr, i, k);
                }
            }
        }
    }
}
