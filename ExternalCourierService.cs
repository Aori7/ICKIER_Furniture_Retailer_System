using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ada

namespace ICKIER_Furniture_Retailer_System
{
    public class ExternalCourierService
    {
        public void BookShipment(string address, DateTime scheduledDate)
        {
            Console.WriteLine($"External courier shipment booked to {address} for {scheduledDate:dd/MM/yyyy}.");
        }

        public string GetShipmentStatus(string trackingNumber)
        {
            return $"External courier tracking {trackingNumber}: In Transit";
        }
    }
}
