using System;

namespace EntityFrameworkSample;

public class Program
{
    public static void Main(string[] args)
    {
        //Adding();
        //Taking();
        //RemoveProduct(2);
        // MakeSale();
        ShowSales();
        Console.ReadLine();
    }
    public static void Adding()
    {
        using (var context = new MyDbContext())
        {
            Product p1 = new Product
            {
                Name = "Product 2",
                Price = 155.99M
            };
            StaffMemeber staff1 = new StaffMemeber
            {
                FirstName = "Jonas",
                LastName = "Jonaitis",
                DateOfBirth = DateOnly.Parse("2000-01-08")
            };
            context.Products.Add(p1);
            context.StaffMemebers.Add(staff1);
            context.SaveChanges();
        }
    }
    public static void Taking()
    {
        using(var context = new MyDbContext())
        {
            List<Product> allProducts = context.Products.ToList();
            Product productWithId2 = context.Products.Find(2);
            foreach (Product p in allProducts)
            {
                Console.WriteLine($"{p.Id} {p.Name} {p.Price}");
            }
            Console.WriteLine($"Product with id 2 {productWithId2.Id} {productWithId2.Name} {productWithId2.Price}");
        }
        
    }
    public static void RemoveProduct(int id)
    {
        using(var context = new MyDbContext())
        {
            context.Products.Remove(context.Products.Find(id));
            context.SaveChanges();
        }
    }
    public static void MakeSale()
    {
        using(var context = new MyDbContext())
        {
            Sale newSale = new Sale
            {
                ProductSold = context.Products.Find(1),
                SalesPerson = context.StaffMemebers.Find(1)
            };
            context.Sales.Add(newSale);
            context.SaveChanges();
        }
    }
    public static void ShowSales()
    {
        using(var context = new MyDbContext())
        {
            List<Sale> allSales = context.Sales.ToList();
                
            foreach(Sale sale in allSales)
            {
                context.Entry(sale).Reference(x => x.ProductSold).Load();
                context.Entry(sale).Reference(x => x.SalesPerson).Load();
                Console.WriteLine($"{sale.SaleId} {sale.SalesPerson.FirstName} {sale.SalesPerson.LastName} {sale.ProductSold.Name} {sale.ProductSold.Price}");
            }
        }

    }
}