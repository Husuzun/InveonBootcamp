using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.LSP
{
    public class Eagle : Bird, IFly
    {
        public void Fly()
        {
            Console.WriteLine("Flying.");
        }
    }
}
