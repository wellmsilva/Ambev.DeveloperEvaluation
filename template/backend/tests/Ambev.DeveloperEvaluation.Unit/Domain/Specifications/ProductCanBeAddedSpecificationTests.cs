using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Specifications;
using FizzWare.NBuilder;
using FluentAssertions;
using System;
using Xunit;


namespace Ambev.DeveloperEvaluation.Unit.Domain.Specifications;

public class ProductCanBeAddedSpecificationTests
{

    [Theory]
    [InlineData(22, false)]
    [InlineData(12, true)]
    [InlineData(2, true)]
    [InlineData(5, true)]
    public void IsSatisfiedBy_ShouldValidate(int quantity, bool expectedResult)
    {
        // Arrange
        var user = Builder<Product>
            .CreateNew()
            .With(x => x.Quantity, quantity)
            .Build();

        var specification = new ProductCanBeAddedSpecification();

        // Act
        var result = specification.IsSatisfiedBy(user);

        // Assert
        result.Should().Be(expectedResult);
    }
}
