using System;
// See https://aka.ms/new-console-template for more information
int[] array1 = new int[10];
Random aRandom = new Random();
for (int i = 0; i < 10; i++)
    array1[i] = aRandom.Next(100);
Array.Sort(array1);
for(int i=0;i<13;i++)
    Console.WriteLine(array1[i]);

