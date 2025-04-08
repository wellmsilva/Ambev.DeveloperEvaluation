using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public int Number { get; set; }
    public Guid CustomerId { get; set; }
    public string Branch { get; set; } = string.Empty;
    public IEnumerable<CreateSaleProductCommand> Products { get; set; } = [];


    public static implicit operator Sale(CreateSaleCommand command)
    {
        var sale = new Sale(command.Number, command.CustomerId, command.Branch);
        foreach (var product in command.Products)
        {
            sale.AddProduct(new Product(product.Name, product.Quantity, product.Price));
        }

        return sale;
    }


}
