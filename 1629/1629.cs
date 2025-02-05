#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

long ModExp(long A, long B, long C)
{
	if (B == 0) return 1;
	if (B == 1) return A % C;

	long half = ModExp(A, B / 2, C);
	long result = (half * half) % C;

	if (B % 2 != 0)
	{
		result = (result * A) % C;
	}

	return result;
}

string[] S = Console.ReadLine().Split();

long A = long.Parse(S[0]);
long B = long.Parse(S[1]);
long C = long.Parse(S[2]);

Console.WriteLine(ModExp(A, B, C));