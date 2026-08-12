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
        public Table CreateTable();
        public Chair CreateChair();
        public BookShelf CreateBookShelf();
    }
}
