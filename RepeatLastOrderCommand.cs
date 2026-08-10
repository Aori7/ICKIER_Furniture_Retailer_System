using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ada
namespace ICKIER_Furniture_Retailer_System
{
    public class RepeatLastOrderCommand : OrderCommand
    {
        private OrderFacade receiver;
        private Customer cust;
        private Order repeatedOrder;

        public RepeatLastOrderCommand(OrderFacade receiver, Customer cust)
        {
            this.receiver = receiver;
            this.cust = cust;
        }
        public void Execute()
        {
            repeatedOrder = receiver.RepeatLastOrder(cust);
        }
        public void Undo()
        {
            if (repeatedOrder != null)
            {
                receiver.CancelOrder(repeatedOrder);
            }
        }
    } 
}
