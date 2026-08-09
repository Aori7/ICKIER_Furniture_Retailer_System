//Zi Ying
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            if (string.IsNullOrWhiteSpace(CardNumber) ||
                CardNumber.Length != 16 ||
                !CardNumber.All(char.IsDigit))
            {
                Console.WriteLine("Invalid credit card number. Please enter a 16-digit card number.");
                return false;
            }

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
