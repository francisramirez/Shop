using Shop.Production.Api.Infrastructure.Services.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Production.Api.Infrastructure.Services.ServicesResult.Validation
{
    public class NameExistsAttribute : ValidationAttribute
    {
        private readonly IProductService _IProductService;
        public NameExistsAttribute(IProductService iProductService)
        {
            this._IProductService = iProductService;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var existsName = _IProductService.ValidateProduct(value.ToString());
            var x = Convert.ToBoolean(existsName);

            if (!x)
            {
                var mssgError = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(mssgError);
            }
            return ValidationResult.Success;
        }
    }
}