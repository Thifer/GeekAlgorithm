using System;
using System.Runtime.InteropServices;

namespace GeekAlgorithm
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int seed = 0;
            Console.WriteLine("Введите номер задания или 0 для отмены");
            int.TryParse(Console.ReadLine(), out var task);
            Console.WriteLine("task = " + task);
            switch (task)
            {
                case 12:
                    int a, b, c;
                    Console.WriteLine("Введите первое число");
                    int.TryParse(Console.ReadLine(), out a);
                    Console.WriteLine("Введите второе число");
                    int.TryParse(Console.ReadLine(), out b);
                    Console.WriteLine("Введите третье число");
                    int.TryParse(Console.ReadLine(), out c);
                    if (a > b)
                    {
                        if (a > c) Console.WriteLine("максимальное число : " + a);
                        else Console.WriteLine("максимальное число : " + c);
                    }
                    else if (b > c) Console.WriteLine("максимальное число : " + b);
                    else Console.WriteLine("максимальное число : " + c);

                    break;
                case 13:
                    Random rnd = new Random();

                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("Случайное число с использованием стандартного ГПСЧ : " + rnd.Next(1, 100));
                        Console.WriteLine("Случайное число без использования стандартного ГПСЧ : " + Rnd(ref seed));
                    }

                    break;
                case 14:
                    Console.WriteLine("Введите натуральное число");
                    int.TryParse(Console.ReadLine(), out var number);
                    for (int i = 0; i <= number; i++)
                    {
                        if (IsAuto(i))
                        {
                            Console.Write(i + "^" + 2 + " = " + Math.Pow(i, 2) + " ");
                        }
                    }

                    break;
                default:
                    break;
            }
        }

        private static bool IsAuto(int i)
        {
            if (true)
            {
                long pow = (long) Math.Pow(i, 2);
                pow -= i;
                for (int j = 0; j < i.ToString().Length; j++)
                {
                    if (pow % 10 != 0)
                        return false;
                    else
                    {
                        pow /= 10;
                    }
                }

                return true;
            }
        }

        private static int Rnd(ref int seed)
        {
            seed = seed + DateTime.Now.GetHashCode();
            int result = seed;
            result >>= 10;
            result /= 1243;
            while (result < 0 || result > 100)
            {
                if (result <= 0) result += 100;
                else if (result >= 100) result -= 100;
            }

            return result;
        }
    }
}
