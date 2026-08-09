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
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Payment was unsuccessful.");
            }
        }
    }
}
