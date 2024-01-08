using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test3
{
    abstract class A
    {
        public abstract void Function1();
        public virtual void Function2()
        {
            Console.WriteLine("Function2 in A.");
        }
    }
}
