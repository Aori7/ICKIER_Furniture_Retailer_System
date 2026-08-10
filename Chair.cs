using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICKIER_Furniture_Retailer_System
{
    internal class Chair : FurnitureItem
    {
        private string material;
        private double height;

        public string Material { get { return material; } }
        public double Height { get { return height; } }

        public Chair(int furnitureId, string name, decimal basePrice, string description,
                     string material, double height) : base(furnitureId, name, basePrice, description)
        {
            this.material = material;
            this.height = height;
        }

        public override string GetDescription()
        {
            return $"Chair: {name} ({material}, {height}cm)";
        }
        public override decimal GetPrice()
        {
            return basePrice;
        }
    }
}
