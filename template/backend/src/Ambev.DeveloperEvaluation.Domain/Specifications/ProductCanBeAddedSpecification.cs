using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class ProductCanBeAddedSpecification : ISpecification<Product>
{
    public bool IsSatisfiedBy(Product entity)
    {
        return entity.Quantity <= 20;
    }
}
