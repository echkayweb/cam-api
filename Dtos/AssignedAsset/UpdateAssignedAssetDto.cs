using System.ComponentModel.DataAnnotations.Schema;

namespace cam_api.Dtos.AssignedAsset
{
    public class UpdateAssignedAssetDto
    {
        public int AssignedAssetId { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? Remarks { get; set; } = string.Empty;
        public DateTime DateAssigned { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}