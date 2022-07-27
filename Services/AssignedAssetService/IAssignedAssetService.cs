using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cam_api.Dtos.AssignedAsset;

namespace cam_api.Services.AssignedAssetService
{
    public interface IAssignedAssetService
    {
        Task<ServiceResponse<List<GetAssignedAssetDto>>> GetAllAssignAssets();
        Task<ServiceResponse<GetAssignedAssetDto>> GetAssignAssetById(int id);
        Task<ServiceResponse<List<GetAssignedAssetDto>>> AddAssignAsset(AddAssignedAssetDto newAssignAsset);
        Task<ServiceResponse<GetAssignedAssetDto>> UpdateAssignAsset(UpdateAssignedAssetDto updatedAssignAsset);
        Task<ServiceResponse<List<GetAssignedAssetDto>>> DeleteAssignAsset(int id);
    }
}