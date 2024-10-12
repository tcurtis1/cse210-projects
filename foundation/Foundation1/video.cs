using System.Dynamic;
using System.Net;
using System.Reflection;
using System.Transactions;

class Video
{
    private string _title;
    private string _author;
    private int _length;

    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public string GetVideoTitle()
    {
        return _title;
    }
    public string GetVideoAuthor()
    {
        return _author;
    }
    public int GetVideoLength()
    {
        return _length;
    }
    public int GetNumberOfComments()
    {
        return _comments.Count();
    }
    public void AddComment(string name, string comment)
    {
        
        Console.Clear();
        //Console.WriteLine("Enter the comment author's name: ");
        //tmpName = Console.ReadLine();
        //Console.WriteLine("Enter the comment: ");
        
        //tmpComment = Console.ReadLine();
        // Create a new Scripture object and add it to the list
            Comment newComment = new Comment(name, comment);
            _comments.Add(newComment);
    }
    public void DisplayDetails()
    {
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($"Video: {_title}\nAuthor: {_author}\nLength: {_length}");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("Comments:\n");
        foreach (Comment item in _comments)
        {
            Console.WriteLine($"\nAuthor: {item.GetCommentName()}");
            Console.WriteLine($"Comment: {item.GetCommentText()}");
        }
        
    }
}