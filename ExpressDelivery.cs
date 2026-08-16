using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ada

namespace ICKIER_Furniture_Retailer_System
{
    public class ExpressDelivery : Delivery
    {
        public ExpressDelivery(int deliveryId, string deliveryAddress, DateTime scheduledDate, string trackingNumber) : base(deliveryId, deliveryAddress, scheduledDate, trackingNumber)
        {
        }
    }
}
