using System;

class Program
{
    static void Main()
    {
        // Prompt the user to enter the coefficients
        Console.WriteLine("Enter the coefficient a (a should not be zero): ");
        double a;
        while (!double.TryParse(Console.ReadLine(), out a) || a == 0)
        {
            Console.WriteLine("Coefficient a cannot be zero. Please enter a valid value for a: ");
        }

        Console.WriteLine("Enter the coefficient b: ");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the coefficient c: ");
        double c = double.Parse(Console.ReadLine());

        // Find the roots and the type of roots
        var (roots, rootType) = FindRoots(a, b, c);

        // Display the results
        Console.WriteLine($"The quadratic equation with coefficients a={a}, b={b}, c={c} has {rootType}.");
        Console.WriteLine($"The roots are: {string.Join(" and ", roots)}");
    }

    static (string[], string) FindRoots(double a, double b, double c)
    {
        // Calculate the discriminant
        double discriminant = b * b - 4 * a * c;
        string rootType;
        string[] roots;

        if (discriminant > 0)
        {
            // Two distinct real roots
            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            roots = new string[] { root1.ToString(), root2.ToString() };
            rootType = "two distinct real roots";
        }
        else if (discriminant == 0)
        {
            // One real root (repeated root)
            double root = -b / (2 * a);
            roots = new string[] { root.ToString() };
            rootType = "one repeated real root";
        }
        else
        {
            // Two complex roots
            double realPart = -b / (2 * a);
            double imaginaryPart = Math.Sqrt(-discriminant) / (2 * a);
            roots = new string[] 
            { 
                $"{realPart} + {imaginaryPart}i", 
                $"{realPart} - {imaginaryPart}i" 
            };
            rootType = "two complex roots";
        }

        return (roots, rootType);
    }
}
