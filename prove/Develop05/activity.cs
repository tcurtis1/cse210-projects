using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    protected string Name { get; set; }
    protected string Description { get; set; }
    protected int Duration { get; set; }

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {Name} Activity ---");
        Console.WriteLine(Description);
        Console.Write("How long, in seconds, would you like for this activity? ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
    }
    public virtual void DisplayPrompt(string prompt)
    {
        Console.WriteLine(prompt);
    }

    public virtual void DisplayQuestion(string question)
    {
        Console.WriteLine(question);
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!");
        ShowSpinner(5);
        Console.WriteLine($"You have completed another {Duration} seconds of the {Name} Activity.");
        ShowSpinner(5);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinnerChars = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds; i++)
        {
            foreach (var character in spinnerChars)
            {
                Console.Write(character);
                Thread.Sleep(250);
                // Easy way to go back a space and rewrite -- 
                Console.Write("\b \b"); // Erase the character
            }
        }
        Console.WriteLine(); // Move to next line after spinner is done
    }

    /* protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b \b"); // Erase the number by moving back and covering with spaces
        }
        Console.WriteLine(); // Clear the line after countdown
    } */
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            // I'm tyring yet another method for inline txt updating 
            // Save the current cursor position
            int left = Console.CursorLeft;
            int top = Console.CursorTop;

            
            Console.Write(i);

            // Wait for one second
            Thread.Sleep(1000);

            // Return to the saved cursor position to overwrite the number
            Console.SetCursorPosition(left, top);
        }
        // This will clear the last number displayed by overwriting it with spaces
        Console.Write(new string(' ', Console.WindowWidth.ToString().Length + 1));
        Console.SetCursorPosition(0, Console.CursorTop); // Reset cursor to start of the line for next output
    }
}