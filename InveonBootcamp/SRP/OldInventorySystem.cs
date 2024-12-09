using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.SRP
{
    public class OldInventorySystem
    {
        public void CheckInventory(Order order)
        {
            Console.WriteLine("Envanter kontrol edildi." + order.ProductName);
        }
    }
}
