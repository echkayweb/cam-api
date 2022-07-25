using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cam_api.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

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

        public DateTime? EOJ { get; set; }

        public long Phone { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Email { get; set; } = string.Empty;
    }
}