//ziying
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    public class Customer : IBrandObserver
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        private readonly List<Notification> notifications;

        public Customer(int customerId, string name, string email)
        {
            CustomerId = customerId;
            Name = name;
            Email = email;
            notifications = new List<Notification>();
        }

        public void SubscribeToBrand(Brand brand)
        {
            Console.WriteLine($"{Name} subscribing to {brand.BrandName}...");
            brand.Subscribe(this);
        }

        public void UnsubscribeFromBrand(Brand brand)
        {
            Console.WriteLine($"{Name} unsubscribing from {brand.BrandName}...");
            brand.Unsubscribe(this);
        }

        public void Update(Promotion promotion)
        {
            int notificationId = notifications.Count + 1;

            string message =
                $"New promotion: {promotion.Title} - " +
                $"{promotion.DiscountPercentage}% off. " +
                $"{promotion.Description}";

            Notification notification =
                new Notification(notificationId, message);

            notifications.Add(notification);
        }

        public void ViewNotifications()
        {
            Console.WriteLine();
            Console.WriteLine($"=== Notifications for {Name} ===");

            if (notifications.Count == 0)
            {
                Console.WriteLine("No notifications.");
                return;
            }

            foreach (Notification notification in notifications)
            {
                string status = notification.IsRead ? "Read" : "Unread";

                Console.WriteLine(
                    $"[{status}] {notification.Message}"
                );

                notification.MarkAsRead();
            }
        }
    }
}
