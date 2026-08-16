// Rui Min - Facade pattern
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    public class OrderFacade
    {
        // Places an order by coordinating Order, Payment and Delivery
        public bool PlaceOrder(Order order, Payment payment, Delivery delivery)
        {
            if (order == null || payment == null || delivery == null)
            {
                Console.WriteLine("Order, payment or delivery details are missing.");
                return false;
            }

            order.SetPayment(payment);
            order.SetDelivery(delivery);
            bool paymentSuccessful = payment.ProcessPayment();

            if (!paymentSuccessful)
            {
                Console.WriteLine("Payment was unsuccessful. Order was not placed.");
                return false;
            }

            delivery.ScheduleDelivery();
            order.PlaceOrder();
            order.MakePayment();
            Console.WriteLine($"Order ORD{order.OrderId} placed successfully.");
            return true;
        }


        // Cancels an order refunds user
        public bool CancelOrder(Order order)
        {
            if (order == null)
            {
                Console.WriteLine("Order cannot be found.");
                return false;
            }

            order.CancelOrder();

            if (order.Status != "Cancelled")
            {
                Console.WriteLine($"Order ORD{order.OrderId} could not be cancelled.");
                return false;
            }

            // refund
            if (order.Payment != null)
            {
                if (order.Payment.IsPaid)
                {
                    order.Payment.RefundPayment();
                }
                else if (order.Payment.IsCashOnDelivery)
                {
                    Console.WriteLine(
                        "No refund is required because Cash on Delivery has not been collected."
                    );
                }
            }

            Console.WriteLine($"Order ORD{order.OrderId} cancelled successfully.");
            return true;
        }


        // Combines details from Order, Payment and Delivery
        public void DisplayOrderDetails(Order order)
        {
            if (order == null)
            {
                Console.WriteLine("Order cannot be found.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("=== Order Details ===");
            Console.WriteLine($"Order ID: ORD{order.OrderId}");
            Console.WriteLine($"Status: {order.Status}");
            Console.WriteLine($"Total: ${order.TotalAmount:N2}");

            // payment information
            if (order.Payment != null)
            {
                Console.WriteLine();
                Console.WriteLine("Payment Details:");

                if (order.Payment.IsCashOnDelivery)
                {
                    if (order.Payment.IsPaid)
                    {
                        Console.WriteLine("Payment: Cash on Delivery - Paid");
                    }
                    else
                    {
                        Console.WriteLine("Payment: Cash on Delivery - Pending Collection");
                    }
                }
                else
                {
                    if (order.Payment.IsPaid)
                    {
                        Console.WriteLine("Payment: Paid");
                    }
                    else
                    {
                        Console.WriteLine("Payment: Not Paid");
                    }
                }

                if (order.Payment.IsRefunded)
                {
                    Console.WriteLine("Refund Status: Refunded");
                }
            }

            // delivery information
            if (order.Delivery != null)
            {
                Console.WriteLine();
                Console.WriteLine("Delivery Details:");
                Console.WriteLine($"Address: {order.Delivery.DeliveryAddress}");
                Console.WriteLine($"Delivery Date: {order.Delivery.ScheduledDate:dd/MM/yyyy}");
                Console.WriteLine($"Tracking Number: {order.Delivery.TrackingNumber}");
                Console.WriteLine($"Delivery Status: {order.Delivery.DeliveryStatus}");
            }
        }
    }
}

//namespace ICKIER_Furniture_Retailer_System
//{
//    internal class OrderFacade
//    {
//        public bool PlaceOrder(Order order, Payment payment, Delivery delivery)
//        {
//            // TODO
//        }

//        public bool CancelOrder(Order order, Payment payment, Delivery delivery)
//        {
//            // TODO
//        }

//        public List<Order> GetOrderHistory(Customer customer)
//        {
//            // TODO

//        }

//        public void DisplayOrderDetails(Order order, Payment payment, Delivery delivery)
//        {
//            // TODO

//        }
//    }
//}
