using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
	public CreateSaleRequestValidator()
	{
        RuleFor(command => command.CustomerId)
          .NotNull().WithMessage("Customer Id cannot be null.");

        RuleFor(command => command.CustomerId)
            .NotEmpty().WithMessage("Customer Id cannot be empty.");

        RuleFor(command => command.Branch)
            .NotEmpty().Length(3, 70).WithMessage("Branch name must be between 3 and 70 characters.");

        RuleFor(command => command.Products)
            .NotEmpty().WithMessage("Sale must contain at least one product.");
    }
}
