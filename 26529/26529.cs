#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

int N = int.Parse(Console.ReadLine());
int[] T = new int[N];
int k = int.MinValue;
for (int i = 0; i < N; i++)
{
	T[i] = int.Parse(Console.ReadLine());
	if (T[i] > k) k = T[i];
}
int[] DP = new int[k + 1];
DP[0] = 1;
DP[1] = 1;
for (int i = 2; i <= k; i++)
{
	DP[i] = DP[i - 1] + DP[i - 2];
}
for (int i = 0; i < N; i++)
{
	Console.WriteLine(DP[T[i]]);
}