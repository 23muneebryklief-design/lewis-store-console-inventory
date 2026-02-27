namespace lewis_store_inventory_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
             const int MAX_ITEMS = 100;

                string[] itemNames = new string[MAX_ITEMS];
                string[] itemDescriptions = new string[MAX_ITEMS];
                double[] itemPrices = new double[MAX_ITEMS];
                int[] itemQuantities = new int[MAX_ITEMS];
                int itemCount = 0;
                const double VAT = 0.15;
                

            bool running = true;
            while (running)
            {
                Console.WriteLine("======================================================");
                Console.WriteLine("*********LEWIS STORE INVENTORY SYSTEM*********");
                Console.WriteLine("======================================================");
                Console.WriteLine("1. Add Stock");
                Console.WriteLine("2. View Stock");
                Console.WriteLine("3. Sell Item");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter Option: ");
                 int choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > 4)
                  {
                     Console.WriteLine("Invalid Option. Please try again.");
                     continue;  
                  }

               switch (choice)
               {
                 case 1:
                         Console.WriteLine("**********Add Stock*********");
                        if (itemCount>=MAX_ITEMS)
                        {
                            Console.WriteLine("The inventory is full");
                            break;
                        }
                        Console.WriteLine("===============================");
                        Console.WriteLine("Enter the name of the item: ");
                        string name = Console.ReadLine();
                        while  (string.IsNullOrWhiteSpace(name))
                        {
                             Console.WriteLine("===============================");
                            Console.WriteLine("Item name cannot be empty. Enter name:");
                            name = Console.ReadLine();
                        }
                         Console.WriteLine("===============================");
                        Console.WriteLine("Enter Item Description: ");
                        string description = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(description))
                        {
                             Console.WriteLine("===============================");
                             Console.WriteLine("Description cannot be empty. Enter the description");
                            description = Console.ReadLine();
                        }
                        Console.WriteLine("===============================");
                        Console.WriteLine("Enter The Price Of The Product: ");
                        double price;

                        while (!double.TryParse(Console.ReadLine(), out price) || price < 0)
                        {
                            Console.WriteLine("===============================");
                          Console.WriteLine("Invalid price. Enter a valid positive number:");
                        }
                        Console.WriteLine("===============================");
                        Console.WriteLine("Enter The Item Quantity: ");
                        int qty;
                        while (!int.TryParse(Console.ReadLine(), out qty) || qty < 0)
                        {
                            Console.WriteLine("===============================");
                            Console.WriteLine("Invalid quantity. Enter a valid quantity: ");
                        }
                         itemNames[itemCount] = name;
                         itemDescriptions[itemCount] = description;
                         itemPrices[itemCount] = price;
                         itemQuantities[itemCount] = qty;
                         itemCount++;
                        Console.WriteLine("+++++++Item Added Successfully!++++++");
                        break;

                
                
                 case 2:
                 Console.WriteLine("View Stock selected.");
                 break;

                case 3:
                Console.WriteLine("Sell Item selected.");
                 break;

                case 4:
                 running = false;   
                 Console.WriteLine("Exiting system...");
                break;
              }
            }
        }
    }
}
