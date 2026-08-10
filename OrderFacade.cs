// Rui Min - facade pattern
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

        public bool CancelOrder(Order order, Payment payment, Delivery delivery)
        {
            // let State pattern decide whether this order can be cancelled
            bool cancelled = order.CancelOrder();

            if (!cancelled)
            {
                Console.WriteLine("This order can no longer be cancelled.");
                return false;
            }

            // cancellation succeeded
            payment.RefundPayment();

            Console.WriteLine("Order cancelled successfully.");
            return true;
        }

        public List<Order> GetOrderHistory(Customer customer)
        {
            return customer.GetOrders();
        }

        public void DisplayOrderDetails(Order order, Payment payment, Delivery delivery)
        {
            Console.WriteLine("========= ORDER DETAILS =========");

            Console.WriteLine($"Total: ${order.CalculateTotal():F2}");
            payment.DisplayDetails();
            delivery.DisplayDetails();
        }
    }
}
