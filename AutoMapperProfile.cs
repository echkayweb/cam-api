using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using cam_api.Dtos.Asset;

namespace cam_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Asset, GetAssetDto>();
            CreateMap<AddAssetDto, Asset>();
            CreateMap<UpdateAssetDto, Asset>();
        }
    }
}