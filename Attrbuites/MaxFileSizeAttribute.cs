using GameZone.Models;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Attrbuites
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if(file != null)
            {
                if(file.Length > _maxFileSize)
                {
                    return new ValidationResult($"Maximum allowed Size is {FileSetings.MaxFileSizeInMB} MB!");
                }
            }

            return ValidationResult.Success;
        }
    }
}
