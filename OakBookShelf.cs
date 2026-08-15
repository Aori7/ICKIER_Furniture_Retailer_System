using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ada
namespace ICKIER_Furniture_Retailer_System
{
    public class OakBookShelf : BookShelf
    {
        public OakBookShelf(int id, string name, decimal price, string description, string material, double height, double width, int shelfCount) : base(id, name, price, description, material, height, width, shelfCount)
        {
        }
    }
}
