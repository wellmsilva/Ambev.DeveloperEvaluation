namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequest
{

    public int Number { get; set; }
    public Guid CustomerId { get; set; } 
    public string Branch { get; set; } = string.Empty;

    public IEnumerable<CreateSaleProductRequest> Products { get; set; } = [];
}

public class CreateSaleProductRequest
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