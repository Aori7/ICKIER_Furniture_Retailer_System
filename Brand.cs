//ziying
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    public class Brand : IBrandSubject
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        private readonly List<IBrandObserver> observers;
        private readonly List<Promotion> promotions;

        public Brand(int brandId, string brandName)
        {
            BrandId = brandId;
            BrandName = brandName;

            observers = new List<IBrandObserver>();
            promotions = new List<Promotion>();
        }

        public void Subscribe(IBrandObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
                Console.WriteLine($"Successfully subscribed to {BrandName}.");
            }
            else
            {
                Console.WriteLine("You are already subscribed to this brand.");
            }
        }

        public void Unsubscribe(IBrandObserver observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
                Console.WriteLine($"Successfully unsubscribed from {BrandName}.");
            }
            else
            {
                Console.WriteLine("You are not subscribed to this brand.");
            }
        }

        public void NotifyObservers(Promotion promotion)
        {
            foreach (IBrandObserver observer in observers)
            {
                observer.Update(this, promotion);
            }
        }

        public void AddPromotion(Promotion promotion)
        {
            if (!promotion.IsActive())
            {
                Console.WriteLine("Promotion is not active and cannot be sent to subscribers.");
                return;
            }

            promotions.Add(promotion);

            Console.WriteLine(
                $"New promotion added by {BrandName}: {promotion.Title}"
            );

            NotifyObservers(promotion);
        }
    }
}
