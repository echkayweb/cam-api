using cam_api.Dtos.EmployeeDto;
using cam_api.Services.EmployeeService;
using Microsoft.AspNetCore.Mvc;

namespace cam_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> Get()
        {
            return Ok(await _employeeService.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetEmployeeDto>>> GetSingle(int id)
        {
            return Ok(await _employeeService.GetEmployeeById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> AddEmployee(AddEmployeeDto newEmployee)
        {
            var response = await _employeeService.AddEmployee(newEmployee);
            if (response.Data == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetEmployeeDto>>> UpdateEmployee(UpdateEmployeeDto updatedEmployee)
        {
            var response = await _employeeService.UpdateEmployee(updatedEmployee);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> Delete(int id)
        {
            var response = await _employeeService.DeleteEmployee(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}