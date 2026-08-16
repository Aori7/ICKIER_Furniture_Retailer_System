// Rui Min - Iterator pattern

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICKIER_Furniture_Retailer_System
{
    public interface IFurnitureIterator
    {
        bool HasNext();
        FurnitureItem Next();
    }
}
