//Zi Ying
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    public interface IPaymentStrategy
    {
        string MethodName { get; }

        bool Pay(decimal amount);

        bool Refund(decimal amount);
    }
}
