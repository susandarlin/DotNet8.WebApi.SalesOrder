using Dapper;
using DotNet8.WebApi.SalesOrder.Models;
using DotNet8.WebApi.SalesOrder.Queries;
using DotNet8.WebApi.SalesOrder.Services;
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
    private readonly DapperService _dapperService;

    public CustomerController(DapperService dapperService)
    {
        _dapperService = dapperService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomersAsync()
    {
        try
        {
            string query = CustomerQuery.GetCustomerListQuery;
            var lst = await _dapperService.QueryAsync<Customer>(query);

            return Ok(lst);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerByIdAsync(Guid id)
    {
        try
        {
            var query = CustomerQuery.GetCustomerById;
            var item = await _dapperService.QueryFirstOrDefaultAsync<Customer>(query, new Customer { customerId = id });
            if (item is null)
                return NotFound("No data found.");

            return Ok(item);
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
            customer.customerId = customerId;
            var parameters = new
            {
                customer.customerId,
                customer.customerName,
                customer.customerPhoneNo,
                customer.customerAddress,
            };

            var result = await _dapperService.ExecuteAsync(query, parameters);
            string message = result > 0 ? "Saving Successful." : "Saving Failed";

            return Content(message);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    [HttpPatch("id")]
    public async Task<IActionResult> PatchCustomerAsync(Guid customerId, Customer customer)
    {
        try
        {
            var query = CustomerQuery.GetCustomerById;
            var item = await _dapperService.QueryFirstOrDefaultAsync<Customer>(query, new Customer { customerId = customerId });
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

            var result = await _dapperService.ExecuteAsync(query, customer);

            var message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Content(message);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomerAsync(Guid id)
    {
        try
        {
            var query = CustomerQuery.GetCustomerById;
            var item = _dapperService.QueryFirstOrDefaultAsync<Customer>(query, new Customer { customerId = id });
            if (item is null)
                return NotFound("No data found.");

            string deleteQuery = CustomerQuery.DeleteCustomerQuery;
            var param = new { customerId = id };
            int result = await _dapperService.ExecuteAsync(deleteQuery, param);
            var message = result > 0 ? "Deleting Successful." : "Deleting Fail";

            return Content(message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

