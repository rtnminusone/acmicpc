#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

PriorityQueue<string, string> PQ = new PriorityQueue<string, string>();

while (true)
{
	PQ.Clear();
	int N = int.Parse(Console.ReadLine());
	if (N == 0) break;
	for (int i = 0; i < N; i++)
	{
		string S = Console.ReadLine();
		PQ.Enqueue(S, S.ToLower());
	}

	Console.WriteLine(PQ.Dequeue());
}