#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

int N = int.Parse(Console.ReadLine());
int[] T = new int[N];
string[] S = Console.ReadLine().Split();
for (int i = 0; i < N; i++)
{
	T[i] = int.Parse(S[i]);
}
Array.Sort(T);
int R1 = int.MaxValue;
int R2 = 0;
for (int i = 0; i < N - 1; i++)
{
	if (Math.Abs(T[i] - T[i + 1]) < R1)
	{
		R1 = Math.Abs(T[i] - T[i + 1]);
		R2 = 1;
	}
	else if (Math.Abs(T[i] - T[i + 1]) == R1) R2++;
}

Console.WriteLine(R1 + " " + R2);