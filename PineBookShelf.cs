using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ada
namespace ICKIER_Furniture_Retailer_System
{
    public class PineBookShelf : BookShelf
    {
        public PineBookShelf(int furnitureId, string name, decimal basePrice, string description, double height, double width, int shelfCount) : base(furnitureId, name, basePrice, description, "Pine", height, width, shelfCount)
        {
        }
    }
}
