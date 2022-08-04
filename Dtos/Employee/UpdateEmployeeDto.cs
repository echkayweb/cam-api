namespace cam_api.Dtos.EmployeeDto
{
    public class UpdateEmployeeDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string HouseNumber { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int Pincode { get; set; }
        public string Country { get; set; } = string.Empty;
        public DateTime? DOJ { get; set; }
        public DateTime? EOJ { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}