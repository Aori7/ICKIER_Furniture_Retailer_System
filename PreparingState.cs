//Christina
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    internal class PreparingState : OrderState
    {
        public PreparingState(Order order) : base(order) { }

        public override void PlaceOrder() { Console.WriteLine("Order already placed and being prepared."); }
        public override void MakePayment() { Console.WriteLine("Payment already processed."); }
        public override void CancelOrder()
        {
            Console.WriteLine($"Order {order.OrderId}: Order cancelled before shipping. Payment refunded.");
            order.Status = "Cancelled";
            order.SetState(order.CancelledState);
        }
        public override void ConfirmDelivery() { Console.WriteLine("Cannot confirm delivery - order not shipped yet."); }
        public override void RequestReturn() { Console.WriteLine("Cannot return - order not delivered yet."); }
        public override void ArchiveOrder() { Console.WriteLine("Cannot archive - order not delivered yet."); }
        public override void RemoveOrder() { Console.WriteLine("Cannot remove - order still active."); }
        public override void PackingCompleted()
        {
            Console.WriteLine($"Order {order.OrderId}: Packing completed. Order is out for delivery.");
            order.Status = "Out for Delivery";
            order.SetState(order.OutForDeliveryState);
        }
    }
}
