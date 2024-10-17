using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment myAssignment = new Assignment();
        MathAssignment myMathAssignment = new MathAssignment("Robert Rodriquez","Fractions","7.3", "8-19");
        WritingAssignment myWritingAssignment = new WritingAssignment("Mary Waters","European History", "The Cause of World War II");
        Console.WriteLine($"{myAssignment.GetSummary()}");
        Console.WriteLine($"{myMathAssignment.GetHomeWorkList()}");
        Console.WriteLine($"{myWritingAssignment.GetWritingInformation()}");
    }
}