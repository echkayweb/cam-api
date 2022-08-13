using cam_api.Dtos.AssetDto;

namespace cam_api.Services.AssetService
{
    public interface IAssetService
    {
        Task<ServiceResponse<List<GetAssetDto>>> GetAllAssets();
        Task<ServiceResponse<GetAssetDto>> GetAssetById(int id);
        Task<ServiceResponse<List<GetAssetDto>>> AddAsset(AddAssetDto newAsset);
        Task<ServiceResponse<GetAssetDto>> UpdateAsset(int id, UpdateAssetDto updatedAsset);
        Task<ServiceResponse<List<GetAssetDto>>> DeleteAsset(int id);
    }
}