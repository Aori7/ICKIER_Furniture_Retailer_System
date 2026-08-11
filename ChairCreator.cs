using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ada
namespace ICKIER_Furniture_Retailer_System
{
    internal class ChairCreator : FurnitureCreator
    {
        public override FurnitureItem CreateFurniture()
        {
            return new Chair(2, "Basic Chair", 75m, "Basic Furniture Chair", "Basic", 90);
        }
    }
}
