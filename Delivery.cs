//zy
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ICKIER_Furniture_Retailer_System
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string DeliveryStatus { get; set; }
        public string TrackingNumber { get; set; }

        public Delivery(
            int deliveryId,
            string deliveryAddress,
            DateTime scheduledDate,
            string trackingNumber)
        {
            DeliveryId = deliveryId;
            DeliveryAddress = deliveryAddress;
            ScheduledDate = scheduledDate;
            TrackingNumber = trackingNumber;
            DeliveryStatus = "Scheduled";
        }

        public void UpdateStatus(string status)
        {
            DeliveryStatus = status;
        }

        public string TrackDelivery()
        {
            return $"Tracking Number: {TrackingNumber} | Status: {DeliveryStatus}";
        }
    }
}