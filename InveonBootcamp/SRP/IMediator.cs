using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.SRP
{
    public interface IMediator
    {
        void Control(System system, Order order);
    }
}
