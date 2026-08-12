using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICKIER_Furniture_Retailer_System
{
    internal class BookshelfCreator : FurnitureCreator
    {
        public override FurnitureItem CreateFurniture()
        {
            return new BookShelf(3, "Basic Bookshelf", 200m, "Basic Furniture Bookshelf", "Basic", 180, 80, 5);
        }
    }
}
