//Christina
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    internal class OutForDeliveryState : OrderState
    {
        public OutForDeliveryState(Order order) : base(order) { }

        public override void PlaceOrder() { Console.WriteLine("Order already placed and out for delivery."); }
        public override void MakePayment() { Console.WriteLine("Payment already processed."); }
        public override void CancelOrder() { Console.WriteLine("Cannot cancel - order already shipped. No refund."); }
        public override void ConfirmDelivery()
        {
            Console.WriteLine($"Order {order.OrderId}: Delivery confirmed.");

            order.Status = "Delivered";
            order.DeliveryDate = DateTime.Now;

            order.Delivery?.UpdateStatus("Delivered");

            order.SetState(order.DeliveredState);
        }
        public override void RequestReturn() { Console.WriteLine("Cannot return - order not delivered yet."); }
        public override void ArchiveOrder() { Console.WriteLine("Cannot archive - order not delivered yet."); }
        public override void RemoveOrder() { Console.WriteLine("Cannot remove - order still active."); }
        public override void PackingCompleted() { Console.WriteLine("Packing already completed."); }
    }
}