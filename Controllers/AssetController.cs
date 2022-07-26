using cam_api.Dtos.Asset;
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
            return Ok(await _assetService.GetAllAssets());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAssetDto>>> GetSingle(int id)
        {
            return Ok(await _assetService.GetAssetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetAssetDto>>>> AddAsset(AddAssetDto newAsset)
        {
            var response = await _assetService.AddAsset(newAsset);
            if (response.Data == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetAssetDto>>> UpdateAsset(UpdateAssetDto updatedAsset)
        {
            var response = await _assetService.UpdateAsset(updatedAsset);
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