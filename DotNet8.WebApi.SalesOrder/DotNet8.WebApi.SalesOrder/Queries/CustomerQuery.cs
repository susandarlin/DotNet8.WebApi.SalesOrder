namespace DotNet8.WebApi.SalesOrder.Queries;

public class CustomerQuery
{
    public static string GetCustomerListQuery { get; } =
        @"SELECT [customerId] 
              ,[customerName]
              ,[customerPhoneNo]
              ,[customerAddress]
          FROM [dbo].[Customer]";

    public static string GetCustomerById = @"SELECT [customerId]
                ,[customerName]
                ,[customerPhoneNo]
                ,[customerAddress]
         FROM [dbo].[Customer]
         WHERE [customerId] = @customerId";

    public static string CreateCustomerQuery { get; } =
        @"INSERT INTO [dbo].[Customer]
           ([customerId]
           ,[customerName]
           ,[customerPhoneNo]
           ,[customerAddress])
     VALUES
           (@customerId
           ,@customerName
           ,@customerPhoneNo
           ,@customerAddress)";

    public static string DeleteCustomerQuery { get; } =
        @"Delete
        FROM [dbo].[Customer]
        WHERE [customerId] = @customerId";
}
