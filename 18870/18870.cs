#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

int N = int.Parse(Console.ReadLine());
string[] S = Console.ReadLine().Split(' ');

int[] K = new int[N];
int[] R = new int[N];

StringBuilder sb = new StringBuilder();
Dictionary<int, int> D = new Dictionary<int, int>();
int X = 0;

for (int i = 0; i < N; i++)
{
	K[i] = int.Parse(S[i]);
	R[i] = int.Parse(S[i]);
}

Array.Sort(R);

D.Add(R[0], X++);

for (int i = 1; i < N; i++)
{
	if (R[i - 1] != R[i]) D.Add(R[i], X++);
}

for (int i = 0; i < N; i++)
{
	sb.Append(D[K[i]] + " ");
}

Console.WriteLine(sb);