//Christina
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICKIER_Furniture_Retailer_System
{
    internal class WarrantyDecorator : FurnitureDecorator
    {
        private decimal warrantyPrice;

        public decimal WarrantyPrice { get { return warrantyPrice; } }

        public WarrantyDecorator(FurnitureItem furniture, decimal warrantyPrice)
            : base(furniture.FurnitureId, furniture)
        {
            this.warrantyPrice = warrantyPrice;
        }

        public override string GetDescription()
        {
            return furniture.GetDescription() + "\n+ 3-Year Warranty";
        }
        public override decimal GetPrice()
        {
            return furniture.GetPrice() + warrantyPrice;
        }
    }
}
