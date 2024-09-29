using System;


public class Entry
{
    private string _date;
    private string _location;
    private string _promptText;
    private string _entryText;
    

    // Constructor to initialize the Entry object
    public Entry(string date, string mylocation, string promptText, string entryText)
    {
        _date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        _location = mylocation;
        _promptText = promptText;
        _entryText = entryText;
        
    }

    // Display the entry details
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Location: I am writing to you from {_location}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine("");
        //Console.WriteLine("---------------------------------------");
    }

    // Convert entry object to a string gonna override existing ToString class
    // Because this saves us a little time and follows best practices for object development :-)
    public override string ToString()
    {
        return $"{_date}|{_location}|{_promptText}|{_entryText}";
    }
    
    // Static method to create an Entry from a string (used for loading)
    public static Entry FromString(string entryString)
    {
        // learned this trick in c sharp to use type 'var' which allows the compiler to 
        // infer which variable type.  In this case it's an array of strings.  Kinda cool!
        var piece = entryString.Split('|');
        // Below is where we actually create the instance using the constructor above.  
        // There are three variables expected in teh constructor which we parsed above into 
        // a new 
        return new Entry(piece[0], piece[1], piece[2], piece[3]);
    }
}
