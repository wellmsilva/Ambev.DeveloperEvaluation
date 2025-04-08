using Ambev.DeveloperEvaluation.Application.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public record GetSalesQuery : IRequest<PaginatedList<GetSalesResult>>
{
    public string Filters { get; set; } = string.Empty;

    /// <summary>
    /// Order of the elements in the collection (asc or desc, default: asc)
    /// </summary>
    public string Order { get; set; } = "asc";

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
