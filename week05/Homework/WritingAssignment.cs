using System;

public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        // Access student name from base using protected method
        string studentName = GetStudentName();
        return $"{_title} by {studentName}";
    }
}
