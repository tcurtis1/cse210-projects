public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }
    public void Run()
    {
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            string breatheInText = "Breathe in... ";
            Console.Write(breatheInText);
            ShowCountDown(4);
            // Clear the line before writing the next text
            Console.Write("\r" + new string(' ', breatheInText.Length) + "\r");

            string breatheOutText = "Now breathe out... ";
            Console.Write(breatheOutText);
            ShowCountDown(6);
            // Clear the line again
            Console.Write("\r" + new string(' ', breatheOutText.Length) + "\r");
        }
    }
}
