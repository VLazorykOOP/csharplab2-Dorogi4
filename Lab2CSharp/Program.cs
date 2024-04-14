using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Виберіть завдання:");
        Console.WriteLine("1. Підрахувати кількість елементів, що не потрапляють в заданий інтервал.");
        Console.WriteLine("2. Знайти номер останнього мінімального елемента.");
        Console.WriteLine("3. Обчислити A в степені n, де n - натуральне число.");
        Console.WriteLine("4. Для кожного рядка знайти суму елементів з номерами від k1 до k2 і записати дані в новий масив.");

        int taskChoice = int.Parse(Console.ReadLine());

        if (taskChoice == 1)
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
        }
        else if (taskChoice == 2)
        {
            Console.WriteLine("Введіть розмірність одновимірного масиву:");
            int size = int.Parse(Console.ReadLine());

            // Одновимірний масив
            double[] array = new double[size];

            Console.WriteLine("Введіть елементи масиву:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Елемент {i + 1}: ");
                array[i] = double.Parse(Console.ReadLine());
            }

            // Знаходження номеру останнього мінімального елемента
            double min = array[0];
            int lastIndex = 0;
            for (int i = 1; i < size; i++)
            {
                if (array[i] <= min)
                {
                    min = array[i];
                    lastIndex = i;
                }
            }

            Console.WriteLine($"Номер останнього мінімального елемента: {lastIndex + 1}");
        }
        else if (taskChoice == 3)
        {
            Console.WriteLine("Введіть розмірність масиву n:");
            int n = int.Parse(Console.ReadLine());

            // Двовимірний масив
            double[,] array = new double[n, n];

            Console.WriteLine("Введіть елементи масиву:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Елемент [{i + 1}, {j + 1}]: ");
                    array[i, j] = double.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Введіть степінь n:");
            int power = int.Parse(Console.ReadLine());

            // Обчислення A в степені n
            double[,] result = PowerOfArray(array, power);

            Console.WriteLine($"Результат обчислення A в степені {power}:");
            PrintArray(result);
        }
        else if (taskChoice == 4)
        {
            Console.WriteLine("Введіть розмірність масиву n:");
            int n = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[n][];

            Console.WriteLine("Введіть дані масиву:");

            // Введення елементів масиву
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введіть кількість елементів у рядку {i + 1}: ");
                int m = int.Parse(Console.ReadLine());
                jaggedArray[i] = new int[m];

                Console.WriteLine($"Введіть елементи для рядка {i + 1}:");
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Елемент {j + 1}: ");
                    jaggedArray[i][j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Введіть k1:");
            int k1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть k2:");
            int k2 = int.Parse(Console.ReadLine());

            // Створення нового масиву для зберігання сум елементів з номерами від k1 до k2 для кожного рядка
            int[] sums = new int[n];

            // Обчислення сум елементів з номерами від k1 до k2 для кожного рядка
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = k1 - 1; j < k2 && j < jaggedArray[i].Length; j++)
                {
                    sum += jaggedArray[i][j];
                }
                sums[i] = sum;
            }

            // Виведення результату
            Console.WriteLine("Суми елементів з номерами від k1 до k2 для кожного рядка:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Рядок {i + 1}: {sums[i]}");
            }
        }
        else
        {
            Console.WriteLine("Неправильний вибір.");
        }
    }

    // Метод для піднесення одновимірного масиву до степеня
    static double[,] PowerOfArray(double[,] array, int power)
    {
        int n = array.GetLength(0);

        double[,] result = new double[n, n];

        // Ініціалізуємо result як одиничну матрицю
        for (int i = 0; i < n; i++)
        {
            result[i, i] = 1;
        }

        // Піднесення до степеня за допомогою розкладання на добуток
        while (power > 0)
        {
            if (power % 2 == 1)
            {
                result = MultiplyArrays(result, array);
            }
            array = MultiplyArrays(array, array);
            power /= 2;
        }

        return result;
    }

    // Метод для обчислення матричного добутку двовимірних масивів
    static double[,] MultiplyArrays(double[,] matrix1, double[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int cols2 = matrix2.GetLength(1);

        double[,] result = new double[rows1, cols2];

        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                for (int k = 0; k < cols1; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        return result;
    }

    // Метод для виведення двовимірного масиву на екран
    static void PrintArray(double[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{array[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}
