﻿using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Specifications;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Microsoft.AspNetCore.Identity;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    private readonly List<Product> _products = [];

    /// <summary>
    /// Sale number
    /// </summary>
    public int Number { get; init; }

    /// <summary>
    /// Date when the sale was made
    /// </summary>
    public DateTime Date { get; init; }

    /// <summary>
    /// Customer name
    /// </summary>
    public Guid CustomerId { get; init; }

    /// <summary>
    /// Branch where the sale was made
    /// </summary>
    public string Branch { get; init; } = string.Empty;

    /// <summary>
    /// The list of products
    /// </summary>
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

    /// <summary>
    /// Sale canceled
    /// </summary>
    public bool IsCancelled { get; private set; }

    /// <summary>
    /// Date the sale was cancelled
    /// </summary>
    public DateTime? CancelledAt { get; private set; }


    protected Sale() { }

    public Sale(int numero, Guid customerId, string branch) : this()
    {
        Number = numero;
        CustomerId = customerId;
        Branch = branch;
        Date = DateTime.UtcNow;
    }


    /// <summary>
    /// Cancels the sale.
    /// </summary>
    public void Cancel()
    {
        IsCancelled = true;
        CancelledAt = DateTime.UtcNow;
    }


    public decimal AmountTotal => _products.Sum(x => x.AmountTotal);

    public decimal Count() => _products.Sum(x => x.Quantity);

    public void AddProduct(Product product)
    {
        if (product == null || _products.Any(x => x.Name == product.Name))
            return;

        var productCanBeAddedSpec = new ProductCanBeAddedSpecification();
        if (!productCanBeAddedSpec.IsSatisfiedBy(product))
        {
            throw new ProductCanBeAddedException();
        }
        _products.Add(product);
    }


    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
