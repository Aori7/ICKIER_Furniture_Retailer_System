/* SDP Group 2
 * ICKIER Furniture System
 * Ada, Rui Min, Zi Ying, Christina
 */

//Zi Ying

using System;

namespace ICKIER_Furniture_Retailer_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ICKIER Furniture Retailer ===");
            Console.WriteLine("Payment Testing");
            Console.WriteLine();

            Payment payment = new Payment(1, 250.00m);

            Console.WriteLine("Select Payment Method:");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. PayPal");
            Console.WriteLine("3. Cash on Delivery");
            Console.Write("Enter option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter card number: ");
                    string cardNumber = Console.ReadLine();

                    payment.SetPaymentStrategy(
                        new CreditCardPayment(cardNumber)
                    );
                    break;

                case "2":
                    Console.Write("Enter PayPal email: ");
                    string email = Console.ReadLine();

                    payment.SetPaymentStrategy(
                        new PayPalPayment(email)
                    );
                    break;

                case "3":
                    payment.SetPaymentStrategy(
                        new CashOnDeliveryPayment()
                    );
                    break;

                default:
                    Console.WriteLine("Invalid payment method.");
                    return;
            }

            Console.WriteLine();

            bool successful = payment.ProcessPayment();

            if (successful)
            {
                Console.WriteLine();
                Console.WriteLine("Payment process completed.");

                Console.WriteLine();
                Console.Write("Test refund? (Y/N): ");
                string refundChoice = Console.ReadLine();

                if (refundChoice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    payment.RefundPayment();
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Payment was unsuccessful.");
            }

            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine("       OBSERVER PATTERN TEST");
            Console.WriteLine("================================");
            Console.WriteLine();

            // Create a customer
            Customer customer = new Customer(
                1,
                "Zi Ying",
                "ziying@email.com"
            );

            // Create a brand
            Brand brand = new Brand(
                1,
                "ICKIER Home"
            );

            // Customer subscribes to the brand
            customer.SubscribeToBrand(brand);

            Console.WriteLine();

            // Create a promotion
            Promotion promotion = new Promotion(
                1,
                "National Day Sale",
                "Enjoy special discounts on selected furniture.",
                20m,
                DateTime.Now.AddDays(-1),
                DateTime.Now.AddDays(7)
            );

            // Brand publishes the promotion
            brand.AddPromotion(promotion);

            // Customer views the notification
            customer.ViewNotifications();

            Console.WriteLine();
            Console.WriteLine("--- Testing Unsubscribe ---");

            // Customer unsubscribes
            customer.UnsubscribeFromBrand(brand);

            // Create another promotion
            Promotion secondPromotion = new Promotion(
                2,
                "Weekend Sale",
                "Extra savings this weekend.",
                10m,
                DateTime.Now,
                DateTime.Now.AddDays(2)
            );

            // Brand publishes another promotion
            brand.AddPromotion(secondPromotion);

            Console.WriteLine();

            // Check the customer's notifications again
            customer.ViewNotifications();
        }
    }
}
