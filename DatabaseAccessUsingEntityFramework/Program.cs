using DatabaseAccessUsingEntityFramework;
using Microsoft.EntityFrameworkCore;

using (var dbContext = new AdventureWorksContext())
{
    var task1 = dbContext.Customers.Select(x => $"{x.FirstName} {x.LastName}");
    foreach (var item in task1)
    {
        Console.WriteLine(item);
    }

    var task2 = dbContext.Addresses.Select(x => x.CountryRegion);
    foreach (var item in task2)
    {
        Console.WriteLine(item);
    }

    var task3 = dbContext.Addresses.Select(x => x.CountryRegion).Distinct();
    foreach (var item in task3)
    {
        Console.WriteLine(item);
    }

    var task4 = dbContext.CustomerAddresses.Select(x => x.AddressType).Distinct().Count();
    Console.WriteLine(task4);

    var task5 = dbContext.SalesOrderHeaders.Where(x => x.CustomerId == 30050);
    foreach (var item in task5)
    {
        Console.WriteLine(item.SalesOrderId);
    }

    var task6 = dbContext.SalesOrderHeaders.Count();
    Console.WriteLine(task6);


    var task7 = dbContext
        .Products
        .Include(x => x.ProductCategory) //this is because by default EF does not load related tables
        .OrderBy(x => x.SellStartDate)
        .First()
        .ProductCategory
        .Name;
    Console.WriteLine(task7);

    var task8 = dbContext
        .Customers
        .Include(x => x.CustomerAddresses)
        .Where(x => x.CustomerAddresses.Count() > 1);

    foreach (var item in task8)
    {
        Console.WriteLine(item.LastName);
        foreach (var address in item.CustomerAddresses)
        {
            Console.WriteLine("     " + address.AddressId);
        }
    }

    var task9 = dbContext
        .Products
        .Where(x => x.Name.Contains("Road Frame"))
        .Count();

    Console.WriteLine(task9);

    var task10 = dbContext
        .SalesOrderHeaders
        .Include(x => x.SalesOrderDetails)
        .OrderByDescending(x => x.SalesOrderDetails.Count())
        .First();
    Console.WriteLine($"Order with id {task10.SalesOrderId} has {task10.SalesOrderDetails.Count()}");

    var task11 = dbContext
        .SalesOrderHeaders
        .Include(x => x.Customer)
        .OrderByDescending(x => x.TaxAmt)
        .First()
        .Customer;

    Console.WriteLine($"{task11.FirstName} {task11.LastName}");

    var task12 = dbContext
        .ProductDescriptions
        .OrderByDescending(x => x.Description.Length)
        .Select(x => x.ProductModelProductDescriptions.)

    var taskB1 = dbContext
        .Customers
        .Where(x => x.FirstName == "Joseph" && x.LastName == "Castellucio");

    foreach (var item in taskB1)
    {
        Console.WriteLine(item.CustomerId);
        item.CompanyName = "University of Information Technology and Management";
    }
    dbContext.SaveChanges();

    var newCustomer = new Customer
    {
        NameStyle = false,
        FirstName = "James",
        LastName = "Bond",
        PasswordHash = "7dnLSdRuWFKBMjmORanIkwGVy3smf5yZI3YxSSyd5/U=",
        PasswordSalt = "jH5dJh4=",
        Rowguid = Guid.NewGuid(),
        ModifiedDate = DateTime.Now
    };
    dbContext.Customers.Add(newCustomer);
    dbContext.SaveChanges();

    //ReadProducts(dbContext);
    //ReadCustomersWithAddresses(dbContext);
    //UpdateExample(dbContext);
    //DeleteExample(dbContext);
    //InsertExample(dbContext);
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