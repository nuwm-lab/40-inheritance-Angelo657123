using System;

class Rectangle
{
    // Поля для координат
    public double B1 { get; set; }
    public double A1 { get; set; }
    public double B2 { get; set; }
    public double A2 { get; set; }

    // Метод для встановлення значень
    public void SetCoefficients(double b1, double a1, double b2, double a2)
    {
        B1 = b1;
        A1 = a1;
        B2 = b2;
        A2 = a2;
    }

    // Метод для виведення значень
    public void DisplayCoefficients()
    {
        Console.WriteLine($"Rectangle bounds: B1={B1}, A1={A1}, B2={B2}, A2={A2}");
    }

    // Метод для перевірки, чи належить точка прямокутнику
    public bool ContainsPoint(double x, double y)
    {
        return B1 <= x && x <= A1 && B2 <= y && y <= A2;
    }
}

class Parallelepiped : Rectangle
{
    // Додаткові координати для паралелепіпеда
    public double C1 { get; set; }
    public double C2 { get; set; }

    // Перевантажений метод для встановлення значень
    public void SetCoefficients(double b1, double a1, double b2, double a2, double c1, double c2)
    {
        base.SetCoefficients(b1, a1, b2, a2);
        C1 = c1;
        C2 = c2;
    }

    // Перевантажений метод для перевірки, чи належить точка
    public bool ContainsPoint(double x, double y, double z)
    {
        return base.ContainsPoint(x, y) && C1 <= z && z <= C2;
    }

    // Перевантажений метод для виведення
    public new void DisplayCoefficients()
    {
        base.DisplayCoefficients();
        Console.WriteLine($"C1={C1}, C2={C2}");
    }
}

class Program
{
    static void Main()
    {
        // Створення прямокутника
        Rectangle rect = new Rectangle();
        rect.SetCoefficients(1, 5, 2, 6);
        rect.DisplayCoefficients();
        Console.WriteLine($"Point (3,4) in rectangle: {rect.ContainsPoint(3, 4)}");

        // Створення паралелепіпеда
        Parallelepiped para = new Parallelepiped();
        para.SetCoefficients(1, 5, 2, 6, 0, 10);
        para.DisplayCoefficients();
        Console.WriteLine($"Point (3,4,5) in parallelepiped: {para.ContainsPoint(3, 4, 5)}");
    }
}