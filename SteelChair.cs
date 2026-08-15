using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ada
namespace ICKIER_Furniture_Retailer_System
{
    public class SteelChair : Chair
    {
        public SteelChair(int furnitureId, string name, decimal basePrice, string description, double height) : base(furnitureId, name, basePrice, description, "Steel", height)
        {
        }
    }
}
