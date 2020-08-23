using System;
using System.Collections;
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

        public static void Main(string[] args)
        {
            Check();
            transfer(Console.ReadLine());
        }


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
            string answer =string.Empty;
            foreach (var ch in a)
            {

                if (ch == '1' || ch == '2' || ch == '3' || ch == '4'|| ch == '5' || ch == '6' || ch == '7' || ch == '8' ||
                    ch == '9')
                {
                    answer += ch;
                }
                if (ch == '+' || ch == '-'|| ch == '*' || ch == '/')
                {
                    op.Push(ch);
                }

            }

            while (op.Count>0)
            {
                answer += op.Pop();
            }

            Console.WriteLine(answer);
        }
    }
}
