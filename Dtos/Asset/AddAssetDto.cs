using System.ComponentModel.DataAnnotations;

namespace cam_api.Dtos.AssetDto
{
    public class AddAssetDto : IValidatableObject
    {
        public string AssetName { get; set; } = string.Empty;
        public string AssetModel { get; set; } = string.Empty;
        public string AssetSerialNumber { get; set; } = string.Empty;
        public string Warranty { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
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