using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Linq;
namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

internal class GetSalesHandler : IRequestHandler<GetSalesQuery, PaginatedList<GetSalesResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetSalesHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<GetSalesResult>> Handle(GetSalesQuery query, CancellationToken cancellationToken)
    {
        var validator = new GetSalesQueryValidator();
        var validationResult = await validator.ValidateAsync(query, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var sales = _saleRepository.GetAllAsync(query.Filters, query.Order, cancellationToken);

        return await PaginatedList<GetSalesResult>.CreateAsync(sales.Select(x => (GetSalesResult)x), query.Page, query.PageSize); ;
    }
}
