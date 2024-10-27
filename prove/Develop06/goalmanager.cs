using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    DisplayPlayerInfo();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Your score: {_score} points");
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        string choice = Console.ReadLine();

        Console.Write("Enter the name of your goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter a short description of your goal: ");
        string description = Console.ReadLine();
        Console.Write("Enter the amount of points associated with this goal: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;
        switch (choice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("Enter the target completion count for this goal: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter the bonus points for reaching this target: ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine("Goal created successfully.");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Your goals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
        int index = int.Parse(Console.ReadLine()) - 1;
        
        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"You earned {pointsEarned} points!");

            // Check if the goal was a ChecklistGoal and display extra details
            if (_goals[index] is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"Current progress: {checklistGoal.GetAmountCompleted()}/{checklistGoal.GetTarget()} times");
                if (checklistGoal.IsComplete())
                {
                    Console.WriteLine($"Congratulations! You completed the checklist and earned an additional bonus of {checklistGoal.GetBonus()} points.");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score); // Write the score at the top
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation()); // Write each goal's string representation
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        _goals.Clear(); // Clear existing goals to load fresh data
        using (StreamReader reader = new StreamReader("goals.txt"))
        {
            _score = int.Parse(reader.ReadLine()); // Read the score

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Parse the line to identify the type of goal and its properties
                string[] parts = line.Split(':');
                string goalType = parts[0];
                string[] goalData = parts[1].Split(',');

                Goal goal = null;
                switch (goalType)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(goalData[0], goalData[1], int.Parse(goalData[2]));
                        if (bool.Parse(goalData[3])) ((SimpleGoal)goal).RecordEvent(); // Set as complete if true
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(goalData[0], goalData[1], int.Parse(goalData[2]));
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal(goalData[0], goalData[1], int.Parse(goalData[2]), int.Parse(goalData[3]), int.Parse(goalData[4]));
                        for (int i = 0; i < int.Parse(goalData[5]); i++) ((ChecklistGoal)goal).RecordEvent(); // Set completion count
                        break;
                }

                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
        }
        Console.WriteLine("Goals loaded successfully.");
    }
}
