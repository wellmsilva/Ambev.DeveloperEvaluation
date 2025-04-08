using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public record GetSalesResult
{
    /// <summary>
    /// The unique identifier 
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The sale number
    /// </summary>
    public int Number { get; set; }

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
    public decimal AmountTotal { get; set; }


    /// <summary>
    /// The branch name 
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    public static implicit operator GetSalesResult(Sale sale) => new GetSalesResult
    {
        Branch = sale.Branch,
        CustomerId = sale.CustomerId,
        Date = sale.Date,
        Id = sale.Id,
        Number = sale.Number,
        AmountTotal = sale.AmountTotal
    };

}
