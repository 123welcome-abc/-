// See https://aka.ms/new-console-template for more information
using System;
using test3;

static void Test(A aObj)
{
    aObj.Function1();
    aObj.Function2();
}

Test(new B());
Test(new C());

Console.ReadLine();
