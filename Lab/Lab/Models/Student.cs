namespace Lab.Models
{
    public class Student
    {
        public int ? Id { get; set; }
        public string Name { get; set; }
        public required string Email { get; set; }
    }
}
