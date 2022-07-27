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

        public bool AssetAvailable { get; set; } = true;

        [ForeignKey("Employee")]
        public int? AssetAssignedTo { get; set; }
        public Employee? Employee { get; set; }
    }
}