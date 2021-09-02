using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SampleApplication.Models;
using SampleApplication.Services.Products;

namespace SampleApplication.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(i => i.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(i => i.Price)
                .GreaterThan(10000).WithMessage("{PropertyName} must be more then 10000");
        }
    }
}
