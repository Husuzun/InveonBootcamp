using InveonBootcamp.LSP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp
{
    public class LSPTest
    {
        public static void Run()
        {
            Console.WriteLine("\nLSP \n");
            OldBird oldBird = new OldPenguin();
            //oldBird.Fly();
            Bird bird = new Eagle();
            bird.Breath();
            //bird.Fly();
            if(bird is IFly birdFly)
            {
                birdFly.Fly();
            }

        }
    }
}
