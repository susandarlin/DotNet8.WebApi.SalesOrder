namespace DotNet8.WebApi.SalesOrder.Queries;

public class CustomerQuery
{
    public static string GetCustomerListQuery { get; } =
        @"SELECT [customerId] 
              ,[customerName]
              ,[customerPhoneNo]
              ,[customerAddress]
              ,[isDeleted]
          FROM [dbo].[Customer]
          WHERE isDeleted = 0
          ORDER BY customerId Desc";

    public static string GetCustomerById = @"SELECT [customerId]
                ,[customerName]
                ,[customerPhoneNo]
                ,[customerAddress]
                ,[isDeleted]
         FROM [dbo].[Customer]
         WHERE [customerId] = @customerId";

    public static string CreateCustomerQuery { get; } =
        @"INSERT INTO [dbo].[Customer]
           ([customerId]
           ,[customerName]
           ,[customerPhoneNo]
           ,[customerAddress])
           ,[isDeleted]
     VALUES
           (@customerId
           ,@customerName
           ,@customerPhoneNo
           ,@customerAddress)";

    public static string DeleteCustomerQuery { get; } =
        @"UPDATE [dbo].[Customer]
        SET isDeleted = 1 
        WHERE [customerId] = @customerId";
}
