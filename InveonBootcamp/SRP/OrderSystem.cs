using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.SRP
{
    public class OrderSystem(IMediator mediator) : System(mediator)
    {
        public void Order(Order order)
        {
            _mediator.Control(this, order);
            Console.WriteLine("Siparis tamamlandi." + order.ProductName);
        }
    }
}
