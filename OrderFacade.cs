
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    internal class OrderFacade
    {
        public bool PlaceOrder(Order order, Payment payment, Delivery delivery)
        {
            // calculate total using Order class
            decimal total = order.CalculateTotal();

            // process payment using Payment class
            bool paymentSuccessful = payment.ProcessPayment();

            if (!paymentSuccessful)
            {
                Console.WriteLine("Payment failed. Order was not placed.");
                return false;
            }

            order.PlaceOrder();

            // arrange delivery using the Delivery class
            delivery.ScheduleDelivery();

            Console.WriteLine("Order placed successfully.");
            return true;
        }
    }
}
