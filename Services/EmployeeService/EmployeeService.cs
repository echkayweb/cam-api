using AutoMapper;
using cam_api.Data;
using cam_api.Dtos.EmployeeDto;
using Microsoft.EntityFrameworkCore;

namespace cam_api.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public EmployeeService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetEmployeeDto>>> GetAllEmployees()
        {
            var response = new ServiceResponse<List<GetEmployeeDto>>();
            var dbAssets = await _context.Employees.ToListAsync();
            response.Data = dbAssets.Select(e => _mapper.Map<GetEmployeeDto>(e)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetEmployeeDto>> GetEmployeeById(int id)
        {
            var serviceResponse = new ServiceResponse<GetEmployeeDto>();
            var dbAsset = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            serviceResponse.Data = _mapper.Map<GetEmployeeDto>(dbAsset);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetEmployeeDto>>> AddEmployee(AddEmployeeDto newEmployee)
        {
            var serviceResponse = new ServiceResponse<List<GetEmployeeDto>>();
            try
            {
                Employee employee = _mapper.Map<Employee>(newEmployee);
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Employees
                                    .Select(e => _mapper.Map<GetEmployeeDto>(e))
                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetEmployeeDto>> UpdateEmployee(UpdateEmployeeDto updatedEmployee)
        {
            ServiceResponse<GetEmployeeDto> response = new ServiceResponse<GetEmployeeDto>();
            try
            {
                var employee = await _context.Employees.
                            FirstOrDefaultAsync(e => e.EmployeeId == updatedEmployee.EmployeeId);

                _mapper.Map(updatedEmployee, employee);

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetEmployeeDto>(employee);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetEmployeeDto>>> DeleteEmployee(int id)
        {
            ServiceResponse<List<GetEmployeeDto>> response = new ServiceResponse<List<GetEmployeeDto>>();
            try
            {
                Employee employee = await _context.Employees.FirstAsync(e => e.EmployeeId == id);
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

                response.Data = await _context.Employees.Select(e => _mapper.Map<GetEmployeeDto>(e)).ToListAsync();
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