using System.Diagnostics;

namespace HomeWork7
{
    delegate List<long> FindFibbonacciHandler(List<long> longs, int n);
    class Program
    {
        static void Main()
        {
            var stopwatch = new Stopwatch();
            var longs = new List<long>();
            Console.WriteLine("Поиск рекурсивно, нажмите любую клавишу");
            PrintInputNumbers(longs, GetRecursivelyList);
            Console.WriteLine("Поиск циклично, нажмите любую клавишу");
            PrintInputNumbers(longs, GetCycicallyList);
            PrintResult(longs, 5, stopwatch, GetRecursivelyList);
            PrintResult(longs, 5, stopwatch, GetCycicallyList);
            PrintResult(longs, 10, stopwatch, GetRecursivelyList);
            PrintResult(longs, 10, stopwatch, GetCycicallyList);
            PrintResult(longs, 20, stopwatch, GetRecursivelyList);
            PrintResult(longs, 20, stopwatch, GetCycicallyList);
            Console.ReadKey();
        }
        public static void PrintNums(List<long> longs)
        {
            foreach (var item in longs)
            {
                Console.Write("{0} ", item);
            }
        }
        public static void PrintInputNumbers(List<long> longs, FindFibbonacciHandler handler)
        {
            longs = new List<long> { 0, 1 };
            Console.WriteLine("Для поиска n-го члена напишите число 'n' ниже:");
            var isNum = int.TryParse(Console.ReadLine(), out var n);
            if (isNum)
            {
                handler(longs, n);
            }
            // Для просмотра последовательности чисел, разкомментируйте блок кода ниже
            PrintNums(longs);
            Console.WriteLine($"{n}-й член: {longs[n - 1]}");
        }
        public static void PrintResult(List<long> longs, int n, Stopwatch stopwatch, FindFibbonacciHandler handler)
        {
            var s = new string('-', 50);
            if (handler == GetCycicallyList)
            {
                Console.WriteLine(s + "\nПоиск циклично");
            }
            else
            {
                Console.WriteLine(s + "\nПоиск рекурсивно");
            }
            longs = new List<long> { 0, 1 };
            stopwatch.Start();
            handler(longs, n);
            Console.WriteLine($"Затраченное время: {stopwatch.Elapsed}");
            // Для просмотра последовательности чисел, разкомментируйте блок кода ниже
            PrintNums(longs);
            stopwatch.Reset();
            Console.WriteLine($"{n}-й член: {longs[n - 1]}");
        }
        public static List<long> GetRecursivelyList(List<long> longs, int n)
        {
            longs.Add(longs[^2] + longs[^1]);
            if (longs.Count < n)
            {
                return GetRecursivelyList(longs, n);
            }
            else return longs;
        }
        public static List<long> GetCycicallyList(List<long> longs, int n)
        {
            while (longs.Count < n)
            {
                longs.Add(longs[^2] + longs[^1]);
            }
            return longs;
        }
    }
}