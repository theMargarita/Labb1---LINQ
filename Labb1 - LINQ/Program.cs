namespace Labb1___LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Data.GetCategoryAndProducts();
            //Data.GetTopThreeMostSoldOrderDetailData();

            Console.WriteLine("" +
                "1: Hämta alla produkter i kategorin \"Electronics\" och sortera dem efter pris (högst först)\n" +
                "2: Lista alla leverantörer (suppliers) som har produkter med ett lagersaldo under 10 enheter \n" +
                "3: Get total amount of the past month amount \n" +
                "4: Most Sold Item\n" +
                "5: Get  Categorys and their products\n" +
                "6: \n" +
                "7:Shut of the program " +
                "");

            while (true)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Data.GetElectronices();
                        break;

                    case "2":
                        Data.GetSuppliers();
                        break;

                    case "3":
                        Data.GetOrders();
                        break;

                    case "4":
                        Data.GetTopThreeMostSoldOrderDetailData();
                        break;

                    case "5":
                        Data.GetCategoryAndProducts();
                        break;

                    case "6":
                        Data.GetCustomerAndOrderDetail();
                        break;

                    case "7":
                        Console.WriteLine("Escaping");
                        return;
                    //break;

                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }
            }
        }
    }
}
