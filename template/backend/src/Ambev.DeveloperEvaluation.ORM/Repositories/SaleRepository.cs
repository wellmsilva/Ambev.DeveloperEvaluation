using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    public IQueryable<Sale> GetAllAsync(string? orderField, string? order = "asc", CancellationToken cancellationToken = default)
    {
        var query = _context.Sales
          .Include(x => x.Products)
          .AsNoTracking();

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
     

    public async Task<bool> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> DeleteAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        _context.Sales.Remove(sale);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
