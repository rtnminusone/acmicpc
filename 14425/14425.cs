#pragma warning disable CS8600, CS8601, CS8602, CS8604

using System;

string[] S = Console.ReadLine().Split(' ');
int N = int.Parse(S[0]);
int M = int.Parse(S[1]);

Dictionary<string, int> D = new Dictionary<string, int>();
int R = 0;

for (int i = 0; i < N; i++)
{
	D.Add(Console.ReadLine(), 1);
}

for (int i = 0; i < M; i++)
{
	string T = Console.ReadLine();
	if (D.ContainsKey(T)) R++;
}

Console.WriteLine(R);