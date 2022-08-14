using System.ComponentModel.DataAnnotations.Schema;

namespace cam_api.Dtos.User
{
    public class UserLoginDto
    {
        [Column(TypeName = ("nvarchar(50)"))]
        public string Username { get; set; } = string.Empty;
        [Column(TypeName = ("nvarchar(100)"))]
        public string Password { get; set; } = string.Empty;
    }
}