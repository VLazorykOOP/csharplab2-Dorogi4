using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть розмірність масиву:");
        int size = int.Parse(Console.ReadLine());

        // Одновимірний масив
        int[] array1D = new int[size];

        Console.WriteLine("Введіть елементи масиву:");
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Елемент {i + 1}: ");
            array1D[i] = int.Parse(Console.ReadLine());
        }

        // Введення інтервалу
        Console.WriteLine("Введіть початок інтервалу:");
        int start = int.Parse(Console.ReadLine());
        Console.WriteLine("Введіть кінець інтервалу:");
        int end = int.Parse(Console.ReadLine());

        // Підрахунок елементів, що не потрапляють в заданий інтервал
        int countOutsideInterval1D = 0;
        foreach (int num in array1D)
        {
            if (num < start || num > end)
                countOutsideInterval1D++;
        }

        Console.WriteLine($"Кількість елементів, що не потрапляють в інтервал [{start}, {end}]: {countOutsideInterval1D}");

        // Двовимірний масив
        int[,] array2D = new int[size, size];

        Console.WriteLine("Введіть елементи масиву:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write($"Елемент [{i + 1}, {j + 1}]: ");
                array2D[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Підрахунок елементів, що не потрапляють в заданий інтервал
        int countOutsideInterval2D = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (array2D[i, j] < start || array2D[i, j] > end)
                    countOutsideInterval2D++;
            }
        }

        Console.WriteLine($"Кількість елементів, що не потрапляють в інтервал [{start}, {end}] (двовимірний масив): {countOutsideInterval2D}");
    }
}
