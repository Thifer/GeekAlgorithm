using System;
using System.Collections.Generic;

namespace lesson2
{
    /*
     * 1. Реализовать функцию перевода из десятичной системы в двоичную, используя рекурсию.
     * 2. Реализовать функцию возведения числа a в степень b:
     * a. без рекурсии;
     * b. рекурсивно;
     * c. *рекурсивно, используя свойство четности степени.
     *
     * 3. Исполнитель Калькулятор преобразует целое число, записанное на экране. У исполнителя две команды, каждой команде присвоен номер:
     * Прибавь 1
     * Умножь на 2
     * Первая команда увеличивает число на экране на 1, вторая увеличивает это число в 2 раза. Сколько существует программ, которые число 3 преобразуют в число 20?
     * а) с использованием массива;
     * б) с использованием рекурсии.
     * Реализовать меню с выбором способа заполнения массива: из файла, случайными числами, с клавиатуры.
     */
    internal class Program
    {
        static List<int> temp = new List<int>();
        private static int count = 0;
        private static int start = 3;
        private static int end = 200;

        public static void Main(string[] args)
        {
            Console.WriteLine("введите число для перевода в двоичную систему счисления");
            Transfer(Int32.Parse(Console.ReadLine()));
            Console.WriteLine();
            Console.WriteLine("Введите число A для возведения в степерь B");
            Console.WriteLine();
            Console.WriteLine(
                Pow(uint.Parse(Console.ReadLine()), uint.Parse(Console.ReadLine())));
            Console.WriteLine();
            temp.Clear();
            Calc(start);
            Console.WriteLine(count);
            
        }


        #region Transfer

        private static void Transfer(int dec)
        {
            RecTranf(dec);
            temp.Reverse();
            Console.WriteLine();
            foreach (var value in temp)
            {
                Console.Write(value);
            }
        }

        private static void RecTranf(int dec)
        {
            if (dec > 0)
            {
                temp.Add(dec % 2);
                dec /= 2;
                RecTranf(dec);
            }
        }

        #endregion

        #region pow

        private static uint Pow(uint a, uint b)
        {
            if (b == 0) return 1;
            else if (b % 2 == 1) return a * Pow(a, b - 1);
            else return Pow(a * a, b / 2);
        }

        #endregion

        #region Calc

        static void Calc(int local)
        {
            if(local> end) return;
            if (local == end)
            {
                count++;
                return;
            }

            if (local < end)
            {
                
                Calc(local+1);
                Calc(local*2);
            }
        }

        #endregion
    }
}
