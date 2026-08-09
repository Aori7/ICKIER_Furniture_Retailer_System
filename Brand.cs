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

        private List<IBrandObserver> observers;
        private List<Promotion> promotions;

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
            }
        }

        public void Unsubscribe(IBrandObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(Promotion promotion)
        {
            foreach (IBrandObserver observer in observers)
            {
                observer.Update(promotion);
            }
        }

        public void AddPromotion(Promotion promotion)
        {
            promotions.Add(promotion);

            Console.WriteLine(
                $"New promotion added by {BrandName}: {promotion.Title}"
            );

            NotifyObservers(promotion);
        }
    }
}
