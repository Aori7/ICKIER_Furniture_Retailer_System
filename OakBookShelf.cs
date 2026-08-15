using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ada
namespace ICKIER_Furniture_Retailer_System
{
    public class OakBookShelf : BookShelf
    {
        public OakBookShelf(int furnitureId, string name, decimal basePrice, string description, double height, double width, int shelfCount) : base(furnitureId, name, basePrice, description, "Oak", height, width, shelfCount)
        {
        }
    }
}
