using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    internal class ReturnedState : OrderState
    {
        public ReturnedState(Order order) : base(order) { }

        public override void PlaceOrder() { Console.WriteLine("Order already returned."); }
        public override void MakePayment() { Console.WriteLine("Payment already processed."); }
        public override void CancelOrder() { Console.WriteLine("Cannot cancel - order already returned."); }
        public override void ConfirmDelivery() { Console.WriteLine("Delivery already confirmed."); }
        public override void RequestReturn() { Console.WriteLine("Return already requested."); }
        public override void ArchiveOrder() { Console.WriteLine("Cannot archive - return pending."); }
        public override void RemoveOrder()
        {
            Console.WriteLine($"Order {order.OrderId}: Return approved. Payment refunded. Order removed.");
            order.Status = "Removed";
        }
        public override void PackingCompleted() { Console.WriteLine("Packing already completed."); }
    }
}