using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FizzWare.NBuilder;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;


public class SaleTests
{

    [Fact(DisplayName = "Sale status should change to Cancelled when cancelled")]
    public void Given_ActiveSale_When_Cancelled_Then_StatusShouldBeCancelled()
    {
        // Arrange
        var sale = Builder<Sale>
          .CreateNew()
          .With(x => x.IsCancelled, true)
          .Build();

        // Act
        sale.Cancel();

        // Assert
        Assert.True(sale.IsCancelled);
    }


    [Fact(DisplayName = "Total amount should be calculated correctly")]
    public void Given_SaleWithItems_When_CalculateTotalAmount_Then_TotalAmountShouldBeCorrect()
    {
        // Arrange
        var sale = SaleTestData.GenerateSale();
        
        // Assert
        var expectedTotalAmount = sale.Products.Sum(item => (item.Price * item.Quantity) - item.Discount);
        Assert.Equal(expectedTotalAmount, sale.AmountTotal);
    }


    [Fact(DisplayName = "Validation should pass for valid sale data")]
    public void Given_ValidSaleData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var sale = SaleTestData.GenerateSale();

        // Act
        var result = sale.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when sale properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid sale data")]
    public void Given_InvalidSaleData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var sale = Builder<Sale>
            .CreateNew()
            .Build();

        // Act
        var result = sale.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}
