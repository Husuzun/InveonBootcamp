using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.SRP
{
    public abstract class System
    {
        protected IMediator _mediator;
        public System(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
