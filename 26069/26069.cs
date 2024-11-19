#pragma warning disable CS8600, CS8602, CS8604

using System;

int N = int.Parse(Console.ReadLine());
Dictionary<string, int> D = new Dictionary<string, int>();

for (int i = 0; i < N; i++)
{
	string[] S = Console.ReadLine().Split(' ');
	if (S[0] == "ChongChong" || S[1] == "ChongChong" || D.ContainsKey(S[0]) || D.ContainsKey(S[1]))
	{
		try
		{
			D.Add(S[0], 1);
		}
		catch (ArgumentException) {}
		try
		{
			D.Add(S[1], 1);
		}
		catch (ArgumentException) {}
	}
}

Console.WriteLine(D.Count);