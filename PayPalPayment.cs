//Zi Ying
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    public class PayPalPayment : IPaymentStrategy
    {
        public string Email { get; set; }

        public PayPalPayment(string email)
        {
            Email = email;
        }

        public bool Pay(decimal amount)
        {
            if (string.IsNullOrWhiteSpace(Email) ||
                !Email.Contains("@") ||
                !Email.Contains("."))
            {
                Console.WriteLine("Invalid PayPal email address.");
                return false;
            }

            Console.WriteLine($"Processing PayPal payment of ${amount:F2}...");
            Console.WriteLine("PayPal payment successful.");
            return true;
        }

        public bool Refund(decimal amount)
        {
            Console.WriteLine($"Refunding ${amount:F2} through PayPal...");
            Console.WriteLine("PayPal refund successful.");
            return true;
        }
    }
}