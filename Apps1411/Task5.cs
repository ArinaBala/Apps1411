using System;
using System.IO;

namespace App1411
{
    public class Task5
    {
        public void Run()
        {
            Console.WriteLine("\n=== Завдання 5: Аналіз 100 000 чисел ===");
            string sourceFile = "numbers_100k.txt";

            if (!File.Exists(sourceFile))
            {
                GenerateNumbersFile(sourceFile, 100000);
            }

            string content = File.ReadAllText(sourceFile);
            string[] tokens = content.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            int[] allNumbers = new int[tokens.Length];
            int posCount = 0;
            int negCount = 0;
            int twoDigitCount = 0;
            int fiveDigitCount = 0;

            for (int i = 0; i < tokens.Length; i++)
            {
                if (int.TryParse(tokens[i], out int number))
                {
                    allNumbers[i] = number;

                    if (number > 0) posCount++;
                    else if (number < 0) negCount++;

                    int absNumber = Math.Abs(number);
                    if (absNumber >= 10 && absNumber <= 99) twoDigitCount++;
                    else if (absNumber >= 10000 && absNumber <= 99999) fiveDigitCount++;
                }
            }

            int[] positive = new int[posCount];
            int[] negative = new int[negCount];
            int[] twoDigit = new int[twoDigitCount];
            int[] fiveDigit = new int[fiveDigitCount];

            int pIdx = 0, nIdx = 0, tIdx = 0, fIdx = 0;

            for (int i = 0; i < allNumbers.Length; i++)
            {
                int number = allNumbers[i];

                if (number > 0) positive[pIdx++] = number;
                else if (number < 0) negative[nIdx++] = number;

                int absNumber = Math.Abs(number);
                if (absNumber >= 10 && absNumber <= 99) twoDigit[tIdx++] = number;
                else if (absNumber >= 10000 && absNumber <= 99999) fiveDigit[fIdx++] = number;
            }

            File.WriteAllText("positive_numbers.txt", string.Join(" ", positive));
            File.WriteAllText("negative_numbers.txt", string.Join(" ", negative));
            File.WriteAllText("two_digit_numbers.txt", string.Join(" ", twoDigit));
            File.WriteAllText("five_digit_numbers.txt", string.Join(" ", fiveDigit));

            Console.WriteLine($"Проаналізовано чисел із файлу {sourceFile}: {allNumbers.Length}");
            Console.WriteLine($"1. Кількість додатних чисел: {positive.Length} (файл: positive_numbers.txt)");
            Console.WriteLine($"2. Кількість від'ємних чисел: {negative.Length} (файл: negative_numbers.txt)");
            Console.WriteLine($"3. Кількість двозначних чисел: {twoDigit.Length} (файл: two_digit_numbers.txt)");
            Console.WriteLine($"4. Кількість п'ятизначних чисел: {fiveDigit.Length} (файл: five_digit_numbers.txt)");
        }

        private void GenerateNumbersFile(string filePath, int count)
        {
            Random random = new Random();
            int[] numbers = new int[count];

            for (int i = 0; i < count; i++)
            {
                numbers[i] = random.Next(-100000, 100001);
            }

            File.WriteAllText(filePath, string.Join(" ", numbers));
        }
    }
}