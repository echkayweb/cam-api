using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cam_api.Dtos.AssignedAsset;
using cam_api.Services.AssignedAssetService;
using Microsoft.AspNetCore.Mvc;

namespace cam_api.Controllers
{
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
    }
}