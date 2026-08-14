//Christina
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    public class Order
    {
        private int orderId;
        private DateTime orderDate;
        private DateTime deliveryDate;
        private string status;
        private decimal totalAmount;
        private List<OrderItem> items;
        private OrderState currentState;
        private Payment? payment;
        private Delivery? delivery;

        private OrderState createdState;
        private OrderState awaitingPaymentState;
        private OrderState preparingState;
        private OrderState outForDeliveryState;
        private OrderState deliveredState;
        private OrderState returnedState;
        private OrderState cancelledState;
        private OrderState archivedState;

        public OrderState CreatedState { get { return createdState; } }
        public OrderState AwaitingPaymentState { get { return awaitingPaymentState; } }
        public OrderState PreparingState { get { return preparingState; } }
        public OrderState OutForDeliveryState { get { return outForDeliveryState; } }
        public OrderState DeliveredState { get { return deliveredState; } }
        public OrderState ReturnedState { get { return returnedState; } }
        public OrderState CancelledState { get { return cancelledState; } }
        public OrderState ArchivedState { get { return archivedState; } }

        public int OrderId { get { return orderId; } }
        public string Status { get { return status; } set { status = value; } }
        public decimal TotalAmount { get { return totalAmount; } }
        public DateTime DeliveryDate { get { return deliveryDate; } set { deliveryDate = value; } }
        public Payment? Payment { get { return payment; } }
        public Delivery? Delivery { get { return delivery; } }

        public Order(int orderId)
        {
            this.orderId = orderId;
            this.orderDate = DateTime.Now;
            this.status = "Created";
            this.totalAmount = 0;
            this.items = new List<OrderItem>();

            createdState = new CreatedState(this);
            awaitingPaymentState = new AwaitingPaymentState(this);
            preparingState = new PreparingState(this);
            outForDeliveryState = new OutForDeliveryState(this);
            deliveredState = new DeliveredState(this);
            returnedState = new ReturnedState(this);
            cancelledState = new CancelledState(this);
            archivedState = new ArchivedState(this);

            currentState = createdState;
            Console.WriteLine($"Order {orderId} created.");
        }

        public void SetState(OrderState state) { currentState = state; }
        public void PlaceOrder() { currentState.PlaceOrder(); }
        public void MakePayment() { currentState.MakePayment(); }
        public void CancelOrder() { currentState.CancelOrder(); }
        public void ConfirmDelivery() { currentState.ConfirmDelivery(); }
        public void RequestReturn() { currentState.RequestReturn(); }
        public void ArchiveOrder() { currentState.ArchiveOrder(); }
        public void RemoveOrder() { currentState.RemoveOrder(); }
        public void PackingCompleted() { currentState.PackingCompleted(); }

        public void addItem(OrderItem item)
        {
            items.Add(item);
            totalAmount += item.calculateSubtotal();
        }
        public void removeItem(OrderItem item)
        {
            items.Remove(item);
            totalAmount -= item.calculateSubtotal();
        }
        public void SetPayment(Payment payment)
        {
            this.payment = payment;

        }
        public void SetDelivery(Delivery delivery)
        {
            this.delivery = delivery;
            this.deliveryDate = delivery.ScheduledDate;
        }
        public decimal calculateTotal() { return totalAmount; }
    }
}