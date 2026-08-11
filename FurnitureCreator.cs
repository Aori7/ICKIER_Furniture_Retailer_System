using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ada
namespace ICKIER_Furniture_Retailer_System
{
    public abstract class FurnitureCreator
    {
        //factory method
        public abstract FurnitureItem CreateFurniture();
        public FurnitureItem OrderFurniture()
        {
            FurnitureItem f = CreateFurniture();
            Console.WriteLine($"Furniture created: {f.GetDescription()}");
            return f;
        }
    }
}
