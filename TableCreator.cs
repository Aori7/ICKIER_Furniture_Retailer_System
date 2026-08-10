using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ada
namespace ICKIER_Furniture_Retailer_System
{
    internal class TableCreator : FurnitureCreator
    {
        public override FurnitureItem CreateFurniture()
        {
            return new Table(1, "Basic Table", 150m, "Basic Furniture Table", "Basic", 120,60);
        }
    }
}
