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

        public async Task<ServiceResponse<List<GetAssignedAssetDto>>> GetAllAssignedAssets()
        {
            var response = new ServiceResponse<List<GetAssignedAssetDto>>();
            var dbAssignAssets = await _context.AssignedAssets.ToListAsync();
            response.Data = dbAssignAssets.Select(a => _mapper.Map<GetAssignedAssetDto>(a)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetAssignedAssetDto>> GetAssignedAssetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetAssignedAssetDto>();
            var dbAsset = await _context.AssignedAssets.FirstOrDefaultAsync(a => a.AssignedAssetId == id);
            serviceResponse.Data = _mapper.Map<GetAssignedAssetDto>(dbAsset);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAssignedAssetDto>>> AddAssignedAsset(AddAssignedAssetDto newAssignedAsset)
        {
            var serviceResponse = new ServiceResponse<List<GetAssignedAssetDto>>();
            AssignedAsset assignedAsset = _mapper.Map<AssignedAsset>(newAssignedAsset);
            Asset asset = await _context.Assets.FirstAsync(a => a.AssetId == assignedAsset.AssetId);
            asset.AssetAvailable = Availability.Assigned;
            asset.AssetAssignedTo = assignedAsset.EmployeeId;
            _context.AssignedAssets.Add(assignedAsset);
            await _context.SaveChangesAsync();
            asset.AssignedAssetId = assignedAsset.AssignedAssetId;
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.AssignedAssets
                                .Select(a => _mapper.Map<GetAssignedAssetDto>(a))
                                .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAssignedAssetDto>> UpdateAssignedAsset(int id, UpdateAssignedAssetDto updatedAssignedAsset)
        {
            ServiceResponse<GetAssignedAssetDto> response = new ServiceResponse<GetAssignedAssetDto>();
            try
            {
                var assignedAsset = await _context.AssignedAssets.
                            FirstOrDefaultAsync(a => a.AssignedAssetId == id);

                _mapper.Map(updatedAssignedAsset, assignedAsset);

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetAssignedAssetDto>(assignedAsset);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetAssignedAssetDto>>> DeleteAssignedAsset(int id)
        {
            ServiceResponse<List<GetAssignedAssetDto>> response = new ServiceResponse<List<GetAssignedAssetDto>>();
            try
            {
                AssignedAsset assignedAsset = await _context.AssignedAssets.FirstAsync(a => a.AssignedAssetId == id);
                _context.AssignedAssets.Remove(assignedAsset);
                await _context.SaveChangesAsync();

                response.Data = await _context.AssignedAssets.Select(a => _mapper.Map<GetAssignedAssetDto>(a)).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}