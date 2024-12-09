using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.SRP
{
    public class OldOrderSystem
    {
        private OldInventorySystem _oldInventorySystem;
        private OldNotificationSystem _oldNotificationSystem;
        public OldOrderSystem(OldInventorySystem oldInventorySystem, OldNotificationSystem oldNotificationSystem)
        {
            _oldInventorySystem = oldInventorySystem;
            _oldNotificationSystem = oldNotificationSystem;
        }

        public void Order(Order order)
        {
            _oldInventorySystem.CheckInventory(order);
            _oldNotificationSystem.SendNotification(order);
            Console.WriteLine("Siparis tamamlandi." + order.ProductName);
        }
        
    }

}
