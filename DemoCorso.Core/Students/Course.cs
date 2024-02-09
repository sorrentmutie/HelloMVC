﻿namespace DemoCorso.Core.Students;

public class Course
{
    public int CourseId { get; set; }
    public string? Title { get; set; }
    public int Credits { get; set; }
    public ICollection<Enrollment>? Enrollments { get; set; }
}