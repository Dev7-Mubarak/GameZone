using System.ComponentModel.DataAnnotations;

namespace GameZone.Attrbuites
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string _allowedExstenisions;

        public AllowedExtensionsAttribute(string allowedExstenisions)
        {
            _allowedExstenisions = allowedExstenisions;
        }

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if(file != null)
            {
                var extension = Path.GetExtension(file.FileName);

                var isAllowed = _allowedExstenisions.Split(',')
                    .Contains(extension, StringComparer.OrdinalIgnoreCase);

                if (!isAllowed)
                {
                    return new ValidationResult($"Only {_allowedExstenisions} are allowed!");
                }
            }

            return ValidationResult.Success;
        }
    }
}