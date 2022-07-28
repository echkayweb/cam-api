using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cam_api.Models
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string AssetName { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(30)")]
        public string AssetModel { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(30)")]
        public string AssetSerialNumber { get; set; } = string.Empty;
        public Availability AssetAvailable { get; set; } = Availability.Available;
        public int? AssignedAssetId { get; set; }
        public int? AssetAssignedTo { get; set; }

        [ForeignKey("AssetAssignedTo")]
        public Employee? Employee { get; set; }
        [ForeignKey("AssignedAssetId")]
        public AssignedAsset? AssignedAssets { get; set; }
    }
}