using System.Diagnostics;

namespace AVL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание объекта Random для генерации случайных чисел
            var random = new Random();
            // Создание массива из 10000 случайных чисел
            var numbers = Enumerable.Range(0, 10000).OrderBy(x => random.Next()).ToArray();
            // Создание объекта AVLTree
            var tree = new AVLTree();
            // Создание объекта Stopwatch для измерения времени
            var sw = new Stopwatch();
            // Инициализация переменных для хранения времени и количества операций при добавлении чисел
            long addTime = 0;
            tree.OperationsCount = 0; // Сбрасываем счетчик операций перед добавлением чисел
            // Поэлементное добавление чисел в дерево и измерение времени
            foreach (int num in numbers)
            {
                sw.Restart();
                tree.Add(num);
                sw.Stop();
                addTime += sw.ElapsedTicks;
            }
            // Запоминаем количество операций при добавлении чисел
            long addOperations = tree.OperationsCount;
            // Выборка 100 случайных чисел для поиска
            var searchNumbers = numbers.OrderBy(x => random.Next()).Take(100).ToArray();
            // Инициализация переменных для хранения времени и количества операций при поиске чисел
            long searchTime = 0;
            tree.OperationsCount = 0; // Сбрасываем счетчик операций перед поиском чисел
            // Поэлементный поиск чисел в дереве и измерение времени
            foreach (int num in searchNumbers)
            {
                sw.Restart();
                tree.Contains(num);
                sw.Stop();
                searchTime += sw.ElapsedTicks;
            }
            // Запоминаем количество операций при поиске чисел
            long searchOperations = tree.OperationsCount;
            // Выборка 1000 случайных чисел для удаления
            var removeNumbers = numbers.OrderBy(x => random.Next()).Take(1000).ToArray();
            // Инициализация переменных для хранения времени и количества операций при удалении чисел
            long removeTime = 0;
            tree.OperationsCount = 0; // Сбрасываем счетчик операций перед удалением чисел
            // Поэлементное удаление чисел из дерева и измерение времени
            foreach (int num in removeNumbers)
            {
                sw.Restart();
                tree.Remove(num);
                sw.Stop();
                removeTime += sw.ElapsedTicks;
            }
            // Запоминаем количество операций при удалении чисел
            long removeOperations = tree.OperationsCount;
            // Вывод результатов
            Console.WriteLine("Среднее время вставки: {0} тиков", addTime / (double)numbers.Length);
            Console.WriteLine("Среднее количество операций вставки: {0}", addOperations / (double)numbers.Length);
            Console.WriteLine("Среднее время поиска: {0} тиков", searchTime / (double)searchNumbers.Length);
            Console.WriteLine("Среднее количество операций поиска: {0}", searchOperations / (double)searchNumbers.Length);
            Console.WriteLine("Среднее время удаления: {0} тиков", removeTime / (double)removeNumbers.Length);
            Console.WriteLine("Среднее количество операций удаления: {0}", removeOperations / (double)removeNumbers.Length);
        }
    }
}