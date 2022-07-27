using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using cam_api.Data;
using cam_api.Dtos.AssignedAsset;
using Microsoft.EntityFrameworkCore;

namespace cam_api.Services.AssignedAssetService
{
    public class AssignedAssetService : IAssignedAssetService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public AssignedAssetService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetAssignedAssetDto>>> AddAssignAsset(AddAssignedAssetDto newAssignedAsset)
        {
            var response = new ServiceResponse<List<GetAssignedAssetDto>>();
            var dbAssignAssets = await _context.AssignedAssets.ToListAsync();
            response.Data = dbAssignAssets.Select(a => _mapper.Map<GetAssignedAssetDto>(a)).ToList();
            return response;
        }

        public Task<ServiceResponse<List<GetAssignedAssetDto>>> DeleteAssignAsset(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetAssignedAssetDto>>> GetAllAssignAssets()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetAssignedAssetDto>> GetAssignAssetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetAssignedAssetDto>> UpdateAssignAsset(UpdateAssignedAssetDto updatedAssignedAsset)
        {
            throw new NotImplementedException();
        }
    }
}