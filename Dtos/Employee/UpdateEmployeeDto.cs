using System.ComponentModel.DataAnnotations;

namespace cam_api.Dtos.EmployeeDto
{
    public class UpdateEmployeeDto : IValidatableObject
    {
        public string EmployeeName { get; set; } = string.Empty;
        public string HouseNumber { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int Pincode { get; set; }
        public string Country { get; set; } = string.Empty;
        public DateTime? DOJ { get; set; }
        public DateTime? EOJ { get; set; }
        [Phone]
        public string Phone { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string Mobile { get; set; } = string.Empty;
        public int Salary { get; set; }
        public string ImageName { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DOJ?.Year < 2000)
                yield return new ValidationResult("Joining data is incorrect.");
            if (DOJ?.Date > DateTime.Now.Date)
                yield return new ValidationResult("Invalid Date");
            if (EOJ?.Date < DOJ?.Date)
                yield return new ValidationResult("Leaving date can't be before joining.");
            if (EOJ?.Date > DateTime.Now.Date)
                yield return new ValidationResult("Invalid Date");
        }
    }
}