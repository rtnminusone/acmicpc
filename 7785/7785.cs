#pragma warning disable CS8600, CS8601, CS8602, CS8604

using System;

int N = int.Parse(Console.ReadLine());
Dictionary<string, string> D = new Dictionary<string, string>();
List<string> L = new List<string>();

for (int i = 0; i < N; i++)
{
	string[] S = Console.ReadLine().Split(' ');
	if (D.ContainsKey(S[0]))
	{
		if (S[1] == "leave") D.Remove(S[0]); 
	}
	else
	{
		if (S[1] == "enter") D.Add(S[0], S[1]);
	}
}

foreach (var d in D)
{
	if (d.Value == "enter") L.Add(d.Key);
}

L.Sort();

for (int i = L.Count - 1; i >= 0; i--)
{
	Console.WriteLine(L[i]);
}