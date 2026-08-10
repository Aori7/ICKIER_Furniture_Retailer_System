//Christina
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICKIER_Furniture_Retailer_System
{
    internal class InstallationDecorator : FurnitureDecorator
    {
        private decimal installationFee;

        public decimal InstallationFee { get { return installationFee; } }

        public InstallationDecorator(FurnitureItem furniture, decimal installationFee)
            : base(furniture.FurnitureId, furniture)
        {
            this.installationFee = installationFee;
        }

        public override string GetDescription()
        {
            return furniture.GetDescription() + "\n+ Installation Service";
        }
        public override decimal GetPrice()
        {
            return furniture.GetPrice() + installationFee;
        }
    }
}
