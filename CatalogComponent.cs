// Rui Min - Composite pattern
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    public abstract class CatalogComponent
    {
        // does not allow leaf to add children
        public virtual void Add(CatalogComponent component)
        {
            throw new NotSupportedException();
        }

        // does not allow leaf to remove children
        public virtual void Remove(CatalogComponent component)
        {
            throw new NotSupportedException();
        }

        // does not allow leaf to get children
        public virtual CatalogComponent GetChild(int index)
        {
            throw new NotSupportedException();
        }

        public virtual string GetDescription()
        {
            throw new NotSupportedException();
        }

        //public virtual string Display()
        //{
        //    throw new NotSupportedException();
        //}
    }
}

/* side notes:
 * throw new NotSupportedException();
 *      throw - stops operation and declares that its not allowed
 *              eg.) a leaf tries to add a children under itself. the method stops this
 *              
 */
