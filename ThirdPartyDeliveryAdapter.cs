using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ada
namespace ICKIER_Furniture_Retailer_System
{
    public class ThirdPartyDeliveryAdapter : Delivery
    {
        private ExternalCourierService externalCourier;

        public ThirdPartyDeliveryAdapter(int deliveryId, string deliveryAddress, DateTime scheduledDate, string trackingNumber, ExternalCourierService externalCourier) : base(deliveryId, deliveryAddress, scheduledDate, trackingNumber)
        {
            this.externalCourier = externalCourier;
        }

        public void ScheduleDelivery()
        {
            externalCourier.BookShipment(DeliveryAddress, ScheduledDate);
        }

        public override string TrackDelivery()
        {
            return externalCourier.GetShipmentStatus(TrackingNumber);
        }
    }
}
