//ziying
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICKIER_Furniture_Retailer_System
{
    public class OrderItem
    {
        public int FurnitureId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public OrderItem(
            int furnitureId,
            int quantity,
            decimal unitPrice)
        {
            FurnitureId = furnitureId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public decimal calculateSubtotal()
        {
            return UnitPrice * Quantity;
        }
    }
}