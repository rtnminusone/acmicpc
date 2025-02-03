#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

string[] S = Console.ReadLine().Split();

long A = long.Parse(S[0]);
long B = long.Parse(S[1]);
long N = long.Parse(S[2]);

for (int i = 0; i < N; i++)
{
	A %= B;
	A *= 10;
}

Console.WriteLine(A / B % 10);