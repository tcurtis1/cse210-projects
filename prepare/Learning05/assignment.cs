using System;

class Assignment
{
    protected string _studentName;
    protected string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public Assignment()
    {
        _studentName = "unassigned";
        _topic = "unassigned";
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}