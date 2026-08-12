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
        public Table CreateTable()
        {
            return new OakTable();
        }
        public Chair CreateChair()
        {
            return new OakChair();
        }
        public BookShelf CreateBookShelf()
        {
            return new OakBookShelf();
        }
    }
}
