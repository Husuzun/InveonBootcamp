using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.SRP
{
    public class OldNotificationSystem
    {
        public void SendNotification(Order order)
        {
            Console.WriteLine("Bildirim gonderildi." + order.ProductName);
        }
    }
}
