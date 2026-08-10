//Christina
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICKIER_Furniture_Retailer_System
{
    internal abstract class FurnitureItem
    {
        protected int furnitureId;
        protected string name;
        protected decimal basePrice;
        protected string description;

        public int FurnitureId { get { return furnitureId; } }
        public string Name { get { return name; } }
        public decimal BasePrice { get { return basePrice; } }
        public string Description { get { return description; } }

        public abstract string GetDescription();
        public abstract decimal GetPrice();
    }
}
