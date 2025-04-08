using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Application.Sales.GetSales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

public class GetSalesProfile : Profile
{
    public GetSalesProfile()
    {
        CreateMap<GetSalesRequest, GetSalesQuery>();
        CreateMap<GetSalesResult, GetSalesResponse>();
        CreateMap<PaginatedList<GetSalesResult>, PaginatedList<GetSalesResponse>>()
            .ConvertUsing((src, dest, context) =>
            {
                var mappedItems = context.Mapper.Map<List<GetSalesResponse>>(src);
                return new PaginatedList<GetSalesResponse>(mappedItems, src.TotalCount, src.CurrentPage, src.PageSize);
            });

    }
}
