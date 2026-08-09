//Zi Ying
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    public class CreditCardPayment : IPaymentStrategy
    {
        public string CardNumber { get; set; }

        public CreditCardPayment(string cardNumber)
        {
            CardNumber = cardNumber;
        }

        public bool Pay(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of ${amount:F2}...");
            Console.WriteLine("Credit card payment successful.");
            return true;
        }

        public bool Refund(decimal amount)
        {
            Console.WriteLine($"Refunding ${amount:F2} to credit card...");
            Console.WriteLine("Credit card refund successful.");
            return true;
        }
    }
}
