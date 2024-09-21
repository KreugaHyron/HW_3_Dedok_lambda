using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    public delegate bool NumberFilter(int number);
    public static int[] GetNumbersByFilter(int[] array, NumberFilter filter)
    {
        List<int> result = new List<int>();
        foreach (int number in array)
        {
            if (filter(number))
            {
                result.Add(number);
            }
        }
        return result.ToArray();
    }
    public static bool IsEven(int number)
    {
        return number % 2 == 0;
    }
    public static bool IsOdd(int number)
    {
        return number % 2 != 0;
    }
    public static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
    public static bool IsFibonacci(int number)
    {
        bool IsPerfectSquare(int x)
        {
            int s = (int)Math.Sqrt(x);
            return s * s == x;
        }
        return IsPerfectSquare(5 * number * number + 4) || IsPerfectSquare(5 * number * number - 4);
    }
    static void Main(string[] args)
    {
        //1
        Console.WriteLine("Task_1: ");
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 13, 21, 34, 55 };
        int[] evenNumbers = GetNumbersByFilter(array, IsEven);
        Console.WriteLine("Парні числа: " + string.Join(", ", evenNumbers));

        int[] oddNumbers = GetNumbersByFilter(array, IsOdd);
        Console.WriteLine("Непарні числа: " + string.Join(", ", oddNumbers));

        int[] primeNumbers = GetNumbersByFilter(array, IsPrime);
        Console.WriteLine("Прості числа: " + string.Join(", ", primeNumbers));

        int[] fibonacciNumbers = GetNumbersByFilter(array, IsFibonacci);
        Console.WriteLine("Числа Фібоначчі: " + string.Join(", ", fibonacciNumbers));
        Console.WriteLine();
        //2
        Console.WriteLine("Task_2: ");
        Action showCurrentTime = () => Console.WriteLine($"Current Time: {DateTime.Now.ToString("T")}");
        Action showCurrentDate = () => Console.WriteLine($"Current Date: {DateTime.Now.ToString("D")}");
        Action showCurrentDayOfWeek = () => Console.WriteLine($"Current Day of the Week: {DateTime.Now.DayOfWeek}");

        showCurrentTime();
        showCurrentDate();
        showCurrentDayOfWeek();

        Func<double, double, double> calculateTriangleArea = (baseLength, height) => 0.5 * baseLength * height;
        Func<double, double, double> calculateRectangleArea = (width, height) => width * height;

        double triangleBase = 5;
        double triangleHeight = 10;
        double rectangleWidth = 7;
        double rectangleHeight = 4;

        double triangleArea = calculateTriangleArea(triangleBase, triangleHeight);
        double rectangleArea = calculateRectangleArea(rectangleWidth, rectangleHeight);

        Console.WriteLine($"Triangle Area: {triangleArea}");
        Console.WriteLine($"Rectangle Area: {rectangleArea}");
        Console.WriteLine();
        //3
        Console.WriteLine("Task_3: ");
        Func<string, string, bool> containsWord = (text, word) =>
        text.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0;
        string text = "Це приклад тексту для перевірки.";
        string wordToCheck = "приклад";
        bool result = containsWord(text, wordToCheck);
        Console.WriteLine($"Чи містить текст слово '{wordToCheck}': {result}");
        wordToCheck = "немає";
        result = containsWord(text, wordToCheck);
        Console.WriteLine($"Чи містить текст слово '{wordToCheck}': {result}");
        Console.WriteLine();
        //4
        Console.WriteLine("Task_4: ");
        int[] numbers = { 1, 7, 14, 21, 3, 28, 9, 35, 40, 49, 50 };
        Func<int[], int> countMultiplesOfSeven = arr =>
            Array.FindAll(arr, n => n % 7 == 0).Length;
        int count = countMultiplesOfSeven(numbers);
        Console.WriteLine($"Кількість чисел, кратних семи: {count}");
        Console.WriteLine();
        //5
        Console.WriteLine("Task_5: ");
        int[] numbers_1 = { -5, 3, 0, 7, -1, 12, -8, 4, -2, 9 };
        Func<int[], int> countPositiveNumbers = arr_1 =>
            Array.FindAll(arr_1, n_1 => n_1 > 0).Length;
        int count_1 = countPositiveNumbers(numbers_1);
        Console.WriteLine($"Кількість позитивних чисел: {count_1}");
        Console.WriteLine();
        //6
        Console.WriteLine("Task_6: ");
        int[] numbers_2 = { -5, 3, -1, -5, 7, -2, -1, -8, 4, -2 };
        Func<int[], int[]> uniqueNegativeNumbers = arr_2 =>
            arr_2.Where(n_2 => n_2 < 0).Distinct().ToArray();
        int[] uniqueNegatives = uniqueNegativeNumbers(numbers_2);
        Console.WriteLine("Унікальні негативні числа: " + string.Join(", ", uniqueNegatives));
    }
}
