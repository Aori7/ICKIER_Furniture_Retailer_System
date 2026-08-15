using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ada
namespace ICKIER_Furniture_Retailer_System
{
    public class SteelFurnitureFactory : FurnitureFactory
    {
        public Table CreateTable(double length, double width)
        {
            return new SteelTable(301, "Steel Table", 1000m, "Custom steel table", length, width);
        }

        public Chair CreateChair(double height)
        {
            return new SteelChair(302, "Steel Chair", 400m, "Custom steel chair", height);
        }

        public BookShelf CreateBookShelf(double height, double width, int shelfCount)
        {
            return new SteelBookShelf(303, "Steel BookShelf", 800m, "Custom steel bookshelf", height, width, shelfCount);
        }
    }
}
