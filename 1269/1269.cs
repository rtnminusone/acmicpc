#pragma warning disable CS8600, CS8602, CS8604

using System;

string[] S = Console.ReadLine().Split(' ');
int N = int.Parse(S[0]);
int M = int.Parse(S[1]);
HashSet<int> A1 = new HashSet<int>();
HashSet<int> A2 = new HashSet<int>();
HashSet<int> B = new HashSet<int>();

S = Console.ReadLine().Split(' ');
for (int i = 0; i < N; i++)
{
	A1.Add(int.Parse(S[i]));
	A2.Add(int.Parse(S[i]));
}

S = Console.ReadLine().Split(' ');
for (int i = 0; i < M; i++)
{
	A1.Remove(int.Parse(S[i]));
	B.Add(int.Parse(S[i]));
}

foreach (int i in A2)
{
	B.Remove(i);
}

A1.UnionWith(B);

Console.WriteLine(A1.Count);