// Zi Ying
using System;

namespace ICKIER_Furniture_Retailer_System
{
    public class PayPalPayment : IPaymentStrategy
    {
        public string Email { get; set; }

        public PayPalPayment(string email)
        {
            Email = email;
        }

        public string MethodName => "PayPal";

        public bool Pay(decimal amount)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                Console.WriteLine(
                    "Invalid PayPal email address. Please use a format such as name@example.com."
                );
                return false;
            }

            int atIndex = Email.IndexOf('@');
            int lastDotIndex = Email.LastIndexOf('.');

            if (atIndex <= 0 ||
                atIndex != Email.LastIndexOf('@') ||
                lastDotIndex <= atIndex + 1 ||
                lastDotIndex == Email.Length - 1)
            {
                Console.WriteLine(
                    "Invalid PayPal email address. Please use a format such as name@example.com."
                );
                return false;
            }

            Console.WriteLine(
                $"Processing PayPal payment of ${amount:F2}..."
            );

            Console.WriteLine("PayPal payment successful.");

            return true;
        }

        public bool Refund(decimal amount)
        {
            Console.WriteLine(
                $"Refunding ${amount:F2} through PayPal..."
            );

            Console.WriteLine("PayPal refund successful.");

            return true;
        }
    }
}