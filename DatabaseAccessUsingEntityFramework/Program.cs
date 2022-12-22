using DatabaseAccessUsingEntityFramework;
using Microsoft.EntityFrameworkCore;

using (var dbContext = new AdventureWorksContext())
{
    //ReadProducts(dbContext);
    //ReadCustomersWithAddresses(dbContext);
    //UpdateExample(dbContext);
    //DeleteExample(dbContext);
    InsertExample(dbContext);
}

void InsertExample(AdventureWorksContext dbContext)
{
    var newAddress = new Address
    {
        AddressLine1 = "Sucharskiego",
        AddressLine2 = "2",
        City = "Rzeszów",
        CountryRegion = "Podkarpackie",
        PostalCode = "35-225",
        StateProvince = "Rzeszów - miasto"
    };

    dbContext.Addresses.Add(newAddress);
    dbContext.SaveChanges();
}

static void ReadProducts(AdventureWorksContext dbContext)
{
    foreach (var product in dbContext.Products)
    {
        Console.WriteLine($"{product.Name} ({product.ProductId}) {product.Color}");
    }
}

static void ReadCustomersWithAddresses(AdventureWorksContext dbContext)
{
    var customers = dbContext.Customers
        .Include(x => x.CustomerAddresses)
        .ThenInclude(x => x.Address)
        .Where(x => x.CustomerAddresses.Count > 0)
        .OrderByDescending(x => x.CustomerAddresses.Count);

    foreach (var customer in customers) //!! keep in mind that your work with db under the hood
    {
        Console.WriteLine($"{customer.FirstName} {customer.LastName} has {customer.CustomerAddresses.Count} addresses");
        foreach (var address in customer.CustomerAddresses)
        {
            Console.WriteLine($"   {address.Address.City}");
        }
    }
}

static void UpdateExample(AdventureWorksContext dbContext)
{
    var firstCustomer = dbContext.Customers.First(x => x.FirstName == "Christopher" && x.LastName == "Beck");

    Console.WriteLine(firstCustomer.Suffix);

    firstCustomer.Suffix = "Sr.";
    dbContext.SaveChanges();
}

static void DeleteExample(AdventureWorksContext dbContext)
{
    var salesOrderDetailToDelete = dbContext.SalesOrderDetails.First(x => x.SalesOrderDetailId == 110562);
    Console.WriteLine(salesOrderDetailToDelete.LineTotal);

    dbContext.SalesOrderDetails.Remove(salesOrderDetailToDelete);
    dbContext.SaveChanges();
}