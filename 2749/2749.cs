#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

ulong N = ulong.Parse(Console.ReadLine());
int[] F = new int[1000000 / 10 * 15];

if (N == 0) Console.WriteLine(0);
else if (N == 1) Console.WriteLine(1);
else
{
	F[0] = 0;
	F[1] = 1;
	for (int i = 2; i < 1000000 / 10 * 15; i++)
	{
		F[i] = (F[i - 2] + F[i - 1]) % 1000000;
	}
	Console.WriteLine(F[N % (1000000 / 10 * 15)]);
}