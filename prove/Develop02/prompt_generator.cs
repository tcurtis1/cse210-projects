using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts;

    // Constructor initializes the list of prompts
    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I worked with today?",
            "What was the best thing to happen to me today?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today and Why?",
            "If I had one thing I could do over today, what would it be?",
            "What impressions did I receive from my prayers today?"
        };
    }

    // Get a random prompt from the list
    public string GetRandomPrompt()
    {
        //Random test = new Random();
        //Console.WriteLine($"random number: {test.ToString}");
        Random random = new Random();
        int index = random.Next(_prompts.Count); //set range of random number within number of prompts
        return _prompts[index]; // return prompt using random index 
    }
}
