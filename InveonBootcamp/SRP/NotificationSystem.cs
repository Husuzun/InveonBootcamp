using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.SRP
{
    public class NotificationSystem(IMediator mediator) : System(mediator)
    {
        public void SendNotification(Order order)
        {
            _mediator.Control(this, order);
            Console.WriteLine("Bildirim gonderildi." + order.ProductName);
        }
    }
}
