#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

string S = Console.ReadLine();
int R0 = 0;
int R1 = 0;
if (S[0] == '0') R0++;
else R1++;
if (S.Length == 1) R0 = R1 = 1;
for (int i = 1; i < S.Length; i++)
{
	if (S[i] == S[i - 1]) continue;
	if (S[i] == '0') R0++;
	else R1++;
}

Console.WriteLine(Math.Min(R0, R1));