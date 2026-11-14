using System;
using System.IO;
using System.Text.RegularExpressions;

namespace App1411
{
    public class Task3
    {
        public void Run()
        {
            Console.WriteLine("\n=== Завдання 3: Модератор ===");
            Console.Write("Введіть шлях до файлу з текстом: ");
            string textFilePath = Console.ReadLine();

            Console.Write("Введіть шлях до файлу зі словами для модерації: ");
            string badWordsFilePath = Console.ReadLine();

            if (!File.Exists(textFilePath) || !File.Exists(badWordsFilePath))
            {
                Console.WriteLine("Помилка: Один або обидва файли не знайдено.");
                return;
            }

            string text = File.ReadAllText(textFilePath);
            string badWordsRaw = File.ReadAllText(badWordsFilePath);

            char[] separators = new char[] { ' ', '\n', '\r', '\t', ',', '.' };
            string[] badWords = badWordsRaw.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int totalModeratedWords = 0;

            foreach (string word in badWords)
            {
                string stars = new string('*', word.Length);
                string pattern = $@"\b{Regex.Escape(word)}\b";

                int matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase).Count;
                totalModeratedWords += matches;

                text = Regex.Replace(text, pattern, stars, RegexOptions.IgnoreCase);
            }

            File.WriteAllText(textFilePath, text);

            Console.WriteLine("\n--- Статистика модерації ---");
            Console.WriteLine($"Слів у словнику модерації: {badWords.Length}");
            Console.WriteLine($"Замінено слів у тексті: {totalModeratedWords}");
            Console.WriteLine("Результат успішно збережено у початковий файл.");
        }
    }
}