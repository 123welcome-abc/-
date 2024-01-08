// See https://aka.ms/new-console-template for more information
using test6;

static double F(double x) => Math.Sin(x);
DrawBoard aFunction = new DrawBoard(80, 40);
aFunction.Draw(F,0.0, 1.0, 2*Math.PI,-1.0);
//aFunction.Draw(F, -10, 10, -10, 10);