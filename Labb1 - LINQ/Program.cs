namespace Labb1___LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //Console.Clear();
                ShowMenu();

                //Console.Clear();

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //Works
                        Data.GetElectronices();
                        break;

                    case "2":
                        //nope
                        Data.GetSuppliers();
                        break;

                    case "3":
                        //? maybe
                        Data.GetOrders();
                        break;

                    case "4":
                        //dont really know
                        Data.GetTopThreeMostSoldOrderDetailData();
                        break;

                    case "5":
                        //works
                        Data.GetCategoryAndProducts();
                        break;

                    case "6":
                        //works??
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
        public static void ShowMenu()
        {

            Console.WriteLine("" +
                "1: Hämta alla produkter i kategorin \"Electronics\" och sortera dem efter pris (högst först)\n" +
                "2: Lista alla leverantörer (suppliers) som har produkter med ett lagersaldo under 10 enheter \n" +
                "3: Get total amount of the past month amount \n" +
                "4: Most Sold Item\n" +
                "5: Get  Categories and their products\n" +
                "6: Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr\n" +
                "7:Shut of the program " +
                "");

        }
    }
}
