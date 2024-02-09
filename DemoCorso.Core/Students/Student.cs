

namespace DemoCorso.Core.Students;

public class Student
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public ICollection<Enrollment>? Enrollments { get; set; }
}
