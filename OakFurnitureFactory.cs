using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ada
namespace ICKIER_Furniture_Retailer_System
{
    public class OakFurnitureFactory : FurnitureFactory
    {
        public Table CreateTable(double length, double width)
        {
            return new OakTable(101, "Oak Table", 800m, "Custom oak table", length, width);
        }
        public Chair CreateChair(double height)
        {
            return new OakChair(102, "Oak Chair", 300m, "Custom oak chair", height);
        }
        public BookShelf CreateBookShelf(double height, double width, int shelfCount)
        {
            return new OakBookShelf(103, "Oak BookShelf", 500m, "Custom oak bookshelf", height, width, shelfCount);
        }
    }
}
