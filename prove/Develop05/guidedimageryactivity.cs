using System;

public class GuidedImageryActivity : Activity
{
    private List<string> _scenarios = new List<string> {
        "Walking through a serene forest with the sound of leaves crunching underfoot and birds singing.",
        "Sitting on a quiet beach watching the waves gently crash on the shore as the sun sets.",
        "Floating on a cloud, feeling weightless and looking down at the world below.",
        // Add more scenarios here
    };

    public GuidedImageryActivity() : base("Guided Imagery", "This activity will transport you to a calming place through visualization, helping you to relax and reduce stress.") { }

    public void Run()
    {
        Random rand = new Random();
        string scenario = _scenarios[rand.Next(_scenarios.Count)];

        // Introduction to the imagery
        DisplayPrompt($"Imagine yourself in this setting: {scenario}");
        ShowSpinner(10); // Give them a moment to start visualizing

        // Guided visualization steps
        string[] steps = {
            "Notice the colors around you...",
            "Listen to the sounds in this place...",
            "Feel the texture of the ground beneath you...",
            "Breathe in the fresh air... notice any scents...",
            "Let your body relax with each breath you take here..."
        };

        foreach (var step in steps)
        {
            if ((DateTime.Now - DateTime.MinValue).TotalSeconds >= Duration) break;
            DisplayQuestion(step);
            ShowSpinner(15); // Allow time for visualization
        }

        // Closing the session
        Console.WriteLine("Slowly bring your awareness back to the room. When you're ready, open your eyes, feeling refreshed and calm.");
    }

    // These might not be necessary if you're using base class methods, but they're included for customization:
    public override void DisplayPrompt(string prompt)
    {
        Console.WriteLine($"\n{prompt}");
        Console.WriteLine("Close your eyes if you feel comfortable, and let's begin.");
    }

    public override void DisplayQuestion(string question)
    {
        Console.WriteLine($"\n{question}");
    }
}