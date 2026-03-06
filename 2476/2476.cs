#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

Dictionary<int, int> D = new Dictionary<int, int>();

int N = int.Parse(Console.ReadLine());
int R = int.MinValue;
for (int i = 0; i < N; i++)
{
	D.Clear();
	string[] S = Console.ReadLine().Split();
	for (int j = 0; j < 3; j++)
	{
		int t = int.Parse(S[j]);
		if (D.ContainsKey(t)) D[t]++;
		else D[t] = 1;
	}
	int r = 0;
	if (D.Count == 3) r = D.Keys.Max() * 100;
	else if (D.Count == 2) r = D.First(x => x.Value == 2).Key * 100 + 1000;
	else r = D.First().Key * 1000 + 10000;

	if (r > R) R = r;
}

Console.WriteLine(R);