using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cam_api.Dtos.User
{
    public class UserRegisterDto : IValidatableObject
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Username { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            System.Text.RegularExpressions.Regex r =
              new System.Text.RegularExpressions.Regex(@"(?=.{8,})(?=(.*\d){1,})(?=(.*\W){1,})");


            if (!r.IsMatch(Password))
            {
                yield return new ValidationResult("Password must be at least 8 characters long and " +
                                    "contain at least one number and one special character.");
            }
        }
    }
}