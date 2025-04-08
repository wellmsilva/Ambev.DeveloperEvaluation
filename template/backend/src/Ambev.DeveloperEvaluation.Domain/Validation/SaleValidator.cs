using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;


public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(s => s.Number)
            .NotEmpty().WithMessage("Sale number is required.");

        RuleFor(s => s.CustomerId)
            .NotNull().WithMessage("Customer Id cannot be null.")
            .NotEmpty().WithMessage("Customer Id cannot be empty");

        RuleFor(s => s.Branch)
            .NotEmpty().Length(3, 70).WithMessage("Branch name must be between 3 and 100 characters.");

        RuleFor(s => s.Products)
            .NotEmpty().WithMessage("Sale must have at least one item of product.");

        RuleForEach(s => s.Products).SetValidator(new ProductValidator());
    }
}


public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(item => item.Id)
           .NotNull().WithMessage("Customer Id cannot be null.")
           .NotEmpty().WithMessage("Customer Id cannot be empty");

        RuleFor(item => item.Name)
            .NotEmpty().Length(3, 100).WithMessage("Product name must be between 3 and 100 characters.");

        RuleFor(item => item.Quantity)
            .InclusiveBetween(1, 20).WithMessage("Quantity must be between 1 and 20.");

        RuleFor(item => item.Price)
            .GreaterThan(0).WithMessage("Unit price must be greater than 0.");
    }
}