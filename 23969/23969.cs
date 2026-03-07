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
	for (int j = 1; j <= i; j++)
	{
		if (T[j - 1] > T[j])
		{
			k++;
			int tmp = T[j - 1];
			T[j - 1] = T[j];
			T[j] = tmp;
			if (k == K)
			{
				Console.WriteLine(string.Join(" ", T));
				Environment.Exit(0);
			}
		}
	}
}

Console.WriteLine(-1);