﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleRequestValidator: AbstractValidator<GetSaleRequest>
{
	public GetSaleRequestValidator()
	{
        RuleFor(request => request.Id)
            .NotNull().WithMessage("Sale ID is required")
            .NotEmpty().WithMessage("Sale ID cannot be empty");       
    }
}
