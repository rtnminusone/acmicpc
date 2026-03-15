#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

int N = int.Parse(Console.ReadLine());
(int, int)[] T = new (int, int)[N];
for (int i = 0; i < N; i++)
{
	string[] S = Console.ReadLine().Split();
	T[i] = (int.Parse(S[0]), int.Parse(S[1]));
}
Array.Sort(T, (a, b) => 
{
	if (a.Item1 != b.Item1) return a.Item1.CompareTo(b.Item1);
	return a.Item2.CompareTo(b.Item2);
});
int M = int.MaxValue;
int R = 0;
for (int i = 0; i < N; i++)
{
	if (T[i].Item2 < M)
	{
		R++;
		M = T[i].Item2;
	}
}

Console.WriteLine(R);