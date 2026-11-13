using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabDb.Models
{
    [Table("Employees")]
    public class Employee
    {
        // EmpId (primary key), EmpName, Department, Salary, ExperienceYears, JoinedAt
        public class NotFutureDateAttribute : ValidationAttribute
        {
            public override bool IsValid(object? value)
            {
                if (value is DateTime date)
                {
                    return date <= DateTime.Today;
                }

                return false;
            }
        }

        [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Name must be between 3 and 50 characters")]
        public string? EmpName { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [StringLength(30)]
        public string? Department { get; set; }

        [Range(10000, 1000000,
            ErrorMessage = "Salary must be between 10000 and 1000000")]
        public double Salary { get; set; }

        [Range(0, 50,
            ErrorMessage = "Experience must be between 0 and 50 years")]
        public int ExperienceYears { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [NotFutureDate(ErrorMessage = "Joined date cannot be in the future.")]
        public DateTime JoinedAt { get; set; }
    }
}