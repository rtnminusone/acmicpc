#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

int[] T = new int[9];

string S = Console.ReadLine();
for (int i = 0; i < S.Length; i++)
{
	if ('0' <= S[i] && S[i] <= '8') T[S[i] - '0']++;
	else T[6]++;
}
T[6] -= T[6] / 2;

Array.Sort(T);

Console.WriteLine(T[8]);