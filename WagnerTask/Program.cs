// See https://aka.ms/new-console-template for more information
using System;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        Console.WriteLine("Coordinates of 3 points in 2-dimensional coordinate system in C#\r");
        Console.WriteLine("-----------------------------Agata Wagner-----------------------\n");

        //Declare variables and then initialize to zero
        double x1, y1, x2, y2, x3, y3;

        // Ask the user to type the coordinate x of dot A
        Console.WriteLine("Type the coordinate x of dot A and then press Enter");
        x1 = Convert.ToDouble(Console.ReadLine());

        // Ask the user to type the coordinate y of dot A
        Console.WriteLine("Type the coordinate y of dot A and then press Enter");
        y1 = Convert.ToDouble(Console.ReadLine());

        // Ask the user to type the coordinate x of dot B
        Console.WriteLine("Type the coordinate x of dot B and then press Enter");
        x2 = Convert.ToDouble(Console.ReadLine());

        // Ask the user to type the coordinate y of dot B
        Console.WriteLine("Type the coordinate y of dot B and then press Enter");
        y2 = Convert.ToDouble(Console.ReadLine());

        // Ask the user to type the coordinate x of dot C
        Console.WriteLine("Type the coordinate x of dot C and then press Enter");
        x3 = Convert.ToDouble(Console.ReadLine());

        // Ask the user to type the coordinate y of dot C
        Console.WriteLine("Type the coordinate y of dot C and then press Enter");
        y3 = Convert.ToDouble(Console.ReadLine());

        // Name sides of triangle
        Point a = new Point(x1, y1);    
        Point b = new Point(x2, y2);
        Point c = new Point(x3, y3);    

        Triangle triangle = new Triangle(a, b, c);

        Console.WriteLine("Side A: " + triangle.getSideA());
        Console.WriteLine("Side B: " + triangle.getSideB());
        Console.WriteLine("Side C: " + triangle.getSideC());
        Console.WriteLine("Perimeter:" + triangle.getPerimeter());
        Console.WriteLine("Parity numbers in range from 0 to triangle perimeter:");
        Program.printEvenNumbers(triangle.getPerimeter());

        if (!triangle.isTriangle())
        {
            Console.WriteLine("Given points doesnt represent triangle.");
            return;
        } 

        if(triangle.isEquiliteral())
        {
            Console.WriteLine("This triangle IS equiliteral.");
        } 
        else
        {
            Console.WriteLine("This triangle is NOT equiliteral.");
        }

        if(triangle.isRight())
        {
            Console.WriteLine("This triangle IS right.");
        }
        else
        {
            Console.WriteLine("This triangle is NOT right.");
        }
    }
    static void printEvenNumbers(double perimeter)
    {
        for (int i = 0; i <= Math.Floor(perimeter); i=i+2) // i to znaczy od ilu będziemy liczyć czyli od 0 / i++ oznacza i + 1
        {
            Console.WriteLine(i);
        }  
    }
}

class Point
{
    private double x, y;
    
    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double getX() { return x; } 
    public double getY() { return y; }

    public double calculateDistance(Point p)
    {
        return Math.Sqrt(Math.Pow(p.x - this.x, 2) + Math.Pow(p.y - this.y, 2));
    }

}

class Triangle
{
    private double sidea;
    private double sideb;
    private double sidec;

    private double precision = 0.00001;

    public Triangle(Point a, Point b, Point c)
    {
        sidea = Math.Round(a.calculateDistance(b), 8);
        sideb = Math.Round(a.calculateDistance(c), 8);
        sidec = Math.Round(b.calculateDistance(c), 8);
    }

    public double getSideA() { return sidea; }
    public double getSideB() { return sideb; }
    public double getSideC() { return sidec; }

    public bool isTriangle()
    {
        if (sidea >= sideb && sidea >= sidec)
        {
            return Math.Abs(sidea - sideb - sidec) > precision;
        }

        else if (sideb >= sidea && sideb >= sidec)
        {
            return Math.Abs(sideb - sidea - sidec) > precision;
        }

        else
        {
            return Math.Abs(sidec - sidea - sideb) > precision;
        }
    }

    public bool isEquiliteral()
    {
        return sidea == sideb && sideb == sidec;
    }

    public bool isIsosceles()
    {
        return sidea == sideb || sidea == sidec || sideb == sidec;
    }

    public bool isRight()
    {
        if (sidea >= sideb && sidea >= sidec)
        {
            return Math.Pow(sidea, 2) - (Math.Pow(sideb, 2) + Math.Pow(sidec, 2)) <= precision;
        }

        else if (sideb >= sidea && sideb >= sidec)
        {
            return Math.Pow(sideb, 2) - (Math.Pow(sidea, 2) + Math.Pow(sidec, 2)) <= precision;
        }

        else
        {
            return Math.Pow(sidec, 2) - (Math.Pow(sidea, 2) + Math.Pow(sideb, 2)) <= precision;
        }
    }

    public double getPerimeter()
    {
        return this.sidea + this.sideb + this.sidec;
    }
   
}
