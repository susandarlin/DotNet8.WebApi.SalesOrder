using DotNet8.WebApi.SalesOrder.Models;
using Microsoft.EntityFrameworkCore;
namespace DotNet8.WebApi.SalesOrder.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Stock> Stocks { get; set; }
}