#pragma warning disable CS8600, CS8601, CS8602, CS8604

using System;
using System.Text;

string[] S = Console.ReadLine().Split(' ');
int N = int.Parse(S[0]);
int M = int.Parse(S[1]);
HashSet<string> H = new HashSet<string>();
List<string> K = new List<string>();
StringBuilder sb = new StringBuilder();

for (int i = 0; i < N; i++)
{
	H.Add(Console.ReadLine());
}

for (int i = 0; i < M; i++)
{
	string T = Console.ReadLine();
	if (!H.Add(T)) K.Add(T);
}

K.Sort();

sb.AppendLine(K.Count + "");

foreach (var k in K)
{
	sb.AppendLine(k);
}

Console.WriteLine(sb);