using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ada
namespace ICKIER_Furniture_Retailer_System
{
    public class OakTable : Table
    {
        public OakTable(int furnitureId, string name, decimal basePrice, string description, double length, double width) : base(furnitureId, name, basePrice, description, "Oak", length, width)
        {
        }
    }
}
