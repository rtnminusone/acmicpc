#pragma warning disable CS8600, CS8602, CS8604

using System;

string[] S = Console.ReadLine().Split(' ');
int N = int.Parse(S[0]);
int K = int.Parse(S[1]);
int[] R = new int[N];
S = Console.ReadLine().Split(' ');

for (int i = 0; i < N; i++)
{
	R[i] = int.Parse(S[i]);
}

Array.Sort(R);
Console.WriteLine(R[N - K]);