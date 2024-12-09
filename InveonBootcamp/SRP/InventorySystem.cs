using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.SRP
{
    public class InventorySystem(IMediator mediator) : System(mediator)
    {
        public void CheckInventory(Order order)
        {
            _mediator.Control(this, order);
            Console.WriteLine("Envanter kontrol edildi." + order.ProductName);
        }
    }
}
