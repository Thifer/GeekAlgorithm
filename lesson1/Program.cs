using System;

namespace GeekAlgorithm
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задания или 0 для отмены");
            int.TryParse(Console.ReadLine(), out var task);
            Console.WriteLine("task = " + task);
            switch (task)
            {
                case 14:
                    Console.WriteLine("Введите натуральное число");
                    int.TryParse(Console.ReadLine(), out var number);
                    for (int i = 0; i <= number; i++)
                    {
                        if (IsAuto(i))
                        {
                            Console.Write(i + "^" + 2 +" = " + Math.Pow(i,2)+ " ");
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
        
        
        
    }
}
