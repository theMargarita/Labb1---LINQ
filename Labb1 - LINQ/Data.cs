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
            using (var context = new E_CommerceContext())
            {
                var electronics = context.Products.Where(p => p.CategoryId == 1).OrderByDescending(p => p.Price);

                foreach (var e in electronics)
                {
                    Console.WriteLine($"Name of the product: {e.Name}  \nPrice: {e.Price:C}\n");
                }
            }
        }

        //Lista alla leverantörer (suppliers) som har produkter med ett lagersaldo under 10 enheter
        //fel på metoden 
        public static void GetSuppliers()
        {
            using (var context = new E_CommerceContext())
            {
                var suppliers = context.Products
                    .Where(p => p.StockQuantity < 10);


                foreach (var s in suppliers)
                {
                    Console.WriteLine($"Name: {s.Supplier.Name} - Product name: {s.Name} -  Stock quantity: {s.StockQuantity}");
                }
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
        }


        //Hitta de 3 mest sålda produkterna baserat på OrderDetail-data
        //Take(3)
        public static void GetTopThreeMostSoldOrderDetailData()
        {
            using (var context = new E_CommerceContext())
            {
                IQueryable<OrderDetail> orderDetails = context.OrderDetails
                //.Where(o => o.ProductId > 2).OrderDescending().Take(3);
                .OrderByDescending(o => o.ProductId > 2).Take(3);

                foreach (var o in orderDetails)
                {
                    Console.WriteLine($"{o.ProductId} - {o.Quantity}");
                }
            }
        }


        //Lista alla kategorier och antalet produkter i varje kategori
        public static void GetCategoryAndProducts()
        {
            //I get atleast an output 
            using (var context = new E_CommerceContext())
            {
                var getCategoryAndProduct = context.Categorys
                    .Select(c => new
                    {
                        Category = c.Name,
                        Product = c.Products.Count()
                    })
                    .ToList();


                foreach (var items in getCategoryAndProduct)
                {
                    Console.WriteLine($"Categories: {items.Category} - Number of Products: {items.Product} ");
                }

            }
        }

        //Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr
        public static void GetCustomerAndOrderDetail()
        {
            using (var context = new E_CommerceContext())
            {
                var getCustomerInfo = context.Orders
                    .Where(o => o.TotalAmount > 100)
                    .Include(c => c.Customer)
                    .Include(od => od.OrderDetails)
                    .ThenInclude(p => p.Product)
                    .ToList();


                foreach (var items in getCustomerInfo)
                {
                    Console.WriteLine($"Order: {items.OrderId}: Customer: {items.Customer.Name} - Total: {items.TotalAmount} kr");
                    foreach (var d in items.OrderDetails)
                    {
                        Console.WriteLine($"Product name: {d.Product.Name}- Quantity: {d.Product.StockQuantity} - Unit price: {d.UnitPrice:C}");
                        Console.WriteLine();
                    }
                }
            }
        }

    }
}
