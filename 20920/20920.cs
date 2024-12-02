#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

string[] S = Console.ReadLine().Split(' ');
int N = int.Parse(S[0]);
int M = int.Parse(S[1]);
Dictionary<string, int> D = new Dictionary<string, int>();
StringBuilder sb = new StringBuilder();

for (int i = 0; i < N; i++)
{
	string T = Console.ReadLine();
	if (T.Length >= M)
	{
		if (D.ContainsKey(T)) D[T]++;
		else D.Add(T, 1);
	}
}

var L = D.OrderByDescending(x => x.Value).ThenByDescending(x => x.Key.Length).ThenBy(x => x.Key).Select(x => x.Key).ToList();

foreach (var l in L)
{
	sb.AppendLine(l + "");
}

Console.WriteLine(sb);