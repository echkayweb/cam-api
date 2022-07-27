namespace cam_api.Dtos.Asset
{
    public class GetAssetDto
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; } = string.Empty;
        public string AssetModel { get; set; } = string.Empty;
        public string AssetSerialNumber { get; set; } = string.Empty;
        public bool AssetAvailable { get; set; } = true;
        public int? AssetAssignedTo { get; set; }
    }
}