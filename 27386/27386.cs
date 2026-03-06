#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

PriorityQueue<char, char> PQ = new PriorityQueue<char, char>();

for (int t = 0; t < 2; t++)
{
	string S = Console.ReadLine();
	for (int i = 0; i < S.Length; i++)
	{
		PQ.Enqueue(S[i], S[i]);
	}
}

while (PQ.Count > 0)
{
	Console.Write(PQ.Dequeue());
}