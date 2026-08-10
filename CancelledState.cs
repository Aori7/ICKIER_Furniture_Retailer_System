//Christina
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    internal class CancelledState : OrderState
    {
        public CancelledState(Order order) : base(order) { }

        public override void PlaceOrder() { Console.WriteLine("Order is cancelled."); }
        public override void MakePayment() { Console.WriteLine("Order is cancelled."); }
        public override void CancelOrder() { Console.WriteLine("Order is already cancelled."); }
        public override void ConfirmDelivery() { Console.WriteLine("Order is cancelled."); }
        public override void RequestReturn() { Console.WriteLine("Order is cancelled."); }
        public override void ArchiveOrder() { Console.WriteLine("Order is cancelled."); }
        public override void RemoveOrder()
        {
            Console.WriteLine($"Order {order.OrderId}: Cancelled order removed from system.");
            order.Status = "Removed";
        }
        public override void PackingCompleted() { Console.WriteLine("Order is cancelled."); }
    }
}