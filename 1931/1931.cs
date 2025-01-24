#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

Dictionary<int, int> D = new Dictionary<int, int>();
int N = int.Parse(Console.ReadLine());
List<int> L = new List<int>();
int R = 0;

for (int i = 0; i < N; i++)
{
	string[] S = Console.ReadLine().Split();
	int key = int.Parse(S[1]);
	int value = int.Parse(S[0]);
	if (D.ContainsKey(key))
	{
		if (key == value) R++;
		else if (D[key] == key || D[key] < value)
		{
			if (D[key] == key) R++;
			D[key] = value;
		}
	}
	else
	{
		D[key] = value;
		L.Add(key);
	}
}

N = L.Count;
L.Sort();

int last = 0;
foreach (var l in L)
{
	if (D[l] >= last)
	{
		last = l;
		R++;
	}
}

Console.WriteLine(R);