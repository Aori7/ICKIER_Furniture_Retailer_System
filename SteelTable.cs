using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ada
namespace ICKIER_Furniture_Retailer_System
{
    public class SteelTable : Table
    {
        public SteelTable(int furnitureId, string name, decimal basePrice, string description, double length, double width) : base(furnitureId, name, basePrice, description, "Steel", length, width)
        {
        }
    }
}
