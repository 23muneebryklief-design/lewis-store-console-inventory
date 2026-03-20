// Namespace groups related code together
namespace lewis_store_inventory_system
{
    // Main program class
    internal class Program
    {
        // Entry point of the program
        static void Main(string[] args)
        {
            // Maximum number of items that the inventory is able to store
            const int MAX_ITEMS = 100;

            // VAT rate used to calculate sales
            const double VAT = 0.15;

            // Parallel arrays used to store information about items
            string[] itemNames = new string[MAX_ITEMS];        // stores item names
            string[] itemDescriptions = new string[MAX_ITEMS]; // stores item descriptions
            double[] itemPrices = new double[MAX_ITEMS];       // stores item prices
            int[] itemQuantities = new int[MAX_ITEMS];         // stores item quantities

            // Tracks how many items currently exist in the inventory
            int itemCount = 0;

            // Controls whether the program keeps or not
            bool running = true;

            // Main menu loop (the program runs while running = true)
            while (running)
            {
                Console.WriteLine("======================================================");
                Console.WriteLine("********* LEWIS STORE INVENTORY SYSTEM *********");
                Console.WriteLine("======================================================");
                Console.WriteLine("1. Add Stock");
                Console.WriteLine("2. View Stock");
                Console.WriteLine("3. Sell Item");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter Option: ");

                // Variable used to store the choice from the user
                int choice;

                // Menu input validation
                // Ensureing that the user enters a number that is between 1 and 4
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid option. Enter a number between 1 and 4: ");
                }

                // Switch statement is used to execute different actions based on the menu option
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("********** ADD STOCK **********");

                        // Prevents adding items if inventory is full
                        if (itemCount >= MAX_ITEMS)
                        {
                            Console.WriteLine("The inventory is full.");
                            break;
                        }

                        // Ask admin for item name
                        Console.WriteLine("Enter item name (or type cancel): ");
                        string name = Console.ReadLine();

                        // Allow admin to cancel the add process
                        if (name != null && name.ToLower() == "cancel")
                        {
                            Console.WriteLine("Add Stock cancelled. Returning to menu.");
                            break;
                        }

                        // Validate that item name is not empty
                        while (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Item name cannot be empty. Enter item name: ");
                            name = Console.ReadLine();

                            if (name?.Trim().ToLower() == "cancel")
                            {
                                Console.WriteLine("Add Stock cancelled. Returning to menu.");
                                break;
                            }
                        }

                        // Checking if the item entered already exists in the inventory
                        int existingIndex = -1;

                        for (int i = 0; i < itemCount; i++)
                        {
                            if (itemNames[i].ToLower() == name.ToLower())
                            {
                                existingIndex = i;
                                break;
                            }
                        }

                        // If the item entered already exists, update its quantity instead of creating a new item
                        if (existingIndex != -1)
                        {
                            Console.WriteLine("This item already exists.");
                            Console.WriteLine($"Current quantity: {itemQuantities[existingIndex]}");
                            Console.WriteLine("Enter quantity to add (or type -1 to cancel): ");

                            int extraQty;

                            // Validating quantity input
                            while (!int.TryParse(Console.ReadLine(), out extraQty) || extraQty < -1)
                            {
                                Console.WriteLine("Invalid quantity. Enter a valid quantity, or -1 to cancel: ");
                            }

                            // Cancel update if user enters -1
                            if (extraQty == -1)
                            {
                                Console.WriteLine("Stock update cancelled. Returning to menu.");
                                break;
                            }

                            // Increase existing item quantity
                            itemQuantities[existingIndex] += extraQty;

                            Console.WriteLine("Stock quantity updated successfully.");
                            break;
                        }

                        // Ask for item description
                        Console.WriteLine("Enter item description (or type cancel): ");
                        string description = Console.ReadLine();

                        if (description.ToLower() == "cancel")
                        {
                            Console.WriteLine("Add Stock cancelled. Returning to menu.");
                            break;
                        }

                        // Validate that the description is not empty
                        while (string.IsNullOrWhiteSpace(description))
                        {
                            Console.WriteLine("Description cannot be empty. Enter item description: ");
                            description = Console.ReadLine();

                            if (description.ToLower() == "cancel")
                            {
                                Console.WriteLine("Add Stock cancelled. Returning to menu.");
                                break;
                            }
                        }

                        if (description.ToLower() == "cancel")
                        {
                            break;
                        }

                        // Ask for item price
                        Console.WriteLine("Enter item price (or type -1 to cancel): ");
                        double price;

                        // Validate the entered price input
                        while (!double.TryParse(Console.ReadLine(), out price) || price < -1)
                        {
                            Console.WriteLine("Invalid price. Enter a valid price, or -1 to cancel: ");
                        }

                        // Cancel if price = -1
                        if (price == -1)
                        {
                            Console.WriteLine("Add Stock cancelled. Returning to menu.");
                            break;
                        }

                        // Ask for item quantity
                        Console.WriteLine("Enter item quantity (or type -1 to cancel): ");
                        int qty;

                        // Validate quantity input
                        while (!int.TryParse(Console.ReadLine(), out qty) || qty < -1)
                        {
                            Console.WriteLine("Invalid quantity. Enter a valid quantity, or -1 to cancel: ");
                        }

                        // Cancel if quantity = -1
                        if (qty == -1)
                        {
                            Console.WriteLine("Add Stock cancelled. Returning to menu.");
                            break;
                        }

                        // Store new item in the arrays
                        itemNames[itemCount] = name;
                        itemDescriptions[itemCount] = description;
                        itemPrices[itemCount] = price;
                        itemQuantities[itemCount] = qty;

                        // Increase the item count variable after adding item
                        itemCount++;

                        Console.WriteLine("Item added successfully.");
                        break;

                    case 2:
                        Console.WriteLine("********** VIEW STOCK **********");

                        // Check if inventory is empty
                        if (itemCount == 0)
                        {
                            Console.WriteLine("No items in inventory.");
                        }
                        else
                        {
                            // Looping through all the items in the inventory and displaying their details
                            for (int i = 0; i < itemCount; i++)
                            {
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine($"Item Number: {i + 1}");
                                Console.WriteLine($"Name: {itemNames[i]}");
                                Console.WriteLine($"Description: {itemDescriptions[i]}");
                                Console.WriteLine($"Price: {itemPrices[i]:C}");
                                Console.WriteLine($"Quantity: {itemQuantities[i]}");
                            }

                            Console.WriteLine("--------------------------------------");
                        }
                        break;

                    case 3:
                        Console.WriteLine("********** SELL ITEM **********");

                        // Prevent selling if the inventory is empty
                        if (itemCount == 0)
                        {
                            Console.WriteLine("No items available to sell.");
                            break;
                        }

                        Console.WriteLine("Available items:");

                        // Display all items with price and quantity
                        for (int i = 0; i < itemCount; i++)
                        {
                            Console.WriteLine($"{i + 1}. {itemNames[i]} | Quantity: {itemQuantities[i]} | Price: {itemPrices[i]:C}");
                        }

                        Console.WriteLine("Enter the item number to sell (or 0 to cancel): ");

                        int itemNumber;

                        // Validate item selection
                        while (!int.TryParse(Console.ReadLine(), out itemNumber) || itemNumber < 0 || itemNumber > itemCount)
                        {
                            Console.WriteLine("Invalid item number. Enter a valid item number, or 0 to cancel: ");
                        }

                        // Cancel selling process
                        if (itemNumber == 0)
                        {
                            Console.WriteLine("Sale cancelled. Returning to menu.");
                            break;
                        }

                        // Convert item number to array index
                        int index = itemNumber - 1;

                        // Prevent selling if item is out of stock
                        if (itemQuantities[index] == 0)
                        {
                            Console.WriteLine("This item is out of stock.");
                            break;
                        }

                        Console.WriteLine("Enter quantity to sell (or 0 to cancel): ");

                        int sellQty;

                        // Validate selling quantity
                        while (!int.TryParse(Console.ReadLine(), out sellQty) || sellQty < 0 || sellQty > itemQuantities[index])
                        {
                            Console.WriteLine("Invalid quantity. Enter a valid quantity, or 0 to cancel: ");
                        }

                        if (sellQty == 0)
                        {
                            Console.WriteLine("Sale cancelled. Returning to menu.");
                            break;
                        }

                        // Calculate sale amounts
                        double subtotal = sellQty * itemPrices[index];
                        double vatAmount = subtotal * VAT;
                        double total = subtotal + vatAmount;

                        // Reduce stock quantity
                        itemQuantities[index] -= sellQty;

                        // Display sale summary
                        Console.WriteLine("\n========== SALE RECEIPT ==========");
                        Console.WriteLine($"Item:           {itemNames[index]}");
                        Console.WriteLine($"Quantity:       {sellQty}");
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine($"Subtotal:       {subtotal:C}");
                        Console.WriteLine($"VAT (15%):      {vatAmount:C}");
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine($"TOTAL:          {total:C}");
                        Console.WriteLine("==================================");
                        Console.WriteLine("Sale completed successfully.\n");
                        break;

                    case 4:
                        // Exit the program if the user enters 4 as the option input
                        running = false;
                        Console.WriteLine("Thank you. Bye!");
                        break;
                }
            }
        }
    }
}
