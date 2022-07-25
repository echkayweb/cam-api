using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cam_api.Dtos.Asset;

namespace cam_api.Services.AssetService
{
    public interface IAssetService
    {
        Task<ServiceResponse<List<GetAssetDto>>> GetAllAssets();
        Task<ServiceResponse<GetAssetDto>> GetAssetById(int id);
        Task<ServiceResponse<List<GetAssetDto>>> AddAsset(AddAssetDto newAsset);
        Task<ServiceResponse<GetAssetDto>> UpdateAsset(UpdateAssetDto updatedAsset);
        Task<ServiceResponse<List<GetAssetDto>>> DeleteAsset(int id);
    }
}