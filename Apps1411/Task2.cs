using System;
using System.IO;
using System.Text.RegularExpressions;

namespace App1411
{
    public class Task2
    {
        public void Run()
        {
            Console.WriteLine("\n=== Завдання 2: Пошук та заміна ===");
            Console.Write("Введіть шлях до файлу: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Помилка: Файл не знайдено.");
                return;
            }

            Console.Write("Введіть слово для пошуку: ");
            string searchWord = Console.ReadLine();

            Console.Write("Введіть слово для заміни: ");
            string replaceWord = Console.ReadLine();

            string content = File.ReadAllText(filePath);
            string pattern = $@"\b{Regex.Escape(searchWord)}\b";
            int replacementsCount = Regex.Matches(content, pattern).Count;

            string updatedContent = Regex.Replace(content, pattern, replaceWord);
            File.WriteAllText(filePath, updatedContent);

            Console.WriteLine("\n--- Статистика роботи ---");
            Console.WriteLine($"Файл: {Path.GetFullPath(filePath)}");
            Console.WriteLine($"Шукане слово: {searchWord}");
            Console.WriteLine($"Слово для заміни: {replaceWord}");
            Console.WriteLine($"Кількість замін: {replacementsCount}");
        }
    }
}