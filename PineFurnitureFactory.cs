using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ada
namespace ICKIER_Furniture_Retailer_System
{
    public class PineFurnitureFactory : FurnitureFactory
    {
        public Table CreateTable(double length, double width)
        {
            return new PineTable(201, "Pine Table", 500m, "Custom pine table", length, width);
        }

        public Chair CreateChair(double height)
        {
            return new PineChair(202, "Pine Chair", 200m, "Custom pine chair", height);
        }

        public BookShelf CreateBookShelf(double height, double width, int shelfCount)
        {
            return new PineBookShelf(203, "Pine BookShelf", 400m, "Custom pine bookshelf", height, width, shelfCount);
        }
    }
}
