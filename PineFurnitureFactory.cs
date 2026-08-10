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
        public Table CreateTable()
        {
            return new PineTable();
        }
        public Chair CreateChair()
        {
            return new PineChair();
        }
        public BookShelf CreateBookShelf()
        {
            return new PineBookShelf();
        }
    }
}
