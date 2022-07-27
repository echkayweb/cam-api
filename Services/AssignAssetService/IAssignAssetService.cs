using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cam_api.Dtos.AssignAsset;

namespace cam_api.Services.AssignAssetService
{
    public interface IAssignAssetService
    {
        Task<ServiceResponse<List<GetAssignAssetDto>>> GetAllAssignAssets();
        Task<ServiceResponse<GetAssignAssetDto>> GetAssignAssetById(int id);
        Task<ServiceResponse<List<GetAssignAssetDto>>> AddAssignAsset(AddAssignAssetDto newAssignAsset);
        Task<ServiceResponse<GetAssignAssetDto>> UpdateAssignAsset(UpdateAssignAssetDto updatedAssignAsset);
        Task<ServiceResponse<List<GetAssignAssetDto>>> DeleteAssignAsset(int id);
    }
}