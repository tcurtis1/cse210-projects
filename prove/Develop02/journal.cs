using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;

    // Constructor initializes the list of entries
    public Journal()
    {
        _entries = new List<Entry>(); // instantiating a new List of entries.  Keeping track of all entries here while program is running.  
    }

    // Add a new entry to the journal
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Display all entries in the journal
    public void DisplayAll()
    {
        Console.Clear();
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.");
        }
        
        else
        {
            int count = 1; // lets keep track of entries with this variable
            Console.WriteLine("---------- Begin journal Entries -----------------");
            foreach (var entry in _entries)
            {
                Console.WriteLine($"Entry # {count}");
                entry.Display();
                count++;
            }
            Console.WriteLine("---------- END journal Entries -------------------");
        }
        
    }

    // Save journal to a file
    public void SaveToFile(string fileName)
    {
        //using streamwriter -- i saw an example of this and it seems to do the job :-)
        //probably should use a try catch block here but i ran out of time.
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in _entries) // iterate through all the entries
            {
                writer.WriteLine(entry.ToString()); //write the entries to our streamwriter instance and flush to disk.
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    // Load journal from a file
    public void LoadFromFile(string fileName)
    {
        _entries.Clear();
        if (File.Exists(fileName)) // gonna at least check if file exists.
        {
            //again probbly should use a try catch block for this -- no time.
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null) // read line until we reach the end.
                {
                    Entry entry = Entry.FromString(line);
                    _entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
