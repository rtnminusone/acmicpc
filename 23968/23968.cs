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
for (int i = N; i > 1; i--)
{
	for (int j = 1; j < i; j++)
	{
		if (T[j] < T[j - 1])
		{
			k++;
			if (k == K)
			{
				Console.WriteLine(T[j] + " " + T[j - 1]);
				Environment.Exit(0);
			}
			int tmp = T[j - 1];
			T[j - 1] = T[j];
			T[j] = tmp;
		}
	}
}

Console.WriteLine(-1);