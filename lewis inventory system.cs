namespace lewis_store_inventory_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
          

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n=== LEWIS STORE INVENTORY SYSTEM ===");
                Console.WriteLine("1. Add Stock");
                Console.WriteLine("2. View Stock");
                Console.WriteLine("3. Sell Item");
                Console.WriteLine("4. Exit");
                Console.Write("Select option: ");
               
                const int MAX_ITEMS = 100;

                string[] itemNames = new string[MAX_ITEMS];
                string[] itemDescriptions = new string[MAX_ITEMS];
                double[] itemPrices = new double[MAX_ITEMS];
                int[] itemQuantities = new int[MAX_ITEMS];

                // tracks how many items exist
                int itemCount = 0;

                int choice = int.Parse(Console.ReadLine());


                if (choice == 1)
                {

                    {
                        if (itemCount >= MAX_ITEMS)
                        {
                            Console.WriteLine("Inventory is full. Cannot add more items.");
                            return;
                        }

                        Console.Write("Enter item name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter item description: ");
                        string description = Console.ReadLine();

                        // Validate price
                        double price;
                        Console.Write("Enter price (excluding VAT): ");
                        while (!double.TryParse(Console.ReadLine(), out price) || price < 0)
                        {
                            Console.Write("Invalid price. Enter a positive number: ");
                        }

                        // Validate quantity
                        int quantity;
                        Console.Write("Enter quantity: ");
                        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
                        {
                            Console.Write("Invalid quantity. Enter a non-negative integer: ");
                        }

                        itemNames[itemCount] = name;
                        itemDescriptions[itemCount] = description;
                        itemPrices[itemCount] = price;
                        itemQuantities[itemCount] = quantity;

                        itemCount++;

                        Console.WriteLine("Stock item added successfully.");
                    }
                }
                else if (choice == 2)
                {
                    
                }
                else if (choice == 3)
                {
                    Console.WriteLine("chose 3");
                }
                else if (choice == 4)
                {
                    bool ruuning = false;
                }
                else
                {
                    Console.WriteLine("Invalid");
                }

            }

        }
    }
}
