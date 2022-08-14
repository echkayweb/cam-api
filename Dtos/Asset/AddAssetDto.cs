using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cam_api.Dtos.AssetDto
{
    public class AddAssetDto : IValidatableObject
    {
        [Column(TypeName = "nvarchar(100)")]
        public string AssetName { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(30)")]
        public string AssetModel { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(30)")]
        public string AssetSerialNumber { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(30)")]
        public string Warranty { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PurchaseDate.Year < 2000)
                yield return new ValidationResult("Purchase data is incorrect.");
            if (PurchaseDate.Date > DateTime.Now.Date)
                yield return new ValidationResult("Invalid Date");
        }
    }
}