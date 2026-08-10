/* SDP Group 2
- ICKIER Furniture System
- Ada, Rui Min, Zi Ying, Christina
*/

// Zi Ying

using System;
using System.Collections.Generic;

namespace ICKIER_Furniture_Retailer_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("================================");
            Console.WriteLine("   ICKIER FURNITURE RETAILER");
            Console.WriteLine("================================");
            Console.WriteLine();

            // ==============================
            // Strategy Pattern - Payment
            // ==============================

            Payment payment = new Payment(1, 250.00m);

            Console.WriteLine("PAYMENT");
            Console.WriteLine("--------------------------------");
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
                Console.Write("Request refund? (Y/N): ");
                string refundChoice = Console.ReadLine();

                while (!refundChoice.Equals("Y", StringComparison.OrdinalIgnoreCase) &&
                       !refundChoice.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Invalid input. Please enter Y or N: ");
                    refundChoice = Console.ReadLine();
                }

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
            Console.WriteLine();

            // ==============================
            // Observer Pattern - Promotions
            // ==============================

            Console.WriteLine("================================");
            Console.WriteLine("       BRAND PROMOTIONS");
            Console.WriteLine("================================");
            Console.WriteLine();

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

            string observerChoice;
            int nextPromotionId = 1;

            do
            {
                Console.WriteLine();
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

                observerChoice = Console.ReadLine();

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

                        Console.Write("Enter Promotion Title: ");
                        string promotionTitle = Console.ReadLine();

                        Console.Write("Enter Promotion Description: ");
                        string promotionDescription = Console.ReadLine();

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
                        Console.WriteLine("Returning...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

            } while (observerChoice != "0");
        }
    }
}