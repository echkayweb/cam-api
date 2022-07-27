using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cam_api.Dtos.AssignAsset
{
    public class UpdateAssignAssetDto
    {
        public int AssignedAssetId { get; set; }
        public Asset? Asset { get; set; }
        public Employee? Employee { get; set; }
        public string? Remarks { get; set; } = "";
        public DateTime DateAssigned { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}