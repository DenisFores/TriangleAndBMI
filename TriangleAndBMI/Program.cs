using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== МЕНЮ ===");
            Console.WriteLine("1. Периметр треугольника");
            Console.WriteLine("2. Индекс массы тела (ИМТ)");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите пункт: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CalculateTriangle();
                    break;

                case "2":
                    CalculateBodyMassIndex();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Неверный выбор!");
                    Pause();
                    break;
            }
        }
    }

    //  ТРЕУГОЛЬНИК 
    static void CalculateTriangle()
    {
        Console.Clear();
        Console.WriteLine("=== Периметр треугольника ===");

        double a = ReadDouble("Введите сторону a: ");
        double b = ReadDouble("Введите сторону b: ");
        double c = ReadDouble("Введите сторону c: ");

        if (!IsTriangleValid(a, b, c))
        {
            Console.WriteLine("\nТакого треугольника не существует!");
        }
        else
        {
            double perimeter = CalculateTrianglePerimeter(a, b, c);
            Console.WriteLine($"\nПериметр: {perimeter:F2}");
        }

        Pause();
    }

    static bool IsTriangleValid(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }

    static double CalculateTrianglePerimeter(double a, double b, double c)
    {
        return a + b + c;
    }

    //  ИМТ 
    static void CalculateBodyMassIndex()
    {
        Console.Clear();
        Console.WriteLine("=== Индекс массы тела ===");

        double weight = ReadDouble("Введите вес (кг): ");
        double height = ReadDouble("Введите рост (м): ");

        if (height <= 0)
        {
            Console.WriteLine("\nРост должен быть больше 0!");
        }
        else
        {
            double bmi = CalculateBMI(weight, height);
            string category = GetBMICategory(bmi);

            Console.WriteLine($"\nИМТ: {bmi:F2}");
            Console.WriteLine($"Категория: {category}");
        }

        Pause();
    }

    static double CalculateBMI(double weight, double height)
    {
        return weight / (height * height);
    }

    static string GetBMICategory(double bmi)
    {
        if (bmi < 18.5)
            return "Недостаточный вес";
        else if (bmi < 25)
            return "Норма";
        else if (bmi < 30)
            return "Избыточный вес";
        else
            return "Ожирение";
    }

    //  ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ 
    static double ReadDouble(string message)
    {
        double value;

        while (true)
        {
            Console.Write(message);

            if (double.TryParse(Console.ReadLine(), out value))
                return value;

            Console.WriteLine("Ошибка! Введите число.");
        }
    }

    static void Pause()
    {
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }
}