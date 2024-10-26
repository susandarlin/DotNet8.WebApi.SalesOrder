namespace DotNet8.WebApi.SalesOrder.Models
{
    public class SaleOrder
    {
        public Guid soId { get; set; }
        public Customer? customer { get; set; }
        public List<Stock>? stocks { get; set; }
        public DateTime soDate { get; set; }
    }
}
