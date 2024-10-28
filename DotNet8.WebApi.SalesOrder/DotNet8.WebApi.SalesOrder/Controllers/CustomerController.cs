using Dapper;
using DotNet8.WebApi.SalesOrder.Models;
using DotNet8.WebApi.SalesOrder.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace DotNet8.WebApi.SalesOrder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public CustomerController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomersAsync()
    {
        try
        {
            string query = CustomerQuery.GetCustomerListQuery;
            using IDbConnection db = new SqlConnection(
                _configuration.GetConnectionString("DbConnection")
            );

            var lst = await db.QueryAsync<Customer>(query);

            return Ok(lst);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostCustomerAsync(Customer customer)
    {
        try
        {
            string query = CustomerQuery.CreateCustomerQuery;
            var customerId = Guid.NewGuid();
            customer.customerId = customerId.ToString();
            var parameters = new
            {
                customer.customerId,
                customer.customerName,
                customer.customerPhoneNo,
                customer.customerAddress,
            };

            using IDbConnection db = new SqlConnection(
                _configuration.GetConnectionString("DbConnection")
            );
            var result = await db.ExecuteAsync(query, parameters);
            string message = result > 0 ? "Saving Successful." : "Saving Failed";

            return Content(message);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    //public Customer? FindById(string id)
    //{
    //    var item = new Customer();
    //    var query = CustomerQuery.GetCustomerById;
    //    using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));

    //    item = db.Query<Customer>(query, new Customer { customerId = id }).FirstOrDefault();
    //    return item;
    //}

    [HttpPatch("id")]
    public async Task<IActionResult> PatchCustomerAsync(string customerId, Customer customer)
    {
        try
        {
            //var item = FindById(customerId);

            var query = CustomerQuery.GetCustomerById;
            using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));

            var item = db.Query<Customer>(query, new Customer { customerId = customerId }).FirstOrDefault();
            if (item is null)
            {
                return NotFound("No data to Update.");
            }

            var conditions = string.Empty;

            if (!string.IsNullOrEmpty(customer.customerName))
            {
                conditions += " [customerName] = @customerName, ";
            }
            if (!string.IsNullOrEmpty(customer.customerPhoneNo))
            {
                conditions += " [customerPhoneNo] = @customerPhoneNo, ";
            }
            if (!string.IsNullOrEmpty(customer.customerAddress))
            {
                conditions += " [customerAddress] = @customerAddress, ";
            }
            if (conditions.Length == 0)
            {
                return NotFound("No data found to update");
            }

            conditions = conditions.Substring(0, conditions.Length - 2);
            customer.customerId = customerId;

            query = $@"UPDATE [dbo].[Customer]
                        SET {conditions}
                        WHERE [customerId] = @customerId";

            //using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
            var result = await db.ExecuteAsync(query, customer);

            var message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Content(message);

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
