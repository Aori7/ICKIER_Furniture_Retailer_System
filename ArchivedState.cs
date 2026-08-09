using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    internal class ArchivedState : OrderState
    {
        public ArchivedState(Order order) : base(order) { }

        public override void PlaceOrder() { Console.WriteLine("Order is archived."); }
        public override void MakePayment() { Console.WriteLine("Order is archived."); }
        public override void CancelOrder() { Console.WriteLine("Cannot cancel - order is archived."); }
        public override void ConfirmDelivery() { Console.WriteLine("Order is archived."); }
        public override void RequestReturn() { Console.WriteLine("Return period has passed - order is archived."); }
        public override void ArchiveOrder() { Console.WriteLine("Order is already archived."); }
        public override void RemoveOrder()
        {
            Console.WriteLine($"Order {order.OrderId}: Order permanently removed from system.");
            order.Status = "Removed";
        }
        public override void PackingCompleted() { Console.WriteLine("Order is archived."); }
    }
}