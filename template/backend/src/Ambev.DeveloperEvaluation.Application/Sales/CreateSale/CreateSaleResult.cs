namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public record CreateSaleResult
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public string Branch { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    public IEnumerable<CreateSaleProductResult> Products { get; set; } = [];
}


public record CreateSaleProductResult
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


    /// <summary>
    /// Discount granted
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// The  Amount Total
    /// </summary>
    public decimal AmountTotal { get; set; }
}