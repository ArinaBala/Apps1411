using System;
using System.IO;

namespace App1411
{
    public class Task4
    {
        public void Run()
        {
            Console.WriteLine("\n=== Завдання 4: Перевертання вмісту файлу ===");
            Console.Write("Введіть шлях до файлу: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Помилка: Файл не знайдено.");
                return;
            }

            string content = File.ReadAllText(filePath);
            char[] charArray = content.ToCharArray();
            Array.Reverse(charArray);
            string reversedContent = new string(charArray);

            string directory = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileName(filePath);
            string newFilePath = Path.Combine(directory ?? "", "reversed_" + fileName);

            File.WriteAllText(newFilePath, reversedContent);

            Console.WriteLine("Вміст файлу успішно перевернуто.");
            Console.WriteLine($"Новий файл збережено за шляхом: {Path.GetFullPath(newFilePath)}");
        }
    }
}