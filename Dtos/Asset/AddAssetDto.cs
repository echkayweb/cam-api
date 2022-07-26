namespace cam_api.Dtos.Asset
{
    public class AddAssetDto
    {
        public string AssetName { get; set; } = string.Empty;
        public string AssetModel { get; set; } = string.Empty;
        public string AssetSerialNumber { get; set; } = string.Empty;
    }
}