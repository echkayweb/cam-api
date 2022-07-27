using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cam_api.Models
{
    public class AssignedAsset
    {
        [Key]
        public int AssignedAssetId { get; set; }
        public Asset? Asset { get; set; }
        public Employee? Employee { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Remarks { get; set; } = "";
        [Column(TypeName = "Date")]
        public DateTime DateAssigned { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? DateReturned { get; set; }
    }
}