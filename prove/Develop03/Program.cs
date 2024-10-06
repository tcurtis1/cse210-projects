using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Scripture> scriptures = new List<Scripture>();

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("---- Scripture Memorization Menu ----");
            Console.WriteLine("1. Add a new scripture");
            Console.WriteLine("2. Memorize scripture");
            Console.WriteLine("3. Save scriptures to file");
            Console.WriteLine("4. Load scriptures from file");
            Console.WriteLine("5. Display scripture list");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddScripture();
                    break;
                case "2":
                    MemorizeScripture();
                    break;
                case "3":
                    SaveScriptures();
                    break;
                case "4":
                    LoadScriptures();
                    break;
                case "5":
                    DisplayCurrentScriptures();
                    break;
                case "6":
                    running = false;
                    break;
                
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }

    static void AddScripture()
    {
        // Prompt the user for scripture details
        Console.Write("Enter the book: ");
        string book = Console.ReadLine();

        Console.Write("Enter the chapter: ");
        int chapter = int.Parse(Console.ReadLine());

        Console.Write("Enter the starting verse: ");
        int verse = int.Parse(Console.ReadLine());

        Console.Write("Does this scripture have an ending verse? (y/n): ");
        string hasEndVerse = Console.ReadLine().ToLower();
        int endVerse = 0;
        
        if (hasEndVerse == "y" || hasEndVerse == "yes")
        {
            Console.Write("Enter the ending verse: ");
            endVerse = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter the scripture text: ");
        string scriptureText = Console.ReadLine();

        // Create the Reference object
        Reference reference = endVerse > 0 ? new Reference(book, chapter, verse, endVerse) : new Reference(book, chapter, verse);

        // Check if the scripture already exists (duplicate check)
        bool exists = scriptures.Any(s => s._reference.Displaytext() == reference.Displaytext());

        if (exists)
        {
            Console.WriteLine("This scripture already exists and won't be added.");
        }
        else
        {
            // Create a new Scripture object and add it to the list
            Scripture newScripture = new Scripture(false, reference, scriptureText); // Set _memorized to false initially
            scriptures.Add(newScripture);

            Console.WriteLine("Scripture added successfully!");
        }

        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }


    static void MemorizeScripture()
    {
        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures available to memorize. Add one first.");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            return;
        }

        Console.Clear();
        Console.WriteLine("Select a scripture to memorize:");
        int tmpCount = 1;
        foreach( var scriptItem in scriptures)
            {
                
                Console.WriteLine($"{tmpCount}. {scriptItem.DisplayScripture()}\n");

                tmpCount++;
            }

        Console.Write("Enter the number of the scripture to memorize: ");
        int selection;
        
        // Ensure valid selection
        while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > scriptures.Count)
        {
            Console.WriteLine("Invalid selection. Please try again.");
            Console.Write("Enter the number of the scripture to memorize: ");
        }
        
        
        Scripture selectedScripture = scriptures[selection-1];

        int numWordsToHide = 0;
        Console.Write("How many words should be hidden initially? ");
        
        // Ensure valid number input for hiding words
        while (!int.TryParse(Console.ReadLine(), out numWordsToHide) || numWordsToHide < 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        while (true)
        {
            Console.Clear();
            selectedScripture.HideWords(numWordsToHide);
            Console.WriteLine(selectedScripture.DisplayScripture());
            // if (selectedScripture.hiddenCount == selectedScripture._scriptureWords.Count)
            // {
            //     Console.WriteLine("Congratulations you have memorized all the words!");
            //     break;
            // }
            Console.Write("Hide more words? Enter a number, enter 'success', or 'quit' to stop: ");
            string response = Console.ReadLine();

            if (response.ToLower() == "quit")
            {
                break;
            }
            else if (response.ToLower() == "success" || response.ToLower() == "s")
            {
                Console.WriteLine("Congratulations!!  I will mark this scripture as memorized!");
                selectedScripture._memorized = true;
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
                selectedScripture.unHideWords();
                break;
            }

            // Handle empty input or invalid number
            if (string.IsNullOrWhiteSpace(response) || !int.TryParse(response, out numWordsToHide) || numWordsToHide < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid number or 'quit' to exit.");
                continue;
            }
            
        }
        selectedScripture.unHideWords();
    }


    static void SaveScriptures()
    {
        Console.Write("Enter the filename to save scriptures: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var scripture in scriptures)
            {
                // Save the memorized status (true/false), followed by the reference and scripture text
                string line = $"{scripture._memorized} {scripture._reference.Displaytext()}|{scripture.GetScriptureText()}";
                writer.WriteLine(line);
            }
        }

        Console.WriteLine("Scriptures saved successfully!");
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }
    static void DisplayCurrentScriptures()
    {
        int tmpCount = 1;
        Console.Clear();
        if(scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures entered or loaded.");
        }
        else
        {
            foreach( var scriptItem in scriptures)
            {
                
                Console.WriteLine($"{tmpCount}. {scriptItem.DisplayScripture()}\n");

                tmpCount++;
            }
        }
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();

    }
    static void LoadScriptures()
    // This is extra credit.   I ask the user for a file to load
    // which contains scriptures.
    // The file can be a path or just a file name.
    
        {
        Console.Write("Enter the filename to load scriptures: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            Console.ReadKey();
            return;
        }

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Split the line into memorized status, reference, and scripture text
                var parts = line.Split('|');
                string[] memorizeAndReference = parts[0].Split(' ', 2); // Split only on the first space
                bool memorized = bool.Parse(memorizeAndReference[0]);
                string referencePart = memorizeAndReference[1];
                string scriptureText = parts[1];

                // Split the reference part into book, chapter, and verse
                int colonIndex = referencePart.LastIndexOf(':');
                int spaceIndex = referencePart.LastIndexOf(' ', colonIndex - 1);

                string book = referencePart.Substring(0, spaceIndex);
                string chapterVerse = referencePart.Substring(spaceIndex + 1);

                string[] chapterVerseParts = chapterVerse.Split(new[] { ':', '-' });

                int chapter = int.Parse(chapterVerseParts[0]);
                int verse = int.Parse(chapterVerseParts[1]);
                int endVerse = chapterVerseParts.Length > 2 ? int.Parse(chapterVerseParts[2]) : 0;

                // Create the Reference object
                Reference reference = endVerse > 0 ? new Reference(book, chapter, verse, endVerse) : new Reference(book, chapter, verse);

                // Check if this scripture already exists based on the reference
                bool exists = scriptures.Any(s => s._reference.Displaytext() == reference.Displaytext());

                if (!exists)
                {
                    // Create the Scripture object with the memorized flag
                    Scripture scripture = new Scripture(memorized, reference, scriptureText);
                    scriptures.Add(scripture);
                }
            }
        }

        Console.WriteLine("Scriptures loaded successfully!");
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }

}
