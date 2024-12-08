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
}
