using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FizzWare.NBuilder;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class SaleValidatorTests
{
    private readonly SaleValidator _validator = new();

 
    [Fact(DisplayName = "Should have error when CustomerId is empty")]
    public void Given_InvalidCustomerId_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var sale = Builder<Sale>.CreateNew()
            .With(x => x.CustomerId, Guid.Empty)
            .Build();

        // Act & Assert
        var result = _validator.TestValidate(sale);
        result.ShouldHaveValidationErrorFor(s => s.CustomerId).WithErrorMessage("Customer Id cannot be empty");
    }



    [Fact(DisplayName = "Should have error when BranchName is empty or out of length bounds")]
    public void Given_InvalidBranchName_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var sale = Builder<Sale>.CreateNew()
              .With(x => x.Branch, string.Empty)
              .Build();

        // Act & Assert
        var result = _validator.TestValidate(sale);
        result.ShouldHaveValidationErrorFor(s => s.Branch).WithErrorMessage("Branch name must be between 3 and 100 characters.");
    }

    [Fact(DisplayName = "Should have error when Items list is empty")]
    public void Given_EmptyItemsList_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var sale = Builder<Sale>.CreateNew()
             .Build();

        // Act & Assert
        var result = _validator.TestValidate(sale);
        result.ShouldHaveValidationErrorFor(s => s.Products).WithErrorMessage("Sale must have at least one item of product.");
    }
}