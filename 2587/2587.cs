#pragma warning disable CS8600, CS8602, CS8604

using System;

int R = 0;
int[] K = new int[5];

for (int i = 0; i < 5; i++)
{
	K[i] = int.Parse(Console.ReadLine());
	R += K[i];
}

Array.Sort(K);
Console.WriteLine(R / 5);
Console.WriteLine(K[2]);