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
        private readonly IWebHostEnvironment _hostEnvironment;

        public AssetService(IMapper mapper, DataContext context, IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
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
            try
            {
                if (newAsset.ImageFile != null)
                {
                    newAsset.ImageName = await SaveImage(newAsset.ImageFile);
                    if (newAsset.ImageName == "")
                    {
                        serviceResponse.Message = "Invalid Image.";
                    }
                }
                Asset asset = _mapper.Map<Asset>(newAsset);
                _context.Assets.Add(asset);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Assets
                                    .Select(a => _mapper.Map<GetAssetDto>(a))
                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAssetDto>> UpdateAsset(int id, UpdateAssetDto updatedAsset)
        {
            ServiceResponse<GetAssetDto> response = new ServiceResponse<GetAssetDto>();

            if (updatedAsset.ImageFile != null)
            {
                DeleteImage(updatedAsset.ImageName);
                updatedAsset.ImageName = await SaveImage(updatedAsset.ImageFile);
                if (updatedAsset.ImageName == "")
                {
                    response.Message = "Invalid Image.";
                }
            }

            try
            {
                var asset = await _context.Assets.
                            FirstOrDefaultAsync(a => a.AssetId == id);

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
                DeleteImage(asset.ImageName);
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

        public async Task<string> SaveImage(IFormFile imageFile)
        {
            if (imageFile.Length > 200000)
            {
                return "";
            }
            string[] AllowedFileExtensions = new string[] { ".jpg", ".png", ".jpeg", ".bmp" };
            if (!AllowedFileExtensions.Contains(imageFile.FileName.Substring(imageFile.FileName.LastIndexOf("."))))
            {
                return "";
            }
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images/Assets", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images/Assets", imageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }
    }
}