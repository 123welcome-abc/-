using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test3
{
    class B : A
    {
        public override void Function1()
        {
            Console.WriteLine("Function1 in B.");
        }
        public override void Function2() => Console.WriteLine("Function2 in B.");
    }
}
