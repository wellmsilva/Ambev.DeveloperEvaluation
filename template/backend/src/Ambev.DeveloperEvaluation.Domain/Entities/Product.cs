using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity
{
    public Guid SaleId { get; init; }
    public string Name { get; init; } = string.Empty;
    public int Quantity { get; init; }
    public decimal Price { get; init; }

    public Sale? Sale { get; init; }

    public decimal Discount
    {
        get
        {
            if (Quantity >= 4 && Quantity <= 10) return Math.Round(Price * Quantity * (decimal)0.1F, 2);
            if (Quantity > 10 && Quantity <= 20) return Math.Round(Price * Quantity * (decimal)0.2F, 2);
            return 0;
        }
        set => _ = value;
    }


    public decimal AmountTotal => (Price * Quantity) - Discount;

    protected Product() { }

    public Product(string name, int quantity, decimal price) : this()
    {
        Name = name;
        Quantity = quantity <= 20 ? quantity : throw new InvalidOperationException("Cannot sell more than 20 identical items.");
        Price = price;
    }

    public ValidationResultDetail Validate()
    {
        var validator = new ProductValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
