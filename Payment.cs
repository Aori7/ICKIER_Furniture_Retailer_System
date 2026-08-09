//Zi Ying
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        private IPaymentStrategy paymentStrategy;

        public Payment(int paymentId, decimal amount)
        {
            PaymentId = paymentId;
            Amount = amount;
            PaymentDate = DateTime.Now;
        }

        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            paymentStrategy = strategy;
        }

        public bool ProcessPayment()
        {
            if (paymentStrategy == null)
            {
                Console.WriteLine("Please select a payment method.");
                return false;
            }

            return paymentStrategy.Pay(Amount);
        }

        public bool RefundPayment()
        {
            if (paymentStrategy == null)
            {
                Console.WriteLine("No payment method found for refund.");
                return false;
            }

            return paymentStrategy.Refund(Amount);
        }
    }
}
