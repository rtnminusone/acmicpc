#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

int N = int.Parse(Console.ReadLine());
int[] T = new int[N];
int[] K = new int[N];
string[] S1 = Console.ReadLine().Split();
string[] S2 = Console.ReadLine().Split();
for (int i = 0; i < N; i++)
{
	T[i] = int.Parse(S1[i]);
	K[i] = int.Parse(S2[i]);
}
if (T.SequenceEqual(K))
{
	Console.WriteLine(1);
	Environment.Exit(0);
}
for (int i = N - 1; i > 0; i--)
{
	int idx = 0;
	for (int j = 0; j <= i; j++)
	{
		if (T[idx] < T[j]) idx = j;
	}
	if (idx != i)
	{
		int tmp = T[i];
		T[i] = T[idx];
		T[idx] = tmp;
		if (T.SequenceEqual(K))
		{
			Console.WriteLine(1);
			Environment.Exit(0);
		}
	}
}

Console.WriteLine(0);