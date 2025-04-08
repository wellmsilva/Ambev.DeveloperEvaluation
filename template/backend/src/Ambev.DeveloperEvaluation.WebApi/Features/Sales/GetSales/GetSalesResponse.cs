namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

public record GetSalesResponse
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
}
