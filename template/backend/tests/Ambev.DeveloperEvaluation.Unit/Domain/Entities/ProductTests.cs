using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FizzWare.NBuilder;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;


public class ProductTests
{


    [Fact(DisplayName = "10% discount should be applied for quantity between minimum and maximum for 10% discount")]
    public void Given_QuantityBetweenMinAndMaxForTenPercentDiscount_When_ApplyDiscount_Then_TenPercentDiscountShouldBeApplied()
    {
        // Arrange
        var Product = Builder<Product>
           .CreateNew()
           .With(x => x.Quantity, 5)
           .With(x => x.Price, 10m)
       .Build();

        // Assert
        Assert.Equal(5m, Product.Discount);
    }


    [Fact(DisplayName = "No discount should be applied for quantity less than minimum for discount")]
    public void Given_QuantityLessThanMinForDiscount_When_ApplyDiscount_Then_NoDiscountShouldBeApplied()
    {
        // Arrange
        var Product = Builder<Product>
            .CreateNew()
            .With(x => x.Quantity, 3)
            .With(x => x.Price, 10m)
        .Build();


        // Assert
        Assert.Equal(0m, Product.Discount);
    }

    [Fact(DisplayName = "20% discount should be applied for quantity between maximum for 10% discount and maximum for 20% discount")]
    public void Given_QuantityBetweenMaxForTenPercentAndMaxForTwentyPercentDiscount_When_ApplyDiscount_Then_TwentyPercentDiscountShouldBeApplied()
    {
        // Arrange
        var Product = Builder<Product>
           .CreateNew()
           .With(x => x.Quantity, 17)
           .With(x => x.Price, 10m)
       .Build();


        // Assert
        Assert.Equal(34m, Product.Discount);
    }


    [Fact(DisplayName = "Validation should pass for valid sale item data")]
    public void Given_ValidProductData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var Product = ProductsTestData.GenerateValidProducts();

        // Act
        var result = Product[0].Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }


    [Fact(DisplayName = "Validation should fail for invalid sale item data")]
    public void Given_InvalidProductData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var Product = new Product(string.Empty, 0, 0m);

        // Act
        var result = Product.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    [Fact(DisplayName = "Exception should be thrown for quantity exceeding maximum allowed for discount")]
    public void Given_QuantityExceedsMaxForDiscount_When_ApplyDiscount_Then_ShouldThrowException()
    {
        // Arrange
        var Product = Builder<Product>
         .CreateNew()
         .With(x => x.Quantity, 25)
         .With(x => x.Price, 10m)
        .Build();


        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => new Product(
            "Product 1", 25, 10m
            ));
        Assert.Equal("Cannot sell more than 20 identical items.", exception.Message);
    }

}