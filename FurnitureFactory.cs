using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ada
namespace ICKIER_Furniture_Retailer_System
{
    public interface FurnitureFactory
    {
        public Table CreateTable(double length, double width); // customers able to choose the length and width of the table
        public Chair CreateChair(double height);
        public BookShelf CreateBookShelf(double height, double width, int shelfCount);
    }
}
