//Christina
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    internal class AwaitingPaymentState : OrderState
    {
        public AwaitingPaymentState(Order order) : base(order) { }

        public override void PlaceOrder() { Console.WriteLine("Order already placed, awaiting payment."); }

        public override void MakePayment()
        {
            if (order.Payment != null && order.Payment.IsCashOnDelivery)
            {
                // Cash on Delivery - stays in Preparing so customer can still cancel
                Console.WriteLine($"Order {order.OrderId}: Cash on Delivery selected. Order is being prepared...");
                Console.WriteLine("You can still cancel your order at this stage.");
                order.Status = "Preparing";
                order.SetState(order.PreparingState);
            }
            else
            {
                // Credit Card / PayPal - paid immediately, packing done, goes straight to Out for Delivery
                Console.WriteLine($"Order {order.OrderId}: Payment successful.");
                Console.WriteLine($"Order {order.OrderId}: Packing completed.");
                Console.WriteLine($"Order {order.OrderId}: Order is now out for delivery!");
                order.Status = "Out for Delivery";
                order.DeliveryDate = DateTime.Now;
                order.SetState(order.OutForDeliveryState);
            }
        }

        public override void CancelOrder()
        {
            Console.WriteLine($"Order {order.OrderId}: Order cancelled. Payment refunded.");
            order.Status = "Cancelled";
            order.SetState(order.CancelledState);
        }
        public override void ConfirmDelivery() { Console.WriteLine("Cannot confirm delivery - payment not received."); }
        public override void RequestReturn() { Console.WriteLine("Cannot return - payment not received."); }
        public override void ArchiveOrder() { Console.WriteLine("Cannot archive - payment not received."); }
        public override void RemoveOrder() { Console.WriteLine("Cannot remove - payment not received."); }
        public override void PackingCompleted() { Console.WriteLine("Cannot complete packing - payment not received."); }
    }
}