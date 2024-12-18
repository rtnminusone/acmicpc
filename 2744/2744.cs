#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;

char[] C = Console.ReadLine().ToCharArray();

for (int i = 0; i < C.Length; i++)
{
	if ('A' <= C[i] && C[i] <= 'Z') C[i] = (char)(C[i] + 'a' - 'A');
	else C[i] = (char)(C[i] + 'A' - 'a');
}

Console.WriteLine(new string(C));