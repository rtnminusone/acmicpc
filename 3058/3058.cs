#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

int T = int.Parse(Console.ReadLine());
while (T-- > 0)
{
	int r = int.MaxValue;
	int R = 0;
	string[] S = Console.ReadLine().Split();
	for (int i = 0; i < 7; i++)
	{
		int t = int.Parse(S[i]);
		if (t % 2 == 0)
		{
			if (t < r) r = t;
			R += t;
		}
	}

	Console.WriteLine(R + " " + r);
}