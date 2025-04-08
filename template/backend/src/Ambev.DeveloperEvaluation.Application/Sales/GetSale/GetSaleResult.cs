namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleResult
{
    /// <summary>
    /// The unique identifier 
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The sale number
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// The date when the sale was made
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// The customer Id
    /// </summary>
    public Guid CustomerId { get; set; }


    /// <summary>
    /// The total sale amount
    /// </summary>
    public decimal TotalAmount { get; set; }


    /// <summary>
    /// The branch name 
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// The list of items in the sale
    /// </summary>
    public IEnumerable<GetProductResult> Products { get; set; } = [];

    /// <summary>
    /// Indicates whether the sale is cancelled
    /// </summary>
    public bool IsCancelled { get; set; }
}

public class GetProductResult
{
    /// <summary>
    /// The unique identifier 
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// The product name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The price of the product
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// The quantity of the product
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The discount amount
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// The total amount of the sale item
    /// </summary>
    public decimal TotalAmount { get; set; }
}
