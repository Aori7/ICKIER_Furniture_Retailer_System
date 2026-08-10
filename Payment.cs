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
        public bool IsPaid { get; private set; }
        public bool IsRefunded { get; private set; }

        private IPaymentStrategy? paymentStrategy;

        public bool IsCashOnDelivery
        {
            get
            {
                return paymentStrategy is CashOnDeliveryPayment;
            }
        }

        public Payment(int paymentId, decimal amount)
        {
            PaymentId = paymentId;
            Amount = amount;
            PaymentDate = DateTime.Now;
            IsPaid = false;
            IsRefunded = false;
        }

        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            paymentStrategy = strategy;
        }

        public bool ProcessPayment()
        {
            if (Amount <= 0)
            {
                Console.WriteLine("Payment amount must be greater than $0.");
                return false;
            }

            if (paymentStrategy == null)
            {
                Console.WriteLine("Please select a payment method.");
                return false;
            }

            bool successful = paymentStrategy.Pay(Amount);

            if (successful)
            {
                if (paymentStrategy is CashOnDeliveryPayment)
                {
                    IsPaid = false;
                }
                else
                {
                    IsPaid = true;
                }
            }

            return successful;
        }

        public bool RefundPayment()
        {
            if (!IsPaid)
            {
                Console.WriteLine("Refund cannot be processed because payment has not been completed.");
                return false;
            }

            if (IsRefunded)
            {
                Console.WriteLine("This payment has already been refunded.");
                return false;
            }

            if (paymentStrategy == null)
            {
                Console.WriteLine("No payment strategy has been selected.");
                return false;
            }

            bool successful = paymentStrategy.Refund(Amount);

            if (successful)
            {
                IsRefunded = true;
            }

            return successful;
        }
        public bool MarkCashOnDeliveryAsPaid()
        {
            if (paymentStrategy is not CashOnDeliveryPayment)
            {
                Console.WriteLine("This payment is not Cash on Delivery.");
                return false;
            }

            if (IsPaid)
            {
                Console.WriteLine("Cash on Delivery payment has already been collected.");
                return false;
            }

            IsPaid = true;
            Console.WriteLine($"Cash on Delivery payment of ${Amount:F2} collected successfully.");
            return true;
        }
    }
}
