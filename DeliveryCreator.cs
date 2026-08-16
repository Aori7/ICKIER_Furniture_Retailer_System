using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ada
namespace ICKIER_Furniture_Retailer_System
{
    public abstract class DeliveryCreator
    {
        public abstract Delivery CreateDelivery(int deliveryId, string address, DateTime scheduledDate, string trackingNumber);
    }
}
