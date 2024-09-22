using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        
        while (true) {
            Console.Write("Enter number: ");
            try {
                int newNumber = int.Parse(Console.ReadLine());   
                if (newNumber == 0) {
                    break;
                }
                else {
                    numbers.Add(newNumber);
                }
            }
            catch (FormatException) {

                Console.WriteLine("Error: Invalid input.  Please enter a numberical value.");
            }
        }

        //Find total value of list, largest item, and smallest item
        int total = 0;
        int largest = 1;
        int smallest = 1000000000;
        foreach (int item in numbers) {
            total += item;
            if (item > largest) {
                largest = item;
            }
            if (item < smallest) {
                smallest = item;
            }
        }

        //find average
        float average = 1.2f;
        average = total / numbers.Count;


        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest number is: {smallest}");
    }
}