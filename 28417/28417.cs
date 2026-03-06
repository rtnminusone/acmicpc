#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

PriorityQueue<int, int> PQ = new PriorityQueue<int, int>();
int R = int.MinValue;
int N = int.Parse(Console.ReadLine());
while (N-- > 0)
{
	string[] S = Console.ReadLine().Split();
	int r1 = int.MinValue;
	for (int i = 0; i < 2; i++)
	{
		int k = int.Parse(S[i]);
		if (k > r1) r1 = k;
	}
	PQ.Clear();
	for (int i = 2; i < 7; i++)
	{
		int k = int.Parse(S[i]);
		PQ.Enqueue(k, -k);
	}
	int r2 = PQ.Dequeue() + PQ.Dequeue();
	if (R < r1 + r2) R = r1 + r2;
}

Console.WriteLine(R);