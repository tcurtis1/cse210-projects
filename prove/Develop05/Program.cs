using System;

class Program
{
    static void Main(string[] args)
    {
        // Main menu in while loop.
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start Imagery activity");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1": activity = new BreathingActivity(); break;
                case "2": activity = new ReflectingActivity(); break;
                case "3": activity = new ListingActivity(); break;
                case "4": activity = new GuidedImageryActivity(); break;
                case "5": return;
                default: Console.WriteLine("Invalid choice. Please try again."); continue;
            }

            activity.DisplayStartingMessage();
            if (activity is BreathingActivity breathActivity) breathActivity.Run();
            else if (activity is ReflectingActivity reflectActivity) reflectActivity.Run();
            else if (activity is ListingActivity listActivity) listActivity.Run();
            else if (activity is GuidedImageryActivity guideImageActivity) guideImageActivity.Run();
            activity.DisplayEndingMessage();
        }
    }
}