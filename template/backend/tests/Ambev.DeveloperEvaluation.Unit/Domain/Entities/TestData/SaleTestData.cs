using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
public static class SaleTestData
{
    public static Sale GenerateSale()
    {
        var sale = new Faker<Sale>()
            .CustomInstantiator(f => new Sale(
                f.Random.Number(1, 100),
                Guid.NewGuid(),
                 f.Company.CompanyName()
                ))
            .RuleFor(s => s.Id, f => Guid.NewGuid())
            .Generate();
        ProductsTestData
            .GenerateValidProducts(6)
            .ForEach(p => sale.AddProduct(p));
        
        return sale;
    }

}