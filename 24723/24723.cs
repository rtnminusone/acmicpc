#pragma warning disable CS8600, CS8602, CS8604

using System;

int N = int.Parse(Console.ReadLine());
int K = 1;

for (int i = 0; i < N; i++)
{
	K *= 2;
}

Console.WriteLine(K);