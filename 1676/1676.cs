#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;
using System.Numerics;

BigInteger B = 1;

int N = int.Parse(Console.ReadLine());

for (int i = 2; i <= N; i++)
{
	B *= i;
}

int C = 0;

while (true)
{
	if (B % 10 != 0) break;
	B /= 10;
	C++;
}

Console.WriteLine(C);