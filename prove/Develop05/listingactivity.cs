using System;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    public void Run()
    {
        GetRandomPrompt();
        var items = GetListFromUser();
        _count = items.Count;
        Console.WriteLine($"You listed {_count} items!");
    }

    public void GetRandomPrompt()
    {
        Random rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
    }

    public List<string> GetListFromUser()
    {
        var items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Enter item: ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item)) items.Add(item);
        }
        return items;
    }
}