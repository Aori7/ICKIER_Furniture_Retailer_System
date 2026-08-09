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
            Console.WriteLine($"Order {order.OrderId}: Payment successful. Preparing order...");
            order.Status = "Preparing";
            order.SetState(order.PreparingState);
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