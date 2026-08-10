//Christina
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    internal abstract class OrderState
    {
        protected Order order;

        public OrderState(Order order)
        {
            this.order = order;
        }

        public abstract void PlaceOrder();
        public abstract void MakePayment();
        public abstract void CancelOrder();
        public abstract void ConfirmDelivery();
        public abstract void RequestReturn();
        public abstract void ArchiveOrder();
        public abstract void RemoveOrder();
        public abstract void PackingCompleted();
    }
}
