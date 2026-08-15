using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ada
namespace ICKIER_Furniture_Retailer_System
{
    public class OakChair: Chair
    {
        public OakChair(int id, string name, decimal price, string description, string material, double height) : base(id, name, price, description, material, height)
        {
        }
    }
}
