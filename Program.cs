/* SDP Group 2
* ICKIER Furniture System
* Ada, Rui Min, Zi Ying, Christina
*/

using ICKIER_Furniture_Retailer_System;
using System.Collections;

List<FurnitureItem> catalogue = new List<FurnitureItem>();

// furniture collections; composite pattern
FurnitureCollection bedroom = new FurnitureCollection(1, "Bedroom Collection", "Bedroom items");
FurnitureCollection livingRoom = new FurnitureCollection(2, "Living Room Collection", "Living Room items");
FurnitureCollection office = new FurnitureCollection(3, "Office Collection", "Office items");
FurnitureCollection kitchen = new FurnitureCollection(4, "Kitchen Collection", "Kitchen items");
FurnitureCollection bathroom = new FurnitureCollection(5, "Bathroom Collection", "Bathroom items");

FurnitureCollection subBedroom = new FurnitureCollection(6,"SubBedroom Collection", "Bedroom Sub-Collection");
FurnitureCollection subLivingRoom = new FurnitureCollection(7, "SubLivingRoom Collection", "Living Room Sub-Collection");
FurnitureCollection subOffice = new FurnitureCollection(8, "SubOffice Collection", "Office Sub-Collection");
FurnitureCollection subKitchen = new FurnitureCollection(9, "SubKitchen Collection", "Kitchen Sub-Collection");

// create material factories; asbtract factory pattern
FurnitureFactory oakFactory = new OakFurnitureFactory();
FurnitureFactory pineFactory = new PineFurnitureFactory();
FurnitureFactory steelFactory = new SteelFurnitureFactory();

// making items
FurnitureItem table1 = new FurnitureItem(1, "Table", 2000, "sturdy =material= table");
FurnitureItem cabinet1 = new FurnitureItem(2, "Cabinet", 3000, "sturdy =material= Cabinet");
FurnitureItem chair1 = new FurnitureItem(3, "Chair", 500, "sturdy =material= Chair");
FurnitureItem bookshelf1 = new FurnitureItem(4, "Bookshelf", 2500, "sturdy =material= Bookshelf");
FurnitureItem showerHead1 = new FurnitureItem(5, "Shower Head", 700, "sturdy Shower Head");
FurnitureItem sink1 = new FurnitureItem(6, "Sink", 300, "sturdy =material= Sink");
FurnitureItem stove1 = new FurnitureItem(7, "Stove", 600, "sturdy Stove");
FurnitureItem door1 = new FurnitureItem(8, "Door", 200, "sturdy =material= Door");
FurnitureItem bed1 = new FurnitureItem(9, "Bed", 15000, "sturdy =material= Bed");
FurnitureItem sofa1 = new FurnitureItem(10, "Sofa", 15000, "sturdy =material= Sofa");

// adding items into collection
bedroom.Add(bed1);
bedroom.Add(bookshelf1);
subBedroom.Add(door1);
bedroom.Add(subBedroom);

livingRoom.Add(table1);
livingRoom.Add(sofa1);
subLivingRoom.Add(chair1);
livingRoom.Add(subLivingRoom);

office.Add(table1);
office.Add(chair1);
office.Add(bookshelf1);
subOffice.Add(door1);
office.Add(subOffice);

kitchen.Add(sink1);
subKitchen.Add(stove1);

bathroom.Add(showerHead1);
bathroom.Add(sink1);
bathroom.Add(door1);


// list of collections
List<FurnitureCollection> Catalogue = new List<FurnitureCollection>
{
bedroom, livingRoom, office, kitchen, bathroom
};

// order facade
OrderFacade orderFacade = new OrderFacade();

// Sample data setup
List<Order> orderHistory = new List<Order>();
Order? lastOrder = null;
List<(FurnitureItem item, int qty)> lastOrderItems =
new List<(FurnitureItem item, int qty)>();
int orderCounter = 1001;

// Sample cart
List<(FurnitureItem item, int qty)> cart = new List<(FurnitureItem, int)>();

//command pattern
RepeatOrderService repeatOrderService = new RepeatOrderService(cart, lastOrderItems);
OrderCommandInvoker orderCommandInvoker = new OrderCommandInvoker();
RepeatLastOrderCommand repeatCommand = new RepeatLastOrderCommand(repeatOrderService);
orderCommandInvoker.SetCommand(repeatCommand);

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
Console.WriteLine("7. Manage Brand Subscriptions");
Console.WriteLine("8. View Notifications");
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
    case "7":
        ManageBrandSubscriptions();
        break;

    case "8":
        customer.ViewNotifications();
        break;

    case "9":
        ManageOrder();
        break;
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
// browse collection & select
// browse items under collection & select
// display detials of item & select to add to cart
// display and select add ons
void BrowseFurniture()
{
    bool back = false;

    while (!back)
    {
        Console.WriteLine();
        Console.WriteLine("=== Browse Furniture ===");
        Console.WriteLine("Select Furniture Collection:");

        for (int i = 0; i < Catalogue.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Catalogue[i].Name}");
        }

        Console.WriteLine("0. Back");
        Console.Write("Enter your choice: ");

        string input = Console.ReadLine() ?? "";

        if (input == "0")
        {
            return;
        }
        else if (!int.TryParse(input, out int choice))
        {
            Console.WriteLine("Please enter a valid number.");
            continue;
        }
        else if (choice < 1 || choice > Catalogue.Count)
        {
            Console.WriteLine("Invalid collection.");
            continue;
        }

        FurnitureCollection collection = Catalogue[choice - 1];
        bool backToCollections = false;

        while (!backToCollections)
        {
            Console.WriteLine();
            Console.WriteLine($"=== {collection.Name} ===");

            for (int i = 0; i < collection.Children.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {collection.Children[i].Name}");
            }

            Console.WriteLine("0. Back");
            Console.Write("Enter your choice: ");

            string itemIndex = Console.ReadLine() ?? "";

            if (itemIndex == "0")
            {
                backToCollections = true;
                continue;
            }
            else if (!int.TryParse(itemIndex, out int choice2))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }
            else if (choice2 < 1 || choice2 > collection.Children.Count)
            {
                Console.WriteLine("Invalid choice.");
                continue;
            }

            CatalogComponent selectedChild = collection.Children[choice2 - 1];
            FurnitureItem item;

            // composite Pattern - subcollection
            if (selectedChild is FurnitureCollection)
            {
                FurnitureCollection subCollection = (FurnitureCollection)selectedChild;

                Console.WriteLine();
                Console.WriteLine($"=== {subCollection.Name} ===");

                for (int i = 0; i < subCollection.Children.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {subCollection.Children[i].Name}");
                }

                Console.WriteLine("0. Back");
                Console.Write("Enter your choice: ");

                string subInput = Console.ReadLine() ?? "";

                if (subInput == "0")
                {
                    continue;
                }
                else if (!int.TryParse(subInput, out int subChoice))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }
                else if (subChoice < 1 || subChoice > subCollection.Children.Count)
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                CatalogComponent subSelected = subCollection.Children[subChoice - 1];

                if (subSelected is FurnitureItem)
                {
                    item = (FurnitureItem)subSelected;
                }
                else
                {
                    Console.WriteLine("Please select a furniture item.");
                    continue;
                }
            }
            // composite Pattern - item
            else if (selectedChild is FurnitureItem)
            {
                item = (FurnitureItem)selectedChild;
            }
            else
            {
                Console.WriteLine("Invalid selection.");
                continue;
            }
            FurnitureItem selected = item;

            // Abstract Factory Pattern - customisable furniture
            if (item.Name == "Table" || item.Name == "Chair" || item.Name == "Bookshelf")
            {
                Console.WriteLine();
                Console.WriteLine("=== Customise Furniture ===");
                Console.WriteLine("Choose Furniture Material:");
                Console.WriteLine("1. Oak");
                Console.WriteLine("2. Pine");
                Console.WriteLine("3. Steel");
                Console.Write("Enter choice: ");

                string materialChoice = Console.ReadLine() ?? "";
                FurnitureFactory fact;

                if (materialChoice == "1")
                {
                    fact = oakFactory;
                }
                else if (materialChoice == "2")
                {
                    fact = pineFactory;
                }
                else if (materialChoice == "3")
                {
                    fact = steelFactory;
                }
                else
                {
                    Console.WriteLine("Invalid material.");
                    continue;
                }

                if (item.Name == "Table")
                {
                    Console.Write("Enter length (cm): ");
                    double length = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter width (cm): ");
                    double width = Convert.ToDouble(Console.ReadLine());

                    selected = fact.CreateTable(length, width);
                }
                else if (item.Name == "Chair")
                {
                    Console.Write("Enter height (cm): ");
                    double height = Convert.ToDouble(Console.ReadLine());

                    selected = fact.CreateChair(height);
                }
                else if (item.Name == "Bookshelf")
                {
                    Console.Write("Enter height (cm): ");
                    double height = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter width (cm): ");
                    double width = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter number of shelves: ");
                    int shelfCount = Convert.ToInt32(Console.ReadLine());

                    selected = fact.CreateBookShelf(height, width, shelfCount);
                }
            }

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"=== {selected.Name} ===");
                Console.WriteLine($"Price: ${selected.GetPrice():F2}");
                Console.WriteLine($"Description: {selected.Description}");
                Console.Write("Add item to cart? Y/N: ");
                string decision = (Console.ReadLine() ?? "").ToUpper();

                if (decision == "N")
                {
                    break;
                }
                else if (decision == "Y")
                {
                    // Decorator Pattern
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("=== Add-ons ===");
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
                        Console.WriteLine("Invalid quantity. Please enter a whole number greater than 0.");
                    }

                    cart.Add((selected, qty));
                    Console.WriteLine($"{selected.Name} x{qty} added to cart!");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                }
            }
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

        List<FurnitureItem> allItems = new List<FurnitureItem>();
        List<FurnitureItem> GetAllFurnitureItems(FurnitureCollection collection)
        {
            List<FurnitureItem> items = new List<FurnitureItem>();

            foreach (CatalogComponent child in collection.Children)
            {
                if (child is FurnitureItem)
                {
                    items.Add((FurnitureItem)child);
                }
                else if (child is FurnitureCollection)
                {
                    FurnitureCollection subCollection = (FurnitureCollection)child;
                    items.AddRange(GetAllFurnitureItems(subCollection));
                }
            }

            return items;
        }

        foreach (FurnitureCollection collection in Catalogue)
        {
            allItems.AddRange(GetAllFurnitureItems(collection));
        }

        var results = allItems.Where(f =>
            f.Name.ToLower().Contains(keyword) ||
            f.GetDescription().ToLower().Contains(keyword)
        ).ToList();

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

                return;
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
            Console.WriteLine("Invalid date format. Please enter the date as dd/MM/yyyy.");
            continue;
        }

        if (deliveryDate.Date <= DateTime.Today)
        {
            Console.WriteLine("Delivery date must be a future date.");
            continue;
        }

        break;
    }

    Console.WriteLine($"Delivery slot confirmed: {deliveryDate:dd/MM/yyyy}, 2:00 PM - 5:00 PM");

    // Factory Pattern - Delivery
    Console.WriteLine("\nSelect Delivery Type:");
    Console.WriteLine("1. Standard Delivery");
    Console.WriteLine("2. Express Delivery");
    Console.WriteLine("3. Third-Party Delivery");
    Console.Write("Enter choice: ");

    string deliveryChoice = Console.ReadLine() ?? "";
    DeliveryCreator deliveryCreator;

    if (deliveryChoice == "1")
    {
        deliveryCreator = new StandardDeliveryCreator();
    }
    else if (deliveryChoice == "2")
    {
        deliveryCreator = new ExpressDeliveryCreator();
    }
    else if (deliveryChoice == "3")
    {
        deliveryCreator = new ThirdPartyDeliveryCreator();
    }
    else
    {
        Console.WriteLine("Invalid delivery type.");
        return;
    }

    // Calculate total
    decimal total = cart.Sum(c => c.item.GetPrice() * c.qty);

    // Strategy Pattern - Payment
    Payment payment = new Payment(orderCounter, total);

    bool paymentSelected = false;

    while (!paymentSelected)
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

                paymentSelected = true;
                break;

            case "2":
                Console.Write("Enter PayPal email: ");
                string email = Console.ReadLine() ?? "";

                payment.SetPaymentStrategy(
                    new PayPalPayment(email)
                );

                paymentSelected = true;
                break;

            case "3":
                payment.SetPaymentStrategy(
                    new CashOnDeliveryPayment()
                );

                paymentSelected = true;
                break;

            case "0":
                Console.WriteLine("Checkout cancelled. Your cart has been kept.");
                return;

            default:
                Console.WriteLine("Invalid payment method. Please try again.");
                break;
        }
    }

    // Create Order
    Order newOrder = new Order(orderCounter++);

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

    // Factory Pattern - Create Delivery
    Delivery delivery = deliveryCreator.CreateDelivery(newOrder.OrderId, address, deliveryDate, $"TRK{newOrder.OrderId}" );

    // Facade Pattern
    bool orderPlaced = orderFacade.PlaceOrder(newOrder, payment, delivery);

    if (!orderPlaced)
    {
        Console.WriteLine("Checkout was unsuccessful.");
        return;
    }

    // Save order
    orderHistory.Insert(0, newOrder);
    lastOrder = newOrder;

    Console.WriteLine();
    Console.WriteLine("================================");
    Console.WriteLine("       ORDER CONFIRMED");
    Console.WriteLine("================================");

    Console.WriteLine($"Order ID: ORD{newOrder.OrderId}");
    Console.WriteLine($"Total Amount: ${total:N2}");
    Console.WriteLine($"Order Status: {newOrder.Status}");
    Console.WriteLine($"Payment Method: {payment.PaymentMethod}");

    if (payment.IsCashOnDelivery)
    {
        Console.WriteLine("Payment Status: Pending Collection");
    }
    else
    {
        Console.WriteLine("Payment Status: Paid");
    }

    Console.WriteLine();
    Console.WriteLine("Delivery Details:");
    Console.WriteLine($"Address: {delivery.DeliveryAddress}");
    Console.WriteLine($"Preferred Delivery Date: {delivery.ScheduledDate:dd/MM/yyyy}");
    Console.WriteLine("Delivery Slot: 2:00 PM - 5:00 PM");
    Console.WriteLine($"Tracking Number: {delivery.TrackingNumber}");

    Console.WriteLine("================================");

    // Save current order items for Repeat Order
    lastOrderItems.Clear();

    foreach (var item in cart)
    {
        lastOrderItems.Add(item);
    }

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
        Console.WriteLine("Invalid Order ID. Please use a format such as ORD1001.");
        return;
    }

    Order? found = orderHistory.FirstOrDefault(o => o.OrderId == orderId);

    if (found == null)
    {
        Console.WriteLine("Order not found.");
        return;
    }

    // Facade Pattern
    orderFacade.DisplayOrderDetails(found);

    Console.WriteLine();
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1. Manage This Order");
    Console.WriteLine("0. Back");
    Console.Write("Enter your choice: ");

    string detailChoice = Console.ReadLine() ?? "";

    if (detailChoice == "1")
    {
        ManageOrder();
    }
}


// ─── Option 6: Repeat Last Order ──────────────────────────────────────
// command pattern
void RepeatLastOrder()
{
    Console.WriteLine("\n=== Repeat Last Order ===");

    if (lastOrder == null || lastOrderItems.Count == 0)
    {
        Console.WriteLine("No previous order found.");
        return;
    }

    Console.WriteLine($"Last Order: ORD{lastOrder.OrderId}");
    Console.WriteLine($"Total: ${lastOrder.TotalAmount:N2}");
    Console.WriteLine("1. Repeat Order");
    Console.WriteLine("0. Back");
    Console.Write("Enter choice: ");

    string choice = Console.ReadLine() ?? "";

    if (choice == "1")
    {
        orderCommandInvoker.ExecuteCommand();

        Console.WriteLine("\nPrevious order has been repeated.");
        Console.WriteLine("1. Proceed to Checkout");
        Console.WriteLine("2. Undo Repeat");
        Console.WriteLine("0. Back");
        Console.Write("Enter choice: ");

        string repeatChoice = Console.ReadLine() ?? "";

        if (repeatChoice == "1")
        {
            Console.WriteLine("Please confirm delivery and payment details again.");
            Checkout();
        }
        else if (repeatChoice == "2")
        {
            orderCommandInvoker.UndoCommand();
        }
        else if (repeatChoice == "0")
        {
            return;
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
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
        Console.WriteLine("3. Process Next Delivery Stage");
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
                    // Facade Pattern
                    orderFacade.CancelOrder(found);
                }
                back = true;
                break;

            case "2":
                Console.WriteLine($"\n=== Track Delivery ORD{found.OrderId} ===");

                Console.WriteLine($"Order Status: {found.Status}");

                if (found.Delivery != null)
                {
                    Console.WriteLine($"Delivery Address: {found.Delivery.DeliveryAddress}");
                    Console.WriteLine($"Expected Delivery Date: {found.Delivery.ScheduledDate:dd/MM/yyyy}");
                    Console.WriteLine("Delivery Slot: 2:00 PM - 5:00 PM");
                    //Console.WriteLine($"Tracking Number: {found.Delivery.TrackingNumber}");
                    //Console.WriteLine($"Delivery Status: {found.Delivery.DeliveryStatus}");
                    Console.WriteLine(found.Delivery.TrackDelivery());
                }
                else
                {
                    Console.WriteLine("Delivery information is not available for this order.");
                }

                break;

            case "3":
                Console.WriteLine("\n=== Process Delivery ===");

                if (found.Status == "Preparing")
                {
                    Console.WriteLine("Packing has been completed.");

                    found.PackingCompleted();

                    Console.WriteLine(
                        $"Order ORD{found.OrderId} is now out for delivery."
                    );
                }
                else if (found.Status == "Out for Delivery")
                {
                    Console.WriteLine("Confirming delivery...");

                    found.ConfirmDelivery();

                    Console.WriteLine(
                        $"Order ORD{found.OrderId} has been delivered successfully."
                    );
                }
                else if (found.Status == "Delivered")
                {
                    Console.WriteLine(
                        "This order has already been delivered."
                    );
                }
                else if (found.Status == "Cancelled")
                {
                    Console.WriteLine(
                        "A cancelled order cannot proceed with delivery."
                    );
                }
                else
                {
                    Console.WriteLine(
                        $"Delivery cannot be updated while the order status is {found.Status}."
                    );
                }

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
