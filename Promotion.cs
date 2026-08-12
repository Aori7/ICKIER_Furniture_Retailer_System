//ziying
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Promotion(
            int promotionId,
            string title,
            string description,
            decimal discountPercentage,
            DateTime startDate,
            DateTime endDate)
        {
            PromotionId = promotionId;
            Title = title;
            Description = description;
            DiscountPercentage = discountPercentage;
            StartDate = startDate;
            EndDate = endDate;
        }

        public bool IsActive()
        {
            DateTime currentDate = DateTime.Now;

            return currentDate >= StartDate &&
                   currentDate <= EndDate;
        }
    }
}