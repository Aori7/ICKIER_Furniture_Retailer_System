using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ada
namespace ICKIER_Furniture_Retailer_System
{
    public class OrderCommandInvoker
    {
        private OrderCommand command;
        public void SetCommand(OrderCommand command)
        {
            this.command = command;
        }
        public void ExecuteCommand()
        {
            command.Execute();
        }
        public void UndoCommand()
        {
            command.Undo();
        }
    }
}
