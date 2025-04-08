using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    public IQueryable<Sale> GetAllAsync(string? filters, string order = "asc", CancellationToken cancellationToken = default)
    {
        var query = _context.Sales
          .Include(x => x.Products)
          .AsNoTracking();

        //if (string.IsNullOrEmpty(filters))
        //{
        //    query = query.Where(x => x.Number == int.Parse(filters!));
        //}

        if (order == "asc")
            query = query.OrderBy(x => x.Number);
        else
            query = query.OrderByDescending(x => x.Number);

        return query;
    }

    public async Task<Sale?> GetByIdNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Sales
            .Include(x => x.Products)
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Sales
            .Include(x => x.Products)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    public Task<int> GetTotalCountAsync(string filters, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(Sale sale, CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
