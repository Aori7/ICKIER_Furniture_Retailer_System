/* SDP Group 2
 * ICKIER Furniture System
 * Ada, Rui Min, Zi Ying, Christina
 */

using ICKIER_Furniture_Retailer_System;

// Sample data setup
List<Order> orderHistory = new List<Order>();
Order? lastOrder = null;
List<(FurnitureItem item, int qty)> lastOrderItems =
    new List<(FurnitureItem item, int qty)>();
int orderCounter = 1001;

// Sample furniture items
List<FurnitureItem> catalogue = new List<FurnitureItem>
{
    new Table(1, "Basic Dining Table", 599.99m, "Basic Dining Table", "Basic", 180, 90),
    new Table(2, "Office Desk", 399.99m, "Office Desk", "Walnut", 140, 70),
    new Chair(3, "Ergonomic Chair", 299.99m, "Ergonomic Chair", "Mesh", 120),
    new Chair(4, "Dining Chair", 149.99m, "Dining Chair", "Oak", 90),
    new BookShelf(5, "Kallax Shelf", 199.99m, "Kallax Shelf", "Pine", 150, 80, 4),
    new BookShelf(6, "Billy Bookcase", 249.99m, "Billy Bookcase", "Oak", 200, 80, 5),
};

// Sample cart
List<(FurnitureItem item, int qty)> cart = new List<(FurnitureItem, int)>();
// Observer Pattern - Customer and Brands
Customer customer = new Customer(
    1,
    "Zi Ying",
    "ziying@email.com"
);

List<Brand> brands = new List<Brand>
{
    new Brand(1, "ICKIER Home"),
    new Brand(2, "Nordic Living"),
    new Brand(3, "Urban Oak")
};

int nextPromotionId = 1;

bool running = true;
while (running)
{
  
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
    Console.WriteLine("7. Brand Subscriptions & Promotions");
    Console.WriteLine("9. Manage Order");
    Console.WriteLine("0. Exit");
    Console.Write("\nEnter your choice: ");

    string choice = Console.ReadLine() ?? "";
  

    switch (choice)
    {
        case "1": BrowseFurniture(); break;
        case "2": SearchFurniture(); break;
        case "3": ViewCart(); break;
        case "4": Checkout(); break;
        case "5": ViewOrderHistory(); break;
        case "6": RepeatLastOrder(); break;
        case "7": ManageBrandSubscriptions(); break;
        case "9": ManageOrder(); break;
        case "0":
            Console.WriteLine("Hope you enjoy browsing ICKIER!");
            Console.WriteLine("See you again!");
            running = false;
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
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
        string col = Console.ReadLine() ?? "";

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
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
        }

        Console.WriteLine($"=== {collectionName} ===\n");
        for (int i = 0; i < collection.Count; i++)
            Console.WriteLine($"{i + 1}. {collection[i].GetDescription()} - ${collection[i].GetPrice():N2}");

        Console.WriteLine("\nChoose Product Type:");
        Console.WriteLine("1. Table");
        Console.WriteLine("2. Chair");
        Console.WriteLine("3. BookShelf");
        Console.WriteLine("0. Back");
        Console.Write("\nEnter your choice: "); 
        string typeChoice = Console.ReadLine() ?? "";

        List<FurnitureItem> filtered = new List<FurnitureItem>();
        switch (typeChoice)
        {
            case "1": filtered = collection.Where(f => f is Table).ToList(); break;
            case "2": filtered = collection.Where(f => f is Chair).ToList(); break;
            case "3": filtered = collection.Where(f => f is BookShelf).ToList(); break;
            case "0": continue;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
        }

       
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
        string itemChoice = Console.ReadLine() ?? "";

        if (itemChoice == "0") continue;

        if (int.TryParse(itemChoice, out int itemIdx) && itemIdx >= 1 && itemIdx <= filtered.Count)
        {
            FurnitureItem selected = filtered[itemIdx - 1];

            while (true)
            {
                Console.WriteLine("\nAdd-ons:");
                Console.WriteLine("1. Add Warranty (+$49.99)");
                Console.WriteLine("2. Add Installation (+$79.99)");
                Console.WriteLine("3. Add Both");
                Console.WriteLine("0. No add-ons");
                Console.Write("Enter choice: ");

                string addon = Console.ReadLine() ?? "";

                switch (addon)
                {
                    case "1":
                        selected = new WarrantyDecorator(selected, 49.99m);
                        break;

                    case "2":
                        selected = new InstallationDecorator(selected, 79.99m);
                        break;

                    case "3":
                        selected = new WarrantyDecorator(selected, 49.99m);
                        selected = new InstallationDecorator(selected, 79.99m);
                        break;

                    case "0":
                        break;

                    default:
                        Console.WriteLine("Invalid add-on choice. Please enter 0, 1, 2, or 3.");
                        continue;
                }

                break;
            }

            int qty;

            while (true)
            {
                Console.Write("Enter quantity: ");

                if (int.TryParse(Console.ReadLine(), out qty) && qty > 0)
                {
                    break;
                }

                Console.WriteLine(
                    "Invalid quantity. Please enter a whole number greater than 0."
                );
            }

            cart.Add((selected, qty));
            Console.WriteLine(
                $"\n{selected.Name} x{qty} added to cart!"
            );
        }
        else
        {
            Console.WriteLine(
                $"Invalid item number. Please enter a number from 1 to {filtered.Count}, or 0 to go back."
            );
        }

    }
}

// ─── Option 2: Search Furniture ───────────────────────────────────────
void SearchFurniture()
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("=== Search Furniture ===");
        Console.WriteLine();
        Console.Write("Which furniture are you looking for? (Enter 0 to go back): ");
        string keyword = (Console.ReadLine() ?? "").ToLower();
        if (keyword == "0")
        {
            return;
        }

        var results = catalogue.Where(f =>
        f.Name.ToLower().Contains(keyword) ||
        f.GetDescription().ToLower().Contains(keyword)).ToList();


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

            Console.Write("Enter item number to add to cart (or 0 to search again): ");
            string itemChoice = Console.ReadLine() ?? "";

            if (itemChoice == "0")
            {
                continue;
            }

            if (int.TryParse(itemChoice, out int itemIdx) &&
                itemIdx >= 1 &&
                itemIdx <= results.Count)
            {
                cart.Add((results[itemIdx - 1], 1));

                Console.WriteLine(
                    $"\n{results[itemIdx - 1].Name} x1 added to cart!"
                );
            }
            else
            {
                Console.WriteLine(
                    $"Invalid item number. Please enter a number from 1 to {results.Count}, or 0 to search again."
                );
            }
        }
    }
   
}

// ─── Option 3: View Cart ──────────────────────────────────────────────
void ViewCart()
{
    bool back = false;
    while (!back)
    {
    
        Console.WriteLine("=== Shopping Cart ===\n");

        if (cart.Count == 0)
        {
            Console.WriteLine("Your cart is empty! Please add items first.");
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
        string choice = Console.ReadLine() ?? "";

        switch (choice)
        {
            case "1":
                Console.Write("Enter item number to remove: ");

                if (int.TryParse(Console.ReadLine(), out int removeIdx) &&
                    removeIdx >= 1 && removeIdx <= cart.Count)
                {
                    Console.WriteLine(
                        $"{cart[removeIdx - 1].item.Name} removed from cart."
                    );

                    cart.RemoveAt(removeIdx - 1);
                }
                else
                {
                    Console.WriteLine(
                        $"Invalid item number. Please enter a number from 1 to {cart.Count}."
                    );
                }

                break;

            case "2":
                Console.Write("Enter item number to change quantity: ");

                if (int.TryParse(Console.ReadLine(), out int qtyIdx) &&
                    qtyIdx >= 1 &&
                    qtyIdx <= cart.Count)
                {
                    Console.Write("Enter new quantity: ");

                    if (int.TryParse(Console.ReadLine(), out int newQty) &&
                        newQty > 0)
                    {
                        var item = cart[qtyIdx - 1];

                        cart[qtyIdx - 1] =
                            (item.item, newQty);

                        Console.WriteLine(
                            $"Quantity updated to {newQty}."
                        );
                    }
                    else
                    {
                        Console.WriteLine(
                            "Invalid quantity. Please enter a whole number greater than 0."
                        );
                    }
                }
                else
                {
                    Console.WriteLine(
                        $"Invalid item number. Please enter a number from 1 to {cart.Count}."
                    );
                }

                break;

            case "3":
                Checkout();
                back = true;
                break;

            case "0":
                back = true;
                break;

            default:
                Console.WriteLine(
                    "Invalid option. Please enter 0, 1, 2, or 3."
                );
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
        return;
    }

    // Delivery address
    string address;

    while (true)
    {
        Console.WriteLine("Enter Delivery Address");
        Console.WriteLine("Format example: Blk 123 Clementi Ave 3, #05-10, Singapore 120123");
        Console.Write("Address: ");

        address = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(address))
        {
            Console.WriteLine("Delivery address cannot be empty.");
            Console.WriteLine();
            continue;
        }

        if (address.Length < 5)
        {
            Console.WriteLine("Please enter a valid delivery address.");
            Console.WriteLine();
            continue;
        }

        break;
    }

    // Delivery date
    DateTime deliveryDate;

    while (true)
    {
        Console.Write("Select Preferred Delivery Date (dd/MM/yyyy): ");
        string dateInput = Console.ReadLine() ?? "";

        bool validDate = DateTime.TryParseExact(
            dateInput,
            "dd/MM/yyyy",
            null,
            System.Globalization.DateTimeStyles.None,
            out deliveryDate
        );

        if (!validDate)
        {
            Console.WriteLine(
                "Invalid date format. Please enter the date as dd/MM/yyyy."
            );
            continue;
        }

        if (deliveryDate.Date <= DateTime.Today)
        {
            Console.WriteLine(
                "Delivery date must be a future date."
            );
            continue;
        }

        break;
    }

    Console.WriteLine("\nConnecting to external delivery provider...");
    Console.WriteLine(
        $"Delivery slot confirmed: {deliveryDate:dd/MM/yyyy}, 2:00 PM - 5:00 PM"
    );

    // Calculate total
    decimal total = cart.Sum(c => c.item.GetPrice() * c.qty);

    // Strategy Pattern - Payment
    Payment payment = new Payment(orderCounter, total);
    
    Console.WriteLine();

    bool paymentSuccessful = false;

    while (!paymentSuccessful)
    {
        Console.WriteLine("\nSelect Payment Method:");
        Console.WriteLine("1. Credit Card");
        Console.WriteLine("2. PayPal");
        Console.WriteLine("3. Cash on Delivery");
        Console.WriteLine("0. Cancel Checkout");
        Console.Write("\nEnter your choice: ");

        string payChoice = Console.ReadLine() ?? "";

        switch (payChoice)
        {
            case "1":
                Console.Write("Enter card number: ");
                string cardNumber = Console.ReadLine() ?? "";

                payment.SetPaymentStrategy(
                    new CreditCardPayment(cardNumber)
                );
                break;

            case "2":
                Console.Write("Enter PayPal email: ");
                string email = Console.ReadLine() ?? "";

                payment.SetPaymentStrategy(
                    new PayPalPayment(email)
                );
                break;

            case "3":
                payment.SetPaymentStrategy(
                    new CashOnDeliveryPayment()
                );
                break;

            case "0":
                Console.WriteLine("Checkout cancelled. Your cart has been kept.");
                return;

            default:
                Console.WriteLine(
                    "Invalid payment method. Please try again."
                );
                continue;
        }

        Console.WriteLine();

        paymentSuccessful = payment.ProcessPayment();

        if (!paymentSuccessful)
        {
            Console.WriteLine();
            Console.WriteLine(
                "Please select a payment method and try again."
            );
        }
    }

    // Create order
    Order newOrder = new Order(orderCounter++);
    newOrder.SetPayment(payment);
    foreach (var (item, qty) in cart)
    {
        newOrder.addItem(
            new OrderItem(
                item.FurnitureId,
                qty,
                item.GetPrice()
            )
        );
    }

    newOrder.PlaceOrder();
    newOrder.MakePayment();

    orderHistory.Insert(0, newOrder);
    lastOrder = newOrder;

    Console.WriteLine();
    Console.WriteLine("Checkout completed successfully.");
    Console.WriteLine($"Payment amount: ${total:N2}");
    Console.WriteLine($"Order ID: ORD{newOrder.OrderId} has been placed!");

    lastOrderItems = cart
    .Select(c => (c.item, c.qty))
    .ToList();

    cart.Clear();
}

// ─── Option 5: View Order History ─────────────────────────────────────
void ViewOrderHistory()
{
    bool back = false;
    while (!back)
    {
       
        Console.WriteLine("=== Order History ===\n");

        if (orderHistory.Count == 0)
        {
            Console.WriteLine("No order history found.");
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
        string choice = Console.ReadLine() ?? "";

        switch (choice)
        {
            case "1":
                ViewOrderDetails();
                break;

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

            default:
                Console.WriteLine(
                    "Invalid option. Please enter 0, 1, 2, or 3."
                );
                break;
        }
    }
}

void ViewOrderDetails()
{
    Console.Write("Enter Order ID (e.g. ORD1001): ");

    string input = (Console.ReadLine() ?? "")
        .ToUpper()
        .Replace("ORD", "");

    if (!int.TryParse(input, out int orderId))
    {
        Console.WriteLine(
            "Invalid Order ID. Please use a format such as ORD1001."
        );
        return;
    }

    Order? found = orderHistory.FirstOrDefault(
        o => o.OrderId == orderId
    );

    if (found == null)
    {
        Console.WriteLine("Order not found.");
        return;
    }

    Console.WriteLine();
    Console.WriteLine("=== Order Details ===");
    Console.WriteLine($"Order ID: ORD{found.OrderId}");
    Console.WriteLine($"Status:   {found.Status}");
    Console.WriteLine($"Total:    ${found.TotalAmount:N2}");

    if (found.Payment != null)
    {
        if (found.Payment.IsCashOnDelivery)
        {
            Console.WriteLine(
                found.Payment.IsPaid
                    ? "Payment: Cash on Delivery - Paid"
                    : "Payment: Cash on Delivery - Pending Collection"
            );
        }
        else
        {
            Console.WriteLine(
                found.Payment.IsPaid
                    ? "Payment: Paid"
                    : "Payment: Not Paid"
            );
        }

        if (found.Payment.IsRefunded)
        {
            Console.WriteLine("Refund Status: Refunded");
        }
    }
}
// ─── Option 6: Repeat Last Order ──────────────────────────────────────
void RepeatLastOrder()
{
    
    Console.WriteLine("=== Repeat Last Order ===\n");

    if (lastOrder == null)
    {
        Console.WriteLine("No previous order found.");
       
        return;
    }

    Console.WriteLine($"Last Order: ORD{lastOrder.OrderId}");
    Console.WriteLine($"Total: ${lastOrder.TotalAmount:N2}");
    Console.WriteLine("\nRepeat this order?");
    Console.WriteLine("1. Confirm");
    Console.WriteLine("2. Cancel");
    Console.WriteLine("0. Back");
    Console.Write("\nEnter your choice: ");
    string choice = Console.ReadLine() ?? "";

    if (choice == "1")
    {
        if (lastOrderItems.Count == 0)
        {
            Console.WriteLine(
                "The previous order items could not be found."
            );
            return;
        }

        cart.Clear();

        foreach (var (item, qty) in lastOrderItems)
        {
            cart.Add((item, qty));
        }

        Console.WriteLine(
            "\nPrevious order items have been added back to your cart."
        );

        Console.WriteLine(
            "Please confirm delivery and payment details again."
        );

        Checkout();
    }
}

// ─── Option 9: Manage Order ───────────────────────────────────────────
void ManageOrder()
{
   
    Console.WriteLine("=== Manage Order ===\n");

    Console.Write("Enter Order ID (e.g. ORD1001): ");
    string input = (Console.ReadLine() ?? "")
    .ToUpper()
    .Replace("ORD", "");

    if (!int.TryParse(input, out int orderId))
    {
        Console.WriteLine(
            "Invalid Order ID. Please use a format such as ORD1001."
        );
        return;
    }

    Order? found = orderHistory.FirstOrDefault(
    o => o.OrderId == orderId
    );

    if (found == null)
    {
        Console.WriteLine("Order not found.");
        return;
    }

    bool back = false;
    while (!back)
    {
        
        Console.WriteLine($"Order ID: ORD{found.OrderId}");
        Console.WriteLine($"Status:   {found.Status}");
        Console.WriteLine($"Total:    ${found.TotalAmount:N2}\n");
        Console.WriteLine("1. Cancel Order");
        Console.WriteLine("2. Track Delivery");
        Console.WriteLine("0. Back");
        Console.Write("\nEnter your choice: ");
        string choice = Console.ReadLine() ?? "";

        switch (choice)
        {
            case "1":
                Console.WriteLine($"\nCancel Order ORD{found.OrderId}?");
                Console.WriteLine("1. Confirm");
                Console.WriteLine("0. Back");
                Console.Write("Enter your choice: ");
                string confirm = Console.ReadLine() ?? "";

                if (confirm == "1")
                {
                    found.CancelOrder();
                    if (found.Status == "Cancelled")
                    {
                        Console.WriteLine("\nOrder cancelled successfully.");

                        if (found.Payment != null)
                        {
                            if (found.Payment.IsPaid)
                            {
                                found.Payment.RefundPayment();
                            }
                            else if (found.Payment.IsCashOnDelivery)
                            {
                                Console.WriteLine(
                                    "No refund is required because Cash on Delivery has not been collected."
                                );
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nCancellation unsuccessful.");
                        Console.WriteLine("The order has already been sent out for delivery,");
                        Console.WriteLine("so no cancellation or refund is allowed.");
                    }
                }
                
                back = true;
                break;
            case "2":
                Console.WriteLine($"\nTracking Order ORD{found.OrderId}...");
                Console.WriteLine($"Current Status: {found.Status}");
                break;
            case "0":
                back = true;
                break;
            default:
                Console.WriteLine(
                    "Invalid option. Please enter 0, 1, or 2."
                );
                break;
        }
    }
}
void ManageBrandSubscriptions()
{
    string observerChoice;

    do
    {
     
        Console.WriteLine("================================");
        Console.WriteLine("      BRAND SUBSCRIPTIONS");
        Console.WriteLine("================================");
        Console.WriteLine("1. View Available Brands");
        Console.WriteLine("2. Subscribe to Brand");
        Console.WriteLine("3. Unsubscribe from Brand");
        Console.WriteLine("4. View My Subscriptions");
        Console.WriteLine("5. View Notifications");
        Console.WriteLine("6. Publish Promotion");
        Console.WriteLine("0. Back");
        Console.Write("Enter option: ");

        observerChoice = Console.ReadLine() ?? "";
        Console.WriteLine();

        switch (observerChoice)
        {
            case "1":
                Console.WriteLine("Available Brands:");
                Console.WriteLine();

                foreach (Brand brand in brands)
                {
                    Console.WriteLine(
                        $"{brand.BrandId}. {brand.BrandName}"
                    );
                }
                break;

            case "2":
                Console.WriteLine("=== Subscribe to Brand ===");
                Console.WriteLine();

                foreach (Brand brand in brands)
                {
                    Console.WriteLine(
                        $"{brand.BrandId}. {brand.BrandName}"
                    );
                }

                Console.WriteLine();
                Console.Write("Enter Brand ID: ");

                int subscribeBrandId;

                while (!int.TryParse(
                           Console.ReadLine(),
                           out subscribeBrandId) ||
                       subscribeBrandId < 1 ||
                       subscribeBrandId > brands.Count)
                {
                    Console.Write(
                        "Invalid Brand ID. Please try again: "
                    );
                }

                Brand brandToSubscribe =
                    brands[subscribeBrandId - 1];

                customer.SubscribeToBrand(
                    brandToSubscribe
                );

                break;

            case "3":
                Console.WriteLine("=== Unsubscribe from Brand ===");
                Console.WriteLine();

                foreach (Brand brand in brands)
                {
                    Console.WriteLine(
                        $"{brand.BrandId}. {brand.BrandName}"
                    );
                }

                Console.WriteLine();
                Console.Write("Enter Brand ID: ");

                int unsubscribeBrandId;

                while (!int.TryParse(
                           Console.ReadLine(),
                           out unsubscribeBrandId) ||
                       unsubscribeBrandId < 1 ||
                       unsubscribeBrandId > brands.Count)
                {
                    Console.Write(
                        "Invalid Brand ID. Please try again: "
                    );
                }

                Brand brandToUnsubscribe =
                    brands[unsubscribeBrandId - 1];

                customer.UnsubscribeFromBrand(
                    brandToUnsubscribe
                );

                break;

            case "4":
                customer.ViewSubscriptions();
                break;

            case "5":
                customer.ViewNotifications();
                break;

            case "6":
                Console.WriteLine("=== Publish Promotion ===");
                Console.WriteLine();

                foreach (Brand brand in brands)
                {
                    Console.WriteLine(
                        $"{brand.BrandId}. {brand.BrandName}"
                    );
                }

                Console.WriteLine();
                Console.Write("Enter Brand ID: ");

                int promotionBrandId;

                while (!int.TryParse(
                           Console.ReadLine(),
                           out promotionBrandId) ||
                       promotionBrandId < 1 ||
                       promotionBrandId > brands.Count)
                {
                    Console.Write(
                        "Invalid Brand ID. Please try again: "
                    );
                }

                Brand promotionBrand =
                    brands[promotionBrandId - 1];

                string promotionTitle;

                while (true)
                {
                    Console.Write("Enter Promotion Title: ");
                    promotionTitle = (Console.ReadLine() ?? "").Trim();

                    if (!string.IsNullOrWhiteSpace(promotionTitle))
                    {
                        break;
                    }

                    Console.WriteLine("Promotion title cannot be empty.");
                }

                string promotionDescription;

                while (true)
                {
                    Console.Write("Enter Promotion Description: ");
                    promotionDescription = (Console.ReadLine() ?? "").Trim();

                    if (!string.IsNullOrWhiteSpace(promotionDescription))
                    {
                        break;
                    }

                    Console.WriteLine("Promotion description cannot be empty.");
                }

                Console.Write("Enter Discount Percentage: ");

                decimal discountPercentage;

                while (!decimal.TryParse(
                           Console.ReadLine(),
                           out discountPercentage) ||
                       discountPercentage <= 0 ||
                       discountPercentage > 100)
                {
                    Console.Write(
                        "Invalid discount. Enter a value between 1 and 100: "
                    );
                }

                Promotion newPromotion = new Promotion(
                    nextPromotionId,
                    promotionTitle,
                    promotionDescription,
                    discountPercentage,
                    DateTime.Now,
                    DateTime.Now.AddDays(7)
                );

                promotionBrand.AddPromotion(newPromotion);
                nextPromotionId++;

                break;

            case "0":
                break;

            default:
                Console.WriteLine(
                    "Invalid option. Please try again."
                );
                break;
        }

    } while (observerChoice != "0");
}