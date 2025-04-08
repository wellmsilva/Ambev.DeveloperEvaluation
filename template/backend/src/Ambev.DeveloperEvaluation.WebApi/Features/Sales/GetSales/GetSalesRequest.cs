namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

public record GetSalesRequest
{
    public string Filters { get; set; } = string.Empty;

    /// <summary>
    /// Order of the elements in the collection (asc or desc, default: asc)
    /// </summary>
    public string Order { get; set; } = "ASC";

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
