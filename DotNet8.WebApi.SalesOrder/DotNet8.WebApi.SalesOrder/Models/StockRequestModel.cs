namespace DotNet8.WebApi.SalesOrder.Models;

public class StockRequestModel
{
    public string? stockName { get; set; }
    public string? stockDescription { get; set; }
    public double stockPrice { get; set; }

    public int stockOnHandQty { get; set; }
}
