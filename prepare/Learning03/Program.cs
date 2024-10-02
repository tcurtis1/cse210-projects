using System;

class Program
{

    static void Main()
    {

        Fraction myFraction = new Fraction(1);
        Fraction myFraction1 = new Fraction(5);
        Fraction myFraction2 = new Fraction(3,4);
        Fraction myFraction3 = new Fraction(1,3);
        //Console.WriteLine($"Fraction 1 is: {myFraction.GetTop()}/{myFraction.GetBottom()}");
        
        Console.WriteLine($"{myFraction.GetFractionString()}");
        Console.WriteLine($"{myFraction.GetDecimalValue()}");
        Console.WriteLine($"{myFraction1.GetFractionString()}");
        Console.WriteLine($"{myFraction1.GetDecimalValue()}");
        Console.WriteLine($"{myFraction2.GetFractionString()}");
        Console.WriteLine($"{myFraction2.GetDecimalValue()}");
        Console.WriteLine($"{myFraction3.GetFractionString()}");
        Console.WriteLine($"{myFraction3.GetDecimalValue():0.0000000000000000}");
        
        //Console.WriteLine($"Fraction 2 is: {myFraction1.GetTop()}/{myFraction1.GetBottom()}");
        //Console.WriteLine($"Fraction 3 is: {myFraction2.GetTop()}/{myFraction2.GetBottom()}");
        //Console.WriteLine($"Fraction 4 is: {myFraction3.GetTop()}/{myFraction3.GetBottom()}");
    }
}
