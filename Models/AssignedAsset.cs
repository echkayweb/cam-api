using System.ComponentModel.DataAnnotations;

namespace cam_api.Models
{
    public class AssignedAsset
    {
        [Key]
        public int AssignedAssetId { get; set; }

        public int AssetId { get; set; }
        public Asset? Asset { get; set; }

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public string? Remarks { get; set; } = "";

        public DateTime DateAssigned { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}