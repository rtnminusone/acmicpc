#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

PriorityQueue<int, int> PQ = new PriorityQueue<int, int>();
StringBuilder sb = new StringBuilder();
while (true)
{
	PQ.Clear();
	int N = int.Parse(Console.ReadLine());
	if (N == 0) break;
	string[] S = Console.ReadLine().Split();
	for (int i = 0; i < N; i++)
	{
		int k = int.Parse(S[i]);
		PQ.Enqueue(k, k);
	}
	int R = int.MaxValue;
	int last = PQ.Dequeue();
	while (PQ.Count > 0)
	{
		int cur = PQ.Dequeue();
		if (Math.Abs(cur - last) < R) R = Math.Abs(cur - last);
		last = cur;
	}

	sb.AppendLine(R.ToString());
}

Console.WriteLine(sb.ToString());