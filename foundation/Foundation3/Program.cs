using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of each activity
        var running = new Running(new DateTime(2024, 10, 28), 220, 26.4); // 3rd param distance in miles
        var cycling = new Cycling(new DateTime(2024, 10, 28), 100, 25);  // 3rd param speed in mph
        var swimming = new Swimming(new DateTime(2024, 10, 28), 30, 40); // 3rd param laps

        // Add them to a list of activities
        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        // Display summaries for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
