using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

internal class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidator()
    {
        RuleFor(command => command.CustomerId)
           .NotNull().WithMessage("Customer Id cannot be null.");

        RuleFor(command => command.CustomerId)
            .NotEmpty().WithMessage("Customer Id cannot be empty.");

        RuleFor(command => command.Branch)
            .NotEmpty().Length(3, 70).WithMessage("Branch name must be between 3 and 70 characters.");

        RuleFor(command => command.Products)
            .NotEmpty().WithMessage("Sale must contain at least one product.");

        RuleForEach(command => command.Products).SetValidator(new CreateProductsCommandValidator());

    }
}


public class CreateProductsCommandValidator : AbstractValidator<CreateSaleProductCommand>
{
    public CreateProductsCommandValidator()
    {
        RuleFor(item => item.Name)
            .NotEmpty().Length(3, 70).WithMessage("Product name must be between 3 and 70 characters.");

        RuleFor(item => item.Quantity)
            .InclusiveBetween(1, 20).WithMessage("Quantity must be between 1 and 20.");

        RuleFor(item => item.Price)
            .GreaterThan(0).WithMessage("Unit price must be greater than 0.");
    }
}