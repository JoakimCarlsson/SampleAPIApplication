using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SampleApplication.Models;
using SampleApplication.Services.Products;

namespace SampleApplication.Validators
{
    public class ProductValidator : AbstractValidator<AddProductRequest>
    {
        public ProductValidator()
        {
            RuleFor(i => i.Product.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(i => i.Product.Price)
                .GreaterThan(10000).WithMessage("{PropertyName} must be more then 10000");
        }
    }
}
