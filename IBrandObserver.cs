//ziying
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    public interface IBrandObserver
    {
        void Update(Brand brand, Promotion promotion);
    }
}
