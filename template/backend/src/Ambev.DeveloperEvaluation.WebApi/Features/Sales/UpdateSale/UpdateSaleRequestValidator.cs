using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{

    public UpdateSaleRequestValidator()
    {
        RuleFor(command => command.Number)
        .NotEmpty().WithMessage("Number cannot be empty.");

        RuleFor(command => command.CustomerId)
         .NotNull().WithMessage("Customer Id cannot be null.");

        RuleFor(command => command.CustomerId)
            .NotEmpty().WithMessage("Customer Id cannot be empty.");

        RuleFor(command => command.Branch)
            .NotEmpty().Length(3, 70).WithMessage("Branch name must be between 3 and 70 characters.");

    }
}
