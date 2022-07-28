using AutoMapper;
using cam_api.Dtos.AssetDto;
using cam_api.Dtos.AssignedAsset;
using cam_api.Dtos.EmployeeDto;

namespace cam_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Asset, GetAssetDto>();
            CreateMap<AddAssetDto, Asset>();
            CreateMap<UpdateAssetDto, Asset>();
            CreateMap<Employee, GetEmployeeDto>();
            CreateMap<AddEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<AssignedAsset, GetAssignedAssetDto>();
            CreateMap<AddAssignedAssetDto, AssignedAsset>();
            CreateMap<UpdateAssignedAssetDto, AssignedAsset>();
        }
    }
}