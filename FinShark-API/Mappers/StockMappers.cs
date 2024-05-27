using FinShark_API.Dto.Stock;
using FinShark_API.Models;

namespace FinShark_API.Mappers;

public static class StockMappers
{
    public static StockDto ToStockDto(this Stock stockModel)
    {
        return new StockDto
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Purchase = stockModel.Purchase,
            LastDiv = stockModel.LastDiv,
            Industry = stockModel.Industry,
            MarketCap = stockModel.MarketCap
        };
    }

    public static Stock ToStockFromCreateDto(this CreateStockRequestDto dto)
    {
        return new Stock
        {
            Symbol = dto.Symbol,
            CompanyName = dto.CompanyName,
            Purchase = dto.Purchase,
            LastDiv = dto.LastDiv,
            Industry = dto.Industry,
            MarketCap = dto.MarketCap
        };
    }
}