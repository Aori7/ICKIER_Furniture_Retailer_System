//Zi Ying
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    public interface IPaymentStrategy
    {
        bool Pay(decimal amount);

        bool Refund(decimal amount);
    }
}
