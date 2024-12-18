#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;

int N = int.Parse(Console.ReadLine());

string[] S1 = Console.ReadLine().Split(' ');
string[] S2 = Console.ReadLine().Split(' ');

int T = int.Parse(S2[0]);
int P = int.Parse(S2[1]);
int C = 0;

for (int i = 0; i < 6; i++)
{
	int K = int.Parse(S1[i]);
	while (K > 0)
	{
		K -= T;
		C++;
	}
}

Console.WriteLine(C);
Console.WriteLine(N / P + " " + N % P);