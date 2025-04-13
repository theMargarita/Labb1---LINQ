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
        public static void GetSuppliers()
        {
            using (var context = new E_CommerceContext())
            {
                var suppliers = context.Products.Include(p => p.Supplier).Where(p => p.StockQuantity < 10);


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

                var totalPriceOfORders = context.Orders
                    .Where(o => o.OrderDate == DateTime.Today.AddDays(-31))
                    .Sum(o => o.TotalAmount);

                Console.WriteLine($"Total past months order {totalPriceOfORders}");


                var totalAmount = context.Orders
                    .Where(o => o.OrderDate == DateTime.Today.AddDays(-31))
                    .Select(o => new
                    {
                        Date = o.OrderDate,
                        Total = o.TotalAmount
                    }).ToList();

                foreach (var t in totalAmount)
                {
                    Console.WriteLine($"Something: {t.Date} {t.Total}");
                }
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
                    //.Include(p => p.Products)
                    .Select(p => new
                    {
                        Category = p.Name,
                        Count = p.Products.Count()
                    }).ToList();


                foreach (var p in getCategoryAndProduct)
                {
                    Console.WriteLine($"{p.Category} - {p.Count}");
                }

            }
        }

        //Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr
        public static void GetCustomerAndOrderDetail()
        {
            using (var context = new E_CommerceContext())
            {

            }
        }

    }
}
