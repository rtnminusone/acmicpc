#pragma warning disable CS8600, CS8602, CS8604

using System;

string[] S = Console.ReadLine().Split(' ');
int a = int.Parse(S[0]);
int b = int.Parse(S[1]);
int c = int.Parse(S[2]);
int d = int.Parse(S[3]);
int e = int.Parse(S[4]);
int f = int.Parse(S[5]);

for (int x = -999; x < 1000; x++)
{
	for (int y = -999; y < 1000; y++)
	{
		if (a * x + b * y == c && d * x + e * y == f) Console.WriteLine(x + " " + y);
	}
}