using System;

public class Assignment
{
    protected string _studentName = "";
    protected string _topic = "";

    public string GetName()
    {
        return _studentName;
    }
    public void SetName(string studentName)
    {
        _studentName = studentName;
    }
    public string GetTopic()
    {
        return _topic;
    }

    public void SetTopic(string topic)
    {
        _topic = topic;
    }
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}