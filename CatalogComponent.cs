// Rui Min - Composite pattern
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    public abstract class CatalogComponent
    {
        public virtual string Name
        {
            get { throw new NotSupportedException(); }
        }

        public virtual void Add(CatalogComponent component)
        {
            throw new NotSupportedException();
        }

        public virtual void Remove(CatalogComponent component)
        {
            throw new NotSupportedException();
        }

        public virtual CatalogComponent GetChild(int index)
        {
            throw new NotSupportedException();
        }

        public virtual string GetDescription()
        {
            throw new NotSupportedException();
        }
    }
}

/* side notes:
 * throw new NotSupportedException();
 *      throw - stops operation and declares that its not allowed
 *              eg.) a leaf tries to add a children under itself. the method stops this
 *              
 */
