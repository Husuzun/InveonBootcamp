using InveonBootcamp.SRP;

namespace InveonBootcamp
{
    public class SRPTest
    {
        public static void Run()
        {
            Console.WriteLine("\nSRP \n");
            OldInventorySystem oldInventorySystem = new OldInventorySystem();
            OldNotificationSystem oldNotificationSystem = new OldNotificationSystem(); 
            OldOrderSystem oldOrderSystem = new OldOrderSystem(oldInventorySystem, oldNotificationSystem);
            Order newOrder = new Order {ProductName = "TV", Quantity = 1 };
            oldOrderSystem.Order(newOrder);

            Mediator mediator = new Mediator();
            InventorySystem inventorySystem = new InventorySystem(mediator);
            NotificationSystem notificationSystem = new NotificationSystem(mediator);
            OrderSystem orderSystem = new OrderSystem(mediator);

            mediator.inventorySystem = inventorySystem;
            mediator.notificationSystem = notificationSystem;
            mediator.orderSystem = orderSystem;
            Order newOrder2 = new Order { ProductName = "PS4", Quantity = 2 };
            orderSystem.Order(newOrder2);
        }
    }
} 