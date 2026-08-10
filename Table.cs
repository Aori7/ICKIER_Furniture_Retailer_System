using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICKIER_Furniture_Retailer_System
{
    internal class Table : FurnitureItem
    {
        private string material;
        private double length;
        private double width;

        public string Material { get { return material; } }
        public double Length { get { return length; } }
        public double Width { get { return width; } }

        public Table(int furnitureId, string name, decimal basePrice, string description,
                     string material, double length, double width) : base (furnitureId, name, basePrice, description)
        {
            this.material = material;
            this.length = length;
            this.width = width;
        }

        public override string GetDescription()
        {
            return $"Table: {name} ({material}, {length}x{width}cm)";
        }
        public override decimal GetPrice()
        {
            return basePrice;
        }
    }
}
