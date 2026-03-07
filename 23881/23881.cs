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
	int M1 = int.MinValue;
	int M2 = -1;
	for (int j = 0; j <= i; j++)
	{
		if (T[j] > M1)
		{
			M1 = T[j];
			M2 = j;
		}
	}
	if (T[M2] > T[i])
	{
		k++;
		if (k == K)
		{
			Console.WriteLine(T[i] + " " + T[M2]);
			Environment.Exit(0);
		}
		int tmp = T[M2];
		T[M2] = T[i];
		T[i] = tmp;
	}
}

Console.WriteLine(-1);