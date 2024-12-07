

namespace ConsoleApp1
{
    internal class FibonacciSeq
    {
        static void Main(string[] args)
        {
            int[] cache = new int[10];
            cache[0] = 1;
            cache[1] = 1;
            for (int i = 2; i < 10; i++)
            {
                cache[i] = cache[i - 1] + cache[i - 2];
            }
            for (int i = 0; i < 10; i++)
            {
                if (i < cache.Length - 1)
                    Console.Write($"{cache[i]}, ");
                else
                    Console.WriteLine($"{cache[i]}.");
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"{Fibonacci(8)} is 8th number in fibonacci sequence.");
        }

        static int Fibonacci(int i)
        {
            if (i == 1 || i == 2)
            {
                return 1;
            }

            return Fibonacci(i - 1) + Fibonacci(i - 2);
        }
    }
}
