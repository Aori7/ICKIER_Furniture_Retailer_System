using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ada
namespace ICKIER_Furniture_Retailer_System
{
    public class RepeatOrderService
    {
        private List<(FurnitureItem item, int qty)> cart;
        private List<(FurnitureItem item, int qty)> lastOrderItems;
        private List<(FurnitureItem item, int qty)> previousCart;

        public RepeatOrderService(List<(FurnitureItem item, int qty)> cart, List<(FurnitureItem item, int qty)> lastOrderItems)
        {
            this.cart = cart;
            this.lastOrderItems = lastOrderItems;
            previousCart = new List<(FurnitureItem item, int qty)>();
        }

        public void RepeatLastOrder()
        {
            previousCart.Clear();
            foreach (var item in cart)
            {
                previousCart.Add(item);
            }
            cart.Clear();

            foreach (var item in lastOrderItems)
            {
                cart.Add(item);
            }
            Console.WriteLine("Previous order items have been added back to the cart.");
        }

        public void CancelRepeatedOrder()
        {
            cart.Clear();
            foreach (var item in previousCart)
            {
                cart.Add(item);
            }
            Console.WriteLine("Repeated order has been undone. Previous cart restored.");
        }
    }
}
