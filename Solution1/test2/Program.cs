using System;
// See https://aka.ms/new-console-template for more information
List<int> mList = new List<int>();
Random myrandom = new Random();

//Array.Sort(array1);
for (int i = 0; i < 10; i++)
{
    mList.Add(myrandom.Next(100));
}
mList.Sort();
for (int i = 0; i < 10; i++)
    Console.WriteLine(mList[i]);