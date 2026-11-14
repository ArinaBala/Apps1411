using System;
using System.IO;

namespace App1411
{
    public class Task1
    {
        public void Run()
        {
            Random random = new Random();
            int[] numbers = new int[100];

            int primeCount = 0;
            int fibCount = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 1001);

                if (IsPrime(numbers[i]))
                {
                    primeCount++;
                }

                if (IsFibonacci(numbers[i]))
                {
                    fibCount++;
                }
            }

            int[] primes = new int[primeCount];
            int[] fibonacci = new int[fibCount];

            int pIndex = 0;
            int fIndex = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (IsPrime(numbers[i]))
                {
                    primes[pIndex++] = numbers[i];
                }

                if (IsFibonacci(numbers[i]))
                {
                    fibonacci[fIndex++] = numbers[i];
                }
            }

            string primesFile = "primes.txt";
            string fibFile = "fibonacci.txt";

            File.WriteAllText(primesFile, string.Join(" ", primes));
            File.WriteAllText(fibFile, string.Join(" ", fibonacci));

            Console.WriteLine("=== Завдання 1: Статистика ===");
            Console.WriteLine($"Всього згенеровано чисел: {numbers.Length}");
            Console.WriteLine($"Знайдено простих чисел: {primes.Length} (файл: {primesFile})");
            Console.WriteLine($"Знайдено чисел Фібоначчі: {fibonacci.Length} (файл: {fibFile})");
            Console.WriteLine("Прості числа: " + (primes.Length > 0 ? string.Join(", ", primes) : "немає"));
            Console.WriteLine("Числа Фібоначчі: " + (fibonacci.Length > 0 ? string.Join(", ", fibonacci) : "немає"));
        }

        private bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        private bool IsFibonacci(int n)
        {
            if (n < 0) return false;
            int a = 0;
            int b = 1;
            while (a < n)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a == n;
        }
    }
}