using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cam_api.Dtos.Asset
{
    public class GetAssetDto
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

        public int? AssetAssignedTo { get; set; }
        public Employee? Employee { get; set; }
    }
}