using System;

class Program
{
    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the Program!");
    }
    
    static string PromptUserName() {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber() {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }
    
    static int SquareNumber(int number) {
        return (number * number);
    }
    
    static void DisplayResults(string name, int number) {
        Console.WriteLine($"{name}, the square of your number is {number}");
    }

    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Prep5 World!");
        string name = "";
        int number = 0;
        int square = 0;

        DisplayWelcome();
        name = PromptUserName();
        number = PromptUserNumber();
        square = SquareNumber(number);
        DisplayResults(name,square);
    }
}