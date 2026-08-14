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
        private readonly List<Brand> subscribedBrands;

        public Customer(int customerId, string name, string email)
        {
            CustomerId = customerId;
            Name = name;
            Email = email;
            notifications = new List<Notification>();
            subscribedBrands = new List<Brand>();
        }

        public void SubscribeToBrand(Brand brand)
        {
            Console.WriteLine($"{Name} subscribing to {brand.BrandName}...");

            if (!subscribedBrands.Contains(brand))
            {
                brand.Subscribe(this);
                subscribedBrands.Add(brand);
            }
            else
            {
                Console.WriteLine("You are already subscribed to this brand.");
            }
        }

        public void UnsubscribeFromBrand(Brand brand)
        {
            Console.WriteLine($"{Name} unsubscribing from {brand.BrandName}...");

            if (subscribedBrands.Contains(brand))
            {
                brand.Unsubscribe(this);
                subscribedBrands.Remove(brand);
            }
            else
            {
                Console.WriteLine("You are not subscribed to this brand.");
            }
        }

        public void Update(Brand brand, Promotion promotion)
        {
            int notificationId = notifications.Count + 1;

            string message =
               $"New promotion from {brand.BrandName}: " +
               $"{promotion.Title} - " +
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
        public void ViewSubscriptions()
        {
            Console.WriteLine();
            Console.WriteLine($"=== Brand Subscriptions for {Name} ===");

            if (subscribedBrands.Count == 0)
            {
                Console.WriteLine("You are not subscribed to any brands.");
                return;
            }

            foreach (Brand brand in subscribedBrands)
            {
                Console.WriteLine(
                    $"{brand.BrandId}. {brand.BrandName}"
                );
            }
        }
    }
}
