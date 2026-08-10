//Christina
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    internal class CreatedState : OrderState
    {
        public CreatedState(Order order) : base(order) { }

        public override void PlaceOrder()
        {
            Console.WriteLine($"Order {order.OrderId}: Order placed. Awaiting payment...");
            order.Status = "Awaiting Payment";
            order.SetState(order.AwaitingPaymentState);
        }
        public override void MakePayment() { Console.WriteLine("Cannot make payment - place order first."); }
        public override void CancelOrder() { Console.WriteLine("Cannot cancel - order not placed yet."); }
        public override void ConfirmDelivery() { Console.WriteLine("Cannot confirm delivery - order not placed yet."); }
        public override void RequestReturn() { Console.WriteLine("Cannot return - order not placed yet."); }
        public override void ArchiveOrder() { Console.WriteLine("Cannot archive - order not placed yet."); }
        public override void RemoveOrder() { Console.WriteLine("Cannot remove - order not placed yet."); }
        public override void PackingCompleted() { Console.WriteLine("Cannot complete packing - order not placed yet."); }
    }
}