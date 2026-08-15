//Christina
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICKIER_Furniture_Retailer_System
{
    public class FurnitureItem : CatalogComponent
    {
        private int furnitureId;
        private string name;
        private decimal basePrice;
        private string description;

        public int FurnitureId { get { return furnitureId; } set { furnitureId = value; } }
        public string Name { get { return name; } set { name = value; } }
        public decimal BasePrice { get { return basePrice; } set { basePrice = value; } }
        public string Description { get { return description; } set { description = value; } }


        public FurnitureItem(int furnitureId, string name, decimal basePrice, string description)
        {
            this.furnitureId = furnitureId;
            this.name = name;
            this.basePrice = basePrice;
            this.description = description;
        }

        public override string GetDescription()
        {
            return description;
        }

        public virtual decimal GetPrice()
        {
            return basePrice;
        }
    }
}
