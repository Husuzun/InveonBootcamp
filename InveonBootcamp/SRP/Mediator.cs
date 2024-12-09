using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.SRP
{
    public class Mediator : IMediator
    {
        InventorySystem _inventorySystem;
        NotificationSystem _notificationSystem;
        OrderSystem _orderSystem;

        public InventorySystem inventorySystem { set => _inventorySystem = value; }
        public NotificationSystem notificationSystem { set => _notificationSystem = value; }
        public OrderSystem orderSystem { set => _orderSystem = value; }

        public void Control(System system, Order order)
        {
            if (system is NotificationSystem)
            {

            }
            else if(system is InventorySystem)
            {

            }
            else if (system is OrderSystem) {
                _inventorySystem.CheckInventory(order);
                _notificationSystem.SendNotification(order);
            }
        }

    }
}
