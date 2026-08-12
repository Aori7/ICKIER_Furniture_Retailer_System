/* SDP Group 2
 * ICKIER Furniture System
 * Ada, Rui Min, Zi Ying, Christina
 */

//Christina
using ICKIER_Furniture_Retailer_System;

// Sample data setup
List<Order> orderHistory = new List<Order>();
Order lastOrder = null;
int orderCounter = 1001;

// Sample furniture items
List<FurnitureItem> catalogue = new List<FurnitureItem>
{
    new Table(1, "Oak Dining Table", 599.99m, "Oak", 180, 90),
    new Table(2, "Office Desk", 399.99m, "Walnut", 140, 70),
    new Chair(3, "Ergonomic Chair", 299.99m, "Mesh", 120),
    new Chair(4, "Dining Chair", 149.99m, "Oak", 90),
    new BookShelf(5, "Kallax Shelf", 199.99m, "Pine", 150, 80, 4),
    new BookShelf(6, "Billy Bookcase", 249.99m, "Oak", 200, 80, 5),
};

// Sample cart
List<(FurnitureItem item, int qty)> cart = new List<(FurnitureItem, int)>();

bool running = true;
while (running)
{
    Console.Clear();
    Console.WriteLine("========================================");
    Console.WriteLine("     WELCOME TO ICKIER FURNITURE STORE");
    Console.WriteLine("========================================");
    Console.WriteLine("What would you like to do today?");
    Console.WriteLine("1. Browse Furniture");
    Console.WriteLine("2. Search Furniture");
    Console.WriteLine("3. View Shopping Cart");
    Console.WriteLine("4. Checkout");
    Console.WriteLine("5. View Order History");
    Console.WriteLine("6. Repeat Last Order");
    Console.WriteLine("9. Manage Order");
    Console.WriteLine("0. Exit");
    Console.Write("\nEnter your choice: ");

    string choice = Console.ReadLine();
    Console.Clear();

    switch (choice)
    {
        case "1": BrowseFurniture(); break;
        case "2": SearchFurniture(); break;
        case "3": ViewCart(); break;
        case "4": Checkout(); break;
        case "5": ViewOrderHistory(); break;
        case "6": RepeatLastOrder(); break;
        case "9": ManageOrder(); break;
        case "0":
            Console.WriteLine("Hope you enjoy browsing ICKIER!");
            Console.WriteLine("See you again!");
            running = false;
            break;
        default:
            Console.WriteLine("Invalid choice. Press any key to try again.");
            Console.ReadKey();
            break;
    }
}

// ─── Option 1: Browse Furniture ───────────────────────────────────────
void BrowseFurniture()
{
    bool back = false;
    while (!back)
    {
        Console.WriteLine("=== Browse Furniture ===\n");
        Console.WriteLine("Select Furniture Collection:");
        Console.WriteLine("1. Living Room Collection");
        Console.WriteLine("2. Bedroom Collection");
        Console.WriteLine("3. Office Collection");
        Console.WriteLine("0. Back");
        Console.Write("\nEnter your choice: ");
        string col = Console.ReadLine();

        List<FurnitureItem> collection = new List<FurnitureItem>();
        string collectionName = "";

        switch (col)
        {
            case "1":
                collectionName = "Living Room Collection";
                collection = catalogue.Where(f => f is Table || f is Chair).ToList();
                break;
            case "2":
                collectionName = "Bedroom Collection";
                collection = catalogue.Where(f => f is BookShelf).ToList();
                break;
            case "3":
                collectionName = "Office Collection";
                collection = catalogue.Where(f => f is Table || f is Chair).ToList();
                break;
            case "0":
                back = true;
                continue;
            default:
                Console.WriteLine("Invalid choice.");
                Console.ReadKey();
                continue;
        }

        Console.Clear();
        Console.WriteLine($"=== {collectionName} ===\n");
        for (int i = 0; i < collection.Count; i++)
            Console.WriteLine($"{i + 1}. {collection[i].GetDescription()} - ${collection[i].GetPrice():N2}");

        Console.WriteLine("\nChoose Product Type:");
        Console.WriteLine("1. Table");
        Console.WriteLine("2. Chair");
        Console.WriteLine("3. BookShelf");
        Console.WriteLine("0. Back");
        Console.Write("\nEnter your choice: ");
        string typeChoice = Console.ReadLine();

        List<FurnitureItem> filtered = new List<FurnitureItem>();
        switch (typeChoice)
        {
            case "1": filtered = collection.Where(f => f is Table).ToList(); break;
            case "2": filtered = collection.Where(f => f is Chair).ToList(); break;
            case "3": filtered = collection.Where(f => f is BookShelf).ToList(); break;
            case "0": continue;
            default:
                Console.WriteLine("Invalid choice.");
                Console.ReadKey();
                continue;
        }

        Console.Clear();
        Console.WriteLine($"=== {collectionName} ===\n");
        for (int i = 0; i < filtered.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {filtered[i].Name}");
            Console.WriteLine($"   {filtered[i].GetDescription()}");
            Console.WriteLine($"   Price: ${filtered[i].GetPrice():N2}");
            Console.WriteLine();
        }

        Console.WriteLine("Would you like to add an item to cart?");
        Console.Write("Enter item number (or 0 to go back): ");
        string itemChoice = Console.ReadLine();

        if (itemChoice == "0") continue;

        if (int.TryParse(itemChoice, out int itemIdx) && itemIdx >= 1 && itemIdx <= filtered.Count)
        {
            FurnitureItem selected = filtered[itemIdx - 1];

            Console.WriteLine("\nAdd-ons:");
            Console.WriteLine("1. Add Warranty (+$49.99)");
            Console.WriteLine("2. Add Installation (+$79.99)");
            Console.WriteLine("3. Add Both");
            Console.WriteLine("0. No add-ons");
            Console.Write("Enter choice: ");
            string addon = Console.ReadLine();

            switch (addon)
            {
                case "1": selected = new WarrantyDecorator(selected, 49.99m); break;
                case "2": selected = new InstallationDecorator(selected, 79.99m); break;
                case "3":
                    selected = new WarrantyDecorator(selected, 49.99m);
                    selected = new InstallationDecorator(selected, 79.99m);
                    break;
            }

            Console.Write("Enter quantity: ");
            if (int.TryParse(Console.ReadLine(), out int qty) && qty > 0)
            {
                cart.Add((selected, qty));
                Console.WriteLine($"\n{selected.Name} x{qty} added to cart!");
            }
            else
            {
                Console.WriteLine("Invalid quantity.");
            }
        }
        Console.ReadKey();
    }
}

// ─── Option 2: Search Furniture ───────────────────────────────────────
void SearchFurniture()
{
    Console.WriteLine("=== Search Furniture ===\n");
    Console.Write("Which furniture are you looking for? ");
    string keyword = Console.ReadLine().ToLower();

    var results = catalogue.Where(f =>
        f.Name.ToLower().Contains(keyword) ||
        f.GetDescription().ToLower().Contains(keyword)).ToList();

    Console.Clear();
    if (results.Count == 0)
    {
        Console.WriteLine($"No results found for \"{keyword}\".");
    }
    else
    {
        Console.WriteLine($"=== Search Results for \"{keyword}\" ===\n");
        for (int i = 0; i < results.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {results[i].Name}");
            Console.WriteLine($"   {results[i].GetDescription()}");
            Console.WriteLine($"   Price: ${results[i].GetPrice():N2}");
            Console.WriteLine();
        }

        Console.Write("Enter item number to add to cart (or 0 to go back): ");
        string itemChoice = Console.ReadLine();

        if (int.TryParse(itemChoice, out int itemIdx) && itemIdx >= 1 && itemIdx <= results.Count)
        {
            cart.Add((results[itemIdx - 1], 1));
            Console.WriteLine($"\n{results[itemIdx - 1].Name} x1 added to cart!");
        }
    }
    Console.ReadKey();
}

// ─── Option 3: View Cart ──────────────────────────────────────────────
void ViewCart()
{
    bool back = false;
    while (!back)
    {
        Console.Clear();
        Console.WriteLine("=== Shopping Cart ===\n");

        if (cart.Count == 0)
        {
            Console.WriteLine("Your cart is empty.");
            Console.ReadKey();
            return;
        }

        decimal total = 0;
        for (int i = 0; i < cart.Count; i++)
        {
            decimal subtotal = cart[i].item.GetPrice() * cart[i].qty;
            total += subtotal;
            Console.WriteLine($"{i + 1}. {cart[i].item.Name} x{cart[i].qty}   ${subtotal:N2}");
        }
        Console.WriteLine($"\nTotal: ${total:N2}");
        Console.WriteLine("\n1. Remove Item");
        Console.WriteLine("2. Change Quantity");
        Console.WriteLine("3. Checkout");
        Console.WriteLine("0. Back");
        Console.Write("\nEnter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Enter item number to remove: ");
                if (int.TryParse(Console.ReadLine(), out int removeIdx) &&
                    removeIdx >= 1 && removeIdx <= cart.Count)
                {
                    Console.WriteLine($"{cart[removeIdx - 1].item.Name} removed from cart.");
                    cart.RemoveAt(removeIdx - 1);
                }
                Console.ReadKey();
                break;
            case "2":
                Console.Write("Enter item number to change quantity: ");
                if (int.TryParse(Console.ReadLine(), out int qtyIdx) &&
                    qtyIdx >= 1 && qtyIdx <= cart.Count)
                {
                    Console.Write("Enter new quantity: ");
                    if (int.TryParse(Console.ReadLine(), out int newQty) && newQty > 0)
                    {
                        var item = cart[qtyIdx - 1];
                        cart[qtyIdx - 1] = (item.item, newQty);
                        Console.WriteLine($"Quantity updated to {newQty}.");
                    }
                }
                Console.ReadKey();
                break;
            case "3":
                Checkout();
                back = true;
                break;
            case "0":
                back = true;
                break;
        }
    }
}

// ─── Option 4: Checkout ───────────────────────────────────────────────
void Checkout()
{
    Console.WriteLine("=== Checkout ===\n");

    if (cart.Count == 0)
    {
        Console.WriteLine("Your cart is empty! Please add items first.");
        Console.ReadKey();
        return;
    }

    // Delivery address
    Console.Write("Enter Delivery Address: ");
    string address = Console.ReadLine();

    // Delivery date
    Console.Write("Select Preferred Delivery Date (dd/MM/yyyy): ");
    string dateInput = Console.ReadLine();

    Console.WriteLine("\nConnecting to external delivery provider...");
    Console.WriteLine($"Delivery slot confirmed: {dateInput}, 2:00 PM - 5:00 PM");

    // Payment method
    Console.WriteLine("\nSelect Payment Method:");
    Console.WriteLine("1. Credit Card");
    Console.WriteLine("2. PayPal");
    Console.WriteLine("3. Cash on Delivery");
    Console.Write("\nEnter your choice: ");
    string payChoice = Console.ReadLine();

    string payMethod = payChoice switch
    {
        "1" => "Credit Card",
        "2" => "PayPal",
        "3" => "Cash on Delivery",
        _ => "Credit Card"
    };

    // Calculate total
    decimal total = cart.Sum(c => c.item.GetPrice() * c.qty);

    // Create order
    Order newOrder = new Order(orderCounter++);
    foreach (var (item, qty) in cart)
        for (int i = 0; i < qty; i++)
            newOrder.addItem(new OrderItem(item.FurnitureId, qty, item.GetPrice()));

    newOrder.PlaceOrder();
    newOrder.MakePayment();

    orderHistory.Insert(0, newOrder);
    lastOrder = newOrder;

    Console.WriteLine();
    Console.WriteLine("Checkout completed successfully.");
    Console.WriteLine($"Payment amount: ${total:N2}");
    Console.WriteLine($"Order ID: ORD{newOrder.OrderId} has been placed!");

    // Show different message based on payment method
    if (newOrder.Status == "Preparing")
    {
        Console.WriteLine();
        Console.WriteLine("Payment method: Cash on Delivery");
        Console.WriteLine("Your order is currently being prepared.");
        Console.WriteLine("You can still cancel your order at this stage.");
        Console.WriteLine("Payment will be collected upon delivery.");
    }
    else if (newOrder.Status == "Out for Delivery")
    {
        Console.WriteLine();
        Console.WriteLine("Your order is now out for delivery!");
        Console.WriteLine("Cancellation is no longer possible.");
    }

    cart.Clear();
    Console.ReadKey();
}

// ─── Option 5: View Order History ─────────────────────────────────────
void ViewOrderHistory()
{
    bool back = false;
    while (!back)
    {
        Console.Clear();
        Console.WriteLine("=== Order History ===\n");

        if (orderHistory.Count == 0)
        {
            Console.WriteLine("No order history found.");
            Console.ReadKey();
            return;
        }

        for (int i = 0; i < orderHistory.Count; i++)
        {
            Console.WriteLine($"Order ID: ORD{orderHistory[i].OrderId}");
            Console.WriteLine($"Status:   {orderHistory[i].Status}");
            Console.WriteLine($"Total:    ${orderHistory[i].TotalAmount:N2}");
            Console.WriteLine();
        }

        Console.WriteLine("How can we help you?");
        Console.WriteLine("1. View Order Details");
        Console.WriteLine("2. Cancel Order");
        Console.WriteLine("3. Repeat Order");
        Console.WriteLine("0. Back");
        Console.Write("\nEnter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
            case "2":
                ManageOrder();
                break;
            case "3":
                RepeatLastOrder();
                back = true;
                break;
            case "0":
                back = true;
                break;
        }
    }
}

// ─── Option 6: Repeat Last Order ──────────────────────────────────────
void RepeatLastOrder()
{
    Console.Clear();
    Console.WriteLine("=== Repeat Last Order ===\n");

    if (lastOrder == null)
    {
        Console.WriteLine("No previous order found.");
        Console.ReadKey();
        return;
    }

    Console.WriteLine($"Last Order: ORD{lastOrder.OrderId}");
    Console.WriteLine($"Total: ${lastOrder.TotalAmount:N2}");
    Console.WriteLine("\nRepeat this order?");
    Console.WriteLine("1. Confirm");
    Console.WriteLine("2. Cancel");
    Console.WriteLine("0. Back");
    Console.Write("\nEnter your choice: ");
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        Order repeatOrder = new Order(orderCounter++);
        repeatOrder.PlaceOrder();
        repeatOrder.MakePayment();
        orderHistory.Insert(0, repeatOrder);
        lastOrder = repeatOrder;
        Console.WriteLine($"\nOrder ORD{repeatOrder.OrderId} placed successfully!");
        Console.WriteLine($"Total: ${repeatOrder.TotalAmount:N2}");
    }
    Console.ReadKey();
}

// ─── Option 9: Manage Order ───────────────────────────────────────────
void ManageOrder()
{
    Console.Clear();
    Console.WriteLine("=== Manage Order ===\n");

    Console.Write("Enter Order ID (e.g. ORD1001): ");
    string input = Console.ReadLine().ToUpper().Replace("ORD", "");

    if (!int.TryParse(input, out int orderId))
    {
        Console.WriteLine("Invalid Order ID.");
        Console.ReadKey();
        return;
    }

    Order found = orderHistory.FirstOrDefault(o => o.OrderId == orderId);

    if (found == null)
    {
        Console.WriteLine("Order not found.");
        Console.ReadKey();
        return;
    }

    bool back = false;
    while (!back)
    {
        Console.Clear();
        Console.WriteLine($"Order ID: ORD{found.OrderId}");
        Console.WriteLine($"Status:   {found.Status}");
        Console.WriteLine($"Total:    ${found.TotalAmount:N2}\n");
        Console.WriteLine("1. Cancel Order");
        Console.WriteLine("2. Track Delivery");
        Console.WriteLine("0. Back");
        Console.Write("\nEnter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine($"\nCancel Order ORD{found.OrderId}?");
                Console.WriteLine("1. Confirm");
                Console.WriteLine("0. Back");
                Console.Write("Enter your choice: ");
                string confirm = Console.ReadLine();

                if (confirm == "1")
                {
                    found.CancelOrder();
                    if (found.Status == "Cancelled")
                    {
                        Console.WriteLine($"\nOrder cancelled successfully.");
                        Console.WriteLine($"Refund of ${found.TotalAmount:N2} has been processed.");
                    }
                    else
                    {
                        Console.WriteLine("\nCancellation unsuccessful.");
                        Console.WriteLine("The order has already been sent out for delivery,");
                        Console.WriteLine("so no cancellation or refund is allowed.");
                    }
                }
                Console.ReadKey();
                back = true;
                break;
            case "2":
                Console.WriteLine($"\nTracking Order ORD{found.OrderId}...");
                Console.WriteLine($"Current Status: {found.Status}");
                Console.ReadKey();
                break;
            case "0":
                back = true;
                break;
        }
    }
}