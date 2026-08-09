using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICKIER_Furniture_Retailer_System
{
    internal abstract class FurnitureDecorator : FurnitureItem
    {
        protected FurnitureItem furniture;

        public FurnitureDecorator(int furnitureId, FurnitureItem furniture)
        {
            this.furnitureId = furnitureId;
            this.furniture = furniture;
        }

        public override string GetDescription()
        {
            return furniture.GetDescription();
        }
        public override decimal GetPrice()
        {
            return furniture.GetPrice();
        }
    }
}
