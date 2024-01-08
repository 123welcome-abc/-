using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Complex
    {
        public Complex() {
            X = 0;
            Y = 0;
        }
        public Complex(double x,double y) 
        {
            X=x; Y=y;        
        }
        public double X
        {
            get; set;
        }
        public double Y
        {
            get; set;
        }
        public static Complex operator+(Complex c0, Complex c1)
        {
            return new Complex(c1.X + c0.X, c1.Y + c0.Y);
        }
        public static Complex operator -(Complex c0, Complex c1)
        {
            return new Complex(c0.X - c1.X, c0.Y - c1.Y);
        }

        //private double X, Y;
    }
}
