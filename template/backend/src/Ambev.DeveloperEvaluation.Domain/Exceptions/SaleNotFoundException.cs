namespace Ambev.DeveloperEvaluation.Domain.Exceptions;

public class SaleNotFoundException : Exception
{
    public SaleNotFoundException(Guid id) : base(string.Format("Sale  {0} not found", id)) { }
}
