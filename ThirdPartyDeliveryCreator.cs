using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICKIER_Furniture_Retailer_System
{
    public class ThirdPartyDeliveryCreator : DeliveryCreator
    {
        public override Delivery CreateDelivery(int deliveryId, string deliveryAddress, DateTime scheduledDate, string trackingNumber)
        {
            return new ThirdPartyDeliveryAdapter(deliveryId, deliveryAddress, scheduledDate, trackingNumber, new ExternalCourierService());
        }
    }
}
