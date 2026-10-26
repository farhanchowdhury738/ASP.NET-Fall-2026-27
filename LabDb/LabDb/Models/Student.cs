using System.ComponentModel.DataAnnotations.Schema;

namespace LabDb.Models
{
    [Table("users")]
    public class Student
    {
        public int id { get; set; }


        public string? name { get; set; }


        public string? department { get; set; }


        public double cgpa { get; set; }
    }
}
