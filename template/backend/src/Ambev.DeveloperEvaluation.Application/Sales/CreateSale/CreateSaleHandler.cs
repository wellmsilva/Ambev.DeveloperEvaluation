using Ambev.DeveloperEvaluation.Application.Sales.Events;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

internal sealed class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly IMapper _mapper;
    private readonly ISaleRepository _saleRepository;
    private readonly ILogger<CreateSaleHandler> _logger;
    readonly IBus _bus;

    public CreateSaleHandler(IMapper mapper, ISaleRepository saleRepository, ILogger<CreateSaleHandler> logger, IBus bus)
    {
        _mapper = mapper;
        _saleRepository = saleRepository;
        _logger = logger;
        _bus = bus;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for CreateSaleCommand. Errors: {Errors}", validationResult.Errors);
            throw new ValidationException(validationResult.Errors);
        }

        Sale sale = command;

        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);

        await _bus.Publish(new EventSalesMessage(EventSale.SaleCreated, sale.Id, DateTime.UtcNow), cancellationToken);

        return _mapper.Map<CreateSaleResult>(createdSale);
    }
}
