using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.Write("What is the magic number? ");
        //int magic = int.Parse(Console.ReadLine());
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);
        int letsGo = 1;
        int guesses = 0;
        Console.WriteLine("A random number between 1 and 100 has been chosen");

        while (letsGo == 1) {
            
            Console.Write("What is your guess? ");
            int guess = int.Parse(Console.ReadLine());

            if (guess == number) {
                letsGo = 0;
            }
            else if (guess < number) {
                Console.WriteLine("Try a higher number next.");
            }
            else {
                Console.WriteLine("Try a lower number next.");
            }
            guesses ++;
        }
        Console.WriteLine($"Congrats you guessed the number {number} correctly after {guesses} guesses!");
    }
}