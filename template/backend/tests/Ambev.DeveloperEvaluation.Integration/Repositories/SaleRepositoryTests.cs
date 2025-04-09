using Ambev.DeveloperEvaluation.ORM.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Microsoft.EntityFrameworkCore;
using Xunit;
using FizzWare.NBuilder;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Integration.Repositories;

public class SaleRepositoryTests
{
    /// <summary>
    /// The options for the in-memory database context.
    /// </summary>
    private readonly DbContextOptions<DefaultContext> _dbContextOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="SaleRepositoryTests"/> class.
    /// </summary>
    public SaleRepositoryTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<DefaultContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
    }

    [Fact(DisplayName = "Should add sale to database when valid sale is provided")]
    public async Task GivenValidSale_WhenCreateAsyncCalled_ThenAddsSaleToDatabase()
    {
        // Arrange
        using var context = new DefaultContext(_dbContextOptions);
        var _sut = new SaleRepository(context);
        var newSale = Builder<Sale>.CreateNew()
            .With(x =>x.Id, Guid.NewGuid())
            .Build();

        // Act
        var createdSale = await _sut.CreateAsync(newSale);

        // Assert
        Assert.NotNull(createdSale);
        Assert.Equal(newSale.Id, createdSale.Id);
    }

    [Fact(DisplayName = "Should return sale when existing ID is provided")]
    public async Task GivenExistingSaleId_WhenGetByIdAsyncCalled_ThenReturnsSale()
    {
        // Arrange
        using var context = new DefaultContext(_dbContextOptions);
        var _sut = new SaleRepository(context);
        var existingSale = Builder<Sale>.CreateNew()
            .With(x => x.Id, Guid.NewGuid())
            .Build();
        await context.Sales.AddAsync(existingSale);
        await context.SaveChangesAsync();

        // Act
        var retrievedSale = await _sut.GetByIdAsync(existingSale.Id);

        // Assert
        Assert.NotNull(retrievedSale);
        Assert.Equal(existingSale.Id, retrievedSale.Id);
    }

    [Fact(DisplayName = "Should update sale details when sale exists")]
    public async Task GivenExistingSale_WhenUpdateAsyncCalled_ThenUpdatesSaleDetails()
    {
        // Arrange
        using var context = new DefaultContext(_dbContextOptions);
        var _sut = new SaleRepository(context);
        var originalSale = Builder<Sale>.CreateNew()
            .With(x => x.Id, Guid.NewGuid())
            .Build();
        await context.Sales.AddAsync(originalSale);
        await context.SaveChangesAsync();

        // Act
        originalSale.Update(originalSale.Number, originalSale.CustomerId, "Updated Branch");
        var updateResult = await _sut.UpdateAsync(originalSale);

        // Assert
        Assert.True(updateResult);
        var updatedSale = await _sut.GetByIdAsync(originalSale.Id);
        Assert.Equal("Updated Branch", updatedSale?.Branch);
    }

    [Fact(DisplayName = "Should delete sale when existing")]
    public async Task GivenExistingSaleId_WhenDeleteAsyncCalled()
    {
        // Arrange
        using var context = new DefaultContext(_dbContextOptions);
        var _sut = new SaleRepository(context);
        var saleToCancel = Builder<Sale>.CreateNew()
            .With(x => x.Id, Guid.NewGuid())
            .Build();
        await context.Sales.AddAsync(saleToCancel);
        await context.SaveChangesAsync();

        // Act
        var deleteResult = await _sut.DeleteAsync(saleToCancel);

        // Assert
        Assert.True(deleteResult);
    }


}
