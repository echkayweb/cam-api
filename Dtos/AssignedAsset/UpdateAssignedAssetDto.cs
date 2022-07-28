namespace cam_api.Dtos.AssignedAsset
{
    public class UpdateAssignedAssetDto
    {
        public int AssignedAssetId { get; set; }
        public int? AssetId { get; set; }
        public int? EmployeeId { get; set; }
        public string? Remarks { get; set; } = string.Empty;
        public DateTime DateAssigned { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}