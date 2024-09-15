using DtoPractice.Application.DTOs;
using FluentValidation;

namespace DtoPractice.Application.Services.Validation;

public class ProductCreateDTOValidator : AbstractValidator<ProductCreateDTO>
{
    public ProductCreateDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(3, 100).WithMessage("Name must be between 3 and 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");
    }
}