#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

string[] S = Console.ReadLine().Split();
int N = int.Parse(S[0]);
int K = int.Parse(S[1]);
int[] T = new int[N];
S = Console.ReadLine().Split();
for (int i = 0; i < N; i++)
{
	T[i] = int.Parse(S[i]);
}
int k = 0;
for (int i = N - 1; i > 0; i--)
{
	int idx = 0;
	for (int j = 0; j <= i; j++)
	{
		if (T[idx] < T[j]) idx = j;
	}
	if (idx != i)
	{
		k++;
		int tmp = T[i];
		T[i] = T[idx];
		T[idx] = tmp;
		if (K == k)
		{
			Console.WriteLine(string.Join(" ", T));
			Environment.Exit(0);
		}
	}
}

Console.WriteLine(-1);