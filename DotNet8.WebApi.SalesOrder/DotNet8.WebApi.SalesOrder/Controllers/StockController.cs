using DotNet8.WebApi.SalesOrder.Db;
using DotNet8.WebApi.SalesOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.WebApi.SalesOrder.Controllers;

[Route("api/controller")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly AppDbContext _db;

    public StockController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStocksAsync()
    {
        try
        {
            var lst = await _db.Stocks.ToListAsync();
            return Ok(lst);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStockAsync(Guid id)
    {
        var stock = await _db.Stocks.FindAsync(id);
        if (stock is null)
            return NotFound("No data found.");

        return Ok(stock);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStockAsync(StockRequestModel requestModel)
    {
        var stock = new Stock()
        {
            stockName = requestModel.stockName,
            stockDescription = requestModel.stockDescription,
            stockPrice = requestModel.stockPrice,
            stockOnHandQty = requestModel.stockOnHandQty
        };
        await _db.Stocks.AddAsync(stock);
        var result = await _db.SaveChangesAsync();

        var message = result > 0 ? "Creating Successful." : "Creating Failed.";

        return Ok(message);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateStockAsync(Guid id, StockRequestModel requestModel)
    {
        var stock = await _db.Stocks.FindAsync(id);
        if (stock is null)
            return NotFound("No data found.");

        if(!string.IsNullOrEmpty(requestModel.stockName))
            stock.stockName = requestModel.stockName;
        if(!string.IsNullOrEmpty(requestModel.stockDescription))
            stock.stockDescription = requestModel.stockDescription;
        if(requestModel.stockPrice > 0)
            stock.stockPrice = requestModel.stockPrice;
        if(requestModel.stockOnHandQty > 0)
            stock.stockOnHandQty = requestModel.stockOnHandQty;

        var result = await _db.SaveChangesAsync();

        var message = result > 0 ? "Updating Successful." : "Creating Failed.";
        return Ok(message);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var stock = _db.Stocks.FirstOrDefault(s => s.stockId == id);
        if (stock is null)
            return NotFound("No data found.");

        _db.Stocks.Remove(stock!);
        var result = await _db.SaveChangesAsync();

        var message = result > 0 ? "Deleting Successful." : "Deleting Failed.";

        return Ok(message);
    }
}
