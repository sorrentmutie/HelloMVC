namespace DemoCorso.Core.Students
{

    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Grade? Grade { get; set; }

        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!; 
    }
}