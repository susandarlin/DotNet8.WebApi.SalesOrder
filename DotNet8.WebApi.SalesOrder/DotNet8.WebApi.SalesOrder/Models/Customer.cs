namespace DotNet8.WebApi.SalesOrder.Models
{
    public class Customer
    {
        public Guid customerId { get; set; }
        public string? customerName { get; set; }
        public int customerPhoneNo { get; set; }
        public string? customerAddress { get; set; }
    }
}
