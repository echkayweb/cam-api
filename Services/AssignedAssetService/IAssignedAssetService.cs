using cam_api.Dtos.AssignedAsset;

namespace cam_api.Services.AssignedAssetService
{
    public interface IAssignedAssetService
    {
        Task<ServiceResponse<List<GetAssignedAssetDto>>> GetAllAssignedAssets();
        Task<ServiceResponse<GetAssignedAssetDto>> GetAssignedAssetById(int id);
        Task<ServiceResponse<List<GetAssignedAssetDto>>> AddAssignedAsset(AddAssignedAssetDto newAssignAsset);
        Task<ServiceResponse<GetAssignedAssetDto>> UpdateAssignedAsset(UpdateAssignedAssetDto updatedAssignAsset);
        Task<ServiceResponse<List<GetAssignedAssetDto>>> DeleteAssignedAsset(int id);
    }
}