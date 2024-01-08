using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test4
{
    internal class MyFunction
    {
        public MyFunction(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }
        public double MyFunc(double x, double y)
        {
            return _a * x * x * x + _b * y * y + _a * _b * x * y + _c;
        }
        private double _a, _b, _c;

    }
}
