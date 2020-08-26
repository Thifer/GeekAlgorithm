using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;

namespace lesson6
{
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            task1();
            task2();
        }

        #region Task1

        private static void task1()
        {
            List<long> list = new List<long>();
            int count = 0;

            for (int i = 0; i < 100000; i++)
            {
                list.Add(hash(i));
            }
            check(list);
        }


        private static void check(List<long> list)
        {
            int count = 0;
            List<long> collision = new List<long>();
            list.Sort();
            for (int i = 0; i < list.Count-1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    collision.Add(list[i]);
                    count++;
                }
            }

            for (int i = 0; i < collision.Count; i++)
            {
                Console.WriteLine(collision[i]);
            }
            
            Console.WriteLine(count);
        }



        private static long hash(int key)
        {
            key *= key;
            key = key + (key << 10)/50;
            return key;
        }

        #endregion

        #region Task2

        private static void task2()
        {
            int[] array = new int[] {0, 8, 9, 15, 12, 6, 6, 12, 16, 0, 0, 0, 5, 0, 0};
            Console.WriteLine("Введите метод обхода дерева где L - лево, r - корень, R - право");
            Console.WriteLine("Привем rLR");
            printTree(array, Console.ReadLine());
        }

        private static void printTree(int[] array, string args = "rLR", int start = 1)
        {
            switch (args)
            {
                default:
                {
                    if (start < array.Length && array[start] != 0)
                    {
                        Console.Write($"{array[start]} ,");
                        if (2 * start < array.Length && array[2 * start] != 0) printTree(array, args, 2 * start);
                        if (2 * start + 1 < array.Length && array[2 * start + 1] != 0)
                            printTree(array, args, 2 * start + 1);
                    }

                    break;
                }
                case "LrR":
                {
                    if (start < array.Length && array[start] != 0)
                    {
                        if (2 * start < array.Length && array[2 * start] != 0) printTree(array, args, 2 * start);
                        Console.Write($"{array[start]} ,");
                        if (2 * start + 1 < array.Length && array[2 * start + 1] != 0)
                            printTree(array, args, 2 * start + 1);
                    }

                    break;
                }
                case "LRr":
                {
                    if (start < array.Length && array[start] != 0)
                    {
                        if (2 * start < array.Length && array[2 * start] != 0) printTree(array, args, 2 * start);
                        if (2 * start + 1 < array.Length && array[2 * start + 1] != 0)
                            printTree(array, args, 2 * start + 1);
                        Console.Write($"{array[start]} ,");
                    }

                    break;
                }
                case "RrL":
                {
                    if (start < array.Length && array[start] != 0)
                    {
                        if (2 * start + 1 < array.Length && array[2 * start + 1] != 0)
                            printTree(array, args, 2 * start + 1);
                        Console.Write($"{array[start]} ,");
                        if (2 * start < array.Length && array[2 * start] != 0) printTree(array, args, 2 * start);
                    }

                    break;
                }
                case "RLr":
                {
                    if (start < array.Length && array[start] != 0)
                    {
                        if (2 * start + 1 < array.Length && array[2 * start + 1] != 0)
                            printTree(array, args, 2 * start + 1);
                        if (2 * start < array.Length && array[2 * start] != 0) printTree(array, args, 2 * start);
                        Console.Write($"{array[start]} ,");
                    }

                    break;
                }
                case "rRL":
                {
                    if (start < array.Length && array[start] != 0)
                    {
                        Console.Write($"{array[start]} ,");
                        if (2 * start + 1 < array.Length && array[2 * start + 1] != 0)
                            printTree(array, args, 2 * start + 1);
                        if (2 * start < array.Length && array[2 * start] != 0) printTree(array, args, 2 * start);
                    }

                    break;
                }
            }
        }

        #endregion
    }
}
