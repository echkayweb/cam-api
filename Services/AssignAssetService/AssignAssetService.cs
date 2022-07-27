using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cam_api.Dtos.AssignAsset;

namespace cam_api.Services.AssignAssetService
{
    public class AssignAssetService : IAssignAssetService
    {
        public Task<ServiceResponse<List<GetAssignAssetDto>>> AddAssignAsset(AddAssignAssetDto newAssignAsset)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetAssignAssetDto>>> DeleteAssignAsset(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetAssignAssetDto>>> GetAllAssignAssets()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetAssignAssetDto>> GetAssignAssetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetAssignAssetDto>> UpdateAssignAsset(UpdateAssignAssetDto updatedAssignAsset)
        {
            throw new NotImplementedException();
        }
    }
}