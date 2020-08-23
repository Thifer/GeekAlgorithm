using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace lesson5
{
    //
    // Написать программу, которая определяет, является ли введенная скобочная последовательность правильной. Примеры правильных скобочных выражений: (), ([])(), {}(), ([{}]), неправильных — )(, ())({), (, ])}), ([(]) для скобок [,(,{. Например: (2+(2*2)) или [2/{5*(4+7)}]
    // Реализовать алгоритм перевода из инфиксной записи арифметического выражения в постфиксную.
    // 


    internal class Program
    {
        static int[,] Field;
        static int step;

        public static void Main(string[] args)
        {
            HorseStart(6, 6);

            // Check();

            //transfer(Console.ReadLine());
        }

        #region lesson4

        private static void HorseStart(int a, int b)
        {
            Console.Clear();
            step = 0;
            Field = new int[a, b];
            HorseMove(0, 0, 1);

            List<int> array = new List<int>();
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    array.Add(Field[i, j]);
                }
            }

            array.Sort();
            int ans = 0;
            int ans2 = 0;
            for (int i = 0; i < array.Count; i++)
            {
                ans += array[i];
            }
            
            for (int i = 1; i <= a*b; i++)
            {
                ans2 += i;
            }
            
            if(ans==ans2)
                Console.WriteLine("Solved");
            else
                Console.WriteLine("UnSolved");
            Console.WriteLine();
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    Console.Write("{0:D2} ", Field[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void HorseMove(int a, int b, int count)
        {
            Field[a, b] = count;
            count++;
            if (moveCheck(a + 2, b + 1))
            {
                HorseMove(a + 2, b + 1, count);
            }

            if (moveCheck(a + 2, b - 1))
            {
                HorseMove(a + 2, b - 1, count);
            }

            if (moveCheck(a - 2, b + 1))
            {
                HorseMove(a - 2, b + 1, count);
            }

            if (moveCheck(a - 2, b - 1))
            {
                HorseMove(a - 2, b - 1, count);
            }

            if (moveCheck(a + 1, b + 2))
            {
                HorseMove(a + 1, b + 2, count);
            }

            if (moveCheck(a + 1, b - 2))
            {
                HorseMove(a + 1, b - 2, count);
            }

            if (moveCheck(a - 1, b + 2))
            {
                HorseMove(a - 1, b + 2, count);
            }

            if (moveCheck(a - 1, b - 2))
            {
                HorseMove(a - 1, b - 2, count);
            }

            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    if (Field[i, j] == 0)
                    {
                        Field[a, b] = 0;
                        return;
                    }
                }
            }
        }


        private static bool moveCheck(int a, int b)
        {
            if (step % 10000000 == 0)
            {
                //Console.Clear();
                //Console.WriteLine(step);
            }

            step++;
            return a >= 0 && a < Field.GetLength(0) && b >= 0 && b < Field.GetLength(1) && (Field[a, b] == 0);
        }

        #endregion


        #region lesson5

        private static void Check()
        {
            Stack stack = new Stack();

            Console.WriteLine("ВВедите выражение");
            var answer = Console.ReadLine();

            foreach (var a in answer)
            {
                if (a == '(' || a == '{' || a == '[')
                {
                    stack.Push(a);
                }


                if (a == ')' || a == '}' || a == ']')
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("не верно");
                        return;
                    }

                    if (checks((char) stack.Peek(), a))
                    {
                        stack.Pop();
                    }

                    else
                    {
                        Console.WriteLine("не верно");
                        return;
                    }
                }
            }

            if (stack.Count > 0)
            {
                Console.WriteLine("не верно");
            }
            else
            {
                Console.WriteLine("верно");
            }
        }


        private static bool checks(char a, char b)
        {
            if ((a == '(' && b == ')') || (a == '[' && b == ']') || (a == '{' && b == '}'))
            {
                return true;
            }

            return false;
        }


        private static void transfer(string a)
        {
            Stack op = new Stack();
            string answer = string.Empty;
            foreach (var ch in a)
            {
                if (ch == '1' || ch == '2' || ch == '3' || ch == '4' || ch == '5' || ch == '6' || ch == '7' ||
                    ch == '8' ||
                    ch == '9')
                {
                    answer += ch;
                }

                if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
                {
                    op.Push(ch);
                }
            }

            while (op.Count > 0)
            {
                answer += op.Pop();
            }

            Console.WriteLine(answer);
        }

        #endregion
    }
}
