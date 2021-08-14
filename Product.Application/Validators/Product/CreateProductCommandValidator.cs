using FluentValidation;
using Product.Application.Command.Product.Create;
using System;

namespace Product.Application.Validators.Product
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.ProductDescription)
                   .NotNull()
                   .NotEmpty()
                   .Length(1, 250);
        }

        public bool MetodoExemploCasoQueiraRegex(string valor)
        {
            var regex = "AQQUI VAI SEU REGEX";

            return true;
        }
    }
}
