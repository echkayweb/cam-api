using AutoMapper;
using cam_api.Data;
using cam_api.Dtos.AssetDto;
using Microsoft.EntityFrameworkCore;

namespace cam_api.Services.AssetService
{
    public class AssetService : IAssetService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public AssetService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetAssetDto>>> GetAllAssets()
        {
            var response = new ServiceResponse<List<GetAssetDto>>();
            var dbAssets = await _context.Assets.ToListAsync();
            response.Data = dbAssets.Select(a => _mapper.Map<GetAssetDto>(a)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetAssetDto>> GetAssetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetAssetDto>();
            var dbAsset = await _context.Assets.FirstOrDefaultAsync(a => a.AssetId == id);
            serviceResponse.Data = _mapper.Map<GetAssetDto>(dbAsset);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAssetDto>>> AddAsset(AddAssetDto newAsset)
        {
            var serviceResponse = new ServiceResponse<List<GetAssetDto>>();
            Asset asset = _mapper.Map<Asset>(newAsset);
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Assets
                                .Select(a => _mapper.Map<GetAssetDto>(a))
                                .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAssetDto>> UpdateAsset(UpdateAssetDto updatedAsset)
        {
            ServiceResponse<GetAssetDto> response = new ServiceResponse<GetAssetDto>();
            try
            {
                var asset = await _context.Assets.
                            FirstOrDefaultAsync(a => a.AssetId == updatedAsset.AssetId);

                _mapper.Map(updatedAsset, asset);

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetAssetDto>(asset);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetAssetDto>>> DeleteAsset(int id)
        {
            ServiceResponse<List<GetAssetDto>> response = new ServiceResponse<List<GetAssetDto>>();
            try
            {
                Asset asset = await _context.Assets.FirstAsync(a => a.AssetId == id);
                _context.Assets.Remove(asset);
                await _context.SaveChangesAsync();

                response.Data = await _context.Assets.Select(a => _mapper.Map<GetAssetDto>(a)).ToListAsync();
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