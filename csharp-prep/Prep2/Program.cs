using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Please enter your grade percentage: ");
        int gradePercent = int.Parse(Console.ReadLine());
        string letter;
        if (gradePercent >= 90) {
            letter = "A";
        }
        else if (gradePercent >=80) {
            letter = "B";
        }
        else if (gradePercent >=70) {
            letter = "C";
        }
        else if (gradePercent >=60) {
            letter = "D";
        }
        else {
            letter = "F";
        }
        
        Console.WriteLine($"Your grade is: {letter}");
        if(letter == "D" || letter == "F") {
            Console.WriteLine("Better work harder next time you have FAILED!");
        }
        else {
            Console.WriteLine("Congrats you have passed!");
        }

    }
}