using cam_api.Dtos.AssignedAsset;
using cam_api.Services.AssignedAssetService;
using Microsoft.AspNetCore.Mvc;

namespace cam_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignedAssetController : ControllerBase
    {
        private readonly IAssignedAssetService _assignedAssetService;

        public AssignedAssetController(IAssignedAssetService assignedAssetService)
        {
            _assignedAssetService = assignedAssetService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetAssignedAssetDto>>>> Get()
        {
            return Ok(await _assignedAssetService.GetAllAssignedAssets());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAssignedAssetDto>>> GetSingle(int id)
        {
            return Ok(await _assignedAssetService.GetAssignedAssetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetAssignedAssetDto>>>> AddAssignedAsset(AddAssignedAssetDto newAssignedAsset)
        {
            var response = await _assignedAssetService.AddAssignedAsset(newAssignedAsset);
            if (response.Data == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAssignedAssetDto>>> UpdateAssignedAsset(int id, UpdateAssignedAssetDto updatedAssignedAsset)
        {
            var response = await _assignedAssetService.UpdateAssignedAsset(id, updatedAssignedAsset);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetAssignedAssetDto>>>> Delete(int id)
        {
            var response = await _assignedAssetService.DeleteAssignedAsset(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}