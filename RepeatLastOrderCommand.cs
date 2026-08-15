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
        private RepeatOrderService receiver;

        public RepeatLastOrderCommand(RepeatOrderService receiver)
        {
            this.receiver = receiver;
        }

        public void Execute()
        {
            receiver.RepeatLastOrder();
        }

        public void Undo()
        {
            receiver.CancelRepeatedOrder();
        }
    }
} 