using System.ComponentModel.DataAnnotations.Schema;

namespace cam_api.Dtos.AssignedAsset
{
    public class AddAssignedAssetDto
    {
        public int? AssetId { get; set; }
        public int? EmployeeId { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? Remarks { get; set; } = string.Empty;
        public DateTime DateAssigned { get; set; }
    }
}