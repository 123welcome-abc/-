//using System.Numerics;
using ClassLibrary1;
namespace Test001
{
    [TestClass]
    public class ComplexTests
    {
        [TestMethod]
        public void ComplexAddTest()
        {
            Complex c1 = new Complex(1, 2);
            Complex c2 = new Complex(3, 4);
            Complex c3 = c1 + c2;

            Console.WriteLine($"{c1.X}+{c1.Y}i + {c2.X}+{c2.Y}i = {c3.X}+{c3.Y}i");
            Assert.AreEqual(4, c3.X);
            Assert.AreEqual(6, c3.Y);
        }

        [TestMethod]
        public void ComplexSubTest()
        {
            Complex c1 = new Complex(4, 7);
            Complex c2 = new Complex(1, 2);
            Complex c3 = c1 - c2;

            Assert.AreEqual(3, c3.X);
            Assert.AreEqual(5, c3.Y);
        }
    }
}