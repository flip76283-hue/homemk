using System;

struct Vector3D
{
    public double X;
    public double Y;
    public double Z;

    public Vector3D(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Vector3D Multiply(double number)
    {
        return new Vector3D(X * number, Y * number, Z * number);
    }

    public Vector3D Add(Vector3D other)
    {
        return new Vector3D(X + other.X, Y + other.Y, Z + other.Z);
    }

    public Vector3D Subtract(Vector3D other)
    {
        return new Vector3D(X - other.X, Y - other.Y, Z - other.Z);
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }
}

struct DecimalNumber
{
    public long Value;

    public DecimalNumber(long value)
    {
        Value = value;
    }

    public string ToBinary()
    {
        return Convert.ToString(Value, 2);
    }

    public string ToOctal()
    {
        return Convert.ToString(Value, 8);
    }

    public string ToHexadecimal()
    {
        return Convert.ToString(Value, 16).ToUpper();
    }
}

struct RGBColor
{
    public int R;
    public int G;
    public int B;

    public RGBColor(int r, int g, int b)
    {
        R = Math.Clamp(r, 0, 255);
        G = Math.Clamp(g, 0, 255);
        B = Math.Clamp(b, 0, 255);
    }

    public string ToHex()
    {
        return $"#{R:X2}{G:X2}{B:X2}";
    }

    public string ToHSL()
    {
        double r = R / 255.0;
        double g = G / 255.0;
        double b = B / 255.0;

        double max = Math.Max(r, Math.Max(g, b));
        double min = Math.Min(r, Math.Min(g, b));
        double delta = max - min;

        double h = 0;
        double s = 0;
        double l = (max + min) / 2.0;

        if (delta != 0)
        {
            s = delta / (1 - Math.Abs(2 * l - 1));

            if (max == r)
                h = 60 * (((g - b) / delta) % 6);
            else if (max == g)
                h = 60 * ((b - r) / delta + 2);
            else
                h = 60 * ((r - g) / delta + 4);

            if (h < 0)
                h += 360;
        }

        return $"HSL({h:F2}, {s * 100:F2}%, {l * 100:F2}%)";
    }

    public string ToCMYK()
    {
        double r = R / 255.0;
        double g = G / 255.0;
        double b = B / 255.0;

        double k = 1 - Math.Max(r, Math.Max(g, b));
        double c = 0;
        double m = 0;
        double y = 0;

        if (k < 1)
        {
            c = (1 - r - k) / (1 - k);
            m = (1 - g - k) / (1 - k);
            y = (1 - b - k) / (1 - k);
        }

        return $"CMYK({c * 100:F2}%, {m * 100:F2}%, {y * 100:F2}%, {k * 100:F2}%)";
    }
}

class Program
{
    static void Main()
    {
        // Task 1
        Vector3D vector1 = new Vector3D(2, 4, 6);
        Vector3D vector2 = new Vector3D(1, 3, 5);

        Console.WriteLine("Vector 1: " + vector1);
        Console.WriteLine("Vector 2: " + vector2);
        Console.WriteLine("Multiplication: " + vector1.Multiply(3));
        Console.WriteLine("Addition: " + vector1.Add(vector2));
        Console.WriteLine("Subtraction: " + vector1.Subtract(vector2));

        // Task 2
        DecimalNumber number = new DecimalNumber(255);

        Console.WriteLine("\nDecimal number: " + number.Value);
        Console.WriteLine("Binary: " + number.ToBinary());
        Console.WriteLine("Octal: " + number.ToOctal());
        Console.WriteLine("Hexadecimal: " + number.ToHexadecimal());

        // Task 3
        RGBColor color = new RGBColor(255, 128, 64);

        Console.WriteLine("\nRGB: (" + color.R + ", " + color.G + ", " + color.B + ")");
        Console.WriteLine("HEX: " + color.ToHex());
        Console.WriteLine("HSL: " + color.ToHSL());
        Console.WriteLine("CMYK: " + color.ToCMYK());
    }
}