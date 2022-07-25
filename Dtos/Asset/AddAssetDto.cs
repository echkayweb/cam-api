using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cam_api.Dtos.Asset
{
    public class AddAssetDto
    {
        [Column(TypeName = "nvarchar(100)")]
        public string AssetName { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(30)")]
        public string AssetModel { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(30)")]
        public string AssetSerialNumber { get; set; } = string.Empty;
    }
}