using System;

class Program
{
    private static List<Video> _myMovieList;
    
    static void Main(string[] args)
    {
        List<Video> _myMovieList = new List<Video>();
        Video myVideo = new Video("Aliens3","Roger More", 140);
        myVideo.AddComment("John", "Best movie ever!!");
        myVideo.AddComment("Joe Namath", "I didn't like the ending!");
        myVideo.AddComment("Jarron", "I can't wait for Aliens4!");
        
        _myMovieList.Add(myVideo);

        Video myVideo2 = new Video("Cars2","Bill Jasper", 130);
        myVideo2.AddComment("Carrie", "I liked the movie but too much cheese");
        myVideo2.AddComment("William", "Kids movie - i thought it was an adult movie");
        myVideo2.AddComment("Suzette", "It was hilarious!  I loved it!");
        
        _myMovieList.Add(myVideo2);

        Video myVideo3 = new Video("Star Trek Into the Deep","Bob Done", 230);
        myVideo3.AddComment("Indigo", "Great special effects -- too long");
        myVideo3.AddComment("Tom", "I was expecting more high tech gadgets and cool futuristic content");
        myVideo3.AddComment("Luke Penze", "Well done!  Great story!  Another classic!");
        
        _myMovieList.Add(myVideo3);
        Console.Clear();
        foreach (var movie in _myMovieList)
        {
            Console.WriteLine("\n");
            movie.DisplayDetails();
        }
    }
    

}