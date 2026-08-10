using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICKIER_Furniture_Retailer_System
{
    internal class BookShelf : FurnitureItem
    {
        private string material;
        private double height;
        private double width;
        private int shelfCount;

        public string Material { get { return material; } }
        public double Height { get { return height; } }
        public double Width { get { return width; } }
        public int ShelfCount { get { return shelfCount; } }

        public BookShelf(int furnitureId, string name, decimal basePrice, string description,
                         string material, double height, double width, int shelfCount): base(furnitureId,name,basePrice, description)
        {
            this.material = material;
            this.height = height;
            this.width = width;
            this.shelfCount = shelfCount;
        }

        public override string GetDescription()
        {
            return $"BookShelf: {name} ({material}, {height}x{width}cm, {shelfCount} shelves)";
        }
        public override decimal GetPrice()
        {
            return basePrice;
        }
    }
}
