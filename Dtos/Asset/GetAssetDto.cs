namespace cam_api.Dtos.AssetDto
{
    public class GetAssetDto
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; } = string.Empty;
        public string AssetModel { get; set; } = string.Empty;
        public string AssetSerialNumber { get; set; } = string.Empty;
        public Availability AssetAvailable { get; set; } = Availability.Available;
        public int? AssignedAssetId { get; set; }
        public int? AssetAssignedTo { get; set; }
    }
}