using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ada
namespace ICKIER_Furniture_Retailer_System
{
    public class ExpressDeliveryCreator : DeliveryCreator
    {
        public override Delivery CreateDelivery(int deliveryId, string address, DateTime scheduledDate, string trackingNumber)
        {
            return new ExpressDelivery(deliveryId, address, scheduledDate, trackingNumber);
        }
    }
}
