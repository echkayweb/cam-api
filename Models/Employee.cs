using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cam_api.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

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

        [Column(TypeName = "Date")]
        public DateTime DOJ { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? EOJ { get; set; }

        public long Phone { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Email { get; set; } = string.Empty;
        public List<Asset>? Assets { get; set; }
    }
}