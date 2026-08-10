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
        public Table CreateTable()
        {
            return new SteelTable();
        }
        public Chair CreateChair()
        {
            return new SteelChair();
        }
        public BookShelf CreateBookShelf()
        {
            return new SteelBookShelf();
        }
    }
}
