namespace DotNet8.WebApi.SalesOrder.Models
{
    public class Stock
    {
        public Guid stockId { get; set; }
        public string? stockName { get; set; }
        public string? stockDescription { get; set; }
        public float stockPrice { get; set; }
        public int stockOnHandQty { get; set; }
    }
}
