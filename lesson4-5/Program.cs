using System;
using System.Collections;

namespace lesson4_5
{
    //
    // Написать программу, которая определяет, является ли введенная скобочная последовательность правильной. Примеры правильных скобочных выражений: (), ([])(), {}(), ([{}]), неправильных — )(, ())({), (, ])}), ([(]) для скобок [,(,{. Например: (2+(2*2)) или [2/{5*(4+7)}]
    // Реализовать алгоритм перевода из инфиксной записи арифметического выражения в постфиксную.
    // 
    internal class Program
    {
        public static void Main(string[] args)
        {
            Check();
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
                    if (checks((char)stack.Peek(),a))
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

            Console.WriteLine("верно");
        }


        private static bool checks(char a, char b)
        {
            if ((a == '(' && b == ')') || (a == '[' && b == ']') || (a == '{' && b == '}'))
            {
                return true;
            }

            return false;
        }
    }
}
