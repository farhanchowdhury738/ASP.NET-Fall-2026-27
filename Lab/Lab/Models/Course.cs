
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Lab.Models
{
    // Course Name Validation
    public class AllowedCourseName : ValidationAttribute
    {
        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            string name = value.ToString()!.Trim();

            if (name.All(char.IsDigit))
            {
                return new ValidationResult(
                    ErrorMessage ?? "Course name cannot contain only numbers");
            }

            return ValidationResult.Success;
        }
    }

    // Course Hours Validation
    public class AllowedCourseHours : ValidationAttribute
    {
        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (!int.TryParse(value.ToString(), out int hours))
                return new ValidationResult("Invalid course hours");

            if (hours < 1 || hours > 4)
            {
                return new ValidationResult(
                    ErrorMessage ?? "Course hours must be 1, 2, 3, or 4");
            }

            return ValidationResult.Success;
        }
    }

    // Course Code Validation
    public class AllowedCoursecode : ValidationAttribute
    {
        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            string code = value.ToString()!;

            if (!Regex.IsMatch(code, @"^[A-Z]{3}\d{4}$"))
            {
                return new ValidationResult(
                    ErrorMessage ?? "Course code must be 3 uppercase letters followed by 4 digits");
            }

            return ValidationResult.Success;
        }
    }

    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, MinimumLength = 3,
            ErrorMessage = "Name must be between 3 and 60 characters")]
        [AllowedCourseName]
        public string Name { get; set; } = string.Empty;


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Course code is required")]
        //[AllowedCoursecode]
        public string courseCode { get; set; } = string.Empty;


        [Required(ErrorMessage = "Course hours are required")]
        [AllowedCourseHours]
        public int CourseHours { get; set; }


        [Required(ErrorMessage = "Semester fee is required")]
        [Range(typeof(decimal), "5000", "50000",
            ErrorMessage = "Fee must be between 5000 and 50000")]
        public decimal SemesterFee { get; set; }
    }
}
