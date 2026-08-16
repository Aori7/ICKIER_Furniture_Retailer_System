// Christina & Rui Min - Decorator and Composite pattern
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
        private Brand? brandName;
        private Promotion? activePromotion;

        public int FurnitureId { get { return furnitureId; } set { furnitureId = value; } }
        public override string Name { get { return name; } }
        public decimal BasePrice { get { return basePrice; } set { basePrice = value; } }
        public string Description { get { return description; } set { description = value; } }

        public Brand? BrandName { get { return brandName; } set { brandName = value; } }

        public Promotion? ActivePromotion { get { return activePromotion; } set { activePromotion = value; } }


        public FurnitureItem(int furnitureId, string name, decimal basePrice, string description, Brand? brandName = null, Promotion? activePromotion = null)
        {
            this.furnitureId = furnitureId;
            this.name = name;
            this.basePrice = basePrice;
            this.description = description;
            this.brandName = brandName;
            this.activePromotion = activePromotion;
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
