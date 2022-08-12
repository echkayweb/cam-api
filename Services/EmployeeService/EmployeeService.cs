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
        private readonly IWebHostEnvironment _hostEnvironment;

        public EmployeeService(IMapper mapper, DataContext context, IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetEmployeeDto>>> GetAllEmployees()
        {
            var response = new ServiceResponse<List<GetEmployeeDto>>();
            var dbEmployees = await _context.Employees.ToListAsync();
            response.Data = dbEmployees.Select(e => _mapper.Map<GetEmployeeDto>(e)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetEmployeeDto>> GetEmployeeById(int id)
        {
            var serviceResponse = new ServiceResponse<GetEmployeeDto>();
            var dbEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            serviceResponse.Data = _mapper.Map<GetEmployeeDto>(dbEmployee);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetEmployeeDto>>> AddEmployee(AddEmployeeDto newEmployee)
        {
            var serviceResponse = new ServiceResponse<List<GetEmployeeDto>>();
            try
            {
                if (newEmployee.ImageFile != null)
                {
                    newEmployee.ImageName = await SaveImage(newEmployee.ImageFile);
                    if (newEmployee.ImageName == "")
                    {
                        serviceResponse.Message = "Invalid Image.";
                    }
                }
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

        public async Task<ServiceResponse<GetEmployeeDto>> UpdateEmployee(int id, UpdateEmployeeDto updatedEmployee)
        {
            ServiceResponse<GetEmployeeDto> response = new ServiceResponse<GetEmployeeDto>();

            if (updatedEmployee.ImageFile != null)
            {
                DeleteImage(updatedEmployee.ImageName);
                updatedEmployee.ImageName = await SaveImage(updatedEmployee.ImageFile);
                if (updatedEmployee.ImageName == "")
                {
                    response.Message = "Invalid Image.";
                }
            }

            try
            {
                var employee = await _context.Employees.
                            FirstOrDefaultAsync(e => e.EmployeeId == id);

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
                DeleteImage(employee.ImageName);
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
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }

    }
}