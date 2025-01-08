#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;
using System.Text;

Dictionary<string, string> D = new Dictionary<string, string>();
StringBuilder sb = new StringBuilder();

string[] S = Console.ReadLine().Split();
int N = int.Parse(S[0]);
int M = int.Parse(S[1]);

for (int i = 0; i < N; i++)
{
	S = Console.ReadLine().Split();
	D.Add(S[0], S[1]);
}

for (int i = 0; i < M; i++)
{
	sb.AppendLine(D[Console.ReadLine()]);
}

Console.WriteLine(sb);