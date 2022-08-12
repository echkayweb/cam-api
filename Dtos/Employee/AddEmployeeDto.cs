using System.ComponentModel.DataAnnotations;

namespace cam_api.Dtos.EmployeeDto
{
    public class AddEmployeeDto : IValidatableObject
    {
        public string EmployeeName { get; set; } = string.Empty;
        public string HouseNumber { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int Pincode { get; set; }
        public string Country { get; set; } = string.Empty;
        public DateTime DOJ { get; set; }
        [Phone]
        public long Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public long Mobile { get; set; }
        public int Salary { get; set; }
        public string? ImageName { get; set; }
        public IFormFile? ImageFile { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DOJ.Year < 2000)
                yield return new ValidationResult("Joining data is incorrect.");
        }
    }
}