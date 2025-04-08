namespace Ambev.DeveloperEvaluation.Domain.Exceptions;

internal class ProductCanBeAddedException : Exception
{
    public ProductCanBeAddedException() : base("It's not possible to sell above 20 identical items") { }
}
