// See https://aka.ms/new-console-template for more information
using test4;
MyFunction aFunction = new MyFunction(1.0, 2.0, 3.0);
double Fun1 = aFunction.MyFunc(1.0, 2.0);
double Fun2 = aFunction.MyFunc(2.0, 4.0);
double Fun3 = aFunction.MyFunc(3.0, 6.0);
Console.WriteLine(Fun1);
Console.WriteLine(Fun2);
Console.WriteLine(Fun3);
