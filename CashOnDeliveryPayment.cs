//Zi Ying
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    public class CashOnDeliveryPayment : IPaymentStrategy
    {
        public bool Pay(decimal amount)
        {
            Console.WriteLine($"Cash on Delivery selected for ${amount:F2}.");
            Console.WriteLine("Payment will be collected when the order is delivered.");
            return true;
        }

        public bool Refund(decimal amount)
        {
            Console.WriteLine($"Refund of ${amount:F2} for Cash on Delivery.");
            Console.WriteLine("Cash on Delivery refund processed successfully.");
            return true;
        }
    }
}
