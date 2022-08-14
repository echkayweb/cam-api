using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cam_api.Dtos.EmployeeDto
{
    public class AddEmployeeDto : IValidatableObject
    {
        [Column(TypeName = "nvarchar(100)")]
        public string EmployeeName { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(20)")]
        public string HouseNumber { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(50)")]
        public string Location { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(20)")]
        public string City { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(20)")]
        public string State { get; set; } = string.Empty;
        public int Pincode { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Country { get; set; } = string.Empty;
        public DateTime DOJ { get; set; }
        [Phone(ErrorMessage = "Phone is not valid.")]
        public string Phone { get; set; } = string.Empty;
        [EmailAddress(ErrorMessage = "Email is not valid.")]
        public string Email { get; set; } = string.Empty;
        [Phone(ErrorMessage = "Mobile is not valid.")]
        public string Mobile { get; set; } = string.Empty;
        [Range(minimum: 20000, maximum: 200000, ErrorMessage = "Salary does not fall into allowed range.")]
        public int Salary { get; set; }
        public string? ImageName { get; set; }
        public IFormFile? ImageFile { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DOJ.Year < 2000)
                yield return new ValidationResult("Joining data is incorrect.");
            if (DOJ.Date > DateTime.Now.Date)
                yield return new ValidationResult("Invalid Date");
        }
    }
}