using cam_api.Dtos.EmployeeDto;
using cam_api.Services.EmployeeService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cam_api.Controllers
{
    [Authorize]
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
            var employees = await _employeeService.GetAllEmployees();
            if (employees.Data != null)
            {
                foreach (var employee in employees.Data)
                {
                    if (employee.ImageName != "")
                    {
                        employee.ImageSrc = String.Format("{0}://{1}{2}/Images/Employees/{3}",
                        Request.Scheme, Request.Host, Request.PathBase, employee.ImageName);
                    }
                }
            }
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetEmployeeDto>>> GetSingle(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee.Data != null)
            {
                if (employee.Data.ImageName != "")
                {
                    employee.Data.ImageSrc = String.Format("{0}://{1}{2}/Images/Employees/{3}",
                        Request.Scheme, Request.Host, Request.PathBase, employee.Data.ImageName);
                }
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> AddEmployee([FromForm] AddEmployeeDto newEmployee)
        {
            var response = await _employeeService.AddEmployee(newEmployee);
            if (response.Data == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetEmployeeDto>>> UpdateEmployee(int id, [FromForm] UpdateEmployeeDto updatedEmployee)
        {
            var response = await _employeeService.UpdateEmployee(id, updatedEmployee);
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