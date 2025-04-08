namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleProductCommand
{
    /// <summary>
    /// The product name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The quantity of the product
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The unit price of the product
    /// </summary>
    public decimal Price { get; set; }

    public Guid SaleId { get; set; }
}