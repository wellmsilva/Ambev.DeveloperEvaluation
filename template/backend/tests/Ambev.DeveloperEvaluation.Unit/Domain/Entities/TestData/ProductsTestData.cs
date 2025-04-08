using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

public static class ProductsTestData
{
    public static List<Product> GenerateInvalidProducts(int qtde = 1) => new Faker<Product>()
        .CustomInstantiator(f => new Product(
             f.Commerce.ProductName(),
             f.Random.Number(21, 30),
                f.Random.Decimal(10, 100)))
        .RuleFor(s => s.Id, f => Guid.NewGuid())
        .Generate(qtde);

    public static List<Product> GenerateValidProducts(int qtde = 1) => new Faker<Product>()
           .CustomInstantiator(f => new Product(
             f.Commerce.ProductName(),
             f.Random.Number(1, 20),
             f.Random.Decimal(10, 100)))
        .RuleFor(s => s.Id, f => Guid.NewGuid())
        .Generate(qtde);

}