using Labb1___LINQ.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Labb1___LINQ
{
    public class Data
    {
        //Hämta alla produkter i kategorin "Electronics" och sortera dem efter pris (högst först)
        public static void GetElectronices()
        {
            Console.WriteLine();
            using (var context = new E_CommerceContext())
            {
                var electronics = context.Products.Where(p => p.CategoryId == 1).OrderByDescending(p => p.Price);

                foreach (var e in electronics)
                {
                    Console.WriteLine($"Name of the product: {e.Name}  \nPrice: {e.Price:C}\n");
                }

                Console.WriteLine();
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Lista alla leverantörer (suppliers) som har produkter med ett lagersaldo under 10 enheter
        public static void GetSuppliers()
        {
            using (var context = new E_CommerceContext())
            {
                var suppliers = context.Products
                    .Where(p => p.StockQuantity < 10)
                    .Select(p => p.Supplier).Distinct().ToList();

                foreach (var s in suppliers)
                {
                    Console.WriteLine($"Name: {s.Name}");
                }

                Console.WriteLine();
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Beräkna det totala ordervärdet för alla ordrar gjorda under den senaste månaden
        public static void GetOrders()
        {
            using (var context = new E_CommerceContext())
            {
                //to clarify one month back
                var oneMonthAgo = DateTime.Today.AddMonths(-1);
                //to clarify todays date
                var today = DateTime.Today;

                var totalPriceOfORders = context.Orders
                    .Where(o => o.OrderDate >= oneMonthAgo && o.OrderDate <= today)
                    .Sum(o => o.TotalAmount);

                Console.WriteLine($"Total cost of the past month order: {totalPriceOfORders.ToString()} kr");
            }
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }


        //Hitta de 3 mest sålda produkterna baserat på OrderDetail-data
        public static void GetTopThreeMostSoldOrderDetailData()
        {
            using (var context = new E_CommerceContext())
            {
                //IQueryable<OrderDetail> orderDetails = context.OrderDetails
                ////.Where(o => o.ProductId > 2).OrderDescending().Take(3);
                //.OrderByDescending(o => o.ProductId).Take(3);

                var orderDetailsTopThreee = context.OrderDetails
                    .GroupBy(od => od.Product.Name)
                    .Select(od => new
                    {
                        Name = od.Key,
                        TotalQuantity = od.Sum(q => q.Quantity)

                    }).OrderByDescending(tq => tq.TotalQuantity)
                    .Take(3)
                    .ToList();


                foreach (var o in orderDetailsTopThreee)
                {
                    Console.WriteLine($"{o.Name} - Total Quantity: {o.TotalQuantity}");
                }
                Console.WriteLine();
                Console.ReadKey();
                Console.Clear();
            }
        }


        //Lista alla kategorier och antalet produkter i varje kategori
        public static void GetCategoryAndProducts()
        {
            //I get atleast an output 
            using (var context = new E_CommerceContext())
            {
                var getCategoryAndProduct = context.Products
                    .GroupBy(p => p.Category)
                    .Select(g => new
                    {
                        Category = g.Key,
                        ProductAmount = g.Count()
                    })
                    .ToList();

                Console.WriteLine("Categories:");
                foreach (var items in getCategoryAndProduct)
                {
                    Console.WriteLine($" {items.Category.Name} - Number of Products: {items.ProductAmount} ");
                }

                Console.WriteLine();
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr
        public static void GetCustomerAndOrderDetail()
        {
            using (var context = new E_CommerceContext())
            {
                var getCustomerInfo = context.Orders
                    .Where(o => o.TotalAmount > 1000)
                    .Include(c => c.Customer)
                    .Include(od => od.OrderDetails)
                    .ThenInclude(p => p.Product)
                    .ToList();


                foreach (var items in getCustomerInfo)
                {
                    Console.WriteLine($"Order: {items.OrderId}: Customer: {items.Customer.Name} - Total: {items.TotalAmount:C}");
                    foreach (var d in items.OrderDetails)
                    {
                        Console.WriteLine($"Product name: {d.Product.Name}- Quantity: {d.Product.StockQuantity} - Unit price: {d.UnitPrice:C}");
                        Console.WriteLine();
                    }
                }

                Console.WriteLine();
                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}
