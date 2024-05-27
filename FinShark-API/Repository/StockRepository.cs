using FinShark_API.Data;
using FinShark_API.Dto.Stock;
using FinShark_API.Interfaces;
using FinShark_API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark_API.Repository;

public class StockRepository : IStockRepository
{
    private readonly ApplicationDBContext _context;

    public StockRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    
    public async Task<List<Stock>> GetAllAsync()
    {
        return await _context.Stock.ToListAsync();
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await _context.Stock.FindAsync(id);
    }

    public async Task<Stock> CreateAsync(Stock stockModel)
    {
        await _context.Stock.AddAsync(stockModel);
        await _context.SaveChangesAsync();

        return stockModel;
    }

    public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
    {
        var exisitingStock = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);

        if (exisitingStock == null)
        {
            return null;
        }
        exisitingStock.Symbol = stockDto.Symbol;
        exisitingStock.CompanyName = stockDto.CompanyName;
        exisitingStock.Purchase = stockDto.Purchase;
        exisitingStock.LastDiv = stockDto.LastDiv;
        exisitingStock.Industry = stockDto.Industry;
        exisitingStock.MarketCap = stockDto.MarketCap;

        await _context.SaveChangesAsync();

        return exisitingStock;
    }

    public async Task<Stock?> DeleteAsync(int id)
    {
        var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);

        if (stockModel == null)
        {
            return null;
        }

        _context.Stock.Remove(stockModel);
        await _context.SaveChangesAsync();
        return stockModel;
    }
}