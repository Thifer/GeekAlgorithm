using System;

namespace lesson3
{
    internal class Program
    {
        /*1. Попробовать оптимизировать пузырьковую сортировку. Сравнить количество операций сравнения оптимизированной и не оптимизированной программы. Написать функции сортировки, которые возвращают количество операций.
         *2. *Реализовать шейкерную сортировку.
         *3. Реализовать бинарный алгоритм поиска в виде функции, которой передается отсортированный массив. Функция возвращает индекс найденного элемента или -1, если элемент не найден.
         *4. *Подсчитать количество операций для каждой из сортировок и сравнить его с асимптотической сложностью алгоритма.*/
        public static void Main(string[] args)
        {
            var rnd = new Random();
            var bubbleTen = new int[10];
            var bubbleHundred = new int[100];
            var bubbleThousand = new int [1000];
            var shakerTen = new int[10];
            var shakerHundred = new int[100];
            var shakerThousand = new int [1000];

            for (int i = 0; i < bubbleTen.Length; i++)
            {
                bubbleTen[i] = rnd.Next(1000);
                shakerTen[i] = bubbleTen[i];
            }

            for (int i = 0; i < bubbleHundred.Length; i++)
            {
                bubbleHundred[i] = rnd.Next(1000);
                shakerHundred[i] = bubbleHundred[i];
            }

            for (int i = 0; i < bubbleThousand.Length; i++)
            {
                bubbleThousand[i] = rnd.Next(1000);
                shakerThousand[i] = bubbleThousand[i];
            }

            Console.WriteLine("Bubble sort array of 10");
            boublesort(bubbleTen);
            Console.WriteLine("Bubble sort array of 100");
            boublesort(bubbleHundred);
            Console.WriteLine("Bubble sort array of 1000");
            boublesort(bubbleThousand);
            Console.WriteLine("Shaker sort array of 10");
            shakerSort(shakerTen);
            Console.WriteLine("Shaker sort array of 100");
            shakerSort(shakerHundred);
            Console.WriteLine("Shaker sort array of 1000");
            shakerSort(shakerThousand);
        }


        private static void boublesort(int[] array)
        {
            var start = DateTime.Now;
            int swap = 0;
            int count = 0;
            int temp = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                        swap++;
                    }

                    count++;
                }
            }

            var time = (DateTime.Now - start).TotalMilliseconds;
            
            Console.WriteLine("время : " + time);
            Console.WriteLine("чтений : " + count);
            Console.WriteLine("записей : " + swap);
            Console.WriteLine();
        }

        private static void shakerSort(int[] array)
        {
            var start = DateTime.Now;
            int swap = 0;
            int count = 0;
            int temp = 0;

            for (int i = 0; i < array.Length / 2; i++)
            {
                for (int j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                        swap++;
                    }

                    count++;
                }

                for (int j = array.Length - 2 - 1; j > i; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                        swap++;
                    }

                    count++;
                }
            }

            var time = (DateTime.Now - start).TotalMilliseconds;
            Console.WriteLine("время : " + time);
            Console.WriteLine("чтений : " + count);
            Console.WriteLine("записей : " + swap);
            Console.WriteLine();
        }
    }
}
