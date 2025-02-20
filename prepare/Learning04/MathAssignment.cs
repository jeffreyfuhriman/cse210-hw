using System;

public class MathAssignment : Assignment
{
    private string _textbookSection = "";
    private string _problems = "";
    public string GetSection()
    {
        return _textbookSection;
    }
    public void SetSection(string textbookSection)
    {
        _textbookSection = textbookSection;
    }
    public string GetProblems()
    {
        return _problems;
    }
    public void SetProblems(string problems)
    {
        _problems = problems;
    }
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}