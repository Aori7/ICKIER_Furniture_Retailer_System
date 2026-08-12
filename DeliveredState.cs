//Christina
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    public class DeliveredState : OrderState
    {
        public DeliveredState(Order order) : base(order) { }

        public override void PlaceOrder() { Console.WriteLine("Order already delivered."); }
        public override void MakePayment() { Console.WriteLine("Payment already processed."); }
        public override void CancelOrder() { Console.WriteLine("Cannot cancel - order already delivered."); }
        public override void ConfirmDelivery() { Console.WriteLine("Delivery already confirmed."); }
        public override void RequestReturn()
        {
            Console.WriteLine($"Order {order.OrderId}: Return requested within return period.");
            order.Status = "Returned";
            order.SetState(order.ReturnedState);
        }
        public override void ArchiveOrder()
        {
            if (DateTime.Now >= order.DeliveryDate.AddYears(1))
            {
                Console.WriteLine($"Order {order.OrderId}: Order archived after 1 year.");
                order.Status = "Archived";
                order.SetState(order.ArchivedState);
            }
            else
            {
                Console.WriteLine($"Order {order.OrderId}: Cannot archive - 1 year has not passed yet.");
            }
        }
        public override void RemoveOrder() { Console.WriteLine("Cannot remove - archive first."); }
        public override void PackingCompleted() { Console.WriteLine("Packing already completed."); }
    }
}