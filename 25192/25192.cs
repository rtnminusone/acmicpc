#pragma warning disable CS8600, CS8602, CS8604

using System;

int N = int.Parse(Console.ReadLine());
int K = 0;
Dictionary<string, int> D = new Dictionary<string, int>();

for (int i = 0; i < N; i++)
{
	string S = Console.ReadLine();
	if (S == "ENTER")
	{
		K += D.Count;
		D = new Dictionary<string, int>();
	}
	else
	{
		try
		{
			D.Add(S, 1);
		}
		catch (ArgumentException) {}
	}
}
if (D.Count != 0) K += D.Count;

Console.WriteLine(K);