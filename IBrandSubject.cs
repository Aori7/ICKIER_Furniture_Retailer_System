//ziying
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    public interface IBrandSubject
    {
        void Subscribe(IBrandObserver observer);

        void Unsubscribe(IBrandObserver observer);

        void NotifyObservers(Promotion promotion);
    }
}
