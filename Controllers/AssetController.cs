using cam_api.Dtos.AssetDto;
using cam_api.Services.AssetService;
using Microsoft.AspNetCore.Mvc;

namespace cam_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetAssetDto>>>> Get()
        {
            var assets = await _assetService.GetAllAssets();
            if (assets.Data != null)
            {
                foreach (var asset in assets.Data)
                {
                    if (asset.ImageName != "")
                    {
                        asset.ImageSrc = String.Format("{0}://{1}{2}/Images/Assets/{3}",
                        Request.Scheme, Request.Host, Request.PathBase, asset.ImageName);
                    }
                }
            }
            return Ok(assets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAssetDto>>> GetSingle(int id)
        {
            var asset = await _assetService.GetAssetById(id);
            if (asset.Data != null)
            {
                if (asset.Data.ImageName != "")
                {
                    asset.Data.ImageSrc = String.Format("{0}://{1}{2}/Images/Assets/{3}",
                    Request.Scheme, Request.Host, Request.PathBase, asset.Data.ImageName);
                }
            }
            return Ok(asset);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetAssetDto>>>> AddAsset([FromForm] AddAssetDto newAsset)
        {
            var response = await _assetService.AddAsset(newAsset);
            if (response.Data == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAssetDto>>> UpdateAsset(int id, [FromForm] UpdateAssetDto updatedAsset)
        {
            var response = await _assetService.UpdateAsset(id, updatedAsset);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetAssetDto>>>> Delete(int id)
        {
            var response = await _assetService.DeleteAsset(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}