using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet8.WebApi.SalesOrder.Models
{
    [Table("Stock")]
    public class Stock
    {
        [Key]
        public Guid stockId { get; set; }
        public string? stockName { get; set; }
        public string? stockDescription { get; set; }
        public double stockPrice { get; set; }
        public int stockOnHandQty { get; set; }
    }
}
